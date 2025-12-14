public interface IFileFactory
{
    FileLoader CreateLoader();
    FileSaver CreateSaver(string text);
}
