namespace book_store
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            table_view = new DataGridView();
            tables_box = new ComboBox();
            btn_save = new Button();
            btn_delete = new Button();
            status_bar = new StatusStrip();
            status_bar_text = new ToolStripStatusLabel();
            icon_box = new PictureBox();
            go_to_additional_button = new Button();
            ((System.ComponentModel.ISupportInitialize)table_view).BeginInit();
            status_bar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icon_box).BeginInit();
            SuspendLayout();
            // 
            // table_view
            // 
            table_view.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            table_view.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table_view.Location = new Point(12, 46);
            table_view.Name = "table_view";
            table_view.RowHeadersWidth = 51;
            table_view.Size = new Size(1025, 410);
            table_view.TabIndex = 0;
            // 
            // tables_box
            // 
            tables_box.Font = new Font("Times New Roman", 10.2F);
            tables_box.Location = new Point(12, 12);
            tables_box.Name = "tables_box";
            tables_box.Size = new Size(151, 27);
            tables_box.TabIndex = 1;
            tables_box.SelectedIndexChanged += tables_box_SelectedIndexChanged;
            // 
            // btn_save
            // 
            btn_save.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btn_save.BackColor = Color.SaddleBrown;
            btn_save.Font = new Font("Times New Roman", 10.2F);
            btn_save.Location = new Point(1043, 144);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(129, 29);
            btn_save.TabIndex = 2;
            btn_save.Text = "Сохранить";
            btn_save.UseVisualStyleBackColor = false;
            btn_save.Click += btn_save_Click;
            // 
            // btn_delete
            // 
            btn_delete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btn_delete.BackColor = Color.SaddleBrown;
            btn_delete.Font = new Font("Times New Roman", 10.2F);
            btn_delete.Location = new Point(1043, 179);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(129, 29);
            btn_delete.TabIndex = 3;
            btn_delete.Text = "Удалить";
            btn_delete.UseVisualStyleBackColor = false;
            btn_delete.Click += btn_delete_Click;
            // 
            // status_bar
            // 
            status_bar.ImageScalingSize = new Size(20, 20);
            status_bar.Items.AddRange(new ToolStripItem[] { status_bar_text });
            status_bar.Location = new Point(0, 459);
            status_bar.Name = "status_bar";
            status_bar.Size = new Size(1181, 25);
            status_bar.TabIndex = 4;
            // 
            // status_bar_text
            // 
            status_bar_text.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            status_bar_text.Name = "status_bar_text";
            status_bar_text.Size = new Size(35, 19);
            status_bar_text.Text = "text";
            // 
            // icon_box
            // 
            icon_box.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            icon_box.BackgroundImage = Properties.Resources.app_icon;
            icon_box.BackgroundImageLayout = ImageLayout.Zoom;
            icon_box.Location = new Point(1043, 12);
            icon_box.Name = "icon_box";
            icon_box.Size = new Size(126, 126);
            icon_box.TabIndex = 8;
            icon_box.TabStop = false;
            // 
            // go_to_additional_button
            // 
            go_to_additional_button.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            go_to_additional_button.BackColor = Color.SaddleBrown;
            go_to_additional_button.Font = new Font("Times New Roman", 10.2F);
            go_to_additional_button.Location = new Point(1043, 214);
            go_to_additional_button.Name = "go_to_additional_button";
            go_to_additional_button.Size = new Size(129, 29);
            go_to_additional_button.TabIndex = 9;
            go_to_additional_button.Text = "Задолжники ";
            go_to_additional_button.UseVisualStyleBackColor = false;
            go_to_additional_button.Click += go_to_additional_button_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1181, 484);
            Controls.Add(go_to_additional_button);
            Controls.Add(icon_box);
            Controls.Add(status_bar);
            Controls.Add(btn_delete);
            Controls.Add(btn_save);
            Controls.Add(tables_box);
            Controls.Add(table_view);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Главная форма";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)table_view).EndInit();
            status_bar.ResumeLayout(false);
            status_bar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)icon_box).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView table_view;
        private ComboBox tables_box;
        private Button btn_save;
        private Button btn_delete;
        private StatusStrip status_bar;
        private ToolStripStatusLabel status_bar_text;
        private PictureBox icon_box;
        private Button go_to_additional_button;
    }
}
