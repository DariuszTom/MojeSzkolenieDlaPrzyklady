using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Fund
    {
        
        public int FundNumber { get; set; }
        private string pFundName;

        public Fund(int numer, string pFundName)
        {
            this.FundNumber = numer;
            this.pFundName = pFundName;
        }

        public string MyProperty
        {
            get { return pFundName; }
            set { pFundName = value; }
            
        }
       
    }
}
