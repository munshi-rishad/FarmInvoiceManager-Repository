using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanglaProject
{
    internal class InputValidatorProduct
    {
        public static bool ValidateName(TextBox txtName, Label lblNameError)
        {
            lblNameError.Visible = false;

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                lblNameError.Text = "Product name is required";
                lblNameError.ForeColor = Color.Red;
                lblNameError.Visible = true;
                return false;
            }

            lblNameError.Text = "✓ Looks good";
            lblNameError.ForeColor = Color.Green;
            lblNameError.Visible = true;
            return true;
        }

        public static bool ValidateQuantity(TextBox txtQuantity, Label lblQuantityError)
        {
            lblQuantityError.Visible = false;

            if (string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                lblQuantityError.Text = "Quantity is required";
                lblQuantityError.ForeColor = Color.Red;
                lblQuantityError.Visible = true;
                return false;
            }

            int qty;
            if (!int.TryParse(txtQuantity.Text, out qty))
            {
                lblQuantityError.Text = "Quantity must be a number";
                lblQuantityError.ForeColor = Color.Red;
                lblQuantityError.Visible = true;
                return false;
            }

            if (qty < 0 || qty > 999)
            {
                lblQuantityError.Text = "Quantity must be between 0 and 999";
                lblQuantityError.ForeColor = Color.Red;
                lblQuantityError.Visible = true;
                return false;
            }

            lblQuantityError.Text = "✓ Looks good";
            lblQuantityError.ForeColor = Color.Green;
            lblQuantityError.Visible = true;
            return true;
        }


        public static bool ValidateCategory(TextBox txtCategory, Label lblCategoryError)
        {
            lblCategoryError.Visible = false;

            string category = txtCategory.Text.Trim();

            if (string.IsNullOrWhiteSpace(category))
            {
                lblCategoryError.Text = "Category is required";
                lblCategoryError.ForeColor = Color.Red;
                lblCategoryError.Visible = true;
                return false;
            }

            foreach (char c in category)
            {
                if (!char.IsLetter(c))
                {
                    lblCategoryError.Text = "Category must contain only letters";
                    lblCategoryError.ForeColor = Color.Red;
                    lblCategoryError.Visible = true;
                    return false;
                }
            }

            if (!char.IsUpper(category[0]))
            {
                lblCategoryError.Text = "Category must start with a capital letter";
                lblCategoryError.ForeColor = Color.Red;
                lblCategoryError.Visible = true;
                return false;
            }

            lblCategoryError.Text = "✓ Looks good";
            lblCategoryError.ForeColor = Color.Green;
            lblCategoryError.Visible = true;
            return true;
        }


        public static bool ValidatePrice(TextBox txtPrice, Label lblPriceError)
        {
            lblPriceError.Visible = false;

            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                lblPriceError.Text = "Unit price is required";
                lblPriceError.ForeColor = Color.Red;
                lblPriceError.Visible = true;
                return false;
            }

            foreach (char c in txtPrice.Text)
            {
                if (!char.IsDigit(c))
                {
                    lblPriceError.Text = "Price must contain only digits";
                    lblPriceError.ForeColor = Color.Red;
                    lblPriceError.Visible = true;
                    return false;
                }
            }

            int price = int.Parse(txtPrice.Text);

            if (price <= 0)
            {
                lblPriceError.Text = "Price must be greater than 0";
                lblPriceError.ForeColor = Color.Red;
                lblPriceError.Visible = true;
                return false;
            }

            lblPriceError.Text = "✓ Looks good";
            lblPriceError.ForeColor = Color.Green;
            lblPriceError.Visible = true;
            return true;
        }


        public static bool ValidateDate(DateTimePicker dtpDate, Label lblDateError)
        {
            lblDateError.Visible = false;

            DateTime selectedDate = dtpDate.Value.Date;
            DateTime today = DateTime.Now.Date;
            if (selectedDate > today)
            {
                lblDateError.Text = "Future date is not allowed";
                lblDateError.ForeColor = Color.Red;
                lblDateError.Visible = true;
                return false;
            }

            lblDateError.Text = "✓ Looks good";
            lblDateError.ForeColor = Color.Green;
            lblDateError.Visible = true;
            return true;
        }


        public static bool ValidateStatus(CheckBox chkIsActive, Label lblStatusError)
        {
            lblStatusError.Visible = false;

            if (!chkIsActive.Checked)
            {
                lblStatusError.Text = "Product must be Active";
                lblStatusError.ForeColor = Color.Red;
                lblStatusError.Visible = true;
                return false;
            }

            lblStatusError.Text = "✓ Looks good";
            lblStatusError.ForeColor = Color.Green;
            lblStatusError.Visible = true;
            return true;
        }
    }
}
