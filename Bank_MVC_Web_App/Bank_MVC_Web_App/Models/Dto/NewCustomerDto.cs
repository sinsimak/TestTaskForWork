using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bank_MVC_Web_App.Models.Dto
{
    public class NewCustomerDto
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public int ContractNumber { get; set; }
        public string AccountNumber { get; set; }
    }
}