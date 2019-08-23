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
        TextBox atlagTextBox;

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
            ListViewItem lvi3 = new ListViewItem(new string[] { "Mirmur", "macska", "6" });
            lv.Items.Add(lvi2);
            lv.Items.Add(lvi3);

            lv.GridLines = true;

            eredmenyTextBox = new TextBox();
            eredmenyTextBox.Location = new Point(12, 600);
            eredmenyTextBox.Size = new Size(400,12);
            Controls.Add(eredmenyTextBox);

            atlagTextBox = new TextBox();
            atlagTextBox.Location = new Point(450, 600);
            atlagTextBox.Size = new Size(150, 12);
            atlagTextBox.ReadOnly = true;
            Controls.Add(atlagTextBox);

            Button szamolAtlag = new Button();
            szamolAtlag.Location = new Point(620, 600);
            szamolAtlag.Size = new Size(150, 24);
            szamolAtlag.Text = "Számol életkor átlagot...";
            szamolAtlag.Click += SzamolAtlag_Click;
            Controls.Add(szamolAtlag);

            Button torolSor = new Button();
            torolSor.Location = new Point(620, 630);
            torolSor.Size = new Size(150, 24);
            torolSor.Text = "Töröl sort...";
            torolSor.Click += TorolSor_Click;
            Controls.Add(torolSor);

            Controls.Add(lv);

            lv.SelectedIndexChanged += Lv_SelectedIndexChanged;
        }

        private void TorolSor_Click(object sender, EventArgs e)
        {
            if (lv.SelectedItems.Count == 0)
                return;
            foreach (ListViewItem listViewItem in lv.SelectedItems)
            {
                lv.Items.Remove(listViewItem);
            }
        }

        private void SzamolAtlag_Click(object sender, EventArgs e)
        {
            double szum = 0;
            if (lv.SelectedItems.Count == 0)
            {
                atlagTextBox.Text = szum.ToString();
                return;
            }
            foreach (ListViewItem lvi in lv.Items)
            {
                szum += Convert.ToDouble(lvi.SubItems[2].Text);
            }
            double atlag = szum / lv.Items.Count;
            atlagTextBox.Text = atlag.ToString();
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
