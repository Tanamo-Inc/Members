
using Model;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Members
{
    public partial class Members : Form
    {

        // My Title.
        string myTitle = "Membership";


        // My Connection String.
        static string conS = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        // Calling the Members_Model class.
        Members_Model conc = new Members_Model();

        public Members()
        {
            InitializeComponent();
        }

        // Member Load Method.
        private void Member_Load(object sender, EventArgs e)
        {

            // Load Data on ListView.

            DataTable dat = conc.Select();

            listview.DataSource = dat;

        }

        // Populating data into My listview Table.
        private void listview_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Load Data from ListView into the Fields.

            int rowIndex = e.RowIndex;

            id_field.Text = listview.Rows[rowIndex].Cells[0].Value.ToString();
            firstname_field.Text = listview.Rows[rowIndex].Cells[1].Value.ToString();
            lastname_field.Text = listview.Rows[rowIndex].Cells[2].Value.ToString();
            phone_field.Text = listview.Rows[rowIndex].Cells[3].Value.ToString();
            address_field.Text = listview.Rows[rowIndex].Cells[4].Value.ToString();
            level_field.Text = listview.Rows[rowIndex].Cells[5].Value.ToString();
            gender_field.Text = listview.Rows[rowIndex].Cells[6].Value.ToString();


        }

        // Button Add Member Method.
        private void but_Add_Click(object sender, EventArgs e)
        {

            // Get values from fields.

            conc.FirstName = firstname_field.Text;
            conc.LastName = lastname_field.Text;
            conc.Phone = phone_field.Text;
            conc.Address = address_field.Text;
            conc.Level = level_field.Text;
            conc.Gender = gender_field.Text;

            // Insert Data into Database.

            bool success = conc.Insert(conc);


            if (success == true)
            {
                MessageBox.Show("New Member Added Successfully.", myTitle);

                // Clear All Fields
                butClear();

            }
            else
            {
                MessageBox.Show("Failed To Add New Member.", myTitle);

            }

            // Load Data on ListView.
  
            DataTable dat = conc.Select();

            listview.DataSource = dat;

        }

        // Button Update Member Method.
        private void but_Update_Click(object sender, EventArgs e)
        {
            try
            {
                conc.ID = int.Parse(id_field.Text);

            }
            catch
            {

            }

            conc.FirstName = firstname_field.Text;
            conc.LastName = lastname_field.Text;
            conc.Phone = phone_field.Text;
            conc.Address = address_field.Text;
            conc.Gender = gender_field.Text;

            bool success = conc.Update(conc);


            if (success == true)
            {
                MessageBox.Show("Member Updated Successfully.", myTitle);

                // Load Data on ListView.

                DataTable dat = conc.Select();

                listview.DataSource = dat;


                butClear();

            }
            else
            {
                MessageBox.Show("Failed To Update Member.", myTitle);

            }




        }

        // Button Clear Member Method
        private void but_clear_Click(object sender, EventArgs e)
        {
            butClear();
        }

        // Button Delete Member Method
        private void but_Del_Click(object sender, EventArgs e)
        {

            try
            {
                conc.ID = Convert.ToInt32(id_field.Text);
            }
            catch { }

            bool success = conc.Delete(conc);


            if (success == true)
            {
                MessageBox.Show("Member Deleted Successfully.", myTitle);

                // Load Data on ListView.

                DataTable dat = conc.Select();

                listview.DataSource = dat;


                butClear();

            }
            else
            {
                MessageBox.Show("Failed To Delete Member.", myTitle);

            }

        }

        // Search Method.
        private void searcher_TextChanged(object sender, EventArgs e)
        {
            string keyword = searcher.Text;
            string query = "SELECT * FROM members_db WHERE FirstName LIKE '%" + keyword + "%'OR LastName  LIKE '%" + keyword + "%' OR Address  LIKE '%" + keyword + " %'";

            SqlConnection con = new SqlConnection(conS);

            SqlDataAdapter sad = new SqlDataAdapter(query, con);

            DataTable datat = new DataTable();

            sad.Fill(datat);

            listview.DataSource = datat;

        }

        // Close the Form Method.
        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Clear Fields Method.
        private void butClear()
        {

            id_field.Text = "";
            firstname_field.Text = "";
            lastname_field.Text = "";
            phone_field.Text = "";
            address_field.Text = "";
            level_field.Text = "";
            gender_field.Text = "";

        }


    }


}
