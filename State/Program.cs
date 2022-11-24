// See https://aka.ms/new-console-template for more information

using State;

Console.Title = "State";

var bankAccount = new BankAccount();
bankAccount.Deposit(100);
bankAccount.Withdraw(500);
bankAccount.Withdraw(100);
bankAccount.Deposit(3000);
bankAccount.Withdraw(100);
bankAccount.Deposit(10);
bankAccount.Withdraw(300);
bankAccount.Deposit(300);
bankAccount.Withdraw(100);
bankAccount.Withdraw(6000);
bankAccount.Deposit(6000);

Console.ReadKey();
