// See https://aka.ms/new-console-template for more information

using Business.Domain.Interfaces;
using Business.Domain.Models;
using Business.Services;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
string userInput;

IServiceCollection services = new ServiceCollection()
    .AddScoped<IPhoneService, PhoneService>()
    .AddScoped<IBrandService, BrandService>();
services.AddRepositories();
ServiceProvider serviceProvider = services.BuildServiceProvider();
IPhoneService phoneService = serviceProvider.GetService<IPhoneService>();

while (true)
{
    Console.Clear();
    MainMenu();
    userInput = Console.ReadLine();
    switch (userInput)
    {
        case "q": ExitApp(); break;
        case "s":
            {
                SortPhones();
                userInput= Console.ReadLine();
                PhoneDetails(userInput);
            }
            break;
        case "f":
            {
                SearchPhones();
                userInput = Console.ReadLine();
                PhoneDetails(userInput);
            }
            break;
        default: PhoneDetails(userInput); break;
    }
    Console.ReadKey();
}

void MainMenu()
{
    List<Phone> phoneList = phoneService.GetAll();
    Console.WriteLine(
        "Welcome to the Phoneshop!\n\n" +
        "Enter a number to see phone details:\n");
    foreach (Phone phone in phoneList)
    {
        Console.WriteLine($"{phone.PhoneId}. {phone.Brand.BrandName} {phone.Model}");
    }
    Console.WriteLine("\nPress 's' to sort the phones by brand." +
        "\nPress 'f' to search for phones." +
        "\nPress 'Escape' to exit the application.");
}

void PhoneDetails(string input)
{

    if(int.TryParse(input, out int id))
    {
        Console.Clear();
        try
        {
            Phone phone = phoneService.GetById(id);
            Console.WriteLine(
                $"Phone: {phone.Brand.BrandName} {phone.Model}.\n" +
                $"Price: {phone.PriceVat.ToString("C")}.\n" +
                $"In Stock: {phone.Stock}\n\n" +
                $"Description:\n" +
                $"{phone.Description}");
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine("Invalid phone number. Please enter a valid number");
        }
    }
    else
        Console.WriteLine("Invalid phone number. Please enter a valid number"); ;
    Console.WriteLine("\nPress a key to return to the main menu.");
}

void SearchPhones()
{
    Console.Clear();
    Console.WriteLine("What phone are you looking for?");
    string query = Console.ReadLine();
    List<Phone> searchResult = phoneService.Search(query);
    foreach (Phone phone in searchResult)
    {
        Console.WriteLine($"{phone.PhoneId}. {phone.Brand.BrandName} {phone.Model}");
    }
    if (searchResult.Count > 0)
        Console.WriteLine("Type in a number to select a phone.");
    else
        Console.WriteLine("\nWe can't find the phone you are looking for.");
}

void SortPhones()
{
    List<Phone> phoneList = phoneService.Sort();
    Console.Clear();
    Console.WriteLine(
    "Welcome to the Phoneshop!\n\n" +
    "Enter a phone number to see phone details:\n");
    foreach (Phone phone in phoneList)
    {
        Console.WriteLine($"{phone.PhoneId}. {phone.Brand.BrandName} {phone.Model}");
    }
    Console.WriteLine("\nPress 'Escape' to exit the application.");
}

void ExitApp()
{
    Console.Clear();
    Environment.Exit(0);
}

