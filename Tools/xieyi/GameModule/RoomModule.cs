using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoMsg;
using MobaServer.Entity;

namespace MobaServer
{
    class RoomModule : GameModuleBase<RoomModule>
    {
        public override void Init()
        {
            base.Init();
        }

        public override void Release()
        {
            base.Release();
        }

        public override void AddListener()
        {
            base.AddListener();
            
            NetEvent.Instance.AddEventListener(1400, HandleRoomSelectHeroC2S);//选择英雄
            NetEvent.Instance.AddEventListener(1401, HandleRoomSelectHeroSkillC2S);//选择召唤师技能
            NetEvent.Instance.AddEventListener(1402, HandleRoomCreateC2S);//创建房间
            NetEvent.Instance.AddEventListener(1403, HandleRoomCloseC2S);//解散房间
            NetEvent.Instance.AddEventListener(1404, HandleRoomSendMsgC2S);//发送队伍聊天信息
            NetEvent.Instance.AddEventListener(1405, HandleRoomLockHeroC2S);//锁定英雄
            NetEvent.Instance.AddEventListener(1406, HandleRoomLoadProgressC2S);//发送加载进度
            NetEvent.Instance.AddEventListener(1407, HandleRoomToBattleC2S);//加载战斗
        }

        public override void RemoveListener()
        {
            base.RemoveListener();
            
            NetEvent.Instance.RemoveEventListener(1400, HandleRoomSelectHeroC2S);//选择英雄
            NetEvent.Instance.RemoveEventListener(1401, HandleRoomSelectHeroSkillC2S);//选择召唤师技能
            NetEvent.Instance.RemoveEventListener(1402, HandleRoomCreateC2S);//创建房间
            NetEvent.Instance.RemoveEventListener(1403, HandleRoomCloseC2S);//解散房间
            NetEvent.Instance.RemoveEventListener(1404, HandleRoomSendMsgC2S);//发送队伍聊天信息
            NetEvent.Instance.RemoveEventListener(1405, HandleRoomLockHeroC2S);//锁定英雄
            NetEvent.Instance.RemoveEventListener(1406, HandleRoomLoadProgressC2S);//发送加载进度
            NetEvent.Instance.RemoveEventListener(1407, HandleRoomToBattleC2S);//加载战斗
        }

        

         /// <summary> 选择英雄 </summary>
        private void HandleRoomSelectHeroC2S(MsgEntity p)
        {
            RoomSelectHeroC2S c2sMsg = RoomSelectHeroC2S.Parser.ParseFrom(p.body);

            RoomSelectHeroS2C s2cMsg = new RoomSelectHeroS2C();
            //MsgToClient.SendBuff(p.id, s2cMsg, p.clientAgent);

        }

         /// <summary> 选择召唤师技能 </summary>
        private void HandleRoomSelectHeroSkillC2S(MsgEntity p)
        {
            RoomSelectHeroSkillC2S c2sMsg = RoomSelectHeroSkillC2S.Parser.ParseFrom(p.body);

            RoomSelectHeroSkillS2C s2cMsg = new RoomSelectHeroSkillS2C();
            //MsgToClient.SendBuff(p.id, s2cMsg, p.clientAgent);

        }

         /// <summary> 创建房间 </summary>
        private void HandleRoomCreateC2S(MsgEntity p)
        {
            RoomCreateC2S c2sMsg = RoomCreateC2S.Parser.ParseFrom(p.body);

            RoomCreateS2C s2cMsg = new RoomCreateS2C();
            //MsgToClient.SendBuff(p.id, s2cMsg, p.clientAgent);

        }

         /// <summary> 解散房间 </summary>
        private void HandleRoomCloseC2S(MsgEntity p)
        {
            RoomCloseC2S c2sMsg = RoomCloseC2S.Parser.ParseFrom(p.body);

            RoomCloseS2C s2cMsg = new RoomCloseS2C();
            //MsgToClient.SendBuff(p.id, s2cMsg, p.clientAgent);

        }

         /// <summary> 发送队伍聊天信息 </summary>
        private void HandleRoomSendMsgC2S(MsgEntity p)
        {
            RoomSendMsgC2S c2sMsg = RoomSendMsgC2S.Parser.ParseFrom(p.body);

            RoomSendMsgS2C s2cMsg = new RoomSendMsgS2C();
            //MsgToClient.SendBuff(p.id, s2cMsg, p.clientAgent);

        }

         /// <summary> 锁定英雄 </summary>
        private void HandleRoomLockHeroC2S(MsgEntity p)
        {
            RoomLockHeroC2S c2sMsg = RoomLockHeroC2S.Parser.ParseFrom(p.body);

            RoomLockHeroS2C s2cMsg = new RoomLockHeroS2C();
            //MsgToClient.SendBuff(p.id, s2cMsg, p.clientAgent);

        }

         /// <summary> 发送加载进度 </summary>
        private void HandleRoomLoadProgressC2S(MsgEntity p)
        {
            RoomLoadProgressC2S c2sMsg = RoomLoadProgressC2S.Parser.ParseFrom(p.body);

            RoomLoadProgressS2C s2cMsg = new RoomLoadProgressS2C();
            //MsgToClient.SendBuff(p.id, s2cMsg, p.clientAgent);

        }

         /// <summary> 加载战斗 </summary>
        private void HandleRoomToBattleC2S(MsgEntity p)
        {
            RoomToBattleC2S c2sMsg = RoomToBattleC2S.Parser.ParseFrom(p.body);

            RoomToBattleS2C s2cMsg = new RoomToBattleS2C();
            //MsgToClient.SendBuff(p.id, s2cMsg, p.clientAgent);

        }


    }
}