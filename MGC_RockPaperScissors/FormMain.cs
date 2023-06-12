using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MGC_RockPaperScissors
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            Session.Inst.State = SessionState.NotLogin;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Trim() == "" || txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("No ID or Password");

                return;
            }


            var param = new ParamLogin();
            param.id = txtID.Text;
            param.password = txtPassword.Text;

            var msg = LoginAPI.login(param);
            if (msg == null)
            {
                MessageBox.Show("Unknown Error");
            }
            else
            {
                if (msg.resultCode == APIResultCode.Fail)
                {
                    MessageBox.Show("ID or Password is incorrect");

                    return;
                }
                else if (msg.resultCode == APIResultCode.Success)
                {
                    var jobj = JObject.Parse(msg.data);

                    var sessionKey = jobj["sessionKey"].Value<string>();

                    Session.Inst.State = SessionState.Login;
                    Session.Inst.SessionKey = sessionKey;

                    MessageBox.Show("Login okay");
                }
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (Session.Inst.State != SessionState.Login)
            {
                MessageBox.Show("Session state is wrong");
                return;
            }

            var param = new ParamSessionKeyOnly();
            param.sessionKey = Session.Inst.SessionKey;

            var msg = LoginAPI.logout(param);
            if (msg == null)
            {
                MessageBox.Show("Unknown Error");
            }
            else
            {
                if (msg.resultCode == APIResultCode.Fail)
                {
                    MessageBox.Show("Logout fail");

                    msg.debug();

                    return;
                }
                else if (msg.resultCode == APIResultCode.Success)
                {
                    MessageBox.Show("Logout okay");

                    Session.Inst.State = SessionState.NotLogin;
                    Session.Inst.SessionKey = string.Empty;
                }
            }
        }

        private void btnPlayGame_Click(object sender, EventArgs e)
        {
            if (Session.Inst.State != SessionState.Login)
            {
                MessageBox.Show("Session state is wrong");
                return;
            }

            var param = new ParamSessionKeyOnly();
            param.sessionKey = Session.Inst.SessionKey;

            var msg = GameAPI.playGame(param);
            if (msg == null)
            {
                MessageBox.Show("Unknown Error");
            }
            else
            {
                if (msg.resultCode == APIResultCode.Fail)
                {
                    MessageBox.Show("playGame fail");

                    return;
                }
                else if (msg.resultCode == APIResultCode.Success)
                {
                    var reply = JsonConvert.DeserializeObject<APIReplayPlayGame>(msg.data);

                    Session.Inst.State = SessionState.PlayGame;

                    var frm = new FormGame();
                    frm.IP = reply.ip;
                    frm.Port = reply.port;
                    frm.ShowDialog();
                }
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //txtID.Text = "user1";
            //txtPassword.Text = "password1";
        }
    }
}
