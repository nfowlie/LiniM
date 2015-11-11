using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace League_Input_Changer
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public DirectoryInfo RootPath = new DirectoryInfo("C:\\Riot Games\\League of Legends\\Config");
        public DirectoryInfo InputPath = new DirectoryInfo("C:\\Riot Games\\League of Legends\\Config\\input");

        public FileInfo[] FileRetrieval(DirectoryInfo input)
        {
            FileInfo[] files = input.GetFiles();
            filesDropDown.DataSource = files;

            return files;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if(!InputPath.Exists){
                InputPath.Create();
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            FileInfo file = filesDropDown.SelectedItem as FileInfo;
            
            File.Copy(InputPath + "\\" + file.Name, RootPath + "\\input.ini", true);
            //System.Diagnostics.Process.Start(@InputPath + "\\" + file.Name.ToString());
            //FileStream fileStream = new FileStream(@InputPath + "\\" + file.Name.ToString(), FileMode.Open, FileAccess.ReadWrite);
            
            //string[] lines = File.ReadAllLines(InputPath + "\\" + file.Name.ToString());
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            string newFile = Prompt.ExportDialog("Name: ", "Input File Name");
            if (File.Exists(RootPath + "\\input.ini"))
            {
                File.Copy(RootPath + "\\input.ini", InputPath + "\\" + newFile + ".ini", true);
            }
            else {
                File.Create(InputPath + newFile + ".ini");
            }

            FileRetrieval(InputPath);
        }
    }
    public static class Prompt{
        public static string ExportDialog(string text, string caption)
        {
            Form prompt = new Form();
            prompt.Width = 300;
            prompt.Height = 180;
            prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
            prompt.Text = caption;
            prompt.StartPosition = FormStartPosition.CenterParent;

            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 200 };
            Button confirmation = new Button() { Text = "Ok", Left = 180, Width = 100, Top = 80, Height = 30, DialogResult = DialogResult.OK };

            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
