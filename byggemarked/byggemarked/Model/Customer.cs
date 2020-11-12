using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace byggemarked.Model
{
    public class Customer : INotifyPropertyChanged
    {
        public int Id { get; set; }

        private string name;
        public string Name {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }
        private string address;
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
                NotifyPropertyChanged("Address");
            }
        }

        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                NotifyPropertyChanged("Email");
            }
        }

        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                NotifyPropertyChanged("Username");
            }
        }
        public string Password { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

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
