using System;

interface ICoffee
{
    double GetCost();
    string GetDescription();
}

class BaseCoffee : ICoffee
{
    public double GetCost()
    {
        return 5.0;
    }

    public string GetDescription()
    {
        return "Base Coffee";
    }
}

abstract class CoffeeDecorator : ICoffee
{
    protected ICoffee coffee;

    public CoffeeDecorator(ICoffee coffee)
    {
        this.coffee = coffee;
    }

    public virtual double GetCost()
    {
        return coffee.GetCost();
    }

    public virtual string GetDescription()
    {
        return coffee.GetDescription();
    }
}

class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee) { }

    public override double GetCost()
    {
        return coffee.GetCost() + 1.0;
    }

    public override string GetDescription()
    {
        return coffee.GetDescription() + ", Milk";
    }
}

class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(ICoffee coffee) : base(coffee) { }

    public override double GetCost()
    {
        return coffee.GetCost() + 0.5;
    }

    public override string GetDescription()
    {
        return coffee.GetDescription() + ", Sugar";
    }
}

class ChocolateDecorator : CoffeeDecorator
{
    public ChocolateDecorator(ICoffee coffee) : base(coffee) { }

    public override double GetCost()
    {
        return coffee.GetCost() + 2.0;
    }

    public override string GetDescription()
    {
        return coffee.GetDescription() + ", Chocolate";
    }
}

class Program
{
    static void Main()
    {
        ICoffee coffee = new BaseCoffee();
        Console.WriteLine($"{coffee.GetDescription()} : ${coffee.GetCost()}");

        coffee = new MilkDecorator(coffee);
        Console.WriteLine($"{coffee.GetDescription()} : ${coffee.GetCost()}");

        coffee = new SugarDecorator(coffee);
        Console.WriteLine($"{coffee.GetDescription()} : ${coffee.GetCost()}");

        coffee = new ChocolateDecorator(coffee);
        Console.WriteLine($"{coffee.GetDescription()} : ${coffee.GetCost()}");
    }
}
