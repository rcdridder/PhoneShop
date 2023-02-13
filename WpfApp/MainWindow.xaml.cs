using Business.Domain.Interfaces;
using Business.Domain.Models;
using Business.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IPhoneService phoneService;
        public MainWindow(IPhoneService phoneService)
        {
            this.phoneService = phoneService;
            InitializeComponent();
            lbPhones.ItemsSource = phoneService.Sort();
        }

        private void lbPhones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (lbPhones.SelectedItem != null)
            {
                Phone phone = lbPhones.SelectedItem as Phone;
                tbBrand.Text = phone.Brand;
                tbType.Text = phone.Type;
                tbPrice.Text = phone.PriceVat.ToString("C");
                tbStock.Text = phone.Stock.ToString();
                tbDescription.Text = phone.Description;
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text.Length > 0)
                lbPhones.ItemsSource = phoneService.Search(tbSearch.Text);
            else
                lbPhones.ItemsSource = phoneService.Sort();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
