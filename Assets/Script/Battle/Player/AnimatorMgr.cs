﻿using ProtoMsg;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerAnimationClip
{
    None,
    Idle,
    Run,
    Dance,
    Dead,
    SkillQ,
    SkillW,
    SkillE,
    SkillR,
    NormalAttack,
}

public class AnimatorMgr : MonoBehaviour
{
    PlayerCtrl playerCtrl;
    PlayerInfo playerInfo;
    Animator animator;
    public string[] clips = new string[] { "None","Idle","Run", "Dead" , "SkillQ",
        "SkillW","SkillE","SkillR","NormalAttack"};
    public void Init(PlayerCtrl playerCtrl)
    {
        this.playerCtrl = playerCtrl;
        playerInfo = playerCtrl.playerInfo;
        animator = transform.GetComponent<Animator>();
    }

    public void Play(PlayerAnimationClip clip)
    {
        ResetState();
        animator.SetBool(clip.ToString(), true);
    }

    private void ResetState()
    {
        for (int i = 0; i<clips.Length; i++)
        {
            animator.SetBool(clips[i], false);
        }
    }

    public void DoSkillQEvent()
    {
        SpawnEffect("Q");
    }

    public void DoSkillWEvent()
    {
        SpawnEffect("W");
    }

    public void DoSkillEEvent()
    {
        SpawnEffect("E");
    }

    public void DoSkillREvent()
    {
        SpawnEffect("R");
    }

    public void DoSkillAEvent()
    {
        SpawnEffect("A");
    }

    public void SpawnEffect(string key)
    {
        GameObject effect = ResMgr.Instance.LoadEffect(playerInfo.HeroID, key);
        effect.transform.position = transform.position;
        effect.transform.eulerAngles = transform.eulerAngles;
        effect.SetActive(true);
        EConfig eConfig = effect.transform.GetComponent<EConfig>();
        BattleUserInputC2S skillCMD = playerCtrl.playerFSM.skillCMD.CMD;
        //playerCtrl.OnSkillTrriger 技能出发回调 由释放者控制
        eConfig.Init(skillCMD.RolesID, skillCMD.LockTag, skillCMD.LockID,
            transform.forward, transform.position, playerCtrl.OnSkillTrriger);
    }

    public void EndSkill()
    {
        Debug.Log("技能释放结束");
        playerCtrl.playerFSM.ToNext(FSMState.Idle);
    }
}
