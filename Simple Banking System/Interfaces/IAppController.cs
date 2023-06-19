namespace Simple_Banking_System;

public interface IAppController
{
    void StartApp();
    private static bool ValidPromptChar(char c) => c is 'a' or 'b' or 'c' or 'd' or 'e' or 'f' or 'g' or 'h';
}