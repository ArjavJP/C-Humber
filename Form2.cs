using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week10
{
    public partial class Form2 : Form
    {
        public Inventroy NewItem { get; private set; }
        public Form2()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                NewItem = new Inventroy()
                {
                    ItemNo = int.Parse(txtitem.Text),
                    Description = txtdesc.Text,
                    Price = decimal.Parse(txtprice.Text)
                };
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Please fill in all fields with valid data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidateInput()
        {
            return !string.IsNullOrWhiteSpace(txtitem.Text) &&
                   !string.IsNullOrWhiteSpace(txtdesc.Text) &&
                   !string.IsNullOrWhiteSpace(txtprice.Text) &&
                   int.TryParse(txtitem.Text, out _) &&
                   decimal.TryParse(txtprice.Text, out _);
        }
    }
}
