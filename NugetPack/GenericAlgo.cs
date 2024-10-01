using System;
namespace NugetPack
{
    public class GenericAlgo
    {

        private List<Solution> population = new List<Solution>();
        private Random random = new();

        public void Initialize(int n_obs_1, int n_obs_2, int n_obs_3, int population_size)
        {
            for (int i = 0; i < population_size; ++i)
            {
                var list = new List<Rectangle>();
                int n_obs = n_obs_1 + n_obs_2 + n_obs_3;
                int max_l = n_obs; 
                for (int j = 0; j < n_obs_1; ++j)
                {
                    list.Add(new Rectangle(random.Next(0, max_l), random.Next(0, max_l), 1, 1));
                    
                }
                for (int j = 0; j < n_obs_2; ++j)
                {
                    list.Add(new Rectangle(random.Next(0, max_l), random.Next(0, max_l), 2, 2));

                }
                for (int j = 0; j < n_obs_3; ++j)
                {
                    list.Add(new Rectangle(random.Next(0, max_l), random.Next(0, max_l), 3, 3));

                }

                var sol = new Solution(list);
                if (!sol.IsValid())
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
                if (random.Next(0, 10) <= 4 - rec.weight)
                {
                    int dx = random.Next(-2, 2);
                    
                    rec.x_l += dx;
                    rec.x_r += dx;
                    
                }
                if (random.Next(0, 10) <= 4 - rec.weight)
                {
                    int dy = random.Next(-2, 2);
                    rec.y_t += dy;
                    rec.y_b += dy;
                } 
                
            }

            sol.count_metric();
        }



        public void Evolute()
        {
            List<Solution> newPopulation = new List<Solution>();
            var SortedSolutions = population.OrderBy(s => s.count_metric()).ToList();
            List<Solution> SelectedPopulation = new List<Solution>();
            for (int i = 0; i < SortedSolutions.Count / 4;  ++i)
            {
                SelectedPopulation.Add((Solution) SortedSolutions[i].Clone());
                SelectedPopulation.Add((Solution)SortedSolutions[
                    random.Next(SortedSolutions.Count / 4, SortedSolutions.Count / 4 * 3)].Clone());
            }

            while (newPopulation.Count < population.Count)
            {
                var parent1 = SelectedPopulation[random.Next(0, SelectedPopulation.Count)];
                var parent2 = SelectedPopulation[random.Next(0, SelectedPopulation.Count)];

                var child = Crossover(parent1, parent2);
                Mutate(child);

                if (child.IsValid())
                {
                    newPopulation.Add(child);
                }
                
            }

            var solutions = newPopulation.OrderBy(s => s.count_metric()).ToList();
            for (int i = 0; SelectedPopulation.Count < population.Count; ++i) 
            {
                SelectedPopulation.Add(solutions[i]);
            }

            
            this.population.Clear();
            for (int i = 0; i < SelectedPopulation.Count; ++i)
            {
                this.population.Add(SelectedPopulation[i]);
            }
            this.population = population.OrderBy(s => s.count_metric()).ToList();

        }

        public Solution GetBestSol(int max_iters)
        {
            Solution best_sol = new Solution(new List<Rectangle> ());
            for (int i = 0; i < max_iters; ++i)
            {
                var sorted = population.OrderBy(s =>  s.count_metric()).ToList();
                population = sorted;
                best_sol = (Solution) sorted[0].Clone();

                Console.WriteLine($"Поколение : {i}, \n Площадь: {best_sol.count_metric()} \n");
                foreach (var sq in best_sol.rectangles)
                {
                    ///Console.WriteLine($"x_l: {sq.x_l} y_b: {sq.y_b} w: {sq.weight} h: {sq.height}");
                }

                this.Evolute();

                if (Console.KeyAvailable)
                {
                    Console.ReadKey();
                    return best_sol;
                }
            }

            return best_sol;
        }
    } 

    
}


