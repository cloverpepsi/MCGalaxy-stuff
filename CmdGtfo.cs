using MCGalaxy;

namespace Core {
	public sealed class CmdDefriend : Command2 {
		public override string name { get { return "GetTheFrickOut"; } }
        public override string shortcut { get { return "gtfo"; } }
		public override string type { get { return "Moderation"; } }
		
		public override void Use(Player p, string message ) {
            string[] args = message.SplitSpaces(2);
            if (args.Length < 2) { Help(p); return; }
            
//Note: you can change the "%m" to any color code you want. This is just what I chose

        	string reason = args.Length < 2 ? "" :  "%m" + args[1] ;
        	string target = PlayerInfo.FindMatchesPreferOnline(p, args[0]);
            
  		  Command.Find("warn").Use(p, target + " %fBlacklisted from the freebuilds for: " + reason);
		    Command.Find("send").Use(p, target + " &fYou have been blacklisted from the freebuilds for: " + reason);

//The text in the warn/send can be customized, as well as the name of the maps you're choosing to blacklist them from.

        Command.Find("perbuild").Use(p, "freebuild " + "-" + target);
        Command.Find("perbuild").Use(p, "pixel " + "-" + target);
		    Command.Find("UndoPlayer").Use(p, target + " all");
        
        }
		
       public override void Help(Player p ) {
            p.Message("&a/GetTheFrickOut [player] [reason]");
           	p.Message("&eWarns, blacklists, and undoes a player's actions on the world you're on, and sends a message to said players inbox.");
            
		}
	}
}
