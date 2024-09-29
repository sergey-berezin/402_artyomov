namespace NugetPack
{
    public class Rectangle
    {
        public int weight { get; set; }
        public int height { get; set; }
        public int x_l { get; set; }
        public int y_b { get; set; }
        public int x_r { get; set; }
        public int y_t { get; set; }

        ///Создаем квадрат по левой нижней точке
        public Rectangle(int x, int y, int w, int h)
        {
            this.x_l = x;
            this.x_r = x + w;
            this.weight = w;
            this.height = h;
            this.y_b = y;
            this.y_t = y + h;
        }

        public int GetArea()
        { return (x_r - x_l) * (y_t - y_b); }


        public bool IsNotCrossing(Rectangle r2)
        {
            return (r2.x_r < x_l || r2.x_l > x_r) && (r2.y_t > y_b || r2.y_b < y_t); 
        }
    }

}

