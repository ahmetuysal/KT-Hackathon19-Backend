using System;

namespace baykuslar_api.Contract.Models
{
    public class EquityFundingPostModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }    
        public double SharePrice { get; set; }
        public int TargetShare { get; set; }
        public DateTime Deadline { get; set; }
        public int SoldShare { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }            
    }
}