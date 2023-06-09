
namespace Simple_Banking_System;
class Account : IAccount
{
    public int Number { get; init; }
    public string Name { get; init; }
    public decimal Balance { get; set; }

    public Account(string name, decimal balance = 0)
    {
        Number = Bank.Instance.NextAccountIndex();
        Name = name;
        Balance = balance;
    }
}
