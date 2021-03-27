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
    public partial class Queryes : Form, IRefreshable
    {
        Dictionary<string, int> workers;
        Dictionary<string, int> rooms;

        public Queryes()
        {
            InitializeComponent();
        }

        private void Queryes_Load(object sender, EventArgs e)
        {
            RefreshDB();
        }

        private void execute_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    RoomQuery();
                    break;
                case 1:
                    WorkerQuery();
                    break;
                case 2:
                    FreeRoomsQuery();
                    break;
            }
        }

        private void RoomQuery()
        {
            dataGridView.Columns.AddRange(workerColumn, clientColumn, enterDate, exitDate, priceColumn);
            using (var sql = new SqlConnection(Program.sql.ConnectionString))
            {
                sql.Open();

                var com = sql.CreateCommand();
                com.CommandText = "select t2.Должность + ': ' + t2.Фамилия + ' ' +" +
                    "SUBSTRING(t2.Имя, 1, 1) + '.' + SUBSTRING(t2.Отчество, 1, 1) + '.'," +
                    "t4.Фамилия + ' ' +" +
                    "SUBSTRING(t4.Имя, 1, 1) + '.' + SUBSTRING(t4.Отчество, 1, 1) + '.'," +
                    "t1.[Дата въезда], t1.[Дата выезда], t1.Стоимость " +
                    "from(((Бронь t1 inner join Сотрудники t2 on t1.[Id сотрудника] = t2.Id)" +
                    "inner join Номера t3 on t1.[Id номера] = t3.Id) " +
                    "inner join Клиенты t4 on t1.[Id клиента] = t4.Id) where t1.[Id номера] = " + rooms[room.SelectedItem.ToString()];
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
                sql.Close();
            }
        }

        private void WorkerQuery()
        {
            dataGridView.Columns.AddRange(roomColumn, clientColumn, enterDate, exitDate, priceColumn);
            using (var sql = new SqlConnection(Program.sql.ConnectionString))
            {
                sql.Open();

                var com = sql.CreateCommand();
                com.CommandText = "select CAST(t3.[Номер комнаты] as nvarchar(10)) + ' - ' + t3.[Тип номера]," +
                    "t4.Фамилия + ' ' +" +
                    "SUBSTRING(t4.Имя, 1, 1) + '.' + SUBSTRING(t4.Отчество, 1, 1) + '.'," +
                    "t1.[Дата въезда], t1.[Дата выезда], t1.Стоимость " +
                    "from(((Бронь t1 inner join Сотрудники t2 on t1.[Id сотрудника] = t2.Id)" +
                    "inner join Номера t3 on t1.[Id номера] = t3.Id) " +
                    "inner join Клиенты t4 on t1.[Id клиента] = t4.Id) where t1.[Id сотрудника] = " + workers[worker.SelectedItem.ToString()];
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
                sql.Close();
            }
        }

        private void FreeRoomsQuery()
        {
            dataGridView.Columns.AddRange(number, type, places);
            using (var sql = new SqlConnection(Program.sql.ConnectionString))
            {
                sql.Open();

                var com = sql.CreateCommand();
                com.CommandText = "select t3.[Номер комнаты], t3.[Тип номера], t3.[Количество мест] " +
                    "from(((Бронь t1 inner join Сотрудники t2 on t1.[Id сотрудника] = t2.Id)" +
                    "inner join Номера t3 on t1.[Id номера] = t3.Id) " +
                    "inner join Клиенты t4 on t1.[Id клиента] = t4.Id)" +
                    "where not('" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + 
                    "' between t1.[Дата въезда] and t1.[Дата выезда])" +
                    "union select[Номер комнаты], [Тип номера], [Количество мест]" +
                    "from Номера where Id != ANY(select [Id номера] from Бронь)";
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

        public void RefreshDB()
        {
            using (var sql = new SqlConnection(Program.sql.ConnectionString))
            {
                sql.Open();
                
                workers = new Dictionary<string, int>();
                rooms = new Dictionary<string, int>();

                var com = sql.CreateCommand();
                com.CommandText = "select Должность + ': ' + Фамилия + ' ' +" +
                    "SUBSTRING(Имя, 1, 1) + '.' + SUBSTRING(Отчество, 1, 1) + '.', Id from Сотрудники";
                var reader = com.ExecuteReader();
                while (reader.Read())
                    workers.Add(reader[0].ToString(), (int)reader[1]);
                reader.Close();

                com = sql.CreateCommand();
                com.CommandText = "select cast([Номер комнаты] as nvarchar(10)) + ' - ' + [Тип номера], Id from Номера";
                reader = com.ExecuteReader();
                while (reader.Read())
                    rooms.Add(reader[0].ToString(), (int)reader[1]);
                reader.Close();

                sql.Close();
            }

            worker.Items.Clear();
            room.Items.Clear();

            foreach (string w in workers.Keys)
                worker.Items.Add(w);
            foreach (string r in rooms.Keys)
                room.Items.Add(r);
        }
    }
}
