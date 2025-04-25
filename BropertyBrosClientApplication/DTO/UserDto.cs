using System.ComponentModel.DataAnnotations;

namespace BropertyBrosApi2._0.DTOs
{
    public class UserDto
    {

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}