using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace byggemarked.Model
{
    public class Rental : INotifyPropertyChanged
    {
        private static List<string> validStatus = new List<string> { "reserveret", "udleveret", "tilbageleveret" };

        private string status;

        public int Id { get; set; }
        public int HardwareId { get; set; }
        public virtual Hardware Hardware { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public string Status
        {
            get { return status; }
            set
            {
                if (!validStatus.Contains(value))
                {
                    throw new Exception("Invalid status '" + value + "'");
                }
                else if (status == "reserveret" && value != "udleveret")
                {
                    throw new Exception("Invalid status '" + value + "'");
                }
                else if (status == "udleveret" && value != "tilbageleveret")
                {
                    throw new Exception("Invalid status '" + value + "'");
                }

                status = value;
                NotifyPropertyChanged("Status");
            }
        }

        public DateTime StartDate { get; set; }
        public int Days { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
