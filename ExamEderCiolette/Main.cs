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

    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            this.Hide();
            Views views = new Views();
            views.ShowDialog();
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            this.Hide();
            Insert insert = new Insert();
            insert.ShowDialog();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            this.Hide();
            Delete delete = new Delete();
            delete.ShowDialog();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            this.Hide();
            Update update = new Update();
            update.ShowDialog();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
