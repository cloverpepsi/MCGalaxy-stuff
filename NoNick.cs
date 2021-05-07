using System;
using MCGalaxy;
using MCGalaxy.Commands;
using MCGalaxy.Events.PlayerEvents;

namespace myServer {

  public sealed class NoNick : Plugin {
    public override string name    { get { return "NoNick"; } }
    public override string creator { get { return "Unseen"; } }
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

       if(cmd.CaselessEq("nick")){
	          
       
          subject.Message("&cYou can't use /nick. Try /shortname instead.");
          subject.cancelcommand = true;
          return;
        }

          }
          
        }

       }

