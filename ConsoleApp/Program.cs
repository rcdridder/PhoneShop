// See https://aka.ms/new-console-template for more information

using Business.Domain.Models;
using Business.Services;
using System.Collections.Generic;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
PhoneService phoneService = new();

while (true)
{
    MainMenu();
    ConsoleKeyInfo selection = Console.ReadKey();
    ExitApp(selection);
    PhoneDetails(selection);
    ConsoleKeyInfo returnToMenu = Console.ReadKey();
    ExitApp(returnToMenu);
    Console.Clear();
}

void MainMenu()
{
    List<Phone> phoneList = phoneService.GetAll();
    Console.WriteLine(
        "Welcome to the Phoneshop!\n\n" +
        "Type in a number to see phone details:\n");
    foreach(Phone phone in phoneList)
    {
        Console.WriteLine($"{phone.Id}. {phone.Brand} {phone.Type}");
    }
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
    Console.WriteLine("\nPress a key to return to the main menu (or 'Escape' to exit the application).");
}

void ExitApp(ConsoleKeyInfo input)
{
    if (input.KeyChar == 27)
    {
        Console.Clear();
        Environment.Exit(0);
    }
}

