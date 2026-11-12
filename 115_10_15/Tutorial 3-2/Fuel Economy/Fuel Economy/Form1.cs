using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fuel_Economy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Calculate MPG 按鈕:每加侖行駛英里數 = 英里 / 加侖
        private void calculateButton_Click(object sender, EventArgs e)
        {
            double miles, gallons;

            if (!double.TryParse(milesTextBox.Text, out miles) || miles < 0)
            {
                MessageBox.Show("Please enter a valid number of miles driven.",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                milesTextBox.Focus();
                milesTextBox.SelectAll();
                return;
            }

            if (!double.TryParse(gallonsTextBox.Text, out gallons) || gallons <= 0)
            {
                MessageBox.Show("Please enter a valid number of gallons (greater than 0).",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gallonsTextBox.Focus();
                gallonsTextBox.SelectAll();
                return;
            }

            double mpg = miles / gallons;
            mpgLabel.Text = mpg.ToString("n1");
        }

        // Exit 按鈕:關閉程式
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}