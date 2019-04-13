using System;
using baykuslar_api.Contract;

namespace baykuslar_api.Data.Entities
{
    public class EquityFundingPostEntity : EntityBase<int>
    {
        public string UserId { get; set; }
        public string Title { get; set; }
        public double SharePrice { get; set; }
        public int TargetShare { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public UserEntity User { get; set; }
        
    }
}