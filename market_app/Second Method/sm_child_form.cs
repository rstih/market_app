using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace market_app.Second_Method
{
    public partial class sm_child_form : Form
    {
        public sm_child_form()
        {
            InitializeComponent();
        }

        private void market_dbBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.market_dbBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.market_data);

        }

        private void sm_child_form_Load(object sender, EventArgs e)
        {
            if (this.show_status_label.Text == "New Record")
            {
                this.market_dbBindingSource.AddNew();
                this.groupBox1.Enabled = true;
            }
            if (this.show_status_label.Text == "Edit Record")
            {
                this.groupBox1.Enabled = true;
                //----------Int64 is like LONG-------------------------
                Int64 i;
                Int64.TryParse(sel_id_lb.Text, out i);
                this.market_dbTableAdapter.FillBy_id(this.market_data.market_db, i);
            }
                //--------------------------------------------------
                if (this.show_status_label.Text == "Delete Record")
                {
                    this.groupBox1.Enabled = false;
                    //--------------------------------------
                    Int64 i;
                    Int64.TryParse(sel_id_lb.Text, out i);
                    this.market_dbTableAdapter.FillBy_id(this.market_data.market_db, i);
                }
        }

    

        private void save_btn_Click(object sender, EventArgs e)
        {
            //---------------CODE FOR DELETE BUTTON---------------
            if(show_status_label.Text== "Delete Record")
            {
                this.market_dbBindingSource.RemoveCurrent();
            }
            
            //All of this need to save to sql
            this.market_dbBindingSource.EndEdit();
            Int32 r;
            r = this.market_dbTableAdapter.Update(market_data.market_db);
            if (r > 0)
            {
                MessageBox.Show("Done! Count: " + r.ToString());
                //this.Close();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Nothing Saved" + r.ToString());
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
