// See https://aka.ms/new-console-template for more information

using Business.Domain.Interfaces;
using Business.Domain.Models;
using Business.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
ConsoleKeyInfo userInput;

IServiceCollection services = new ServiceCollection()
    .AddScoped<IPhoneService, PhoneService>();
ServiceProvider serviceProvider = services.BuildServiceProvider();
IPhoneService phoneService = serviceProvider.GetService<IPhoneService>();

while (true)
{
    Console.Clear();
    MainMenu();
    userInput = Console.ReadKey();
    switch (userInput.Key)
    {
        case ConsoleKey.Escape: ExitApp(); break;
        case ConsoleKey.S:
            {
                SortPhones();
                userInput = Console.ReadKey();
                if (userInput.Key == ConsoleKey.Escape)
                    ExitApp();
                else
                    PhoneDetails(userInput);
            }
            break;
        case ConsoleKey.F:
            {
                SearchPhones();
                userInput = Console.ReadKey();
                if (userInput.Key == ConsoleKey.Escape)
                    ExitApp();
                else
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
        "Type in a number to see phone details:\n");
    foreach (Phone phone in phoneList)
    {
        Console.WriteLine($"{phone.Id}. {phone.Brand} {phone.Type}");
    }
    Console.WriteLine("\nPress 's' to sort the phones by brand." +
        "\nPress 'f' to search for phones." +
        "\nPress 'Escape' to exit the application.");
}

void PhoneDetails(ConsoleKeyInfo number)
{
    Console.Clear();
    int id = 0;
    switch (number.Key)
    {
        case ConsoleKey.NumPad1: case ConsoleKey.D1: id = 1; break;
        case ConsoleKey.NumPad2: case ConsoleKey.D2: id = 2; break;
        case ConsoleKey.NumPad3: case ConsoleKey.D3: id = 3; break;
        case ConsoleKey.NumPad4: case ConsoleKey.D4: id = 4; break;
        case ConsoleKey.NumPad5: case ConsoleKey.D5: id = 5; break;
        default: break;
    }

    try
    {
        Phone phone = phoneService.GetById(id);
        Console.WriteLine(
            $"Phone: {phone.Brand} {phone.Type}.\n" +
            $"Price: {phone.PriceVat.ToString("C")}.\n" +
            $"In Stock: {phone.Stock}\n\n" +
            $"Description:\n" +
            $"{phone.Description}");
    }
    catch (NullReferenceException ex)
    {
        Console.WriteLine("Invalid phone number. Please enter a valid number");
    }
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
        Console.WriteLine($"{phone.Id}. {phone.Brand} {phone.Type}");
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
    "Type in a number to see phone details:\n");
    foreach (Phone phone in phoneList)
    {
        Console.WriteLine($"{phone.Id}. {phone.Brand} {phone.Type}");
    }
    Console.WriteLine("\nPress 'Escape' to exit the application.");
}

void ExitApp()
{
    Console.Clear();
    Environment.Exit(0);
}

