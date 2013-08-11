using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bank_MVC_Web_App.Services
{
    public class ContractNumberGenerator
    {
        private static int _contractNumber; 
        private static ContractNumberGenerator _instance;
        private ContractNumberGenerator()
        {
            _contractNumber = 0;
        }

        public static ContractNumberGenerator Instance()
        {
            if(_instance == null)
            {
                _instance = new ContractNumberGenerator();
            }
            return _instance;
        }

        public int GetContractNumber()
        {
            _contractNumber++;
            return _contractNumber;
        }
    }
}