using Common.Database;
using Common.Resources.Proto;
using Common.Utils.ExcelReader;
using System.Security.Cryptography;

namespace PemukulPaku.GameServer.Handlers
{
    [PacketCmdId(CmdId.SyncElfFragmentNotify)]
    internal class SyncElfFragmentNotifyHandler : IPacketHandler
    {
        public void Handle(Session session, Packet packet)
        {
            
        }
    }
}