namespace Entities.Utils
{
    public class FaceRecognitionResult
    {
        public int? Id_User { get; set; }
        public double? Distance { get; set; }
        public bool isSuccess { get; set; }
    }
}