using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Assignment_10._3
{
    public partial class Form1 : Form
    {
        CRUD crud;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            crud = new CRUD();
            dataGridView1.DataSource = crud.GetAll();
            btnSubmit.Enabled = false;
            btnUpdateRecord.Enabled = false;
            

        }
        private void Clear()
        {
            txtVIN.Clear();
            txtMake.Clear();
            txtModel.Clear();
            txtPrice.Clear();
            txtYear.Clear();
        }
        private void txtVIN_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {    
            btnSubmit.Enabled = true;
           
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtVIN.Text))
            {
                var newcar = new Car();
                newcar.VIN = txtVIN.Text;
                newcar.Make = txtMake.Text;
                newcar.Model = txtModel.Text;
                newcar.Year = int.Parse(txtYear.Text);
                newcar.Price = decimal.Parse(txtPrice.Text);
                crud.AddRecord(newcar);
                MessageBox.Show("New car added");
                Clear();

            }
            else
            {
                MessageBox.Show("No VIN added, record not added");
            }
            Clear();
            btnSubmit.Enabled=false;
            dataGridView1.DataSource = crud.GetAll();
        }

        private void btnUpdateRecord_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = crud.GetAll();
        }
    }
}
