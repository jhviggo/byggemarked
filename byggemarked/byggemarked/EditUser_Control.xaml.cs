using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using byggemarked.Model;

namespace byggemarked
{
    /// <summary>
    /// Interaction logic for EditUser_Control.xaml
    /// </summary>
    public partial class EditUser_Control : UserControl
    {
        private static HardwareStoreDbContext ctx;

        Customer customer = new Customer();

        public EditUser_Control()
        {
            InitializeComponent();

            ctx = new HardwareStoreDbContext();

            DataContext = customer;
        }

        public void FindButton_Click(object sender, RoutedEventArgs e)
        {
            var q = ctx.Customers
                .Where(s => s.Id == customer.Id)
                .FirstOrDefault<Customer>();

            if (q != null)
            {
                customer.populate(q);
                ErrorLabel.Content = "";
            } else
            {
                ErrorLabel.Content = "No user found";
            }
        }

        public void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ctx.Customers.Add(customer);
            ctx.SaveChanges();
            ErrorLabel.Content = "";
        }

        public void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var q = ctx.Customers
                .Where(c => c.Id == customer.Id)
                .FirstOrDefault<Customer>();

            if (q != null)
            {
                q.populate(customer);
                ctx.SaveChanges();
                ErrorLabel.Content = "";
            } else
            {
                ErrorLabel.Content = "Unknown user";
            }
        }
    }
}
