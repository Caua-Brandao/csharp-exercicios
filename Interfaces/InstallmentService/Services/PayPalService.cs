using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstallmentService.Entitites;

namespace InstallmentService.Services
{
    internal class PayPalService : IPaymentService
    {
        public double paymentFee(double amount)
        {
            return amount + (amount * 0.02);
        }

        public double interest(double amount, int month)
        {
            return amount + ((amount * 0.01) * month);
        }
    }
}
