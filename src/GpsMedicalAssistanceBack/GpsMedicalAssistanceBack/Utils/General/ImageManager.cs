using System.Text.RegularExpressions;

namespace GpsMedicalAssistanceBack.Utils.General
{
    public static class ImageManager
    {
        public static string Base64ToImagePath(string base64, string imageName, string folderName, IWebHostEnvironment env)
        {
            try
            {
                string path = System.IO.Path.Combine(env.ContentRootPath, folderName);

                //Check if directory exist
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
                }

                string fileExtension = GetFileExtension(base64);
                if (string.IsNullOrEmpty(fileExtension))
                    return null;

                string img = imageName + fileExtension;

                //set the image path
                string imgPath = Path.Combine(path, img);

                Regex regex = new Regex(@"^[\w/\:.-]+;base64,");
                base64 = regex.Replace(base64, string.Empty);

                byte[] imageBytes = Convert.FromBase64String(base64);

                File.WriteAllBytes(imgPath, imageBytes);
                return imgPath;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static string GetFileExtension(string base64String)
        {
            var data = base64String.Substring(0, base64String.IndexOf(';'));

            if(data.ToUpper().Contains("PNG"))
            {
                return ".png";
            }
            else if(data.ToUpper().Contains("JPG"))
            {
                return ".jpg";
            }
            else if (data.ToUpper().Contains("JPEG"))
            {
                return ".jpeg";
            }
            else
            {
                return null;
            }
        }
    }
}
