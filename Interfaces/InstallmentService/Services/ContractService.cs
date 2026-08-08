using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstallmentService.Entitites;

namespace InstallmentService.Services
{
    internal class ContractService 
    {
        private IPaymentService _paymentService;


        public ContractService(IPaymentService paymentservice)
        {
            this._paymentService = paymentservice;
        }

        public void ProcessContract(Contract contract, int months)
        {
            DateTime date = contract.Date;
            double installment = contract.TotalValue / months;


            for (int i=1;i<=months;i++)
            {
                DateTime installmentDate = date.AddMonths(i);
                double value = _paymentService.interest(installment, i);
                double finalValue = _paymentService.paymentFee(value);
                Installment inst = new Installment(installmentDate, finalValue);
                contract.Installments.Add(inst);
            }
        }
    }
}
