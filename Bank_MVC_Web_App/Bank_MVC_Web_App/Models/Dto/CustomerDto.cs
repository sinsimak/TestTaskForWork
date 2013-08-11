using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bank_MVC_Web_App.Models.Dto
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public int ContractNumber { get; set; }

        public List<string> AccountNumberList { get; set; } 
    }
}