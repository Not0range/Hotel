using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hotel
{
    public partial class Clients : Form
    {
        public Clients()
        {
            InitializeComponent();
        }

        private void Clients_Load(object sender, EventArgs e)
        {
            RefreshDB();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            ClientForm form = new ClientForm();
            form.Text = "Добавить клиента";
            form.button1.Text = "Добавить";
            if (form.ShowDialog() == DialogResult.OK)
            {
                using (var sql = new SqlConnection(Program.sql.ConnectionString))
                {
                    sql.Open();
                    var com = sql.CreateCommand();
                    com.CommandText = String.Format("insert into Клиенты values('{0}','{1}','{2}', '{3}')",
                        form.lastName.Text, form.firstName.Text, form.middleName.Text, form.contacts.Text);
                    com.ExecuteNonQuery();
                    sql.Close();
                }
                RefreshDB();
                Owner.OwnedForms.OfType<IRefreshable>().ToList().ForEach(f => f.RefreshDB());
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            ClientForm form = new ClientForm();
            form.Text = "Изменить клиента";
            form.button1.Text = "Применить";

            form.Tag = dataGridView.SelectedRows[0].Cells[0].Value.ToString();
            form.lastName.Text = dataGridView.SelectedRows[0].Cells[1].Value.ToString();
            form.firstName.Text = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
            form.middleName.Text = dataGridView.SelectedRows[0].Cells[3].Value.ToString();
            form.contacts.Text = dataGridView.SelectedRows[0].Cells[4].Value.ToString();

            if (form.ShowDialog() == DialogResult.OK)
            {
                using (var sql = new SqlConnection(Program.sql.ConnectionString))
                {
                    sql.Open();
                    var com = sql.CreateCommand();
                    com.CommandText = String.Format("update Клиенты set Фамилия='{0}',Имя='{1}'," +
                        "Отчество='{2}',[Контактные данные]='{3}' where Id={4}",
                        form.lastName.Text, form.firstName.Text, form.middleName.Text, form.contacts.Text, form.Tag);
                    com.ExecuteNonQuery();
                    sql.Close();
                }
                RefreshDB();
                Owner.OwnedForms.OfType<IRefreshable>().ToList().ForEach(f => f.RefreshDB());
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно желаете удалить выбранную запись", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var sql = new SqlConnection(Program.sql.ConnectionString))
                {
                    sql.Open();
                    var com = sql.CreateCommand();
                    com.CommandText = String.Format("delete from Клиенты where Id={0}", dataGridView.SelectedRows[0].Cells[0].Value);
                    com.ExecuteNonQuery();
                    sql.Close();
                }
                RefreshDB();
            }
        }

        private void RefreshDB()
        {
            dataGridView.Rows.Clear();
            using (var sql = new SqlConnection(Program.sql.ConnectionString))
            {
                sql.Open();
                var com = sql.CreateCommand();
                com.CommandText = "select * from Клиенты";
                var reader = com.ExecuteReader();
                while (reader.Read())
                {
                    var row = new DataGridViewRow();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        var c = new DataGridViewTextBoxCell();
                        c.Value = reader[i];
                        row.Cells.Add(c);
                    }
                    dataGridView.Rows.Add(row);
                }
                reader.Close();
                sql.Close();
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
