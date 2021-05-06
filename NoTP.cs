using System;
using MCGalaxy;
using MCGalaxy.Commands;
using MCGalaxy.Events.PlayerEvents;

namespace myServer {

  public sealed class GateKeeper : Plugin {
    public override string name    { get { return "NoTP"; } }
    public override string creator { get { return "crush_"; } }
    public          string version { get { return "18.04.20"; } }
    public override string MCGalaxy_Version { get { return "1.9.1.9"; } }

    public override void Load(bool startup) {
      OnPlayerCommandEvent.Register(OnPlrCommand, Priority.Low);
		}

    public override void Unload(bool shutdown) {
	  OnPlayerCommandEvent.Unregister(OnPlrCommand);
		}


    void OnPlrCommand(Player subject, string cmd, string message, CommandData data) {
       if (subject.group.Permission >= LevelPermission.Operator) { return; }
       string[] args = message.SplitSpaces();

       if(cmd.CaselessEq("tp") || cmd.CaselessEq("teleport") ||
       cmd.CaselessEq("tpp") && data.Context != CommandContext.MessageBlock){
	          
       
       if((subject.GetMotd().CaselessContains("-hax")) && (args.Length > 1) && !(LevelInfo.IsRealmOwner(subject.level, subject.name)) ){
          subject.Message("&cTeleporting is currently disabled.");
          subject.cancelcommand = true;
          return;
        }

        if(args.Length == 1 ){
          Player tpObject = PlayerInfo.FindMatches(subject, args[0]);
              
          if((tpObject.GetMotd().Contains("-hax")) && !(LevelInfo.IsRealmOwner(tpObject.level, subject.name))){
            if(tpObject.level != subject.level){
            subject.Message("&cYou can't directly teleport to that player because hax are disabled in %f" + tpObject.level.name + ", &cusing /goto instead.");
            Command.Find("Goto").Use(subject, tpObject.level.name);}
            else {subject.Message("&cTeleporting is currently disabled.");}
            subject.cancelcommand = true;
            return;
          }
          
        }

       }

    }

  }

}
