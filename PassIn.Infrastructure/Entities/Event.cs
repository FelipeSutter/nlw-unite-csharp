namespace PassIn.Infrastructure.Entities
{
    public class Event
    {

        public Guid Id { get; set; } = Guid.NewGuid(); // Significa que quando fizer um new Event, o Id vai vir preenchido
        public string Title { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public int Maximum_Attendees { get; set; }

    }
}
