using market_app.Second_Method;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace market_app.Third_method
{
    public partial class third_main_form : Form
    {
        public third_main_form()
        {
            InitializeComponent();
        }

        private void market_dbBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.market_dbBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.market_data);

        }

        private void third_main_form_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'market_data.market_db' table. You can move, or remove it, as needed.
            this.market_dbTableAdapter.Fill(this.market_data.market_db);

        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            //CODE FOR SHOW CHILD FORM
            market_app.Third_method.tm_child_form frm = new tm_child_form();

            //Int32 rc;
            //rc = this.market_data.market_db.Rows.Count;
            //if (rc == 0)
            //{
            //    MessageBox.Show("Please select your record to edit!");
            //    return;
            //}

           
            //--------COD FOR SELECTED ID and convert to int and to string
            Int32 i;
            Int32.TryParse(this.iDLabel1.Text, out i);
            frm.sel_id_lb.Text = i.ToString();

            frm.ShowDialog();
            frm.Dispose();
            //---------------------
        }
    }
}
