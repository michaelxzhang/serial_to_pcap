/************************************
This file convert serial communication traffic into Wireshark pcapng.
Written by: Michael Zhang   michaelxmail[AT]gmail.com

Input file format:
12:34:56.789   Rx
05 64 77 88 99 AA BB CC 
12:34:56.790   Tx
05 64 77 88 99 AA BB CC

or
[12:34:56.789]   Rx
05 64 77 88 99 AA BB CC 
[12:34:56.790]   Tx
05 64 77 88 99 AA BB CC

timestamp line with Rx or Tx
data line

If line has spaces at begining of the line, this tool will trim them.
 
************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ser2pcap
{
    public partial class FormSer2pcap : Form
    {
        bool IsHex(char c)
        {
            return "0123456789ABCDEFabcdef".IndexOf(c) != -1;
        }

        public FormSer2pcap()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog SerialFileDialog = new OpenFileDialog();
            SerialFileDialog.Title = "Select Serial traffic file";
            SerialFileDialog.Filter = "TXT files|*.txt";
            SerialFileDialog.InitialDirectory = @"C:\";
            if (SerialFileDialog.ShowDialog() == DialogResult.OK)
            {
                toolStripStatusLabel1.Text = SerialFileDialog.FileName;

                string filename = SerialFileDialog.FileName;
                string filepath = Path.GetDirectoryName(filename);
                string newfilename = filepath+"\\"+Path.GetFileNameWithoutExtension(filename)+"_n.txt";
                string pcapname = filepath + "\\" + Path.GetFileNameWithoutExtension(filename) + ".pcapng";
                string[] filelines = File.ReadAllLines(filename);
                int datacnt_pre= 0;
                int datacnt = 0;

                for (int cnt = 0; cnt < filelines.Length; cnt++)
                {
                    string tmpline = filelines[cnt].Trim();
                    tmpline = tmpline.Trim('[');
                    
                    char char1 = 'x';
                    char char2 = 'x';
                    char char3 = 'x';

                    if (tmpline.Length == 2)
                    {
                        char1 = tmpline[0];
                        char2 = tmpline[1];

                        //this line only has one data
                        if((IsHex(char1) == true) & (IsHex(char2)==true))
                        {
                            tmpline = datacnt.ToString("X4") + " " + tmpline;
                        }
                        datacnt = datacnt + 1;
                    }
                    else if(tmpline.Length > 2)
                    {
                        char1 = tmpline[0];
                        char2 = tmpline[1];
                        char3 = tmpline[2];

                        //timestamp line 12:34:56.789   
                        if ((IsHex(char1) == true) & (IsHex(char2) == true) & (char3 == ':'))
                        {
                            datacnt = 0;
                            if (tmpline.IndexOf("Rx") >= 0)      //has Rx in this line?
                                tmpline = "I " + tmpline;
                            else if (tmpline.IndexOf("Tx") >= 0)  //has Tx in this line?
                                tmpline = "O " + tmpline;
                        }
                        //data line
                        else if((IsHex(char1) == true) & (IsHex(char2) == true) & (char3 == ' '))
                        {
                            //count the data
                            string[] splitLines = tmpline.Split(' ');
                            datacnt_pre = datacnt;

                            foreach(string dstr in splitLines)
                            {
                                if (dstr.Length == 2)
                                    datacnt++;
                            }

                            tmpline = datacnt_pre.ToString("X4") + " " + tmpline;
                            //then add offset at begining
                        }
                        else
                        {
                            tmpline = '#' + tmpline;
                        }
                            //MessageBox.Show(tmpline + ";" + Convert.ToString(tmpline.Length) + ";" + char1 + char2 + char3);
                    }
                    else    //empty line
                    {
                        tmpline = '#' + tmpline;
                    }
                    filelines[cnt] = tmpline;
                }
                File.WriteAllLines(newfilename, filelines);

                //call wireshark text2pcap to convert the txt file
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = false;
                startInfo.FileName = "C:\\Program Files\\Wireshark\\text2pcap.exe";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                //add " around new file name, in case file name has space and will cause text2pcap execute wrong
                startInfo.Arguments = "-D -T 1111,22403 -t %H:%M:%S. "+"\""+newfilename + "\"" + " "+ "\""+pcapname + "\"";

                try
                {
                    // Start the process with the info we specified.
                    // Call WaitForExit and then the using statement will close.
                    using (Process exeProcess = Process.Start(startInfo))
                    {
                        exeProcess.WaitForExit();
                    }
                }
                catch
                {
                    // Log error.
                }
            }
        }
    }
}
