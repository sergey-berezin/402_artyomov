using System;
using System.Xml.Linq;

namespace NugetPack
{
   
    public class Solution : ICloneable
    {
        public List<Rectangle> rectangles { get; set; }
        private int n { get; set; }
        private Rectangle res{get; set;}
        /// <summary>
        public int Metric { get; set; }
        /// </summary>
        public bool isValid;


        /*public int recount_res()
        {
            int X_l = rectangles[0].x_l; 
            int X_r = rectangles[0].x_r;
            int Y_t = rectangles[0].y_t;
            int Y_b = rectangles[0].y_b;
            foreach (Rectangle rec in rectangles)
            {
                if (rec.x_l < X_l)
                {
                    X_l = rec.x_l;
                }
                if (rec.x_r > X_r)
                {
                    X_r = rec.x_r;
                }
                if (rec.y_b < Y_b)
                {
                    Y_b = rec.y_b;
                }
                if (rec.y_t > Y_t)
                {
                    Y_t = rec.y_t;
                }
               
            }

            res = new Rectangle(X_l, Y_b, X_r - X_l, Y_t - Y_b);
            Metric = res.GetArea();
            return Metric;
        }*/

        public object Clone()
        {
            return new Solution(rectangles);
        }


        public Solution(List<Rectangle> rectgs)
        {
            this.rectangles = new List<Rectangle>();
            for (int i = 0; i < rectgs.Count(); i++)
            {
                this.rectangles.Add((Rectangle) rectgs[i].Clone());
            }
            this.IsValid();
        }

        public bool IsValid()
        {
            for (int i = 0; i < rectangles.Count; i++)
            {
                for (int j = i + 1; j < rectangles.Count; j++) {
                    ///Console.WriteLine($"i: {i}, j: {j}");
                    if (!rectangles[i].IsNotCrossing(rectangles[j]))
                    {
                        ////Metric = 100000000;
                        return false;
                    }
                }
            }

            ///this.recount_res();
            return true;
            
        }

        public int count_metric()
        {
            if (!IsValid()) return 1000000;
            int X_l = rectangles[0].x_l;
            int X_r = rectangles[0].x_r;
            int Y_t = rectangles[0].y_t;
            int Y_b = rectangles[0].y_b;
            foreach (Rectangle rec in rectangles)
            {
                if (rec.x_l < X_l)
                {
                    X_l = rec.x_l;
                }
                if (rec.x_r > X_r)
                {
                    X_r = rec.x_r;
                }
                if (rec.y_b < Y_b)
                {
                    Y_b = rec.y_b;
                }
                if (rec.y_t > Y_t)
                {
                    Y_t = rec.y_t;
                }

            }

            var res = new Rectangle(X_l, Y_b, X_r - X_l, Y_t - Y_b);
            Metric = res.GetArea();
            return res.GetArea();
        }

    }
}
