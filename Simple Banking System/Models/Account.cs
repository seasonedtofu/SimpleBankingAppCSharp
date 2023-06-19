
namespace Simple_Banking_System;
class Account : IAccount
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public decimal Balance { get; set; }
    public bool Active { get; set; }

    public Account(string name, decimal balance = 0)
    {
        Id = Guid.NewGuid();
        Name = name;
        Balance = balance;
        Active = true;
    }
}
