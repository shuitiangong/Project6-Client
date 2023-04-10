using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoMsg;
using MobaServer.Entity;

namespace MobaServer
{
    class RolesModule : GameModuleBase<RolesModule>
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
            
            NetEvent.Instance.AddEventListener(1201, HandleRolesCreateC2S);//创建角色
        }

        public override void RemoveListener()
        {
            base.RemoveListener();
            
            NetEvent.Instance.RemoveEventListener(1201, HandleRolesCreateC2S);//创建角色
        }

        

         /// <summary> 创建角色 </summary>
        private void HandleRolesCreateC2S(MsgEntity p)
        {
            RolesCreateC2S c2sMsg = RolesCreateC2S.Parser.ParseFrom(p.body);

            RolesCreateS2C s2cMsg = new RolesCreateS2C();
            //MsgToClient.SendBuff(p.id, s2cMsg, p.clientAgent);

        }


    }
}