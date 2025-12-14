using System.IO;

public abstract class FileLoader
{
    public abstract string Load(string path);
}

public abstract class FileSaver
{
    protected string Text;

    protected FileSaver(string text)
    {
        Text = text;
    }

    public abstract void Save(string path);
}
