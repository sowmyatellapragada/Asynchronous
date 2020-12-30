using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{ 


    public class Students
    {
        public int Id { get; set; }

        public string StudentName { get; set; }


        public int StudentFee { get; set; }

        public int Allowance { get; set; }


        public int TotalAllowance { get; private set; }


        public void CalculateTotalFeeToCollege()
        {
            this.TotalAllowance = this.StudentFee - this.Allowance;
            Thread.Sleep(this.TotalAllowance);
        }
    }
}
