using System;
using System.ComponentModel.DataAnnotations;

namespace baykuslar_api.Data.Entities
{
    public class EquityFundingInvestmentEntity
    {
        public string UserId { get; set; }
        public int EquityFundingPostId { get; set; }
        [Required]
        public int ShareCount { get; set; }
        public string Message { get; set; }
        [Required]
        public DateTime Date { get; set; }
        
        public UserEntity User { get; set; }
        public EquityFundingPostEntity EquityFundingPost { get; set; }
    }
}