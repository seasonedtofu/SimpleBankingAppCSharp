namespace Simple_Banking_System;

public class BankController
{
    public IAccountController this[Guid key] => Bank.Instance.Accounts[key];
    
    public static bool AccountExists(Guid id) => Bank.Instance.Accounts.ContainsKey(id);

    public static bool AccountActive(Guid id) => Bank.Instance.Accounts[id].Active();

    public static Guid CreateAccount()
    {
        BankLogger.EnterName();
        string name = Console.ReadLine() ?? "";
        while (name.Length == 0)
        {
            BankLogger.NameLength();
            name = Console.ReadLine() ?? "";
        }
        while (name.Any(c => char.IsDigit(c)))
        {
            BankLogger.OnlyCharacters();
            name = Console.ReadLine() ?? "";
        }
        var account = new Account(name);
        Bank.Instance.Accounts.Add(account.Id, new AccountController(account));
        return account.Id;
    }
}