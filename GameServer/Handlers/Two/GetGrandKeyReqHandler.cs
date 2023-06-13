using Common.Resources.Proto;
namespace PemukulPaku.GameServer.Handlers
{
    [PacketCmdId(CmdId.GetGrandKeyReq)]
    internal class GrandKeyReqHandler : IPacketHandler
    {
        public void Handle(Session session, Packet packet)
        {
            GetGrandKeyReq Data = packet.GetDecodedBody<GetGrandKeyReq>();

            //HandleReq
            GetGrandKeyRsp Rsp = new(){};

            //Read DB and return all player dkeys
            //Rsp.KeyLists.Add();
            //Rsp.retcode = GetGrandKeyRsp.Retcode.Succ;
            //Rsp.IsAll = true;
            Rsp.retcode = GetGrandKeyRsp.Retcode.Fail;
            session.Send(Packet.FromProto(Rsp, CmdId.GetGrandKeyRsp));
        }
    }
}
