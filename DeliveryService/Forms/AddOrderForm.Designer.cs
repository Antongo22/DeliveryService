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
            label2 = new Label();
            label3 = new Label();
            DatedateTimePicker = new DateTimePicker();
            CitiesComboBox = new ComboBox();
            SaveButton = new Button();
            SuspendLayout();
            // 
            // WeightTextBox
            // 
            WeightTextBox.Location = new Point(69, 23);
            WeightTextBox.Name = "WeightTextBox";
            WeightTextBox.Size = new Size(170, 23);
            WeightTextBox.TabIndex = 0;
            WeightTextBox.TextChanged += WeightTextBox_TextChanged;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 76);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 2;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 123);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 3;
            label3.Text = "label3";
            // 
            // DatedateTimePicker
            // 
            DatedateTimePicker.Location = new Point(69, 117);
            DatedateTimePicker.Name = "DatedateTimePicker";
            DatedateTimePicker.Size = new Size(170, 23);
            DatedateTimePicker.TabIndex = 4;
            // 
            // CitiesComboBox
            // 
            CitiesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            CitiesComboBox.FormattingEnabled = true;
            CitiesComboBox.Location = new Point(69, 73);
            CitiesComboBox.Name = "CitiesComboBox";
            CitiesComboBox.Size = new Size(170, 23);
            CitiesComboBox.TabIndex = 5;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(164, 210);
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
            ClientSize = new Size(254, 245);
            Controls.Add(SaveButton);
            Controls.Add(CitiesComboBox);
            Controls.Add(DatedateTimePicker);
            Controls.Add(label3);
            Controls.Add(label2);
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
        private Label label2;
        private Label label3;
        private DateTimePicker DatedateTimePicker;
        private ComboBox CitiesComboBox;
        private Button SaveButton;
    }
}