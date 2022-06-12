using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Net.Sockets;

namespace Black_Desert_Private_Launcher
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.ParseLogin();
            this.ParseWorld();
            this.Text = "White Desert Launcher";
            string currentdir = System.IO.Directory.GetCurrentDirectory();
            string exeFile = currentdir + "\\bin64\\BlackDesert64.exe"; //\\bin64\\BlackDesert64.exe"
            bool ready0 = System.IO.File.Exists(exeFile);
            if (ready0 == false)
            {
                MessageBox.Show(" 검은사막 파일이 없습니다! \n 접속기를 'bin64' 폴더 밖에 넣어주세요.", "경고! 게임 파일 없음!");
                Environment.Exit(0);
            }
            if (White_Desert_Launcher.Properties.Settings.Default.Email != string.Empty)
            {
                textBoxUserEmail.Text = White_Desert_Launcher.Properties.Settings.Default.Email;
                textBox_Password.Text = White_Desert_Launcher.Properties.Settings.Default.Password;
                checkBoxRememberMe.Checked = true;
            } else
            {
                textBoxUserEmail.Text = White_Desert_Launcher.Properties.Settings.Default.Email;
                textBox_Password.Text = White_Desert_Launcher.Properties.Settings.Default.Password;
                checkBoxRememberMe.Checked = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBoxRememberMe.Checked)
            {
                White_Desert_Launcher.Properties.Settings.Default.Email = textBoxUserEmail.Text;
                White_Desert_Launcher.Properties.Settings.Default.Password = textBox_Password.Text;
                White_Desert_Launcher.Properties.Settings.Default.Save();
                checkBoxRememberMe.Checked = true;
            }
            serviceIni();
            clientRun();

        }

        private void clientRun()
        {
            Process p = new Process();
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "cmd.exe";
            info.RedirectStandardInput = true;
            info.UseShellExecute = false;
            info.CreateNoWindow = true;

            p.StartInfo = info;
            p.Start();

            using (StreamWriter sw = p.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    sw.WriteLine("cd bin64");
                    sw.WriteLine("start BlackDesert64.exe" + " " + textBoxUserEmail.Text + "," + textBox_Password.Text);
                }
                Thread.Sleep(5000);
                engineInject();
            }
        }

       private void engineInject()
        {
            if (Process.GetProcessesByName("BlackDesert64").Length == 0)
            {
                MessageBox.Show("검은사막을 찾을 수 없습니다.");
                return;
            }
            //Globals.Memory();
        }

        private void ParseLogin()
        {
            try
            {
                string host = "testsw.kro.kr";
                int port = 1044;
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                bool flag = socket.BeginConnect(host, port, (AsyncCallback)null, (object)null).AsyncWaitHandle.WaitOne(100, true);
                if (flag)
                {
                    this.LoginServerTest.Checked = (true);
                    socket.Close();
                }
                else
                {
                    if (flag)
                        return;
                    this.LoginServerTest.Checked = (false);
                    socket.Close();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void ParseWorld()
        {
            try
            {
                string host = "testsw.kro.kr";
                int port = 1045;
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                bool flag = socket.BeginConnect(host, port, (AsyncCallback)null, (object)null).AsyncWaitHandle.WaitOne(100, true);
                if (flag)
                {
                    this.WorldServerTest.Checked = true;
                    socket.Close();
                }
                else
                {
                    if (flag)
                        return;
                    this.WorldServerTest.Checked = false;
                    socket.Close();
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void serviceIni() // builds the servce.ini file
        {

            var MyIni = new IniFile("service.ini");


            if (!MyIni.KeyExists("TYPE", "SERVICE"))            
            {
                MyIni.Write("TYPE", "GT", "SERVICE");         
            }
            if (!MyIni.KeyExists("RES", "SERVICE"))          
            {
                MyIni.Write("RES", "", "SERVICE");
            }
            if (!MyIni.KeyExists("AUTHENTIC_DOMAIN", "GT"))
            {
                MyIni.Write("AUTHENTIC_DOMAIN", "testsw.kro.kr", "GT"); 
            }
            if (!MyIni.KeyExists("AUTHENTIC_PORT", "GT"))
            {
                MyIni.Write("AUTHENTIC_PORT", "1044", "GT");
            }
            if (!MyIni.KeyExists("PATCH_URL", "GT"))
            {
                MyIni.Write("PATCH_URL", "http://patch.black.gdn.gamecdn.net/gdn/black/live/patch/", "GT");
            }
            
            MyIni.Write("AUTHENTIC_DOMAIN", "testsw.kro.kr", "GT");
            MyIni.Write("AUTHENTIC_PORT", "1044", "GT");
        }

        private void textBoxUserEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
        }
    
        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void textBox_Password_TextChanged(object sender, EventArgs e)
        {
        }

        private void LoginServerTest_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void WorldServerTest_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void LoginServerTest_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void WorldServerTest_CheckedChanged_1(object sender, EventArgs e)
        {
        }
    }
}