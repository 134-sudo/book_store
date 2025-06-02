using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Timer = System.Windows.Forms.Timer;

namespace book_store
{
    public partial class AuthForm : Form
    {
        private bool showPassword = false;
        private NpgsqlConnection conn = new NpgsqlConnection(Constants.ConnectionString);

        private Timer timer;
        private int counter = 0;
        public AuthForm()
        {
            InitializeComponent();
            login_textBox.KeyPress += textBox_KeyPress;
            password_textBox.KeyPress += textBox_KeyPress;

            timer = new Timer
            {
                Interval = 1000
            };
            timer.Tick += Timer_Tick;
            statusbar_text.Text = "";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            counter++;
            if (counter >= 3)
            {
                timer.Stop();
                statusbar_text.Text = "";
                counter = 0;
            }
        }

        private void show_password_button_Click(object sender, EventArgs e)
        {
            showPassword = !showPassword;
            password_textBox.UseSystemPasswordChar = !showPassword;
            statusbar_text.Text = (showPassword) ? "Пароль показан" : "Пароль скрыт";
            counter = 0;
            timer.Start();
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            string login = login_textBox.Text;
            string password = password_textBox.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Логин и пароль не могут быть пустыми!", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(
                    "SELECT COUNT(*) FROM users WHERE login=@login AND password=@password;",
                    conn);

                cmd.Parameters.AddWithValue("login", login);
                cmd.Parameters.AddWithValue("password", password);
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count == 0)
                {
                    MessageBox.Show($"Пользователь '{login}' не найден или пароль неверен!",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show("Вход выполнен успешно!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                MainForm form = new MainForm();
                form.Show();
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения: {ex.Message}", "Ошибка БД",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\t' || e.KeyChar == ' ' || e.KeyChar == '\n' || e.KeyChar == '\r')
            {
                statusbar_text.Text = "Вы не можете ввести данный символ";
                counter = 0;
                timer.Start();
                e.Handled = true;
            }
        }
    }
}
