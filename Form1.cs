using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Table
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void butGenerate_Click(object sender, EventArgs e)
        {
            if (tbxNumber.Text == "")
            {
                Control ctrl = (Control)tbxNumber;
                ctrl.BackColor = Color.LightPink;
                MessageBox.Show("Please enter the number to generate table", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbxNumber.Focus();
            }
            else if (tbxRange.Text == "")
            {
                Control ctrl = (Control)tbxRange;
                ctrl.BackColor = Color.LightPink;
                MessageBox.Show("Please enter the range to generate table", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbxRange.Focus();
            }
            else
            {
                double num = 0;
                long range = 0;
                try
                {
                    num = Convert.ToDouble(tbxNumber.Text);
                    range = Convert.ToInt64(tbxRange.Text);
                }
                catch (FormatException)
                {
                    Control ctrl = (Control)tbxNumber;
                    ctrl.BackColor = Color.LightPink;
                    MessageBox.Show("Please enter the number in correct formate to generate table", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbxNumber.Focus();
                }
                catch (OverflowException)
                {
                    MessageBox.Show("The entered data is out of the limit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbxNumber.Clear();
                    tbxRange.Clear();
                    tbxNumber.Focus();
                }              
                if (num == 0 ||range==0)
                    return;
                for(long i=0; i<= range; i++)
                {
                    listBox1.Items.Add(num + "   x   " + i + "   =   " + num * i);
                }
                
            }
        }

        private void butClear_Click(object sender, EventArgs e)
        {
            tbxNumber.Clear();
            tbxRange.Clear();
            listBox1.Items.Clear();
            tbxNumber.Focus();
        }

        private void tbxNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar!=46))
                e.Handled = true;               
        }

        private void tbxRange_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tbxNumber_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            ctrl.BackColor = Color.White;
        }

        private void tbxNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, false, true);
            }
        }
    }
}
