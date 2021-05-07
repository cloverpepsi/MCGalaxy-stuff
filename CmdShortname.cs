//reference System.dll
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using MCGalaxy;
using MCGalaxy.Commands;

namespace Core {
	public sealed class CmdShortname : Command2 {
		public override string name { get { return "Shortname"; } }
        public override string shortcut { get { return "Shortnick"; } }
        public override string type { get { return "Chat"; } }

		public override void Use(Player p, string message) {
            string[] args = message.SplitSpaces(2);
        	if (args[0] == "") { Command.Find("Nick").Use(p, "-own"); return; }
//edit text/ValidFlairs.txt to change the flars you can use
            List<string> validList = Utils.ReadAllLinesList("text/ValidFlairs.txt");
            
            if (args.Length > 1) {string nick = args[1];
       		string UncoloredNick = Regex.Replace(nick, @"%.", "");

             string flair = args[0]; 
        	 string UncoloredFlair = Regex.Replace(flair, @"%.", "");
        if(UncoloredFlair.Length > 1) {p.Message("%cYour flair can only be 1 character."); return;}
        if(!(validList.Contains(UncoloredFlair))) {p.Message("%cYou are using an invalid flair."); return;}
            
        if((p.name).CaselessContains(UncoloredNick))  {
//you can set the 3 here to be any number. Just make sure to change the error message.
        if(UncoloredNick.Length >= 3) {
        Command.Find("Nick").Use(p, "-own " + flair + " " + nick);
        
        }
     	else {p.Message("%cYou need to have your name be 3 characters or longer.");}
        }
            
        else {p.Message("%cNew name must be part of original name.");}
        }
        
        else {
            string nick = args[0];
            string UncoloredNick = Regex.Replace(nick, @"%.", "");
            if((p.name).CaselessContains(UncoloredNick))  {
//same thing here. Just make sure to change all the threes.

           if(UncoloredNick.Length >= 3) {Command.Find("Nick").Use(p, "-own " + nick);}
     	    else {p.Message("%cYou need to have your name be 3 characters or longer.");}
     
        }
            
        else {p.Message("%cNew name must be part of original name.");}}
        } 
            public override void Help(Player p ) {
            p.Message("&a/Shortname <flair> [name]");
           	p.Message("&eSets your nick to [name]. You can include a flair if you want.");
    }
    }
}
    
        
