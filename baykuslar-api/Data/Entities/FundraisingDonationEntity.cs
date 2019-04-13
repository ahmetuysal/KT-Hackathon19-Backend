using System;
using System.ComponentModel.DataAnnotations;

namespace baykuslar_api.Data.Entities
{
    public class FundraisingDonationEntity
    {
        public string UserId { get; set; }
        public int FundraisingPostId { get; set; }
        [Required]
        public double Amount { get; set; }
        public string Message { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public UserEntity User { get; set; }
        public FundraisingPostEntity FundraisingPost { get; set; }
    }
}