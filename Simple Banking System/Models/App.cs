namespace Simple_Banking_System;

public class App: Singleton<App>
{
    public char Choice { get; set; }
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public readonly BankController BankController = new();
}