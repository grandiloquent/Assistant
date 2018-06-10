using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpers
{


    static class Formatter
    {
        public static string FormatNginxConf(string value)
        {
            var sb = new StringBuilder();
            var count = 0;
            foreach (var item in value)
            {
                if (item == '{')
                {
                    sb.AppendLine("{");
                    count++;
                }
                else if (item == '}')
                {
                    sb.AppendLine('\t'.Repeat(count) + "}");

                    count--;
                }
                else
               if (item == ';')
                {
                    sb.AppendLine(";");
                    sb.Append('\t'.Repeat(count));
                }
                else if (item == '\r' || item == '\n' || item == '\t')
                {

                    continue;
                }
                else
                {
                    sb.Append(item);
                }

            }
            return sb.ToString();
        }
        public static string FormatBlockComment(string value)
        {
            var sb = new StringBuilder();
            var cacheSb = new StringBuilder();

            sb.Append("/*\r\n\r\n");
            foreach (var item in value.Split(new char[] { '\n' }))
            {
                if (item.IsReadable())
                {
                    foreach (var l in item.Split(' '))
                    {
                        if (l.IsReadable())
                        {

                            cacheSb.Append(l.Trim()).Append(' ');
                            if (cacheSb.Length > 50)
                            {
                                sb.Append(cacheSb).AppendLine();
                                cacheSb.Clear();
                            }
                        }
                    }
                    if (cacheSb.Length > 0)
                    {
                        sb.Append(cacheSb).AppendLine().AppendLine();
                        cacheSb.Clear();
                    }

                }
            }
            sb.Append("*/\r\n");
            return sb.ToString();
        }

        public static IEnumerable<string> FormatMethodList(string value)
        {
            var count = 0;
            var sb = new StringBuilder();
            var ls = new List<string>();
            for (int i = 0; i < value.Length; i++)
            {
                sb.Append(value[i]);

                if (value[i] == '{')
                {
                    count++;
                }
                else if (value[i] == '}')
                {
                    count--;
                    if (count == 0)
                    {
                        ls.Add(sb.ToString());
                        sb.Clear();
                    }
                }

            }
            //if (ls.Any())
            //{
            //    var firstLine = ls[0];
            //    ls.RemoveAt(0);
            //    ls.Add(firstLine.)

            //}
            return ls.Select(i => i.Split(new char[] { '{' }, 2).First().Trim() + ";").OrderBy(i => i.Trim());

        }

        public static string FormatStringBuilder(string value)
        {

            var sb = new StringBuilder();

            sb.AppendLine("var sb = new StringBuilder();");

            var ls = value.Split('\n').Where(i => i.IsReadable()).Select(i => i.Trim());

            foreach (var item in ls)
            {
                sb.AppendFormat("sb.AppendLine({0});\r\n", item.ToLiteral());
            }

            return sb.ToString();
        }
    }

}
