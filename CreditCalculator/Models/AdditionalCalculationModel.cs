using System;
using System.ComponentModel.DataAnnotations;

namespace CreditCalculator.Models
{
    public class AdditionalCalculationModel
    {
        [Required(ErrorMessage = "Поле 'Сумма займа' обязательно для заполнения.")]
        [Range(1, double.MaxValue, ErrorMessage = "Поле 'Сумма займа' должно быть больше 0.")]
        public double LoanAmount { get; set; }

        [Required(ErrorMessage = "Поле 'Срок займа (в днях)' обязательно для заполнения.")]
        [Range(1, int.MaxValue, ErrorMessage = "Поле 'Срок займа (в днях)' должно быть больше 0.")]
        public int LoanTermDays { get; set; }

        [Required(ErrorMessage = "Поле 'Ставка (в день)' обязательно для заполнения.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Поле 'Ставка (в день)' должно быть больше 0.")]
        public double InterestRatePerDay { get; set; }

        [Required(ErrorMessage = "Поле 'Шаг платежа (в днях)' обязательно для заполнения.")]
        [Range(1, int.MaxValue, ErrorMessage = "Поле 'Шаг платежа (в днях)' должно быть больше 0.")]
        public int PaymentIntervalDays { get; set; }
    }
}
