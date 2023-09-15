using System;
using System.ComponentModel.DataAnnotations;

namespace CreditCalculator.Models
{
    public class LoanCalculationModel
    {
        [Required(ErrorMessage = "Поле 'Сумма займа' обязательно для заполнения.")]
        [Range(1, double.MaxValue, ErrorMessage = "Сумма займа должна быть положительным числом.")]
        public double LoanAmount { get; set; }

        [Required(ErrorMessage = "Поле 'Срок займа' обязательно для заполнения.")]
        [Range(1, int.MaxValue, ErrorMessage = "Срок займа должен быть положительным целым числом.")]
        public int LoanTermMonths { get; set; }

        [Required(ErrorMessage = "Поле 'Ставка' обязательно для заполнения.")]
        [Range(0.01, 100, ErrorMessage = "Ставка должна быть в диапазоне от 0.01 до 100.")]
        public double InterestRate { get; set; }
    }
}