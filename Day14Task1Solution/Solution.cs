using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day14Task1Solution
{
    public class Solution
    {
        private const string Ore = "ORE";

        private readonly IReadOnlyDictionary<string, Recipe> recipes;
        private readonly IReadOnlyDictionary<string, Dictionary<string, long>> needs;

        public Solution(string[] recipesList)
        {
            recipes = recipesList.Select(r => r.Split('='))
                .Select(s => new { Ingredients = Regex.Matches(s[0].TrimEnd(' '), @"(\d+) (\w+)"), Data = Regex.Match(s[1].Substring(2), @"(\d+) (\w+)") })
                .Select(x => new Recipe(x.Data.Groups[2].Value, long.Parse(x.Data.Groups[1].Value), x.Ingredients.Cast<Match>().Select(m => (m.Groups[2].Value, long.Parse(m.Groups[1].Value)))))
                .ToDictionary(k => k.Name, v => v);
            needs = recipes.Keys.Union(new string[] { Ore }).ToDictionary(k => k, v => new Dictionary<string, long>());
        }

        public void CalculateNeedsFor(string ingredient, long amount, string source)
        {
            if (ingredient == Ore)
            {
                AddNeed(ingredient, amount, source);
                return;
            }

            var recipe = recipes[ingredient];
            var need = GetNeedsOf(ingredient);
            var timesWanted = Convert.ToInt64(Math.Ceiling((double)need / recipe.Amount));

            AddNeed(ingredient, amount, source);
            var newNeed = GetNeedsOf(ingredient);
            var newTimesWanted = Convert.ToInt64(Math.Ceiling((double)newNeed / recipe.Amount));

            if (newTimesWanted > timesWanted)
            {
                foreach (var element in recipes[ingredient].Ingredients)
                {
                    CalculateNeedsFor(element.Name, newTimesWanted * element.Amount, ingredient);
                }
            }
        }

        public long GetNeedsOf(string ingredient)
        {
            return needs[ingredient].Sum(n => n.Value);
        }

        private void AddNeed(string ingredient, long amount, string source)
        {
            needs[ingredient][source] = amount;
        }
    }
}
