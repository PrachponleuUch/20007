using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public abstract class GameObject: IdentifiableObject
    {
        private string _description;
        private string _name;

        public GameObject(string[] ids, string name, string desc): base(ids) //Base: Using IdentifiableObject(Parent) constructor
        {
            _description = desc;
            _name = name;
        }
        
        public string Name
        { 
            get { return _name; }
        }

        public string ShortDescription
        { get { return $"{Name} ({FirstId})"; } }

        public virtual string FullDescription
        { get { return _description; } }


    }
}
