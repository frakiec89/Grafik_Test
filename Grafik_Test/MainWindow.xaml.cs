using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Grafik_Test.BL;

namespace Grafik_Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btPaint_Click(object sender, RoutedEventArgs e)
        {
            canvasFrafic.Children.Clear();
            OsiX_Y();
        }

        /// <summary>
        /// рисует  ось координат
        /// </summary>
        private void OsiX_Y()
        {
            for (int i = (int)canvasFrafic.ActualWidth / 2 * -1; i < (int)canvasFrafic.ActualWidth / 2; i += 10)
            {
                canvasFrafic.Children.Add(NewLine(i, 5, i, -5));
            }

            for (int i = (int)canvasFrafic.ActualHeight / 2 * -1; i < (int)canvasFrafic.ActualHeight / 2; i += 10)
            {
                canvasFrafic.Children.Add(NewLine(5, i, -5, i));
            }
            canvasFrafic.Children.Add(NewLine(canvasFrafic.ActualWidth / 2 * -1, 0, canvasFrafic.ActualWidth / 2, 0));
            canvasFrafic.Children.Add(NewLine(0, canvasFrafic.ActualHeight / 2, 0, canvasFrafic.ActualHeight / 2 * -1));
        }

        private System.Windows.Shapes.Line NewLine(double x1 , double y1 , double x2 , double y2)
        {
            Grafic grafic = new Grafic(canvasFrafic.ActualWidth, canvasFrafic.ActualHeight);
            var l = grafic.GetLine(x1 ,y1,x2 , y2);
            var line = new System.Windows.Shapes.Line()
            {
                X1 = l.PointStart.X,
                X2 = l.PointEnd.X,
                Y1 = l.PointStart.Y,
                Y2 = l.PointEnd.Y,
                StrokeThickness = 1,
                Stroke = Brushes.Black
            };
            return line;
        }
    }
}
