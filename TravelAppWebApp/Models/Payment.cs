namespace TravelAppWebApp.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int? BookingId { get; set; }
        public decimal? TotalAmount { get; set; }
        public string PaymentStatus { get; set; }
    }
}
