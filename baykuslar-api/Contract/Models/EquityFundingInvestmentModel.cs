using System;

namespace baykuslar_api.Contract.Models
{
    public class EquityFundingInvestmentModel
    {
        public string UserId { get; set; }
        public int EquityFundingPostId { get; set; }
        public int ShareCount { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}