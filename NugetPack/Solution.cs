using System;

namespace NugetPack
{
    public class Solution
    {
        public List<Rectangle> rectangles { get; set; }
        private int n { get; set; }
        private Rectangle res;
        public int Metric { get; set; }
        public bool isValid;


        public int recount_res()
        {
            int x_l = rectangles[0].x_l; 
            int x_r = rectangles[0].x_r;
            int y_t = rectangles[0].y_t;
            int y_b = rectangles[0].y_b;
            foreach (Rectangle rec in rectangles)
            {
                x_l = Math.Min(x_l, rec.x_l);
                x_r = Math.Max(x_r, rec.x_r);
                y_b = Math.Min(y_b, rec.y_b);
                y_t = Math.Max(y_t, rec.y_t);
            }

            res = new Rectangle(x_l, y_b, x_r - x_l, y_t - y_b);
            Metric = res.GetArea();
            return Metric;
        }


        public Solution(List<Rectangle> rectgs)
        {
            this.rectangles = rectgs;
            this.recount_res();
        }

        public bool IsValid()
        {
            for (int i = 0; i < rectangles.Count; i++)
            {
                for (int j = i + 1; j < rectangles.Count; j++) {
                    if (!rectangles[i].IsNotCrossing(rectangles[j]))
                    {
                        Metric = 100000000;
                        return false;
                    }
                }
            }

            this.recount_res();
            return true;
        }

    }
}
