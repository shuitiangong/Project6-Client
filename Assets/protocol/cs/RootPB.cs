// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: RootPB.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using System;
using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using scg = global::System.Collections.Generic;
namespace ProtoMsg {

  #region Messages
  public sealed class UserInfo : pb::IMessage {
    private static readonly pb::MessageParser<UserInfo> _parser = new pb::MessageParser<UserInfo>(() => new UserInfo());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<UserInfo> Parser { get { return _parser; } }

    /// <summary>Field number for the "ID" field.</summary>
    public const int IDFieldNumber = 1;
    private int iD_;
    /// <summary>
    ///用户ID,服务器自动生成,用户注册成功后返回给客户端
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int ID {
      get { return iD_; }
      set {
        iD_ = value;
      }
    }

    /// <summary>Field number for the "Account" field.</summary>
    public const int AccountFieldNumber = 2;
    private string account_ = "";
    /// <summary>
    ///帐号
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Account {
      get { return account_; }
      set {
        account_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Password" field.</summary>
    public const int PasswordFieldNumber = 3;
    private string password_ = "";
    /// <summary>
    ///密码
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Password {
      get { return password_; }
      set {
        password_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (ID != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(ID);
      }
      if (Account.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Account);
      }
      if (Password.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Password);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (ID != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(ID);
      }
      if (Account.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Account);
      }
      if (Password.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Password);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            ID = input.ReadInt32();
            break;
          }
          case 18: {
            Account = input.ReadString();
            break;
          }
          case 26: {
            Password = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed class RolesInfo : pb::IMessage {
    private static readonly pb::MessageParser<RolesInfo> _parser = new pb::MessageParser<RolesInfo>(() => new RolesInfo());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<RolesInfo> Parser { get { return _parser; } }

    /// <summary>Field number for the "ID" field.</summary>
    public const int IDFieldNumber = 1;
    private int iD_;
    /// <summary>
    ///用户ID-与账号一样
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int ID {
      get { return iD_; }
      set {
        iD_ = value;
      }
    }

    /// <summary>Field number for the "RolesID" field.</summary>
    public const int RolesIDFieldNumber = 2;
    private int rolesID_;
    /// <summary>
    ///角色ID（自动生成）
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int RolesID {
      get { return rolesID_; }
      set {
        rolesID_ = value;
      }
    }

    /// <summary>Field number for the "NickName" field.</summary>
    public const int NickNameFieldNumber = 3;
    private string nickName_ = "";
    /// <summary>
    ///昵称
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string NickName {
      get { return nickName_; }
      set {
        nickName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Level" field.</summary>
    public const int LevelFieldNumber = 4;
    private int level_;
    /// <summary>
    ///等级
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Level {
      get { return level_; }
      set {
        level_ = value;
      }
    }

    /// <summary>Field number for the "State" field.</summary>
    public const int StateFieldNumber = 5;
    private int state_;
    /// <summary>
    ///状态：0休闲 1游戏中 2离线
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int State {
      get { return state_; }
      set {
        state_ = value;
      }
    }

    /// <summary>Field number for the "VictoryPoint" field.</summary>
    public const int VictoryPointFieldNumber = 6;
    private int victoryPoint_;
    /// <summary>
    ///胜点:用于推算段位
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int VictoryPoint {
      get { return victoryPoint_; }
      set {
        victoryPoint_ = value;
      }
    }

    /// <summary>Field number for the "GoldCoin" field.</summary>
    public const int GoldCoinFieldNumber = 7;
    private int goldCoin_;
    /// <summary>
    ///金币数量
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int GoldCoin {
      get { return goldCoin_; }
      set {
        goldCoin_ = value;
      }
    }

    /// <summary>Field number for the "Diamonds" field.</summary>
    public const int DiamondsFieldNumber = 8;
    private int diamonds_;
    /// <summary>
    ///钻石数量
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Diamonds {
      get { return diamonds_; }
      set {
        diamonds_ = value;
      }
    }

    /// <summary>Field number for the "RoomID" field.</summary>
    public const int RoomIDFieldNumber = 9;
    private int roomID_;
    /// <summary>
    ///当前所在的房间ID,战斗时候掉线,重连时候用
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int RoomID {
      get { return roomID_; }
      set {
        roomID_ = value;
      }
    }

    /// <summary>Field number for the "SeatID" field.</summary>
    public const int SeatIDFieldNumber = 10;
    private int seatID_;
    /// <summary>
    ///房间中的位置ID
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int SeatID {
      get { return seatID_; }
      set {
        seatID_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (ID != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(ID);
      }
      if (RolesID != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(RolesID);
      }
      if (NickName.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(NickName);
      }
      if (Level != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(Level);
      }
      if (State != 0) {
        output.WriteRawTag(40);
        output.WriteInt32(State);
      }
      if (VictoryPoint != 0) {
        output.WriteRawTag(48);
        output.WriteInt32(VictoryPoint);
      }
      if (GoldCoin != 0) {
        output.WriteRawTag(56);
        output.WriteInt32(GoldCoin);
      }
      if (Diamonds != 0) {
        output.WriteRawTag(64);
        output.WriteInt32(Diamonds);
      }
      if (RoomID != 0) {
        output.WriteRawTag(72);
        output.WriteInt32(RoomID);
      }
      if (SeatID != 0) {
        output.WriteRawTag(80);
        output.WriteInt32(SeatID);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (ID != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(ID);
      }
      if (RolesID != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(RolesID);
      }
      if (NickName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(NickName);
      }
      if (Level != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Level);
      }
      if (State != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(State);
      }
      if (VictoryPoint != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(VictoryPoint);
      }
      if (GoldCoin != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(GoldCoin);
      }
      if (Diamonds != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Diamonds);
      }
      if (RoomID != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(RoomID);
      }
      if (SeatID != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(SeatID);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            ID = input.ReadInt32();
            break;
          }
          case 16: {
            RolesID = input.ReadInt32();
            break;
          }
          case 26: {
            NickName = input.ReadString();
            break;
          }
          case 32: {
            Level = input.ReadInt32();
            break;
          }
          case 40: {
            State = input.ReadInt32();
            break;
          }
          case 48: {
            VictoryPoint = input.ReadInt32();
            break;
          }
          case 56: {
            GoldCoin = input.ReadInt32();
            break;
          }
          case 64: {
            Diamonds = input.ReadInt32();
            break;
          }
          case 72: {
            RoomID = input.ReadInt32();
            break;
          }
          case 80: {
            SeatID = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  public sealed class RoomInfo : pb::IMessage {
    private static readonly pb::MessageParser<RoomInfo> _parser = new pb::MessageParser<RoomInfo>(() => new RoomInfo());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<RoomInfo> Parser { get { return _parser; } }

    /// <summary>Field number for the "ID" field.</summary>
    public const int IDFieldNumber = 1;
    private int iD_;
    /// <summary>
    ///房间ID
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int ID {
      get { return iD_; }
      set {
        iD_ = value;
      }
    }

    /// <summary>Field number for the "TeamA" field.</summary>
    public const int TeamAFieldNumber = 2;
    private static readonly pb::FieldCodec<global::ProtoMsg.RolesInfo> _repeated_teamA_codec
        = pb::FieldCodec.ForMessage(18, global::ProtoMsg.RolesInfo.Parser);
    private readonly pbc::RepeatedField<global::ProtoMsg.RolesInfo> teamA_ = new pbc::RepeatedField<global::ProtoMsg.RolesInfo>();
    /// <summary>
    ///队伍1 (0-4)
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::ProtoMsg.RolesInfo> TeamA {
      get { return teamA_; }
    }

    /// <summary>Field number for the "TeamB" field.</summary>
    public const int TeamBFieldNumber = 3;
    private static readonly pb::FieldCodec<global::ProtoMsg.RolesInfo> _repeated_teamB_codec
        = pb::FieldCodec.ForMessage(26, global::ProtoMsg.RolesInfo.Parser);
    private readonly pbc::RepeatedField<global::ProtoMsg.RolesInfo> teamB_ = new pbc::RepeatedField<global::ProtoMsg.RolesInfo>();
    /// <summary>
    ///队伍2 (5-9)
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::ProtoMsg.RolesInfo> TeamB {
      get { return teamB_; }
    }

    /// <summary>Field number for the "StartTime" field.</summary>
    public const int StartTimeFieldNumber = 4;
    private long startTime_;
    /// <summary>
    ///开始的时间
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long StartTime {
      get { return startTime_; }
      set {
        startTime_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (ID != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(ID);
      }
      teamA_.WriteTo(output, _repeated_teamA_codec);
      teamB_.WriteTo(output, _repeated_teamB_codec);
      if (StartTime != 0L) {
        output.WriteRawTag(32);
        output.WriteInt64(StartTime);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (ID != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(ID);
      }
      size += teamA_.CalculateSize(_repeated_teamA_codec);
      size += teamB_.CalculateSize(_repeated_teamB_codec);
      if (StartTime != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(StartTime);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            ID = input.ReadInt32();
            break;
          }
          case 18: {
            teamA_.AddEntriesFrom(input, _repeated_teamA_codec);
            break;
          }
          case 26: {
            teamB_.AddEntriesFrom(input, _repeated_teamB_codec);
            break;
          }
          case 32: {
            StartTime = input.ReadInt64();
            break;
          }
        }
      }
    }

  }

  public sealed class PlayerInfo : pb::IMessage {
    private static readonly pb::MessageParser<PlayerInfo> _parser = new pb::MessageParser<PlayerInfo>(() => new PlayerInfo());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<PlayerInfo> Parser { get { return _parser; } }

    /// <summary>Field number for the "RolesInfo" field.</summary>
    public const int RolesInfoFieldNumber = 1;
    private global::ProtoMsg.RolesInfo rolesInfo_;
    /// <summary>
    ///玩家的角色信息
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::ProtoMsg.RolesInfo RolesInfo {
      get { return rolesInfo_; }
      set {
        rolesInfo_ = value;
      }
    }

    /// <summary>Field number for the "SkillA" field.</summary>
    public const int SkillAFieldNumber = 2;
    private int skillA_;
    /// <summary>
    ///玩家的技能A 默认是103 点燃
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int SkillA {
      get { return skillA_; }
      set {
        skillA_ = value;
      }
    }

    /// <summary>Field number for the "SkillB" field.</summary>
    public const int SkillBFieldNumber = 3;
    private int skillB_;
    /// <summary>
    ///玩家的技能B 默认是106 闪现
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int SkillB {
      get { return skillB_; }
      set {
        skillB_ = value;
      }
    }

    /// <summary>Field number for the "HeroID" field.</summary>
    public const int HeroIDFieldNumber = 4;
    private int heroID_;
    /// <summary>
    ///选择的英雄ID
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int HeroID {
      get { return heroID_; }
      set {
        heroID_ = value;
      }
    }

    /// <summary>Field number for the "TeamID" field.</summary>
    public const int TeamIDFieldNumber = 5;
    private int teamID_;
    /// <summary>
    ///队伍ID 0表示队伍A 1表示队伍B
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int TeamID {
      get { return teamID_; }
      set {
        teamID_ = value;
      }
    }

    /// <summary>Field number for the "PosID" field.</summary>
    public const int PosIDFieldNumber = 6;
    private int posID_;
    /// <summary>
    ///位置
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int PosID {
      get { return posID_; }
      set {
        posID_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (rolesInfo_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(RolesInfo);
      }
      if (SkillA != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(SkillA);
      }
      if (SkillB != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(SkillB);
      }
      if (HeroID != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(HeroID);
      }
      if (TeamID != 0) {
        output.WriteRawTag(40);
        output.WriteInt32(TeamID);
      }
      if (PosID != 0) {
        output.WriteRawTag(48);
        output.WriteInt32(PosID);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (rolesInfo_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(RolesInfo);
      }
      if (SkillA != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(SkillA);
      }
      if (SkillB != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(SkillB);
      }
      if (HeroID != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(HeroID);
      }
      if (TeamID != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(TeamID);
      }
      if (PosID != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(PosID);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            if (rolesInfo_ == null) {
              rolesInfo_ = new global::ProtoMsg.RolesInfo();
            }
            input.ReadMessage(rolesInfo_);
            break;
          }
          case 16: {
            SkillA = input.ReadInt32();
            break;
          }
          case 24: {
            SkillB = input.ReadInt32();
            break;
          }
          case 32: {
            HeroID = input.ReadInt32();
            break;
          }
          case 40: {
            TeamID = input.ReadInt32();
            break;
          }
          case 48: {
            PosID = input.ReadInt32();
            break;
          }
        }
      }
    }

    }

  public sealed class V3Info : pb::IMessage {
    private static readonly pb::MessageParser<V3Info> _parser = new pb::MessageParser<V3Info>(() => new V3Info());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<V3Info> Parser { get { return _parser; } }

    /// <summary>Field number for the "X" field.</summary>
    public const int XFieldNumber = 1;
    private int x_;
    /// <summary>
    ///x轴
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int X {
      get { return x_; }
      set {
        x_ = value;
      }
    }

    /// <summary>Field number for the "Y" field.</summary>
    public const int YFieldNumber = 2;
    private int y_;
    /// <summary>
    ///y轴
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Y {
      get { return y_; }
      set {
        y_ = value;
      }
    }

    /// <summary>Field number for the "Z" field.</summary>
    public const int ZFieldNumber = 3;
    private int z_;
    /// <summary>
    ///z轴
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Z {
      get { return z_; }
      set {
        z_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (X != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(X);
      }
      if (Y != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(Y);
      }
      if (Z != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(Z);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (X != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(X);
      }
      if (Y != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Y);
      }
      if (Z != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Z);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            X = input.ReadInt32();
            break;
          }
          case 16: {
            Y = input.ReadInt32();
            break;
          }
          case 24: {
            Z = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  public sealed class BattleFrameInfo : pb::IMessage {
    private static readonly pb::MessageParser<BattleFrameInfo> _parser = new pb::MessageParser<BattleFrameInfo>(() => new BattleFrameInfo());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<BattleFrameInfo> Parser { get { return _parser; } }

    /// <summary>Field number for the "UserID" field.</summary>
    public const int UserIDFieldNumber = 1;
    private int userID_;
    /// <summary>
    ///用户ID
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int UserID {
      get { return userID_; }
      set {
        userID_ = value;
      }
    }

    /// <summary>Field number for the "PlayerMove" field.</summary>
    public const int PlayerMoveFieldNumber = 2;
    private static readonly pb::FieldCodec<global::ProtoMsg.MoveInfo> _repeated_playerMove_codec
        = pb::FieldCodec.ForMessage(18, global::ProtoMsg.MoveInfo.Parser);
    private readonly pbc::RepeatedField<global::ProtoMsg.MoveInfo> playerMove_ = new pbc::RepeatedField<global::ProtoMsg.MoveInfo>();
    /// <summary>
    ///用户输入-移动
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::ProtoMsg.MoveInfo> PlayerMove {
      get { return playerMove_; }
    }

    /// <summary>Field number for the "ReleaseSkills" field.</summary>
    public const int ReleaseSkillsFieldNumber = 3;
    private static readonly pb::FieldCodec<global::ProtoMsg.SkillInfo> _repeated_releaseSkills_codec
        = pb::FieldCodec.ForMessage(26, global::ProtoMsg.SkillInfo.Parser);
    private readonly pbc::RepeatedField<global::ProtoMsg.SkillInfo> releaseSkills_ = new pbc::RepeatedField<global::ProtoMsg.SkillInfo>();
    /// <summary>
    ///用户输入-释放技能
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::ProtoMsg.SkillInfo> ReleaseSkills {
      get { return releaseSkills_; }
    }

    /// <summary>Field number for the "BuyEquipmentMSG" field.</summary>
    public const int BuyEquipmentMSGFieldNumber = 4;
    private static readonly pb::FieldCodec<global::ProtoMsg.BuyEquipmentInfo> _repeated_buyEquipmentMSG_codec
        = pb::FieldCodec.ForMessage(34, global::ProtoMsg.BuyEquipmentInfo.Parser);
    private readonly pbc::RepeatedField<global::ProtoMsg.BuyEquipmentInfo> buyEquipmentMSG_ = new pbc::RepeatedField<global::ProtoMsg.BuyEquipmentInfo>();
    /// <summary>
    ///用户输入-购买装备
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::ProtoMsg.BuyEquipmentInfo> BuyEquipmentMSG {
      get { return buyEquipmentMSG_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (UserID != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(UserID);
      }
      playerMove_.WriteTo(output, _repeated_playerMove_codec);
      releaseSkills_.WriteTo(output, _repeated_releaseSkills_codec);
      buyEquipmentMSG_.WriteTo(output, _repeated_buyEquipmentMSG_codec);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (UserID != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(UserID);
      }
      size += playerMove_.CalculateSize(_repeated_playerMove_codec);
      size += releaseSkills_.CalculateSize(_repeated_releaseSkills_codec);
      size += buyEquipmentMSG_.CalculateSize(_repeated_buyEquipmentMSG_codec);
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            UserID = input.ReadInt32();
            break;
          }
          case 18: {
            playerMove_.AddEntriesFrom(input, _repeated_playerMove_codec);
            break;
          }
          case 26: {
            releaseSkills_.AddEntriesFrom(input, _repeated_releaseSkills_codec);
            break;
          }
          case 34: {
            buyEquipmentMSG_.AddEntriesFrom(input, _repeated_buyEquipmentMSG_codec);
            break;
          }
        }
      }
    }

  }

  public sealed class MoveInfo : pb::IMessage {
    private static readonly pb::MessageParser<MoveInfo> _parser = new pb::MessageParser<MoveInfo>(() => new MoveInfo());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<MoveInfo> Parser { get { return _parser; } }

    /// <summary>Field number for the "Position" field.</summary>
    public const int PositionFieldNumber = 1;
    private global::ProtoMsg.V3Info position_;
    /// <summary>
    ///目标位置
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::ProtoMsg.V3Info Position {
      get { return position_; }
      set {
        position_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (position_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Position);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (position_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Position);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            if (position_ == null) {
              position_ = new global::ProtoMsg.V3Info();
            }
            input.ReadMessage(position_);
            break;
          }
        }
      }
    }

  }

  public sealed class SkillInfo : pb::IMessage {
    private static readonly pb::MessageParser<SkillInfo> _parser = new pb::MessageParser<SkillInfo>(() => new SkillInfo());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<SkillInfo> Parser { get { return _parser; } }

    /// <summary>Field number for the "SkillID" field.</summary>
    public const int SkillIDFieldNumber = 1;
    private int skillID_;
    /// <summary>
    ///技能ID
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int SkillID {
      get { return skillID_; }
      set {
        skillID_ = value;
      }
    }

    /// <summary>Field number for the "Position" field.</summary>
    public const int PositionFieldNumber = 2;
    private global::ProtoMsg.V3Info position_;
    /// <summary>
    ///释放位置
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::ProtoMsg.V3Info Position {
      get { return position_; }
      set {
        position_ = value;
      }
    }

    /// <summary>Field number for the "Rotation" field.</summary>
    public const int RotationFieldNumber = 3;
    private global::ProtoMsg.V3Info rotation_;
    /// <summary>
    ///释放朝向
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::ProtoMsg.V3Info Rotation {
      get { return rotation_; }
      set {
        rotation_ = value;
      }
    }

    /// <summary>Field number for the "LockID" field.</summary>
    public const int LockIDFieldNumber = 4;
    private int lockID_;
    /// <summary>
    ///锁定的目标ID
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int LockID {
      get { return lockID_; }
      set {
        lockID_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (SkillID != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(SkillID);
      }
      if (position_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(Position);
      }
      if (rotation_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(Rotation);
      }
      if (LockID != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(LockID);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (SkillID != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(SkillID);
      }
      if (position_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Position);
      }
      if (rotation_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Rotation);
      }
      if (LockID != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(LockID);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            SkillID = input.ReadInt32();
            break;
          }
          case 18: {
            if (position_ == null) {
              position_ = new global::ProtoMsg.V3Info();
            }
            input.ReadMessage(position_);
            break;
          }
          case 26: {
            if (rotation_ == null) {
              rotation_ = new global::ProtoMsg.V3Info();
            }
            input.ReadMessage(rotation_);
            break;
          }
          case 32: {
            LockID = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  public sealed class BuyEquipmentInfo : pb::IMessage {
    private static readonly pb::MessageParser<BuyEquipmentInfo> _parser = new pb::MessageParser<BuyEquipmentInfo>(() => new BuyEquipmentInfo());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<BuyEquipmentInfo> Parser { get { return _parser; } }

    /// <summary>Field number for the "EquipmentID" field.</summary>
    public const int EquipmentIDFieldNumber = 1;
    private int equipmentID_;
    /// <summary>
    ///装备ID
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int EquipmentID {
      get { return equipmentID_; }
      set {
        equipmentID_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (EquipmentID != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(EquipmentID);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (EquipmentID != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(EquipmentID);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            EquipmentID = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
