﻿using System;
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

            Controls.Add(lv);
        }
    }
}
