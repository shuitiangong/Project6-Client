using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoMsg;
using MobaServer.Entity;

namespace MobaServer
{
    class ServerModule : GameModuleBase<ServerModule>
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
            
            NetEvent.Instance.AddEventListener(1100, HandleServerGetAllC2S);//获取所有区服
            NetEvent.Instance.AddEventListener(1101, HandleServerSelectC2S);//选择区服
        }

        public override void RemoveListener()
        {
            base.RemoveListener();
            
            NetEvent.Instance.RemoveEventListener(1100, HandleServerGetAllC2S);//获取所有区服
            NetEvent.Instance.RemoveEventListener(1101, HandleServerSelectC2S);//选择区服
        }

        

         /// <summary> 获取所有区服 </summary>
        private void HandleServerGetAllC2S(MsgEntity p)
        {
            ServerGetAllC2S c2sMsg = ServerGetAllC2S.Parser.ParseFrom(p.body);

            ServerGetAllS2C s2cMsg = new ServerGetAllS2C();
            //MsgToClient.SendBuff(p.id, s2cMsg, p.clientAgent);

        }

         /// <summary> 选择区服 </summary>
        private void HandleServerSelectC2S(MsgEntity p)
        {
            ServerSelectC2S c2sMsg = ServerSelectC2S.Parser.ParseFrom(p.body);

            ServerSelectS2C s2cMsg = new ServerSelectS2C();
            //MsgToClient.SendBuff(p.id, s2cMsg, p.clientAgent);

        }


    }
}