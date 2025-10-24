using NUnit.Framework.Internal;

namespace TestProject
{
    public class Tests
    {
        private IngredientList ingredients1;
        private IngredientList ingredients2;
        private IngredientList ingredients3;

        [SetUp]
        public void Setup()
        {
            ingredients1 = new()
            {
                List =
                {
                    {IngredientName.EGG, 1},
                }
            };

            ingredients2 = new()
            {
                List =
                {
                    {IngredientName.MILK, 1},
                }
            };

            ingredients3 = new()
            {
                List =
                {
                    {IngredientName.EGG, 2},
                }
            };
        }

        [Test]
        public void InvalidKey()
        {
            IngredientList test = ingredients1.Subtract(ingredients2);
            
            Assert.That(test.List.ContainsKey(IngredientName.MILK), Is.False);
        }

        [Test]
        public void Multiple()
        {
            int multiples = ingredients1.MultiplesOf(ingredients1);

            Assert.That(multiples, Is.EqualTo(1));
        }

        [Test]
        public void Subtract()
        {
            IngredientList test = ingredients3.Subtract(ingredients1);

            Assert.That(test.List[IngredientName.EGG], Is.EqualTo(1));
        }

        [Test]
        public void SubtractRemoveNegativesAndZero()
        {
            IngredientList test = ingredients1.Subtract(ingredients3);

            Assert.That(test.List.ContainsKey(IngredientName.EGG), Is.False);
        }

        [Test]
        public void Multiply()
        {
            IngredientList test = ingredients1.Multiply(2);

            Assert.That(test.List[IngredientName.EGG], Is.EqualTo(2));
        }
    }
}