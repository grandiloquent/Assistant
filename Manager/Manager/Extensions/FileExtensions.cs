using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Reflection;

namespace Helpers
{
    static class FileExtensions
    {

        public static readonly char DirectorySeparatorChar = '\\';
        public static readonly char AltDirectorySeparatorChar = '/';
        public static readonly char VolumeSeparatorChar = ':';
        private static readonly char[] InvalidFileNameChars = {
            '\"',
            '<',
            '>',
            '|',
            '\0',
            (Char)1,
            (Char)2,
            (Char)3,
            (Char)4,
            (Char)5,
            (Char)6,
            (Char)7,
            (Char)8,
            (Char)9,
            (Char)10,
            (Char)11,
            (Char)12,
            (Char)13,
            (Char)14,
            (Char)15,
            (Char)16,
            (Char)17,
            (Char)18,
            (Char)19,
            (Char)20,
            (Char)21,
            (Char)22,
            (Char)23,
            (Char)24,
            (Char)25,
            (Char)26,
            (Char)27,
            (Char)28,
            (Char)29,
            (Char)30,
            (Char)31,
            ':',
            '*',
            '?',
            '\\',
            '/'
        };
        internal static readonly char[] InvalidPathChars = {
            '\"', '<', '>', '|', '\0',
            (char)1, (char)2, (char)3, (char)4, (char)5, (char)6, (char)7, (char)8, (char)9, (char)10,
            (char)11, (char)12, (char)13, (char)14, (char)15, (char)16, (char)17, (char)18, (char)19, (char)20,
            (char)21, (char)22, (char)23, (char)24, (char)25, (char)26, (char)27, (char)28, (char)29, (char)30,
            (char)31
        };

        public static void AppendAllText(this String path, String contents)
        {
            using (var sw = new StreamWriter(path, true, new UTF8Encoding(false)))
                sw.Write(contents);
        }
        internal static bool AnyPathHasWildCardCharacters(string path, int startIndex = 0)
        {
            char currentChar;
            for (int i = startIndex; i < path.Length; i++)
            {
                currentChar = path[i];
                if (currentChar == '*' || currentChar == '?')
                    return true;
            }
            return false;
        }

        internal static bool AnyPathHasIllegalCharacters(string path, bool checkAdditional = false)
        {
            return path.IndexOfAny(InvalidPathChars) >= 0 || (checkAdditional && AnyPathHasWildCardCharacters(path));
        }



        public static void CreateDirectoryFromFilePath(this string filename)
        {
            var dir = Path.GetDirectoryName(filename);
            if (!string.IsNullOrWhiteSpace(dir)&&!Directory.Exists(dir))
                Directory.CreateDirectory(Path.GetDirectoryName(filename));
        }


        public static String GetExtension(this String path)
        {
            if (path == null)
                return null;

            int length = path.Length;
            for (int i = length; --i >= 0;)
            {
                char ch = path[i];
                if (ch == '.')
                {
                    if (i != length - 1)
                        return path.Substring(i, length - i);
                    else
                        return String.Empty;
                }
                if (ch == DirectorySeparatorChar || ch == AltDirectorySeparatorChar || ch == VolumeSeparatorChar)
                    break;
            }
            return String.Empty;
        }
        public static String ChangeExtension(this String path, String extension)
        {
            if (path != null)
            {

                String s = path;
                for (int i = path.Length; --i >= 0;)
                {
                    char ch = path[i];
                    if (ch == '.')
                    {
                        s = path.Substring(0, i);
                        break;
                    }
                    if (ch == DirectorySeparatorChar || ch == AltDirectorySeparatorChar || ch == VolumeSeparatorChar)
                        break;
                }
                if (extension != null && path.Length != 0)
                {
                    if (extension.Length == 0 || extension[0] != '.')
                    {
                        s = s + ".";
                    }
                    s = s + extension;
                }
                return s;
            }
            return null;
        }
        public static String ChangeParentName(this String path, String parentName)
        {
            var p = Path.Combine(path.GetDirectoryName(), parentName);
            p.CreateDirectory();

            return Path.Combine(p, path.GetFileName());
        }
        public static String ChangeFileName(this String path, String p)
        {


            return Path.Combine(path.GetDirectoryName(), path.GetFileNameWithoutExtension() + p + path.GetExtension());
        }
        public static String GetFileName(this String path)
        {
            if (path != null)
            {


                int length = path.Length;
                for (int i = length; --i >= 0;)
                {
                    char ch = path[i];
                    if (ch == DirectorySeparatorChar || ch == AltDirectorySeparatorChar || ch == VolumeSeparatorChar)
                        return path.Substring(i + 1, length - i - 1);

                }
            }
            return path;
        }

        public static IEnumerable<string> ReadAllLines(this string p)
        {

            String line;


            using (StreamReader sr = new StreamReader(p, new UTF8Encoding(false)))
                while ((line = sr.ReadLine()) != null)
                    yield return line;


        }
        public static String ReadAllText(this String path)
        {
            // https://referencesource.microsoft.com/#mscorlib/system/io/file.cs,8a84c56a62fd8d45
            using (StreamReader sr = new StreamReader(path, new UTF8Encoding(false), true, 1024))
                return sr.ReadToEnd();
        }
        public static void WriteAllText(this String path, String contents)
        {
            using (StreamWriter sw = new StreamWriter(path, false, new UTF8Encoding(false), 1024))
                sw.Write(contents);
        }
        public static String GetFileNameWithoutExtension(this String path)
        {
            path = GetFileName(path);
            if (path != null)
            {
                int i;
                if ((i = path.LastIndexOf('.')) == -1)
                    return path; // No path extension found
                else
                    return path.Substring(0, i);
            }
            return null;
        }

        public static string GetDirectoryName(this string p)
        {
            return Path.GetDirectoryName(p);
        }

        public static void CreateDirectory(this string p)
        {
            if (!Directory.Exists(p))
            {
                Directory.CreateDirectory(p);
            }
        }


        public static string GetDesktopPath(this string p)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), p);
        }

        public static IEnumerable<string> GetFiles(this string p, string filter = "\\.(?:jpg|jpeg)$")
        {

            return Directory.GetFiles(p).Where(i => Regex.IsMatch(i, filter, RegexOptions.IgnoreCase));
        }

        public static bool IsJPGFile(this string p)
        {
            return Regex.IsMatch(p, "\\.(?:jpg|jpeg)", RegexOptions.IgnoreCase);
        }


        public static string GetCommandLinePath(this string p)
        {


            return Path.Combine(Assembly.GetEntryAssembly().Location.GetDirectoryName(), p);
        }
    }
}
