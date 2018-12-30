using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsWCF_TournamentGenerator.ServiceReference1;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace WinFormsWCF_TournamentGenerator
{
    public partial class FormGenerate : Form
    {

        List<Player> playersTournament = new List<Player>();

        #region ON LOAD
        public FormGenerate()
        {
            InitializeComponent();
        }

        private void FormGenerate_Load(object sender, EventArgs e)
        {

            buttonGenerate.Enabled = false;

            //Generate the check list
            Service1Client serviceClient = new Service1Client();

            playersTournament = serviceClient.GetAllPlayers().OfType<Player>().ToList();

            foreach(Player p in playersTournament)
            {
                checkedListBoxPlayers.Items.Add(" " + p.FirstName + " " + p.LastName);
            }               
            
        }

        #endregion

        #region BUTTONS
        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            Service1Client serviceClient = new Service1Client();
            
            List<Player> playersGeneratingTournament = new List<Player>();

            foreach(var i in checkedListBoxPlayers.CheckedItems)
            {
                playersGeneratingTournament.Add(playersTournament.ElementAt<Player>(checkedListBoxPlayers.CheckedItems.IndexOf(i)));
            }

            //GENERATE TOURNAMENT
            string directory = @"C:\Tournament";
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            Tournament Test3RoundTournament = new Tournament(playersGeneratingTournament);                                                       
            File.WriteAllText(@"C:\Tournament\results.html", HTMLResults.GenerateHTMLResultsTable(Test3RoundTournament));
            openFile(@"C:\Tournament\results.html");
        }
        

        #endregion

        #region VALIDATION
                    
        private void checkedListBoxPlayers_MouseMove(object sender, MouseEventArgs e)
        {
            int checkedNumber = checkedListBoxPlayers.CheckedItems.Count;
            if (checkedNumber == 4 || checkedNumber == 8 || checkedNumber == 16)
                buttonGenerate.Enabled = true;
            else
                buttonGenerate.Enabled = false;
        }

        #endregion

        private void openFile(string pathToFile)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo(); 
            startInfo.FileName = pathToFile; 
            process.StartInfo = startInfo;
            process.Start();
        }  
        
    }
}
