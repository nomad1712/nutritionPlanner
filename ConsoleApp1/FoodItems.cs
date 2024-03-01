public class FoodItem
{
    // Properties to store basic nutrition information
    public string Name { get; set; }
    public float Fat { get; set; } // in grams
    public float  Protein { get; set; } // in grams
    public float Carbohydrates { get; set; } // in grams
    public float Calories { get; set; } // in milligrams

    // Constructor
    public FoodItem(string name, float fat, float protein, float carbohydrates, float calories)
    {
        Name = name;
        Fat = fat;
        Protein = protein;
        Carbohydrates = carbohydrates;
        Calories = calories;
    }

    // Method to display information about the food item
    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Fat: {Fat}g");
        Console.WriteLine($"Protein: {Protein}g");
        Console.WriteLine($"Carbohydrates: {Carbohydrates}g");
        Console.WriteLine($"Calories : {Calories}mg");
    }
}