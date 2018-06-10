namespace Assistant
{
    using Helpers;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    class Lottery
    {
        private async static Task<string> GetHTML(string link, bool checkencoding = true)
        {
            var httpClient = new HttpClient(new HttpClientHandler()
            {
                UseProxy = false,
                UseDefaultCredentials = false,
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,

            })
            {
            };

            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");

            var response = await httpClient.GetAsync(link);

            if (checkencoding && response.IsSuccessStatusCode)
            {
                var contenttype = response.Content.Headers.First(h => h.Key.Equals("Content-Type"));
                var rawencoding = contenttype.Value.First();
                var bytes = await response.Content.ReadAsByteArrayAsync();
                if (rawencoding.Contains("utf8") || rawencoding.Contains("UTF-8"))
                {

                    return Encoding.UTF8.GetString(bytes);
                }
                else
                {
                    return Encoding.GetEncoding("gb2312").GetString(bytes);
                }
            }
            return null;

        }


        private static void AnalysisHuBeiK3EvenBig(IEnumerable<int> ls, StringBuilder sb)
        {
            sb.AppendLine("## 大双开奖频率统计").AppendLine();


            var a = 0;
            var b = 0;
            var v = new List<KeyValuePair<int, int>>();
            foreach (var sum in ls)
            {


                if (sum > 10 && sum % 2 == 0)
                {
                    if (b != 0)
                    {
                        v.Add(new KeyValuePair<int, int>(0, b));
                        b = 0;
                    }
                    a++;

                }
                else
                {
                    if (a != 0)
                    {
                        v.Add(new KeyValuePair<int, int>(1, a));
                        a = 0;
                    }
                    b++;
                }
            }

            sb.AppendLine($"大双最大连续开奖期数 {v.Where(i => i.Key == 1).Max(i => i.Value)},最大相隔期数 {v.Where(i => i.Key == 0).Max(i => i.Value)}");
            sb.AppendLine().AppendLine();

            var c = new Dictionary<int, int>();
            var e = new Dictionary<int, int>();
            foreach (var item in v)
            {
                if (item.Key == 1)
                {
                    if (c.Keys.Contains(item.Value))
                    {
                        c[item.Value] += 1;
                    }
                    else
                    {
                        c[item.Value] = 1;
                    }
                }
            }
            foreach (var item in v)
            {
                if (item.Key == 0)
                {
                    if (e.Keys.Contains(item.Value))
                    {
                        e[item.Value] += 1;
                    }
                    else
                    {
                        e[item.Value] = 1;
                    }
                }
            }
            var co = c.OrderByDescending(i => i.Value).ThenBy(i => i.Key);
            var eo = e.OrderByDescending(i => i.Value).ThenBy(i => i.Key);

            sb.AppendLine("大双连续期统计").AppendLine();

            foreach (var item in co)
            {
                sb.AppendLine($"- 大双连续 {item.Key} 期开奖 {item.Value} 次");
            }
            sb.AppendLine().AppendLine();
            sb.AppendLine("大双相隔期统计").AppendLine();

            foreach (var item in eo)
            {
                sb.AppendLine($"- 大双相隔 {item.Key} 期开奖 {item.Value} 次");
            }
            sb.AppendLine().AppendLine();

        }

        private static void AnalysisHuBeiK3EvenSmall(IEnumerable<int> ls, StringBuilder sb)
        {
            sb.AppendLine("## 小双开奖频率统计").AppendLine(); ;


            var a = 0;
            var b = 0;
            var v = new List<KeyValuePair<int, int>>();
            foreach (var sum in ls)
            {

                if (sum < 11 && sum % 2 == 0)
                {
                    if (b != 0)
                    {
                        v.Add(new KeyValuePair<int, int>(0, b));
                        b = 0;
                    }
                    a++;

                }
                else
                {
                    if (a != 0)
                    {
                        v.Add(new KeyValuePair<int, int>(1, a));
                        a = 0;
                    }
                    b++;
                }
            }

            sb.AppendLine($"小双最大连续开奖期数 {v.Where(i => i.Key == 1).Max(i => i.Value)},最大相隔期数 {v.Where(i => i.Key == 0).Max(i => i.Value)}");
            sb.AppendLine().AppendLine();

            var c = new Dictionary<int, int>();
            var e = new Dictionary<int, int>();
            foreach (var item in v)
            {
                if (item.Key == 1)
                {
                    if (c.Keys.Contains(item.Value))
                    {
                        c[item.Value] += 1;
                    }
                    else
                    {
                        c[item.Value] = 1;
                    }
                }
            }
            foreach (var item in v)
            {
                if (item.Key == 0)
                {
                    if (e.Keys.Contains(item.Value))
                    {
                        e[item.Value] += 1;
                    }
                    else
                    {
                        e[item.Value] = 1;
                    }
                }
            }
            var co = c.OrderByDescending(i => i.Value).ThenBy(i => i.Key);
            var eo = e.OrderByDescending(i => i.Value).ThenBy(i => i.Key);
            sb.AppendLine("小双连续期统计").AppendLine();

            foreach (var item in co)
            {
                sb.AppendLine($"- 小双连续 {item.Key} 期开奖 {item.Value} 次");
            }
            sb.AppendLine().AppendLine();
            sb.AppendLine("小双相隔期统计").AppendLine();

            foreach (var item in eo)
            {
                sb.AppendLine($"- 小双相隔 {item.Key} 期开奖 {item.Value} 次");
            }
            sb.AppendLine().AppendLine();

        }

        private static void AnalysisHuBeiK3OddBig(IEnumerable<int> ls, StringBuilder sb)
        {
            sb.AppendLine("## 大单开奖频率统计").AppendLine(); ;


            var a = 0;
            var b = 0;
            var v = new List<KeyValuePair<int, int>>();
            foreach (var sum in ls)
            {
                if (sum > 10 && sum % 2 != 0)
                {
                    if (b != 0)
                    {
                        v.Add(new KeyValuePair<int, int>(0, b));
                        b = 0;
                    }
                    a++;

                }
                else
                {
                    if (a != 0)
                    {
                        v.Add(new KeyValuePair<int, int>(1, a));
                        a = 0;
                    }
                    b++;
                }
            }

            sb.AppendLine($"大单最大连续开奖期数 {v.Where(i => i.Key == 1).Max(i => i.Value)},最大相隔期数 {v.Where(i => i.Key == 0).Max(i => i.Value)}");
            sb.AppendLine().AppendLine();

            var c = new Dictionary<int, int>();
            var e = new Dictionary<int, int>();
            foreach (var item in v)
            {
                if (item.Key == 1)
                {
                    if (c.Keys.Contains(item.Value))
                    {
                        c[item.Value] += 1;
                    }
                    else
                    {
                        c[item.Value] = 1;
                    }
                }
            }
            foreach (var item in v)
            {
                if (item.Key == 0)
                {
                    if (e.Keys.Contains(item.Value))
                    {
                        e[item.Value] += 1;
                    }
                    else
                    {
                        e[item.Value] = 1;
                    }
                }
            }
            var co = c.OrderByDescending(i => i.Value).ThenBy(i => i.Key);
            var eo = e.OrderByDescending(i => i.Value).ThenBy(i => i.Key);
            sb.AppendLine("大单连续期统计").AppendLine();

            foreach (var item in co)
            {
                sb.AppendLine($"- 大单连续 {item.Key} 期开奖 {item.Value} 次");
            }
            sb.AppendLine().AppendLine();
            sb.AppendLine("大单相隔期统计").AppendLine();

            foreach (var item in eo)
            {
                sb.AppendLine($"- 大单相隔 {item.Key} 期开奖 {item.Value} 次");
            }
            sb.AppendLine().AppendLine();

        }

        private static void AnalysisHuBeiK3OddSmall(IEnumerable<int> ls, StringBuilder sb)
        {
            sb.AppendLine("## 小单开奖频率统计").AppendLine(); ;


            var a = 0;
            var b = 0;
            var v = new List<KeyValuePair<int, int>>();
            foreach (var sum in ls)
            {

                if (sum < 11 && sum % 2 != 0)
                {
                    if (b != 0)
                    {
                        v.Add(new KeyValuePair<int, int>(0, b));
                        b = 0;
                    }
                    a++;

                }
                else
                {
                    if (a != 0)
                    {
                        v.Add(new KeyValuePair<int, int>(1, a));
                        a = 0;
                    }
                    b++;
                }
            }

            sb.AppendLine($"小单最大连续开奖期数 {v.Where(i => i.Key == 1).Max(i => i.Value)},最大相隔期数 {v.Where(i => i.Key == 0).Max(i => i.Value)}");
            sb.AppendLine().AppendLine();

            var c = new Dictionary<int, int>();
            var e = new Dictionary<int, int>();
            foreach (var item in v)
            {
                if (item.Key == 1)
                {
                    if (c.Keys.Contains(item.Value))
                    {
                        c[item.Value] += 1;
                    }
                    else
                    {
                        c[item.Value] = 1;
                    }
                }
            }
            foreach (var item in v)
            {
                if (item.Key == 0)
                {
                    if (e.Keys.Contains(item.Value))
                    {
                        e[item.Value] += 1;
                    }
                    else
                    {
                        e[item.Value] = 1;
                    }
                }
            }
            var co = c.OrderByDescending(i => i.Value).ThenBy(i => i.Key);
            var eo = e.OrderByDescending(i => i.Value).ThenBy(i => i.Key);
            sb.AppendLine("小单连续期统计").AppendLine();
            foreach (var item in co)
            {
                sb.AppendLine($"- 小单连续 {item.Key} 期开奖 {item.Value} 次");
            }
            sb.AppendLine().AppendLine();
            sb.AppendLine("小单相隔期统计").AppendLine();

            foreach (var item in eo)
            {
                sb.AppendLine($"- 小单相隔 {item.Key} 期开奖 {item.Value} 次");
            }
            sb.AppendLine().AppendLine();

        }

        private static void AnalysisSum(Dictionary<int,int> dic,IEnumerable<int> ls, StringBuilder sb)
        {
            foreach (var item in dic.Keys)
            {
                var a = 0;
                var b = 0;

                var e = new List<KeyValuePair<int, int>>();
                 

                sb.AppendLine().AppendLine($"## 和值 {item} 开奖频率统计").AppendLine();

                foreach (var i in ls)
                {
                    if (item == i)
                    {
                        a++;
                        //if (b != 0)
                        //{
                        //    e.Add(new KeyValuePair<int, int>(1, b));
                        //    b = 0;

                        //}
                    }
                    else
                    {
                        //b++;
                        if (a != 0)
                        {
                            e.Add(new KeyValuePair<int, int>(0, a));

                            a = 0;

                        }
                    }
                }
                var f = new Dictionary<int, int>();
               // var g = new Dictionary<int, int>();

                foreach (var iv in e)
                {
                    if (iv.Key == 0)
                    {
                        if (f.Keys.Contains(iv.Value))
                        {
                            f[iv.Value] += 1;
                        }
                        else
                        {
                            f[iv.Value] = 1;
                        }
                    }
                }
                //foreach (var iv in e)
                //{
                //    if (iv.Key == 1)
                //    {
                //        if (g.Keys.Contains(iv.Value))
                //        {
                //           g[iv.Value] = +1;
                //        }
                //        else
                //        {
                //            g[iv.Value] = 1;
                //        }
                //    }
                //}
                sb.AppendLine($"和值 {item} 连续期频率统计").AppendLine();

                foreach (var iv in f.OrderByDescending(i=>i.Value))
                {
                    sb.AppendLine($"- {item} 连续 {iv.Key} 期开奖 {iv.Value} 次");

                }

                sb.AppendLine();
                //sb.AppendLine().AppendLine($"和值 {item} 相隔期频率统计").AppendLine();

                //foreach (var iv in g)
                //{
                //    sb.AppendLine($"- {item} 相隔 {iv.Key} 期开奖 {iv.Value} 次");

                //}
            }
        }
        private static void ParseXML(string v)
        {
            try
            {
                if (v == null) return;
                var xmlDocument = XDocument.Parse(v);

                var ls = new List<string>();
                foreach (var item in xmlDocument.Root.Elements("row"))
                {
                    var expect = item.Attribute("expect").Value;
                    var opencode = item.Attribute("opencode").Value;
                    ls.Add(expect + " " + opencode);
                }
                ls.Add(Environment.NewLine);



                "hbk3.txt".AppendAllText(string.Join(Environment.NewLine, ls));
            }
            catch (Exception exc)
            {
                DebugHelper.WriteException(exc);
            }
        }
        private static (string, int) Sum(string s)
        {
            var split = s.Split(new char[] { ' ' }, 2).Last().Split(',').Select(i => int.Parse(i)).OrderBy(i => i).ToArray();

            var t = "";

            if (split[0] == split[1] && split[1] == split[2])
            {
                t = "三同号";
            }
            else if (split[0] + 1 == split[1] && split[1] + 1 == split[2])
            {
                t = "连号";
            }
            return (t, split.Sum());
        }

        public async static Task HuBeiK3()
        {

            var url = "http://kaijiang.500.com/hbk3.shtml";

            var h = await GetHTML(url);

            DateTime dateTimeStart = new DateTime(2015, 11, 3);
            DateTime dateTimeEnd = new DateTime(2018, 6, 10);

            while (dateTimeStart < dateTimeEnd)
            {
                var dst = dateTimeStart.ToString("yyyyMMdd");
                var l = "http://kaijiang.500.com/static/info/kaijiang/xml/hbk3/" + dst + ".xml";
                var v = await GetHTML(l);
                ParseXML(v);

                dateTimeStart = dateTimeStart.AddDays(1);
            }



            //var hd = new HtmlAgilityPack.HtmlDocument();
            //hd.LoadHtml(h);
            //var n = hd.DocumentNode.SelectSingleNode("//*[@id='expectlist']");

            //foreach (var item in n.ChildNodes)
            //{
            //    if(item.NodeType==HtmlAgilityPack.HtmlNodeType.Element&&item.Name== "option")
            //    {
            //       var s= item.InnerText;

            //    }
            //}


        }

        public static void AnalysisHuBeiK3()
        {
            var f = "hbk3.txt".GetCommandLinePath();
            if (!File.Exists(f)) return;



            var t = "hbk3_analysis.txt".GetCommandLinePath();
            if (File.Exists(t))
            {
                File.Delete(t)
;
            }

            var ls = f.ReadAllText().Split('\n').Where(i => i.IsReadable()).Select(i => i.Trim()).OrderBy(i => i);

            var sumList = ls.Select(i => i.Split(new char[] { ' ' }, 2).Last().Split(',').Select(iv => int.Parse(iv)).Sum());

            t.AppendAllText(string.Format("# 湖北快3 2015年11月3日至2018年6月9日共 {0} 期开奖统计" + Environment.NewLine + Environment.NewLine, ls.Count().ToString()));
            var evenDictionary = new Dictionary<string, int>();
            var seqDictionary = new Dictionary<string, int>();
            var sumDictionary = new Dictionary<int, int>();

            evenDictionary.Add("大双", 0);
            evenDictionary.Add("小双", 0);
            evenDictionary.Add("大单", 0);
            evenDictionary.Add("小单", 0);
            seqDictionary.Add("三同号", 0);
            seqDictionary.Add("连号", 0);


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

                //if (type == "三同号")
                //{
                //    seqDictionary["三同号"] += 1;

                //}
                //else if (type == "连号")
                //{
                //    seqDictionary["连号"] += 1;
                //}
                if (sumDictionary.Keys.Contains(sum))
                {
                    sumDictionary[sum] += 1;
                }
                else
                {
                    sumDictionary.Add(sum, 1);

                }
            }



            var sb = new StringBuilder();

            foreach (var item in evenDictionary)
            {
                sb.AppendFormat("- {0}：开奖 {1} 次，{2}%" + Environment.NewLine, item.Key, item.Value, Math.Round((item.Value) / (double)ls.Count() * 100, 3));
            }

            sb.AppendFormat("- {0}：开奖 {1} 次，{2}%" + Environment.NewLine, "双", evenDictionary["大双"] + evenDictionary["小双"], Math.Round((evenDictionary["大双"] + evenDictionary["小双"]) / (double)ls.Count() * 100, 3));
            sb.AppendFormat("- {0}：开奖 {1} 次，{2}%" + Environment.NewLine, "单", evenDictionary["大单"] + evenDictionary["小单"], Math.Round((evenDictionary["大单"] + evenDictionary["小单"]) / (double)ls.Count() * 100, 3));
            sb.AppendFormat("- {0}：开奖 {1} 次，{2}%" + Environment.NewLine, "大", evenDictionary["大双"] + evenDictionary["大单"], Math.Round((evenDictionary["大双"] + evenDictionary["大单"]) / (double)ls.Count() * 100, 3));
            sb.AppendFormat("- {0}：开奖 {1} 次，{2}%" + Environment.NewLine, "小", evenDictionary["小单"] + evenDictionary["小双"], Math.Round((evenDictionary["小单"] + evenDictionary["小双"]) / (double)ls.Count() * 100, 3));
            sb.AppendLine();
            sb.AppendLine();



            sb.AppendLine().AppendLine("## 和值").AppendLine();

            sumDictionary = sumDictionary.OrderByDescending(i => i.Value).ThenBy(i => i.Key).ToDictionary(i => i.Key, i => i.Value);
            foreach (var item in sumDictionary)
            {
                sb.AppendFormat("- {0}：开奖 {1} 次，{2}%" + Environment.NewLine, item.Key, item.Value, Math.Round((item.Value) / (double)ls.Count() * 100, 3));
            }


            AnalysisSum(sumDictionary, sumList, sb);
            AnalysisHuBeiK3EvenBig(sumList, sb);
            AnalysisHuBeiK3EvenSmall(sumList, sb);

            AnalysisHuBeiK3OddBig(sumList, sb);
            AnalysisHuBeiK3OddSmall(sumList, sb);




            //foreach (var item in seqDictionary)
            //{
            //    sb.AppendFormat("{0}：开奖 {1} 次，{2}%" + Environment.NewLine, item.Key, item.Value, Math.Round((item.Value) / (double)ls.Count() * 100, 3));
            //}

            t.AppendAllText(sb.ToString());
        }
    }
}