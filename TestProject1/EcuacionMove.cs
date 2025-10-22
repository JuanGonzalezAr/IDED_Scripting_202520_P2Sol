using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    internal static class EcuacionMove
    {

        public static double CalculateDamagePhysic (Pokemon atacker, Pokemon defender, Move move, double modifier )//El modifier se incluye en los testcase
        {
            double dmg = (((2.0 * atacker.Level / 5.0 + 2) * (move.BasePower * ((double) atacker.Attack / defender.Defense) + 2)) / 50.0) * modifier;
            return dmg;
        }
        public static double CalculateDamageSpecial (Pokemon atacker, Pokemon defender, Move move, double modifier)
        {
            double dmg = (((2.0 * atacker.Level / 5.0 + 2) * (move.BasePower * ((double)atacker.SpAttack / defender.SpDefense) + 2)) / 50.0) * modifier;
            return dmg;
        }

    }
}
