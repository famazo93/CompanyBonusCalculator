using CompanyBonusCalculator.Model;
using CompanyBonusCalculator.Service;

namespace CompanyBonusCalculatorTest;

public class ProfitCalculatorTests
{
    [SetUp]
    public void Setup()
    {
    }

    private static readonly object[] TestCases =
    {
        // no broker achieving profit
        new object[]
        {
            new List<Broker>
            {
                new Broker("John", 200, 0, 1000, 0.1),
                new Broker("Jack", 200, 0, 1000, 0.1),
                new Broker("Jill", 200, 0, 1000, 0.1)
            },
            new CompanyProfit(0, 600, -600)
        },
        
        // some profit, but have not reached the minimum
        new object[]
        {
            new List<Broker>
            {
                new Broker("John", 200, 100, 1000, 0.1),
                new Broker("Jack", 200, 400, 1000, 0.1),
                new Broker("Jill", 200, 800, 1000, 0.1)
            },
            new CompanyProfit(1300, 600, 700)
        },
        
        // some brokers reached the minimum limit
        new object[]
        {
            new List<Broker>
            {
                new Broker("John", 200, 300, 1000, 0.1),
                new Broker("Jack", 200, 600, 1000, 0.1),
                new Broker("Jill", 200, 1200, 1000, 0.1)
            },
            new CompanyProfit(2100, 720, 1380)
        },
        
        // all brokers have reached the minimum
        new object[]
        {
            new List<Broker>
            {
                new Broker("John", 200, 1200, 1000, 0.1),
                new Broker("Jack", 200, 1200, 1000, 0.1),
                new Broker("Jill", 200, 1200, 1000, 0.1)
            },
            new CompanyProfit(3600, 960, 2640)
        }
    };
    
    [TestCaseSource(nameof(TestCases))]
    public void TestCalculator(List<Broker> brokers, CompanyProfit expectedProfit)
    {
        // arrange
        var profitCalculator = new CompanyProfitCalculator();
        
        // act
        CompanyProfit calculatedProfit = profitCalculator.Calculate(brokers);
        
        // assert
        Assert.That(expectedProfit.Total, Is.EqualTo(calculatedProfit.Total));
        Assert.That(expectedProfit.Salaries, Is.EqualTo(calculatedProfit.Salaries));
        Assert.That(expectedProfit.Remaining, Is.EqualTo(calculatedProfit.Remaining));
    }

    private static readonly object[] bonusTests =
    {
        new object[]
        {
            new Broker("J", 200, 300, 1000, 0.1),
            0
        },
        new object[]
        {
            new Broker("J", 200, 1200, 1000, 0.1),
            120
        },
        new object[]
        {
            new Broker("J", 200, 0, 1000, 0.1),
            0
        }
    };

    [TestCaseSource(nameof(bonusTests))]
    public void TestBonusCalculator(Broker broker, double expectedBonus)
    {
        // act
        double calculatedBonus = BonusCalculator.CalculateBonus(broker);
        
        // assert
        Assert.That(expectedBonus, Is.EqualTo(calculatedBonus));
    }
}