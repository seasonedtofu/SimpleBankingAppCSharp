interface IBank
{
    public static Bank? Instance { get; }
    public void deposit(int id, decimal amount);
    public void withdraw(int id, decimal amount);
    public decimal balance(int id);
    public bool accountExists(int id);
    public int getAccountsLength();
    public int createAccount();
}
