using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hotel
{
    public partial class ReservationForm : Form
    {
        public ReservationForm(Dictionary<string, int> workers,
            Dictionary<string, int> rooms,
            Dictionary<string, int> clients)
        {
            InitializeComponent();
            foreach (string w in workers.Keys)
                worker.Items.Add(w);

            foreach (string r in rooms.Keys)
                room.Items.Add(r);

            foreach (string c in clients.Keys)
                client.Items.Add(c);
        }

        private void ReservationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
                return;

            e.Cancel = worker.SelectedItem == null || room.SelectedItem == null || client.SelectedItem == null;
            if (e.Cancel)
                MessageBox.Show("Были введены не все данные");
        }

        private void Date_ValueChanged(object sender, EventArgs e)
        {
            if (sender == enterDate)
            {
                if (enterDate.Value > exitDate.Value)
                    exitDate.Value = enterDate.Value.AddDays(1);
            }
            else
            {
                if (enterDate.Value > exitDate.Value)
                    enterDate.Value = exitDate.Value.AddDays(-1);
            }
        }
    }
}
