/************************************
This tool convert serial communication traffic into Wireshark pcapng.
Written by: Michael Zhang   michaelxmail[AT]gmail.com

Note: Wireshark need to be installed.

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
This tool will format the traffic file and call text2pcap to convert the formatted file into pcapng file.
 
************************************/
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ser2pcap
{
    public partial class FormSer2pcap : Form
    {
        string filename = "";
        string filepath = "";
        string newfilename = "";
        string pcapname = "";

        bool IsHex(char c)
        {
            return "0123456789ABCDEFabcdef".IndexOf(c) != -1;
        }

        public FormSer2pcap()
        {
            InitializeComponent();
        }

        private void BtnConvert_Click(object sender, EventArgs e)
        {
            
            toolStripStatusLabel1.Text = "Validating selection...";

            if (TextBox_Text2pcap.Text == "")
            {
                MessageBox.Show("Text2pcap.exe not sepcified, please select the location!");
                return;
            }

            if (TextBox_file.Text == "")
            {
                MessageBox.Show("Capture file not specified, please select!");
                return;
            }

            string tmpsel = Combox_Pro_Sel.Text;
            if (tmpsel == "")
            {
                MessageBox.Show("Please choose the protocol before convert!");
                return;
            }

            int portnum = 0;

            bool canConvert = int.TryParse(tmpsel, out portnum);
            if (canConvert == false)
            {
                if (tmpsel.IndexOf('@') >= 0)
                {
                    string[] splitstr = tmpsel.Split('@');
                    bool canConvert2 = int.TryParse(splitstr[1], out portnum);
                    if (canConvert2 == false)
                    {
                        MessageBox.Show("Please select a protocol or enter a valid number!");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please select a protocol or enter a valid number!");
                    return;
                }
            }

            //toolStripStatusLabel1.Text = "Selecting file for convert...";

            string[] filelines = File.ReadAllLines(filename);
            int datacnt_pre = 0;
            int datacnt = 0;

            toolStripStatusLabel1.Text = "Formating file...";

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
                    if ((IsHex(char1) == true) & (IsHex(char2) == true))
                    {
                        tmpline = datacnt.ToString("X4") + " " + tmpline;
                    }
                    datacnt = datacnt + 1;
                }
                else if (tmpline.Length > 2)
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
                    else if ((IsHex(char1) == true) & (IsHex(char2) == true) & (char3 == ' '))
                    {
                        //count the data
                        string[] splitLines = tmpline.Split(' ');
                        datacnt_pre = datacnt;

                        //foreach (string dstr in splitLines)
                        for(int i=0;i<splitLines.Length;i++)
                        {
                            char tch1 = 'x';
                            char tch2 = 'x';

                            if (splitLines[i].Length == 2)
                            {
                                tch1 = splitLines[i][0];
                                tch2 = splitLines[i][1];
                                if ((IsHex(tch1) == true) & (IsHex(tch2) == true))
                                    datacnt++;
                                else
                                    break;
                            }
                            else if (splitLines[i] == "")
                                break;
                            else if (splitLines[i].Length != 2)
                                break;
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

            toolStripStatusLabel1.Text = "Converting to pcapng...";

            //call wireshark text2pcap to convert the txt file
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "C:\\Program Files\\Wireshark\\text2pcap.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //add " around new file name, in case file name has space and will cause text2pcap execute wrong
            startInfo.Arguments = "-D -T 1111," + portnum.ToString() + " -t %H:%M:%S. " + "\"" + newfilename + "\"" + " " + "\"" + pcapname + "\"";

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
            //}   //this one
            toolStripStatusLabel1.Text = "Waiting for selection";
        }

        private void BthAbout_Click(object sender, EventArgs e)
        {
            AboutBox1 a = new AboutBox1();
            a.ShowDialog();
        }
        
        private void Btn_Select_capture_Click(object sender, EventArgs e)
        {
            OpenFileDialog SerialFileDialog = new OpenFileDialog();
            SerialFileDialog.Title = "Select Serial traffic file";
            SerialFileDialog.Filter = "TXT files|*.txt";
            SerialFileDialog.InitialDirectory = @"C:\";
            if (SerialFileDialog.ShowDialog() == DialogResult.OK)
            {
                toolStripStatusLabel1.Text = SerialFileDialog.FileName;

                filename = SerialFileDialog.FileName;
                filepath = Path.GetDirectoryName(filename);
                newfilename = filepath + "\\" + Path.GetFileNameWithoutExtension(filename) + "_n.txt";
                pcapname = filepath + "\\" + Path.GetFileNameWithoutExtension(filename) + ".pcapng";

                TextBox_file.Text = filename;

                Label_select_file.Text = "Capture file selected!";
                Label_select_file.Font = new Font(Label_select_file.Font, FontStyle.Regular);
                Label_arror_select_file.Visible = false;
                
                Label_select_protocol.Font = new Font(Label_select_protocol.Font, FontStyle.Bold);

                Label_arrow_select_protocol.Visible = true;
                Label_arrow_select_protocol.Font = new Font(Label_arrow_select_protocol.Font, FontStyle.Bold);

                Combox_Pro_Sel.Focus();

            }
        }

        private void FormSer2pcap_Load(object sender, EventArgs e)
        {
            if (File.Exists("C:\\Program Files\\Wireshark\\text2pcap.exe") == false)
            {
                MessageBox.Show("Text2pcap.exe not found, please specify the location!");
            }
            else
            {
                Label_text2pcap.Font = new Font(Label_text2pcap.Font, FontStyle.Regular);
                Label_text2pcap.Text = "Text2pcap found!";
                TextBox_Text2pcap.Text = "C:\\Program Files\\Wireshark\\text2pcap.exe";
                Label_arrow_text2pcap.Visible = false;

                Label_select_file.Font = new Font(Label_select_file.Font, FontStyle.Bold);
                Label_select_file.Text = "Select capture file:";

                Label_arror_select_file.Visible = true;
                Label_arror_select_file.Font = new Font(Label_arror_select_file.Font, FontStyle.Bold);

                TextBox_file.Focus();
                TextBox_file.Select();
            }
        }

        private void Btn_Select_text2pcap_Click(object sender, EventArgs e)
        {
            OpenFileDialog Select_text2pcap_Dialog = new OpenFileDialog();
            Select_text2pcap_Dialog.Title = "Select Text2pcap.exe";
            Select_text2pcap_Dialog.Filter = "Exe files|*.exe";
            Select_text2pcap_Dialog.InitialDirectory = @"C:\Program Files\Wireshark\";
            if (Select_text2pcap_Dialog.ShowDialog() == DialogResult.OK)
            {
                toolStripStatusLabel1.Text = Select_text2pcap_Dialog.FileName;

                string exefilename = Path.GetFileName(Select_text2pcap_Dialog.FileName);
                                
                if(exefilename != "text2pcap.exe")
                {
                    MessageBox.Show("Please sepcifiy the location of text2pcap.exe!\nIt's under Wireshark installation folder");
                    return;
                }
                else
                {
                    Label_text2pcap.Font = new Font(Label_text2pcap.Font, FontStyle.Regular);
                    Label_text2pcap.Text = "Text2pcap found!";
                    TextBox_Text2pcap.Text = "C:\\Program Files\\Wireshark\\text2pcap.exe";
                    Label_arrow_text2pcap.Visible = false;

                    Label_select_file.Font = new Font(Label_select_file.Font, FontStyle.Bold);
                    Label_select_file.Text = "Select capture file:";

                    Label_arror_select_file.Visible = true;
                    Label_arror_select_file.Font = new Font(Label_arror_select_file.Font, FontStyle.Bold);

                    TextBox_file.Focus();
                    TextBox_file.Select();
                }

            }
        }
    }
}
