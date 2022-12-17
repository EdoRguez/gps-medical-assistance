using System.Net.Http.Headers;
using System.Text.Json;
using Entities.Utils;
using Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace Repository.Services
{
    public class FaceRecognitionServiceRepository : IFaceRecognitionServiceRepository
    {
        private readonly HttpClient _http;
        private string _baseURL = "http://localhost:3000";

        public FaceRecognitionServiceRepository(HttpClient http)
        {
            _http = http;
        }

        public async Task<FaceRecognitionResult> CheckFace(IFormFile file)
        {
            FaceRecognitionResult result = new FaceRecognitionResult() { isSuccess = false };

            try
            {
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
                    }, "File1", "check");

                    var response = await _http.PostAsync($"{_baseURL}/check-face", content);

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

        public async Task<FaceRecognitionResult> CreateFace(IFormFile file, int userId)
        {
            FaceRecognitionResult result = new FaceRecognitionResult() { isSuccess = false };

            try
            {
                using (var content = new MultipartFormDataContent())
                {
                    JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

                    content.Add(new StringContent(userId.ToString()), "label");
                    content.Add(new StreamContent(file.OpenReadStream())
                    {
                        Headers =
                        {
                            ContentLength = file.Length,
                            ContentType = new MediaTypeHeaderValue(file.ContentType)
                        }
                    }, "File1", userId.ToString());

                    var response = await _http.PostAsync($"{_baseURL}/post-face", content);

                    var finalResult = await response.Content.ReadAsStringAsync();
                    FaceRecognitionPostFaceResponse postFaceResponse = JsonSerializer.Deserialize<FaceRecognitionPostFaceResponse>(finalResult, jsonSerializerOptions);
                    result.isSuccess = postFaceResponse.isSuccess;
                }
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
            }

            return result;
        }
    }
}