using Day06Task1Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day06Task1Solution
{
    public static class Solution
    {
        public static int Calculate(string[] orbits)
        {
            var objects = new Dictionary<string, SpaceObject>();
            IEnumerable<(string, string)> relations = orbits.Select(o => o.Split(')')).Select(s => (s[0], s[1]));
            foreach (var relation in relations)
            {
                SpaceObject parent;
                SpaceObject child;

                if (!objects.ContainsKey(relation.Item1))
                {
                    parent = new SpaceObject(relation.Item1);
                    objects.Add(relation.Item1, parent);
                }
                else
                {
                    parent = objects[relation.Item1];
                }

                if (!objects.ContainsKey(relation.Item2))
                {
                    child = new SpaceObject(relation.Item2);
                    objects.Add(relation.Item2, child);
                }
                else
                {
                    child = objects[relation.Item2];
                }

                child.SetParent(parent);
                parent.AddChild(child);
            }
            return objects.Sum(o => o.Value.CountParents());
        }
    }
}
