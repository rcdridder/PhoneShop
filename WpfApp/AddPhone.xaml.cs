using Business.Domain.Interfaces;
using Business.Domain.Models;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for AddPhone.xaml
    /// </summary>
    public partial class AddPhone : Window
    {
        IPhoneService phoneService;
        public AddPhone(IPhoneService phoneService)
        {
            InitializeComponent();
            this.phoneService = phoneService;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to add this phone to the database?", "Add phone to database",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
            if (result == MessageBoxResult.Yes)
            {
                if (string.IsNullOrEmpty(tbBrand.Text) ||
                    string.IsNullOrEmpty(tbModel.Text) ||
                    string.IsNullOrEmpty(tbDescription.Text) ||
                    string.IsNullOrEmpty(tbPrice.Text) ||
                    string.IsNullOrEmpty(tbStock.Text))
                {
                    MessageBox.Show("Please fill out all fields.", "Empty fields", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (decimal.TryParse(tbPrice.Text, out decimal priceVat) && int.TryParse(tbStock.Text, out int stock))
                {
                    Phone phone = new Phone();
                    Brand brand = new Brand();
                    brand.BrandName = tbBrand.Text;
                    phone.Brand = brand;
                    phone.Model = tbModel.Text;
                    phone.Description = tbDescription.Text;
                    phone.PriceVat = priceVat;
                    phone.Stock = stock;
                    phoneService.Add(phone);
                    MessageBox.Show("Phone successfully added to the database.", "Phone added to database",
                        MessageBoxButton.OK, MessageBoxImage.None);
                    Close();
                }
                else
                {
                    MessageBox.Show("Enter valid price and/or stock value", "Invalid price or stock value",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to cancel adding this phone to the database?", "Cancel adding phone",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
                Close();
        }
    }
}
