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
    public partial class Workers : Form
    {
        public Workers()
        {
            InitializeComponent();
        }

        private void Workers_Load(object sender, EventArgs e)
        {
            RefreshDB();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            WorkerForm form = new WorkerForm();
            form.Text = "Добавить сотрудника";
            form.button1.Text = "Добавить";
            if (form.ShowDialog() == DialogResult.OK)
            {
                using (var sql = new SqlConnection(Program.sql.ConnectionString))
                {
                    sql.Open();
                    var com = sql.CreateCommand();
                    com.CommandText = String.Format("insert into Сотрудники values('{0}','{1}','{2}','{3}','{4}')",
                        form.lastName.Text, form.firstName.Text, form.middleName.Text, form.position.Text,
                        form.date.Value.ToString("yyyy-MM-dd"));
                    com.ExecuteNonQuery();
                    sql.Close();
                }
                RefreshDB();
                Owner.OwnedForms.OfType<IRefreshable>().ToList().ForEach(f => f.RefreshDB());
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            WorkerForm form = new WorkerForm();
            form.Text = "Изменить сотрудника";
            form.button1.Text = "Применить";

            form.Tag = dataGridView.SelectedRows[0].Cells[0].Value.ToString();
            form.lastName.Text = dataGridView.SelectedRows[0].Cells[1].Value.ToString();
            form.firstName.Text = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
            form.middleName.Text = dataGridView.SelectedRows[0].Cells[3].Value.ToString();
            form.position.Text = dataGridView.SelectedRows[0].Cells[4].Value.ToString();
            form.date.Value = DateTime.Parse(dataGridView.SelectedRows[0].Cells[5].Value.ToString());

            if (form.ShowDialog() == DialogResult.OK)
            {
                using (var sql = new SqlConnection(Program.sql.ConnectionString))
                {
                    sql.Open();
                    var com = sql.CreateCommand();
                    com.CommandText = String.Format("update Сотрудники set Фамилия='{0}',Имя='{1}'," +
                        "Отчество='{2}',Должность='{3}',[Дата приёма на работу]='{4}' where Id={5}",
                        form.lastName.Text, form.firstName.Text, form.middleName.Text, form.position.Text,
                        form.date.Value.ToString("yyyy-MM-dd"), form.Tag);
                    com.ExecuteNonQuery();
                    sql.Close();
                }
                RefreshDB();
                Owner.OwnedForms.OfType<IRefreshable>().ToList().ForEach(f => f.RefreshDB());
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Вы действительно желаете удалить выбранную запись", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var sql = new SqlConnection(Program.sql.ConnectionString))
                {
                    sql.Open();
                    var com = sql.CreateCommand();
                    com.CommandText = String.Format("delete from Сотрудники where Id={0}", dataGridView.SelectedRows[0].Cells[0].Value);
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
                com.CommandText = "select * from Сотрудники";
                var reader = com.ExecuteReader();
                while (reader.Read())
                {
                    var row = new DataGridViewRow();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        var c = new DataGridViewTextBoxCell();
                        if(i != reader.FieldCount - 1)
                            c.Value = reader[i];
                        else
                            c.Value = ((DateTime)reader[i]).ToString("dd.MM.yyyy");
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
