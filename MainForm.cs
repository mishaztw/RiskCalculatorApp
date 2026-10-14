using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace RiskCalculatorApp
{
    public partial class MainForm : Form
    {
        // Список для хранения рисков
        private BindingList<RiskItem> riskList = new BindingList<RiskItem>();

        // Диаграмма (создаётся программно)
        private Chart chartRisks;

        public MainForm()
        {
            InitializeComponent();

            // Привязка кнопок к обработчикам
            btnAdd.Click += btnAdd_Click;
            btnClear.Click += btnClear_Click;
            btnSave.Click += btnSave_Click;

            // Инициализация диаграммы и таблицы
            CreateChart();
            SetupGrid();
        }

        // Программное создание диаграммы
        private void CreateChart()
        {
            chartRisks = new Chart();
            chartRisks.Location = new Point(12, 340);
            chartRisks.Size = new Size(878, 240);
            chartRisks.Name = "chartRisks";
            chartRisks.BackColor = Color.WhiteSmoke;

            ChartArea area = new ChartArea("MainArea");
            area.BackColor = Color.White;
            chartRisks.ChartAreas.Add(area);

            Legend legend = new Legend("MainLegend");
            legend.Docking = Docking.Bottom;
            legend.Alignment = StringAlignment.Center;
            legend.Font = new Font("Segoe UI", 10);
            chartRisks.Legends.Add(legend);

            Title title = new Title("Распределение рисков по уровням");
            title.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            chartRisks.Titles.Add(title);

            Series series = new Series("RiskLevels");
            series.ChartType = SeriesChartType.Pie;
            series.IsValueShownAsLabel = true;
            series.Label = "#PERCENT{P0}";
            series.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            series["PieLabelStyle"] = "Outside";

            chartRisks.Series.Add(series);

            this.Controls.Add(chartRisks);
            chartRisks.BringToFront();
        }

        // Настройка таблицы DataGridView
        private void SetupGrid()
        {
            dgvRisks.AutoGenerateColumns = false;
            dgvRisks.AllowUserToAddRows = false;
            dgvRisks.ReadOnly = true;
            dgvRisks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRisks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvRisks.Columns.Clear();
            dgvRisks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "AssetName", HeaderText = "Актив" });
            dgvRisks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ThreatName", HeaderText = "Угроза" });
            dgvRisks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Probability", HeaderText = "Вероятность", DefaultCellStyle = new DataGridViewCellStyle { Format = "P0" } });
            dgvRisks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Damage", HeaderText = "Ущерб (руб.)", DefaultCellStyle = new DataGridViewCellStyle { Format = "C0" } });
            dgvRisks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "RiskValue", HeaderText = "Риск (руб.)", DefaultCellStyle = new DataGridViewCellStyle { Format = "C0" } });
            dgvRisks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "RiskLevel", HeaderText = "Уровень" });

            dgvRisks.DataSource = riskList;
        }

        // Обновление диаграммы — БЕЗОПАСНОЕ
        private void UpdateChart()
        {
            if (chartRisks == null || chartRisks.Series.Count == 0) return;

            var series = chartRisks.Series[0];

            // Полностью очищаем точки и добавляем заново
            series.Points.Clear();

            int lowCount = riskList.Count(r => r.RiskLevel == "Низкий");
            int midCount = riskList.Count(r => r.RiskLevel == "Средний");
            int highCount = riskList.Count(r => r.RiskLevel == "Высокий");

            if (lowCount > 0)
            {
                int idx = series.Points.AddXY("Низкий", lowCount);
                series.Points[idx].Color = Color.LightGreen;
            }
            if (midCount > 0)
            {
                int idx = series.Points.AddXY("Средний", midCount);
                series.Points[idx].Color = Color.Gold;
            }
            if (highCount > 0)
            {
                int idx = series.Points.AddXY("Высокий", highCount);
                series.Points[idx].Color = Color.IndianRed;
            }
        }

        // Кнопка "Добавить риск"
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string asset = txtAsset.Text.Trim();
                string threat = cmbThreat.Text.Trim();
                double prob = (double)numProbability.Value;
                decimal damage = numDamage.Value;

                if (string.IsNullOrEmpty(asset) || string.IsNullOrEmpty(threat))
                {
                    MessageBox.Show("Заполните название актива и выберите угрозу!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                RiskCalculator.CalculateRisk(prob, damage);

                var risk = new RiskItem
                {
                    AssetName = asset,
                    ThreatName = threat,
                    Probability = prob,
                    Damage = damage
                };

                riskList.Add(risk);
                UpdateChart();

                txtAsset.Clear();
                cmbThreat.SelectedIndex = -1;
                numProbability.Value = 0;
                numDamage.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопка "Очистить всё"
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Очистить все данные?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                riskList.Clear();
                UpdateChart();
            }
        }

        // Кнопка "Сохранить отчет"
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Текстовые файлы (*.txt)|*.txt",
                FileName = "Отчет_по_рискам.txt"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(sfd.FileName))
                {
                    writer.WriteLine("ОТЧЕТ ПО РИСКАМ ИНФОРМАЦИОННОЙ БЕЗОПАСНОСТИ");
                    writer.WriteLine("Дата: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm"));
                    writer.WriteLine(new string('-', 70));
                    writer.WriteLine($"{"Актив",-20} {"Угроза",-20} {"Риск",15} {"Уровень",10}");

                    foreach (var r in riskList)
                    {
                        writer.WriteLine($"{r.AssetName,-20} {r.ThreatName,-20} {r.RiskValue,15:C0} {r.RiskLevel,10}");
                    }

                    writer.WriteLine(new string('-', 70));
                    writer.WriteLine($"Всего записей: {riskList.Count}");
                }

                MessageBox.Show("Отчет сохранен!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}