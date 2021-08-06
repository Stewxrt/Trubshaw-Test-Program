using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions; // For email validation
using System.Windows.Forms;

namespace Trubshaw_Pre_Interview_Test__C_Sharp_
{
    public partial class TestProgram : Form
    {
        /*
         * Written by Stewart Forlow
         * 06/08/2021
         * 
         * (used a lot of the .Visible function to make the program, when run, look a bit cleaner than a bunch of buttons/text being present
         */
        String userName;    // Variables used to store the users Name & Email from the textboxes
        String userEmail;


        static Regex validate_emailaddress = email_validation();

        public TestProgram()

        {
            InitializeComponent();
            MessageBox.Show("This is a test program. Created by Stewart Forlow");
        }

        private void buttonBack_Click(object sender, EventArgs e)   // Button that resets back to the Welcome/Enter your name section
        {
            labelName.Visible = true;
            textBoxName.Visible = true;
            labelEmail.Visible = false;
            labelThreat.Visible = false;
            buttonName.Visible = true;
            buttonEmail.Visible = false;
            buttonThreat.Visible = false;
            textBoxEmail.Visible = false;
            radioButtonLow.Visible = false;
            radioButtonMedium.Visible = false;
            radioButtonHigh.Visible = false;
            radioButtonLow.Checked = false;
            radioButtonMedium.Checked = false;
            radioButtonHigh.Checked = false;
            listBox1.Visible = false;
            labelWelcome.Visible = true;
            textBoxEmail.Clear();
            textBoxName.Clear();
            listBox1.Items.Clear();

        }

        private void buttonName_Click_1(object sender, EventArgs e)     // Stores your name in the invisible list box, hides name label/button/textbox, and loads Email section
        {

            if (textBoxName.Text.Length < 2 || textBoxName.Text.Length > 25)
            {
                MessageBox.Show("Your name must be between 2 to 25 characters long.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // Error message if name isn't between 2-25 characters.
                textBoxName.Focus();
                return /*false*/;
            }
            else
            {
                userName = textBoxName.Text;
                listBox1.Items.Add("Your name is: " + userName);
                buttonName.Visible = false;
                textBoxName.Visible = false;
                buttonEmail.Visible = true;
                textBoxEmail.Visible = true;
                labelName.Visible = false;
                labelEmail.Visible = true;
                labelWelcome.Visible = false;
            }
        }

        private void buttonEmail_Click_1(object sender, EventArgs e)    // Stores your email in the invisible list box, hides name label/button/textbox, and loads threat radio button section

        {           // Email validation
            if (validate_emailaddress.IsMatch(textBoxEmail.Text) != true)   
            {
                MessageBox.Show("Invalid Email Address!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // Error message if text isn't in email format
                textBoxEmail.Focus();
                return;
            }
            else
            {
                userEmail = textBoxEmail.Text;
                listBox1.Items.Add("Your email is: " + userEmail);
                buttonEmail.Visible = false;
                labelEmail.Visible = false;
                labelThreat.Visible = true;
                radioButtonLow.Visible = true;
                radioButtonMedium.Visible = true;
                radioButtonHigh.Visible = true;
                buttonBack.Visible = true;
                textBoxEmail.Visible = false;
                //MessageBox.Show("Email Address is valid.");   // testing if the validation works
            }
        }

        private void buttonThreat_Click(object sender, EventArgs e) // Stores the radio button selection and shows what the user has entered through the listbox.
        {
            if (radioButtonLow.Checked == true)
            {
                listBox1.Items.Add("You have reported a Low level threat.");
            }
            if (radioButtonMedium.Checked == true)
            {
                listBox1.Items.Add("You have reported a Medium level threat.");
            }
            if (radioButtonHigh.Checked == true)
            {
                listBox1.Items.Add("You have reported a High level threat.");
            }
            labelEmail.Visible = false;
            labelThreat.Visible = false;
            buttonName.Visible = false;
            buttonEmail.Visible = false;
            buttonThreat.Visible = false;
            textBoxEmail.Visible = false;
            radioButtonLow.Visible = false;
            radioButtonMedium.Visible = false;
            radioButtonHigh.Visible = false;
            radioButtonLow.Checked = false;
            radioButtonMedium.Checked = false;
            radioButtonHigh.Checked = false;
            buttonBack.Visible = false;
            buttonThreat.Visible = false;
            listBox1.Visible = Visible;
        }

        

        private void radioButtonLow_CheckedChanged(object sender, EventArgs e)
        {
            buttonThreat.Visible = true;
        }

        private void radioButtonMedium_CheckedChanged(object sender, EventArgs e)
        {
            buttonThreat.Visible = true;
        }

        private void radioButtonHigh_CheckedChanged(object sender, EventArgs e)
        {
            buttonThreat.Visible = true;
        }

        private void buttonBack_Click_1(object sender, EventArgs e) // This button resets the Threat section and removes the email saved from the listbox.
        {
            listBox1.Items.RemoveAt(listBox1.Items.Count - 1);
            buttonName.Visible = false;
            textBoxName.Visible = false;
            buttonEmail.Visible = true;
            textBoxEmail.Visible = true;
            labelName.Visible = false;
            labelEmail.Visible = true;
            buttonBack.Visible = false;
            radioButtonLow.Visible = false;
            radioButtonMedium.Visible = false;
            radioButtonHigh.Visible = false;
            radioButtonLow.Checked = false;
            radioButtonMedium.Checked = false;
            radioButtonHigh.Checked = false;
            buttonThreat.Visible = false;
        }

        private static Regex email_validation() // Method for email validation
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(pattern, RegexOptions.IgnoreCase);
        }
    }
}
