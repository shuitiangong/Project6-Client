using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoMsg;
using MobaServer.Entity;

namespace MobaServer
{
    class BattleModule : GameModuleBase<BattleModule>
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
            
            NetEvent.Instance.AddEventListener(1500, HandleBattleUserInputC2S);//用户的输入
        }

        public override void RemoveListener()
        {
            base.RemoveListener();
            
            NetEvent.Instance.RemoveEventListener(1500, HandleBattleUserInputC2S);//用户的输入
        }

        

         /// <summary> 用户的输入 </summary>
        private void HandleBattleUserInputC2S(MsgEntity p)
        {
            BattleUserInputC2S c2sMsg = BattleUserInputC2S.Parser.ParseFrom(p.body);

            BattleUserInputS2C s2cMsg = new BattleUserInputS2C();
            //MsgToClient.SendBuff(p.id, s2cMsg, p.clientAgent);

        }


    }
}