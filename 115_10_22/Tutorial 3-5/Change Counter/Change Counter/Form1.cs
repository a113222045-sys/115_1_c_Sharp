using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Change_Counter
{
    public partial class Form1 : Form
    {
        // 累計總金額(以美元計)
        private decimal total = 0m;

        public Form1()
        {
            InitializeComponent();
            UpdateTotal();
        }

        // 點擊 5 分硬幣
        private void fiveCentsPictureBox_Click(object sender, EventArgs e)
        {
            total += 0.05m;
            UpdateTotal();
        }

        // 點擊 10 分硬幣
        private void tenCentsPictureBox_Click(object sender, EventArgs e)
        {
            total += 0.10m;
            UpdateTotal();
        }

        // 點擊 25 分硬幣
        private void twentyFiveCentsPictureBox_Click(object sender, EventArgs e)
        {
            total += 0.25m;
            UpdateTotal();
        }

        // 點擊 50 分硬幣
        private void fiftyCentsPictureBox_Click(object sender, EventArgs e)
        {
            total += 0.50m;
            UpdateTotal();
        }

        // Exit 按鈕:關閉程式
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 更新總金額顯示(固定使用美元格式,不受電腦地區設定影響)
        private void UpdateTotal()
        {
            totalLabel.Text = total.ToString("c", CultureInfo.GetCultureInfo("en-US"));
        }
    }
}