using System;

namespace RiskCalculatorApp
{
    public static class RiskCalculator
    {
        public static decimal CalculateRisk(double probability, decimal damage)
        {
            if (probability < 0 || probability > 1)
                throw new ArgumentException("Вероятность должна быть в диапазоне от 0 до 1.");
            if (damage < 0)
                throw new ArgumentException("Ущерб не может быть отрицательным.");

            return (decimal)probability * damage;
        }
    }
}