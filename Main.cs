using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BiM.Behaviors;
//paste       Main.openFile.FileOk += new System.ComponentModel.CancelEventHandler(this.openFile_FileOk);
//above       this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//paste       Main.openFile = new System.Windows.Forms.OpenFileDialog();
//above       this.SuspendLayout();
namespace WindowsFormsApplication1
{
    public partial class Main : Form
    {
        public static OpenFileDialog openFile = new OpenFileDialog();
        public static Main main = new Main();
        public static DlmReader dlm = new DlmReader();

        
        public Main()
        {
            InitializeComponent();
            openFile.FileName = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            main.Location = new Point(this.Location.X, this.Location.Y);
            openFile.ShowDialog();
        }

        public void openFile_FileOk(object sender, CancelEventArgs e)
        {
            if (openFile.CheckFileExists == true & openFile.FileName.Contains(".dlm"))
            {
                dlm.Visible = false;
                dlm.Show();
                dlm.Location = new Point(main.Location.X - 5, main.Location.Y - 5);
                Main.dlm.Visible = true;
                Main.dlm.Refresh();
                this.Hide();
                main.Hide();
                DlmReader.init();
            }
        }
    }
}
