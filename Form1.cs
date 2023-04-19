using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Discord_Bot_Maker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        { }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void flatTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void flatTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void flatTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void flatButton2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                flatLabel2.Text = FBD.SelectedPath;
            }



        }

        private void gitClone()
        {

            // copy git folder into the selected folder https://github.com/shadowforce78/djs-base-handler.git
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "git",
                    Arguments = "clone https://github.com/shadowforce78/djs-base-handler.git",
                    WorkingDirectory = flatLabel2.Text,
                    UseShellExecute = false,
                }
            };
            process.Start();

            // when the process is done, then show the messagebox
            process.WaitForExit();
            MessageBox.Show("The bot was succesfully cloned!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void flatLabel2_Click(object sender, EventArgs e)
        {
            // if text is not equal to NONE, then open the folder
            if (flatLabel2.Text != "NONE")
            {
                System.Diagnostics.Process.Start(flatLabel2.Text);
            }
            // if mouse is over the label, then show the path
            else if (flatLabel2.Text == "NONE")
            {
                MessageBox.Show("You have not selected a folder yet!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void flatButton1_Click(object sender, EventArgs e)
        {
            // if label is not equal to NONE, then create the bot
            if (flatLabel2.Text == "NONE")
            {
                MessageBox.Show("You have not selected a folder yet!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (flatLabel2.Text != "NONE")
            {
                // if textboxes are not empty, then create the bot
                if (flatTextBox1.Text == "" || flatTextBox2.Text == "" || flatTextBox3.Text == "" || flatTextBox4.Text == "" || flatTextBox6.Text == "" || flatTextBox1.Text == "Bot Token" || flatTextBox2.Text == "Bot ID" || flatTextBox3.Text == "Dev ID" || flatTextBox4.Text == "Bot Name" || flatTextBox5.Text == "MongoDB link" || flatTextBox6.Text == "Default Prefix")
                {
                    MessageBox.Show("You have not filled all informations!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                }

                else if (flatTextBox1.Text != "" || flatTextBox2.Text != "" || flatTextBox3.Text != "")
                {
                    // create the bot
                    MessageBox.Show("Bot created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //clone bot
                    gitClone();
                    // edit the config.json file using the function
                    if (flatTextBox5.Text == "" || flatTextBox5.Text == "MongoDB link (Optional)")
                    {
                        string MongoStat = "";
                    EditConfig(flatLabel2.Text + "\\djs-base-handler\\config.json", MongoStat);
                    }
                    else if (flatTextBox5.Text != "" || flatTextBox5.Text != "MongoDB link (Optional)")
                    {
                        string MongoStat = flatTextBox5.Text;
                        EditConfig(flatLabel2.Text + "\\djs-base-handler\\config.json", MongoStat);
                    }
                    // rename folder
                    Directory.Move(flatLabel2.Text + "\\djs-base-handler", flatLabel2.Text + "\\" + flatTextBox4.Text + "-Bot");
                    // open the folder
                    System.Diagnostics.Process.Start(flatLabel2.Text + "\\" + flatTextBox4.Text + "-Bot");
                    // message box to give user the command to install the packages
                    MessageBox.Show("To install the packages, open the folder and run the command 'npm install' in the terminal!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }


        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void flatTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        // function to edit config.json file in the bot folder
        public void EditConfig(string BotPath, string MongoStat)
        {
            // read the config.json file
            string config = File.ReadAllText(BotPath);
            // replace the token
            config = config.Replace("TOKEN_HERE", flatTextBox1.Text);
            // replace the bot id
            config = config.Replace("BOTID_HERE", flatTextBox2.Text);
            // replace the dev id
            config = config.Replace("DEVID_HERE", flatTextBox3.Text);
            // replace the bot name
            config = config.Replace("BOTNAME_HERE", flatTextBox4.Text);
            // replace the mongodb link
            config = config.Replace("MONGODB_HERE", MongoStat);
            // replace the default prefix
            config = config.Replace("PREFIX_HERE", flatTextBox6.Text);
            // write the config.json file with the new informations
            File.WriteAllText(BotPath, config);
        }

        private void flatTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void flatTextBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
