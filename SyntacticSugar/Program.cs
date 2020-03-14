using System;
using System.Collections.Generic;

namespace SyntacticSugar
{
    public class Bug
    {
        /*
            You can declare a typed public property, make it read-only,
            and initialize it with a default value all on the same
            line of code in C#. Readonly properties can be set in the
            class' constructors, but not by external code.
        */
        public string Name { get; } = "";
        public string Species { get; } = "";
        public List<string> Predators { get; } = new List<string>();
        public List<string> Prey { get; } = new List<string>();

        // Convert this readonly property to an expression member
        public string FormalName => $"{this.Name} the {this.Species}";

        // Class constructor
        public Bug(string name, string species, List<string> predators, List<string> prey)
        {
            this.Name = name;
            this.Species = species;
            this.Predators = predators;
            this.Prey = prey;
        }

        // Convert this method to an expression member
        public string PreyList() => string.Join(" and ", this.Prey);

        // Convert this method to an expression member
        public string PredatorList() => string.Join(" and ", this.Predators);

        // Convert this to expression method
        public string Eat(string food) => (this.Prey.Contains(food)) ? $"{this.Name} ate the {food}." : $"{this.Name} is still hungry.";
    }
    class Program
    {
        static void Main(string[] args)
        {
            var preds = new List<string>
            {
                "bats",
                "freakin dinosaurs, man"
            };
            var preys = new List<string>
            {
                "hopes",
                "dreams"
            };
            var nigel = new Bug("Nigel", "LIGHTNING BUG", preds, preys);
            Console.WriteLine($"{nigel.Name} is a {nigel.Species}");
            Console.WriteLine($"What should {nigel.Name} eat? (he likes {nigel.PreyList()})");
            var whatNigelShouldEat = Console.ReadLine();
            Console.WriteLine(nigel.Eat(whatNigelShouldEat));

            var llewellyn = new Bug("Llewellyn", "jitterbug", preys, preds);
            Console.WriteLine($"{llewellyn.Name} is a {llewellyn.Species}");
            Console.WriteLine($"What should {llewellyn.Name} eat? (he likes {llewellyn.PreyList()})");
            var whatLlewellynShouldEat = Console.ReadLine();
            Console.WriteLine(llewellyn.Eat(whatLlewellynShouldEat));
            Console.ReadLine();
        }
    }
}
