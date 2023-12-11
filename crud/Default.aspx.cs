using System;
using System.Data;

namespace crud
{
    public partial class _Default : System.Web.UI.Page
    {
        private readonly StudentInfoDAL dal = new StudentInfoDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        protected void ButtonInsert_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int id = Convert.ToInt32(txtId.Text);
                string name = txtName.Text;
                int age = Convert.ToInt32(txtAge.Text);
                string gender = string.Empty;

                if (rbtnMale.Checked)
                {
                    gender = "Male";
                }
                else if (rbtnFemale.Checked)
                {
                    gender = "Female";
                }

                string hobbies = ddlHobbies.SelectedValue;

                dal.InsertStudent(id, name, age, gender, hobbies);

                BindGridView();
                ClearInputs();
            }
        }

        protected void ButtonUpdate_Click1(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int id = Convert.ToInt32(txtId.Text);
                string name = txtName.Text;
                int age = Convert.ToInt32(txtAge.Text);
                string gender = string.Empty;

                if (rbtnMale.Checked)
                {
                    gender = "Male";
                }
                else if (rbtnFemale.Checked)
                {
                    gender = "Female";
                }

                string hobbies = ddlHobbies.SelectedValue;

                dal.UpdateStudent(id, name, age, gender, hobbies);

                BindGridView();
                ClearInputs();
            }
        }

        protected void ButtonDelete_Click1(object sender, EventArgs e)
        {

                // Set the client-side confirmation using OnClientClick
                ButtonDelete.OnClientClick = "return confirmDelete();";

                // Rest of your existing code for deleting the record
                int id = Convert.ToInt32(txtId.Text);
                dal.DeleteStudent(id);

                ClearInputs();
                BindGridView();
            
        }

        protected void ButtonSearch_Click1(object sender, EventArgs e)
        {

                int id = Convert.ToInt32(txtId.Text);
                DataRow student = dal.GetStudentById(id);

                if (student != null)
                {
                    // Populate your controls with the data
                    txtName.Text = student["Name"].ToString();
                    txtAge.Text = student["Age"].ToString();
                    // Set the gender radio button based on the value in the DataRow
                    rbtnMale.Checked = string.Equals(student["Gender"].ToString(), "Male", StringComparison.OrdinalIgnoreCase);
                    rbtnFemale.Checked = string.Equals(student["Gender"].ToString(), "Female", StringComparison.OrdinalIgnoreCase);
                    ddlHobbies.SelectedValue = student["Hobbies"].ToString();
                }

                // ClearInputs(); // You may or may not want to clear the inputs after a search

                // Bind GridView with the searched data
                DataTable searchResult = new DataTable();
                searchResult.Columns.Add("Id");
                searchResult.Columns.Add("Name");
                searchResult.Columns.Add("Age");
                searchResult.Columns.Add("Gender");
                searchResult.Columns.Add("Hobbies");

                // Add the searched row to the DataTable
                searchResult.Rows.Add(student["Id"], student["Name"], student["Age"], student["Gender"], student["Hobbies"]);

                GridView1.DataSource = searchResult;
                GridView1.DataBind();
            
        }

        protected void ButtonGetAll_Click(object sender, EventArgs e)
        {
            // Logic to get all records from the data source
            BindGridView();
            ClearInputs();  // Optional: Clear inputs if needed
        }


        private void BindGridView()
        {
            GridView1.DataSource = dal.GetStudents();
            GridView1.DataBind();
        }

        private void ClearInputs()
        {
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtAge.Text = string.Empty;
            rbtnMale.Checked = false;
            rbtnFemale.Checked = false;
            ddlHobbies.SelectedIndex = 0;
        }
    }
}