using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roblox_Lua_Executor
{
    public partial class Settings : Form
    {
        private const string SettingsFile = "settings.txt";
        public Settings()
        {
            InitializeComponent();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch1.Checked)
            {

                bool Nezuruse = true;
                bool Xenouse = false;
                bool Veloc = false;
                string content = $"Xeno = {Xenouse}, Nezur = {Nezuruse}, Velocity = {Veloc} ";
                File.WriteAllText(SettingsFile, content);
                guna2ToggleSwitch2.Checked = false;
                guna2ToggleSwitch3.Checked = false;
            }
        }

        private void guna2ToggleSwitch2_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch2.Checked)
            {

                bool Nezuruse = false;
                bool Xenouse = true;
                bool Veloc = false;
                string content = $"Xeno = {Xenouse}, Nezur = {Nezuruse}, Velocity = {Veloc}";
                File.WriteAllText(SettingsFile, content);
                guna2ToggleSwitch3.Checked = false;
                guna2ToggleSwitch1.Checked = false;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2ToggleSwitch3_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch3.Checked)
            {

                bool Nezuruse = false;
                bool Xenouse = false;
                bool Veloc = true;
                string content = $"Xeno = {Xenouse}, Nezur = {Nezuruse}, Velocity = {Veloc}";
                File.WriteAllText(SettingsFile, content);
                guna2ToggleSwitch2.Checked = false;
                guna2ToggleSwitch1.Checked = false;
            }
        }
    }
}
