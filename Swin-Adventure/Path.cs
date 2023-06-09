using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public class Path : GameObject
    {

        Location targetLocation;
        public Path(string[] ids, string name, string desc, Location targetLocation) : base(ids, name, desc)
        {

            this.targetLocation = targetLocation;



        }

        public Location TargetLocation
        {
            get { return targetLocation; }
        }

        public void Move(Player p)
        {
            p.Location = targetLocation;
        }

    }


}
