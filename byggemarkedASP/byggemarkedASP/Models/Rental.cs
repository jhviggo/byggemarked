using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace byggemarked.Model
{
    public class Rental
    {
        public int Id { get; set; }
        public int HardwareId { get; set; }
        public virtual Hardware Hardware { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public string Status { get; set; }

        public DateTime StartDate { get; set; }
        public int Days { get; set; }
    }
}
