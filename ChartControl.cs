using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PerformanceCounters
{
    public partial class ChartContrl
    {
        private Point savedLocation;
        private int savedRotation;
        private int savedInclination;

        public ChartContrl()
        {
            InitializeComponent();
        }

        public void AddSeries(string name, Color color)
        {
            Series series = new Series();
            series.ChartArea = "chartArea";
            series.Legend = "legend";
            series.IsVisibleInLegend = false;
            series.ChartType = SeriesChartType.Spline;
            series.Color = color;
            series.Name = name;
            series.XValueType = ChartValueType.Time;
            series.YValueType = ChartValueType.Int32;
            chart.Series.Add(series);
            LegendItem legendItem = new LegendItem();
            legendItem.Name = name;
            legendItem.Color = color;
            legendItem.Tag = series;
            chart.Legends[0].CustomItems.Add(legendItem);
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

        private void chartPerfomance_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult result = chart.HitTest(e.X, e.Y);
            if (result == null || result.Object == null)
                return;
            // When user hits the LegendItem
            LegendItem legendItem = result.Object as LegendItem;
            if (legendItem == null)
                return;
            // series item selected
            Series selectedSeries = (Series)legendItem.Tag;

            if (selectedSeries == null)
                return;
            
            if (selectedSeries.Enabled)
                selectedSeries.Enabled = false;
            else
                selectedSeries.Enabled = true;
        }
    }
}
