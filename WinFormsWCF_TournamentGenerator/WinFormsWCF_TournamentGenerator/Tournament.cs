using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsWCF_TournamentGenerator.ServiceReference1;

namespace WinFormsWCF_TournamentGenerator
{
    public class Tournament
    {
        public SortedList<int, SortedList<int, Match>> TournamentRoundMatches { get; private set; }
        public Match ThirdPlaceMatch { get; private set; }

        public List<Player> playersTournamentGenerating;
        public List<Player> playersTournamentRandomize;

        public Tournament(List<Player> playerList)
        {
            this.playersTournamentGenerating = playerList;
            this.playersTournamentRandomize = playerList;
            playersTournamentRandomize.Shuffle();

            int rounds = 4;
            switch (playerList.Count)
            {
                case 4:
                    rounds = 2;
                    break;
                case 8:
                    rounds = 3;
                    break;
                case 16:
                    rounds = 4;
                    break;
            }
            this.TournamentRoundMatches = new SortedList<int, SortedList<int, Match>>();
            this.GenerateTournamentResults(rounds);
            if (rounds > 1)
            {
                this.GenerateThirdPlaceResult(rounds);
            }
        }

        public void AddMatch(Match m)
        {
            if (this.TournamentRoundMatches.ContainsKey(m.roundnumber))
            {
                if (!this.TournamentRoundMatches[m.roundnumber].ContainsKey(m.id))
                {
                    this.TournamentRoundMatches[m.roundnumber].Add(m.id, m);
                }
            }
            else
            {
                this.TournamentRoundMatches.Add(m.roundnumber, new SortedList<int, Match>());
                this.TournamentRoundMatches[m.roundnumber].Add(m.id, m);
            }
        }

        private void GenerateTournamentResults(int rounds)
        {
            Random WinnerRandomizer = new Random();

            for (int round = 1, match_id = 1; round <= rounds; round++)
            {
                int matches_in_round = 1 << (rounds - round);
                for (int round_match = 1; round_match <= matches_in_round; round_match++, match_id++)
                {
                    int team1_id;
                    int team2_id;
                    int winner;
                    if (round == 1)
                    {
                        team1_id = (match_id * 2) - 1;
                        team2_id = (match_id * 2);
                    }
                    else
                    {
                        int match1 = (match_id - (matches_in_round * 2) + (round_match - 1));
                        int match2 = match1 + 1;
                        team1_id = this.TournamentRoundMatches[round - 1][match1].winner;
                        team2_id = this.TournamentRoundMatches[round - 1][match2].winner;
                    }
                    winner = (WinnerRandomizer.Next(1, 3) == 1) ? team1_id : team2_id;
                    this.AddMatch(new Match(match_id, team1_id, team2_id, round, winner));
                }
            }
        }

        private void GenerateThirdPlaceResult(int rounds)
        {
            Random WinnerRandomizer = new Random();
            int semifinal_matchid1 = this.TournamentRoundMatches[rounds - 1].Keys.ElementAt(0);
            int semifinal_matchid2 = this.TournamentRoundMatches[rounds - 1].Keys.ElementAt(1);
            Match semifinal_1 = this.TournamentRoundMatches[rounds - 1][semifinal_matchid1];
            Match semifinal_2 = this.TournamentRoundMatches[rounds - 1][semifinal_matchid2];
            int semifinal_loser1 = (semifinal_1.winner == semifinal_1.teamid1) ? semifinal_1.teamid2 : semifinal_1.teamid1;
            int semifinal_loser2 = (semifinal_2.winner == semifinal_2.teamid1) ? semifinal_2.teamid2 : semifinal_2.teamid1;
            int third_place_winner = (WinnerRandomizer.Next(1, 3) == 1) ? semifinal_loser1 : semifinal_loser2;
            this.ThirdPlaceMatch = new Match((1 << rounds) + 1, semifinal_loser1, semifinal_loser2, 1, third_place_winner);
        }

    }
}
