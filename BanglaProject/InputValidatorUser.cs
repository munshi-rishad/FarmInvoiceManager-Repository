using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BanglaProject.DataBase;

namespace BanglaProject
{
    internal class InputValidatorUser
    {
        
        public static bool ValidateStatus(CheckBox chkIsActive, Label lblStatusError)
        {
            lblStatusError.Visible = false;

            if (!chkIsActive.Checked)
            {
                lblStatusError.Text = "Status must be Active";
                lblStatusError.ForeColor = Color.Red;
                lblStatusError.Visible = true;
                return false;
            }

            lblStatusError.Text = "✓ Looks good";
            lblStatusError.ForeColor = Color.Green;
            lblStatusError.Visible = true;
            return true;
        }
        public static bool ValidateRole(ComboBox cmbRole, Label lblRoleError)
        {
            lblRoleError.Visible = false;

            if (cmbRole.SelectedIndex == -1)
            {
                lblRoleError.Text = "Please select a role";
                lblRoleError.ForeColor = Color.Red;
                lblRoleError.Visible = true;
                return false;
            }

            lblRoleError.Text = "✓ Looks good";
            lblRoleError.ForeColor = Color.Green;
            lblRoleError.Visible = true;
            return true;
        }
        public static bool ValidateAddress(TextBox txtAddress, Label lblAddressError)
        {
            lblAddressError.Visible = false;

            string address = txtAddress.Text.Trim();

            if (string.IsNullOrWhiteSpace(address))
            {
                lblAddressError.Text = "Address is required";
                lblAddressError.ForeColor = Color.Red;
                lblAddressError.Visible = true;
                return false;
            }

            if (address.Length < 4 || address.Length > 255)
            {
                lblAddressError.Text = "Address must be between 10 and 255 characters";
                lblAddressError.ForeColor = Color.Red;
                lblAddressError.Visible = true;
                return false;
            }

            foreach (char c in address)
            {
                if (!(char.IsLetterOrDigit(c) || c == ' ' || c == ',' || c == '.'))
                {
                    lblAddressError.Text = "Address contains invalid characters";
                    lblAddressError.ForeColor = Color.Red;
                    lblAddressError.Visible = true;
                    return false;
                }
            }

            lblAddressError.Text = "✓ Looks good";
            lblAddressError.ForeColor = Color.Green;
            lblAddressError.Visible = true;
            return true;
        }
        public static bool ValidateNID(TextBox txtNid, Label lblNidError)
        {
            lblNidError.Visible = false;

            string nid = txtNid.Text.Trim();

            if (string.IsNullOrWhiteSpace(nid))
            {
                lblNidError.Text = "NID is required";
                lblNidError.ForeColor = Color.Red;
                lblNidError.Visible = true;
                return false;
            }
            foreach (char c in nid)
            {
                if (!char.IsDigit(c))
                {
                    lblNidError.Text = "NID must contain only digits";
                    lblNidError.ForeColor = Color.Red;
                    lblNidError.Visible = true;
                    return false;
                }
            }

            if (!(nid.Length == 10  || nid.Length == 17))
            {
                lblNidError.Text = "NID must be 10 or 17 digits";
                lblNidError.ForeColor = Color.Red;
                lblNidError.Visible = true;
                return false;
            }

            

            lblNidError.Text = "✓ Looks good";
            lblNidError.ForeColor = Color.Green;
            lblNidError.Visible = true;
            return true;
        }
        public static bool ValidatePassword(TextBox txtPassword, Label lblPasswordError)
        {
            lblPasswordError.Visible = false;

            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(password))
            {
                lblPasswordError.Text = "Password is required";
                lblPasswordError.ForeColor = Color.Red;
                lblPasswordError.Visible = true;
                return false;
            }
            if (password.Contains(" "))
            {
                lblPasswordError.Text = "Password cannot contain spaces";
                lblPasswordError.ForeColor = Color.Red;
                lblPasswordError.Visible = true;
                return false;
            }

            if (password.Length < 8)
            {
                lblPasswordError.Text = "Password must be at least 8 characters";
                lblPasswordError.ForeColor = Color.Red;
                lblPasswordError.Visible = true;
                return false;
            }

            

            if (!password.Contains("@"))
            {
                lblPasswordError.Text = "Password must contain @ symbol";
                lblPasswordError.ForeColor = Color.Red;
                lblPasswordError.Visible = true;
                return false;
            }

            bool hasLower = false;
            bool hasUpper = false;
            bool hasDigit = false;

            foreach (char c in password)
            {
                if (char.IsLower(c)) hasLower = true;
                else if (char.IsUpper(c)) hasUpper = true;
                else if (char.IsDigit(c)) hasDigit = true;
            }

            if (!hasLower)
            {
                lblPasswordError.Text = "Password must contain at least one lowercase letter";
                lblPasswordError.ForeColor = Color.Red;
                lblPasswordError.Visible = true;
                return false;
            }

            if (!hasUpper)
            {
                lblPasswordError.Text = "Password must contain at least one uppercase letter";
                lblPasswordError.ForeColor = Color.Red;
                lblPasswordError.Visible = true;
                return false;
            }

            if (!hasDigit)
            {
                lblPasswordError.Text = "Password must contain at least one number";
                lblPasswordError.ForeColor = Color.Red;
                lblPasswordError.Visible = true;
                return false;
            }


            lblPasswordError.Text = "✓ Looks good";
            lblPasswordError.ForeColor = Color.Green;
            lblPasswordError.Visible = true;
            return true;
        }


        public static bool ValidateMobile(TextBox txtMobile, Label lblMobileError)
        {
            lblMobileError.Visible = false;

            string mobile = txtMobile.Text.Trim();

            if (string.IsNullOrWhiteSpace(mobile))
            {
                lblMobileError.Text = "Mobile number is required";
                lblMobileError.ForeColor = Color.Red;
                lblMobileError.Visible = true;
                return false;
            }
            if (!mobile.All(char.IsDigit))
            {
                lblMobileError.Text = "Mobile number must contain only digits";
                lblMobileError.ForeColor = Color.Red;
                lblMobileError.Visible = true;
                return false;
            }
            if (!mobile.StartsWith("01"))
            {
                lblMobileError.Text = "Mobile number must start with 01";
                lblMobileError.ForeColor = Color.Red;
                lblMobileError.Visible = true;
                return false;
            }

            if (mobile.Length != 11)
            {
                lblMobileError.Text = "Mobile number must be 11 digits";
                lblMobileError.ForeColor = Color.Red;
                lblMobileError.Visible = true;
                return false;
            }

            lblMobileError.Text = "✓ Looks good";
            lblMobileError.ForeColor = Color.Green;
            lblMobileError.Visible = true;
            return true;
        }
        public static bool ValidateUsername(TextBox txtUsername, Label lblUsernameError)
        {
            lblUsernameError.Visible = false;

            string username = txtUsername.Text.Trim();

            if (string.IsNullOrWhiteSpace(username))
            {
                lblUsernameError.Text = "Username is required";
                lblUsernameError.ForeColor = Color.Red;
                lblUsernameError.Visible = true;
                return false;
            }
            if (username.Contains(" "))
            {
                lblUsernameError.Text = "Username cannot contain spaces";
                lblUsernameError.ForeColor = Color.Red;
                lblUsernameError.Visible = true;
                return false;
            }

            if (username.Length < 5 || username.Length > 20)
            {
                lblUsernameError.Text = "Username must be between 5 and 20 characters";
                lblUsernameError.ForeColor = Color.Red;
                lblUsernameError.Visible = true;
                return false;
            }

            

            foreach (char c in username)
            {
                if (!char.IsLower(c))
                {
                    lblUsernameError.Text = "Username must contain only lowercase letters";
                    lblUsernameError.ForeColor = Color.Red;
                    lblUsernameError.Visible = true;
                    return false;
                }
            }

            lblUsernameError.Text = "✓ Looks good";
            lblUsernameError.ForeColor = Color.Green;
            lblUsernameError.Visible = true;
            return true;
        }
        public static bool ValidateFullName(TextBox txtFullName, Label lblFullNameError)
        {
            lblFullNameError.Visible = false;

            string fullName = txtFullName.Text.Trim();

            if (string.IsNullOrWhiteSpace(fullName))
            {
                lblFullNameError.Text = "Full Name is required";
                lblFullNameError.ForeColor = Color.Red;
                lblFullNameError.Visible = true;
                return false;
            }

            if (!fullName.All(c => char.IsLetter(c) || c == ' '))
            {
                lblFullNameError.Text = "Full Name must contain only letters";
                lblFullNameError.ForeColor = Color.Red;
                lblFullNameError.Visible = true;
                return false;
            }

            if (fullName.Length < 2 || fullName.Length > 20)
            {
                lblFullNameError.Text = "Full Name must be between 2 and 20 characters";
                lblFullNameError.ForeColor = Color.Red;
                lblFullNameError.Visible = true;
                return false;
            }

            bool capitalOk = true;
            int i = 0;

            while (i < fullName.Length)
            {
                if (i == 0 && !char.IsUpper(fullName[i]))
                {
                    capitalOk = false;
                    break;
                }

                if (fullName[i] == ' ')
                {
                    if (i + 1 < fullName.Length && !char.IsUpper(fullName[i + 1]))
                    {
                        capitalOk = false;
                        break;
                    }
                }
                i++;
            }

            if (!capitalOk)
            {
                lblFullNameError.Text = "Each word must start with a capital letter";
                lblFullNameError.ForeColor = Color.Red;
                lblFullNameError.Visible = true;
                return false;
            }

            lblFullNameError.Text = "✓ Looks good";
            lblFullNameError.ForeColor = Color.Green;
            lblFullNameError.Visible = true;
            return true;
        }
        public static bool ValidateEmail(TextBox txtEmail, Label lblEmailError)
        {
            lblEmailError.Visible = false;

            string email = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                lblEmailError.Text = "Email is required";
                lblEmailError.ForeColor = Color.Red;
                lblEmailError.Visible = true;
                return false;
            }

            foreach (char c in email)
            {
                if (char.IsUpper(c))
                {
                    lblEmailError.Text = "Email must be lowercase only";
                    lblEmailError.ForeColor = Color.Red;
                    lblEmailError.Visible = true;
                    return false;
                }
            }

            if (email.Contains(" "))
            {
                lblEmailError.Text = "Email cannot contain spaces";
                lblEmailError.ForeColor = Color.Red;
                lblEmailError.Visible = true;
                return false;
            }

            if (!email.EndsWith("@gmail.com"))
            {
                lblEmailError.Text = "Only Gmail address is allowed (example@gmail.com)";
                lblEmailError.ForeColor = Color.Red;
                lblEmailError.Visible = true;
                return false;
            }

            string userPart = email.Replace("@gmail.com", "");

            if (string.IsNullOrWhiteSpace(userPart))
            {
                lblEmailError.Text = "Invalid Gmail address";
                lblEmailError.ForeColor = Color.Red;
                lblEmailError.Visible = true;
                return false;
            }

            foreach (char c in userPart)
            {
                if (!(char.IsLower(c) || char.IsDigit(c) || c == '.'))
                {
                    lblEmailError.Text = "Invalid Gmail address";
                    lblEmailError.ForeColor = Color.Red;
                    lblEmailError.Visible = true;
                    return false;
                }
            }

            lblEmailError.Text = "✓ Looks good";
            lblEmailError.ForeColor = Color.Green;
            lblEmailError.Visible = true;
            return true;
        }
        public static bool ValidateMobileComboBox(ComboBox cmbMobile, Label lblMobileError)
        {
            lblMobileError.Visible = false;

            string mobile = cmbMobile.Text.Trim();

            if (string.IsNullOrWhiteSpace(mobile))
            {
                lblMobileError.Text = "Mobile required";
                lblMobileError.ForeColor = Color.Red;
                lblMobileError.Visible = true;
                return false;
            }

            if (!mobile.All(char.IsDigit))
            {
                lblMobileError.Text = "Digits only";
                lblMobileError.ForeColor = Color.Red;
                lblMobileError.Visible = true;
                return false;
            }

            if (!mobile.StartsWith("01"))
            {
                lblMobileError.Text = "Must start with 01";
                lblMobileError.ForeColor = Color.Red;
                lblMobileError.Visible = true;
                return false;
            }

            if (mobile.Length != 11)
            {
                lblMobileError.Text = "11 digits required";
                lblMobileError.ForeColor = Color.Red;
                lblMobileError.Visible = true;
                return false;
            }

            lblMobileError.Text = "✓ Valid";
            lblMobileError.ForeColor = Color.Green;
            lblMobileError.Visible = true;
            return true;
        }



    }
}
