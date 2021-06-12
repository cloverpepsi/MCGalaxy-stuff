using System;

namespace MCGalaxy
{
    public class CmdCustomHug : Command
    {
        public override string name { get { return "CustomHug"; } }
        public override string shortcut { get { return "cshug"; } }
        public override string type { get { return "chat"; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Banned; } }
        
        public override void Use(Player p, string message) { 
            string[] args = message.SplitSpaces();
            if (args.Length == 0) { Help(p); return; }
            if (args.Length > 2 ) { Help(p); return; }
            if (args.Length == 2) { 
           
           string target = args[0];
           Player targetName = PlayerInfo.FindMatches(p, target);
           if (targetName == null) {return;}
           string type = " " + args[1];
            Chat.MessageAll(p.ColoredName + " %7gives " + targetName.ColoredName + " %7a" + type + " hug"); 
            }
            
            if (args.Length == 1 ) {
            string target = args[0];
            Player targetName = PlayerInfo.FindMatches(p, target);
           	if (targetName == null) {return;}
            Chat.MessageAll(p.ColoredName + " %7gives " + targetName.ColoredName + " %7a hug");
            }
        }

        public override void Help(Player p)
        {
            p.Message("%T/CustomHug [player] <type>");
            p.Message("%HGives a hug to [player]! You can specify a type if you want. Note that <type> can only be 1 word.");
        }
    }
}
