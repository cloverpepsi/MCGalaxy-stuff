using System;

namespace MCGalaxy.Commands.Eco {
    public sealed class CmdFakePay : MoneyCmd {
        public override string name { get { return "FakePay"; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }

        public override void Use(Player p, string message) {
            string[] args = message.SplitSpaces(3);
            if (args.Length < 2) { Help(p); return; }

            int money = 0;
            if (!CommandParser.GetInt(p, args[1], "Amount", ref money, 1)) return;

            int money2 = p.money;
			if (money2 < money) {
                p.Message("%CYou don't have enough %3" + Server.Config.Currency); return;
            }
            
            string target = PlayerInfo.FindMatchesPreferOnline(p, args[0]);
            if (target == null) return;
            if (p != null && p.name.CaselessEq(target)) {
                p.Message("You cannot pay yourself %3" + Server.Config.Currency); return;
            }

            string sourceName = p == null ? "(console)" : p.ColoredName;
            string targetName = PlayerInfo.GetColoredName(p, target);
            string reason = args.Length < 3 ? "" : " %S(" + args[2] + "%S)";

            const string format = "{0} %Sgave {1} &f{2} &3{3}{4}";					
            Chat.MessageGlobal(sourceName + " %7paid " + targetName + "%f " + money +  "&3 " + Server.Config.Currency + reason);
        }

        public override void Help(Player p) {
            p.Message("%T/FakePay [player] [amount] <reason>");
            p.Message("%HPays [amount] %3" + Server.Config.Currency + " %Hto the player.");
        }
    }
}
