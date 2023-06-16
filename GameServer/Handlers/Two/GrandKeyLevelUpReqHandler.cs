using Common.Database;
using Common.Resources.Proto;
using Common.Utils.ExcelReader;

namespace PemukulPaku.GameServer.Handlers
{
    [PacketCmdId(CmdId.GrandKeyLevelUpReq)]
    internal class GrandKeyLevelUpReqHandler : IPacketHandler
    {
        public void Handle(Session session, Packet packet)
        {

        }
    }
}
