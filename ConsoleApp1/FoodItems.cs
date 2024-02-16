public class FoodItem
{
    // Properties to store basic nutrition information
    public string Name { get; set; }
    public double Fat { get; set; } // in grams
    public double Protein { get; set; } // in grams
    public double Sugar { get; set; } // in grams
    public double Sodium { get; set; } // in milligrams

    // Constructor
    public FoodItem(string name, double fat, double protein, double sugar, double sodium)
    {
        Name = name;
        Fat = fat;
        Protein = protein;
        Sugar = sugar;
        Sodium = sodium;
    }

    // Method to display information about the food item
    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Fat: {Fat}g");
        Console.WriteLine($"Protein: {Protein}g");
        Console.WriteLine($"Sugar: {Sugar}g");
        Console.WriteLine($"Sodium: {Sodium}mg");
    }
}