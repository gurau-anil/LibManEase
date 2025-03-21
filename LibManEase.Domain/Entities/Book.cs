using LibManEase.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
