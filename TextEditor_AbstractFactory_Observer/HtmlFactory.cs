using System.IO;
using System.Linq;
using HtmlAgilityPack;

public class HtmlLoader : FileLoader
{
    public override string Load(string path)
    {
        var doc = new HtmlDocument();
        doc.Load(path);

        var nodes = doc.DocumentNode.SelectNodes("//p|//br");
        if (nodes == null) return "";

        return string.Join(
            System.Environment.NewLine,
            nodes.Select(n => n.InnerText.Trim())
        );
    }
}

public class HtmlSaver : FileSaver
{
    public HtmlSaver(string text) : base(text) { }

    public override void Save(string path)
    {
        var lines = Text.Split('\n');

        string html = "<html><body>\n";
        foreach (var l in lines)
            html += $"<p>{System.Net.WebUtility.HtmlEncode(l)}</p>\n";
        html += "</body></html>";

        File.WriteAllText(path, html);
    }
}

public class HtmlFactory : IFileFactory
{
    public FileLoader CreateLoader() => new HtmlLoader();
    public FileSaver CreateSaver(string text) => new HtmlSaver(text);
}
