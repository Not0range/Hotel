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
    public partial class Rooms : Form
    {
        public Rooms()
        {
            InitializeComponent();
        }

        private void Rooms_Load(object sender, EventArgs e)
        {
            RefreshDB();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            RoomForm form = new RoomForm();
            form.Text = "Добавить номер";
            form.button1.Text = "Добавить";
            if (form.ShowDialog() == DialogResult.OK)
            {
                using (var sql = new SqlConnection(Program.sql.ConnectionString))
                {
                    sql.Open();
                    var com = sql.CreateCommand();
                    com.CommandText = String.Format("insert into Номера values('{0}','{1}','{2}')",
                        form.number.Value, form.type.SelectedItem, form.places.Value);
                    com.ExecuteNonQuery();
                    sql.Close();
                }
                RefreshDB();
                Owner.OwnedForms.OfType<IRefreshable>().ToList().ForEach(f => f.RefreshDB());
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            RoomForm form = new RoomForm();
            form.Text = "Изменить номер";
            form.button1.Text = "Применить";

            form.Tag = dataGridView.SelectedRows[0].Cells[0].Value.ToString();
            form.number.Value = int.Parse(dataGridView.SelectedRows[0].Cells[1].Value.ToString());
            form.type.SelectedItem = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
            form.places.Value = int.Parse(dataGridView.SelectedRows[0].Cells[3].Value.ToString());

            if (form.ShowDialog() == DialogResult.OK)
            {
                using (var sql = new SqlConnection(Program.sql.ConnectionString))
                {
                    sql.Open();
                    var com = sql.CreateCommand();
                    com.CommandText = String.Format("update Номера set [Номер комнаты]='{0}',[Тип номера]='{1}'," +
                        "[Количество мест]='{2}' where Id={3}",
                        form.number.Value, form.type.SelectedItem, form.places.Value, form.Tag);
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
                    com.CommandText = String.Format("delete from Номера where Id={0}", dataGridView.SelectedRows[0].Cells[0].Value);
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
                com.CommandText = "select * from Номера";
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
