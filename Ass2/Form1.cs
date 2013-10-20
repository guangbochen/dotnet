using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ass2
{
    public partial class Ass2Form : Form
    {
        public Ass2Form()
        {
            InitializeComponent();
        }

        private void Ass2Form_Load(object sender, EventArgs e)
        {
            //set status for the ouput textbox
            txtOutput.ReadOnly = true;
            txtOutput.BackColor = Color.White;
        }

        private void btnFleet1_Click(object sender, EventArgs e)
        {
            // create an instance of the open file dialog box.
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            DialogResult result = openFileDialog.ShowDialog();

            // process open file dialog box results 
            if (result == DialogResult.OK)
            {
                txtFleet1.Text = openFileDialog.FileName;
            }
        }

        private void btnFleet2_Click(object sender, EventArgs e)
        {
            // create an instance of the open file dialog box.
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            DialogResult result = openFileDialog.ShowDialog();

            // Process open file dialog box results 
            if (result == DialogResult.OK)
            {
                txtFleet2.Text = openFileDialog.FileName;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //erase the output textbox
            txtOutput.Text = "";

            string file1 = txtFleet1.Text;
            string file2 = txtFleet2.Text;
            try
            {
                //load fleet from files
                if(file1.Equals("")) throw new Exception("No file entered for fleet 1");
                Fleet fleet1 = new Fleet(file1);

                if(file2.Equals("")) throw new Exception("No file entered for fleet 2");
                Fleet fleet2 = new Fleet(file2);

                //get random number generator
                Random rand = validateSeed();

                //start battle after loading files successfully
                Battle battle = new Battle(fleet1, fleet2, rand, this);

            }
            catch (Exception ex)
            {
                string errorMessage = "Program failed with the following error\n" + ex.Message;
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private Random validateSeed()
        {
            Random rand = null;
            string seedStr = txtSeed.Text;
            int seed = -1;
            if (seedStr.Equals(""))
            {
                throw new Exception("No seed value entered");
            }
            else if(!Int32.TryParse(seedStr, out seed) || seed < 0)
            {
                throw new Exception("Invalid seed value entered");
            }
            rand = new Random(seed);
            return rand;
        }

        public void addTextToResult(string text)
        {
            txtOutput.AppendText(text + "\r\n");
        }

        private void txtOutput_TextChanged(object sender, EventArgs e) 
        { 
            txtOutput.SelectionStart = txtOutput.Text.Length;
            txtOutput.ScrollToCaret();
        }

        private void txtFleet1_TextChanged(object sender, EventArgs e) { } 

        private void txtFleet2_TextChanged(object sender, EventArgs e) { }

        private void txtSeed_TextChanged(object sender, EventArgs e) { }

    }
}
