namespace Simple_Banking_System;

public interface IAccount
{
    int Number { get; }
    string Name { get; }
    decimal Balance { get; set; }
}
