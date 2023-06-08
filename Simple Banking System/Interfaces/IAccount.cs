interface IAccount
{
    public int Number
    { get; set; }
    public string Name
    { get; set; }
    public decimal Balance
    { get; set; }
    public decimal withdraw(decimal amount);
    public decimal deposit(decimal amount);
}
