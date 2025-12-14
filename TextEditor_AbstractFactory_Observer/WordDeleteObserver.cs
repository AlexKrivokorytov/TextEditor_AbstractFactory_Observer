using System.Windows.Forms;

namespace TextEditor_AbstractFactory_Observer
{
    public class WordDeleteObserver : ITextObserver
    {
        public void Update(string oldText, string newText)
        {
            int oldWords = oldText.Split(' ', '\n', '\t').Length;
            int newWords = newText.Split(' ', '\n', '\t').Length;

            int deleted = oldWords - newWords;

            if (deleted > 1)
            {
                MessageBox.Show(
                    $"Видалено слів: {deleted}",
                    "Observer"
                );
            }
        }
    }
}
