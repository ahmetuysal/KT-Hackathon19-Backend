using System;
using System.Collections.Generic;
using baykuslar_api.Contract;

namespace baykuslar_api.Data.Entities
{
    public class FundraisingPostEntity : EntityBase<int>
    {
        public string UserId { get; set; }
        public string Title { get; set; }
        public double TargetAmount { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string TargetIban { get; set; }

        // 1 : many
        public UserEntity User { get; set; }
        
        // many : many
        public virtual IEnumerable<FundraisingDonationEntity> FundraisingDonations { get; set; }
        
    }
}