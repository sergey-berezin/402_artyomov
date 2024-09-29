using System;
namespace NugetPack
{
    public class GenericAlgo
    {

        private List<Solution> population;
        private Random random = new();

        public void Initialize(int n_obs_1, int n_obs_2, int n_obs_3, int population_size)
        {
            for (int i = 0; i < population_size; ++i)
            {
                var list = new List<Rectangle>();
                for (int j = 0; j < n_obs_1; ++j)
                {
                    list.Add(new Rectangle(random.Next(0, 10), random.Next(0, 10), 1, 1));
                    
                }
                for (int j = 0; j < n_obs_2; ++j)
                {
                    list.Add(new Rectangle(random.Next(0, 10), random.Next(0, 10), 2, 2));

                }
                for (int j = 0; j < n_obs_3; ++j)
                {
                    list.Add(new Rectangle(random.Next(0, 10), random.Next(0, 10), 3, 3));

                }

                var sol = new Solution(list);
                if (sol.Metric == 100000000)
                {
                    --i;
                }else
                {
                    population.Add(sol);
                }
            }
        }



        private Solution Crossover(Solution parent1, Solution parent2)
        {
            var sqs = new List<Rectangle>();

            for (int i = 0; i < parent1.rectangles.Count; ++i) 
            {
                if (random.Next(0, 2) > 0)
                {
                    sqs.Add(parent1.rectangles[i]);
                }
                else
                {
                     sqs.Add(parent2.rectangles[i]);    
                }
            }

            return new Solution(sqs);

        }


        private void Mutate(Solution sol)
        {
            foreach (var rec in  sol.rectangles) {
                if (random.Next(0, 10) < 2)
                {
                    var dx = random.Next(-1, 1);
                    var dy = random.Next(-1, 1);
                    rec.x_l += dx;
                    rec.x_r += dx;
                    rec.y_t += dy;
                    rec.y_b += dy;
                }
            }

            sol.recount_res();
        }



        public void Evolute()
        {
            List<Solution> newPopulation = new List<Solution>();
            var SortedSolutions = population.OrderBy(s => s.Metric).ToList();
            List<Solution> SelectedPopulation = new List<Solution>();
            for (int i = 0; i < SortedSolutions.Count / 4;  ++i)
            {
                SelectedPopulation.Add(SortedSolutions[i]);
                SelectedPopulation.Add(SortedSolutions[random.Next(SortedSolutions.Count / 4, SortedSolutions.Count / 4 * 3)]);
            }

            while (newPopulation.Count < population.Count)
            {
                var parent1 = SelectedPopulation[random.Next(0, SelectedPopulation.Count)];
                var parent2 = SelectedPopulation[random.Next(0, SelectedPopulation.Count)];

                var child = Crossover(parent1, parent2);
                Mutate(child);

                if (child.Metric != 100000000)
                {
                    newPopulation.Add(child);
                }
            }

            population = newPopulation;

        }

        public Solution GetBestSol(int max_iters)
        {
            for (int i = 0; i < max_iters; ++i)
            {
                Solution best_sol = population.OrderBy(s => s.recount_res()).First();

                Console.WriteLine($"Поколение : {i}, \n Площадь: {best_sol.Metric} \n");

                Evolute();

                if (Console.KeyAvailable)
                {
                    Console.ReadKey();
                    return best_sol;
                }
            }

            return population.OrderBy(s => s.recount_res()).First();
        }
    } 

    
}


