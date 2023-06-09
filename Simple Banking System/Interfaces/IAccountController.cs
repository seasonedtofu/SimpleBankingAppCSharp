namespace Simple_Banking_System;

public interface IAccountController
{
    decimal CheckBalance();
    void Deposit(decimal amount);
    void Withdraw(decimal amount);
    bool Active();
    void CloseAccount();
    void ReopenAccount();
}