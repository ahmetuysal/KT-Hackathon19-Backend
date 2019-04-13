using System;
using System.Collections.Generic;
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
        public string Image { get; set; }
        
        // 1 : many
        public virtual IEnumerable<EquityFundingPostEntity> EquityFundingPosts { get; set; }
        public virtual IEnumerable<FundraisingPostEntity> FundraisingPosts { get; set; }
        
        // many : many
        public virtual IEnumerable<EquityFundingInvestmentEntity> EquityFundingInvestments { get; set; }
        public virtual IEnumerable<FundraisingDonationEntity> FundraisingDonations { get; set; }

    }
}