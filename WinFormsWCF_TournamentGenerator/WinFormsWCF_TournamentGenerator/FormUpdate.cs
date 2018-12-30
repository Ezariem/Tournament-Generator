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

namespace WinFormsWCF_TournamentGenerator
{
    public partial class FormUpdate : Form
    {
        Player playerToUpdate;

        public FormUpdate()
        {
            InitializeComponent();
        }

        private void FormUpdate_Load(object sender, EventArgs e)
        {
            playerToUpdate = Form1.currentSelectedPlayer;
            textBoxFirstName.Text = playerToUpdate.FirstName;
            textBoxLastName.Text = playerToUpdate.LastName;
            numericUpDownAge.Value = playerToUpdate.Age;
            numericUpDownSkill.Value = playerToUpdate.Skill;
            numericUpDownSpeed.Value = playerToUpdate.Speed;
            numericUpDownStrength.Value = playerToUpdate.Strength;
        }

        private void buttonUpdatePlayer_Click(object sender, EventArgs e)
        {
            Player player = new Player();
            player.Id = playerToUpdate.Id;
            player.FirstName = textBoxFirstName.Text;
            player.LastName = textBoxLastName.Text;
            player.Age = Convert.ToInt32(numericUpDownAge.Value);
            player.Speed = Convert.ToInt32(numericUpDownSpeed.Value);
            player.Strength = Convert.ToInt32(numericUpDownStrength.Value);
            player.Skill = Convert.ToInt32(numericUpDownSkill.Value);

            Service1Client serviceClient = new Service1Client();

            if (serviceClient.UpdatePlayer(player) == 1)
            {
                Form1.playerList.Remove(playerToUpdate);
                Form1.playerList.Add(player);
                Form1.dataGridViewForm1.DataSource = serviceClient.GetAllPlayers();
                this.Close();
            }

        }

        #region VALIDATION

        private void textBoxFirstName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxLastName.Text != "" && textBoxFirstName.Text != "")
                buttonUpdatePlayer.Enabled = true;
            else
                buttonUpdatePlayer.Enabled = false;

        }

        private void textBoxLastName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxLastName.Text != "" && textBoxFirstName.Text != "")
                buttonUpdatePlayer.Enabled = true;
            else
                buttonUpdatePlayer.Enabled = false;
        }

        #endregion
    }
}
