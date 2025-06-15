using System.Drawing;
using System.Windows.Forms;

namespace PerformanceCounters
{
    partial class ChartForm : Form
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            treeView = new TreeView();
            timer = new Timer(components);
            chart = new ChartContrl();
            splitContainer = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(splitContainer)).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            SuspendLayout();
            //
            // treeView
            //
            treeView.Dock = DockStyle.Fill;
            treeView.Location = new Point(0, 0);
            treeView.Name = "treeView";
            treeView.Size = new Size(175, 288);
            treeView.TabIndex = 12;
            treeView.MouseClick += new MouseEventHandler(treeView_MouseClick);
            //
            // timer
            //
            timer.Interval = 1000;
            timer.Tick += new System.EventHandler(timer_Tick);
            //
            // chart
            //
            chart.Dock = DockStyle.Fill;
            chart.Location = new Point(0, 0);
            chart.Name = "chart";
            chart.Size = new Size(348, 288);
            chart.TabIndex = 11;
            //
            // splitContainer
            //
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 0);
            splitContainer.Name = "splitContainer";
            //
            // splitContainer.Panel1
            //
            splitContainer.Panel1.Controls.Add(treeView);
            //
            // splitContainer.Panel2
            //
            splitContainer.Panel2.Controls.Add(chart);
            splitContainer.Size = new Size(527, 288);
            splitContainer.SplitterDistance = 175;
            splitContainer.TabIndex = 13;
            //
            // ChartForm
            //
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(527, 288);
            Controls.Add(splitContainer);
            MaximizeBox = false;
            Name = "ChartForm";
            Text = "Performance Counters";
            Load += new System.EventHandler(ChartForm_Load);
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(splitContainer)).EndInit();
            splitContainer.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private ChartContrl chart;
        private TreeView treeView;
        private Timer timer;
        private SplitContainer splitContainer;
    }
}

