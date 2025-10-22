// See https://aka.ms/new-console-template for more information

using System.IO;

Main main = new();
main.Run();


enum IngredientName
{
    EGG,
    MILK,
    FLOUR,
    ONION,
    MUSHROOM,
    CARROT,
    PEAS,
    BACON,
    CHEESE,
    PASTA,
    VEGETABLE_OIL,
    OLIVE_OIL,
    SOY_SAUCE,
}


enum Unit
{
    NONE,
    ML,
    G,
}


struct IngredientDesc
{
    public string Name;
    public Unit Unit;
};


struct IngredientList
{
    public Dictionary<IngredientName, int> List = [];

    public IngredientList()
    {
    }

    public readonly int MultiplesOf(IngredientList other)
    {
        List<int> multiples = [];

        foreach (IngredientName key in List.Keys)
        {
            if (!other.List.ContainsKey(key)) { continue; }

            multiples.Add(List[key] / other.List[key]);
        }

        if (multiples.Count <= 0) { return 0; }

        return multiples.Min();
    }

    public readonly IngredientList Subtract(IngredientList other, int times = 1)
    {
        IngredientList result = new();

        foreach (IngredientName key in other.List.Keys)
        {
            result.List.Add(key, List.TryGetValue(key, out int value) ? value - (other.List[key] * times): -other.List[key] * times);
        }

        return result;
    }
}


class Main
{
    public void Run()
    {
        Console.WriteLine("Hello, World!");

        IngredientList list = new()
        {
            List = new()
            {
                {IngredientName.EGG, 2},
                {IngredientName.MILK, 100},
                {IngredientName.FLOUR, 100},
            }
        };

        IngredientList recipe = new()
        {
            List = new()
            {
                {IngredientName.EGG, 1},
                {IngredientName.MILK, 50},
                {IngredientName.FLOUR, 50},
            }
        };

        Console.WriteLine(list.MultiplesOf(recipe));
        list = list.Subtract(recipe);
        Console.WriteLine(list.MultiplesOf(recipe));
    }


    private readonly Dictionary<IngredientName, IngredientDesc> Ingredients = new()
    {
        {IngredientName.EGG,            new IngredientDesc{ Name = "Eggs",          Unit = Unit.NONE }},
        {IngredientName.MILK,           new IngredientDesc{ Name = "Milk",          Unit = Unit.ML }},
        {IngredientName.FLOUR,          new IngredientDesc{ Name = "Flour",         Unit = Unit.G }},
        {IngredientName.ONION,          new IngredientDesc{ Name = "Onions",        Unit = Unit.NONE }},
        {IngredientName.MUSHROOM,       new IngredientDesc{ Name = "Mushrooms",     Unit = Unit.G }},
        {IngredientName.CARROT,         new IngredientDesc{ Name = "Carrot",        Unit = Unit.NONE }},
        {IngredientName.PEAS,           new IngredientDesc{ Name = "Peas",          Unit = Unit.G }},
        {IngredientName.BACON,          new IngredientDesc{ Name = "Bacon",         Unit = Unit.G }},
        {IngredientName.CHEESE,         new IngredientDesc{ Name = "Cheese",        Unit = Unit.G }},
        {IngredientName.PASTA,          new IngredientDesc{ Name = "Pasta",         Unit = Unit.G }},
        {IngredientName.VEGETABLE_OIL,  new IngredientDesc{ Name = "Vegetable Oil", Unit = Unit.ML }},
        {IngredientName.OLIVE_OIL,      new IngredientDesc{ Name = "Olive Oil",     Unit = Unit.ML }},
        {IngredientName.SOY_SAUCE,      new IngredientDesc{ Name = "Soy Sauce",     Unit = Unit.ML }},
    };
}

