using System;
using MCGalaxy.Eco;
using MCGalaxy.DB;
namespace MCGalaxy.Commands.Eco {
    public sealed class CmdSetMoney : MoneyCmd {
        public override string name { get { return "SetMoney"; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }

        public override void Use(Player p, string message) {
                    string[] args = message.SplitSpaces(3);
                    if (args.Length < 2) { Help(p); return; }

                    int money = 0;
                    if (!CommandParser.GetInt(p, args[1], "Amount", ref money, -Int32.MaxValue)) return;

                    Player tar1 = PlayerInfo.FindMatches(p, args[0]);
                    if (tar1 != null) {
                    tar1.money = money;
                    return;
                    }
                    
                    string target = PlayerInfo.FindMatchesPreferOnline(p, args[0]);
                    
                    Economy.UpdateMoney(target, money);
                    }

        public override void Help(Player p) {
            p.Message("%T/FakePay [player] [amount] <reason>");
            p.Message("%HPays [amount] %3" + Server.Config.Currency + " %Hto the player.");
        }
    }
}
