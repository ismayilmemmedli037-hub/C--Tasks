using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Bank 
{ 
    internal class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Card CreditCard { get; set; }
        public OperationTransaction[] Transactions { get; set; } = new OperationTransaction[100];
        public int TransactionCount { get; set; } = 0;
    }
}
