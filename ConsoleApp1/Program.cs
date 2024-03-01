// See https://aka.ms/new-console-template for more information
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;


class Program
{
   int targerNutrition = 50;
  int populationSize = 100;
   float mutationRate=.01f;


  private GA<char> ga;
 static void Main(string[] args)
    {
        // Creating instances of FoodItem
FoodItem apple = new FoodItem("Apple", 0.3f, 0.5f, 19f, 52f);
FoodItem banana = new FoodItem("Banana", 0.4f, 1.3f, 27f, 89f);
FoodItem spinach = new FoodItem("Spinach", 0.4f, 2.9f, 3.6f, 23f);
FoodItem chickenBreast = new FoodItem("Chicken Breast", 3.6f, 31f, 0f, 165f);
FoodItem salmon = new FoodItem("Salmon", 6f, 25f, 0f, 208f);
FoodItem rice = new FoodItem("Rice (cooked)", 0.3f, 2.7f, 28f, 130f);
FoodItem oatmeal = new FoodItem("Oatmeal", 2f, 6f, 25f, 145f);
FoodItem almonds = new FoodItem("Almonds", 14f, 6f, 22f, 164f);
FoodItem broccoli = new FoodItem("Broccoli", 0.4f, 2.8f, 6f, 31f);
FoodItem egg = new FoodItem("Egg", 5f, 6f, 1f, 78f);
FoodItem avocado = new FoodItem("Avocado", 14f, 2f, 9f, 160f);
FoodItem blackBeans = new FoodItem("Black Beans", 0.5f, 8.9f, 20f, 114f);
FoodItem sweetPotato = new FoodItem("Sweet Potato", 0.1f, 1.6f, 20f, 86f);
FoodItem yogurt = new FoodItem("Yogurt", 3.3f, 9f, 11f, 149f);
FoodItem tofu = new FoodItem("Tofu", 6.2f, 8.1f, 1.9f, 76f);
FoodItem turkeyBreast = new FoodItem("Turkey Breast", 0.7f, 29f, 0f, 135f);
FoodItem lentils = new FoodItem("Lentils", 0.4f, 9f, 20f, 116f);
FoodItem quinoa = new FoodItem("Quinoa (cooked)", 1.9f, 4.1f, 21f, 120f);
FoodItem cottageCheese = new FoodItem("Cottage Cheese", 1f, 11f, 3.4f, 72f);
FoodItem peanutButter = new FoodItem("Peanut Butter", 16f, 7f, 6f, 188f);
FoodItem blueberries = new FoodItem("Blueberries", 0.3f, 0.7f, 14f, 57f);
FoodItem carrots = new FoodItem("Carrots", 0.3f, 0.6f, 9.6f, 41f);
FoodItem groundBeef = new FoodItem("Ground Beef (lean)", 10f, 27f, 0f, 250f);
FoodItem wholeWheatBread = new FoodItem("Whole Wheat Bread", 1f, 4f, 12f, 69f);
FoodItem bellPepper = new FoodItem("Bell Pepper", 0.3f, 1f, 6f, 31f);
FoodItem cheddarCheese = new FoodItem("Cheddar Cheese", 33f, 25f, 1.3f, 403f);
//FoodItem strawberries = new FoodItem("Strawberries", 0.4f, 0.8f, 7.7f, 32f);
FoodItem tilapia = new FoodItem("Tilapia", 1.6f, 26f, 0f, 128f);
//FoodItem brownRice = new FoodItem("Brown Rice (cooked)", 0.9f, 2.6f, 23f, 112f);

        // Displaying information about the food items
      
   // Create a list of FoodItem objects
        var foodItems = new List<FoodItem> { salmon, carrots, groundBeef, tilapia, cheddarCheese, bellPepper,peanutButter,quinoa,lentils,cottageCheese,yogurt,spinach };

        // Create a list of Meal objects
        var meals = new List<Meals>();

        // Create an initial population of meal plans
        for (int i = 0; i < 100; i++)
        {
            var randomFoodItems = new List<FoodItem>();
            while (randomFoodItems.Count < 3)
            {
                var randomFoodItem = foodItems[new Random().Next(0, foodItems.Count)];
                if (!randomFoodItems.Contains(randomFoodItem))
                {
                    randomFoodItems.Add(randomFoodItem);
                }
            }
            var meal = new Meals();
            foreach (var foodItem in randomFoodItems)
            {
                meal.AddFoodItem(foodItem);
            }
            meals.Add(meal);
        }

        // Set the target nutrient value and GA parameters
        int targetNutrition = 50;
        int populationSize = 100;
        float mutationRate = 0.01f;

        // Create a new GA object
        GA<int> ga = new GA<int>(targetNutrition, populationSize, mutationRate);

        // Run the genetic algorithm for 100 generations
        for (int i = 0; i < 100; i++)
        {
            meals = ga.Evolve(meals);
        }

        // Display the best meal plan
        Console.WriteLine("Best meal found:");
        Meals bestMeal = meals[0];
        for (int i = 1; i < meals.Count; i++)
        {
            if (meals[i].Fitness > bestMeal.Fitness)
            {
                bestMeal = meals[i];
            }
        }
        meals.Sort((x, y) => y.Fitness.CompareTo(x.Fitness));
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"Meal {i + 1}");
            meals[i].DisplayInfo();
            Console.WriteLine($"Nutrition value: {meals[i].CalculateNutritionValue()}");
            Console.WriteLine();
        }
    }
}

