using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Birth_Date_String
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Show Date 按鈕:組合並顯示完整日期字串
        private void showDateButton_Click(object sender, EventArgs e)
        {
            string dayOfWeek = dayOfWeekTextBox.Text.Trim();
            string month = monthTextBox.Text.Trim();
            string dayOfMonth = dayOfMonthTextBox.Text.Trim();
            string year = yearTextBox.Text.Trim();

            // 檢查是否有欄位空白
            if (dayOfWeek == "" || month == "" || dayOfMonth == "" || year == "")
            {
                MessageBox.Show("Please fill in all fields.", "Missing Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 檢查日與年是否為有效數字
            if (!int.TryParse(dayOfMonth, out int day) || day < 1 || day > 31)
            {
                MessageBox.Show("The day of the month must be a number from 1 to 31.",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dayOfMonthTextBox.Focus();
                return;
            }

            if (!int.TryParse(year, out int yr) || yr < 1)
            {
                MessageBox.Show("The year must be a valid positive number.",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                yearTextBox.Focus();
                return;
            }

            // 輸出格式:Tuesday, March 15, 1988
            dateOutputLabel.Text = dayOfWeek + ", " + month + " " + day + ", " + yr;
        }

        // Clear 按鈕:清除所有輸入與輸出
        private void clearButton_Click(object sender, EventArgs e)
        {
            dayOfWeekTextBox.Clear();
            monthTextBox.Clear();
            dayOfMonthTextBox.Clear();
            yearTextBox.Clear();
            dateOutputLabel.Text = "";
            dayOfWeekTextBox.Focus();
        }

        // Exit 按鈕:關閉程式
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

