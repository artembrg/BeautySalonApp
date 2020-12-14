using System.Data;
using System.Data.SqlClient;

namespace BeautySalon
{
    partial class Form3
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

        static string connectionString = @"Data Source=ARTEM-PC\SQLEXPRESS;Initial Catalog=BeautySalon;Integrated Security=True";

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.emplChoiceInput = new System.Windows.Forms.ComboBox();
            this.servChoiceInput = new System.Windows.Forms.ComboBox();
            this.logTime = new System.Windows.Forms.Label();
            this.logMinutesInput = new System.Windows.Forms.TextBox();
            this.logHoursInput = new System.Windows.Forms.TextBox();
            this.logDate = new System.Windows.Forms.Label();
            this.logYearInput = new System.Windows.Forms.TextBox();
            this.logMonthInput = new System.Windows.Forms.TextBox();
            this.logDayInput = new System.Windows.Forms.TextBox();
            this.emplChoice = new System.Windows.Forms.Label();
            this.servChoice = new System.Windows.Forms.Label();
            this.clientPhone = new System.Windows.Forms.Label();
            this.phoneInput = new System.Windows.Forms.TextBox();
            this.firstSymb = new System.Windows.Forms.Label();
            this.alert = new System.Windows.Forms.Label();
            this.clientFIO = new System.Windows.Forms.Label();
            this.clientFIOInput = new System.Windows.Forms.TextBox();
            this.birthday = new System.Windows.Forms.Label();
            this.clientYearInput = new System.Windows.Forms.TextBox();
            this.clientMonthInput = new System.Windows.Forms.TextBox();
            this.clientDayInput = new System.Windows.Forms.TextBox();
            this.addLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // emplChoiceInput
            // 
            this.emplChoiceInput.FormattingEnabled = true;
            this.emplChoiceInput.Location = new System.Drawing.Point(572, 99);
            this.emplChoiceInput.Name = "emplChoiceInput";
            this.emplChoiceInput.Size = new System.Drawing.Size(170, 21);
            this.emplChoiceInput.TabIndex = 0;
            this.emplChoiceInput.SelectedIndexChanged += new System.EventHandler(this.emplChoiceInput_SelectedIndexChanged);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from EmployeesID", connection);
                DataSet ds = new DataSet();
                sqlDataAdapter.Fill(ds, "EmployeesID");
                DataTable EmplID = ds.Tables["EmployeesID"];
                foreach (DataRow dr in EmplID.Rows)
                {
                    var IDFIO = dr.ItemArray;
                    emplChoiceInput.Items.Add(IDFIO[0] + ". " + IDFIO[1]);
                }
            }
            // 
            // servChoiceInput
            // 
            this.servChoiceInput.FormattingEnabled = true;
            this.servChoiceInput.Location = new System.Drawing.Point(572, 139);
            this.servChoiceInput.Name = "servChoiceInput";
            this.servChoiceInput.Size = new System.Drawing.Size(170, 21);
            this.servChoiceInput.TabIndex = 1;
            // 
            // logTime
            // 
            this.logTime.AutoSize = true;
            this.logTime.Location = new System.Drawing.Point(569, 202);
            this.logTime.Name = "logTime";
            this.logTime.Size = new System.Drawing.Size(81, 13);
            this.logTime.TabIndex = 25;
            this.logTime.Text = "Время приема";
            // 
            // logMinutesInput
            // 
            this.logMinutesInput.BackColor = System.Drawing.Color.White;
            this.logMinutesInput.Location = new System.Drawing.Point(609, 218);
            this.logMinutesInput.Name = "logMinutesInput";
            this.logMinutesInput.Size = new System.Drawing.Size(31, 20);
            this.logMinutesInput.TabIndex = 24;
            this.logMinutesInput.Text = "mm";
            this.logMinutesInput.Click += new System.EventHandler(this.logMinutesInput_Click);
            this.logMinutesInput.Leave += new System.EventHandler(this.logMinutesInput_Leave);
            // 
            // logHoursInput
            // 
            this.logHoursInput.Location = new System.Drawing.Point(572, 218);
            this.logHoursInput.Name = "logHoursInput";
            this.logHoursInput.Size = new System.Drawing.Size(31, 20);
            this.logHoursInput.TabIndex = 23;
            this.logHoursInput.Text = "hh";
            this.logHoursInput.Click += new System.EventHandler(this.logHoursInput_Click);
            this.logHoursInput.Leave += new System.EventHandler(this.logHoursInput_Leave);
            // 
            // logDate
            // 
            this.logDate.AutoSize = true;
            this.logDate.Location = new System.Drawing.Point(569, 163);
            this.logDate.Name = "logDate";
            this.logDate.Size = new System.Drawing.Size(74, 13);
            this.logDate.TabIndex = 22;
            this.logDate.Text = "Дата приема";
            // 
            // logYearInput
            // 
            this.logYearInput.Location = new System.Drawing.Point(646, 179);
            this.logYearInput.Name = "logYearInput";
            this.logYearInput.Size = new System.Drawing.Size(47, 20);
            this.logYearInput.TabIndex = 21;
            this.logYearInput.Text = "yyyy";
            this.logYearInput.Click += new System.EventHandler(this.logYearInput_Click);
            this.logYearInput.Leave += new System.EventHandler(this.logYearInput_Leave);
            // 
            // logMonthInput
            // 
            this.logMonthInput.BackColor = System.Drawing.Color.White;
            this.logMonthInput.Location = new System.Drawing.Point(609, 179);
            this.logMonthInput.Name = "logMonthInput";
            this.logMonthInput.Size = new System.Drawing.Size(31, 20);
            this.logMonthInput.TabIndex = 20;
            this.logMonthInput.Text = "mm";
            this.logMonthInput.Click += new System.EventHandler(this.logMonthInput_Click);
            this.logMonthInput.Leave += new System.EventHandler(this.logMonthInput_Leave);
            // 
            // logDayInput
            // 
            this.logDayInput.Location = new System.Drawing.Point(572, 179);
            this.logDayInput.Name = "logDayInput";
            this.logDayInput.Size = new System.Drawing.Size(31, 20);
            this.logDayInput.TabIndex = 19;
            this.logDayInput.Text = "dd";
            this.logDayInput.Click += new System.EventHandler(this.logDayInput_Click);
            this.logDayInput.Leave += new System.EventHandler(this.logDayInput_Leave);
            // 
            // emplChoice
            // 
            this.emplChoice.AutoSize = true;
            this.emplChoice.Location = new System.Drawing.Point(569, 83);
            this.emplChoice.Name = "emplChoice";
            this.emplChoice.Size = new System.Drawing.Size(96, 13);
            this.emplChoice.TabIndex = 26;
            this.emplChoice.Text = "Выбор работника";
            // 
            // servChoice
            // 
            this.servChoice.AutoSize = true;
            this.servChoice.Location = new System.Drawing.Point(569, 123);
            this.servChoice.Name = "servChoice";
            this.servChoice.Size = new System.Drawing.Size(76, 13);
            this.servChoice.TabIndex = 27;
            this.servChoice.Text = "Выбор услуги";
            // 
            // clientPhone
            // 
            this.clientPhone.AutoSize = true;
            this.clientPhone.Location = new System.Drawing.Point(12, 83);
            this.clientPhone.Name = "clientPhone";
            this.clientPhone.Size = new System.Drawing.Size(115, 13);
            this.clientPhone.TabIndex = 28;
            this.clientPhone.Text = "Ваш номер телефона";
            // 
            // phoneInput
            // 
            this.phoneInput.Location = new System.Drawing.Point(37, 96);
            this.phoneInput.Name = "phoneInput";
            this.phoneInput.Size = new System.Drawing.Size(100, 20);
            this.phoneInput.TabIndex = 29;
            this.phoneInput.Leave += new System.EventHandler(this.phoneInput_Leave);
            // 
            // firstSymb
            // 
            this.firstSymb.AutoSize = true;
            this.firstSymb.Location = new System.Drawing.Point(12, 99);
            this.firstSymb.Name = "firstSymb";
            this.firstSymb.Size = new System.Drawing.Size(22, 13);
            this.firstSymb.TabIndex = 30;
            this.firstSymb.Text = "+7-";
            // 
            // alert
            // 
            this.alert.AutoSize = true;
            this.alert.Location = new System.Drawing.Point(12, 139);
            this.alert.Name = "alert";
            this.alert.Size = new System.Drawing.Size(437, 13);
            this.alert.TabIndex = 31;
            this.alert.Text = "Если Вы записываетесь в первый раз, укажите, пожалуйста, дату рождения и ФИО";
            // 
            // clientFIO
            // 
            this.clientFIO.AutoSize = true;
            this.clientFIO.Location = new System.Drawing.Point(12, 163);
            this.clientFIO.Name = "clientFIO";
            this.clientFIO.Size = new System.Drawing.Size(62, 13);
            this.clientFIO.TabIndex = 32;
            this.clientFIO.Text = "Ввод ФИО";
            // 
            // clientFIOInput
            // 
            this.clientFIOInput.Location = new System.Drawing.Point(12, 179);
            this.clientFIOInput.Multiline = true;
            this.clientFIOInput.Name = "clientFIOInput";
            this.clientFIOInput.Size = new System.Drawing.Size(178, 59);
            this.clientFIOInput.TabIndex = 33;
            // 
            // birthday
            // 
            this.birthday.AutoSize = true;
            this.birthday.Location = new System.Drawing.Point(193, 163);
            this.birthday.Name = "birthday";
            this.birthday.Size = new System.Drawing.Size(86, 13);
            this.birthday.TabIndex = 37;
            this.birthday.Text = "Дата рождения";
            // 
            // clientYearInput
            // 
            this.clientYearInput.Location = new System.Drawing.Point(270, 179);
            this.clientYearInput.Name = "clientYearInput";
            this.clientYearInput.Size = new System.Drawing.Size(47, 20);
            this.clientYearInput.TabIndex = 36;
            this.clientYearInput.Text = "yyyy";
            this.clientYearInput.Click += new System.EventHandler(this.clientYearInput_Click);
            this.clientYearInput.Leave += new System.EventHandler(this.clientYearInput_Leave);
            // 
            // clientMonthInput
            // 
            this.clientMonthInput.BackColor = System.Drawing.Color.White;
            this.clientMonthInput.Location = new System.Drawing.Point(233, 179);
            this.clientMonthInput.Name = "clientMonthInput";
            this.clientMonthInput.Size = new System.Drawing.Size(31, 20);
            this.clientMonthInput.TabIndex = 35;
            this.clientMonthInput.Text = "mm";
            this.clientMonthInput.Click += new System.EventHandler(this.clientMonthInput_Click);
            this.clientMonthInput.Leave += new System.EventHandler(this.clientMonthInput_Leave);
            // 
            // clientDayInput
            // 
            this.clientDayInput.Location = new System.Drawing.Point(196, 179);
            this.clientDayInput.Name = "clientDayInput";
            this.clientDayInput.Size = new System.Drawing.Size(31, 20);
            this.clientDayInput.TabIndex = 34;
            this.clientDayInput.Text = "dd";
            this.clientDayInput.Click += new System.EventHandler(this.clientDayInput_Click);
            this.clientDayInput.Leave += new System.EventHandler(this.clientDayInput_Leave);
            // 
            // addLog
            // 
            this.addLog.Location = new System.Drawing.Point(572, 244);
            this.addLog.Name = "addLog";
            this.addLog.Size = new System.Drawing.Size(170, 23);
            this.addLog.TabIndex = 38;
            this.addLog.Text = "Записаться";
            this.addLog.UseVisualStyleBackColor = true;
            this.addLog.Click += new System.EventHandler(this.addLog_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.addLog);
            this.Controls.Add(this.birthday);
            this.Controls.Add(this.clientYearInput);
            this.Controls.Add(this.clientMonthInput);
            this.Controls.Add(this.clientDayInput);
            this.Controls.Add(this.clientFIOInput);
            this.Controls.Add(this.clientFIO);
            this.Controls.Add(this.alert);
            this.Controls.Add(this.phoneInput);
            this.Controls.Add(this.firstSymb);
            this.Controls.Add(this.clientPhone);
            this.Controls.Add(this.servChoice);
            this.Controls.Add(this.emplChoice);
            this.Controls.Add(this.logTime);
            this.Controls.Add(this.logMinutesInput);
            this.Controls.Add(this.logHoursInput);
            this.Controls.Add(this.logDate);
            this.Controls.Add(this.logYearInput);
            this.Controls.Add(this.logMonthInput);
            this.Controls.Add(this.logDayInput);
            this.Controls.Add(this.servChoiceInput);
            this.Controls.Add(this.emplChoiceInput);
            this.Name = "Form3";
            this.Text = "Запись на услугу";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form3_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox emplChoiceInput;
        private System.Windows.Forms.ComboBox servChoiceInput;
        private System.Windows.Forms.Label logTime;
        private System.Windows.Forms.TextBox logMinutesInput;
        private System.Windows.Forms.TextBox logHoursInput;
        private System.Windows.Forms.Label logDate;
        private System.Windows.Forms.TextBox logYearInput;
        private System.Windows.Forms.TextBox logMonthInput;
        private System.Windows.Forms.TextBox logDayInput;
        private System.Windows.Forms.Label emplChoice;
        private System.Windows.Forms.Label servChoice;
        private System.Windows.Forms.Label clientPhone;
        private System.Windows.Forms.TextBox phoneInput;
        private System.Windows.Forms.Label firstSymb;
        private System.Windows.Forms.Label alert;
        private System.Windows.Forms.Label clientFIO;
        private System.Windows.Forms.TextBox clientFIOInput;
        private System.Windows.Forms.Label birthday;
        private System.Windows.Forms.TextBox clientYearInput;
        private System.Windows.Forms.TextBox clientMonthInput;
        private System.Windows.Forms.TextBox clientDayInput;
        private System.Windows.Forms.Button addLog;
    }
}