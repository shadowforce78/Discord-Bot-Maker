using System;
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
                if (flatTextBox1.Text == "" || flatTextBox2.Text == "" || flatTextBox3.Text == "" || flatTextBox1.Text == "Bot Token" || flatTextBox2.Text == "Bot ID" || flatTextBox3.Text == "Dev ID")
                {
                    MessageBox.Show("You have not filled in all the textboxes!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (flatTextBox1.Text != "" || flatTextBox2.Text != "" || flatTextBox3.Text != "")
                {
                    // create the bot
                    MessageBox.Show("Bot created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // open the folder
                    System.Diagnostics.Process.Start(flatLabel2.Text);
                }
            
            }
        }
    }
}
