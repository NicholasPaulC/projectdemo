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
            IngredientList test = new();

            Assert.DoesNotThrow(() => test = ingredients1.Subtract(ingredients2));
            
            Assert.That(test.List.ContainsKey(IngredientName.MILK), Is.False);
        }

        [Test]
        public void Multiple()
        {
            int multiples1 = 0;

            Assert.DoesNotThrow(() => multiples1 = ingredients1.MultiplesOf(ingredients2));

            Assert.Equals(multiples1, 1);

            int multiples2 = 0;
            Assert.DoesNotThrow(() => multiples2 = ingredients1.MultiplesOf(ingredients2));

            Assert.Equals(multiples2, 2);

        }

        [Test]
        public void Subtract()
        {
            IngredientList test = new();

            Assert.DoesNotThrow(() => test = ingredients3.Subtract(ingredients1));

            Assert.Equals(test.List[IngredientName.EGG], 1);
        }

        [Test]
        public void SubtractRemoveNegativesAndZero()
        {
            IngredientList test = new();

            Assert.DoesNotThrow(() => test = ingredients1.Subtract(ingredients3));

            Assert.That(test.List.ContainsKey(IngredientName.EGG), Is.False);
        }

        [Test]
        public void Multiply()
        {
            IngredientList test = new();

            Assert.DoesNotThrow(() => test = ingredients1.Multiply(2));

            Assert.Equals(test.List[IngredientName.EGG], 2);
        }
    }
}