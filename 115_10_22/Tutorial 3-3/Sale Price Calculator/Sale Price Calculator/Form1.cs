using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sale_Price_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Calculate Sale Price 按鈕:售價 = 原價 - 折扣金額
        private void calculateButton_Click(object sender, EventArgs e)
        {
            decimal originalPrice, discountPercentage;

            if (!decimal.TryParse(originalPriceTextBox.Text, out originalPrice) || originalPrice < 0)
            {
                MessageBox.Show("Please enter a valid original price.",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                originalPriceTextBox.Focus();
                originalPriceTextBox.SelectAll();
                return;
            }

            if (!decimal.TryParse(discountPercentageTextBox.Text, out discountPercentage) ||
                discountPercentage < 0 || discountPercentage > 100)
            {
                MessageBox.Show("Please enter a discount percentage between 0 and 100.",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                discountPercentageTextBox.Focus();
                discountPercentageTextBox.SelectAll();
                return;
            }

            // 例如輸入 20 代表 20% 折扣
            decimal discountAmount = originalPrice * (discountPercentage / 100m);
            decimal salePrice = originalPrice - discountAmount;

            salePriceLabel.Text = salePrice.ToString("c");
        }

        // Exit 按鈕:關閉程式
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
