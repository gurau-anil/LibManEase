using LibManEase.Domain.Entities.Base;

namespace LibManEase.Domain.Entities
{
    public class Book : BaseEntity<int>
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int PublicationYear { get; set; }
        public bool IsAvailable { get; set; }
        public List<Loan> Loans { get; set; }
    }
}
