using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoMsg;
using MobaServer.Entity;

namespace MobaServer
{
    class UserModule : GameModuleBase<UserModule>
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
            
            NetEvent.Instance.AddEventListener(1000, HandleUserRegisterC2S);//注册帐号
            NetEvent.Instance.AddEventListener(1001, HandleUserLoginC2S);//登录帐号
            NetEvent.Instance.AddEventListener(1003, HandleUserQuitC2S);//请求退出/注销账号(换号的正常流程)
        }

        public override void RemoveListener()
        {
            base.RemoveListener();
            
            NetEvent.Instance.RemoveEventListener(1000, HandleUserRegisterC2S);//注册帐号
            NetEvent.Instance.RemoveEventListener(1001, HandleUserLoginC2S);//登录帐号
            NetEvent.Instance.RemoveEventListener(1003, HandleUserQuitC2S);//请求退出/注销账号(换号的正常流程)
        }

        

         /// <summary> 注册帐号 </summary>
        private void HandleUserRegisterC2S(MsgEntity p)
        {
            UserRegisterC2S c2sMsg = UserRegisterC2S.Parser.ParseFrom(p.body);

            UserRegisterS2C s2cMsg = new UserRegisterS2C();
            //MsgToClient.SendBuff(p.id, s2cMsg, p.clientAgent);

        }

         /// <summary> 登录帐号 </summary>
        private void HandleUserLoginC2S(MsgEntity p)
        {
            UserLoginC2S c2sMsg = UserLoginC2S.Parser.ParseFrom(p.body);

            UserLoginS2C s2cMsg = new UserLoginS2C();
            //MsgToClient.SendBuff(p.id, s2cMsg, p.clientAgent);

        }

         /// <summary> 请求退出/注销账号(换号的正常流程) </summary>
        private void HandleUserQuitC2S(MsgEntity p)
        {
            UserQuitC2S c2sMsg = UserQuitC2S.Parser.ParseFrom(p.body);

            UserQuitS2C s2cMsg = new UserQuitS2C();
            //MsgToClient.SendBuff(p.id, s2cMsg, p.clientAgent);

        }


    }
}