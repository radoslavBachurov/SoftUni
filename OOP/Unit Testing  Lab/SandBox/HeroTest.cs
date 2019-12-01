using System;

namespace SandBox
{
    public class HeroTest
    {
        static void Main(string[] args)
        {
            IWeapon testWeapon = new Axe(10, 10);
            ITarget testDummy = new Dummy(5, 10);
            double experience = 0;
            testWeapon.Attack(testDummy);

            if (testDummy.IsDead())
            {
                experience += testDummy.GiveExperience();
            }

            Console.WriteLine(experience);
        }
    }
}
