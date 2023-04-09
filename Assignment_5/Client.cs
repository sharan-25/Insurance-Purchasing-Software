using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment_5
{
    class Client : Person
    { 
        private string occupation;
        public Client(int n)  //Constructor
        {
            Random random = new Random(n);
            string[] names = { "Alice", "Bob", "Viraj", "David", "Emma", "Frank", "Grace", "Henry", "Isha", "John" };
            name = names[random.Next(names.Length)];
        }
    }
}
