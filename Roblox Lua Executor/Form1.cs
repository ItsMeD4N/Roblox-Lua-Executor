using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VelocityAPI;

namespace Roblox_Lua_Executor
{
    public partial class Form1 : Form
    {
        private readonly VelAPI Velocity = new VelAPI();
        private const string SettingsFile = "settings.txt";
        public Form1()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.appicon;
        }
        private async void Attachwithapi()
        {
            bool Nezur = File.ReadAllText("settings.txt").Contains("Nezur = True");
            bool Xeno = File.ReadAllText("settings.txt").Contains("Xeno = True");
            bool Velocityy = File.ReadAllText("settings.txt").Contains("Velocity = True");

            if (Nezur)
            {
                int currentState = MultiRko.NezurModules.InjectionCheck();
                currentState = MultiRko.NezurModules.InjectionCheck();
                if (MultiRko.RobloxUtils.IsRobloxRunning())
                {
                    LogToConsole("roblox detected!", LogType.INFO);

                    if (currentState == 0)
                    {
                        LogToConsole("RKOAPI - Nezur Injecting!", LogType.Success);
                        MultiRko.NezurModules.Inject();
                    }

                    else if (currentState == 1)
                    {

                        LogToConsole("RKOAPI - Nezur is already injected!", LogType.Warning);
                    }

                }
                else
                {
                    LogToConsole("roblox not detected!", LogType.Warning);
                }


            }


            if (Xeno)
            {

                if (MultiRko.RobloxUtils.IsRobloxRunning())
                {
                    LogToConsole("roblox detected!", LogType.INFO);
                    MultiRko.XenoModules.Inject();
                    LogToConsole("RKOAPI - Xeno Injecting!", LogType.Success);
                }
                else
                {
                    LogToConsole("roblox not detected!", LogType.Warning);
                }

            }
            if (Velocityy)
            {
                if (RobloxLabel.ForeColor == Color.Green)
                {
                    LogToConsole("roblox detected!", LogType.INFO);
                    var roblox = Process.GetProcessesByName("RobloxPlayerBeta").FirstOrDefault();
                    var robloxid = roblox.Id;
                    await Velocity.Attach(robloxid);
                    LogToConsole("Velocity Injecting!", LogType.Success);
                }
                else
                {
                    LogToConsole("roblox not detected!", LogType.Warning);
                }
            }
        }

        private void rbxcheck()
        {
            if (MultiRko.RobloxUtils.IsRobloxRunning())
            {
                RobloxLabel.ForeColor = Color.Green;
                RobloxLabel.Text = "Roblox Open";
            }
            else
            {
                RobloxLabel.ForeColor = Color.Red;
                RobloxLabel.Text = "Roblox Undetected";
            }
        }



        private async Task CleaWhiteitor()
        {
            await webView21.CoreWebView2.ExecuteScriptAsync("window.celestiaEditor && window.celestiaEditor.clearText && window.celestiaEditor.clearText();");

        }



        private async Task<string> GetEditorContent()
        {
            await webView21.EnsureCoreWebView2Async();
            string script = "monaco.editor.getModels()[0].getValue()";
            string result = await webView21.ExecuteScriptAsync(script);
            return JsonConvert.DeserializeObject<string>(result);
        }

        private async Task ExecuteScriptAsync()
        {
            string scriptcontent = await GetEditorContent();
            MultiRko.XenoModules.ExecuteScript(scriptcontent);

        }

        private async Task ExecuteScriptAsync2()
        {
            string scriptcontent = await GetEditorContent();
            MultiRko.NezurModules.ExecuteScript(scriptcontent);
        }
        private async Task ExecuteScriptAsync3()
        {
            string scriptcontent = await GetEditorContent();
            Velocity.Execute(scriptcontent);

        }
        private async void Execute()
        {
            var roblox = Process.GetProcessesByName("RobloxPlayerBeta").FirstOrDefault();
            var robloxid = roblox.Id;
            bool Nezur = File.ReadAllText("settings.txt").Contains("Nezur = True");
            bool Xeno = File.ReadAllText("settings.txt").Contains("Xeno = True");
            bool Velocityy = File.ReadAllText("settings.txt").Contains("Velocity = True");
            if (Velocityy)
            {
                if (Velocity.IsAttached(robloxid))
                {
                    await ExecuteScriptAsync3();
                    LogToConsole("Script Executed", LogType.Success);
                }
                else
                {
                    LogToConsole("Roblox not  Detected", LogType.ERROR);
                }
            }

            if (Nezur)
            {
                if (MultiRko.RobloxUtils.IsRobloxRunning())
                {
                    await ExecuteScriptAsync2();
                    LogToConsole("Script Executed", LogType.Success);
                }

                else { LogToConsole("Roblox not  Detected", LogType.ERROR); }
            }
            if (Xeno)
            {
                if (MultiRko.RobloxUtils.IsRobloxRunning())
                {
                    await ExecuteScriptAsync();
                    LogToConsole("Script Executed", LogType.Success);
                }

                else { LogToConsole("Roblox not  Detected", LogType.ERROR); }
            }
        }

        private void nezurcheck()
        {

            if (MultiRko.NezurModules.InjectionCheck() == 0)
            {
                NezurLabel.ForeColor = Color.Red;
                NezurLabel.Text = "Nezur: not injected";
            }
            else if (MultiRko.NezurModules.InjectionCheck() == 1)
            {
                NezurLabel.ForeColor = Color.Green;
                NezurLabel.Text = "Nezur: injected";
            }

        }
        private void xenocheck()
        {

            if (MultiRko.XenoModules.InjectionCheck() == 0)
            {
                XenoLabel.ForeColor = Color.Red;
                XenoLabel.Text = "Xeno: not injected";
            }
            else
            {
                XenoLabel.ForeColor = Color.Green;
                XenoLabel.Text = "Xeno: injected";
            }

        }
        private void VelocityCheck()
        {
            var roblox = Process.GetProcessesByName("RobloxPlayerBeta").FirstOrDefault();

            if (roblox == null)
            {
                VelocityLabel.ForeColor = Color.Red;
                VelocityLabel.Text = "Velocity: not injected";
                return;
            }
            else
            {
                var robloxid = roblox.Id;
                try
                {
                    if (Velocity.IsAttached(robloxid))
                    {
                        VelocityLabel.ForeColor = Color.Green;
                        VelocityLabel.Text = "Velocity: injected";
                    }
                    else
                    {
                        VelocityLabel.ForeColor = Color.Red;
                        VelocityLabel.Text = "Velocity: not injected";
                    }

                }
                catch { }
            }
        }
        private async Task SaveTextAsLua()
        {
            try
            {

                string jsResult = await webView21.CoreWebView2.ExecuteScriptAsync("window.celestiaEditor && window.celestiaEditor.editor && window.celestiaEditor.editor.getValue();");


                if (jsResult.Length >= 2 && jsResult[0] == '"' && jsResult[jsResult.Length - 1] == '"')
                {
                    jsResult = jsResult.Substring(1, jsResult.Length - 2);
                }

                string editorContent = jsResult
                    .Replace("\\n", "\n")
                    .Replace("\\r", "\r")
                    .Replace("\\t", "\t")
                    .Replace("\\\"", "\"")
                    .Replace("\\\\", "\\");

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Lua Files (*.lua)|*.lua|Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                    sfd.Title = "Save Script File";
                    sfd.FileName = "Script.lua";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(sfd.FileName, editorContent);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadTextFromFile()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "All Files (*.*)|*.*|Lua Files (*.lua)|*.lua|Text Files (*.txt)|*.txt";
                ofd.Title = "Open Script File";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string fileContent = File.ReadAllText(ofd.FileName);

                        string escapedContent = fileContent
                            .Replace("\\", "\\\\")
                            .Replace("\"", "\\\"")
                            .Replace("\r", "")
                            .Replace("\n", "\\n");

                        if (webView21.CoreWebView2 != null)
                        {

                            await webView21.CoreWebView2.ExecuteScriptAsync($"window.celestiaEditor && window.celestiaEditor.setText && window.celestiaEditor.setText(\"{escapedContent}\");");
                        }
                        else
                        {
                            MessageBox.Show("Editor is not ready yet.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to load file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private async void Startup()
        {

            await webView21.EnsureCoreWebView2Async(null);
            webView21.CoreWebView2.Navigate(System.Windows.Forms.Application.StartupPath + "\\bin\\MonacoWithTabs\\monaco.html");

    try
            {
                string Exe = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string dir = Path.GetDirectoryName(Exe);
                var files = Directory.GetFiles(dir);
                string Executorn = Path.GetFileName(Exe);
                foreach (string file in files)
                {
                    string filename = Path.GetFileName(file);
                    if (filename.Equals(Executorn, StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }
                    else if (filename.Equals("settings.txt"))
                        continue;
                    try
                    {
                        File.SetAttributes(file, File.GetAttributes(file) | FileAttributes.Hidden);
                    }
                    catch { MessageBox.Show("Error on File configuration"); }
                }
            }
            catch { MessageBox.Show("Error on fetching files"); }
        }


        private void Minimize()
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void Exit()
        {
            System.Windows.Forms.Application.Exit();
        }
        public enum LogType
        {
            INFO,
            ERROR,
            Warning,
            Success
        }

        public static class ConsoleLogger
        {
            public static Color GetLogColor(LogType type)
            {
                if (type == LogType.INFO)
                    return Color.White;
                if (type == LogType.ERROR)
                    return Color.White;
                if (type == LogType.Warning)
                    return Color.Yellow;
                if (type == LogType.Success)
                    return Color.Green;

                return Color.White;
            }
        }

        private void LogToConsole(string message, LogType type)
        {
            string timestamp = DateTime.Now.ToString("HH:mm");
            Color logColor = ConsoleLogger.GetLogColor(type);

            consoleBox.SelectionStart = consoleBox.TextLength;
            consoleBox.SelectionLength = 0;


            consoleBox.SelectionColor = logColor;
            consoleBox.AppendText($"[ {type} ]");


            consoleBox.SelectionColor = Color.White;
            consoleBox.AppendText($" [{timestamp}] ");


            consoleBox.SelectionColor = logColor;
            consoleBox.AppendText($"{message}\n");

            consoleBox.ScrollToCaret();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Minimize();
        }

        private void VelocityLabel_Click(object sender, EventArgs e)
        {

        }

        private void RobloxLabel_Click(object sender, EventArgs e)
        {

        }

        private async void guna2Button2_Click(object sender, EventArgs e)
        {
            await ExecuteScriptAsync();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Attachwithapi();
        }

        private async void guna2Button5_Click(object sender, EventArgs e)
        {
            await CleaWhiteitor();
        }

        private async void guna2Button4_Click(object sender, EventArgs e)
        {
            await LoadTextFromFile();
        }

        private async void guna2Button3_Click(object sender, EventArgs e)
        {
            await SaveTextAsLua();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            rbxcheck();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            xenocheck();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            nezurcheck();   
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            VelocityCheck();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Startup();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(800, 450);
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void guna2Button7_Click_1(object sender, EventArgs e)
        {
            Minimize();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            Settings Mainfr = new Settings();
            Mainfr.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
