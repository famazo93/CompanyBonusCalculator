using CompanyBonusCalculator.Model;

namespace CompanyBonusCalculator.Service;

public class CompanyProfitCalculator
{
    public CompanyProfit Calculate(List<Broker> brokers)
    {
        double total = 0;
        double salaries = 0;
        double remaining = 0;

        foreach (Broker broker in brokers)
        {
            total += broker.Profit;
            salaries += broker.BaseSalary;
            salaries += BonusCalculator.CalculateBonus(broker);
        }
        
        remaining = total - salaries;
        return new CompanyProfit(total, salaries, remaining);
    }
}