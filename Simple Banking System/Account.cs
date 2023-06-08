class Account : IAccount
{
    private int _number;
    private string _name;
    private decimal _balance;

    public Account(string name)
    {
        Number = Bank.Instance.getAccountsLength() + 1;
        Name = name;
        Balance = 0;
    }


    public int Number
    {
        get { return _number; }
        set { _number = value; }
    }
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public decimal Balance
    {
        get { return _balance; }
        set { _balance = value; }
    }
    public decimal withdraw(decimal amount)
    {
        if (amount > Balance) throw new Exception("Balance is less than withdrawal amount.");
        Balance -= amount;
        return Balance;
    }
    public decimal deposit(decimal amount)
    {
        Balance += amount;
        return Balance;
    }
}
