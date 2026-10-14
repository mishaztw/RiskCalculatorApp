using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace RiskCalculatorApp
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
            groupBox1 = new GroupBox();
            numDamage = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            grpList = new GroupBox();
            dgvRisks = new DataGridView();
            txtAsset = new TextBox();
            cmbThreat = new ComboBox();
            numProbability = new NumericUpDown();
            btnAdd = new Button();
            btnClear = new Button();
            btnSave = new Button();
            groupBox1.SuspendLayout();
            ((ISupportInitialize)numDamage).BeginInit();
            grpList.SuspendLayout();
            ((ISupportInitialize)dgvRisks).BeginInit();
            ((ISupportInitialize)numProbability).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(numDamage);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label4);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(400, 250);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ввод данных";
            // 
            // numDamage
            // 
            numDamage.Location = new Point(150, 130);
            numDamage.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numDamage.Name = "numDamage";
            numDamage.Size = new Size(150, 23);
            numDamage.TabIndex = 6;
            numDamage.ThousandsSeparator = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 30);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 2;
            label1.Text = "Актив";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 54);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 3;
            label2.Text = "Угроза";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 135);
            label3.Name = "label3";
            label3.Size = new Size(82, 15);
            label3.TabIndex = 4;
            label3.Text = "Ущерб (руб.):";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 88);
            label4.Name = "label4";
            label4.Size = new Size(104, 15);
            label4.TabIndex = 5;
            label4.Text = "Вероятность (0-1)";
            // 
            // grpList
            // 
            grpList.Controls.Add(dgvRisks);
            grpList.Location = new Point(425, 12);
            grpList.Name = "grpList";
            grpList.Size = new Size(465, 260);
            grpList.TabIndex = 1;
            grpList.TabStop = false;
            grpList.Text = "Список рисков";
            // 
            // dgvRisks
            // 
            dgvRisks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRisks.Location = new Point(10, 20);
            dgvRisks.Name = "dgvRisks";
            dgvRisks.Size = new Size(445, 230);
            dgvRisks.TabIndex = 12;
            // 
            // txtAsset
            // 
            txtAsset.Location = new Point(120, 28);
            txtAsset.Name = "txtAsset";
            txtAsset.Size = new Size(260, 23);
            txtAsset.TabIndex = 6;
            // 
            // cmbThreat
            // 
            cmbThreat.FormattingEnabled = true;
            cmbThreat.Items.AddRange(new object[] { "Вирусная атака", "Кража данных", "Отказ оборудования", "Ошибка персонала", "DDoS-атака" });
            cmbThreat.Location = new Point(120, 63);
            cmbThreat.Name = "cmbThreat";
            cmbThreat.Size = new Size(260, 23);
            cmbThreat.TabIndex = 4;
            // 
            // numProbability
            // 
            numProbability.DecimalPlaces = 2;
            numProbability.Location = new Point(150, 98);
            numProbability.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            numProbability.Name = "numProbability";
            numProbability.Size = new Size(100, 23);
            numProbability.TabIndex = 7;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(15, 180);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(150, 35);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Добавить риск";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(180, 180);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(150, 35);
            btnClear.TabIndex = 9;
            btnClear.Text = "Очистить всё";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(15, 220);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(315, 30);
            btnSave.TabIndex = 10;
            btnSave.Text = "Сохранить отчет";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 561);
            Controls.Add(btnSave);
            Controls.Add(btnClear);
            Controls.Add(btnAdd);
            Controls.Add(numProbability);
            Controls.Add(cmbThreat);
            Controls.Add(txtAsset);
            Controls.Add(grpList);
            Controls.Add(groupBox1);
            Location = new Point(15, 220);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Расчет рисков ИБ";
            Load += MainForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((ISupportInitialize)numDamage).EndInit();
            grpList.ResumeLayout(false);
            ((ISupportInitialize)dgvRisks).EndInit();
            ((ISupportInitialize)numProbability).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox grpList;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtAsset;
        private ComboBox cmbThreat;
        private NumericUpDown numProbability;
        private NumericUpDown numDamage;
        private Button btnAdd;
        private Button btnClear;
        private Button btnSave;
        private DataGridView dgvRisks;
    }
}
