using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    class InsuranceAgreement
    {
        public Client client; // creating client object
        public double yearlyFee;
        public double risk;
        public double accident;
        public double insuranceAmount;
        public bool isClaimed = false;
        public double totalPayout = 0;
        
        public InsuranceAgreement(int n) //Constructor:  Generating random Insurance Agreement
        {
            Random random = new Random(n);
            client = new Client(n);
            yearlyFee = random.Next(1000, 5000);
            risk = random.Next(5, 101);
            accident = random.Next(5, 21);
            insuranceAmount = yearlyFee * accident;
        }
        public double GetNetProfit()
        {
            return yearlyFee - totalPayout;
        }
        public void nextYearlyFee()
        {
            Random rd = new Random();
            yearlyFee += rd.Next(100,1000);
            //insuranceAmount = yearlyFee * accident;
        }
    }
}