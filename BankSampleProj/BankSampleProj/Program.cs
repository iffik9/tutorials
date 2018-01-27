using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankSampleProj
{
    class Program
    {
        public class BankProject
        {
            int id;
            string name;
            string pancardno;
            string adharno;
            string acno;
            decimal damt;
            decimal wamt;
            public void Register()
            {
                Console.WriteLine("\n\n\t Please enter Bank Details");
                Console.Write("\n\t Enter Id of Customer             : \t");
                id = Convert.ToInt32(Console.ReadLine());
                Console.Write("\n\t Enter Name of Customer           : \t");
                name =Console.ReadLine();
                Console.Write("\n\t Enter Pan Card No of Customer    : \t");
                pancardno = Console.ReadLine();
                Console.Write("\n\t Enter Adhaar Card No of Customer : \t");
                adharno = Console.ReadLine();
                Console.Write("\n\t Enter Account No of Customer     : \t");
                acno = Console.ReadLine();
            }
            public void Customerprofile()
            {
                Console.WriteLine("\n\n\t Details Customer of {0}", name);
                Console.Write("\n\t ID             =  {0} ",id);
                Console.Write("\n\t Name           =  {0} ", name);
                Console.Write("\n\t Pan Card No    =  {0} ", pancardno);
                Console.Write("\n\t Adhaar Card No =  {0} ", adharno);
                Console.Write("\n\t Account No     =  {0} ", acno);
            }
            public void DepositeMoney()
            {
                TakeUserInput:
                    Console.Write("\n\n\tEnter Amount to deposite in {0} Account\t",name);
                    damt = decimal.Parse(Console.ReadLine());
                        if (damt < 100)
                        {
                            Console.Write("\n\n\tMinimum amount to deposite is 100");
                            goto TakeUserInput;
                        }
                        else
                        {
                            Console.Write("\nTransaction Completed successfully. Account Balance is Rs {0} Only", damt); 
                        }                    

            }
            public void Withdraw()
            {
                string tmppan;
                TakeUserInput:
                Console.Write("\n\n\tEnter Amount to withdraw from Customer : {0} :\t",name);
                wamt = decimal.Parse(Console.ReadLine());
                if (wamt < 100)
                {
                    Console.Write("\n\n\tMinimum amount to withdraw is 100");
                    goto TakeUserInput;
                }
                else if (wamt > damt)
                {
                    Console.Write("\n\n\tNo sufficient balance in your account. your balance is {0}",damt);
                    goto TakeUserInput;                    
                }
                else if (wamt >= 50000)
                {
                    if (pancardno == "")
                    {
                        Console.Write("\n\n\tsorry you have not submitted your pan card details cannot withdraw more than 49999 Rs:\t");
                        goto TakeUserInput;
                    }
                    else
                    {
                    EnterPANCard:
                        Console.Write("\n\n\tPlease enter your PAN CARD NO :\t");
                        tmppan = Console.ReadLine();
                        if (tmppan.ToLower().Equals(pancardno.ToLower()))
                        {
                            Console.Write("\n\n\tentered PAN Card Details matched successfully:\n");
                            Console.Write("\nTransaction Completed successfully. Account Balance is Rs {0} Only", (damt - wamt));
                        }
                        else
                        {
                            Console.Write("\n\n\tentered PAN Card Details did not match:\t");
                            goto EnterPANCard;
                        }
                    }
                    
                }
                else
                {
                    Console.Write("\nTransaction Completed successfully. Account Balance is Rs {0} Only", (damt - wamt));
                }
            }
        }
        static void Main(string[] args)
        {
            string ans = "";
            BankProject b = new BankProject();
            BankProject b1 = new BankProject();
           
            b.Register();
            b1.Register();
            
            Console.Write("\n\n\t Do you want to see entered customer profile ?(Y/N)\t");
            ans = Console.ReadLine();
            if (ans.ToLower().Equals("y") || ans.ToLower().Equals("yes"))
            {
                b.Customerprofile();
                b1.Customerprofile();
            }
            
            MainMenu:
            Console.Write("\n\tSelect Transaction\n\n  Deposite(D)\tWithdraw(W)\tExit(X) (Help : Enter D , W or X)  :  ");
            ans = Console.ReadLine();
            if (ans.ToLower().Equals("d"))
            {
                b.DepositeMoney();
                b1.DepositeMoney();
                goto MainMenu;
            }
            else if (ans.ToLower().Equals("w"))
            {
                b.Withdraw();
                b1.Withdraw();
                goto MainMenu;
            }
            else
            {
                Environment.Exit(0);
            }
            Console.ReadLine();
        }
    }
}
