﻿// See https://aka.ms/new-console-template for more information
 class Program
{
    static void Main(string[] args)
    {
        // Creating instances of FoodItem
        FoodItem apple = new FoodItem("Apple", 0.3, 0.5, 19, 1);
        FoodItem chickenBreast = new FoodItem("Chicken Breast", 3.6, 31, 0, 74);
        
        // Displaying information about the food items
        Console.WriteLine("Nutrition Information for Apple:");
        apple.DisplayInfo();
        
        Console.WriteLine("\nNutrition Information for Chicken Breast:");
        chickenBreast.DisplayInfo();
    }
}