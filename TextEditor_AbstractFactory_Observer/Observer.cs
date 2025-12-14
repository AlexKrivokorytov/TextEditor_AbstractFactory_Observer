using System.Collections.Generic;

namespace TextEditor_AbstractFactory_Observer
{
    public interface ITextObserver
    {
        void Update(string oldText, string newText);
    }

    public class TextEditor
    {
        private string text = "";
        private List<ITextObserver> observers = new List<ITextObserver>();

        public void Attach(ITextObserver observer)
        {
            observers.Add(observer);
        }

        public void SetText(string newText)
        {
            string old = text;
            text = newText;

            foreach (var o in observers)
            {
                o.Update(old, newText);
            }
        }
    }
}
