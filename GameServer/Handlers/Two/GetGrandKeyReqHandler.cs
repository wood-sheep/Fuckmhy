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

            /*{
                "id": 202,
                "endTime": 1686959895,
                "unlockLevel": 65,
                "level": 10,
                "breachLevel": 2,
                "activateLevel": 10,
                "skill": {
                    "skillId": 20209
                }
            }*/
            Packet.c.Log("Hello from inside gKey");
                //Rsp.KeyLists.Add();
                Rsp.retcode = GetGrandKeyRsp.Retcode.Succ;
            Rsp.IsAll = true;
            session.Send(Packet.FromProto(Rsp, CmdId.GetGrandKeyRsp));
        }
    }
}
