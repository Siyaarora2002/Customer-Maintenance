using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerMaintenance
{
    public partial class frmCustomers : Form
    {

        private List<Customer> customers = null;
        public frmCustomers()
        {
            InitializeComponent();
        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            customers = CustomerDB.GetCustomers();
            AddCustomersToListBox();
        }

        private void AddCustomersToListBox()
        {
            lstCustomers.Items.Clear();
            foreach (Customer customer in customers)
            {
                lstCustomers.Items.Add(customer.GetDisplayText());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddCustomer frmAddCustomer = new frmAddCustomer();
            Customer newCustomer = frmAddCustomer.GetNewCustomer();

            if (newCustomer != null)
            {
                customers.Add(newCustomer);
                CustomerDB.SaveCustomers(customers);
                AddCustomersToListBox();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstCustomers.SelectedIndex != -1)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected customer?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int selectedIndex = lstCustomers.SelectedIndex;
                    customers.RemoveAt(selectedIndex);
                    CustomerDB.SaveCustomers(customers);
                    AddCustomersToListBox();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
