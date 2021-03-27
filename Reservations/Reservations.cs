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
    public partial class Reservations : Form, IRefreshable
    {
        Dictionary<string, int> workers;
        Dictionary<string, int> rooms;
        Dictionary<string, int> clients;

        public Reservations()
        {
            InitializeComponent();
        }

        private void Reservations_Load(object sender, EventArgs e)
        {
            RefreshDB();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            ReservationForm form = new ReservationForm(workers, rooms, clients);
            form.Text = "Добавить бронь";
            form.button1.Text = "Добавить";
            if (form.ShowDialog() == DialogResult.OK)
            {
                using (var sql = new SqlConnection(Program.sql.ConnectionString))
                {
                    sql.Open();
                    var com = sql.CreateCommand();
                    com.CommandText = String.Format("insert into Бронь values('{0}','{1}','{2}','{3}','{4}','{5}')",
                        workers[form.worker.SelectedItem.ToString()], rooms[form.room.SelectedItem.ToString()], 
                        clients[form.client.SelectedItem.ToString()], form.enterDate.Value.ToString("yyyy-MM-dd"),
                        form.exitDate.Value.ToString("yyyy-MM-dd"), form.price.Value.ToString().Replace(',', '.'));
                    com.ExecuteNonQuery();
                    sql.Close();
                }
                RefreshDB();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            ReservationForm form = new ReservationForm(workers, rooms, clients);
            form.Text = "Изменить бронь";
            form.button1.Text = "Применить";

            form.Tag = dataGridView.SelectedRows[0].Cells[0].Value.ToString();
            form.worker.SelectedItem = dataGridView.SelectedRows[0].Cells[4].Value.ToString();
            form.room.SelectedItem = dataGridView.SelectedRows[0].Cells[5].Value.ToString();
            form.client.SelectedItem = dataGridView.SelectedRows[0].Cells[6].Value.ToString();
            form.enterDate.Value = DateTime.Parse(dataGridView.SelectedRows[0].Cells[7].Value.ToString());
            form.exitDate.Value = DateTime.Parse(dataGridView.SelectedRows[0].Cells[8].Value.ToString());
            form.price.Value = decimal.Parse(dataGridView.SelectedRows[0].Cells[9].Value.ToString());

            if (form.ShowDialog() == DialogResult.OK)
            {
                using (var sql = new SqlConnection(Program.sql.ConnectionString))
                {
                    sql.Open();
                    var com = sql.CreateCommand();
                    com.CommandText = String.Format("update Бронь set [Id сотрудника]='{0}',[Id номера]='{1}'," +
                        "[Id клиента]='{2}',[Дата въезда]='{3}',[Дата выезда]='{4}',Стоимость='{5}' where Id={6}",
                        workers[form.worker.SelectedItem.ToString()], rooms[form.room.SelectedItem.ToString()],
                        clients[form.client.SelectedItem.ToString()], form.enterDate.Value.ToString("yyyy-MM-dd"),
                        form.exitDate.Value.ToString("yyyy-MM-dd"), form.price.Value.ToString().Replace(',', '.'), form.Tag);
                    com.ExecuteNonQuery();
                    sql.Close();
                }
                RefreshDB();
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
                    com.CommandText = String.Format("delete from Бронь where Id={0}", dataGridView.SelectedRows[0].Cells[0].Value);
                    com.ExecuteNonQuery();
                    sql.Close();
                }
                RefreshDB();
            }
        }

        public void RefreshDB()
        {
            dataGridView.Rows.Clear();
            using (var sql = new SqlConnection(Program.sql.ConnectionString))
            {
                sql.Open();
                var com = sql.CreateCommand();
                com.CommandText = "select t1.Id, t1.[Id сотрудника], t1.[Id номера], t1.[Id клиента]," +
                    "t2.Должность + ': ' + t2.Фамилия + ' ' +" +
                    "SUBSTRING(t2.Имя, 1, 1) + '.' + SUBSTRING(t2.Отчество, 1, 1) + '.'," +
                    "CAST(t3.[Номер комнаты] as nvarchar(10)) + ' - ' + t3.[Тип номера]," +
                    "t4.Фамилия + ' ' +" +
                    "SUBSTRING(t4.Имя, 1, 1) + '.' + SUBSTRING(t4.Отчество, 1, 1) + '.'," +
                    "t1.[Дата въезда], t1.[Дата выезда], t1.Стоимость " +
                    "from(((Бронь t1 inner join Сотрудники t2 on t1.[Id сотрудника] = t2.Id)" +
                    "inner join Номера t3 on t1.[Id номера] = t3.Id) inner join Клиенты t4 on t1.[Id клиента] = t4.Id)";

                var reader = com.ExecuteReader();
                while (reader.Read())
                {
                    var row = new DataGridViewRow();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        var c = new DataGridViewTextBoxCell();
                        if (i != reader.FieldCount - 2 && i != reader.FieldCount - 3)
                            c.Value = reader[i];
                        else
                            c.Value = ((DateTime)reader[i]).ToString("dd.MM.yyyy");
                        row.Cells.Add(c);
                    }
                    dataGridView.Rows.Add(row);
                }
                reader.Close();

                workers = new Dictionary<string, int>();
                rooms = new Dictionary<string, int>();
                clients = new Dictionary<string, int>();

                com = sql.CreateCommand();
                com.CommandText = "select Должность + ': ' + Фамилия + ' ' +" +
                    "SUBSTRING(Имя, 1, 1) + '.' + SUBSTRING(Отчество, 1, 1) + '.', Id from Сотрудники";
                reader = com.ExecuteReader();
                while (reader.Read())
                    workers.Add(reader[0].ToString(), (int)reader[1]);
                reader.Close();

                com = sql.CreateCommand();
                com.CommandText = "select cast([Номер комнаты] as nvarchar(10)) + ' - ' + [Тип номера], Id from Номера";
                reader = com.ExecuteReader();
                while (reader.Read())
                    rooms.Add(reader[0].ToString(), (int)reader[1]);
                reader.Close();

                com = sql.CreateCommand();
                com.CommandText = "select Фамилия + ' ' +" +
                    "SUBSTRING(Имя, 1, 1) + '.' + SUBSTRING(Отчество, 1, 1) + '.', Id from Клиенты";
                reader = com.ExecuteReader();
                while (reader.Read())
                    clients.Add(reader[0].ToString(), (int)reader[1]);
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
