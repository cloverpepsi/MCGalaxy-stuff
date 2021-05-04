using System;
using MCGalaxy;
using MCGalaxy.Events.PlayerEvents;

namespace PluginNoTP {
	public sealed class Core : Plugin {
		public override string creator { get { return "Unseen"; } }
		public override string name { get { return "+inv"; } }
		public override string MCGalaxy_Version { get { return "1.9.1.2"; } }
		
		public override void Load(bool startup) {
			OnPlayerCommandEvent.Register(OnPlayerCommand, Priority.Low);
		}
		
		public override void Unload(bool shutdown) {
			OnPlayerCommandEvent.Unregister(OnPlayerCommand);
		}

		static bool OnGameMap(Player p) {
 		   return !p.GetMotd().Contains("+inv");
		}

		void OnPlayerCommand(Player p, string cmd, string args, CommandData data) {
			cmd = cmd.ToLower();
			if (!( cmd == "invincible" )) return;
			
			if (OnGameMap(p)) {
				p.Message("You can't use that command. Try adding +inv to the motd.");
				p.cancelcommand = true;
				return;
			
			}
		}
	}
}
