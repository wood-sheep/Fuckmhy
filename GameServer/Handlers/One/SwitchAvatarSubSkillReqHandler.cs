using Common.Database;
using Common.Resources.Proto;

namespace PemukulPaku.GameServer.Handlers
{
    [PacketCmdId(CmdId.SwitchAvatarSubSkillReq)]
    internal class SwitchAvatarSubSkillReqHandler : IPacketHandler
    {
        public void Handle(Session session, Packet packet)
        {
            SwitchAvatarSubSkillReq Data = packet.GetDecodedBody<SwitchAvatarSubSkillReq>();
            AvatarScheme? avatar = session.Player.AvatarList.FirstOrDefault(avatar => avatar.AvatarId == Data.AvatarId);
            SwitchAvatarSubSkillRsp Rsp = new() { retcode = SwitchAvatarSubSkillRsp.Retcode.Succ };
            if (avatar is not null)
            {
                avatar.SwitchSubSkill(Data.SkillId, Data.SubSkillId);
                session.ProcessPacket(Packet.FromProto(new GetAvatarDataReq() { AvatarIdLists = new uint[] { avatar.AvatarId } }, CmdId.GetAvatarDataReq));
            }
            else
            {
                Rsp.retcode = SwitchAvatarSubSkillRsp.Retcode.Fail;
            }
            session.Send(Packet.FromProto(Rsp, CmdId.SwitchAvatarSubSkillRsp));
        }
    }
}
