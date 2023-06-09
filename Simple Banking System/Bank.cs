namespace Simple_Banking_System;
public class Bank: Singleton<Bank>, IBank
{
    private readonly Dictionary<int, IAccountController> _accounts = new();

    public IAccountController this[int key] => _accounts[key];

    public Bank() { }
    
    public int NextAccountIndex() => _accounts.Count + 1;
    public bool AccountExists(int id) => _accounts.ContainsKey(id);
    public int CreateAccount()
    {
        Console.WriteLine("Enter your name:");
        string name = Console.ReadLine() ?? "";
        while (name.Length == 0)
        {
            Console.WriteLine("Name length must be greater than 0, please re-enter.");
            name = Console.ReadLine() ?? "";
        }
        while (name.Any(c => char.IsDigit(c)))
        {
            Console.WriteLine("Please enter only characters for name (no numbers).");
            name = Console.ReadLine() ?? "";
        }
        var account = new Account(name);
        _accounts.Add(account.Number, new AccountController(account));
        return account.Number;
    }
    
    private IAccountController getAccount(int id) => _accounts[id];

}
