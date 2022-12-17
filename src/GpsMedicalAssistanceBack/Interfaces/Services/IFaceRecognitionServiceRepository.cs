using Entities.Utils;
using Microsoft.AspNetCore.Http;

namespace Interfaces.Services
{
    public interface IFaceRecognitionServiceRepository
    {
        Task<FaceRecognitionResult> CreateFace(IFormFile file, int userId);
        Task<FaceRecognitionResult> CheckFace(IFormFile file);
    }
}