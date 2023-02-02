// See https://aka.ms/new-console-template for more information

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

static void MainMenu()
{
    Console.WriteLine(
        "Welcome to the Phoneshop!\n\n" +
        "Type in a number to see phone details:\n" +
        "1. Huawei P30\n" +
        "2. Samsung Galaxy A52\n" +
        "3. Apple iPhone 11\n" +
        "4. Google Pixel 4a\n" +
        "5. Xiaomi Redmi Note 10 Pro");
}

static void PhoneDetails(ConsoleKeyInfo number)
{
    Console.Clear();
    switch (number.Key)
    {
        case ConsoleKey.NumPad1:
        case ConsoleKey.D1:
            Console.WriteLine(
            "Phone: Huawei P30\n" +
            "Price: €697,00\n\n" +
            "Description:\n" +
            @"6.47"" FHD+ (2340x1080) OLED, Kirin 980 Octa-Core (2x Cortex-A76 2.6GHz + 2x Cortex-A76 1.92GHz + 4x Cortex-A55 1.8GHz), 8GB RAM, 128GB ROM, 40+20+8+TOF/32MP, Dual SIM, 4200mAh, Android 9.0 + EMUI 9.1");
            break;
        case ConsoleKey.NumPad2:
        case ConsoleKey.D2:
            Console.WriteLine(
            "Phone: Samsung Galaxy A52\n" +
            "Price: €399,00\n\n" +
            "Description:\n" +
            @"64 megapixel camera, 4k videokwaliteit 6.5 inch AMOLED scherm 128 GB opslaggeheugen (Uitbreidbaar met Micro-sd) Water- en stofbestendig (IP67)");
            break;
        case ConsoleKey.NumPad3:
        case ConsoleKey.D3:
            Console.WriteLine(
            "Phone: Apple iPhone 11\n" +
            "Price: €619,00\n\n" +
            "Description:\n" +
            @"Met de dubbele camera schiet je in elke situatie een perfecte foto of video. De krachtige A13-chipset zorgt voor razendsnelle prestaties. Met Face ID hoef je enkel en alleen naar je toestel te kijken om te ontgrendelen. Het toestel heeft een lange accuduur dankzij een energiezuinige processor");
            break;
        case ConsoleKey.NumPad4:
        case ConsoleKey.D4:
            Console.WriteLine(
            "Phone: Google Pixel 4a\n" +
            "Price: €411,00\n\n" +
            "Description:\n" +
            @"12.2 megapixel camera, 4k videokwaliteit 5.81 inch OLED scherm, 128 GB opslaggeheugen 3140 mAh accucapaciteit");
            break;
        case ConsoleKey.NumPad5:
        case ConsoleKey.D5:
            Console.WriteLine(
            "Phone: Xiaomi Redmi Note 10 Pro\n" +
            "Price: €298,00\n\n" +
            "Description:\n" +
            @"108 megapixel camera, 4k videokwaliteit 6.67 inch AMOLED scherm, 128 GB opslaggeheugen (Uitbreidbaar met Micro-sd). Water- en stofbestendig (IP53)");
            break;
        default: Console.WriteLine("Invalid number. Please enter a valid number."); break;
    }
    Console.WriteLine("\nPress a key to return to the main menu (or 'Escape' to exit the application).");
}

static void ExitApp(ConsoleKeyInfo input)
{
    if (input.KeyChar == 27)
    {
        Console.Clear();
        Environment.Exit(0);
    }
}

