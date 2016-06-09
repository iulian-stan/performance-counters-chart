using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PerformanceCounters
{
    partial class ChartContrl : UserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            this.chart.BackColor = System.Drawing.Color.SteelBlue;
            this.chart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalRight;
            this.chart.BackSecondaryColor = System.Drawing.Color.White;
            chartArea.Area3DStyle.Enable3D = true;
            chartArea.Area3DStyle.Inclination = 20;
            chartArea.Area3DStyle.IsClustered = true;
            chartArea.Area3DStyle.IsRightAngleAxes = false;
            chartArea.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea.Area3DStyle.Perspective = 20;
            chartArea.Area3DStyle.PointDepth = 200;
            chartArea.Area3DStyle.PointGapDepth = 200;
            chartArea.AxisY.Maximum = 100D;
            chartArea.AxisY.Minimum = 0D;
            chartArea.AxisY.ScaleBreakStyle.BreakLineStyle = System.Windows.Forms.DataVisualization.Charting.BreakLineStyle.Wave;
            chartArea.AxisY.ScaleBreakStyle.Enabled = true;
            chartArea.AxisY.ScaleBreakStyle.LineColor = System.Drawing.Color.Lime;
            chartArea.BackColor = System.Drawing.Color.LightBlue;
            chartArea.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.Center;
            chartArea.BackSecondaryColor = System.Drawing.Color.White;
            chartArea.BorderColor = System.Drawing.Color.Empty;
            chartArea.InnerPlotPosition.Auto = false;
            chartArea.InnerPlotPosition.Height = 88.48166F;
            chartArea.InnerPlotPosition.Width = 90.2958F;
            chartArea.InnerPlotPosition.X = 8.5382F;
            chartArea.InnerPlotPosition.Y = 2.35462F;
            chartArea.Name = "chartArea";
            chartArea.ShadowColor = System.Drawing.Color.Empty;
            this.chart.ChartAreas.Add(chartArea);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend.BackColor = System.Drawing.Color.Transparent;
            legend.DockedToChartArea = "chartArea";
            legend.Name = "legend";
            this.chart.Legends.Add(legend);
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Margin = new System.Windows.Forms.Padding(0);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(300, 300);
            this.chart.TabIndex = 0;
            this.chart.Text = "chartPerfomance";
            this.chart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chartPerfomance_MouseClick);
            this.chart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chartPerfomance_MouseDown);
            this.chart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chartPerfomance_MouseMove);
            this.chart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chartPerfomance_MouseUp);
            // 
            // ChartContrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chart);
            this.Name = "ChartContrl";
            this.Size = new System.Drawing.Size(300, 300);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        
        public  Chart chart;
    }
}
