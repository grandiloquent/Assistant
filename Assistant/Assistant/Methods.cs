using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ionic.Zip;
using System.IO;
using Helpers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
// Install-Package Ionic.Zip -Version 1.9.1.8

namespace Assistant
{
    static class Methods
    {
        public static void CompressDirectory(this string path)
        {
            using (var zip = new ZipFile(Encoding.GetEncoding("gb2312")))
            {
                zip.AddDirectory( path,"");
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                var fileName = path + ".zip";
                if (File.Exists(fileName))
                {

                    fileName = Path.Combine(path, $"{path.GetFileName()}-{new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds()}.zip");
                }
                zip.Save(fileName);
            }
        }
        public static void CompressFile(this string path)
        {
            using (var zip = new ZipFile(Encoding.GetEncoding("gb2312")))
            {
                zip.AddFile(path, "");
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                var fileName = path + ".zip";
                if (File.Exists(fileName))
                {

                    fileName = Path.Combine(path, $"{path.GetFileName()}-{new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds()}.zip");
                }
                zip.Save(fileName);
            }
        }

        public static void UnCompressFile(this string path)
        {
            using (var zip=new ZipFile(path,Encoding.GetEncoding("gb2312")))
            {
                zip.ExtractAll(Path.Combine(path.GetDirectoryName(),path.GetFileNameWithoutExtension()));
            }
        }
        public static string FormatCSharpCode(string value)
        {

            var s = new StringBuilder();

            var rootNode = CSharpSyntaxTree.ParseText(value).GetRoot();

            var namespace_ = rootNode.DescendantNodes().OfType<NamespaceDeclarationSyntax>();

            if (namespace_.Any())
            {

                s.Append(namespace_.First().NamespaceKeyword.Text).Append(' ').Append(namespace_.First().Name).Append('{');
            }

            var using_ = rootNode.DescendantNodes().OfType<UsingDirectiveSyntax>();
            if (using_.Any())
            {

                using_ = using_.OrderBy(i => i.Name.ToString());//.Distinct(i => i.Name.GetText());

                foreach (var item in using_)
                {
                    s.Append(item.ToFullString());
                }
            }
            var enum_ = rootNode.DescendantNodes().OfType<EnumDeclarationSyntax>();
            if (enum_.Any())
            {
                foreach (var item in enum_)
                {
                    enum_ = enum_.OrderBy(i => i.Identifier.ToFullString());
                    s.Append(item.ToFullString());
                }
            }
            var struct_ = rootNode.DescendantNodes().OfType<StructDeclarationSyntax>();
            if (struct_.Any())
            {
                foreach (var item in struct_)
                {
                    struct_ = struct_.OrderBy(i => i.Identifier.ToFullString());
                    s.Append(item.ToFullString());
                }
            }
            var class_ = rootNode.DescendantNodes().OfType<ClassDeclarationSyntax>();

            if (class_.Any())
            {
                class_ = class_.OrderBy(i => i.Identifier.ValueText);

                foreach (var item in class_)
                {
                    s.Append(item.Modifiers.ToFullString()).Append(" class ").Append(item.Identifier.ValueText).Append('{');
                    var field_ = item.DescendantNodes().OfType<FieldDeclarationSyntax>();
                    if (field_.Any())
                    {
                        field_ = field_.OrderBy(i => i.Declaration.Variables.First().ToFullString());

                        foreach (var itemField in field_)
                        {

                            s.Append(itemField.ToFullString().Trim() + '\n');
                        }
                    }

                    var constructor_ = item.DescendantNodes().OfType<ConstructorDeclarationSyntax>();
                    if (constructor_.Any())
                    {
                        constructor_ = constructor_.OrderBy(i => i.Identifier.ValueText);//.OrderBy(i => i.Identifier.ValueText).ThenBy(i=>i.Modifiers.ToFullString());
                        foreach (var itemMethod in constructor_)
                        {


                            s.Append(itemMethod.ToFullString());
                        }

                    }
                    var method_ = item.DescendantNodes().OfType<MethodDeclarationSyntax>();

                    if (method_.Any())
                    {
                        method_ = method_.OrderBy(i => i.Modifiers.ToFullString().Trim() + i.Identifier.ValueText.Trim());//.OrderBy(i => i.Identifier.ValueText).ThenBy(i=>i.Modifiers.ToFullString());
                        foreach (var itemMethod in method_)
                        {


                            s.Append(itemMethod.ToFullString());
                        }

                    }
                    s.Append('}');
                }

            }
            s.Append('}');
            return s.ToString();

        }

    }

    class Logger
    {
        

        public Logger()
        {

        }
        public static void WriteException(Exception exception)
        {

        }
    }
}
