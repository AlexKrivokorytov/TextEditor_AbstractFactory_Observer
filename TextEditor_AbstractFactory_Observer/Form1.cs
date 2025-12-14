using System;
using System.IO;
using System.Windows.Forms;

namespace TextEditor_AbstractFactory_Observer
{
    public partial class Form1 : Form
    {
        private TextBox sourceTextBox;
        private TextBox fileNameTextBox;
        private OpenFileDialog openFileDialog;
        private MenuStrip menuStrip;

        public Form1()
        {
            InitializeComponent();
            InitializeCustomUI();
        }

        private void InitializeCustomUI()
        {
            this.Text = "Text Editor (Abstract Factory)";
            this.Width = 800;
            this.Height = 600;

            // ===== MENU =====
            menuStrip = new MenuStrip();
            var fileMenu = new ToolStripMenuItem("File");
            var openItem = new ToolStripMenuItem("Open");

            openItem.Click += OpenFile_Click;

            fileMenu.DropDownItems.Add(openItem);
            menuStrip.Items.Add(fileMenu);

            this.Controls.Add(menuStrip);
            this.MainMenuStrip = menuStrip;

            // ===== FILE NAME =====
            fileNameTextBox = new TextBox
            {
                Left = 10,
                Top = 30,
                Width = 760,
                ReadOnly = true
            };

            // ===== TEXT AREA =====
            sourceTextBox = new TextBox
            {
                Left = 10,
                Top = 60,
                Width = 760,
                Height = 480,
                Multiline = true,
                ScrollBars = ScrollBars.Both
            };

            this.Controls.Add(fileNameTextBox);
            this.Controls.Add(sourceTextBox);

            // ===== FILE DIALOG =====
            openFileDialog = new OpenFileDialog
            {
                Filter = "Supported files|*.txt;*.html;*.htm;*.bin|Text|*.txt|HTML|*.html;*.htm|Binary|*.bin"
            };
        }

        // ===== ABSTRACT FACTORY USAGE =====
        private void OpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;

                var factory = FileFactoryProvider.GetFactory(path);
                var loader = factory.CreateLoader();

                sourceTextBox.Text = loader.Load(path);
                fileNameTextBox.Text = Path.GetFileName(path);
            }
        }
    }
}
