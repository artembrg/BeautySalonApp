using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeautySalon
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public Form3(Form1 f)
        {
            InitializeComponent();
        }

        private void day_Validate(int day_num, int year_num, ref TextBox r_day, TextBox r_month)
        {
            if (day_num <= 28 && r_month.Text == "02") r_day.BackColor = Color.White;
            else if (day_num <= 29 && r_month.Text == "02" && (year_num % 4 == 0 && year_num % 100 != 0 || year_num % 400 == 0)) r_day.BackColor = Color.White;
            else if (r_month.Text == "04" || r_month.Text == "06" || r_month.Text == "09" || r_month.Text == "11" && day_num <= 30) r_day.BackColor = Color.White;
            else if (r_month.Text == "01" || r_month.Text == "03" || r_month.Text == "05" || r_month.Text == "07" || r_month.Text == "08" || r_month.Text == "10" || r_month.Text == "12" && day_num <= 31) r_day.BackColor = Color.White;
            else r_day.BackColor = Color.Salmon;
        }

        private void month_Validate(int month_num, ref TextBox r_month)
        {
            if (month_num <= 12) r_month.BackColor = Color.White;
            else r_month.BackColor = Color.Salmon;
        }


        private void year_Validate(ref TextBox r_year)
        {
            r_year.BackColor = Color.White;
        }

        private void logDayInput_Click(object sender, EventArgs e)
        {
            int day_num = 0;
            if (!int.TryParse(logDayInput.Text, out day_num) || day_num > 31)
                logDayInput.Text = "";
        }

        private void logMonthInput_Click(object sender, EventArgs e)
        {
            int month_num = 0;
            if (!int.TryParse(logMonthInput.Text, out month_num) || month_num > 12)
                logMonthInput.Text = "";
        }

        private void logYearInput_Click(object sender, EventArgs e)
        {
            int year_num = 0;
            if (!int.TryParse(logYearInput.Text, out year_num))
                logYearInput.Text = "";
        }

        private void logDayInput_Leave(object sender, EventArgs e)
        {
            try
            {
                int day_num = int.Parse(logDayInput.Text);
                if (day_num > 31)
                {
                    logDayInput.Text = "";
                    throw new FormatException();
                }
                int month_num = int.Parse(logMonthInput.Text);
                int year_num = int.Parse(logYearInput.Text);
                day_Validate(day_num, year_num, ref logDayInput, logMonthInput);
                month_Validate(month_num, ref logMonthInput);
                year_Validate(ref logYearInput);
            }
            catch (FormatException)
            {
                logDayInput.BackColor = Color.Salmon;
            }
        }

        private void logMonthInput_Leave(object sender, EventArgs e)
        {
            try
            {
                int month_num = int.Parse(logMonthInput.Text);
                int day_num = int.Parse(logDayInput.Text);
                if (month_num > 12)
                {
                    logMonthInput.Text = "";
                    throw new FormatException();
                }
                int year_num = int.Parse(logYearInput.Text);
                day_Validate(day_num, year_num, ref logDayInput, logMonthInput);
                month_Validate(month_num, ref logMonthInput);
                year_Validate(ref logYearInput);
            }
            catch (FormatException)
            {
                logMonthInput.BackColor = Color.Salmon;
            }
        }

        private void logYearInput_Leave(object sender, EventArgs e)
        {
            try
            {
                int day_num = int.Parse(logDayInput.Text);
                int month_num = int.Parse(logMonthInput.Text);
                int year_num = int.Parse(logYearInput.Text);
                day_Validate(day_num, year_num, ref logDayInput, logMonthInput);
                month_Validate(month_num, ref logMonthInput);
                year_Validate(ref logYearInput);
            }
            catch (FormatException)
            {
                logYearInput.BackColor = Color.Salmon;
            }
        }

        private void logHoursInput_Click(object sender, EventArgs e)
        {
            int hours_num = 0;
            if (!int.TryParse(logHoursInput.Text, out hours_num))
                logHoursInput.Text = "";
        }

        private void logMinutesInput_Click(object sender, EventArgs e)
        {
            int minutes_num = 0;
            if (!int.TryParse(logMinutesInput.Text, out minutes_num))
                logMinutesInput.Text = "";
        }

        private void logHoursInput_Leave(object sender, EventArgs e)
        {
            try
            {
                int hours_num = int.Parse(logHoursInput.Text);
                if (hours_num > 23) throw new FormatException();
                else logHoursInput.BackColor = Color.White;
            }
            catch (FormatException)
            {
                logHoursInput.BackColor = Color.Salmon;
            }
        }

        private void logMinutesInput_Leave(object sender, EventArgs e)
        {
            try
            {
                int minutes_num = int.Parse(logMinutesInput.Text);
                if (minutes_num > 59) throw new FormatException();
                else logMinutesInput.BackColor = Color.White;
            }
            catch (FormatException)
            {
                logMinutesInput.BackColor = Color.Salmon;
            }
        }

        private void phoneInput_Leave(object sender, EventArgs e)
        {
            if (phoneInput.Text.Length != 10) phoneInput.BackColor = Color.Salmon;
            else phoneInput.BackColor = Color.White;
        }

        private void clientDayInput_Click(object sender, EventArgs e)
        {
            int day_num = 0;
            if (!int.TryParse(clientDayInput.Text, out day_num) || day_num > 31)
                clientDayInput.Text = "";
        }

        private void clientMonthInput_Click(object sender, EventArgs e)
        {
            int month_num = 0;
            if (!int.TryParse(clientMonthInput.Text, out month_num) || month_num > 12)
                clientMonthInput.Text = "";
        }

        private void clientYearInput_Click(object sender, EventArgs e)
        {
            int year_num = 0;
            if (!int.TryParse(clientYearInput.Text, out year_num))
                clientYearInput.Text = "";
        }

        private void clientDayInput_Leave(object sender, EventArgs e)
        {
            try
            {
                int day_num = int.Parse(clientDayInput.Text);
                if (day_num > 31)
                {
                    clientDayInput.Text = "";
                    throw new FormatException();
                }
                int month_num = int.Parse(clientMonthInput.Text);
                int year_num = int.Parse(clientYearInput.Text);
                day_Validate(day_num, year_num, ref clientDayInput, clientMonthInput);
                month_Validate(month_num, ref clientMonthInput);
                year_Validate(ref clientYearInput);
            }
            catch (FormatException)
            {
                clientDayInput.BackColor = Color.Salmon;
            }
        }

        private void clientMonthInput_Leave(object sender, EventArgs e)
        {
            try
            {
                int month_num = int.Parse(clientMonthInput.Text);
                int day_num = int.Parse(clientDayInput.Text);
                if (month_num > 12)
                {
                    clientMonthInput.Text = "";
                    throw new FormatException();
                }
                int year_num = int.Parse(clientYearInput.Text);
                day_Validate(day_num, year_num, ref clientDayInput, clientMonthInput);
                month_Validate(month_num, ref clientMonthInput);
                year_Validate(ref clientYearInput);
            }
            catch (FormatException)
            {
                clientMonthInput.BackColor = Color.Salmon;
            }
        }

        private void clientYearInput_Leave(object sender, EventArgs e)
        {
            try
            {
                int day_num = int.Parse(clientDayInput.Text);
                int month_num = int.Parse(clientMonthInput.Text);
                int year_num = int.Parse(clientYearInput.Text);
                day_Validate(day_num, year_num, ref clientDayInput, clientMonthInput);
                month_Validate(month_num, ref clientMonthInput);
                year_Validate(ref clientYearInput);
            }
            catch (FormatException)
            {
                clientYearInput.BackColor = Color.Salmon;
            }
        }

        private void emplChoiceInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            servChoiceInput.Items.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select service from Prices where master_id = " + emplChoiceInput.Text.Split('.')[0], connection);
                DataSet ds = new DataSet();
                sqlDataAdapter.Fill(ds, "PricesServ");
                DataTable Prices = ds.Tables["PricesServ"];
                foreach (DataRow dr in Prices.Rows)
                {
                    var service = dr.ItemArray;
                    servChoiceInput.Items.Add(service[0]);
                }
            }
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form f1 = Application.OpenForms[0];
            f1.Close();
        }

        private void addLog_Click(object sender, EventArgs e)
        {
            bool isPhExists = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (phoneInput.Text != "" && phoneInput.BackColor == Color.White) {
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select phone from Clients", connection);
                    DataSet ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "ClientsPh");
                    DataTable Phones = ds.Tables["ClientsPh"];
                    foreach (DataRow dr in Phones.Rows)
                    {
                        var ph = dr.ItemArray;
                        isPhExists = (String.Equals("8" + phoneInput.Text, ph[0]));
                        if (isPhExists) break;
                    }
                    if (isPhExists && emplChoiceInput.Text != "" && servChoiceInput.Text != "" && logDayInput.Text != "dd" && logMonthInput.Text != "mm" && logYearInput.Text != "yyyy" &&
                        logHoursInput.Text != "hh" && logMinutesInput.Text != "mm" && logDayInput.BackColor == Color.White && logMonthInput.BackColor == Color.White && logYearInput.BackColor == Color.White &&
                        logHoursInput.BackColor == Color.White && logMonthInput.BackColor == Color.White)
                    {
                        sqlDataAdapter = new SqlDataAdapter("Select client_id from Clients where phone = 8" + phoneInput.Text, connection);
                        ds = new DataSet();
                        sqlDataAdapter.Fill(ds, "ClID");
                        DataTable ClID = ds.Tables["ClID"];
                        int id = 0;
                        foreach (DataRow dr in ClID.Rows)
                        {
                            var ClIDFound = dr.ItemArray;
                            id = (int)ClIDFound[0];
                        }
                        String sqlExpression = "AddLog";
                        connection.Open();
                        SqlCommand command = new SqlCommand(sqlExpression, connection);
                        command.CommandType = CommandType.StoredProcedure;
                        SqlParameter masterID = new SqlParameter
                        {
                            ParameterName = "@master_id",
                            Value = int.Parse(emplChoiceInput.Text.Split('.')[0])
                        };
                        command.Parameters.Add(masterID);
                        SqlParameter clientID = new SqlParameter
                        {
                            ParameterName = "@client_id",
                            Value = id
                        };
                        command.Parameters.Add(clientID);
                        SqlParameter date = new SqlParameter
                        {
                            ParameterName = "@date",
                            Value = logYearInput.Text + "-" + logMonthInput.Text + "-" + logDayInput.Text
                        };
                        command.Parameters.Add(date);
                        SqlParameter time = new SqlParameter
                        {
                            ParameterName = "@time",
                            Value = logHoursInput.Text + ":" + logMinutesInput.Text
                        };
                        command.Parameters.Add(time);
                        SqlParameter service = new SqlParameter
                        {
                            ParameterName = "@service",
                            Value = servChoiceInput.Text
                        };
                        command.Parameters.Add(service);
                        command.ExecuteNonQuery();
                        alert.Text = "Запись прошла успешно";
                    }
                    else if (!isPhExists && emplChoiceInput.Text != "" && servChoiceInput.Text != "" && logDayInput.Text != "dd" && logMonthInput.Text != "mm" && logYearInput.Text != "yyyy" &&
                        logHoursInput.Text != "hh" && logMinutesInput.Text != "mm" && logDayInput.BackColor == Color.White && logMonthInput.BackColor == Color.White && logYearInput.BackColor == Color.White &&
                        logHoursInput.BackColor == Color.White && logMonthInput.BackColor == Color.White && clientFIOInput.Text != "" && clientDayInput.Text != "dd" && clientMonthInput.Text != "mm" &&
                        clientYearInput.Text != "yyyy" && clientDayInput.BackColor == Color.White && clientMonthInput.BackColor == Color.White && clientYearInput.BackColor == Color.White)
                    {
                        String sqlExpression = "AddClient";
                        connection.Open();
                        SqlCommand command = new SqlCommand(sqlExpression, connection);
                        command.CommandType = CommandType.StoredProcedure;
                        SqlParameter FIOParam = new SqlParameter
                        {
                            ParameterName = "@FIO_cl",
                            Value = clientFIOInput.Text
                        };
                        command.Parameters.Add(FIOParam);
                        SqlParameter birthday = new SqlParameter
                        {
                            ParameterName = "@birthday",
                            Value = clientYearInput.Text + "-" + clientMonthInput.Text + "-" + clientDayInput.Text
                        };
                        command.Parameters.Add(birthday);
                        SqlParameter phoneParam = new SqlParameter
                        {
                            ParameterName = "@phone",
                            Value = "8" + phoneInput.Text
                        };
                        command.Parameters.Add(phoneParam);
                        command.ExecuteNonQuery();
                        sqlDataAdapter = new SqlDataAdapter("Select client_id from Clients where phone = 8" + phoneInput.Text, connection);
                        ds = new DataSet();
                        sqlDataAdapter.Fill(ds, "ClID");
                        DataTable ClID = ds.Tables["ClID"];
                        int id = 0;
                        foreach (DataRow dr in ClID.Rows)
                        {
                            var ClIDFound = dr.ItemArray;
                            id = (int)ClIDFound[0];
                        }
                        sqlExpression = "AddLog";
                        connection.Open();
                        command = new SqlCommand(sqlExpression, connection);
                        command.CommandType = CommandType.StoredProcedure;
                        SqlParameter masterID = new SqlParameter
                        {
                            ParameterName = "@master_id",
                            Value = int.Parse(emplChoiceInput.Text.Split('.')[0])
                        };
                        command.Parameters.Add(masterID);
                        SqlParameter clientID = new SqlParameter
                        {
                            ParameterName = "@client_id",
                            Value = id
                        };
                        command.Parameters.Add(clientID);
                        SqlParameter date = new SqlParameter
                        {
                            ParameterName = "@date",
                            Value = logYearInput.Text + "-" + logMonthInput.Text + "-" + logDayInput.Text
                        };
                        command.Parameters.Add(date);
                        SqlParameter time = new SqlParameter
                        {
                            ParameterName = "@time",
                            Value = logHoursInput.Text + ":" + logMinutesInput.Text
                        };
                        command.Parameters.Add(time);
                        SqlParameter service = new SqlParameter
                        {
                            ParameterName = "@service",
                            Value = servChoiceInput.Text
                        };
                        command.Parameters.Add(service);
                        command.ExecuteNonQuery();
                        alert.Text = "Запись прошла успешно, новый клиент добавлен";
                    }
                    else
                    {
                        alert.Text = "Невалидные данные, запись не удалась";
                    }
                }
            }
        }
    }
}
