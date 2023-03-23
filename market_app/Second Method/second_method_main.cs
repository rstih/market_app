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
    public partial class second_method_main : Form
    {
        public second_method_main()
        {
            InitializeComponent();
        }

        private void market_dbBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.market_dbBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.market_data);

        }

        private void second_method_main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'market_data.market_db' table. You can move, or remove it, as needed.
            this.market_dbTableAdapter.Fill(this.market_data.market_db);

        }

        private void add_btn_Click(object sender, EventArgs e)
        {
           //CODE FOR SHOW CHILD FORM
            market_app.Second_Method.sm_child_form smf = new sm_child_form();
            smf.show_status_label.Text = "New Record";
            smf.ShowDialog();
            smf.Dispose();
            //---------------------
            if(smf.DialogResult == DialogResult.OK)
            {
                this.market_dbTableAdapter.Fill(this.market_data.market_db);
            }
            
        }

        private void edit_btn_Click(object sender, EventArgs e)
        {
            Int32 rc;
            rc = this.market_data.market_db.Rows.Count;
            if(rc == 0)
            {
                MessageBox.Show("Please select your record to edit!");
                return;
            }
            
            //CODE FOR SHOW
            market_app.Second_Method.sm_child_form smf = new sm_child_form();
            //--------COD FOR SELECTED ID and convert to int and to string
            Int32 i;
            Int32.TryParse(this.iDLabel1.Text, out i);
            smf.sel_id_lb.Text = i.ToString();
            //-----------SHOW DIALOG--------------
            smf.show_status_label.Text = "Edit Record";
            smf.ShowDialog();
            smf.Dispose();
            //------------FOR LOADING DATA AGAIN IN SECOND METHOD FORM
            if (smf.DialogResult == DialogResult.OK)
            {
                this.market_dbTableAdapter.Fill(this.market_data.market_db);
            }
        }

        private void del_btn_Click(object sender, EventArgs e)
        {
            //CODE FOR SHOW CHILD FORM
            market_app.Second_Method.sm_child_form smf = new sm_child_form();
            //--------COD FOR SELECTED ID and convert to int and to string
            Int32 i;
            Int32.TryParse(this.iDLabel1.Text, out i);
            smf.sel_id_lb.Text = i.ToString();
            //--------COD FOR SELECTED ID
            smf.show_status_label.Text = "Delete Record";
            smf.ShowDialog();
            smf.Dispose();
            //------------------------------
            if (smf.DialogResult == DialogResult.OK)
            {
                this.market_dbTableAdapter.Fill(this.market_data.market_db);
            }
            //-------------------------
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
