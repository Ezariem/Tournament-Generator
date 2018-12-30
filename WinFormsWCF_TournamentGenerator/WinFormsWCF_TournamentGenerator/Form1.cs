using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFormsWCF_TournamentGenerator.ServiceReference1;
using System.Linq;

namespace WinFormsWCF_TournamentGenerator
{
    public partial class Form1 : Form
    {
        public static DataGridView dataGridViewForm1;

        public static List<Player> playerList;
        public static Player currentSelectedPlayer;
        bool updateDeleteEnable;

        #region ON LOAD

        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridViewForm1 = new DataGridView();
            dataGridViewForm1 = dataGridViewPlayers;

            updateDeleteEnable = false;   

            buttonCreatePlayer.Enabled = false;
            buttonDelete.Enabled = false;
            buttonUpdate.Enabled = false;

            playerList = new List<Player>();
            currentSelectedPlayer = new Player();
            Service1Client serviceClient = new Service1Client();

            playerList = serviceClient.GetAllPlayers().OfType<Player>().ToList();

            
            dataGridViewPlayers.DataSource = serviceClient.GetAllPlayers();

            ReorderColumns();

        }

        #endregion

        #region BUTTON EVENTS
        private void buttonCreatePlayer_Click(object sender, EventArgs e)
        {
            Player player = new Player();
            player.FirstName = textBoxFirstName.Text;
            player.LastName = textBoxLastName.Text;
            player.Age = Convert.ToInt32(numericUpDownAge.Value);
            player.Speed = Convert.ToInt32(numericUpDownSpeed.Value);
            player.Strength = Convert.ToInt32(numericUpDownStrength.Value);
            player.Skill = Convert.ToInt32(numericUpDownSkill.Value);

            Service1Client serviceClient = new Service1Client();

            if (serviceClient.CreatePlayer(player) == 1)
            {             
                playerList.Add(player);
                dataGridViewPlayers.DataSource = serviceClient.GetAllPlayers();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Player player = currentSelectedPlayer;

            Service1Client serviceClient = new Service1Client();

            if (serviceClient.DeletePlayer(player) == 1)
            {
                playerList.Remove(player);
                dataGridViewPlayers.DataSource = serviceClient.GetAllPlayers();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            FormUpdate formUpdate = new FormUpdate();
            formUpdate.Show();

        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            FormGenerate formGenerate = new FormGenerate();
            formGenerate.Show();
        }

        #endregion

        #region SOME VALIDATION
        //Allow validation
        private void dataGridViewPlayers_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            updateDeleteEnable = true;
            buttonDelete.Enabled = updateDeleteEnable;
            buttonUpdate.Enabled = updateDeleteEnable;
        }

        private void textBoxFirstName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxLastName.Text != "" && textBoxFirstName.Text != "")
                buttonCreatePlayer.Enabled = true;
            else
                buttonCreatePlayer.Enabled = false;
            
        }

        private void textBoxLastName_TextChanged(object sender, EventArgs e)
        {                 
            if (textBoxLastName.Text != "" && textBoxFirstName.Text != "")
                buttonCreatePlayer.Enabled = true;
            else
                buttonCreatePlayer.Enabled = false;
        }

        #endregion

        #region OPERATION ON DATA GRID VIEW
        private void dataGridViewPlayers_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewPlayers.SelectedRows)
            {   
                currentSelectedPlayer.Age = Convert.ToInt32(row.Cells[0].Value);                 // Age
                currentSelectedPlayer.FirstName = row.Cells[1].Value.ToString();                 // First Name
                currentSelectedPlayer.Id = Convert.ToInt32(row.Cells[2].Value);                  // Id
                currentSelectedPlayer.LastName = row.Cells[3].Value.ToString();                  // Last Name
                currentSelectedPlayer.Skill = Convert.ToInt32(row.Cells[4].Value);               // Skill
                currentSelectedPlayer.Speed = Convert.ToInt32(row.Cells[5].Value);               // Speed
                currentSelectedPlayer.Strength = Convert.ToInt32(row.Cells[6].Value);            // Strength

                /*string message = currentSelectedPlayer.Id.ToString() + "  " + 
                                 currentSelectedPlayer.FirstName + "  " +
                                 currentSelectedPlayer.LastName + "  " + 
                                 currentSelectedPlayer.Age.ToString() + "  " + 
                                 currentSelectedPlayer.Speed.ToString() + "  " + 
                                 currentSelectedPlayer.Speed.ToString() + "  " + 
                                 currentSelectedPlayer.Strength.ToString();
                MessageBox.Show(message);        */

                if(Convert.ToInt32(row.Cells[2].Value) > 0 && Convert.ToInt32(row.Cells[0].Value) > 0)    // if (Id > 0 && Age > 0)
                {
                    buttonDelete.Enabled = true;
                    buttonUpdate.Enabled = true;
                }
                else
                {
                    buttonDelete.Enabled = false;
                    buttonUpdate.Enabled = false;
                }
                
            }

        }

        private void dataGridViewPlayers_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            buttonUpdate.Enabled = false;
            buttonDelete.Enabled = false;
        }

        private void ReorderColumns()
        {                              
            dataGridViewPlayers.AutoGenerateColumns = false;
            dataGridViewPlayers.Columns["Id"].Width = 50;
            dataGridViewPlayers.Columns["Id"].DisplayIndex = 0;
            dataGridViewPlayers.Columns["FirstName"].DisplayIndex = 1;
            dataGridViewPlayers.Columns["LastName"].DisplayIndex = 2;
            dataGridViewPlayers.Columns["Age"].DisplayIndex = 3;
            dataGridViewPlayers.Columns["Speed"].DisplayIndex = 4;
            dataGridViewPlayers.Columns["Strength"].DisplayIndex = 5;
            dataGridViewPlayers.Columns["Skill"].DisplayIndex = 6;          
        }

        #endregion

    }
}
