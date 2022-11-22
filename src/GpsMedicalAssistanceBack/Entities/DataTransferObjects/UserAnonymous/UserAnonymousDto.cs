using Entities.DataTransferObjects.AlertUser;

namespace Entities.DataTransferObjects.UserAnonymous
{
    public class UserAnonymousDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Identification { get; set; }

        public string Phone { get; set; }

        public short? Age { get; set; }

        public string Gender { get; set; }

        public float? Height { get; set; }


        public AlertUserDto AlertUser { get; set; }
    }
}