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
    public partial class WorkerForm : Form
    {
        public WorkerForm()
        {
            InitializeComponent();
        }

        private void WorkerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
                return;

            e.Cancel = lastName.Text == "" || firstName.Text == "" || middleName.Text == "" || position.Text == "";
            if (e.Cancel)
                MessageBox.Show("Были введены не все данные");
        }
    }
}
