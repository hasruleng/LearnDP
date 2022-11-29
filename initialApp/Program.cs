﻿// Console.WriteLine("Hello, World!");

using System.Text;
using System.Text.RegularExpressions;
 
try
{
    Console.WriteLine("Please specify the file to convert to HTML.");
    var fullFilePath = Console.ReadLine() ?? string.Empty;
    var inputText = ReadAllText(fullFilePath);
    var paragraphs = Regex.Split(inputText, @"(\r\n?|\n)")
                          .Where(p => p.Any(char.IsLetterOrDigit));
    var sb = new StringBuilder();
 
    foreach (var paragraph in paragraphs)
    {
        if (paragraph.Length == 0)
            continue;
 
        sb.AppendLine($"<p>{paragraph}</p>");
    }
 
    sb.AppendLine("<br/>");
    WriteToFile(fullFilePath, sb.ToString());
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
Console.WriteLine("Press any key to exit");
Console.ReadKey();
 
string ReadAllText(string fullFilePath)
{
    return System.Web.HttpUtility.HtmlEncode(File.ReadAllText(fullFilePath));
}
 
void WriteToFile(string fullFilePath, string text)
{
    var outputFilePath = //Path.GetDirectoryName(fullFilePath) + Path.DirectorySeparatorChar +
        Path.GetFileNameWithoutExtension(fullFilePath) + ".html";
    using StreamWriter file =
    new(outputFilePath);
    file.Write(text);
}