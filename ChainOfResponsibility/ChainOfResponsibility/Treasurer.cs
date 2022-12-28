using System;
using UpSchool_ChainOfResponsibility.DAL;
using UpSchool_ChainOfResponsibility.DAL.Entities;

namespace UpSchool_ChainOfResponsibility.ChainOfResponsibility
{
    public class Treasurer : Employee
    {
        public override void ProcessRequest(WithdrawViewModel req)
        {
            Context context = new Context();

            if (req.Amount <= 40000)
            {
                BankProcess bankProcess = new BankProcess();
                bankProcess.EmployeeName = "Veznedar - Ayşenur Yıldız";
                bankProcess.Description = "Müşteriye talep edilen tutarın ödemesi vezne sorumlusu tarafından gerçekleştirildi";
                bankProcess.Amount = req.Amount;
                bankProcess.CustomerName = req.CustomerName;
                context.BankProcesses.Add(bankProcess);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                BankProcess bankProcess = new BankProcess();
                bankProcess.EmployeeName = "Veznedar - Ayşenur Yıldız";
                bankProcess.Description = "Müşteriye talep edilen tutar yetkim dahilinde olmadıgı icin islem sube müdür yardımcısına gönderildi";
                bankProcess.Amount = req.Amount;
                bankProcess.CustomerName = req.CustomerName;

                context.BankProcesses.Add(bankProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);

            }
        }
    }
}
