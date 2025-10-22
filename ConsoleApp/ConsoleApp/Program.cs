// See https://aka.ms/new-console-template for more information

using System.IO;

Main main = new();
main.Run();


enum IngredientName
{
    EGG,
    MILK,
    FLOUR,
    RICE,
    ONION,
    MUSHROOM,
    CARROT,
    ZUCCHINI,
    PEAS,
    BACON,
    CHICKEN,
    CHEESE,
    PASTA,
    VEGETABLE_OIL,
    OLIVE_OIL,
    SOY_SAUCE,
    LAST
}


struct IngredientList
{
    public Dictionary<IngredientName, int> List = [];

    public IngredientList()
    {
    }

    public readonly int MultiplesOf(IngredientList other)
    {
        List<int> multiples = [];

        foreach (IngredientName key in other.List.Keys)
        {
            if (!List.ContainsKey(key)) { return 0; }

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
            int new_value = List.TryGetValue(key, out int value) ? value - (other.List[key] * times) : -other.List[key] * times;

            if (new_value <= 0)
            {
                result.List.Remove(key);
                continue;
            }

            result.List.Add(key, new_value);
        }

        return result;
    }

    public readonly IngredientList Multiply(int by)
    {
        IngredientList result = new();

        foreach (IngredientName key in List.Keys)
        {
            result.List.Add(key, List[key] * by);
        }

        return result;
    }
}


class Main
{
    enum Unit
    {
        NONE,
        ML,
        G,
    }


    private readonly Dictionary<Unit, string> UnitNames = new()
    {
        {Unit.NONE, ""},
        {Unit.ML,   "ml"},
        {Unit.G,    "g"},
    };


    struct IngredientDesc
    {
        public string Name;
        public Unit Unit;
    };


    private readonly Dictionary<IngredientName, IngredientDesc> IngredientDescs = new()
    {
        {IngredientName.EGG,            new IngredientDesc{ Name = "Eggs",          Unit = Unit.NONE }},
        {IngredientName.MILK,           new IngredientDesc{ Name = "Milk",          Unit = Unit.ML }},
        {IngredientName.FLOUR,          new IngredientDesc{ Name = "Flour",         Unit = Unit.G }},
        {IngredientName.RICE,           new IngredientDesc{ Name = "Rice",          Unit = Unit.G }},
        {IngredientName.ONION,          new IngredientDesc{ Name = "Onions",        Unit = Unit.NONE }},
        {IngredientName.MUSHROOM,       new IngredientDesc{ Name = "Mushrooms",     Unit = Unit.G }},
        {IngredientName.CARROT,         new IngredientDesc{ Name = "Carrots",       Unit = Unit.NONE }},
        {IngredientName.ZUCCHINI,       new IngredientDesc{ Name = "Zucchini",      Unit = Unit.NONE }},
        {IngredientName.PEAS,           new IngredientDesc{ Name = "Peas",          Unit = Unit.G }},
        {IngredientName.BACON,          new IngredientDesc{ Name = "Bacon",         Unit = Unit.G }},
        {IngredientName.CHICKEN,        new IngredientDesc{ Name = "Chicken",       Unit = Unit.G }},
        {IngredientName.CHEESE,         new IngredientDesc{ Name = "Cheese",        Unit = Unit.G }},
        {IngredientName.PASTA,          new IngredientDesc{ Name = "Pasta",         Unit = Unit.G }},
        {IngredientName.VEGETABLE_OIL,  new IngredientDesc{ Name = "Vegetable Oil", Unit = Unit.ML }},
        {IngredientName.OLIVE_OIL,      new IngredientDesc{ Name = "Olive Oil",     Unit = Unit.ML }},
        {IngredientName.SOY_SAUCE,      new IngredientDesc{ Name = "Soy Sauce",     Unit = Unit.ML }},
    };


    private IngredientList Pantry = new()
    {
        List = new()
            {
                {IngredientName.EGG, 16},
                {IngredientName.MILK, 200},
                {IngredientName.FLOUR, 500},
                {IngredientName.ONION, 4},
                {IngredientName.MUSHROOM, 500},
                {IngredientName.CARROT, 4},
                {IngredientName.RICE, 1000 },
                {IngredientName.BACON, 200 },
                {IngredientName.PEAS, 500 },
                {IngredientName.SOY_SAUCE, 250 },
                {IngredientName.ZUCCHINI, 3 },
                {IngredientName.CHEESE, 500 },
                {IngredientName.VEGETABLE_OIL, 500 },
                {IngredientName.PASTA, 250 },
                {IngredientName.OLIVE_OIL, 500 },
                {IngredientName.CHICKEN, 250 },
            }
    };


    enum RecipeName
    {
        FRIED_RICE,
        ZUCCHINI_SLICE,
        CHICKEN_PASTA,
        LAST
    }


    struct RecipeDesc
    {
        public string Name;
        public IngredientList Ingredients;
    }


    private readonly Dictionary<RecipeName, RecipeDesc> RecipeDescs = new()
    {
        {RecipeName.FRIED_RICE, new RecipeDesc{ 
            Name = "Fried Rice", 
            Ingredients = new IngredientList{ List = {
                    {IngredientName.RICE, 250 },
                    {IngredientName.EGG, 2 },
                    {IngredientName.BACON, 50 },
                    {IngredientName.CARROT, 1 },
                    {IngredientName.ONION, 2 },
                    {IngredientName.PEAS, 120 },
                    {IngredientName.SOY_SAUCE, 15 },
                }
            } 
        }},
        {RecipeName.ZUCCHINI_SLICE, new RecipeDesc{
            Name = "Zucchini Slice",
            Ingredients = new IngredientList{ List = {
                    {IngredientName.EGG, 5 },
                    {IngredientName.FLOUR, 150 },
                    {IngredientName.ZUCCHINI, 2 },
                    {IngredientName.ONION, 1 },
                    {IngredientName.BACON, 200 },
                    {IngredientName.CHEESE, 250 },
                    {IngredientName.VEGETABLE_OIL, 250 },
                }
            }
        }},
        {RecipeName.CHICKEN_PASTA, new RecipeDesc{
            Name = "Chicken Pasta",
            Ingredients = new IngredientList{ List = {
                    {IngredientName.PASTA, 250 },
                    {IngredientName.OLIVE_OIL, 15 },
                    {IngredientName.MUSHROOM, 200 },
                    {IngredientName.CHICKEN, 200 },
                    {IngredientName.ONION, 1 },
                    {IngredientName.MILK, 375 },
                    {IngredientName.CHEESE, 155 },
                }
            }
        }},
    };


    private string IngredientListAsString(IngredientList list)
    {
        if (list.List.Count <= 0)
        {
            return "Your Pantry is empty";
        }

        string value = "";

        foreach (IngredientName name in list.List.Keys) 
        {
            IngredientDesc desc = IngredientDescs[name];

            value += list.List[name] + UnitNames[desc.Unit] + " " + IngredientDescs[name].Name + "\n";
        }

        return value;
    }


    private static int GetUserSelection()
    {
        string? input = Console.ReadLine();
        Console.Write("\n");

        if (input == null)
        {
            return GetUserSelection();
        }

        return int.Parse(input);
    }


    private void MakeRecipe(RecipeName name, int serves)
    {
        while (true)
        {
            RecipeDesc desc = RecipeDescs[name];
            IngredientList multipliedList = desc.Ingredients.Multiply(serves);

            Console.WriteLine($"{desc.Name} ({serves} serves)");
            Console.WriteLine(IngredientListAsString(multipliedList));

            Console.WriteLine("[1] Make and Remove Ingredients form Pantry");
            Console.WriteLine("[2] Change Serves");
            Console.WriteLine("[0] Back");

            switch (GetUserSelection())
            {
                case 1:
                    if (Pantry.MultiplesOf(multipliedList) <= 0)
                    {
                        Console.WriteLine("You don't have enough in your Pantry to make this");
                        break;
                    }

                    Pantry = Pantry.Subtract(multipliedList);

                    Console.WriteLine($"Ingredients to make {serves} serves of {desc.Name} removed from your pantry");
                    return;
                case 2:
                    Console.WriteLine("Enter a new number of serves");
                    serves = GetUserSelection();
                    break;
                case 0:
                    return;
            }
        }
    }


    private void SelectRecipe(int serves)
    {
        while (true)
        {
            Console.WriteLine("Select a Recipe to view or make:");

            foreach (RecipeName name in RecipeDescs.Keys)
            {
                RecipeDesc desc = RecipeDescs[name];
                int multiples = Pantry.MultiplesOf(desc.Ingredients);
            
                if (multiples < serves) { continue; }

                Console.WriteLine($"[{(int)(name + 1)}] {desc.Name}");
                Console.WriteLine($"    Enough for {multiples} serves");
            }

            Console.Write("\n");
            Console.WriteLine("[0] Back");

            int selection = GetUserSelection();

            if (selection == 0) { return; }

            selection--;

            if (selection is < 0 or >= (int)RecipeName.LAST)
            {
                Console.WriteLine($"Please enter a valid selection 0-{RecipeName.LAST}");
                break;
            }

            MakeRecipe((RecipeName)selection, Math.Max(serves, 1));
            return;
        }
    }


    private void PreSelectRecipe()
    {
        while (true)
        {
            Console.WriteLine("What Recipes would you like to select from?");
            Console.WriteLine("[1] All Recipes");
            Console.WriteLine("[2] Recipes by Serving Number");
            Console.WriteLine("[0] Back\n");

            switch(GetUserSelection())
            {
                case 1:
                    SelectRecipe(0);
                    return;
                case 2:
                    Console.WriteLine("Enter the number of servings to filter by");
                    SelectRecipe(GetUserSelection());
                    return;
                case 0:
                    return;
                default:
                    Console.WriteLine("Please enter a valid selection 0-2");
                    break;
            }
        }
    }


    public void Run()
    {
        Console.WriteLine("Welcome to the Meal Planner\n");
        while (true)
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1] View Your Pantry");
            Console.WriteLine("[2] Select a Recipe");
            //Console.WriteLine("[3] Make a Grocery List");
            Console.WriteLine("[0] Exit\n");

            switch(GetUserSelection())
            {
                case 1:
                    Console.WriteLine("You Have:");
                    Console.WriteLine(IngredientListAsString(Pantry));
                    break;
                case 2:
                    PreSelectRecipe();
                    break;
                //case 3:
                //    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Please enter a valid selection 0-3");
                    break;
            }
        }
    }
}

