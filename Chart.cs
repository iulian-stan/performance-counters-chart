using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PerformanceCounters
{
    public partial class Chart : UserControl
    {
        public Chart()
        {
            InitializeComponent();
        }

        public void AddSeries(string name, Color color)
        {             
            Series series = new Series();
            series.ChartArea = "chartArea";
            series.Legend = "legend";
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series.Color = color;
            series.Name = name;
            series.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            chart.Series.Add(series);
        }

        public void RemoveSeries(string name)
        {
            chart.Series.Remove(chart.Series.FindByName(name));
        }

        public void AddData(string name, float value)
        {
            DateTime timeStamp = DateTime.Now;

            AddNewPoint(timeStamp, chart.Series[name], value);
        }

        public void AddNewPoint(DateTime timeStamp, Series ptSeries, float nexVal)
        {
            ptSeries.Points.AddXY(timeStamp.ToOADate(), nexVal);

            double removeBefore = timeStamp.AddSeconds((double)(9) * (-1)).ToOADate();

            while (ptSeries.Points[0].XValue < removeBefore)
            {
                ptSeries.Points.RemoveAt(0);
            }

            chart.ChartAreas[0].AxisX.Minimum = ptSeries.Points[0].XValue;
            chart.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(ptSeries.Points[0].XValue).AddSeconds(10).ToOADate();

            chart.Invalidate();
        }

        private void chartPerfomance_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = savedRotation - (savedLocation.X - e.X);
                int y = savedInclination - (savedLocation.Y - e.Y);
                chart.ChartAreas[0].Area3DStyle.Rotation = Math.Max(Math.Min(x, 180), -180); //x % 360 - 360 * ((x / 180) % 2);
                chart.ChartAreas[0].Area3DStyle.Inclination = Math.Max(Math.Min(y, 90), -90);
            }
        }

        private void chartPerfomance_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Cursor = Cursors.NoMove2D;
                savedLocation = e.Location;
                savedRotation = chart.ChartAreas[0].Area3DStyle.Rotation;
                savedInclination = chart.ChartAreas[0].Area3DStyle.Inclination;
            }
        }

        private void chartPerfomance_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Cursor = Cursors.Default;
            }
        }

        private Point savedLocation;
        private int savedRotation;
        private int savedInclination;
    }
}
