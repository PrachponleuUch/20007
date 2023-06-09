using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public class CommandProcessor: Command
    {
        public CommandProcessor(): base(new string[] { "command" })
        { 

        }

        public override string Execute(Player p, string[] text)
        {
            List<Command> commands = new List<Command>() { new LookCommand(), new MoveCommand() };
            foreach (Command command in commands)
            {
                if (command.AreYou(text[0]))
                    return command.Execute(p, text);
            }
            return $"{text[0].ToUpper()} command does not exist";
        }
    }
}
