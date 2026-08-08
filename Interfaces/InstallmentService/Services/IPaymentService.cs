using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallmentService.Services
{
    internal interface IPaymentService
    {
        double paymentFee(double amount);
        double interest(double amount, int month);

    }
}