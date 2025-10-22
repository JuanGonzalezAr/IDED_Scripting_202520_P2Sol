using NUnit.Framework.Legacy;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(40)]
        [TestCase(0)]
        [TestCase(-90)]
        [TestCase(256)]
        public void TestMoveCreation(int poder)
        {
            var move = new Move("Water Gun", PokemonType.Water, Move.MoveType.Special, poder);

            //ClassicAssert.True(move.BasePower > 0 && move.BasePower < 256);
            //Assert.That(move.BasePower, Is.InRange(1, 255));
            //Assert.That(move.BasePower, Is.GreaterThan(0).And.LessThan(256));
            //Assert.That(move.BasePower, Is.AtLeast(1).And.AtMost(255));

            ClassicAssert.LessOrEqual(move.BasePower, 255);
            ClassicAssert.GreaterOrEqual(move.BasePower, 1);
        }

        [Test]
        public void TestDefaultMovePower()
        {
            Move move1 = new Move("Water Gun", PokemonType.Water, Move.MoveType.Special);
            Assert.That(move1.BasePower, Is.EqualTo(100));
        }

        [Test]
        public void TestPokemonCreation()
        {
            Pokemon squirtle = new Pokemon("Squirtle", PokemonType.Water);

            Assert.That(squirtle.Level, Is.EqualTo(1));
            Assert.That(squirtle.Attack, Is.EqualTo(10));
            Assert.That(squirtle.Defense, Is.EqualTo(10));
            Assert.That(squirtle.SpAttack, Is.EqualTo(10));
            Assert.That(squirtle.SpDefense, Is.EqualTo(10));
        }


        [Test]
        public void MODAtack()
        {
            Move move = new Move("Movimiento 1", PokemonType.Fire, Move.MoveType.Special);
            List<PokemonType> moves = new List<PokemonType>();
            moves.Add(PokemonType.Fire);
            moves.Add(PokemonType.Ground);
            double mod;

            mod = CalculatorMOD.CalculateMod(move, moves);
            Assert.That(mod, Is.EqualTo(0.5));
        }

        [TestCase(PokemonType.Fire, PokemonType.Ground, 1.0,
        "Ataque Fuego contra Tierra, (1x)")]
        [TestCase(PokemonType.Grass, PokemonType.Rock, 2.0,
        "Ataque Hierva contra Roca, (2.0x) ")]
        [TestCase(PokemonType.Psychic, PokemonType.Ghost, 1.0,
        "Ataque Fisico contra Fantasma, (1x) ")]
        [TestCase(PokemonType.Bug, PokemonType.Grass, 2.0,
        "Ataque Bicho contra Planta, (2x) ")]
        public void CalculateMod_TypleSingle(PokemonType attackType, PokemonType defenderType, double expectedMod, string description)
        {
            Move move1 = new Move("Movimiento2", attackType, Move.MoveType.Special);
            // Act
            double actualMod = CalculatorMOD.CalculateMod(move1, new List<PokemonType> { defenderType });

            // Assert
            Assert.That(actualMod, Is.EqualTo(expectedMod), description);
        }

        [TestCase(PokemonType.Water, PokemonType.Fire, PokemonType.Rock, 4.0,
       "Ataque Agua (2x) contra Fuego, (2x) contra Roca. 2x2=4x")]
        [TestCase(PokemonType.Grass, PokemonType.Water, PokemonType.Ground, 4.0,
       "Ataque Planta (2x) contra Agua, (2x) contra Tierra. 2x2=4x")]
        [TestCase(PokemonType.Rock, PokemonType.Fire, PokemonType.Bug, 4.0,
       "Ataque Roca (2x) contra Fuego, (2x) contra Bicho. 2x2=4x")]
        [TestCase(PokemonType.Fire, PokemonType.Grass, PokemonType.Rock, 1.0,
       "Ataque Fuego (2x) contra Planta, (0.5x) contra Roca. 2x0.5=1x")]
        [TestCase(PokemonType.Bug, PokemonType.Psychic, PokemonType.Ghost, 1.0,
       "Ataque Bicho (2x) contra Psíquico, (0.5x) contra Fantasma. 2x0.5=1x")]

        public void CalculateMod_TypeCombinations(PokemonType attackType, PokemonType defType1, PokemonType defType2, double expectedMod, string description)
        {

            // Arrange
            List<PokemonType> defenderTypes = new List<PokemonType> { defType1, defType2 };

            Move move2 = new Move("Movimiento3", attackType, Move.MoveType.Physical);
            // Act
            double actualMod = CalculatorMOD.CalculateMod(move2, defenderTypes);

            // Assert
            Assert.That(actualMod, Is.EqualTo(expectedMod), description);
        }

        [TestCase(1, 1, 1, 1, 1, 0, ExpectedResult = 0)]
        [TestCase(2, 1, 1, 1, 1, 1, ExpectedResult = 1)]
        [TestCase(3, 5, 50, 100, 50, 2, ExpectedResult = 16)]//pruebas del 1-21
        [TestCase(4, 5, 50, 100, 50, 1, ExpectedResult = 5)]
        [TestCase(5, 10, 20, 30, 15, 1, ExpectedResult = 5)]
        [TestCase(6, 12, 40, 60, 80, 2, ExpectedResult = 9)]
        [TestCase(7, 25, 80, 120, 60, 1, ExpectedResult = 40)]
        [TestCase(8, 30, 100, 50, 100, 4, ExpectedResult = 58)]
        [TestCase(9, 40, 150, 200, 150, 1, ExpectedResult = 37)]
        [TestCase(10, 50, 128, 200, 100, 1, ExpectedResult = 58)]
        [TestCase(11, 50, 128, 200, 100, 4, ExpectedResult = 455)]
        [TestCase(12, 60, 200, 250, 200, 1, ExpectedResult = 132)]
        [TestCase(13, 70, 180, 200, 100, 2, ExpectedResult = 435)]
        [TestCase(14, 80, 90, 45, 90, 1, ExpectedResult = 33)]
        [TestCase(15, 90, 255, 200, 50, 2, ExpectedResult = 1554)]
        [TestCase(16, 99, 255, 255, 1, 2, ExpectedResult = 108206)]
        [TestCase(17, 99, 255, 255, 255, 4, ExpectedResult = 856)]
        [TestCase(18, 99, 255, 255, 255, 0, ExpectedResult = 0)]
        [TestCase(19, 99, 255, 1, 255, 1, ExpectedResult = 2)]
        [TestCase(20, 45, 60, 10, 200, 1, ExpectedResult = 2)]
        [TestCase(21, 20, 30, 5, 250, 1, ExpectedResult = 1)]


        public int CalculateDamage_Test(int testCase, int level, int power, int attack, int defense, double MOD)
        {
            Move.MoveType moveType;

            Pokemon attacker = new Pokemon("Attacker", PokemonType.Fire, level, attack, defense, attack, defense);
            Pokemon defender = new Pokemon("Defender", PokemonType.Grass, level, attack, defense, attack, defense);

            if (testCase % 2 == 0)//residuos para confirmar si es par o impar
            {
                moveType = Move.MoveType.Physical;
                Move move = new Move("Test Move", PokemonType.Fire, Move.MoveType.Physical, power);
                double damage = EcuacionMove.CalculateDamagePhysic(attacker, defender, move, MOD);
                return (int) Math.Round(damage);
            }
            else
            {
                moveType = Move.MoveType.Special;
                Move move = new Move("Test Move", PokemonType.Fire, Move.MoveType.Special, power);
                double damage = EcuacionMove.CalculateDamageSpecial(attacker, defender, move, MOD);
                return (int)Math.Round(damage);
            }

         
          

        }
    }
}