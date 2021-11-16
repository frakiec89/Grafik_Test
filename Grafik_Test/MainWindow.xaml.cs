using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Grafik_Test.BL;
using Grafik_Test.Model;
using Microsoft.Win32;

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
            canvasGrafic.Children.Clear();
            OsiX_Y("x (даты)" , "y (кол-во)");
            var sell = Model.GrahtSell.SellModels(); //получаем продажи в формате  16.10.2021. 10 шт
            List<BL.Point> points = GetPoints(sell); // получим  точки
            GetLines(points);
            GetLabel(points);

        }

        private void GetLabel(List<BL.Point> points)
        {
            Grafic grafic = new Grafic(canvasGrafic.ActualWidth, canvasGrafic.ActualHeight);

            for (int i = 0; i < points.Count - 1; i++)
            {
                if (i % 5 == 0)
                {
                    var label = new Label() { Content =
                        points[i].Content, RenderTransform = new RotateTransform(90)
                    };
                    Canvas.SetLeft(label, grafic.GetXforWPF( points[i].X) + 5);
                    Canvas.SetTop(label, canvasGrafic.ActualHeight / 2 + 5);
                    canvasGrafic.Children.Add(label);
                }
            }
        }

        /// <summary>
        /// рисуем  график по  точкам 
        /// </summary>
        /// <param name="points"></param>
        private void GetLines(List<BL.Point> points)
        {
            for (int i = 0; i < points.Count-1; i++)
            {
                   canvasGrafic.Children.Add(
                   NewLine(points[i].X, points[i].Y, points[i + 1].X
                   , points[i + 1].Y));
            }
        }

        /// <summary>
        /// получаем  точки  для графика
        /// </summary>
        /// <param name="sell"></param>
        /// <returns></returns>
        private List<BL.Point> GetPoints(List<GrahtSellModel> sell)
        {
            List < BL.Point > point = new();
            int x= -800;
            foreach (var item in sell)
            {
                point.Add(new BL.Point()
                {
                    X = x , Y = item.Count *5 , Content = $"{item.Date.Day}.{item.Date.Month}.{item.Date.Year}"  , VisebleContent =true
                });
                x +=5;
            }
            return point;
        }

        /// <summary>
        /// рисует  ось координат
        /// </summary>
        private void OsiX_Y(string xName , string yName)
        {
            //надпись
            canvasGrafic.Children.Add(new Label()
            {
                Content = xName , Padding = new Thickness(
                    canvasGrafic.ActualWidth -100 ,canvasGrafic.ActualHeight/2 +50 ,
                100 , canvasGrafic.ActualHeight / 2)
            });

            //надпись
            canvasGrafic.Children.Add(new Label()
            {
                Content = yName,
                Padding = new Thickness(canvasGrafic.ActualWidth/2 - 100 , 0 , 0 , canvasGrafic.ActualHeight)
            });

            //пунктиры
            for (int i = (int)canvasGrafic.ActualWidth / 2 * -1; i < (int)canvasGrafic.ActualWidth / 2; i += 10)
            {
                canvasGrafic.Children.Add(NewLine(i, 5, i, -5));
            }
            //пунктиры
            for (int i = (int)canvasGrafic.ActualHeight / 2 * -1; i < (int)canvasGrafic.ActualHeight / 2; i += 10)
            {
                canvasGrafic.Children.Add(NewLine(5, i, -5, i));
            }
            //x
            canvasGrafic.Children.Add(NewLine(canvasGrafic.ActualWidth / 2 * -1, 0, canvasGrafic.ActualWidth / 2, 0));
            //y
            canvasGrafic.Children.Add(NewLine(0, canvasGrafic.ActualHeight / 2, 0, canvasGrafic.ActualHeight / 2 * -1));
        }

        private System.Windows.Shapes.Line NewLine(double x1 , double y1 , double x2 , double y2)
        {
            Grafic grafic = new Grafic(canvasGrafic.ActualWidth, canvasGrafic.ActualHeight);
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


        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            if (canvasGrafic != null) //если в pictureBox есть изображение
            {
               
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как...";
                //отображать ли предупреждение, если пользователь указывает имя уже существующего файла
                savedialog.OverwritePrompt = true;
                //отображать ли предупреждение, если пользователь указывает несуществующий путь
                savedialog.CheckPathExists = true;
                //список форматов файла, отображаемый в поле "Тип файла"
                savedialog.Filter = "Image Files(*.PNG)|*.PDF|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
               
                //отображается ли кнопка "Справка" в диалоговом окне
                if (savedialog.ShowDialog() == true) //если в диалоговом окне нажата кнопка "ОК"
                {
                    try
                    {
                        RenderTargetBitmap renderBitmap = new RenderTargetBitmap
                            ((int)canvasGrafic.ActualWidth, (int)canvasGrafic.ActualHeight
                            , 100d, 100d, PixelFormats.Default
                            );
                        renderBitmap.Render(this);
                        using (FileStream outStream = new FileStream(savedialog.FileName, FileMode.Create))
                        {
                            BmpBitmapEncoder encoder = new BmpBitmapEncoder();
                            encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
                            encoder.Save(outStream);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображениe "); 
                    }
                }
            }
        }
    }
}
