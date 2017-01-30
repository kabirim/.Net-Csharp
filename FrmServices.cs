//M.kabiri
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.ServiceProcess;
using System.IO;

namespace GodMode
{
    public partial class FrmServices : Form
    {
       
        public void init_services(){
            try
            {
                ServiceController[] scServices;
                scServices = ServiceController.GetServices();

                foreach (ServiceController scTemp in scServices)
                {
                    if (scTemp.ServiceName.ToString() == "wuauserv" && scTemp.ServiceName == "wuauserv")
                    {

                        if (scTemp.Status.ToString() == "Running")
                        {
                            lblUpdate.Text = "Enable";
                        }
                        else if (scTemp.Status.ToString() == "Stopped")
                            lblUpdate.Text = "Disable";

                    }


                    else if (scTemp.ServiceName.ToString() == "WinDefend" && scTemp.ServiceName == "WinDefend")
                    {

                        if (scTemp.Status.ToString() == "Running")
                        {
                            lblwindef.Text = "Enable";
                        }
                        else if (scTemp.Status.ToString() == "Stopped")
                            lblwindef.Text = "Disable";

                    }

                    else if (scTemp.ServiceName.ToString() == "MpsSvc" && scTemp.ServiceName == "MpsSvc")
                    {
                      
                        if (scTemp.Status.ToString() == "Running")
                        {
                            
                            lblFireWall.Text = "Enable";
                        }
                        else if (scTemp.Status.ToString() == "Stopped")
                        {
                            lblFireWall.Text = "Disable";
                        }
                    }

                   
                    else if (scTemp.ServiceName.ToString() == "vmickvpexchange" && scTemp.ServiceName == "vmickvpexchange")
                    {

                        if (scTemp.Status.ToString() == "Running")
                        {
                            lblHyperV.Text = "Enable";
                        }
                        else if (scTemp.Status.ToString() == "Stopped"){
                            lblHyperV.Text = "Disable";
                        }
                           
                        else
                        {
                            lblHyperV.Text = scTemp.Status.ToString();
                        }
                    }


                    else if (scTemp.ServiceName.ToString() == "wscsvc" && scTemp.ServiceName == "wscsvc")
                    {

                        if (scTemp.Status.ToString() == "Running")
                        {
                            lblcentresecu.Text = "Enable";
                        }
                        else if (scTemp.Status.ToString() == "Stopped")
                            lblcentresecu.Text = "Disable";
                    }

                    else if (scTemp.ServiceName.ToString() == "IISADMIN" && scTemp.ServiceName == "IISADMIN")
                    {
                       
                        if (scTemp.Status.ToString() == "Running")
                        {
                            lblIIS.Text = "Enable";
                        }
                        else if (scTemp.Status.ToString() == "Stopped")
                        {
                            lblIIS.Text = "Disable";
                        }
                        else
                        {
                            lblIIS.Text = scTemp.Status.ToString();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Warinng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public FrmServices()
        {
            
            InitializeComponent();
            
           
        }

        private void FrmServices_Load(object sender, EventArgs e)
        {
            init_services();
        }

              
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Start windows defender
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            System.Diagnostics.ProcessStartInfo ProcessInfo;
            System.Diagnostics.Process Process;

            ProcessInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/K " + @" sc start WinDefend");
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = true;
            ProcessInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process = System.Diagnostics.Process.Start(ProcessInfo);
            lblwindef.Text = "Enable";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + "Error");
            }
        }
        /// <summary>
        /// stop windows defender
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo ProcessInfo;
                System.Diagnostics.Process Process;

                ProcessInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/K " + @" sc stop WinDefend");
                ProcessInfo.CreateNoWindow = true;
                ProcessInfo.UseShellExecute = true;
                ProcessInfo.WindowStyle = ProcessWindowStyle.Hidden;
            
                Process = System.Diagnostics.Process.Start(ProcessInfo);
                lblwindef.Text = "Disable";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + "Error");
            }
            
        }
        /// <summary>
        /// disable hyper v
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo ProcessInfo;
                System.Diagnostics.Process Process;

                ProcessInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/K " + @" dism.exe /Online /Disable-Feature:Microsoft-Hyper-V-All");
                ProcessInfo.CreateNoWindow = true;
                ProcessInfo.UseShellExecute = true;
                ProcessInfo.WindowStyle = ProcessWindowStyle.Hidden;
            
                Process = System.Diagnostics.Process.Start(ProcessInfo);
                lblHyperV.Text = "Disable";
            }
            catch (Exception ex)
            {
                MessageBox.Show("The service is not installed on your computer " );
            }
        }
        /// <summary>
        /// enable hyper v
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo ProcessInfo;
                System.Diagnostics.Process Process;

                ProcessInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/K " + @" dism.exe /Online /Enable-Feature:Microsoft-Hyper-V /All");
                ProcessInfo.CreateNoWindow = true;
                ProcessInfo.UseShellExecute = true;
                ProcessInfo.WindowStyle = ProcessWindowStyle.Hidden;
            
                Process = System.Diagnostics.Process.Start(ProcessInfo);
                lblHyperV.Text = "Enable";
            }
            catch (Exception ex)
            {
                MessageBox.Show("The service is not installed on your computer ");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Firewall button enable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnfireenable_Click(object sender, EventArgs e)
        {
            try
            {
                Process proc = new Process();
                string top = "netsh.exe";
                proc.StartInfo.Arguments = "Firewall set opmode enable";
                proc.StartInfo.FileName = top;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();
                proc.WaitForExit();
                lblFireWall.Text = "Enable";
                init_services();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()+"Error");
            }

            lblFireWall.Text = "Enable";
        }
        /// <summary>
        /// Firewall button disable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnfiredisable_Click(object sender, EventArgs e)
        {
            try
            {
                Process proc = new Process();
                string top = "netsh.exe";
                proc.StartInfo.Arguments = "Firewall set opmode disable";
                proc.StartInfo.FileName = top;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();
                proc.WaitForExit();
                lblFireWall.Text = "Disable";
                init_services();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()+"Error");
            }

            lblFireWall.Text = "Disable";
        }
        /// <summary>
        /// Windows Security Service enable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btncsactiv_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceController myservice = new ServiceController();
                myservice.ServiceName = "wscsvc";
                if (myservice.Status.ToString() == "Running")
                {

                }
                else if (myservice.Status.ToString() == "Stopped")
                {

                    myservice.Start();
                    lblcentresecu.Text = "Enable";
                    init_services();
                }
              
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + "Error");
            }

        }
        /// <summary>
        /// Windows Update enable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnwupactiv_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceController myservice = new ServiceController();
                myservice.ServiceName = "wuauserv";
                if (myservice.Status.ToString() == "Running")
                {

                }
                else if ( myservice.Status.ToString() == "Stopped")
                {
                   
                    myservice.Start();
                    lblUpdate.Text = "Enable";
                    init_services();

                }

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + "Error");
            }
        }
        /// <summary>
        /// Windows update service disable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnwupdis_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceController myservice = new ServiceController();
                myservice.ServiceName = "wuauserv";
                if (myservice.Status.ToString() == "Running")
                {
                    myservice.Stop();

                    lblUpdate.Text = "Disable";
                    init_services();
                    FrmServices.ActiveForm.ResetText();
                   
                    
                }
                else if (myservice.Status.ToString() == "Stopped")
                {

                   
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + "Error");
            }
        }
        /// <summary>
        /// Windows Security Center Disable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btncsdis_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceController myservice = new ServiceController();
                myservice.ServiceName = "wscsvc";
                if (myservice.Status.ToString() == "Running")
                {
                    myservice.Stop();
                    lblcentresecu.Text = "Disable";
                    init_services();
                }
                else if (myservice.Status.ToString() == "Stopped")
                {

                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + "Error");
            }
        }

        private void btnIISactiv_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceController myservice = new ServiceController();
                myservice.ServiceName = "IISADMIN";
                
                if (myservice.Status.ToString() == "Running")
                {
                    
                }
                else if (myservice.Status.ToString() == "Stopped")
                {
                    myservice.Start();
                    lblIIS.Text = "Enable";
                    init_services();

                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("The service is not installed on your computer ");
            }
        }

        private void btnIISdis_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceController myservice = new ServiceController();
                myservice.ServiceName = "IISADMIN";
                if (myservice.Status.ToString() == "Running")
                {
                    myservice.Stop();
                    lblIIS.Text = "Disable";
                    init_services();
                }
                else if (myservice.Status.ToString() == "Stopped")
                {
                    

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The service is not installed on your computer ");
            }
        }
       
       
    }
}
