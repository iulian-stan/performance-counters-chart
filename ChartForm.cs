using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PerformanceCounters
{
    public partial class ChartForm : Form
    {
        private ContextMenuStrip nodeMenu = new ContextMenuStrip();

        private List<PerformanceCounter> counters = new List<PerformanceCounter>();

        public ChartForm()
        {
            nodeMenu.Items.Add("Expand all", null, delegate(object sender, EventArgs e) { treeView.SelectedNode.ExpandAll(); });
            nodeMenu.Items.Add("Calopse all", null, delegate(object sender, EventArgs e) { treeView.SelectedNode.Collapse(false); });
            nodeMenu.Items.Add("Add to chart", null, delegate(object sender, EventArgs e)
            {
                var counter = treeView.SelectedNode.Tag as PerformanceCounter;
                if (counter != null)
                {
                    chart.AddSeries(counter.CounterName, Color.Red);
                    counters.Add(counter);
                }
            });
            nodeMenu.Items.Add("Clear chart", null, delegate(object sender, EventArgs e)
            {
                timer.Stop();
                foreach (var counter in counters)
                    chart.RemoveSeries(counter.CounterName);
                timer.Start();
            });

            InitializeComponent();
            timer.Start();
        }

        private void ChartForm_Load(object sender, EventArgs e)
        {
            treeView.BeginInvoke((MethodInvoker)async delegate
            {
                // Get a list of available performance counter categories
                PerformanceCounterCategory[] categories = PerformanceCounterCategory.GetCategories();
                Array.Sort(categories, delegate(PerformanceCounterCategory obj1, PerformanceCounterCategory obj2)
                {
                    return obj1.CategoryName.CompareTo(obj2.CategoryName);
                });
                foreach (var category in categories)
                {
                    var root = new TreeNode(category.CategoryName);
                    root.ToolTipText = "Performance counter category";
                    root.Tag = category;
                    treeView.Nodes.Add(root);

                    string[] instances;
                    if (category.CategoryType == PerformanceCounterCategoryType.SingleInstance)
                        instances = new string[] { string.Empty };
                    else
                    {
                        instances = category.GetInstanceNames();
                        Array.Sort(instances);
                    }

                    foreach (var instance in instances)
                    {
                        var node = root;
                        if (!string.IsNullOrEmpty(instance))
                        {
                            node = await NodeAdder(root, instance, "Instance");
                        }
                        try
                        {
                            var counters = category.GetCounters(instance);
                            Array.Sort(counters, delegate(PerformanceCounter obj1, PerformanceCounter obj2)
                            {
                                return obj1.CounterName.CompareTo(obj2.CounterName);
                            });
                            foreach (var counter in counters)
                                await NodeAdder(node, counter.CounterName, "Performce counter", counter);
                        }
                        catch (InvalidOperationException ex)
                        {
                            //Some instances are not longer valid by the time the are queried
                            Debug.WriteLine(ex.Message);
                        }
                    }
                }
            });
        }

        Task<TreeNode> NodeAdder(TreeNode parent, string nodeName, string toolTip, PerformanceCounter counter = null)
        {
            return Task.Run(() =>
                {
                    var node = new TreeNode(nodeName);
                    node.ToolTipText = toolTip;
                    if (counter != null)
                        node.Tag = counter;
                    treeView.BeginInvoke((MethodInvoker)delegate { parent.Nodes.Add(node); });
                    return node;
                });
        }

        private void treeView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                treeView.SelectedNode = treeView.GetNodeAt(e.Location);
                if (treeView.SelectedNode != null)
                    nodeMenu.Show(treeView, e.Location);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            foreach (var counter in counters)
            {
                chart.AddData(counter.CounterName, counter.NextValue());
            }
        }
    }
}