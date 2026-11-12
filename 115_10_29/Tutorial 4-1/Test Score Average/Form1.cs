using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_Score_Average
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Calculate Average 按鈕:計算三次考試的平均分數
        private void calculateButton_Click(object sender, EventArgs e)
        {
            double score1, score2, score3;

            if (!double.TryParse(test1TextBox.Text, out score1) || score1 < 0 || score1 > 100)
            {
                ShowInputError("Test Score #1", test1TextBox);
                return;
            }

            if (!double.TryParse(test2TextBox.Text, out score2) || score2 < 0 || score2 > 100)
            {
                ShowInputError("Test Score #2", test2TextBox);
                return;
            }

            if (!double.TryParse(test3TextBox.Text, out score3) || score3 < 0 || score3 > 100)
            {
                ShowInputError("Test Score #3", test3TextBox);
                return;
            }

            double average = (score1 + score2 + score3) / 3;
            averageLabel.Text = average.ToString("n1");
        }

        // Clear 按鈕:清除所有輸入與結果
        private void clearButton_Click(object sender, EventArgs e)
        {
            test1TextBox.Clear();
            test2TextBox.Clear();
            test3TextBox.Clear();
            averageLabel.Text = "";
            test1TextBox.Focus();
        }

        // Exit 按鈕:關閉程式
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 顯示錯誤訊息並把游標移回有問題的欄位
        private void ShowInputError(string scoreName, TextBox box)
        {
            MessageBox.Show(scoreName + " must be a number from 0 to 100.",
                "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            box.Focus();
            box.SelectAll();
        }
    }
}
