using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace byggemarked.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address{ get; set; }

        public string Email{ get; set; }

        public string Username{ get; set; }
        public string Password { get; set; }

        public void populate(Customer customer)
        {
            this.Id = customer.Id;
            this.Name = customer.Name;
            this.Address = customer.Address;
            this.Email = customer.Email;
            this.Username = customer.Username;
        }

        public string ToString() {
            return "Name: " + Name
                + "\nAddress: " + Address
                + "\nEmail: " + Email
                + "\nUsername: " + Username;
        }
    }
}
