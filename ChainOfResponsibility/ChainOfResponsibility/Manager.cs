using System;
using UpSchool_ChainOfResponsibility.ChainOfResponsibility;
using UpSchool_ChainOfResponsibility.DAL;
using UpSchool_ChainOfResponsibility.DAL.Entities;

namespace ChainOfResponsibility.ChainOfResponsibility
{
	public class Manager:Employee
	{
		public Manager()
		{
		}

        public override void ProcessRequest(WithdrawViewModel req)
        {
            Context context = new Context();

            if (req.Amount <= 150000)
            {
                BankProcess bankProcess = new BankProcess();
                bankProcess.EmployeeName = "Şube müdürü - Hakan Kayalı";
                bankProcess.Description = "Müşteriye talep olmuş olduğu tutarın ödemesi şube müdürü tarafından gerçekleştirildi";
                bankProcess.Amount = req.Amount;
                bankProcess.CustomerName = req.CustomerName;
                context.BankProcesses.Add(bankProcess);
                context.SaveChanges();


            }
            else if (NextApprover != null)
            {
                BankProcess bankProcess = new BankProcess();
                bankProcess.EmployeeName = "Şube müdürü - Hakan Kayalı";
                bankProcess.Description = "Müşteriye talep ettiği tutar yetkim dahilinde olmadıgı icin islem bölge müdürüne gönderildi.";
                bankProcess.Amount = req.Amount;
                bankProcess.CustomerName = req.CustomerName;

                context.BankProcesses.Add(bankProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);

            }
        }
    }
}

