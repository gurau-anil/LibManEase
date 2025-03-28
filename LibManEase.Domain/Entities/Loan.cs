﻿using LibManEase.Domain.Entities.Base;

namespace LibManEase.Domain.Entities
{
    public class Loan : BaseEntity<int>
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }

}
