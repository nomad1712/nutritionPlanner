using System.Dynamic;
using System.Reflection;

public class Meals{
    int targetNutrition = 1000;
    public List<FoodItem> Items{get;set;}
    public  float  Calories { get; set; }
    public float  Fat{ get;set;}
    public  float  Carbohydrates{get; set;}
    public  float  Protein { get; set;}
        public  float  Fitness { get; set; }

    public List<FoodItem> FoodItems { get; set; }

     public Meals()
    {
        FoodItems = new List<FoodItem>();
    }

    public void AddFoodItem(FoodItem foodItem)
    {
        FoodItems.Add(foodItem);
    }

    public  float  CalculateNutritionValue()
    {
        float totalCalories = 0;
        float  totalProtein = 0;
         float  totalCarbohydrates = 0;
        float  totalFat = 0;

        foreach (FoodItem foodItem in FoodItems)
        {
            totalCalories += foodItem.Calories;
            totalProtein += foodItem.Protein;
            totalCarbohydrates += foodItem.Carbohydrates;
            totalFat += foodItem.Fat;
        }

        return totalCalories * 2 + totalProtein * 3 + totalCarbohydrates * 3 + totalFat * 1;
    }
    public void DisplayInfo()
{
    Console.WriteLine("Meal:");
    foreach (FoodItem foodItem in FoodItems)
    {
        Console.WriteLine($"- {foodItem.Name} ({foodItem.Calories} calories, {foodItem.Protein} protein, {foodItem.Carbohydrates} carbohydrates, {foodItem.Fat} fat)");
    }
    Console.WriteLine($"Total nutrition value: {CalculateNutritionValue()}");
}
}