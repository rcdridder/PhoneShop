﻿using Business.Domain.Interfaces;
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
            btnDelete.IsEnabled = true;
            btnEdit.IsEnabled = true;
            if (lbPhones.SelectedItem != null)
            {
                Phone phone = lbPhones.SelectedItem as Phone;
                tbBrand.Text = phone.Brand.BrandName;
                tbType.Text = phone.Model;
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

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddPhone addPhone= new();
            addPhone.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Are you sure you want to delete this phone from the database?", "Delete phone", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            EdtiPhone editPhone = new();
            editPhone.ShowDialog();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
