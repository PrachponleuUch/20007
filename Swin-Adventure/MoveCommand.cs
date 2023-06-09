using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move", "go", "head", "leave" })
        {

        }

        public override string Execute(Player p, string[] text)
        {
            string direction;

            if (!(this.AreYou(text[0])))
            {
                return "Error in move input";
            }

            switch (text.Length)
            {
                case 1:
                    return "Move where?";
                case 2:
                    direction = text[1];
                    break;
                default:
                    return "Error in move input";
            }

            Path path = p.Location.LocatePath(direction);

            if (path != null)
            {
                path.Move(p);
                return $"You head {path.FirstId}.\nYou go through a {path.Name}\nYou have arrived in {p.Location.Name}\n{p.Location.FullDescription}";
            }
            else
            {
                return $"Cannot find {text[1]} path";
            }
        }

    }
}
