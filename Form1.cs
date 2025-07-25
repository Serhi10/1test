using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace t4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Очищаем серию с косинусом (если она уже существует)
            chart1.Series["sin3"].Points.Clear();

            // Устанавливаем тип графика - линия
            chart1.Series["sin3"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            // Задаем цвет линии - синий
            chart1.Series["sin3"].Color = Color.Blue;

            // Генерируем точки для косинуса от -2π до 2π
            for (double x = -2 * Math.PI; x <= 2 * Math.PI; x += 0.1)
            {
                // Добавляем точку (x, cos(x)) в серию sin3
                chart1.Series["sin3"].Points.AddXY(x, Math.Cos(x));
            }

            // Настраиваем подписи осей
            chart1.ChartAreas[0].AxisX.Title = "X";
            chart1.ChartAreas[0].AxisY.Title = "cos(x)";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Очищаем предыдущие данные
            chart1.Series["sins"].Points.Clear();
            chart1.Series["sin2"].Points.Clear();
            chart1.Series["sin3"].Points.Clear();

            // Генерируем точки для синуса
            for (double x = 0; x < 2 * Math.PI; x += 0.1)
            {
                double y = Math.Sin(x);
                double z = Math.Sin(x)*Math.Sin(2*x) * Math.Sin(3 * x) * Math.Sin(4 * x);

                // Добавляем точки в разные серии (для демонстрации разных типов графиков)
                chart1.Series["sins"].Points.AddXY(x, y);    // Точечный график
                chart1.Series["sin2"].Points.AddXY(x, y);    // Линейный график
                chart1.Series["sin3"].Points.AddXY(x, z);    // Быстрая линия
            }
        }
    }
}
