using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public class Player: GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _location;


        public Player(string name, string desc): base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
                return this;

            GameObject gameobject = _inventory.Fetch(id);
            if (gameobject != null)
            {
                return gameobject;
            }
            else if (_location != null)
            {
                gameobject = _location.Locate(id);
                return gameobject;
            }
            else
            {
                return null;
            }
        }

        public override string FullDescription
        {
            get
            {
                return $"You are {Name}\n{base.FullDescription}\nYou are carrying:{Inventory.ItemList}";
            }
        }
        public Inventory Inventory 
        { 
            get { return _inventory; } 
        }

        public Location Location 
        { 
            get { return _location; } 
            set { _location = value; }
        }

        

    }
}
