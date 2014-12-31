﻿using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;

namespace RobloxToSourceEngine
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            string version = "1.10";
            WebClient http = new WebClient();
            FileHandler FileHandler = new FileHandler();
            NameValueCollection settings = FileHandler.GetAppSettings();
            try
            {
                // Best way to test for an internet connection is to see if you can get a response from Google.
                string response = http.DownloadString("http://www.google.com");
            }
            catch
            {
                MessageBox.Show("Unable to connect to the internet.\nPlease check your connection and try again.", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            string currentVersion = settings["latestVersion"];
            if (version != currentVersion)
            {
                DialogResult result = MessageBox.Show("This version is outdated!\n(Running on Version " + version + ", should be on Version " + currentVersion + ") \n\nPlease head over to \nhttp://clonetrooper1019.weebly.com/rbx2source.html\nand get the latest version!\n(Would you like to go there now?)", "FATAL ERROR", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    Process.Start("http://clonetrooper1019.weebly.com/rbx2source.html");
                }
                Application.Exit();
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Rbx());
            }
        }
    }
}