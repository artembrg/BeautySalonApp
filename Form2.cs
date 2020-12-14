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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Form1 f)
        {
            InitializeComponent();
        }

        static string connectionString = @"Data Source=ARTEM-PC\SQLEXPRESS;Initial Catalog=BeautySalon;Integrated Security=True";
        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "beautySalonDataSet.SalesID". При необходимости она может быть перемещена или удалена.
            this.salesIDTableAdapter.Fill(this.beautySalonDataSet.SalesID);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "beautySalonDataSet.SalesJournal". При необходимости она может быть перемещена или удалена.
            this.salesJournalTableAdapter.Fill(this.beautySalonDataSet.SalesJournal);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "beautySalonDataSet.MaterialsList". При необходимости она может быть перемещена или удалена.
            this.materialsListTableAdapter.Fill(this.beautySalonDataSet.MaterialsList);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "beautySalonDataSet.LogID". При необходимости она может быть перемещена или удалена.
            this.logIDTableAdapter.Fill(this.beautySalonDataSet.LogID);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "beautySalonDataSet.LogID". При необходимости она может быть перемещена или удалена.
            this.logIDTableAdapter.Fill(this.beautySalonDataSet.LogID);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "beautySalonDataSet.LogJournal". При необходимости она может быть перемещена или удалена.
            this.logJournalTableAdapter.Fill(this.beautySalonDataSet.LogJournal);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "beautySalonDataSet.PriceList". При необходимости она может быть перемещена или удалена.
            this.priceListTableAdapter.Fill(this.beautySalonDataSet.PriceList);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "beautySalonDataSet.ClientsID". При необходимости она может быть перемещена или удалена.
            this.clientsIDTableAdapter.Fill(this.beautySalonDataSet.ClientsID);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "beautySalonDataSet.ClientsList". При необходимости она может быть перемещена или удалена.
            this.clientsListTableAdapter.Fill(this.beautySalonDataSet.ClientsList);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "beautySalonDataSet.EmployeesID". При необходимости она может быть перемещена или удалена.
            this.employeesIDTableAdapter.Fill(this.beautySalonDataSet.EmployeesID);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "beautySalonDataSet.PersonalList". При необходимости она может быть перемещена или удалена.
            this.personalListTableAdapter.Fill(this.beautySalonDataSet.PersonalList);

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

        private void day_Click(object sender, EventArgs e)
        {
            int day_num = 0;
            if (!int.TryParse(day.Text, out day_num) || day_num > 31)
            day.Text = "";
        }

        private void month_Click(object sender, EventArgs e)
        {
            int month_num = 0;
            if (!int.TryParse(month.Text, out month_num) || month_num > 12)
            month.Text = "";
        }

        private void year_Click(object sender, EventArgs e)
        {
            int year_num = 0;
            if (!int.TryParse(year.Text, out year_num))
            year.Text = "";
        }

        private void day_Leave(object sender, EventArgs e)
        {
            try
            {
                int day_num = int.Parse(day.Text);
                if (day_num > 31)
                {
                    day.Text = "";
                    throw new FormatException();
                }
                int month_num = int.Parse(month.Text);
                int year_num = int.Parse(year.Text);
                day_Validate(day_num, year_num, ref day, month);
                month_Validate(month_num, ref month);
                year_Validate(ref year);
            }
            catch (FormatException)
            {
                day.BackColor = Color.Salmon;
            }
        }

        private void month_Leave(object sender, EventArgs e)
        {
            try
            {
                int month_num = int.Parse(month.Text);
                int day_num = int.Parse(day.Text);
                if (month_num > 12)
                {
                    month.Text = "";
                    throw new FormatException();
                }
                int year_num = int.Parse(year.Text);
                day_Validate(day_num, year_num, ref day, month);
                month_Validate(month_num, ref month);
                year_Validate(ref year);
            }
            catch (FormatException)
            {
                month.BackColor = Color.Salmon;
            }
        }

        private void year_Leave(object sender, EventArgs e)
        {
            try
            {
                int day_num = int.Parse(day.Text);
                int month_num = int.Parse(month.Text);
                int year_num = int.Parse(year.Text);
                day_Validate(day_num, year_num, ref day, month);
                month_Validate(month_num, ref month);
                year_Validate(ref year);
            }
            catch (FormatException)
            {
                year.BackColor = Color.Salmon;
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form f1 = Application.OpenForms[0];
            f1.Close();
        }

        private void phoneInput_Leave(object sender, EventArgs e)
        {
            try
            {
                Int64 phone_num = Int64.Parse(phoneInput.Text);
                if (phoneInput.Text.Length != 10) phoneInput.BackColor = Color.Salmon;
                else phoneInput.BackColor = Color.White;
            }
            catch (FormatException)
            {
                phoneInput.BackColor = Color.Salmon;
            }
        }

        private void workInput_Leave(object sender, EventArgs e)
        {
            if (workInput.Text.Length > 12) workInput.BackColor = Color.Salmon;
            else workInput.BackColor = Color.White;
        }

        private void salaryInput_Leave(object sender, EventArgs e)
        {
            try
            {
                float salary_num = float.Parse(salaryInput.Text);
                salaryInput.BackColor = Color.White;
            }
            catch (Exception)
            {
                salaryInput.BackColor = Color.Salmon;
            }
        }

        private void expInput_Leave(object sender, EventArgs e)
        {
            try
            {
                int exp_num = int.Parse(expInput.Text);
                expInput.BackColor = Color.White;
            }
            catch (FormatException)
            {
                expInput.BackColor = Color.Salmon;
            }
        }

        private void IDInput_Leave(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(IDInput.Text);
                IDInput.BackColor = Color.White;
            }
            catch (FormatException)
            {
                IDInput.BackColor = Color.Salmon;
            }
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            if (day.BackColor == Color.White && month.BackColor == Color.White && year.BackColor == Color.White &&
                phoneInput.BackColor == Color.White && workInput.BackColor == Color.White &&
                salaryInput.BackColor == Color.White && expInput.BackColor == Color.White &&
                FIO.Text != "" && day.Text != "dd" && month.Text != "mm" && year.Text != "yyyy" &&
                phoneInput.Text != "" && workInput.Text != "" && salaryInput.Text != "" && expInput.Text != "")
            {
                string sqlExpression = "AddEmployee";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter FIOParam = new SqlParameter
                    {
                        ParameterName = "@FIO",
                        Value = FIO.Text
                    };
                    command.Parameters.Add(FIOParam);
                    SqlParameter birthday = new SqlParameter
                    {
                        ParameterName = "@birthday",
                        Value = year.Text + "-" + month.Text + "-" + day.Text
                    };
                    command.Parameters.Add(birthday);
                    SqlParameter phoneParam = new SqlParameter
                    {
                        ParameterName = "@phone",
                        Value = "8" + phoneInput.Text
                    };
                    command.Parameters.Add(phoneParam);
                    SqlParameter workParam = new SqlParameter
                    {
                        ParameterName = "@work",
                        Value = workInput.Text
                    };
                    command.Parameters.Add(workParam);
                    SqlParameter salaryParam = new SqlParameter
                    {
                        ParameterName = "@salary",
                        Value = float.Parse(salaryInput.Text)
                    };
                    command.Parameters.Add(salaryParam);
                    SqlParameter exp = new SqlParameter
                    {
                        ParameterName = "@exp",
                        Value = int.Parse(expInput.Text)
                    };
                    command.Parameters.Add(exp);
                    command.ExecuteNonQuery();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from PersonalList", connection);
                    DataSet ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "PersonalList");
                    personalListDataGridView.DataSource = ds.Tables["PersonalList"];
                    sqlDataAdapter = new SqlDataAdapter("Select * from EmployeesID", connection);
                    ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "EmployeesID");
                    employeesIDDataGridView.DataSource = ds.Tables["EmployeesID"];
                    sqlDataAdapter = new SqlDataAdapter("Select * from EmployeesID", connection);
                    ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "EmployeesID");
                    employeesIDDataGridView1.DataSource = ds.Tables["EmployeesID"];
                }
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (day.BackColor == Color.White && month.BackColor == Color.White && year.BackColor == Color.White &&
                phoneInput.BackColor == Color.White && workInput.BackColor == Color.White &&
                salaryInput.BackColor == Color.White && expInput.BackColor == Color.White && IDInput.BackColor == Color.White &&
                FIO.Text != "" && day.Text != "dd" && month.Text != "mm" && year.Text != "yyyy" && IDInput.Text != "" &&
                phoneInput.Text != "" && workInput.Text != "" && salaryInput.Text != "" && expInput.Text != "")
            {
                string sqlExpression = "UpdateEmployee";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter id = new SqlParameter
                    {
                        ParameterName = "@id",
                        Value = int.Parse(IDInput.Text)
                    };
                    command.Parameters.Add(id);
                    SqlParameter FIOParam = new SqlParameter
                    {
                        ParameterName = "@FIO",
                        Value = FIO.Text
                    };
                    command.Parameters.Add(FIOParam);
                    SqlParameter birthday = new SqlParameter
                    {
                        ParameterName = "@birthday",
                        Value = year.Text + "-" + month.Text + "-" + day.Text
                    };
                    command.Parameters.Add(birthday);
                    SqlParameter phoneParam = new SqlParameter
                    {
                        ParameterName = "@phone",
                        Value = "8" + phoneInput.Text
                    };
                    command.Parameters.Add(phoneParam);
                    SqlParameter workParam = new SqlParameter
                    {
                        ParameterName = "@work",
                        Value = workInput.Text
                    };
                    command.Parameters.Add(workParam);
                    SqlParameter salaryParam = new SqlParameter
                    {
                        ParameterName = "@salary",
                        Value = float.Parse(salaryInput.Text)
                    };
                    command.Parameters.Add(salaryParam);
                    SqlParameter exp = new SqlParameter
                    {
                        ParameterName = "@exp",
                        Value = int.Parse(expInput.Text)
                    };
                    command.Parameters.Add(exp);
                    command.ExecuteNonQuery();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from PersonalList", connection);
                    DataSet ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "PersonalList");
                    personalListDataGridView.DataSource = ds.Tables["PersonalList"];
                    sqlDataAdapter = new SqlDataAdapter("Select * from EmployeesID", connection);
                    ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "EmployeesID");
                    employeesIDDataGridView.DataSource = ds.Tables["EmployeesID"];
                    sqlDataAdapter = new SqlDataAdapter("Select * from EmployeesID", connection);
                    ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "EmployeesID");
                    employeesIDDataGridView1.DataSource = ds.Tables["EmployeesID"];
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (IDInput.BackColor == Color.White && IDInput.Text != "")
            {
                string sqlExpression = "RemoveEmployee";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter id = new SqlParameter
                    {
                        ParameterName = "@id",
                        Value = int.Parse(IDInput.Text)
                    };
                    command.Parameters.Add(id);
                    command.ExecuteNonQuery();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from PersonalList", connection);
                    DataSet ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "PersonalList");
                    personalListDataGridView.DataSource = ds.Tables["PersonalList"];
                    sqlDataAdapter = new SqlDataAdapter("Select * from EmployeesID", connection);
                    ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "EmployeesID");
                    employeesIDDataGridView.DataSource = ds.Tables["EmployeesID"];
                    sqlDataAdapter = new SqlDataAdapter("Select * from EmployeesID", connection);
                    ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "EmployeesID");
                    employeesIDDataGridView1.DataSource = ds.Tables["EmployeesID"];
                }
            }
        }

        private void dayClInput_Click(object sender, EventArgs e)
        {
            int day_num = 0;
            if (!int.TryParse(dayClInput.Text, out day_num) || day_num > 31)
                dayClInput.Text = "";
        }

        private void monthClInput_Click(object sender, EventArgs e)
        {
            int month_num = 0;
            if (!int.TryParse(monthClInput.Text, out month_num) || month_num > 12)
                monthClInput.Text = "";
        }

        private void yearClInput_Click(object sender, EventArgs e)
        {
            int year_num = 0;
            if (!int.TryParse(yearClInput.Text, out year_num))
                yearClInput.Text = "";
        }

        private void dayClInput_Leave(object sender, EventArgs e)
        {
            try
            {
                int day_num = int.Parse(dayClInput.Text);
                if (day_num > 31)
                {
                    dayClInput.Text = "";
                    throw new FormatException();
                }
                int month_num = int.Parse(monthClInput.Text);
                int year_num = int.Parse(yearClInput.Text);
                day_Validate(day_num, year_num, ref dayClInput, monthClInput);
                month_Validate(month_num, ref monthClInput);
                year_Validate(ref yearClInput);
            }
            catch (FormatException)
            {
                dayClInput.BackColor = Color.Salmon;
            }
        }

        private void monthClInput_Leave(object sender, EventArgs e)
        {
            try
            {
                int month_num = int.Parse(monthClInput.Text);
                int day_num = int.Parse(dayClInput.Text);
                if (month_num > 12)
                {
                    monthClInput.Text = "";
                    throw new FormatException();
                }
                int year_num = int.Parse(yearClInput.Text);
                day_Validate(day_num, year_num, ref dayClInput, monthClInput);
                month_Validate(month_num, ref monthClInput);
                year_Validate(ref yearClInput);
            }
            catch (FormatException)
            {
                monthClInput.BackColor = Color.Salmon;
            }
        }

        private void yearClInput_Leave(object sender, EventArgs e)
        {
            try
            {
                int day_num = int.Parse(dayClInput.Text);
                int month_num = int.Parse(monthClInput.Text);
                int year_num = int.Parse(yearClInput.Text);
                day_Validate(day_num, year_num, ref dayClInput, monthClInput);
                month_Validate(month_num, ref monthClInput);
                year_Validate(ref yearClInput);
            }
            catch (FormatException)
            {
                yearClInput.BackColor = Color.Salmon;
            }
        }

        private void phoneClInput_Leave(object sender, EventArgs e)
        {
            try
            {
                Int64 phone_num = Int64.Parse(phoneClInput.Text);
                if (phoneClInput.Text.Length != 10) phoneClInput.BackColor = Color.Salmon;
                else phoneClInput.BackColor = Color.White;
            }
            catch (FormatException)
            {
                phoneClInput.BackColor = Color.Salmon;
            }
        }

        private void IDClientInput_Leave(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(IDClientInput.Text);
                IDClientInput.BackColor = Color.White;
            }
            catch (FormatException)
            {
                IDClientInput.BackColor = Color.Salmon;
            }
        }

        private void AddClientButton_Click(object sender, EventArgs e)
        {
            if (dayClInput.BackColor == Color.White && monthClInput.BackColor == Color.White && yearClInput.BackColor == Color.White &&
                phoneClInput.BackColor == Color.White && FIOClinput.Text != "" && dayClInput.Text != "dd" && monthClInput.Text != "mm" &&
                yearClInput.Text != "yyyy" && phoneClInput.Text != "")
            {
                string sqlExpression = "AddClient";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter FIOParam = new SqlParameter
                    {
                        ParameterName = "@FIO_cl",
                        Value = FIOClinput.Text
                    };
                    command.Parameters.Add(FIOParam);
                    SqlParameter birthday = new SqlParameter
                    {
                        ParameterName = "@birthday",
                        Value = yearClInput.Text + "-" + monthClInput.Text + "-" + dayClInput.Text
                    };
                    command.Parameters.Add(birthday);
                    SqlParameter phoneParam = new SqlParameter
                    {
                        ParameterName = "@phone",
                        Value = "8" + phoneClInput.Text
                    };
                    command.Parameters.Add(phoneParam);
                    command.ExecuteNonQuery();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from ClientsList", connection);
                    DataSet ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "ClientsList");
                    clientsListDataGridView.DataSource = ds.Tables["ClientsList"];
                    sqlDataAdapter = new SqlDataAdapter("Select * from ClientsID", connection);
                    ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "ClientsID");
                    clientsIDDataGridView.DataSource = ds.Tables["ClientsID"];
                }
            }
        }

        private void updateClient_Click(object sender, EventArgs e)
        {
            if (dayClInput.BackColor == Color.White && monthClInput.BackColor == Color.White && yearClInput.BackColor == Color.White &&
                phoneClInput.BackColor == Color.White && FIOClinput.Text != "" && dayClInput.Text != "dd" && monthClInput.Text != "mm" &&
                yearClInput.Text != "yyyy" && phoneClInput.Text != "" && IDClientInput.BackColor == Color.White && IDClientInput.Text != "")
            {
                string sqlExpression = "UpdateClient";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter ID = new SqlParameter
                    {
                        ParameterName = "@id",
                        Value = int.Parse(IDClientInput.Text)
                    };
                    command.Parameters.Add(ID);
                    SqlParameter FIOParam = new SqlParameter
                    {
                        ParameterName = "@FIO_cl",
                        Value = FIOClinput.Text
                    };
                    command.Parameters.Add(FIOParam);
                    SqlParameter birthday = new SqlParameter
                    {
                        ParameterName = "@birthday",
                        Value = yearClInput.Text + "-" + monthClInput.Text + "-" + dayClInput.Text
                    };
                    command.Parameters.Add(birthday);
                    SqlParameter phoneParam = new SqlParameter
                    {
                        ParameterName = "@phone",
                        Value = "8" + phoneClInput.Text
                    };
                    command.Parameters.Add(phoneParam);
                    command.ExecuteNonQuery();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from ClientsList", connection);
                    DataSet ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "ClientsList");
                    clientsListDataGridView.DataSource = ds.Tables["ClientsList"];
                    sqlDataAdapter = new SqlDataAdapter("Select * from ClientsID", connection);
                    ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "ClientsID");
                    clientsIDDataGridView.DataSource = ds.Tables["ClientsID"];
                }
            }
        }

        private void clientDelete_Click(object sender, EventArgs e)
        {
            if (IDClientInput.BackColor == Color.White && IDClientInput.Text != "")
            {
                string sqlExpression = "RemoveClient";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter ID = new SqlParameter
                    {
                        ParameterName = "@id",
                        Value = int.Parse(IDClientInput.Text)
                    };
                    command.Parameters.Add(ID);
                    command.ExecuteNonQuery();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from ClientsList", connection);
                    DataSet ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "ClientsList");
                    clientsListDataGridView.DataSource = ds.Tables["ClientsList"];
                    sqlDataAdapter = new SqlDataAdapter("Select * from ClientsID", connection);
                    ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "ClientsID");
                    clientsIDDataGridView.DataSource = ds.Tables["ClientsID"];
                }
            }
        }

        private void serviceInput_Leave(object sender, EventArgs e)
        {
            if (serviceInput.Text.Length > 12) serviceInput.BackColor = Color.Salmon;
            else serviceInput.BackColor = Color.White;
        }

        private void IDMastPrInput_Leave(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(IDMastPrInput.Text);
                IDMastPrInput.BackColor = Color.White;
            }
            catch (FormatException)
            {
                IDMastPrInput.BackColor = Color.Salmon;
            }
        }

        private void PriceInput_Leave(object sender, EventArgs e)
        {
            try
            {
                float price = float.Parse(PriceInput.Text);
                PriceInput.BackColor = Color.White;
            }
            catch (FormatException)
            {
                PriceInput.BackColor = Color.Salmon;
            }
        }

        private void AddPrice_Click(object sender, EventArgs e)
        {
            if (serviceInput.BackColor == Color.White && IDMastPrInput.BackColor == Color.White && PriceInput.BackColor == Color.White &&
                serviceInput.Text != "" && IDMastPrInput.Text != "" && PriceInput.Text != "")
            {
                string sqlExpression = "AddPrice";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter service = new SqlParameter
                    {
                        ParameterName = "@service",
                        Value = serviceInput.Text
                    };
                    command.Parameters.Add(service);
                    SqlParameter id = new SqlParameter
                    {
                        ParameterName = "@master_id",
                        Value = int.Parse(IDMastPrInput.Text)
                    };
                    command.Parameters.Add(id);
                    SqlParameter price = new SqlParameter
                    {
                        ParameterName = "@price",
                        Value = float.Parse(PriceInput.Text)
                    };
                    command.Parameters.Add(price);
                    command.ExecuteNonQuery();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from PriceList", connection);
                    DataSet ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "PriceList");
                    priceListDataGridView.DataSource = ds.Tables["PriceList"];
                    sqlDataAdapter = new SqlDataAdapter("Select * from EmployeesID", connection);
                    ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "EmployeesID");
                    employeesIDDataGridView.DataSource = ds.Tables["EmployeesID"];
                    sqlDataAdapter = new SqlDataAdapter("Select * from EmployeesID", connection);
                    ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "EmployeesID");
                    employeesIDDataGridView1.DataSource = ds.Tables["EmployeesID"];
                }
            }
        }

        private void UpdatePrice_Click(object sender, EventArgs e)
        {
            if (serviceInput.BackColor == Color.White && IDMastPrInput.BackColor == Color.White && PriceInput.BackColor == Color.White &&
                serviceInput.Text != "" && IDMastPrInput.Text != "" && PriceInput.Text != "")
            {
                string sqlExpression = "UpdatePrice";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter service = new SqlParameter
                    {
                        ParameterName = "@service",
                        Value = serviceInput.Text
                    };
                    command.Parameters.Add(service);
                    SqlParameter id = new SqlParameter
                    {
                        ParameterName = "@master_id",
                        Value = int.Parse(IDMastPrInput.Text)
                    };
                    command.Parameters.Add(id);
                    SqlParameter price = new SqlParameter
                    {
                        ParameterName = "@price",
                        Value = float.Parse(PriceInput.Text)
                    };
                    command.Parameters.Add(price);
                    command.ExecuteNonQuery();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from PriceList", connection);
                    DataSet ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "PriceList");
                    priceListDataGridView.DataSource = ds.Tables["PriceList"];
                    sqlDataAdapter = new SqlDataAdapter("Select * from EmployeesID", connection);
                    ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "EmployeesID");
                    employeesIDDataGridView.DataSource = ds.Tables["EmployeesID"];
                    sqlDataAdapter = new SqlDataAdapter("Select * from EmployeesID", connection);
                    ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "EmployeesID");
                    employeesIDDataGridView1.DataSource = ds.Tables["EmployeesID"];
                }
            }
        }

        private void DeletePrice_Click(object sender, EventArgs e)
        {
            if (serviceInput.BackColor == Color.White && IDMastPrInput.BackColor == Color.White &&
                serviceInput.Text != "" && IDMastPrInput.Text != "")
            {
                string sqlExpression = "RemovePrice";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter service = new SqlParameter
                    {
                        ParameterName = "@service",
                        Value = serviceInput.Text
                    };
                    command.Parameters.Add(service);
                    SqlParameter id = new SqlParameter
                    {
                        ParameterName = "@master_id",
                        Value = int.Parse(IDMastPrInput.Text)
                    };
                    command.Parameters.Add(id);
                    command.ExecuteNonQuery();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from PriceList", connection);
                    DataSet ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "PriceList");
                    priceListDataGridView.DataSource = ds.Tables["PriceList"];
                    sqlDataAdapter = new SqlDataAdapter("Select * from EmployeesID", connection);
                    ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "EmployeesID");
                    employeesIDDataGridView.DataSource = ds.Tables["EmployeesID"];
                    sqlDataAdapter = new SqlDataAdapter("Select * from EmployeesID", connection);
                    ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "EmployeesID");
                    employeesIDDataGridView1.DataSource = ds.Tables["EmployeesID"];
                }
            }
        }

        private void logServiceInput_Leave(object sender, EventArgs e)
        {
            if (logServiceInput.Text.Length > 12) logServiceInput.BackColor = Color.Salmon;
            else logServiceInput.BackColor = Color.White;
        }

        private void logDayInput_Click(object sender, EventArgs e)
        {
            int day_num = 0;
            if (!int.TryParse(logDayInput.Text, out day_num) || day_num > 31)
                logDayInput.Text = "";
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

        private void logMonthInput_Click(object sender, EventArgs e)
        {
            int month_num = 0;
            if (!int.TryParse(logMonthInput.Text, out month_num) || month_num > 12)
                logMonthInput.Text = "";
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

        private void logYearInput_Click(object sender, EventArgs e)
        {
            int year_num = 0;
            if (!int.TryParse(logYearInput.Text, out year_num))
                logYearInput.Text = "";
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

        private void logIDEmplInput_Leave(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(logIDEmplInput.Text);
                logIDEmplInput.BackColor = Color.White;
            }
            catch (FormatException)
            {
                logIDEmplInput.BackColor = Color.Salmon;
            }
        }

        private void logIDClInput_Leave(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(logIDClInput.Text);
                logIDClInput.BackColor = Color.White;
            }
            catch (FormatException)
            {
                logIDClInput.BackColor = Color.Salmon;
            }
        }

        private void logIDInput_Leave(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(logIDInput.Text);
                logIDInput.BackColor = Color.White;
            }
            catch (FormatException)
            {
                logIDInput.BackColor = Color.Salmon;
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

        private void AddLog_Click(object sender, EventArgs e)
        {
            if (logServiceInput.BackColor == Color.White && logDayInput.BackColor == Color.White && logMonthInput.BackColor == Color.White &&
                logYearInput.BackColor == Color.White && logHoursInput.BackColor == Color.White && logMinutesInput.BackColor == Color.White &&
                logIDClInput.BackColor == Color.White && logIDEmplInput.BackColor == Color.White && logServiceInput.Text != "" &&
                logDayInput.Text != "dd" && logMonthInput.Text != "mm" && logYearInput.Text != "yyyy" && logHoursInput.Text != "hh" &&
                logMinutesInput.Text != "mm" && logIDClInput.Text != "" && logIDEmplInput.Text != "")
            {
                string sqlExpression = "AddLog";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter masterID = new SqlParameter
                    {
                        ParameterName = "@master_id",
                        Value = int.Parse(logIDEmplInput.Text)
                    };
                    command.Parameters.Add(masterID);
                    SqlParameter clientID = new SqlParameter
                    {
                        ParameterName = "@client_id",
                        Value = int.Parse(logIDClInput.Text)
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
                        Value = logServiceInput.Text
                    };
                    command.Parameters.Add(service);
                    command.ExecuteNonQuery();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from LogJournal", connection);
                    DataSet ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "LogJournal");
                    logJournalDataGridView.DataSource = ds.Tables["LogJournal"];
                    sqlDataAdapter = new SqlDataAdapter("Select * from LogID", connection);
                    ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "LogID");
                    logIDDataGridView.DataSource = ds.Tables["LogID"];
                }
            }
        }

        private void ChangeLog_Click(object sender, EventArgs e)
        {
            if (logIDInput.BackColor == Color.White && logDayInput.BackColor == Color.White && logMonthInput.BackColor == Color.White &&
                logYearInput.BackColor == Color.White && logHoursInput.BackColor == Color.White && logMinutesInput.BackColor == Color.White && 
                logIDInput.Text != "" && logDayInput.Text != "dd" && logMonthInput.Text != "mm" && logYearInput.Text != "yyyy" && 
                logHoursInput.Text != "hh" && logMinutesInput.Text != "mm")
            {
                string sqlExpression = "ChangeLog";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter ID = new SqlParameter
                    {
                        ParameterName = "@id_log",
                        Value = int.Parse(logIDInput.Text)
                    };
                    command.Parameters.Add(ID);
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
                    command.ExecuteNonQuery();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from LogJournal", connection);
                    DataSet ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "LogJournal");
                    logJournalDataGridView.DataSource = ds.Tables["LogJournal"];
                    sqlDataAdapter = new SqlDataAdapter("Select * from LogID", connection);
                    ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "LogID");
                    logIDDataGridView.DataSource = ds.Tables["LogID"];
                }
            }
        }

        private void RemoveLog_Click(object sender, EventArgs e)
        {
            if (logIDInput.BackColor == Color.White && logIDInput.Text != "")
            {
                string sqlExpression = "RemoveLog";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter ID = new SqlParameter
                    {
                        ParameterName = "@id_log",
                        Value = int.Parse(logIDInput.Text)
                    };
                    command.Parameters.Add(ID);
                    command.ExecuteNonQuery();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from LogJournal", connection);
                    DataSet ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "LogJournal");
                    logJournalDataGridView.DataSource = ds.Tables["LogJournal"];
                    sqlDataAdapter = new SqlDataAdapter("Select * from LogID", connection);
                    ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "LogID");
                    logIDDataGridView.DataSource = ds.Tables["LogID"];
                }
            }
        }

        private void productInput_Leave(object sender, EventArgs e)
        {
            if (productInput.Text.Length > 15) productInput.BackColor = Color.Salmon;
            else productInput.BackColor = Color.White;
        }

        private void brandInput_Leave(object sender, EventArgs e)
        {
            if (brandInput.Text.Length > 15) brandInput.BackColor = Color.Salmon;
            else brandInput.BackColor = Color.White;
        }

        private void countInput_Leave(object sender, EventArgs e)
        {
            try
            {
                int count_num = int.Parse(countInput.Text);
                countInput.BackColor = Color.White;
            }
            catch (FormatException)
            {
                countInput.BackColor = Color.Salmon;
            }
        }

        private void costInput_Leave(object sender, EventArgs e)
        {
            try
            {
                float cost_num = float.Parse(costInput.Text);
                costInput.BackColor = Color.White;
            }
            catch (FormatException)
            {
                costInput.BackColor = Color.Salmon;
            }
        }

        private void addMaterial_Click(object sender, EventArgs e)
        {
            if (productInput.BackColor == Color.White && brandInput.BackColor == Color.White &&
                countInput.BackColor == Color.White && costInput.BackColor == Color.White &&
                productInput.Text != "" && brandInput.Text != "" && countInput.Text != "" && costInput.Text != "")
            {
                string sqlExpression = "AddMaterial";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter product = new SqlParameter
                    {
                        ParameterName = "@product",
                        Value = productInput.Text
                    };
                    command.Parameters.Add(product);
                    SqlParameter brand = new SqlParameter
                    {
                        ParameterName = "@brand",
                        Value = brandInput.Text
                    };
                    command.Parameters.Add(brand);
                    SqlParameter count = new SqlParameter
                    {
                        ParameterName = "@count",
                        Value = int.Parse(countInput.Text)
                    };
                    command.Parameters.Add(count);
                    SqlParameter cost = new SqlParameter
                    {
                        ParameterName = "@cost",
                        Value = float.Parse(costInput.Text)
                    };
                    command.Parameters.Add(cost);
                    command.ExecuteNonQuery();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from MaterialsList", connection);
                    DataSet ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "MaterialsList");
                    materialsListDataGridView.DataSource = ds.Tables["MaterialsList"];
                }
            }
        }

        private void changeMaterial_Click(object sender, EventArgs e)
        {
            if (productInput.BackColor == Color.White && countInput.BackColor == Color.White && costInput.BackColor == Color.White &&
                productInput.Text != "" && countInput.Text != "" && costInput.Text != "")
            {
                string sqlExpression = "UpdateMaterial";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter product = new SqlParameter
                    {
                        ParameterName = "@product",
                        Value = productInput.Text
                    };
                    command.Parameters.Add(product);
                    SqlParameter count = new SqlParameter
                    {
                        ParameterName = "@count",
                        Value = int.Parse(countInput.Text)
                    };
                    command.Parameters.Add(count);
                    SqlParameter cost = new SqlParameter
                    {
                        ParameterName = "@cost",
                        Value = float.Parse(costInput.Text)
                    };
                    command.Parameters.Add(cost);
                    command.ExecuteNonQuery();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from MaterialsList", connection);
                    DataSet ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "MaterialsList");
                    materialsListDataGridView.DataSource = ds.Tables["MaterialsList"];
                }
            }
        }

        private void deleteMaterial_Click(object sender, EventArgs e)
        {
            if (productInput.BackColor == Color.White && productInput.Text != "")
            {
                string sqlExpression = "DeleteMaterial";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter product = new SqlParameter
                    {
                        ParameterName = "@product",
                        Value = productInput.Text
                    };
                    command.Parameters.Add(product);
                    command.ExecuteNonQuery();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from MaterialsList", connection);
                    DataSet ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "MaterialsList");
                    materialsListDataGridView.DataSource = ds.Tables["MaterialsList"];
                }
            }
        }

        private void IDMasterInput_Leave(object sender, EventArgs e)
        {
            int id = 0;
            if (int.TryParse(IDMasterInput.Text, out id)) IDMasterInput.BackColor = Color.White;
            else IDMasterInput.BackColor = Color.Salmon;
        }

        private void productSaleInput_Leave(object sender, EventArgs e)
        {
            if (productSaleInput.Text.Length > 15) productSaleInput.BackColor = Color.Salmon;
            else productSaleInput.BackColor = Color.White;
        }

        private void countSaleInput_Leave(object sender, EventArgs e)
        {
            int count_num = 0;
            if (int.TryParse(countSaleInput.Text, out count_num)) countSaleInput.BackColor = Color.White;
            else countSaleInput.BackColor = Color.Salmon;
        }

        private void costSaleInput_Leave(object sender, EventArgs e)
        {
            float cost_num = 0;
            if (float.TryParse(costSaleInput.Text, out cost_num)) costSaleInput.BackColor = Color.White;
            else costSaleInput.BackColor = Color.Salmon;
        }

        private void IDSaleInput_Leave(object sender, EventArgs e)
        {
            int id = 0;
            if (int.TryParse(IDSaleInput.Text, out id)) IDSaleInput.BackColor = Color.White;
            else IDSaleInput.BackColor = Color.Salmon;
        }

        private void AddSale_Click(object sender, EventArgs e)
        {
            if (IDMasterInput.BackColor == Color.White && productSaleInput.BackColor == Color.White && countSaleInput.BackColor == Color.White &&
                costSaleInput.BackColor == Color.White && IDMasterInput.Text != "" && productSaleInput.Text != "" && countSaleInput.Text != "" && costSaleInput.Text != "")
            {
                string sqlExpression = "AddSale";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter IDMast = new SqlParameter
                    {
                        ParameterName = "@master_id",
                        Value = int.Parse(IDMasterInput.Text)
                    };
                    command.Parameters.Add(IDMast);
                    SqlParameter productS = new SqlParameter
                    {
                        ParameterName = "@product",
                        Value = productSaleInput.Text
                    };
                    command.Parameters.Add(productS);
                    SqlParameter countS = new SqlParameter
                    {
                        ParameterName = "@count",
                        Value = int.Parse(countSaleInput.Text)
                    };
                    command.Parameters.Add(countS);
                    SqlParameter costS = new SqlParameter
                    {
                        ParameterName = "@cost",
                        Value = float.Parse(costSaleInput.Text)
                    };
                    command.Parameters.Add(costS);
                    command.ExecuteNonQuery();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from SalesJournal", connection);
                    DataSet ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "SalesJournal");
                    salesJournalDataGridView.DataSource = ds.Tables["SalesJournal"];
                    sqlDataAdapter = new SqlDataAdapter("Select * from SalesID", connection);
                    ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "SalesID");
                    salesIDDataGridView.DataSource = ds.Tables["SalesID"];
                }
            }
        }

        private void UpdateSale_Click(object sender, EventArgs e)
        {
            if (IDMasterInput.BackColor == Color.White && productSaleInput.BackColor == Color.White && countSaleInput.BackColor == Color.White &&
                IDSaleInput.BackColor == Color.White && IDMasterInput.Text != "" && productSaleInput.Text != "" && countSaleInput.Text != "" && IDSaleInput.Text != "")
            {
                string sqlExpression = "UpdateSale";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter IDMast = new SqlParameter
                    {
                        ParameterName = "@master_id",
                        Value = int.Parse(IDMasterInput.Text)
                    };
                    command.Parameters.Add(IDMast);
                    SqlParameter IDS = new SqlParameter
                    {
                        ParameterName = "@id",
                        Value = int.Parse(IDSaleInput.Text)
                    };
                    command.Parameters.Add(IDS);
                    SqlParameter productS = new SqlParameter
                    {
                        ParameterName = "@product",
                        Value = productSaleInput.Text
                    };
                    command.Parameters.Add(productS);
                    SqlParameter countS = new SqlParameter
                    {
                        ParameterName = "@count",
                        Value = int.Parse(countSaleInput.Text)
                    };
                    command.Parameters.Add(countS);
                    command.ExecuteNonQuery();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from SalesJournal", connection);
                    DataSet ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "SalesJournal");
                    salesJournalDataGridView.DataSource = ds.Tables["SalesJournal"];
                    sqlDataAdapter = new SqlDataAdapter("Select * from SalesID", connection);
                    ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "SalesID");
                    salesIDDataGridView.DataSource = ds.Tables["SalesID"];
                }
            }
        }

        private void DeleteSale_Click(object sender, EventArgs e)
        {
            if (IDSaleInput.BackColor == Color.White && IDSaleInput.Text != "")
            {
                string sqlExpression = "DeleteSale";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter IDS = new SqlParameter
                    {
                        ParameterName = "@id",
                        Value = int.Parse(IDSaleInput.Text)
                    };
                    command.Parameters.Add(IDS);
                    command.ExecuteNonQuery();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from SalesJournal", connection);
                    DataSet ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "SalesJournal");
                    salesJournalDataGridView.DataSource = ds.Tables["SalesJournal"];
                    sqlDataAdapter = new SqlDataAdapter("Select * from SalesID", connection);
                    ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "SalesID");
                    salesIDDataGridView.DataSource = ds.Tables["SalesID"];
                }
            }
        }
    }
}
