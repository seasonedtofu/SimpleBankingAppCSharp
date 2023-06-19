namespace Simple_Banking_System;

public class AccountController: IAccountController
{
    private readonly IAccount _account;

    public AccountController(IAccount account) => _account = account;

    public decimal CheckBalance() => _account.Balance;
    
    public void Deposit(decimal amount) => _account.Balance += amount;

    public void Withdraw(decimal amount)
    {
        if (amount > CheckBalance())
        {
            throw new Exception($"You do not have {amount} in your current balance.");
        }
        _account.Balance -= amount;
    }

    public bool Active() => _account.Active;
    public void CloseAccount() {
        if (CheckBalance() > 0)
        {
            BankLogger.CloseAccountBalance();
            return;
        }
        BankLogger.CloseAccountPrompt();
        var answer = Console.ReadKey().KeyChar;

        while (!Validator.YesOrNo(answer))
        {
            BankLogger.EnterValidYesOrNo();
            answer = Console.ReadKey().KeyChar;
            BankLogger.NewLine();
        }
        
        if (answer is 'Y' or 'y') _account.Active = false;
    }

    public void ReopenAccount()
    {
        if (!_account.Active)
        {
            _account.Active = true;
            return;
        }
        BankLogger.AccountAlreadyActive();
    }
}