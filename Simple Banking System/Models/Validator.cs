namespace Simple_Banking_System;

public abstract class Validator
{
    public static bool YesOrNo(char c) => c is 'Y' or 'y' or 'N' or 'n';
    public static bool ValidPromptChar(char c) => c is 'a' or 'b' or 'c' or 'd' or 'e' or 'f' or 'g' or 'h';
}