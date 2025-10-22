namespace TestProject1
{
    public class Chorrotuga : Pokemon //Squirtle

    {
        public Chorrotuga() : base("Chorrotuga", PokemonType.Water)
        {
            Level = 1;
            Attack = 49;
            Defense = 49;
            SpAttack = 65;
            SpDefense = 65;
        }
    }

    
     public class Pikachu : Pokemon
    {

        public Pikachu() : base("Pikachu", PokemonType.Electric)
        {
            Level = 1;
            Attack = 55;
            Defense = 40;
            SpAttack = 50;
            SpDefense = 50;
        }

    }
    public class Charmander : Pokemon
    {

        public Charmander () : base("Charmander", PokemonType.Fire)
        {
            Level = 1;
            Attack = 55;
            Defense = 40;
            SpAttack = 50;
            SpDefense = 50;
        }

    }
    public class Bulbasur : Pokemon
    {

        public Bulbasur () : base("Bulbasur", PokemonType.Grass)
        {
            Level = 1;
            Attack = 55;
            Defense = 40;
            SpAttack = 50;
            SpDefense = 50;
        }

    }
    public class Gengar : Pokemon
    {

        public Gengar () : base("Gengar", PokemonType.Ghost)
        {
            Level = 1;
            Attack = 55;
            Defense = 40;
            SpAttack = 50;
            SpDefense = 50;
        }

    }

}
