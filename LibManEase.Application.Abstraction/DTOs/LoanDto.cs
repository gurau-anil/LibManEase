namespace LibManEase.Application.Abstraction.DTOs
{
    public class LoanDto : BaseDto
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }

    public class CreateLoanDto
    {
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public DateTime DueDate { get; set; }
    }

    public class UpdateLoanDto : BaseDto
    {
        public DateTime? ReturnDate { get; set; }
    }
}
