using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
public class GA<P>
{
    // Creating list and initializing them to be able to get values and set inside population and generation that we are in 
       public List<FoodPlan<P>> Population { get; private set; } = new List<FoodPlan<P>>();
    public int Generation { get; private set; } = 0;
    public float BestFitness { get; private set; } = 0;
    public P[] BestPlans { get; private set; } = null;
    public float mutationRate { get; private set; } = 0;
    private Random random { get; set; } = new Random();
    private float fitnessSum { get; set; } = 0;

    public int Fitness { get; set; }

    private int targetNutrition;
    private int populationSize;

    public GA(int targetNutrition, int populationSize, float mutationRate)
    {
        this.targetNutrition = targetNutrition;
        this.populationSize = populationSize;
        this.mutationRate = mutationRate;
        random = new Random();
    }

   public List<Meals> Evolve(List<Meals> population)
{
    // Step 1: Selection
    List<Meals> parents = new List<Meals>();
    for (int i = 0; i < populationSize / 2; i++)
    {
        Meals parent1 = SelectParent(population);
        Meals parent2 = SelectParent(population);
        parents.Add(parent1);
        parents.Add(parent2);
    }

    // Step 2: Crossover
    List<Meals> children = new List<Meals>();
    for (int i = 0; i < parents.Count / 2; i++)
    {
        Meals child1 = Crossover(parents[i * 2], parents[i * 2 + 1]);
        Meals child2 = Crossover(parents[i * 2 + 1], parents[i * 2]);
        children.Add(child1);
        children.Add(child2);
    }

    // Step 3: Mutation
    for (int i = 0; i < children.Count; i++)
    {
        Mutate(children[i]);
    }

    // Step 4: Replacement
    population.Clear();
    for (int i = 0; i < children.Count; i++)
    {
        population.Add(children[i]);
    }

    return population;
}
    private  float  CalculateFitness(Meals meal)
    {
        float  nutritionValue = meal.CalculateNutritionValue();
         float  difference = Math.Abs(targetNutrition - nutritionValue);
        return 100 - difference;
    }

    private Meals SelectParent(List<Meals> population)
    {
        Meals topMeal = population[0];
        for (int i = 1; i < population.Count; i++)
        {
            if (population[i].Fitness > topMeal.Fitness)
            {
                topMeal = population[i];
            }
        }
        return topMeal;
    }

    private Meals Crossover(Meals parent1, Meals parent2)
    {
        Meals child = new Meals();

        int crossoverPoint = random.Next(parent1.FoodItems.Count);

        for (int i = 0; i < crossoverPoint; i++)
        {
            child.AddFoodItem(parent1.FoodItems[i]);
        }

        for (int i = crossoverPoint; i < parent2.FoodItems.Count; i++)
        {
            child.AddFoodItem(parent2.FoodItems[i]);
        }

        return child;
    }

    private void Mutate(Meals meal)
    {
        foreach (FoodItem foodItem in meal.FoodItems)
        {
            if (random.NextDouble() < mutationRate)
            {
                foodItem.Calories = random.Next(0, 100);
                foodItem.Protein = random.Next(0, 100);
                foodItem.Carbohydrates = random.Next(0, 100);
                foodItem.Fat = random.Next(0, 100);
            }
        }
    }
}