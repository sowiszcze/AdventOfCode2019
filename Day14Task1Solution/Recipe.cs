using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Day14Task1Solution
{
    internal class Recipe
    {
        private readonly IEnumerable<(string Name, long Amount)> ingredients;

        public Recipe(string name, long amount, IEnumerable<(string Name, long Amount)> ingredients)
        {
            Name = name;
            Amount = amount;
            this.ingredients = ingredients;
        }

        public string Name { get; private set; }
        public long Amount { get; private set; }
        public IReadOnlyCollection<(string Name, long Amount)> Ingredients => new ReadOnlyCollection<(string Name, long Amount)>(ingredients.ToList());
    }
}
