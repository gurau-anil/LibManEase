using LibManEase.Domain.Entities.Base;

namespace LibManEase.Domain.Entities
{    public class Member : BaseEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<Loan> Loans { get; set; }
    }

}
