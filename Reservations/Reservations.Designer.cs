
namespace Hotel
{
    partial class Reservations
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Worker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Room = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Client = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnterDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExitDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.WorkerId,
            this.RoomId,
            this.ClientId,
            this.Worker,
            this.Room,
            this.Client,
            this.EnterDate,
            this.ExitDate,
            this.Price});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(484, 267);
            this.dataGridView.TabIndex = 2;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // WorkerId
            // 
            this.WorkerId.HeaderText = "WorkerId";
            this.WorkerId.Name = "WorkerId";
            this.WorkerId.ReadOnly = true;
            this.WorkerId.Visible = false;
            // 
            // RoomId
            // 
            this.RoomId.HeaderText = "RoomId";
            this.RoomId.Name = "RoomId";
            this.RoomId.ReadOnly = true;
            this.RoomId.Visible = false;
            // 
            // ClientId
            // 
            this.ClientId.HeaderText = "ClientId";
            this.ClientId.Name = "ClientId";
            this.ClientId.ReadOnly = true;
            this.ClientId.Visible = false;
            // 
            // Worker
            // 
            this.Worker.HeaderText = "Сотрудник";
            this.Worker.Name = "Worker";
            this.Worker.ReadOnly = true;
            // 
            // Room
            // 
            this.Room.HeaderText = "Номер";
            this.Room.Name = "Room";
            this.Room.ReadOnly = true;
            // 
            // Client
            // 
            this.Client.HeaderText = "Клиент";
            this.Client.Name = "Client";
            this.Client.ReadOnly = true;
            // 
            // EnterDate
            // 
            this.EnterDate.HeaderText = "Дата въезда";
            this.EnterDate.Name = "EnterDate";
            this.EnterDate.ReadOnly = true;
            // 
            // ExitDate
            // 
            this.ExitDate.HeaderText = "Дата выезда";
            this.ExitDate.Name = "ExitDate";
            this.ExitDate.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.HeaderText = "Стоимость";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.button4);
            this.panel.Controls.Add(this.DeleteButton);
            this.panel.Controls.Add(this.EditButton);
            this.panel.Controls.Add(this.AddButton);
            this.panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel.Location = new System.Drawing.Point(0, 267);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(484, 44);
            this.panel.TabIndex = 3;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(397, 9);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Закрыть";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Close_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(174, 9);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 2;
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(93, 9);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(75, 23);
            this.EditButton.TabIndex = 1;
            this.EditButton.Text = "Изменить";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(12, 9);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // Reservations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 311);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panel);
            this.MinimumSize = new System.Drawing.Size(400, 250);
            this.Name = "Reservations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Бронь";
            this.Load += new System.EventHandler(this.Reservations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Worker;
        private System.Windows.Forms.DataGridViewTextBoxColumn Room;
        private System.Windows.Forms.DataGridViewTextBoxColumn Client;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnterDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExitDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
    }
}