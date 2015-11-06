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
            
            var files = FileRetrieval(InputPath);
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            FileInfo file = filesDropDown.SelectedItem as FileInfo;
            
            File.Copy(InputPath + "\\" + file.Name, RootPath + "\\input.ini", true);
            //System.Diagnostics.Process.Start(@InputPath + "\\" + file.Name.ToString());
            //FileStream fileStream = new FileStream(@InputPath + "\\" + file.Name.ToString(), FileMode.Open, FileAccess.ReadWrite);
            
            //string[] lines = File.ReadAllLines(InputPath + "\\" + file.Name.ToString());
        }
    }
}
