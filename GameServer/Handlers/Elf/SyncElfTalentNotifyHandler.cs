using Common.Database;
using Common.Resources.Proto;
using Common.Utils.ExcelReader;

namespace PemukulPaku.GameServer.Handlers
{
    [PacketCmdId(CmdId.SyncElfTalentNotify)]
    internal class SyncElfTalentNotifyHandler : IPacketHandler
    {
        public void Handle(Session session, Packet packet)
        {

        }
    }
}