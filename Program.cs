// Connor Young
// Section 001
// Provide a menu to allow the user to add food items, delete food items, print list of current food items,
// and exit the program (1-4)

using System.Runtime.InteropServices;
using Mission3Assignment;

class Program
{
    static void Main(string[] options)
    {
        // Create list of food items
        List<FoodItem> listItems = new List<FoodItem>();

        // Set the menu to loop until an item is selected
        bool loop = true;

        string[] menuOptions =
        {
            "1. Add Food Items",
            "2. Delete Food Items",
            "3. Print List of Current Food Items",
            "4. Exit the Program"
        };
        
        // Read user input
        while (loop)
        {
            Console.WriteLine("Hello! What would you like to do?");
            foreach (string option in menuOptions)
            {
                Console.WriteLine(option);
            }
            Console.WriteLine("Select an option: ");
            string userInput = Console.ReadLine();

            // Parse the input to an integer
            if (int.TryParse(userInput, out int number) && number > 0 && number <= menuOptions.Length)
            {
                Console.WriteLine($"You chose {number}");

                // Option if number equals 1
                if (number == 1)
                {
                    Console.WriteLine("What is the name of the food item?");
                    string foodName = Console.ReadLine();
                    Console.WriteLine(
                        "What is the categiry of the food item? (e.g. canned goods, dairy, produce, other)");
                    string foodCategory = Console.ReadLine();
                    Console.WriteLine("What is the quantity of the food item in units?");
                    string quant = Console.ReadLine();
                    int foodQuantity = int.Parse(quant);
                    Console.WriteLine("What is the expiration date of the food item? (MM/DD/YYYY)");
                    string date = Console.ReadLine();
                    if (DateOnly.TryParseExact(date, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None,
                            out DateOnly foodDate))
                    {
                        Console.WriteLine($"The expiration date is: {foodDate}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format. Please enter a valid date in the format MM/dd/yyyy.");
                    }
                    
                    // After collecting parameters, make an object and pass them in the constructor
                    FoodItem foodItem = new FoodItem(foodName, foodCategory, foodQuantity, foodDate);
                    
                    Console.WriteLine("Food item created:");
                    Console.WriteLine(foodItem);
                    
                    // Append the foodItem object to the list of items
                    listItems.Add(foodItem);
                    Console.WriteLine();
                }
                
                // Option if number 2 is selected
                if (number == 2)
                {
                    // Ask user for the name of the item to delete
                    Console.WriteLine("\nEnter the name of the food item to delete:");
                    string itemName = Console.ReadLine();
                    
                    var itemToDelete = listItems.FirstOrDefault(item => item.foodItemName.Equals(itemName, StringComparison.OrdinalIgnoreCase));

                    if (itemToDelete != null)
                    {
                        // Remove the object from the list
                        listItems.Remove(itemToDelete);
                        Console.WriteLine($"\n'{itemName}' has been removed from the list.");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine($"\n'{itemName}' not found in the list.");
                        Console.WriteLine();
                    }
                }
                
                // Option if number 3 is selected
                if (number == 3)
                {
                    Console.WriteLine("Current list of food items:");
                    foreach (var item in listItems)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine();
                }

                // Option if number 4 is selected
                if (number == 4)
                {
                    Console.WriteLine("Exiting the program!");
                    loop = false;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}