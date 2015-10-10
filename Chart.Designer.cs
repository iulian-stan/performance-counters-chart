using System.Drawing;
namespace PerformanceCounters
{
    partial class Chart
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
            this.chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.legend = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart.BackColor = System.Drawing.Color.SteelBlue;
			this.chart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalRight;
			this.chart.BackSecondaryColor = System.Drawing.Color.White;
			this.chart.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Sunken;
            legend.Name = "legend";
            legend.IsDockedInsideChartArea = true;
            legend.DockedToChartArea = "chartArea";
            legend.BackColor = Color.Transparent;
			chartArea.Area3DStyle.Enable3D = true;
			chartArea.Area3DStyle.Inclination = 20;
			chartArea.Area3DStyle.IsClustered = true;
			chartArea.Area3DStyle.IsRightAngleAxes = false;
			chartArea.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
			chartArea.Area3DStyle.Perspective = 20;
			chartArea.Area3DStyle.PointDepth = 200;
			chartArea.Area3DStyle.PointGapDepth = 200;
			chartArea.AxisY.Maximum = 100;
			chartArea.AxisY.Minimum = 0;
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
            this.chart.Legends.Add(legend);
			this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chart.Location = new System.Drawing.Point(0, 0);
			this.chart.Name = "chartPerfomance";            
            this.Size = new System.Drawing.Size(300, 300);
			this.chart.TabIndex = 0;
            this.chart.Text = "chartPerfomance";
            this.chart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chartPerfomance_MouseUp);
            this.chart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chartPerfomance_MouseMove);
            this.chart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chartPerfomance_MouseDown);
            // 
            // Chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chart);
            this.Name = "Chart";
            this.Size = new System.Drawing.Size(300, 300);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea;
        private System.Windows.Forms.DataVisualization.Charting.Legend legend;
        public  System.Windows.Forms.DataVisualization.Charting.Chart chart;
    }
}
