using System;
using MCGalaxy;
using MCGalaxy.Network;
using MCGalaxy.Tasks;

namespace RainbowPluginThingy {

    public sealed class RainbowPlugin : Plugin {
        public override string creator { get { return "Unseen"; } }
        public override string MCGalaxy_Version { get { return "1.9.0.1"; } }
        public override string name { get { return "LessPainfulRainbow"; } }

        SchedulerTask task;
        public override void Load(bool startup) {
           task = Server.MainScheduler.QueueRepeat(RainbowCallback, null,
        	                                        TimeSpan.FromMilliseconds(500));
        }
        
        public override void Unload(bool shutdown) {
        	if (task == null) return;
        	Server.MainScheduler.Cancel(task);
        }
        
        static string[] colors = { "9400D3", "4B0082", "0000FF", "00FF00", "FFFF00", "FF7F00", "FF0000" };
        static int index;
        static void RainbowCallback(SchedulerTask task) {
        System.Threading.Thread.Sleep(125);    
        	index = (index + 1) % colors.Length; 
        	ColorDesc desc = Colors.ParseHex(colors[index]);
            desc.Code = 'r';
        	Player[] players = PlayerInfo.Online.Items;
            
        	foreach (Player p in players) {
        		if (!p.Supports(CpeExt.TextColors)) continue;
        		p.Send(Packet.SetTextColor(desc));
        	}
        }
    }
}
