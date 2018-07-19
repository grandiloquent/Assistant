using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using Helpers;
using System.IO;

namespace Assistant
{
    public partial class Hbk3 : Form
    {
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private IEnumerable<int> _sumList;

        public Hbk3()
        {
            InitializeComponent();


        }

        private void saveToImageButton_Click(object sender, EventArgs e)
        {
            if (cartesianChart1 == null) return;
            var bitmap = ImageHelper.GetBitmap(cartesianChart1.Bounds.Width, cartesianChart1.Bounds.Height);
            cartesianChart1.DrawToBitmap(bitmap, cartesianChart1.Bounds);

            ImageHelper.SaveJpegWithCompression(bitmap, "hbk3.jpg".GetDesktopPath(), 95);
        }

        private void LoadDataSet()
        {
            if (_sumList == null)
            {
                var f = "hbk3.txt".GetCommandLinePath();
                if (!File.Exists(f)) return;

                _sumList = f.ReadAllText().Split('\n').Where(i => i.IsReadable())
                    .Distinct()
                    .OrderBy(i => i)
                    .Select(i => i.Trim().Split(new char[] { ' ' }, 2).Last().Split(',')
                    .Select(iv => int.Parse(iv)).Sum());

            }



        }
        private static Dictionary<string, int> StatisticsEvenOdd(IEnumerable<int> sumList)
        {
            var evenDictionary = new Dictionary<string, int>
            {
                { "大双", 0 },
                { "小双", 0 },
                { "大单", 0 },
                { "小单", 0 }
            };
            foreach (var sum in sumList)
            {

                if (sum > 10)
                {
                    if (sum % 2 == 0)
                    {
                        evenDictionary["大双"] += 1;
                    }
                    else
                    {
                        evenDictionary["大单"] += 1;

                    }
                }
                else
                {
                    if (sum % 2 == 0)
                    {
                        evenDictionary["小双"] += 1;
                    }
                    else
                    {
                        evenDictionary["小单"] += 1;

                    }
                }
            }

            return evenDictionary;
        }
        private static Dictionary<int, int> StatisticsSum(IEnumerable<int> sumList)
        {
            var sumDictionary = new Dictionary<int, int>();

            foreach (var sum in sumList)
            {

                if (sumDictionary.Keys.Contains(sum))
                {
                    sumDictionary[sum] += 1;
                }
                else
                {
                    sumDictionary.Add(sum, 1);

                }
            }
            return sumDictionary;


        }
        private void DsStatisticsButton_Click(object sender, EventArgs e)
        {
            LoadDataSet();
            var ed = StatisticsEvenOdd(_sumList);
            ed["双"] = ed["大双"] + ed["小双"];
            ed["单"] = ed["大单"] + ed["小单"];
            ed["大"] = ed["大双"] + ed["大单"];
            ed["小"] = ed["小双"] + ed["小单"];

            var ed1 = ed.OrderByDescending(i => i.Value).ToDictionary(i => i.Key, i => i.Value * 100d / _sumList.Count());

            var vs = Newtonsoft.Json.JsonConvert.SerializeObject(ed1);

            "hbk3_even_odd.json".GetDesktopPath().WriteAllText(vs);
            //if (this.cartesianChart1 != null)
            //{
            //    this.Controls.Remove(this.cartesianChart1);
            //    this.cartesianChart1 = null;
            //}
            //this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart
            //{

            //    Dock = DockStyle.Fill,
            //    Location = new System.Drawing.Point(0, 0),
            //    Name = "cartesianChart1",
            //    BackColor = Color.White,

            //    Text = "cartesianChart1"

            //};

            //this.Controls.Add(this.cartesianChart1);
            //LoadDataSet();
            //var ed = StatisticsEvenOdd(_sumList);
            //ed["双"] = ed["大双"] + ed["小双"];
            //ed["单"] = ed["大单"] + ed["小单"];
            //ed["大"] = ed["大双"] + ed["大单"];
            //ed["小"] = ed["小双"] + ed["小单"];
            //var v = new ChartValues<double>();
            //ed = ed.OrderByDescending(i => i.Value).ToDictionary(i=>i.Key,i=>i.Value);
            //v.AddRange(ed.Values.Select(i => i * 100d / _sumList.Count()));
            //v.Add(0d);

            //cartesianChart1.Series = new SeriesCollection
            //    {
            //        new ColumnSeries()
            //        {
            //            Title="单双统计",
            //            Values=v
            //        }
            //    };

            //cartesianChart1.AxisX.Add(new Axis
            //{

            //    Labels = ed.Keys.ToArray(),

            //    FontSize = 12
            //});

            //cartesianChart1.AxisY.Add(new Axis
            //{
            //    Title = "百分比",

            //    FontSize = 12
            //});


        }

        private void sumButton_Click(object sender, EventArgs e)
        {

            LoadDataSet();
            var ed = StatisticsSum(_sumList);


            var ed1 = ed.OrderByDescending(i => i.Value).ToDictionary(i => i.Key, i => i.Value * 100d / _sumList.Count());

            var vs = Newtonsoft.Json.JsonConvert.SerializeObject(ed1);

            "hbk3_even_sum.json".GetDesktopPath().WriteAllText(vs);

        }

        private void sumStatisticsButton_Click(object sender, EventArgs e)
        {

        }

        private void simulateButton_Click(object sender, EventArgs e)
        {
            var (s, ss) = MockLottery.Random1000();
            //if (this.cartesianChart1 != null)
            //{
            //    this.Controls.Remove(this.cartesianChart1);
            //    this.cartesianChart1 = null;
            //}
            //this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart
            //{

            //    Dock = DockStyle.Fill,
            //    Location = new System.Drawing.Point(0, 0),
            //    Name = "cartesianChart1",
            //    BackColor = Color.White,

            //    Text = "cartesianChart1"

            //};

            //this.Controls.Add(this.cartesianChart1);
            //var v = new ChartValues<int>();
            //var v1 = new ChartValues<int>();

            //v.AddRange(s);
            //v1.AddRange(ss);

            //cartesianChart1.Series = new SeriesCollection
            //{
            //    new LineSeries
            //    {
            //        Title = "Series 1",
            //        Values =v,
            //        PointGeometry = null
            //    },

            //};
            //cartesianChart1.Series.Add(

            //    new LineSeries
            //    {
            //        Title = "Series 1",
            //        Values = v1,
            //        PointGeometry = null
            //    });
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Lottery.MarkSix();

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var lines = "marksix.txt".GetDesktopPath().ReadAllLines().OrderBy(i=>i);

            "marksix.txt".GetDesktopPath().WriteAllText(string.Join("\n", lines));
        }

        private void analysisButton_Click(object sender, EventArgs e)
        {
            MockLottery.AnalysisRandom1000();
        }
    }
}
