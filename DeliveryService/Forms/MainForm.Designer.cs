namespace DeliveryService
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
            saveFileDialog1 = new SaveFileDialog();
            CreateOrderButton = new Button();
            CitiesComboBox = new ComboBox();
            Citieslabel = new Label();
            DatedateTimePicker = new DateTimePicker();
            DateTimelabel = new Label();
            FilteredOrdersDataGridView = new DataGridView();
            GetFilteredOrdersButton = new Button();
            SaveFilteredOrdersButton = new Button();
            ClearButton = new Button();
            GetTablesDatabutton = new Button();
            TablesComboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)FilteredOrdersDataGridView).BeginInit();
            SuspendLayout();
            // 
            // CreateOrderButton
            // 
            CreateOrderButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            CreateOrderButton.Location = new Point(11, 415);
            CreateOrderButton.Name = "CreateOrderButton";
            CreateOrderButton.Size = new Size(119, 23);
            CreateOrderButton.TabIndex = 0;
            CreateOrderButton.Text = "Добавить заказ";
            CreateOrderButton.UseVisualStyleBackColor = true;
            CreateOrderButton.Click += CreateOrderButton_Click;
            // 
            // CitiesComboBox
            // 
            CitiesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            CitiesComboBox.FormattingEnabled = true;
            CitiesComboBox.Location = new Point(68, 12);
            CitiesComboBox.Name = "CitiesComboBox";
            CitiesComboBox.Size = new Size(170, 23);
            CitiesComboBox.TabIndex = 6;
            // 
            // Citieslabel
            // 
            Citieslabel.AutoSize = true;
            Citieslabel.Location = new Point(12, 16);
            Citieslabel.Name = "Citieslabel";
            Citieslabel.Size = new Size(40, 15);
            Citieslabel.TabIndex = 7;
            Citieslabel.Text = "Город";
            // 
            // DatedateTimePicker
            // 
            DatedateTimePicker.Location = new Point(391, 11);
            DatedateTimePicker.Name = "DatedateTimePicker";
            DatedateTimePicker.Size = new Size(170, 23);
            DatedateTimePicker.TabIndex = 9;
            // 
            // DateTimelabel
            // 
            DateTimelabel.AutoSize = true;
            DateTimelabel.Location = new Point(254, 15);
            DateTimelabel.Name = "DateTimelabel";
            DateTimelabel.Size = new Size(131, 15);
            DateTimelabel.TabIndex = 8;
            DateTimelabel.Text = "Дата и время доставки";
            // 
            // FilteredOrdersDataGridView
            // 
            FilteredOrdersDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            FilteredOrdersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            FilteredOrdersDataGridView.Location = new Point(11, 45);
            FilteredOrdersDataGridView.Name = "FilteredOrdersDataGridView";
            FilteredOrdersDataGridView.Size = new Size(777, 364);
            FilteredOrdersDataGridView.TabIndex = 10;
            // 
            // GetFilteredOrdersButton
            // 
            GetFilteredOrdersButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            GetFilteredOrdersButton.Location = new Point(713, 11);
            GetFilteredOrdersButton.Name = "GetFilteredOrdersButton";
            GetFilteredOrdersButton.Size = new Size(75, 23);
            GetFilteredOrdersButton.TabIndex = 11;
            GetFilteredOrdersButton.Text = "Найти";
            GetFilteredOrdersButton.UseVisualStyleBackColor = true;
            GetFilteredOrdersButton.Click += GetFilteredOrdersButton_Click;
            // 
            // SaveFilteredOrdersButton
            // 
            SaveFilteredOrdersButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SaveFilteredOrdersButton.Enabled = false;
            SaveFilteredOrdersButton.Location = new Point(671, 415);
            SaveFilteredOrdersButton.Name = "SaveFilteredOrdersButton";
            SaveFilteredOrdersButton.Size = new Size(117, 23);
            SaveFilteredOrdersButton.TabIndex = 12;
            SaveFilteredOrdersButton.Text = "Сохранить в БД";
            SaveFilteredOrdersButton.UseVisualStyleBackColor = true;
            SaveFilteredOrdersButton.Click += SaveFilteredOrdersButton_Click;
            // 
            // ClearButton
            // 
            ClearButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ClearButton.Location = new Point(476, 415);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(189, 23);
            ClearButton.TabIndex = 13;
            ClearButton.Text = "Очистить БД для фильтрации";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // GetTablesDatabutton
            // 
            GetTablesDatabutton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            GetTablesDatabutton.Location = new Point(324, 415);
            GetTablesDatabutton.Name = "GetTablesDatabutton";
            GetTablesDatabutton.Size = new Size(146, 23);
            GetTablesDatabutton.TabIndex = 14;
            GetTablesDatabutton.Text = "Просмотреть данные";
            GetTablesDatabutton.UseVisualStyleBackColor = true;
            GetTablesDatabutton.Click += GetTablesDatabutton_Click;
            // 
            // TablesComboBox
            // 
            TablesComboBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            TablesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            TablesComboBox.FormattingEnabled = true;
            TablesComboBox.Items.AddRange(new object[] { "Заказы", "Фильтрация", "Логи" });
            TablesComboBox.Location = new Point(181, 415);
            TablesComboBox.Name = "TablesComboBox";
            TablesComboBox.Size = new Size(137, 23);
            TablesComboBox.TabIndex = 15;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(TablesComboBox);
            Controls.Add(GetTablesDatabutton);
            Controls.Add(ClearButton);
            Controls.Add(SaveFilteredOrdersButton);
            Controls.Add(GetFilteredOrdersButton);
            Controls.Add(FilteredOrdersDataGridView);
            Controls.Add(DatedateTimePicker);
            Controls.Add(DateTimelabel);
            Controls.Add(Citieslabel);
            Controls.Add(CitiesComboBox);
            Controls.Add(CreateOrderButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Заказы";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)FilteredOrdersDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SaveFileDialog saveFileDialog1;
        private Button CreateOrderButton;
        private ComboBox CitiesComboBox;
        private Label Citieslabel;
        private DateTimePicker DatedateTimePicker;
        private Label DateTimelabel;
        private DataGridView FilteredOrdersDataGridView;
        private Button GetFilteredOrdersButton;
        private Button SaveFilteredOrdersButton;
        private Button ClearButton;
        private Button GetTablesDatabutton;
        private ComboBox TablesComboBox;
    }
}
