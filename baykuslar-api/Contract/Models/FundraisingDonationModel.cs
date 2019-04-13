using System;

namespace baykuslar_api.Contract.Models
{
    public class FundraisingDonationModel
    {
        public string UserId { get; set; }
        public int FundraisingPostId { get; set; }
        public double Amount { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}