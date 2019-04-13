using System;

namespace baykuslar_api.Contract.Models
{
    public class FundraisingPostModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public double TargetAmount { get; set; }
        public DateTime Deadline { get; set; }
        public double FundedAmount { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }            
        public string TargetIban { get; set; }
    }
}