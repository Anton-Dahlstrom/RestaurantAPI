namespace RestaurantAPI.DTOs
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public required int CustomerIdFk { get; set; }
        public required int TableIdFk { get; set; }
        public required DateTime DateTime { get; set; }
        public required int GuestCount { get; set; }
    }
}
