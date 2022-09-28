namespace GpsMedicalAssistanceBack.Utils.Authentication
{
    public class AuthenticationSettings
    {
        public const string FieldEmail = "Email";
        public const string FieldFamilies = "Families";
        public const string FieldImagePath = "ImagePath";

        public const string ErrorMessageUserAlreadyExists = "User already exists";
        public const string ErrorMessageUserWasNotFound = "User was not found";
        public const string ErrorMessageFamiliesIdFamilyType = "Some family types weren't found";
        public const string ErrorMessageImagePath = "There was an error creating face image";
    }
}
