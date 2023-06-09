using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory inventory;
        private List<Path> paths;

        public Location(string[] ids, string name, string desc) : this(ids, name, desc, new List<Path>())
        {

        }

        public Location(string[] ids, string name, string desc, List<Path> paths) : base(ids, name, desc)
        {
            inventory = new Inventory();
            this.paths = paths;
        }


        public Inventory Inventory
        {
            get { return inventory; }
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            return inventory.Fetch(id);


        }

        public Path LocatePath(string id)
        {
            foreach (Path p in paths)
            {
                if (p.AreYou(id))
                {
                    return p;
                }
            }
            return null;
        }

        public void AddPath(Path path)
        {
            paths.Add(path);
        }

        public string ShowPath()
        {
            if (paths.Count == 0)
            {
                return "\nThere is no exit.";
            }
            else
            {
                foreach (Path p in paths)
                {
                    return $"\nThere is exit to the {p.FirstId}.";
                }
            }
            return "";
        }
    }
}
