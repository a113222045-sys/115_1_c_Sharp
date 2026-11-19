using System;
using System.Windows.Forms;

namespace EquipmentRental
{
    public partial class RentalForm : Form
    {
        private const int MinDays = 1;
        private const int MaxDays = 7;
        private const int ClubDiscountThresholdDays = 3;
        private const int ClubDiscountAmount = 30;

        public RentalForm()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            feedbackLabel.Text = string.Empty;

            if (!int.TryParse(daysTextBox.Text.Trim(), out int days))
            {
                ShowError("請輸入整數的借用天數。");
                return;
            }

            if (days < MinDays || days > MaxDays)
            {
                ShowError($"借用天數須為 {MinDays}～{MaxDays} 天。");
                return;
            }

            int dailyRate = GetDailyRate(days);
            GetDiscount(days, clubCheckBox.Checked, out int discount, out string discountText);
            int total = days * dailyRate - discount;

            dailyRateLabel.Text = $"{dailyRate} 元";
            discountLabel.Text = discountText;
            totalLabel.Text = $"{total} 元";
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            daysTextBox.Clear();
            clubCheckBox.Checked = false;
            ResetResult();
            feedbackLabel.Text = string.Empty;
            daysTextBox.Focus();
        }

        private static int GetDailyRate(int days)
        {
            if (days <= 2) return 80;
            if (days <= 5) return 70;
            return 60;
        }

        private static void GetDiscount(int days, bool isClub, out int discount, out string text)
        {
            if (!isClub)
            {
                discount = 0;
                text = "無優惠";
            }
            else if (days >= ClubDiscountThresholdDays)
            {
                discount = ClubDiscountAmount;
                text = $"折抵 {ClubDiscountAmount} 元";
            }
            else
            {
                discount = 0;
                text = "未達折抵門檻";
            }
        }

        private void ShowError(string message)
        {
            ResetResult();
            feedbackLabel.Text = message;
            daysTextBox.Focus();
            daysTextBox.SelectAll();
        }

        private void ResetResult()
        {
            dailyRateLabel.Text = "—";
            discountLabel.Text = "—";
            totalLabel.Text = "—";
        }
    }
}