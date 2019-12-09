using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Day06Task1Solution.Models
{
    public class SpaceObject
    {
        private readonly ICollection<SpaceObject> _children;

        public SpaceObject(string name)
        {
            Name = name;
            _children = new List<SpaceObject>();
        }

        public string Name { get; }
        public SpaceObject Parent { get; private set; }

        public IReadOnlyCollection<SpaceObject> Children
        {
            get => new ReadOnlyCollection<SpaceObject>(_children.ToList());
        }

        public void SetParent(SpaceObject parent)
        {
            if (Parent != null)
            {
                throw new Exception("Parent was already set.");
            }
            Parent = parent;
        }

        public void AddChild(SpaceObject child)
        {
            if (_children.Contains(child))
            {
                throw new Exception("Child was already assigned.");
            }
            _children.Add(child);
        }

        public int CountParents()
        {
            return Parent != null ? 1 + Parent.CountParents() : 0;
        }
    }
}
