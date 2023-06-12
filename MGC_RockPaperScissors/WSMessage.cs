using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MGC_RockPaperScissors
{
    enum WSMessageID
    {
        UnknownError = 0,
        Login = 1,
        LoginReply = 2,
        PlayGame = 3,
        PlayGameReply = 4,
        PlayerTurn = 5,
        PlayMyHand = 6,
        BattleStart = 8,
        BattleResult = 9,
        GamePlayResult = 10,
        OpponentOut = 11,
    }

    enum WSResultCode
    {
        Success = 0,
        ErrorSessionNotFound = -1,
        ErrorWrongMessage = -2,
    }

    enum PlayerChoice
    {
        Scissors = 0,
        Rock = 1,
        Paper = 2
    }

    enum BattlePlayResult
    {
        Win = 0,
        Lose = 1,
        Draw = 2
    }

    class WSMessage
    {
        public WSMessageID messageID = WSMessageID.UnknownError;
        public string data = string.Empty;
    }

    class WSDataLogin
    {
        public string sessionKey = string.Empty;
    }

    class WSDataError
    {
        public WSResultCode resultCode = WSResultCode.Success;
    }

    class WSDataPlayerHand
    {
        public PlayerChoice choice;
    }

    class WSDataBattleStart
    {
        public int round = 0;
    }

    class WSDataBattlePlayResult
    {
        public BattlePlayResult result = BattlePlayResult.Win;
        public PlayerChoice yourChoice = PlayerChoice.Paper;
        public PlayerChoice opponentChoice = PlayerChoice.Paper;
    }

    class WSDataGamePlayResult
    {
        public int WinCount = 0;
        public int LoseCount = 0;
        public int DrawCount = 0;
    }
    class WSDefine
    {
        public const string WSDataEmpty = "{}";
    }
}












