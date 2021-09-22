using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mini_market
{
    public partial class SellerForm : Form
    {
        DBConnect dbCon = new DBConnect();
        public SellerForm()
        {
            InitializeComponent();
        }

        private void getTable()
        {
            string selectQuery = "SELECT * FROM seller";
            SqlCommand command = new SqlCommand(selectQuery, dbCon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridView_seller.DataSource = table;
        }

        private void clear()
        {
            TextBox_id.Clear();
            TextBox_name.Clear();
            TextBox_age.Clear();
            TextBox_phoneNo.Clear();
            TextBox_password.Clear();
        }

        private void Button_add_Click(object sender, EventArgs e)
        {
            try
            {
                string insertQuery = "INSERT INTO seller VALUES('" + TextBox_id.Text.Trim() + "','" + TextBox_name.Text.Trim() + "','" + TextBox_age.Text.Trim() + "', '"+TextBox_phoneNo.Text.Trim() + "', '"+TextBox_password.Text.Trim()+"')";
                SqlCommand command = new SqlCommand(insertQuery, dbCon.GetCon());
                dbCon.OpenCon();
                command.ExecuteNonQuery();
                MessageBox.Show("Seller added succesfully", "Add Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dbCon.CloseCon();
                getTable();
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SellerForm_Load(object sender, EventArgs e)
        {
            getTable();
        }

        private void Button_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_id.Text == "")
                {
                    MessageBox.Show("Missing information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string updateQuery = "UPDATE seller SET name='" + TextBox_name.Text.Trim() + "', age='" + TextBox_age.Text.Trim() + "', phone='"+TextBox_phoneNo.Text.Trim() + "', password='"+TextBox_password.Text.Trim() + "' WHERE id='" + TextBox_id.Text.Trim() + "'";
                    SqlCommand command = new SqlCommand(updateQuery, dbCon.GetCon());
                    dbCon.OpenCon();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Seller updated succesfully", "Update Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dbCon.CloseCon();
                    getTable();
                    clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_id.Text == "")
                {
                    MessageBox.Show("Missing information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string deleteQuery = "DELETE FROM seller WHERE id='" + TextBox_id.Text.Trim() + "'";
                        SqlCommand command = new SqlCommand(deleteQuery, dbCon.GetCon());
                        dbCon.OpenCon();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Seller deleted succesfully", "Delete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dbCon.CloseCon();
                        getTable();
                        clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGridView_seller_Click(object sender, EventArgs e)
        {
            TextBox_id.Text = DataGridView_seller.SelectedRows[0].Cells[0].Value.ToString().Trim();
            TextBox_name.Text = DataGridView_seller.SelectedRows[0].Cells[1].Value.ToString().Trim();
            TextBox_age.Text = DataGridView_seller.SelectedRows[0].Cells[2].Value.ToString().Trim();
            TextBox_phoneNo.Text = DataGridView_seller.SelectedRows[0].Cells[3].Value.ToString().Trim();
            TextBox_password.Text = DataGridView_seller.SelectedRows[0].Cells[4].Value.ToString().Trim();
        }

        private void Label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Label_exit_MouseEnter(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.Red;
        }

        private void Label_exit_MouseLeave(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.Goldenrod;
        }

        private void Label_logout_MouseEnter(object sender, EventArgs e)
        {
            label_logout.ForeColor = Color.Red;
        }

        private void Label_logout_MouseLeave(object sender, EventArgs e)
        {
            label_logout.ForeColor = Color.Goldenrod;
        }

        private void Label_logout_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        private void Button_product_Click(object sender, EventArgs e)
        {
            ProductForm product = new ProductForm();
            product.Show();
            this.Hide();
        }

        private void Button_category_Click(object sender, EventArgs e)
        {
            CategoryForm category = new CategoryForm();
            category.Show();
            this.Hide();
        }
    }
}
