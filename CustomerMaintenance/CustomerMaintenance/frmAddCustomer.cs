using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CustomerMaintenance
{
    public partial class frmAddCustomer : Form
    {

        private Customer customer = null;

        public frmAddCustomer()
        {
            InitializeComponent();
        }

        public Customer GetNewCustomer()
        {
            using (var form = new frmAddCustomer())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    return form.customer;
                }
                else return null;
            }

            void InitializeComponents()
            {
                // Initialize form controls, including the saveButton
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text;// Get the value from the FirstName field
            string lastName = txtLastName.Text;// Get the value from the LastName field
            string email = txtEmail.Text;// Get the value from the Email field

            string validationErrors = "";
            validationErrors += Validator.IsPresent(firstName, "First Name");
            validationErrors += Validator.IsPresent(lastName, "Last Name");
            validationErrors += Validator.IsValidEmail(email, "Email");

            if (string.IsNullOrEmpty(validationErrors))
            {
                customer = new Customer(firstName, lastName, email);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Validation errors:" + Environment.NewLine + validationErrors);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
