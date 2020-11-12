using byggemarked.Model;
using System;
using System.Collections.Generic;
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

namespace byggemarked
{
    /// <summary>
    /// Interaction logic for UpdateReservation_Control.xaml
    /// </summary>
    public partial class Booking_Control : UserControl
    {
        private static HardwareStoreDbContext ctx;

        public Booking_Control()
        {
            InitializeComponent();

            ctx = new HardwareStoreDbContext();
        }

        public void FindButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(IdField.Text, out int id))
            {
                var rentals = ctx.Rentals
                    .Where(r => r.CustomerId == id)
                    .OrderByDescending(r => r.StartDate)
                    .ToList();

                if (rentals.Count > 0)
                {
                    lvReservations.ItemsSource = rentals;
                    lbCustomerName.Content = rentals[0].Customer.ToString();
                } else
                {
                    lvReservations.ItemsSource = null;
                    lbCustomerName.Content = "This person does not exist or has no Rentals.";
                    lbInfo.Content = "";
                }
            } else
            {
                lbInfo.Content = "Please enter a number.";
            }
        }

        public void StatusButton_Click(object sender, RoutedEventArgs e)
        {
            if (IdField.Text == "" || !int.TryParse(IdField.Text, out int id))
            {
                lbInfo.Content = "Please find the customer.";
                return;
            } else if (lvReservations.SelectedItems.Count <= 0)
            {
                lbInfo.Content = "Please select Rentals.";
            }

            string reservationStatus = (sender as Button).Content.ToString();
            string infoText = "Following reservations updated: [ ";

            foreach (var item in lvReservations.SelectedItems)
            {
                try
                {
                    (item as Rental).Status = reservationStatus;
                } catch (Exception exc)
                {
                    lbInfo.Content = "You cannot change '" + (item as Rental).Status + "' to '" + reservationStatus + "'";
                    return;                }

                infoText += (item as Rental).Id + ", ";
            }
            ctx.SaveChanges();
            lbInfo.Content = infoText + "]";
        }
    }
}
