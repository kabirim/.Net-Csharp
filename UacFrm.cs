//M.Kabiri
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace GodMode
{
    public partial class UacFrm : Form
    {
        public UacFrm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Enable Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo ProcessInfo;
                System.Diagnostics.Process Process;

                ProcessInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/K " + @" %windir%\System32\reg.exe ADD HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System /v EnableLUA /t REG_DWORD /d 1 /f");
                ProcessInfo.CreateNoWindow = true;
                ProcessInfo.UseShellExecute = true;
                ProcessInfo.WindowStyle = ProcessWindowStyle.Hidden;

                Process = System.Diagnostics.Process.Start(ProcessInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Service is not accessible, Please try again !");
            }
            
           
        }
        /// <summary>
        /// Disable button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo ProcessInfo;
                System.Diagnostics.Process Process;

                ProcessInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/K " + @" %windir%\System32\reg.exe ADD HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System /v EnableLUA /t REG_DWORD /d 0 /f");
                ProcessInfo.CreateNoWindow = true;
                ProcessInfo.UseShellExecute = true;
                ProcessInfo.WindowStyle = ProcessWindowStyle.Hidden;
                Process = System.Diagnostics.Process.Start(ProcessInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Service is not accessible, Please try again !");
            }
        }
    }
}
