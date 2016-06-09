using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerformanceCounters
{
    public partial class ChartForm
    {
        private readonly ContextMenuStrip nodeMenu = new ContextMenuStrip();
        private readonly ContextMenuStrip leafMenu = new ContextMenuStrip();
        private readonly Random randomGen = new Random();
        private readonly KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
        private readonly List<PerformanceCounter> counters = new List<PerformanceCounter>();

        public ChartForm()
        {
            nodeMenu.Items.Add("Expand all", null, delegate { treeView.SelectedNode.ExpandAll(); });
            nodeMenu.Items.Add("Calopse all", null, delegate { treeView.SelectedNode.Collapse(false); });
            leafMenu.Items.Add("Add to chart", null, delegate
            {
                var counter = treeView.SelectedNode.Tag as PerformanceCounter;
                if (counter != null)
                {
                    chart.AddSeries(counter.CounterName, Color.FromKnownColor(names[randomGen.Next(names.Length)]));
                    counters.Add(counter);
                }
            });
            InitializeComponent();
            timer.Start();
        }

        private void ChartForm_Load(object sender, EventArgs e)
        {
            treeView.BeginInvoke((MethodInvoker)delegate
            {
               // Get a list of available performance counter categories
               PerformanceCounterCategory[] categories = PerformanceCounterCategory.GetCategories();
               Array.Sort(categories, (obj1, obj2) => string.Compare(obj1.CategoryName, obj2.CategoryName, StringComparison.Ordinal));
               foreach (var category in categories)
               {
                   var root = new TreeNode(category.CategoryName);
                   root.ToolTipText = "Performance counter category";
                   root.Tag = category;
                   treeView.Nodes.Add(root);
                   Task.Run(async () =>
                   {
                       string[] instances;
                       if (category.CategoryType == PerformanceCounterCategoryType.SingleInstance)
                           instances = new[] { string.Empty };
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
                               var categCounters = category.GetCounters(instance);
                               Array.Sort(categCounters, (obj1, obj2) => string.Compare(obj1.CategoryName, obj2.CategoryName, StringComparison.Ordinal));
                               foreach (var counter in categCounters)
                                   await NodeAdder(node, counter.CounterName, "Performce counter", counter);
                           }
                           catch (InvalidOperationException ex)
                           {
                               //Some instances are not longer valid by the time the are queried
                               Debug.WriteLine(ex.Message);
                           }
                       }
                   });
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
            if (e.Button == MouseButtons.Right)
            {
                treeView.SelectedNode = treeView.GetNodeAt(e.Location);
                if (treeView.SelectedNode == null)
                    return;
                if (treeView.SelectedNode.Nodes.Count == 0)
                    leafMenu.Show(treeView, e.Location);
                if (treeView.SelectedNode.Nodes.Count > 0)
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