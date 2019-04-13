using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace baykuslar_api.Data.Entities
{
    public class UserEntity: IdentityUser
    {
        [Required] public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required] public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}