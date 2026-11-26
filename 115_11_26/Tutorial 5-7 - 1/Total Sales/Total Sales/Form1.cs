using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Total_Sales
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            // 計算按鈕點擊事件處理
            try
            {
                decimal total = 0m;

                openFile.InitialDirectory = @"C:\Users\m303\Downloads\data";

                if (openFile.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("未選擇檔案。");
                    return;
                }

                using (StreamReader inputFile = File.OpenText(openFile.FileName))
                {
                    while (!inputFile.EndOfStream)
                    {
                        string line = inputFile.ReadLine();

                        if (decimal.TryParse(line, out decimal sales))
                        {
                            total += sales;
                        }
                        else
                        {
                            MessageBox.Show("檔案中包含無效的銷售額數據。");
                            return;
                        }
                    }
                }

                totalLabel.Text = total.ToString("C");
            }
            catch (Exception ex)
            {
                MessageBox.Show("發生錯誤：" + ex.Message);
            }
        }



        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單
            this.Close();
        }
    }
}
