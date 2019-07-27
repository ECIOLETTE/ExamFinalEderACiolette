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

namespace ExamEderCiolette
{
    public partial class Insert : Form
    {
        string connectionString = "Data Source = INSTRUCTORIT; Initial Catalog = TournamentManager; " +
                                  "User ID = ProfileUser; Password = ProfileUser2019";
        public Insert()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main formInicial = new Main();
            formInicial.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Views views = new Views();
            views.ShowDialog();
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connectionString;

            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand();
                string mySql = "INSERT INTO Teams (TeamName, CoachName, DirectorName, AddressLine1, " +
                    "AddressLine2, PostCode, City, ContactNumber, EmailAddress, CreatedBy) " +
                    "VALUES('" + txtTeamName.Text + "', '" + txtCoachName.Text + "'," +
                    " '" + txtDirectorName.Text + "', '" + txtAddressLine1.Text + "', '" + txtAddressLine2.Text + "', " +
                    "'" + txtPostCode.Text + "', '" + txtCity.Text + "', '" + txtContactNumber.Text + "'" +
                    ", '" + txtEmailAddress.Text + "', '" + txtCreatedBy.Text + "')";

                myCommand.Connection = myConnection;
                myCommand.CommandText = mySql;

                myCommand.ExecuteNonQuery();

                txtTeamName.Text = "";
                txtCoachName.Text = "";
                txtDirectorName.Text = "";
                txtAddressLine1.Text = "";
                txtAddressLine2.Text = "";
                txtPostCode.Text = "";
                txtCity.Text = "";
                txtContactNumber.Text = "";
                txtEmailAddress.Text = "";
                txtCreatedBy.Text = "";

                MessageBox.Show("Saved successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                }
            }
        }

        private void Insert_Load(object sender, EventArgs e)
        {

        }
    }
}
