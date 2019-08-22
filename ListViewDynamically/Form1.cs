using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListViewDynamically
{
    public partial class Form1 : Form
    {
        ListView lv;
        TextBox eredmenyTextBox;

        public Form1()
        {
            InitializeComponent();
            lv = new ListView();
            lv.View = View.Details;
            lv.Location = new Point(12, 12);
            lv.Name = "Kategória lista";
            lv.Size = new Size(600, 480);
            lv.FullRowSelect = true;

            this.Size = new Size(1024, 768);

            lv.Columns.Add("Név");
            lv.Columns.Add("Típus");
            lv.Columns.Add("Életkor");
            lv.Columns[0].Width = 320;
            lv.Columns[1].Width = 180;
            lv.Columns[2].Width = 140;

            ListViewItem lvi = new ListViewItem("Pet");
            //lvi.Text = "Pet";
            lvi.SubItems.Add("kutya");
            lvi.SubItems.Add("9");
            lv.Items.Add(lvi);

            ListViewItem lvi2 = new ListViewItem(new string[] { "Buksi", "kutya", "11" });
            lv.Items.Add(lvi2);

            lv.GridLines = true;

            eredmenyTextBox = new TextBox();
            eredmenyTextBox.Location = new Point(12, 600);
            eredmenyTextBox.Size = new Size(600,12);
            Controls.Add(eredmenyTextBox);

            Controls.Add(lv);

            lv.SelectedIndexChanged += Lv_SelectedIndexChanged;
        }

        private void Lv_SelectedIndexChanged(object sender, EventArgs e)
        {
            StringBuilder eredmeny = new StringBuilder();
            if (lv.SelectedItems.Count == 0)
                return;
            eredmeny.Append(lv.SelectedItems[0].Text);
            eredmeny.Append(" ");
            eredmeny.Append(lv.SelectedItems[0].SubItems[1].Text);
            eredmeny.Append(" ");
            eredmeny.Append(lv.SelectedItems[0].SubItems[2].Text);
            eredmenyTextBox.Text = eredmeny.ToString();
        }
    }
}
