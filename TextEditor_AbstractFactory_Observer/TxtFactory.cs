using System.IO;

public class TxtLoader : FileLoader
{
    public override string Load(string path)
    {
        return File.ReadAllText(path);
    }
}

public class TxtSaver : FileSaver
{
    public TxtSaver(string text) : base(text) { }

    public override void Save(string path)
    {
        File.WriteAllText(path, Text);
    }
}

public class TxtFactory : IFileFactory
{
    public FileLoader CreateLoader() => new TxtLoader();
    public FileSaver CreateSaver(string text) => new TxtSaver(text);
}
