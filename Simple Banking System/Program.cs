App.Instance.startApp();

interface IApp
{
    public void startApp();
}

class App: IApp
{
    private static App? _instance;
    private static readonly object padlock = new();

    protected App() { }
    public static App Instance
    {
        get
        {
            lock (padlock)
            {
                if (_instance == null) _instance = new App();
                return _instance;
            }
        }
    }

    private char _choice;
    private int _id;
    private decimal _amount;

    public void startApp()
    {
        while (true)
        {
            prompt();
            _choice = Console.ReadKey().KeyChar;
            Console.WriteLine("");
            while (!validChar(_choice))
            {
                Console.WriteLine("Invalid choice, please try again.");
                _choice = Console.ReadKey().KeyChar;
                Console.WriteLine("");
            }
            if (_choice == 'f') return;
            else if (_choice == 'a')
            {
                Console.WriteLine($"Your account number is {Bank.Instance.createAccount()}");
                continue;
            }
            askForId("Please enter your bank account id.", out _id);
            if (!validAccountCheck(_id)) continue;
            else if (_choice == 'd') Console.WriteLine($"Your balance is {Bank.Instance.balance(_id)}");
            else if (_choice == 'b')
            {
                askForAmount("Enter amount you would like to deposit.");
                Bank.Instance.deposit(_id, _amount);
            }
            else if (_choice == 'c')
            {
                askForAmount("Enter amount you would like to withdraw.");
                Bank.Instance.withdraw(_id, _amount);
            }
            else
            {
                int toId;
                askForId("Enter the id of the account you would like to transfer to.", out toId);
                if (!validAccountCheck(toId)) continue;
                askForAmount("Enter the amount you would like to transfer.");
                Bank.Instance.withdraw(_id, _amount);
                Bank.Instance.deposit(toId, _amount);
            }
        }
    }

    private void prompt()
    {
        Console.WriteLine("Enter the character of the option you would like to choose.");
        Console.WriteLine("a. Create Account");
        Console.WriteLine("b. Deposit");
        Console.WriteLine("c. Withdraw");
        Console.WriteLine("d. Check Balance");
        Console.WriteLine("e. Transfer Funds");
        Console.WriteLine("f. Exit");
    }
    private bool validChar(char c) => c == 'a' || c == 'b' || c == 'c' || c == 'd' || c == 'e' || c == 'f';

    private void askForId(string text, out int output)
    {
        Console.WriteLine(text);
        bool success = int.TryParse(Console.ReadLine(), out output);
        while (!success)
        {
            Console.WriteLine("Please enter only numbers and try again.");
            success = int.TryParse(Console.ReadLine(), out output);
        }
    }
    private void askForAmount(string text)
    {
        Console.WriteLine(text);
        bool success = Decimal.TryParse(Console.ReadLine(), out _amount);
        while (!success)
        {
            Console.WriteLine("Please enter only numbers and try again.");
            success = Decimal.TryParse(Console.ReadLine(), out _amount);
        }
    }
    private bool validAccountCheck(int id)
    {
        if (!Bank.Instance.accountExists(id))
        {
            Console.WriteLine("Account does not exist, please re-select option and try again.");
            return false;
        }
        return true;
    }
}