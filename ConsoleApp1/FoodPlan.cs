// This will serve as The logic Fot the GA It is a rough draft and currently being imporved 
public class FoodPlan<P>
{
    // three created characteristics for the different food plans 
    //First is the actual list of food plans 
    public P[] Plan {get; private set;}
    // This is the score for fitness of each individual member of the population that was created.
    public float Fitness { get; private set;}
    /* Random variable was created so that it wouldn't be instatiated each time this was called instead the single instance
     will serve all iterations displayed. */
    private Random random;
    private Func<P> getRandomGene;
    private Func<float,int> fitnessFunction;

    public FoodPlan(int size, Random random , Func<P> getRandomGene ,Func<float,int> fitnessFunction, bool shouldInitGene= true)
    {
        Plan = new P[size];
        this.random = random;
        this.getRandomGene= getRandomGene;
        for(int i=0 ;i <Plan.Length;i++)
        {
            Plan[i] = getRandomGene();
        }
    }
    public float CalculateFitness(int index)
    {
        Fitness = fitnessFunction(index);
        return Fitness;
    }
    public FoodPlan<P> Crossover(FoodPlan<P> otherParent)
    {
        FoodPlan<P> child = new FoodPlan<P>(Plan.Length , random ,getRandomGene ,fitnessFunction, shouldInitGene: false);
        for (int i = 0 ; i< Plan.Length ; i++ )
        {
       child.Plan[i]= random.NextDouble()<.5 ? Plan[i] : otherParent.Plan[i];
        }
        return child;

    }
    public void mutate(float mutationRate)
    {
        for (int i =0; i < Plan.Length ; i++)
        {
            if(random.NextDouble()< mutationRate)
          {
            Plan[i] = getRandomGene();
          }
        }
    }

}