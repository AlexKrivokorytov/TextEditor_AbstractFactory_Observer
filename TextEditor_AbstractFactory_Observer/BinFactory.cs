using System.IO;
using System.Text;

public class BinLoader : FileLoader
{
    public override string Load(string path)
    {
        byte[] data = File.ReadAllBytes(path);
        return Encoding.UTF8.GetString(data);
    }
}

public class BinSaver : FileSaver
{
    public BinSaver(string text) : base(text) { }

    public override void Save(string path)
    {
        File.WriteAllBytes(path, Encoding.UTF8.GetBytes(Text));
    }
}

public class BinFactory : IFileFactory
{
    public FileLoader CreateLoader() => new BinLoader();
    public FileSaver CreateSaver(string text) => new BinSaver(text);
}
