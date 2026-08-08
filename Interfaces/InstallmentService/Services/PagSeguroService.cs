using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallmentService.Services
{
    internal class PagSeguroService : IPaymentService
    {
        public double paymentFee(double amount)
        {
            return amount + (amount * 0.08);
        }

        public double interest(double amount, int month)
        {
            return amount + ((amount * 0.03) * month);
        }
    }
}
