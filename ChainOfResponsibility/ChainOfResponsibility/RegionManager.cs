using System;
using UpSchool_ChainOfResponsibility.ChainOfResponsibility;
using UpSchool_ChainOfResponsibility.DAL;
using UpSchool_ChainOfResponsibility.DAL.Entities;

namespace ChainOfResponsibility.ChainOfResponsibility
{
    public class RegionManager : Employee
    {
        public override void ProcessRequest(WithdrawViewModel req)
        {
            Context context = new Context();
            if (req.Amount <= 250000)
            {

                BankProcess bankProcess = new BankProcess();
                bankProcess.EmployeeName = "Bölge müdürü - Nazlı Siyah";
                bankProcess.Description = "Müşteriye talep olmuş olduğu tutarın ödemesi bölge müdürü tarafından gerçekleştirildi";
                bankProcess.Amount = req.Amount;
                bankProcess.CustomerName = req.CustomerName;
                context.BankProcesses.Add(bankProcess);
                context.SaveChanges();
            }
            else
            {

                BankProcess bankProcess = new BankProcess();
                bankProcess.EmployeeName = "Bölge müdürü - Nazlı Siyah";
                bankProcess.Description = "Müşteriye talep edilen tutar banka limitlerinin günlük çekim tutarını aştıgı icin ödenemedi.";
                bankProcess.Amount = req.Amount;
                bankProcess.CustomerName = req.CustomerName;

                context.BankProcesses.Add(bankProcess);
                context.SaveChanges();
            

            }
        }
    }
}

