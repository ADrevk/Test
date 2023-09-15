using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using CreditCalculator.Models;

namespace CreditCalculator.Controllers
{
    public class LoanCalculatorController : Controller
    {
        public IActionResult Calculation()
        {
            var model = new LoanCalculationModel();
            return View(model);
        }
        /// <summary>
        /// Формула рассчета платежа
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Calculate(LoanCalculationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Calculation", model);
            }
            
            double monthlyInterestRate = model.InterestRate / 12 / 100;
            double monthlyPayment = (model.LoanAmount * monthlyInterestRate) /
                                    (1 - Math.Pow(1 + monthlyInterestRate, -model.LoanTermMonths));

            var paymentDetailsList = new List<PaymentDetails>();
            double remainingBalance = model.LoanAmount;

            for (int paymentNumber = 1; paymentNumber <= model.LoanTermMonths; paymentNumber++)
            {
                double interestPayment = remainingBalance * monthlyInterestRate;
                double principalPayment = monthlyPayment - interestPayment;
                remainingBalance -= principalPayment;

                var paymentDetails = new PaymentDetails
                {
                    PaymentNumber = paymentNumber,
                    PaymentDate = DateTime.Now.AddMonths(paymentNumber),
                    PrincipalPayment = principalPayment,
                    InterestPayment = interestPayment,
                    RemainingBalance = remainingBalance
                };

                paymentDetailsList.Add(paymentDetails);
            }

            double totalInterestPaid = paymentDetailsList.Sum(payment => payment.InterestPayment);

            var calculationResults = new CalculationResultsModel
            {
                Payments = paymentDetailsList,
                TotalInterestPaid = totalInterestPaid
            };

            return View("Results", calculationResults);
        }
    }
}