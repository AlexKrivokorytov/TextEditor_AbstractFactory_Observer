using System.IO;

public static class FileFactoryProvider
{
    public static IFileFactory GetFactory(string path)
    {
        switch (Path.GetExtension(path).ToLower())
        {
            case ".txt": return new TxtFactory();
            case ".bin": return new BinFactory();
            case ".html":
            case ".htm": return new HtmlFactory();
            default:
                throw new System.NotSupportedException("Unsupported format");
        }
    }
}
