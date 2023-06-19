namespace Simple_Banking_System;

public class AccountController: IAccountController
{ 
    readonly IAccount _account;

    public AccountController(IAccount account) => _account = account;

    public decimal CheckBalance() => _account.Balance;
    
    public void Deposit(decimal amount) => _account.Balance += amount;

    public void Withdraw(decimal amount)
    {
        if (amount > _account.Balance)
        {
            throw new Exception($"You do not have {amount} in your current balance.");
        }
        _account.Balance -= amount;
    }

    public bool Active() => _account.Active;
}