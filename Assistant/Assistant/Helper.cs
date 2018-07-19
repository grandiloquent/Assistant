using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using Helpers;
using System.Windows.Forms;
using Markdig;

namespace Assistant
{
    class Helper
    {

        public static string ConvertMarkdownToHtml(string s)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html> <html lang=en> <head> <meta charset=utf-8> <meta content=\"IE=edge\" http-equiv=X-UA-Compatible> <meta content=\"width=device-width,initial-scale=1\" name=viewport><link href=\"style.css\" rel=\"stylesheet\"></head><body>");

            var p = new MarkdownPipelineBuilder();

            sb.AppendLine(Markdown.ToHtml(s, p.UseAutoLinks().UseGridTables().UsePipeTables().Build()));

            sb.AppendLine("</body></html>");

            return sb.ToString();
        }
        public static void OnClipboardDirectory(Action<string> action)
        {
            try
            {
                var dir = Clipboard.GetText().Trim();
                if (Directory.Exists(dir)) action(dir);
                else
                {
                    var fileList = Clipboard.GetFileDropList();
                    if (fileList.Count > 0)
                    {
                        dir = fileList[0];
                        if (Directory.Exists(dir)) action(dir);
                    }
                }
            }
            catch (Exception e)
            {

            }
        }

        public static void OnClipboardString(Func<string, string> action)
        {
            try
            {
                var v = Clipboard.GetText().Trim();
                if (string.IsNullOrWhiteSpace(v)) return;
                v = action(v);
                if (!string.IsNullOrWhiteSpace(v))
                    Clipboard.SetText(v);
            }
            catch (Exception e)
            {

            }
        }
        public static string GenerateDirectoriesList(string dir)
        {
            return string.Join(Environment.NewLine, Directory.GetDirectories(dir));
        }
        public static string SummaryDrawable(string dir)
        {
            var files = Directory.GetFiles(dir, "*", SearchOption.AllDirectories).Where(i => Regex.IsMatch(i, "\\.(?:xml|kt|java)$")).ToArray();
            var stringList = new List<string>();

            foreach (var item in files)
            {

                var items = Regex.Matches(item.ReadAllText(), "(\\@drawable/([a-zA-Z0-9\\-_]+))|(R\\.drawable\\.([a-zA-Z0-9\\-_]+))").Cast<Match>().Select((v) =>
                {
                    if (v.Groups[2].Length > 0)
                        return v.Groups[2].Value;
                    else
                        return v.Groups[4].Value;
                });
                stringList.AddRange(items.Distinct());

            }

            var sb = new StringBuilder();
            sb.Append(string.Join(Environment.NewLine, stringList.Distinct().OrderBy(i => i)));
            return sb.ToString();
        }
        public static string FormatJavaFieldToKotlin(string value)
        {
            var ls = value.Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries).Where(i => !string.IsNullOrWhiteSpace(i));
            var strings = new List<string>();
            var declareStrings = new List<string>();

            foreach (var item in ls)
            {
                var splited = item.Split('=').First().Trim().Split(' ');
                var type = splited[splited.Length - 2];
                type = type[0].ToString().ToUpper() + type.Substring(1);
                var declare = splited.Last().TrimEnd(';');
                if (declare[0] == 'm')
                {
                    declare = declare.Substring(1);
                }
                declare = declare[0].ToString().ToLower() + declare.Substring(1);
                strings.Add($"var {declare}:{type}?=null");
                declareStrings.Add($"var {declare}:{type}?=null \n private set");

            }
            return string.Join(",\n", strings.OrderBy(i => i)) + Environment.NewLine + Environment.NewLine + string.Join("\n", declareStrings.OrderBy(i => i));
        }
        public static string FormatCSharpConstFieldToKotlin(string value)
        {
            var ls = value.Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries).Where(i => !string.IsNullOrWhiteSpace(i));
            var strings = new List<string>();

            foreach (var item in ls)
            {

                var declare = item.Split('=').First().Trim().Split(' ').Last();
                var sb = new StringBuilder();

                for (int i = 0; i < declare.Length; i++)
                {
                    if (char.IsUpper(declare[i]))
                    {
                        if (i != 0)
                        {
                            sb.Append('_');
                        }
                    }

                    sb.Append(char.ToUpper(declare[i]));
                }
                var v = item.Split('=').Last().Trim().TrimEnd(';');


                strings.Add($"const val CONST_{sb.ToString()}={v}");

            }
            return string.Join("\n", strings.OrderBy(i => i));
        }

        public static string FormatJavaConstFieldToKotlin(string value)
        {
            var ls = Regex.Matches(value, "(?<=private|public)([^\\=\n\r]*?)\\=([^;]*?);").Cast<Match>().ToList();
            var strings = new List<string>();

            foreach (var item in ls)
            {
                var name = item.Groups[1].Value.TrimEnd().Split(' ').Last();
                var v = item.Groups[2].Value;
                strings.Add($"const val {name}={v}");
            }
            return string.Join("\n", strings.OrderBy(i => i));
        }
    }
}
