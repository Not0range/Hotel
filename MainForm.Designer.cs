
namespace Hotel
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Rooms = new System.Windows.Forms.Button();
            this.Workers = new System.Windows.Forms.Button();
            this.Reservation = new System.Windows.Forms.Button();
            this.Queryes = new System.Windows.Forms.Button();
            this.Clients = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Rooms
            // 
            this.Rooms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Rooms.Location = new System.Drawing.Point(12, 12);
            this.Rooms.Name = "Rooms";
            this.Rooms.Size = new System.Drawing.Size(356, 23);
            this.Rooms.TabIndex = 2;
            this.Rooms.Text = "Номера";
            this.Rooms.UseVisualStyleBackColor = true;
            this.Rooms.Click += new System.EventHandler(this.Rooms_Click);
            // 
            // Workers
            // 
            this.Workers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Workers.Location = new System.Drawing.Point(12, 41);
            this.Workers.Name = "Workers";
            this.Workers.Size = new System.Drawing.Size(356, 23);
            this.Workers.TabIndex = 2;
            this.Workers.Text = "Сотрудники";
            this.Workers.UseVisualStyleBackColor = true;
            this.Workers.Click += new System.EventHandler(this.Workers_Click);
            // 
            // Reservation
            // 
            this.Reservation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Reservation.Location = new System.Drawing.Point(12, 99);
            this.Reservation.Name = "Reservation";
            this.Reservation.Size = new System.Drawing.Size(356, 23);
            this.Reservation.TabIndex = 2;
            this.Reservation.Text = "Бронь";
            this.Reservation.UseVisualStyleBackColor = true;
            this.Reservation.Click += new System.EventHandler(this.Reservation_Click);
            // 
            // Queryes
            // 
            this.Queryes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Queryes.Location = new System.Drawing.Point(12, 128);
            this.Queryes.Name = "Queryes";
            this.Queryes.Size = new System.Drawing.Size(356, 23);
            this.Queryes.TabIndex = 2;
            this.Queryes.Text = "Запросы";
            this.Queryes.UseVisualStyleBackColor = true;
            this.Queryes.Click += new System.EventHandler(this.Queryes_Click);
            // 
            // Clients
            // 
            this.Clients.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Clients.Location = new System.Drawing.Point(12, 70);
            this.Clients.Name = "Clients";
            this.Clients.Size = new System.Drawing.Size(356, 23);
            this.Clients.TabIndex = 2;
            this.Clients.Text = "Клиенты";
            this.Clients.UseVisualStyleBackColor = true;
            this.Clients.Click += new System.EventHandler(this.Clients_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.Queryes);
            this.Controls.Add(this.Reservation);
            this.Controls.Add(this.Clients);
            this.Controls.Add(this.Workers);
            this.Controls.Add(this.Rooms);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Гостиница";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Rooms;
        private System.Windows.Forms.Button Workers;
        private System.Windows.Forms.Button Reservation;
        private System.Windows.Forms.Button Queryes;
        private System.Windows.Forms.Button Clients;
    }
}

