using Common.Database;
using Common.Resources.Proto;
using Common.Utils.ExcelReader;

namespace PemukulPaku.GameServer.Handlers
{
    [PacketCmdId(CmdId.GetElfDataReq)]
    internal class GetElfDataReqHandler : IPacketHandler
    {
        public void Handle(Session session, Packet packet)
        {

        }
    }
}