class Bank : IBank
{
    private static Bank? _instance;
    private static readonly object padlock = new();

    protected Bank() { }
    public static Bank Instance
    {
        get
        {
            lock (padlock)
            {
                if (_instance == null) _instance = new Bank();
                return _instance;
            }
        }
    }

    private Dictionary<int, Account> _accounts = new Dictionary<int, Account> { };

    private Account getAccount(int id) => _accounts[id];
    void addAccount(Account account) => _accounts[account.Number] = account;
    public void deposit(int id, decimal amount) => getAccount(id).deposit(amount);
    public void withdraw(int id, decimal amount) => getAccount(id).withdraw(amount);
    public decimal balance(int id) => getAccount(id).Balance;
    public bool accountExists(int id) => _accounts.ContainsKey(id);
    public int getAccountsLength() => _accounts.Count;
    public int createAccount()
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
        addAccount(account);
        return account.Number;
    }
}
