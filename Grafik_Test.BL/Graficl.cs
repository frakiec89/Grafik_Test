using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Grafik_Test.BL
{
    public class Grafic
    {

        public double Width { get; private set; }
        public double Height { get; private set; }
        
        public Grafic(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public Line GetLine ( double x1, double y1, double x2, double y2 )
        {
            return new Line()
            {
                PointStart = new Point() { X = GetXforWPF(x1), Y = GetYforWPF(y1) },
                PointEnd = new Point()
                {
                    X = GetXforWPF(x2),
                    Y = GetYforWPF(y2)
                }
            };
        }


        public double GetXforWPF (double xMath)
        {
            return (Width / 2) + xMath;
        }
        public double GetXforMath(double xWpf)
        {
            return  xWpf - (Width / 2);
        }

        public double GetYforWPF(double yMath)
        {
            return (Height / 2) - yMath;
        }

        public double GetYforMath(double yWpf)
        {
            return yWpf + (Height / 2);
        }

    }

    public  class Point
    {
        public  double X { get; set; }
        public double Y { get; set; }

        public  string Content { get; set; }

        public  bool VisebleContent { get; set; }
    }


    public class Line
    {
        public Point PointEnd { get; set; }
        public Point PointStart { get; set; }
    }
}
