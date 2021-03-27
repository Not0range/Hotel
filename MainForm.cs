using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hotel
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Rooms_Click(object sender, EventArgs e)
        {
            Form form = OwnedForms.FirstOrDefault(f => f is Rooms);
            if (form != null)
            {
                form.WindowState = FormWindowState.Normal;
                form.Activate();
                return;
            }
            form = new Rooms();
            form.Show(this);
        }

        private void Workers_Click(object sender, EventArgs e)
        {
            Form form = OwnedForms.FirstOrDefault(f => f is Workers);
            if (form != null)
            {
                form.WindowState = FormWindowState.Normal;
                form.Activate();
                return;
            }
            form = new Workers();
            form.Show(this);
        }

        private void Clients_Click(object sender, EventArgs e)
        {
            Form form = OwnedForms.FirstOrDefault(f => f is Clients);
            if (form != null)
            {
                form.WindowState = FormWindowState.Normal;
                form.Activate();
                return;
            }
            form = new Clients();
            form.Show(this);
        }

        private void Reservation_Click(object sender, EventArgs e)
        {
            Form form = OwnedForms.FirstOrDefault(f => f is Reservations);
            if (form != null)
            {
                form.WindowState = FormWindowState.Normal;
                form.Activate();
                return;
            }
            form = new Reservations();
            form.Show(this);
        }

        private void Queryes_Click(object sender, EventArgs e)
        {
            Form form = OwnedForms.FirstOrDefault(f => f is Queryes);
            if (form != null)
            {
                form.WindowState = FormWindowState.Normal;
                form.Activate();
                return;
            }
            form = new Queryes();
            form.Show(this);
        }
    }
}
