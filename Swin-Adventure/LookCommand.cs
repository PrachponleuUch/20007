using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public class LookCommand: Command
    {
        public LookCommand(): base(ids: new string[] { "look" })
        { 
        }

        public override string Execute(Player p, string[] text)
        {
            string thingId;
            IHaveInventory container;

            if (text[0].ToLower() != "look")
            {
                return "Error in look input";
            }

            switch (text.Length)
            {
                case 1:
                    thingId = p.Location.FirstId;
                    container = p;
                    return $"You are in {p.Location.Name}\n{p.Location.FullDescription}{p.Location.ShowPath()}";
                case 3:
                    if (text[1].ToLower() != "at")
                    {
                        return "What do you want to look at?";
                    }
                    thingId = text[2];
                    container = p;
                    break;
                case 5:
                    if (text[3].ToLower() != "in")
                    {
                        return "What do you want to look in?";
                    }
                    container = FetchContainer(p, text[4]);
                    if (container == null)
                    {
                        return $"I cannot find the {text[4]}";
                    }
                    thingId = text[2];
                    break;
                default:
                    return "I don't know how to look like that";
            }
            return LookAtIn(thingId, container);
        }

        public string LookAtIn(string thingId, IHaveInventory container)
        {
            if (container.Locate(thingId) != null)
            {
                return container.Locate(thingId).FullDescription;
            }

            return $"I cannot find the {thingId}";
        }
        public IHaveInventory FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }
    }
}
