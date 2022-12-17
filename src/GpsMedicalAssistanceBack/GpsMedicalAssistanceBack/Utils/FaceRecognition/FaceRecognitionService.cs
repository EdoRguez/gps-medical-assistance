using System.Net.Http.Headers;
using System.Text.Json;
using Entities.Utils;

namespace GpsMedicalAssistanceBack.Utils.FaceRecognition
{
    public static class FaceRecognitionService
    {
        public static async Task<FaceRecognitionResult> CreateFace(IFormFile file, int userId)
        {
            FaceRecognitionResult result = new FaceRecognitionResult() { isSuccess = false };

            try
            {
                HttpClient httpClient = new HttpClient();

                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName?.Trim();

                using (var content = new MultipartFormDataContent())
                {
                    JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

                    content.Add(new StringContent("label"), userId.ToString());
                    content.Add(new StreamContent(file.OpenReadStream())
                    {
                        Headers =
                        {
                            ContentLength = file.Length,
                            ContentType = new MediaTypeHeaderValue(file.ContentType)
                        }
                    }, "File1", fileName);

                    var response = await httpClient.PostAsync("http://localhost:3000/post-face", content);

                    var finalResult = await response.Content.ReadAsStringAsync();
                    FaceRecognitionPostFaceResponse postFaceResponse = JsonSerializer.Deserialize<FaceRecognitionPostFaceResponse>(finalResult, jsonSerializerOptions);
                    result.isSuccess = postFaceResponse.isSuccess;
                }
            }
            catch (Exception)
            {
                result.isSuccess = false;
            }

            return result;
        }

        public static async Task<FaceRecognitionResult> CheckFace(IFormFile file)
        {
            FaceRecognitionResult result = new FaceRecognitionResult() { isSuccess = false };

            try
            {
                HttpClient httpClient = new HttpClient();

                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName?.Trim();

                using (var content = new MultipartFormDataContent())
                {
                    JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

                    content.Add(new StreamContent(file.OpenReadStream())
                    {
                        Headers =
                        {
                            ContentLength = file.Length,
                            ContentType = new MediaTypeHeaderValue(file.ContentType)
                        }
                    }, "File1", fileName);

                    var response = await httpClient.PostAsync("http://localhost:3000/check-face", content);

                    var finalResult = await response.Content.ReadAsStringAsync();
                    FaceRecognitionCheckFaceResponse checkFaceResponse = JsonSerializer.Deserialize<FaceRecognitionCheckFaceResponse>(finalResult, jsonSerializerOptions);

                    if (int.TryParse(checkFaceResponse._label, out int n))
                    {
                        result = new FaceRecognitionResult()
                        {
                            Id_User = int.Parse(checkFaceResponse._label),
                            Distance = checkFaceResponse._distance,
                            isSuccess = true
                        };
                    }
                }
            }
            catch (Exception)
            {
                result.isSuccess = false;
            }

            return result;
        }
    }
}