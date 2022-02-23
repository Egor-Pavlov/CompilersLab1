using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgLab15
{
    class circle
    {
        private float center_x;
        private float center_y;
        private float radius;

        public circle(float x, float y, float r)
        {
            if (r <= 0) throw new ArgumentException("The radius cannot be less than 0", "Radius");
            
            else radius = r;
            center_x = x;
            center_y = y;
        }

        public double perimetr()
        {
            return 2 * 3.1415926 * radius;
        }

        public double area()
        {
            return 3.1415926 * radius * radius;
        }
        public float Center_x//Чтение-установка имени
        {
            get
            {
                return center_x;
            }
            set
            {
                center_x = value;
            }
        }

        public float Center_y//Чтение-установка имени
        {
            get
            {
                return center_y;
            }
            set
            {
                center_y = value;
            }
        }

        public float Radius//Чтение-установка имени
        {
            get
            {
                return radius;
            }
            set
            {
                if (value <= 0) throw new ArgumentException("The radius cannot be less than 0", "Radius");
                else radius = value;
            }
        }
    }

}
