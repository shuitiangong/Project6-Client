using ProtoMsg;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainMgr : MonoBehaviour
{
    private bool isInit;
    private void Awake()
    {
        //TODO: 拉取在线玩家列表
        isInit = false;
        //foreach (var playerInfo in RoomData.Instance.playerinfos)
        //{
        //    GameObject hero = ResMgr.Instance.LoadModel($"Hero/{playerInfo.HeroID}/Model/{playerInfo.HeroID}");
        //    hero.transform.position = BattleConfig.Instance.spawnPosition[playerInfo.PosID];
        //    hero.transform.eulerAngles = BattleConfig.Instance.spawnRotation[playerInfo.PosID];

        //    PlayerCtrl playerCtrl = hero.AddComponent<PlayerCtrl>();
        //    RoomMgr.Instance.SavePlayerCtrl(playerInfo.RolesInfo.RolesID, playerCtrl);
        //    RoomMgr.Instance.SavePlayerObjects(playerInfo.RolesInfo.RolesID, hero);
        //    //初始化每个角色 挂载控制器
        //    Debug.Log($"playerID: {playerInfo.RolesInfo.RolesID}");
        //    playerCtrl.Init(playerInfo);
        //}
        RoomMgr.Instance.InitData();
        BattleListener.Instance.Init();
        GameObject hero = ResMgr.Instance.LoadModel($"Hero/{1001}/Model/{1001}");
        hero.transform.position = new Vector3(22, 12, 139);
        hero.transform.eulerAngles = Vector3.zero;
        PlayerCtrl playerCtrl = hero.AddComponent<PlayerCtrl>();
        RoomMgr.Instance.SavePlayerCtrl(PlayerMgr.Instance.GetRolesInfo().RolesID, playerCtrl);
        RoomMgr.Instance.SavePlayerObjects(PlayerMgr.Instance.GetRolesInfo().RolesID, hero);
        PlayerInfo playerInfo = new PlayerInfo();
        playerInfo.RolesInfo = PlayerMgr.Instance.GetRolesInfo();
        playerInfo.PosID = 0;
        playerInfo.HeroID = 1001;
        playerInfo.TeamID = 0;
        //初始化每个角色 挂载控制器
        Debug.Log($"playerID: {playerInfo.RolesInfo.RolesID}");
        playerCtrl.Init(playerInfo);

        this.gameObject.AddComponent<InputCtrl>();
        isInit = true;
    }

    public void HandleCMD(BattleUserInputS2C s2cMSG)
    {
        Debug.Log(s2cMSG);
        //先确定发送命令的玩家
        //调用其角色控制器 处理这个事件
        RoomMgr.Instance.GetPlayerCtrl(s2cMSG.CMD.RolesID).playerFSM.HandleCMD(s2cMSG);
    }

    private void Update()
    {
        if (isInit) 
        {
            BattleListener.Instance.PlayerFrame(HandleCMD);
        }
    }

    private void OnDestroy()
    {
        RoomMgr.Instance.CloseRoom();
    }
}
