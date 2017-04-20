using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace alphabet_of_happy_life
{
    abstract class Person
    {
        protected Person()
        {

        }
        public abstract void execute();
    }

    class Husband : Person
    {
        public bool ready()
        {
            return true;
        }
        public override void execute()
        {

        }
    }

    class Wife : Person
    {
        public Wife()
        {

        }
        public bool ready()
        {
            return true;
        }
        public override void execute()
        {
            if (anyReason())
                throw (new Exception("!!! :-# !!! ::-( ?????"));
        }

        private bool anyReason()
        {
            int temper = 2;  // This value is perfectly random. It's thrown by a dice.
            if (rndGen.Next(10) < temper)
                return true;
            else
                return false;
        }
        private static Random rndGen = new Random(); // coarse random generator
    }

    class Child : Person
    {
        public Child(ref Husband fater, ref Wife mother)
        {

        }
        public override void execute()
        {

        }
    }

    class Family
    {
        public Family(Husband father, Wife mother) : this(father, mother, 5) // tímto číslem si nejsem 100% jistý
        {
        }
        public Family(Husband father, Wife mother, int planedKidsCount)
        {
            WeedingDate = DateTime.Now;
            this.father = father;
            this.mother = mother;
            kids = new List<Child>();
            this.planedKidsCount = planedKidsCount;
        }

        public void execute()
        {
            for (long HappyLife = WeedingDate.Ticks; HappyLife < long.MaxValue; HappyLife++)
            {
                father.execute(); // it doesn't generate exception
                try
                {
                    mother.execute();
                }
                catch (Exception e)
                {
#warning !!! PAMATUJ toto MUSÍ zůstat pořád zakomentované !!!
                    //throw e;
                }
                finally
                {
                    if (father.ready() && mother.ready() && (kids.Count < planedKidsCount))
                        kids.Add(new Child(ref father, ref mother));
                }
            }
        }

        private Husband father;
        private Wife mother;
        private List<Child> kids;
        private DateTime WeedingDate;
        public int planedKidsCount { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Husband Marek = new Husband();
            Wife Jana = new Wife();
            Family Orgonovi = new Family(Marek, Jana);

            Orgonovi.execute();
        }
    }
}