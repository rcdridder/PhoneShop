using Business.Domain.Interfaces;
using Business.Domain.Models;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for EdtiPhone.xaml
    /// </summary>
    public partial class EditPhone : Window
    {
        IPhoneService phoneService;
        Phone phone;
        public EditPhone(IPhoneService phoneService, Phone phone)
        {
            InitializeComponent();
            this.phoneService = phoneService;
            this.phone = phone;
            tbBrand.Text = phone.Brand.BrandName;
            tbModel.Text = phone.Model;
            tbDescription.Text = phone.Description;
            tbPrice.Text = phone.PriceVat.ToString();
            tbStock.Text = phone.Stock.ToString();
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to edit this phone in the database?", "Edit phone to database",
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
                    phone.Brand.BrandName = tbBrand.Text;
                    phone.Model = tbModel.Text;
                    phone.Description = tbDescription.Text;
                    phone.PriceVat = priceVat;
                    phone.Stock = stock;
                    phoneService.Update(phone);
                    MessageBox.Show("Successfully edited phone in the database.", "Phone edited in database",
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
            MessageBoxResult result = MessageBox.Show("Do you want to cancel editing this phone?", "Cancel editing phone",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
                Close();
        }
    }
}
