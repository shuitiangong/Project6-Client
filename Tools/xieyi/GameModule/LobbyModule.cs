using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoMsg;
using MobaServer.Entity;

namespace MobaServer
{
    class LobbyModule : GameModuleBase<LobbyModule>
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
            
            NetEvent.Instance.AddEventListener(1300, HandleLobbyToMatchC2S);//开始匹配
            NetEvent.Instance.AddEventListener(1301, HandleLobbyUpdateMatchStateC2S);//匹配成功
            NetEvent.Instance.AddEventListener(1302, HandleLobbyQuitMatchC2S);//退出匹配
        }

        public override void RemoveListener()
        {
            base.RemoveListener();
            
            NetEvent.Instance.RemoveEventListener(1300, HandleLobbyToMatchC2S);//开始匹配
            NetEvent.Instance.RemoveEventListener(1301, HandleLobbyUpdateMatchStateC2S);//匹配成功
            NetEvent.Instance.RemoveEventListener(1302, HandleLobbyQuitMatchC2S);//退出匹配
        }

        

         /// <summary> 开始匹配 </summary>
        private void HandleLobbyToMatchC2S(MsgEntity p)
        {
            LobbyToMatchC2S c2sMsg = LobbyToMatchC2S.Parser.ParseFrom(p.body);

            LobbyToMatchS2C s2cMsg = new LobbyToMatchS2C();
            //MsgToClient.SendBuff(p.id, s2cMsg, p.clientAgent);

        }

         /// <summary> 匹配成功 </summary>
        private void HandleLobbyUpdateMatchStateC2S(MsgEntity p)
        {
            LobbyUpdateMatchStateC2S c2sMsg = LobbyUpdateMatchStateC2S.Parser.ParseFrom(p.body);

            LobbyUpdateMatchStateS2C s2cMsg = new LobbyUpdateMatchStateS2C();
            //MsgToClient.SendBuff(p.id, s2cMsg, p.clientAgent);

        }

         /// <summary> 退出匹配 </summary>
        private void HandleLobbyQuitMatchC2S(MsgEntity p)
        {
            LobbyQuitMatchC2S c2sMsg = LobbyQuitMatchC2S.Parser.ParseFrom(p.body);

            LobbyQuitMatchS2C s2cMsg = new LobbyQuitMatchS2C();
            //MsgToClient.SendBuff(p.id, s2cMsg, p.clientAgent);

        }


    }
}