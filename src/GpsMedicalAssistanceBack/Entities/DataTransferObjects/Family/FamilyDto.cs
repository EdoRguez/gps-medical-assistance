using Entities.DataTransferObjects.User;
using Entities.DataTransferObjects.FamilyType;

namespace Entities.DataTransferObjects.Family
{
    public class FamilyDto
    {
        public int Id { get; set; }
        public int Id_User { get; set; }
        public int Id_FamilyType { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Identification { get; set; }
        public string Phone { get; set; }

        public UserDto User { get; set; }
        public FamilyTypeDto FamilyType { get; set; }
    }
}
