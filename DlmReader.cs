using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class DlmReader : Form
    {
        static string key = "649ae451ca33ec53bbcbcc33becf15f4";
        public DlmReader()
        {
            InitializeComponent();
        }

        public static void init()
        {
            Main.dlm.dataGridView1.Rows.Clear();
            BiM.Protocol.Tools.Dlm.DlmMap map = new BiM.Protocol.Tools.Dlm.DlmMap();
            BiM.Protocol.Tools.Dlm.DlmReader reader = new BiM.Protocol.Tools.Dlm.DlmReader(Main.openFile.FileName, key);
            map = reader.ReadMap();
            Main.dlm.Text = "Map ID: " + Convert.ToString(map.Id);
            foreach (BiM.Protocol.Tools.Dlm.DlmLayer layer in map.Layers)
            {
                foreach (BiM.Protocol.Tools.Dlm.DlmCell cell in layer.Cells)
                {
                    foreach (BiM.Protocol.Tools.Dlm.DlmGraphicalElement element in cell.Elements.OfType<BiM.Protocol.Tools.Dlm.DlmGraphicalElement>())
                    {
                        if (element.Identifier != 0 && Convert.ToString(element.Identifier) != "")
                             Main.dlm.dataGridView1.Rows.Add(element.Identifier, cell.Id);
                    }
                }
            }
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main.dlm.dataGridView1.Rows.Clear();
            Main.main.Visible = false;
            Main.main.Show();
            Main.main.Location = new Point(Main.dlm.Location.X + 5, Main.dlm.Location.Y + 5);
            Main.main.Visible = true;
            Main.main.Refresh();
            this.Hide();
        }
    }
}
