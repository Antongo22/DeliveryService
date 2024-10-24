namespace DeliveryService.Forms
{
    partial class AddOrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddOrderForm));
            WeightTextBox = new TextBox();
            labelWeight = new Label();
            Citieslabel = new Label();
            DateTimelabel = new Label();
            DatedateTimePicker = new DateTimePicker();
            CitiesComboBox = new ComboBox();
            SaveButton = new Button();
            SuspendLayout();
            // 
            // WeightTextBox
            // 
            WeightTextBox.Location = new Point(164, 23);
            WeightTextBox.Name = "WeightTextBox";
            WeightTextBox.Size = new Size(170, 23);
            WeightTextBox.TabIndex = 0;
            // 
            // labelWeight
            // 
            labelWeight.AutoSize = true;
            labelWeight.Location = new Point(12, 26);
            labelWeight.Name = "labelWeight";
            labelWeight.Size = new Size(26, 15);
            labelWeight.TabIndex = 1;
            labelWeight.Text = "Вес";
            // 
            // Citieslabel
            // 
            Citieslabel.AutoSize = true;
            Citieslabel.Location = new Point(12, 76);
            Citieslabel.Name = "Citieslabel";
            Citieslabel.Size = new Size(40, 15);
            Citieslabel.TabIndex = 2;
            Citieslabel.Text = "Город";
            // 
            // DateTimelabel
            // 
            DateTimelabel.AutoSize = true;
            DateTimelabel.Location = new Point(12, 123);
            DateTimelabel.Name = "DateTimelabel";
            DateTimelabel.Size = new Size(131, 15);
            DateTimelabel.TabIndex = 3;
            DateTimelabel.Text = "Дата и время доставки";
            // 
            // DatedateTimePicker
            // 
            DatedateTimePicker.Location = new Point(164, 117);
            DatedateTimePicker.Name = "DatedateTimePicker";
            DatedateTimePicker.Size = new Size(170, 23);
            DatedateTimePicker.TabIndex = 4;
            // 
            // CitiesComboBox
            // 
            CitiesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            CitiesComboBox.FormattingEnabled = true;
            CitiesComboBox.Location = new Point(164, 73);
            CitiesComboBox.Name = "CitiesComboBox";
            CitiesComboBox.Size = new Size(170, 23);
            CitiesComboBox.TabIndex = 5;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(259, 160);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 6;
            SaveButton.Text = "Сохранить";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // AddOrderForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(346, 191);
            Controls.Add(SaveButton);
            Controls.Add(CitiesComboBox);
            Controls.Add(DatedateTimePicker);
            Controls.Add(DateTimelabel);
            Controls.Add(Citieslabel);
            Controls.Add(labelWeight);
            Controls.Add(WeightTextBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddOrderForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Добавить заказ";
            Load += AddOrderForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox WeightTextBox;
        private Label labelWeight;
        private Label Citieslabel;
        private Label DateTimelabel;
        private DateTimePicker DatedateTimePicker;
        private ComboBox CitiesComboBox;
        private Button SaveButton;
    }
}