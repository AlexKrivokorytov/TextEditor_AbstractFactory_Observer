using System.IO;
using System.Windows.Forms;

namespace TextEditor_AbstractFactory_Observer
{
    public class ParagraphObserver : ITextObserver
    {
        public void Update(string oldText, string newText)
        {
            int oldP = oldText.Split('\n').Length;
            int newP = newText.Split('\n').Length;

            if (newP > oldP)
            {
                File.WriteAllText("autosave.txt", newText);
                MessageBox.Show("Дані у файлі оновлено (автозбереження)");
            }
        }
    }
}
