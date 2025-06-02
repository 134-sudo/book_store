namespace book_store
{
    partial class AuthForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthForm));
            login_button = new Button();
            status_bar = new StatusStrip();
            statusbar_text = new ToolStripStatusLabel();
            login_textBox = new TextBox();
            password_textBox = new TextBox();
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            icon_box = new PictureBox();
            status_bar.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icon_box).BeginInit();
            SuspendLayout();
            // 
            // login_button
            // 
            login_button.Anchor = AnchorStyles.None;
            login_button.BackColor = Color.SaddleBrown;
            login_button.Font = new Font("Times New Roman", 10.2F);
            login_button.Location = new Point(99, 351);
            login_button.Name = "login_button";
            login_button.Size = new Size(94, 29);
            login_button.TabIndex = 0;
            login_button.Text = "Войти";
            login_button.UseVisualStyleBackColor = false;
            login_button.Click += login_button_Click;
            // 
            // status_bar
            // 
            status_bar.ImageScalingSize = new Size(20, 20);
            status_bar.Items.AddRange(new ToolStripItem[] { statusbar_text });
            status_bar.Location = new Point(0, 425);
            status_bar.Name = "status_bar";
            status_bar.Size = new Size(326, 25);
            status_bar.TabIndex = 1;
            status_bar.Text = "statusStrip1";
            // 
            // statusbar_text
            // 
            statusbar_text.Font = new Font("Times New Roman", 10.2F);
            statusbar_text.Name = "statusbar_text";
            statusbar_text.Size = new Size(35, 19);
            statusbar_text.Text = "text";
            // 
            // login_textBox
            // 
            login_textBox.Anchor = AnchorStyles.None;
            login_textBox.Font = new Font("Times New Roman", 10.2F);
            login_textBox.Location = new Point(33, 227);
            login_textBox.Name = "login_textBox";
            login_textBox.Size = new Size(249, 27);
            login_textBox.TabIndex = 1;
            // 
            // password_textBox
            // 
            password_textBox.Anchor = AnchorStyles.None;
            password_textBox.Font = new Font("Times New Roman", 10.2F);
            password_textBox.Location = new Point(33, 294);
            password_textBox.Name = "password_textBox";
            password_textBox.Size = new Size(249, 27);
            password_textBox.TabIndex = 2;
            password_textBox.UseSystemPasswordChar = true;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(icon_box);
            panel1.Controls.Add(login_button);
            panel1.Controls.Add(password_textBox);
            panel1.Controls.Add(login_textBox);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(302, 410);
            panel1.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(119, 271);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 9;
            label2.Text = "Пароль";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(119, 204);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 8;
            label1.Text = "Логин";
            // 
            // icon_box
            // 
            icon_box.Anchor = AnchorStyles.None;
            icon_box.BackgroundImage = Properties.Resources.app_icon;
            icon_box.BackgroundImageLayout = ImageLayout.Zoom;
            icon_box.Location = new Point(87, 39);
            icon_box.Name = "icon_box";
            icon_box.Size = new Size(126, 126);
            icon_box.TabIndex = 7;
            icon_box.TabStop = false;
            // 
            // AuthForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(326, 450);
            Controls.Add(panel1);
            Controls.Add(status_bar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AuthForm";
            Text = "Авторизация";
            status_bar.ResumeLayout(false);
            status_bar.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)icon_box).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button login_button;
        private StatusStrip status_bar;
        private ToolStripStatusLabel statusbar_text;
        private TextBox login_textBox;
        private TextBox password_textBox;
        private Panel panel1;
        private PictureBox icon_box;
        private Label label2;
        private Label label1;
    }
}