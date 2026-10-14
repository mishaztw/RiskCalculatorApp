using System;

namespace RiskCalculatorApp
{
    public class RiskItem
    {
        public string AssetName { get; set; } = string.Empty;
        public string ThreatName { get; set; } = string.Empty;
        public double Probability { get; set; }
        public decimal Damage { get; set; }

        public decimal RiskValue => (decimal)Probability * Damage;

        public string RiskLevel
        {
            get
            {
                if (RiskValue <= 5000) return "Низкий";
                if (RiskValue <= 20000) return "Средний";
                return "Высокий";
            }
        }
    }
}