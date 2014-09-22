using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoursePaper
{
    public partial class AddElement : Form
    {
        public AddElement()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string header = this.headerTextBox.Text;
            string body = this.bodyTextBox.Text;
            try
            {
                if(DBConnector.ExecuteNonQuery(String.Format("INSERT INTO data (header, body, date_added) VALUES ('{0}', '{1}', NOW())", header, body)))
                {
                    MessageBox.Show("Element added succesfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
