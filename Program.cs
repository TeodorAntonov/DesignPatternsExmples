// Type: Creational Patterns
//Usage: Often

//Resume: Creates an instance of several families of classes

//The Abstract Factory design pattern provides an interface for creating families of related or
//dependent objects without specifying their concrete classes.

England england = new England();
Battle battleInOldEngland = new Battle(england);
battleInOldEngland.Run();

Console.WriteLine("--------------");

Greece greece = new Greece();
Battle battleOnThermopylae = new Battle(greece);
battleOnThermopylae.Run();

abstract class Country
{
    public abstract Attacker CreateWarrior();
    public abstract Defender CreateDefender();
}

class England : Country
{
    public override Defender CreateDefender()
    {
        return new Saxon();
    }

    public override Attacker CreateWarrior()
    {
        return new Viking();
    }
}

class Greece : Country
{
    public override Defender CreateDefender()
    {
        return new Spartan();
    }

    public override Attacker CreateWarrior()
    {
        return new Persian();
    }
}

abstract class Attacker 
{
    public abstract void Interact(Defender defender);
}

abstract class Defender
{
    public abstract void Interact(Attacker attacker);
}

class Viking : Attacker
{
    public override void Interact(Defender saxon)
    {
        Console.WriteLine(this.GetType().Name + " attacks " + saxon.GetType().Name);
    }
}

class Saxon : Defender
{
    public override void Interact(Attacker viking)
    {
        Console.WriteLine(this.GetType().Name + " defends against " + viking.GetType().Name);
    }
}

class Spartan : Defender
{
    public override void Interact(Attacker persion)
    {
        Console.WriteLine(this.GetType().Name + " defends againts " + persion.GetType().Name);
    }
}

class Persian : Attacker
{
    public override void Interact(Defender spartan)
    {
        Console.WriteLine(this.GetType().Name + " attacks " + spartan.GetType().Name);
    }
}

class Battle
{
    private Attacker _attacker;
    private Defender _defender;

    public Battle(Country country)
    {
        _attacker = country.CreateWarrior();
        _defender = country.CreateDefender();
    }

    public void Run()
    {
        _attacker.Interact(_defender);
        _defender.Interact(_attacker);
    }
}