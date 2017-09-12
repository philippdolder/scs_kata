using System.Collections.Generic;

namespace MyDailyKata
{
    public interface ITokenizationFactory
    {
        List<Token> SeperateCalculation(string input) ;
    }
}