using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace book_store
{
    public partial class MainForm : Form
    {
        private NpgsqlConnection conn = new NpgsqlConnection(Constants.ConnectionString);

        private NpgsqlDataAdapter dataAdapter;
        private DataTable dataTable;

        private Timer timer;
        private int counter = 0;

        public AdditionalForm additionalForm;

        public MainForm()
        {
            InitializeComponent();
            Init();
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1200, 600);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            counter++;
            if (counter >= 3)
            {
                timer.Stop();
                status_bar_text.Text = "";
            }
        }

        private void Init()
        {
            try
            {
                conn.Open();
                string query = @"
                SELECT table_name 
                FROM information_schema.tables 
                WHERE table_schema = 'public' 
                  AND table_type = 'BASE TABLE'
                  AND NOT table_name = 'users';
            ";
           

            tables_box.Items.Clear();
            using (var cmd = new NpgsqlCommand(query, conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tables_box.Items.Add(reader.GetString(0));
                    }
                }
            }

            tables_box.DropDownStyle = ComboBoxStyle.DropDownList;
            tables_box.SelectedIndex = 0;
            table_view.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader);

            status_bar_text.Text = "";

            timer = new Timer
            {
                Interval = 1000
            };
            timer.Tick += Timer_Tick;
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации: {ex.Message}", "Ошибка БД",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private bool TableExists(string tableName)
        {
            string query = $"SELECT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_name = '{tableName}')";
            using (var cmd = new NpgsqlCommand(query, conn))
                return (bool)cmd.ExecuteScalar();
        }

        private void tables_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            try 
            { 
            table_view.DataSource = null;
            dataAdapter = new NpgsqlDataAdapter($"SELECT * FROM {tables_box.Text}", conn);
            dataTable = new DataTable();


            NpgsqlCommandBuilder commandBuilder = new NpgsqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(dataTable);

            table_view.DataSource = dataTable;
            table_view.Columns[0].Visible = false;

            Dictionary<string, DataTable> fkData = new Dictionary<string, DataTable>();

            for (int i = 1; i < dataTable.Columns.Count; i++)
            {
                DataColumn column = dataTable.Columns[i];
                if (column.ColumnName.EndsWith("_id"))
                {
                    string relatedTable = column.ColumnName.Replace("_id", "s");
                    if (TableExists(relatedTable))
                    {
                        var fkAdapter = new NpgsqlDataAdapter($"SELECT * FROM {relatedTable}", conn);
                        DataTable fkTable = new DataTable();
                        fkAdapter.Fill(fkTable);
                        fkData.Add(column.ColumnName, fkTable);
                    }
                }
            }

            foreach (var fk in fkData)
            {
                if (table_view.Columns.Contains(fk.Key))
                {
                    string col_name = fk.Key.Replace("_id", "");
                    if (fk.Value.Columns.Contains(col_name + "_name"))
                    {
                        col_name += "_name";
                    }

                    DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn
                    {
                        DataSource = fk.Value,
                        DisplayMember = col_name,
                        ValueMember = fk.Key,
                        DataPropertyName = fk.Key,
                        HeaderText = col_name
                    };

                    int columnIndex = table_view.Columns[fk.Key].Index;
                    table_view.Columns.Remove(fk.Key);
                    table_view.Columns.Insert(columnIndex, combo);
                }
            }

            table_view.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки таблицы: {ex.Message}", "Ошибка БД",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                dataAdapter.Update(dataTable);
            counter = 0;
            status_bar_text.Text = "Изменения успешно сохранены!";
            timer.Start();
                MessageBox.Show("Данные успешно сохранены!", "Успех",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка БД",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

            if (table_view.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in table_view.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        table_view.Rows.Remove(row);
                    }
                }

                dataAdapter.Update(dataTable);
                status_bar_text.Text = "Строки успешно удалены!";
                counter = 0;
                timer.Start();
            }
            else
            {
                status_bar_text.Text = "Сначала выберите строки!";
                counter = 0;
                timer.Start();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка закрытия подключения: {ex.Message}", "Ошибка БД",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnFormClosed(e);
            Application.Exit();
        }


        private void go_to_additional_button_Click(object sender, EventArgs e)
        {
            if (additionalForm == null)
                additionalForm = new AdditionalForm(this);

            additionalForm.Show();
            this.Hide();
        }
    }
}
