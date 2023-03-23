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

namespace market_app
{
    public partial class Main_form : Form
    {
        public Main_form()
        {
            InitializeComponent();
        }

      

        private void button1_Click_1(object sender, EventArgs e)
        {
            market_app.Forms.first_method fm = new Forms.first_method();
            fm.Show();
            fm.BringToFront();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            market_app.Second_Method.second_method_main sm = new second_method_main();
            sm.Show();
            sm.BringToFront();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            market_app.Third_method.third_main_form tm = new Third_method.third_main_form();
            tm.Show();
            tm.BringToFront();
        }
    }
}
