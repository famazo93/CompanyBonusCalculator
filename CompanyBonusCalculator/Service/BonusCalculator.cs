using CompanyBonusCalculator.Model;

namespace CompanyBonusCalculator.Service;

public class BonusCalculator
{
    public static double CalculateBonus(Broker broker)
    {
        return broker.Profit >= broker.Minimum ? broker.Profit * broker.Multiplier : 0;
    }
}