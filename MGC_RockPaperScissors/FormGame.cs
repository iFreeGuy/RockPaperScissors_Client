using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;

namespace MGC_RockPaperScissors
{
    public partial class FormGame : Form
    {
        public string IP = string.Empty;
        public int Port = 0;
        private WebSocket wsClient_ = null;

        public FormGame()
        {
            InitializeComponent();
        }

        private string WSConnectStr()
        {
            return string.Format("ws://{0}:{1}", IP, Port);
        }

        private void btnRock_Click(object sender, EventArgs e)
        {
            var wsmsgData = new WSDataPlayerHand();
            wsmsgData.choice = PlayerChoice.Rock;

            WSMessage wsSendmsg = new WSMessage();
            wsSendmsg.messageID = WSMessageID.PlayMyHand;
            wsSendmsg.data = JsonConvert.SerializeObject(wsmsgData);

            string wsmsg = JsonConvert.SerializeObject(wsSendmsg);
            wsClient_.Send(wsmsg);

            AddMessage("Choose rock");
            EnableInput(false);
        }

        private void btnPaper_Click(object sender, EventArgs e)
        {
            var wsmsgData = new WSDataPlayerHand();
            wsmsgData.choice = PlayerChoice.Paper;

            WSMessage wsSendmsg = new WSMessage();
            wsSendmsg.messageID = WSMessageID.PlayMyHand;
            wsSendmsg.data = JsonConvert.SerializeObject(wsmsgData);

            string wsmsg = JsonConvert.SerializeObject(wsSendmsg);
            wsClient_.Send(wsmsg);

            AddMessage("Choose paper");
            EnableInput(false);
        }

        private void btnScissor_Click(object sender, EventArgs e)
        {
            var wsmsgData = new WSDataPlayerHand();
            wsmsgData.choice = PlayerChoice.Scissors;

            WSMessage wsSendmsg = new WSMessage();
            wsSendmsg.messageID = WSMessageID.PlayMyHand;
            wsSendmsg.data = JsonConvert.SerializeObject(wsmsgData);

            string wsmsg = JsonConvert.SerializeObject(wsSendmsg);
            wsClient_.Send(wsmsg);

            AddMessage("Choose scissor");
            EnableInput(false);
        }

        private void FormGame_Load(object sender, EventArgs e)
        {
            EnableInput(false);

            try
            {
                string uri = WSConnectStr();
                wsClient_ = new WebSocket(uri);

                wsClient_.OnOpen += OnWSClientOpen;
                wsClient_.OnClose += OnWSClientClose;
                wsClient_.OnError += OnWSClientError;
                wsClient_.OnMessage += OnWSClientMessage;

                wsClient_.Connect();

                if (!wsClient_.IsAlive)
                {
                    MessageBox.Show("Fail to connect");
                    Close();

                    return;
                }

                WSDataLogin msgData = new WSDataLogin();
                msgData.sessionKey = Session.Inst.SessionKey;

                WSMessage msg = new WSMessage();
                msg.messageID = WSMessageID.Login;
                msg.data = JsonConvert.SerializeObject(msgData);

                string wsmsg = JsonConvert.SerializeObject(msg);

                wsClient_.Send(wsmsg);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());

                MessageBox.Show("Unknown Error");
                Close();
            }
        }

        private void OnWSClientOpen(object sender, EventArgs e)
        {
            if (wsClient_.ReadyState == WebSocketState.Open)
            {
                Logger.Log("GameServer connected");
            }
            else if (wsClient_.ReadyState == WebSocketState.Closing || wsClient_.ReadyState == WebSocketState.Closed)
            {
                MessageBox.Show("GameServer disconnected");

                return;
            }
        }

        private void OnWSClientClose(object sender, CloseEventArgs e)
        {
            MessageBox.Show("GameServer disconnected");
        }

        private void OnWSClientError(object sender, ErrorEventArgs e)
        {
            MessageBox.Show("GameServer disconnected");
            wsClient_.Close();
        }

        private void OnWSClientMessage(object sender, MessageEventArgs e)
        {
            Logger.LogDebug("OnMessage: " + e.Data);

            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate {
                    var wsmsg = JsonConvert.DeserializeObject<WSMessage>(e.Data);

                    switch (wsmsg.messageID)
                    {
                        case WSMessageID.LoginReply:
                            OnWSMessageLoginReply(wsmsg);
                            break;

                        case WSMessageID.PlayGameReply:
                            OnWSMessagePlayGameReply(wsmsg);
                            break;

                        case WSMessageID.PlayerTurn:
                            OnWSMessagePlayerTurn(wsmsg);
                            break;

                        case WSMessageID.BattleStart:
                            OnWSMessageBattleStart(wsmsg);
                            break;

                        case WSMessageID.BattleResult:
                            OnWSMessageBattleResult(wsmsg);
                            break;

                        case WSMessageID.GamePlayResult:
                            OnWSMessageBattleGamePlayResult(wsmsg);
                            break;

                        case WSMessageID.OpponentOut:
                            OnWSMessageOpponentOut(wsmsg);
                            break;
                    }
                });
                return;
            }
        }

        private void OnWSMessageLoginReply(WSMessage wsmsg)
        {
            var msgData = JsonConvert.DeserializeObject<WSDataError>(wsmsg.data);

            if (msgData.resultCode != WSResultCode.Success)
            {
                MessageBox.Show("Fail to login GameServer");
                Close();

                return;
            }

            AddMessage("Log in to the game server");

            WSMessage msg = new WSMessage();
            msg.messageID = WSMessageID.PlayGame;
            msg.data = JsonConvert.SerializeObject(WSDefine.WSDataEmpty);

            string wsSendMsg = JsonConvert.SerializeObject(msg);

            wsClient_.Send(wsSendMsg);
        }

        private void OnWSMessagePlayGameReply(WSMessage wsmsg)
        {
            var msgData = JsonConvert.DeserializeObject<WSDataError>(wsmsg.data);

            if (msgData.resultCode != WSResultCode.Success)
            {
                MessageBox.Show("Fail to play game");
                Close();

                return;
            }

            AddMessage("Waiting for the game to start");
        }

        private void OnWSMessageBattleStart(WSMessage wsmsg)
        {
            var msgData = JsonConvert.DeserializeObject<WSDataBattleStart>(wsmsg.data);

            AddMessage(Environment.NewLine);
            AddMessage(string.Format("Round {0} Start", msgData.round));
        }

        private void OnWSMessageBattleResult(WSMessage wsmsg)
        {
            var msgData = JsonConvert.DeserializeObject<WSDataBattlePlayResult>(wsmsg.data);

            AddMessage(msgData.yourChoice.ToString() + " vs " + msgData.opponentChoice.ToString());
            AddMessage(msgData.result.ToString());
        }

        private void OnWSMessagePlayerTurn(WSMessage wsmsg)
        {
            MessageBox.Show("Choose your hand");
            EnableInput(true);
        }

        private void OnWSMessageBattleGamePlayResult(WSMessage wsmsg)
        {
            var msgData = JsonConvert.DeserializeObject<WSDataGamePlayResult>(wsmsg.data);

            string log = string.Format("Game End: Win: {0} / Lose: {1} / Draw: {2}",
                msgData.WinCount, msgData.LoseCount, msgData.DrawCount);

            AddMessage(Environment.NewLine);
            AddMessage(log);
        }

        private void OnWSMessageOpponentOut(WSMessage wsmsg)
        {
            AddMessage(Environment.NewLine);
            AddMessage("Game End: OpponentOut");
        }

        private void EnableInput(bool enable)
        {
            btnPaper.Enabled = enable;
            btnScissor.Enabled = enable;
            btnRock.Enabled = enable;
        }

        private void AddMessage(string msg)
        {
            txtGame.AppendText(msg);
            if (msg != Environment.NewLine)
            {
                txtGame.AppendText(Environment.NewLine);
            }
        }

        private void FormGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            Session.Inst.State = SessionState.Login;
            wsClient_.Close();
        }
    }
}










