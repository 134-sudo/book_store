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
    public partial class AdditionalForm : Form
    {
        private NpgsqlConnection conn = new NpgsqlConnection(Constants.ConnectionString);

        private Timer timer;
        private int counter = 0;
        private MainForm mainForm;
        public AdditionalForm(MainForm mainForm)
        {
            InitializeComponent();
            status_bar_text.Text = "";

            timer = new Timer
            {
                Interval = 1000
            };
            timer.Tick += Timer_Tick;

            this.mainForm = mainForm;
            string query = @"
SELECT 
    r.reader_id,
    r.reader_name,
    r.phone,
    b.author,
    b.book_name,
    l.quantity,
    l.loan_date,
    l.return_date,
    COALESCE(lo.overdue_days, 0) as overdue_days
FROM readers r
JOIN loans l ON r.reader_id = l.reader_id
JOIN books b ON l.book_id = b.book_id
LEFT JOIN loan_with_overdue lo ON l.loan_id = lo.loan_id
WHERE l.return_date IS NULL
ORDER BY r.reader_id";

            conn.Open();
            using (var cmd = new NpgsqlCommand(query, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int readerId = Convert.ToInt32(reader["reader_id"]);
                    string readerName = reader["reader_name"].ToString();
                    string phone = reader["phone"].ToString();
                    string author = reader["author"].ToString();
                    string bookName = reader["book_name"].ToString();
                    int quantity = Convert.ToInt32(reader["quantity"]);
                    DateTime loanDate = Convert.ToDateTime(reader["loan_date"]);
                    int overdueDays = Convert.ToInt32(reader["overdue_days"]);

                    string returnStatus = reader["return_date"] is DBNull ?
                        $"Due in {(14 - (DateTime.Now - loanDate).Days)} days" :
                        "Returned";

                    AddLoanItem(readerId, readerName, phone, author, bookName,
                               quantity, loanDate, returnStatus, overdueDays);
                }
            }
            conn.Close();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            counter++;
            if (counter >= 3)
            {
                timer.Stop();
                status_bar_text.Text = "";
                counter = 0;
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            mainForm.Show();
            mainForm.additionalForm = null;
        }

        private void go_back_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddLoanItem(int readerId, string readerName, string phone, string author,
         string bookName, int quantity, DateTime loanDate,
         string returnStatus, int overdueDays)
        {
            Panel itemPanel = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(8, 8),
                Name = $"loanPanel_{readerId}",
                Size = new Size(630, 120),
                TabIndex = 0,
                BackColor = Constants.PrimaryBackgroundColor
            };

            Label readerLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Times New Roman", 13.8F),
                Location = new Point(6, 6),
                Name = $"readerLabel_{readerId}",
                Text = readerName
            };

            Label contactLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Times New Roman", 10.2F),
                Location = new Point(6, 34),
                Name = $"contactLabel_{readerId}",
                Text = $"Номер телефона: {phone}"
            };

            Label bookLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Times New Roman", 10.2F),
                Location = new Point(6, 53),
                Name = $"bookLabel_{readerId}",
                Text = $"{author} - {bookName}"
            };

            Label detailsLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Times New Roman", 10.2F),
                Location = new Point(6, 72),
                Name = $"detailsLabel_{readerId}",
                Text = $"Количество: {quantity} | Выдано: {loanDate:dd.MM.yyyy}"
            };

            Label statusLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Times New Roman", 10.2F, FontStyle.Bold),
                Location = new Point(6, 91),
                Name = $"statusLabel_{readerId}",
                ForeColor = overdueDays > 0 ? Color.Red : Color.Black,
                Text = (returnStatus == "Возвращено") ? $"Статус: {returnStatus}" : $"Задолженность: {overdueDays} дней"
            };

            itemPanel.Controls.Add(readerLabel);
            itemPanel.Controls.Add(contactLabel);
            itemPanel.Controls.Add(bookLabel);
            itemPanel.Controls.Add(detailsLabel);
            itemPanel.Controls.Add(statusLabel);

            items_panel.Controls.Add(itemPanel);
        }


    }
}
