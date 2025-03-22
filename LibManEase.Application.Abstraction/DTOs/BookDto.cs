namespace LibManEase.Application.Abstraction.DTOs
{
    public class BookDto : BaseDto
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int PublicationYear { get; set; }
        public bool IsAvailable { get; set; }
    }

    public class CreateBookDto
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int PublicationYear { get; set; }
    }

    public class UpdateBookDto : BaseDto
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int PublicationYear { get; set; }
        public bool IsAvailable { get; set; }
    }
}
