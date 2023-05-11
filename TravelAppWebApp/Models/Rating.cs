namespace TravelAppWebApp.Models
{
    public class Rating
    {
        public int RatingId { get; set; }
        public string Comments { get; set; }
        public int? Rating1 { get; set; }
        public int? BookingId { get; set; }
    }
}
