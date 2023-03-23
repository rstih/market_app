﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace market_app.Forms
{
    public partial class first_method : Form
    {
        public first_method()
        {
            InitializeComponent();
        }

        private void first_method_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'market_data.market_db' table. You can move, or remove it, as needed.
            this.save_btn.Enabled = false;
            this.cancel_btn.Enabled = false;
            //-----------------------------
            this.groupBox1.Enabled = false;
            //---------------------------
            this.DGV.Enabled = true;
            this.binding_nav.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.market_dbTableAdapter.Fill(this.market_data.market_db);
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            add_edit_delete_Controler();
            this.market_dbBindingSource.AddNew();
        }

        private void edit_btn_Click(object sender, EventArgs e)
        {
            // CODE FOR ERRORS -ako nije loadana baza prije
            Int32 rc;
            rc = this.market_data.market_db.Rows.Count;
            if(rc==0)
            {
                MessageBox.Show("Please load and select your record to edit!");
                return;
            }

            add_edit_delete_Controler();
        }

        private void del_btn_Click(object sender, EventArgs e)
        {
            // CODE FOR ERRORS -ako nije loadana baza prije
            Int32 rc;
            rc = this.market_data.market_db.Rows.Count;
            if (rc == 0)
            {
                MessageBox.Show("Please load and select your record to delete!");
                return;
            }
            //------------------
            add_edit_delete_Controler();
            this.market_dbBindingSource.RemoveCurrent();
            //------------------------
            this.groupBox1.Enabled = false;
        }

        void add_edit_delete_Controler()
        {
            this.add_btn.Enabled = false;
            this.edit_btn.Enabled = false;
            this.del_btn.Enabled = false;
            //--------------------------
            this.save_btn.Enabled = true;
            this.cancel_btn.Enabled = true;
            //---------------------------
            this.groupBox1.Enabled = true;
            //---------------------------
            this.DGV.Enabled = false;
            this.binding_nav.Enabled = false;
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            save_cancel_Controler();
            //All of this need to save to sql
            this.market_dbBindingSource.EndEdit();
            Int32 r;
            r = this.market_dbTableAdapter.Update(market_data.market_db);
            if (r > 0)
            {
                MessageBox.Show("Done! Count: " + r.ToString());
            }
            else
            {
                MessageBox.Show("Nothing Saved" + r.ToString());
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            save_cancel_Controler();
            this.market_dbBindingSource.CancelEdit();
            this.market_data.market_db.RejectChanges();
        }

        void save_cancel_Controler()
        {
            this.save_btn.Enabled=false;
            this.cancel_btn.Enabled = false;
            //-----------------------------
            this.add_btn.Enabled = true;
            this.edit_btn.Enabled = true;
            this.del_btn.Enabled = true;
            //----------------------------
            this.groupBox1.Enabled = false;
            //---------------------------
            this.DGV.Enabled = true;
            this.binding_nav.Enabled = true;
        }
    }
}
