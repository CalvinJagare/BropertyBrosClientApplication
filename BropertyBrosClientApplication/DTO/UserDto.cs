using BropertyBrosApi2._0.DTOs;
using System.ComponentModel.DataAnnotations;

namespace BropertyBrosClientApplication.DTO
{
    public class UserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}