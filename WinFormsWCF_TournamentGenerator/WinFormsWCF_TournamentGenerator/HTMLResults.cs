using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsWCF_TournamentGenerator
{
    public static class HTMLResults
    {
        public static string GenerateHTMLResultsTable(Tournament tournament)
        {
            int match_white_span;
            int match_span;
            int position_in_match_span;
            int column_stagger_offset;
            int effective_row;
            int col_match_num;
            int cumulative_matches;
            int effective_match_id;
            int rounds = tournament.TournamentRoundMatches.Count;
            int teams = 1 << rounds;
            int max_rows = teams << 1;
            StringBuilder HTMLTable = new StringBuilder();

            HTMLTable.AppendLine("<style type=\"text/css\">");
            HTMLTable.AppendLine("    .thd {background: rgb(220,240,250); font: bold 11pt Arial; text-align: center;}");
            HTMLTable.AppendLine("    .team {color: white; background: rgb(100,120,130); font: bold 11pt Arial; border-right: solid 2px black;}");
            HTMLTable.AppendLine("    .winner {color: white; background: rgb(60,80,90); font: bold 11pt Arial;}");
            HTMLTable.AppendLine("    .vs {font: bold 8pt Arial; border-right: solid 2px black;}");
            HTMLTable.AppendLine("    td, th {padding: 3px 15px; border-right: solid 2px rgb(200,220,230); text-align: right;}");
            HTMLTable.AppendLine("    h1 {font: bold 11pt Arial; margin-top: 24pt;}");
            HTMLTable.AppendLine("</style>");

            HTMLTable.AppendLine("<h1>Tournament Results</h1>");
            HTMLTable.AppendLine("<table border=\"0\" cellspacing=\"0\">");
            for (int row = 0; row <= max_rows; row++)
            {
                cumulative_matches = 0;
                HTMLTable.AppendLine("    <tr>");
                for (int col = 1; col <= rounds + 1; col++)
                {
                    match_span = 1 << (col + 1);
                    match_white_span = (1 << col) - 1;
                    column_stagger_offset = match_white_span >> 1;
                    if (row == 0)
                    {
                        if (col <= rounds)
                        {
                            HTMLTable.AppendLine("        <th class=\"thd\">Round " + col + "</th>");
                        }
                        else
                        {
                            HTMLTable.AppendLine("        <th class=\"thd\">Winner</th>");
                        }
                    }
                    else if (row == 1)
                    {
                        HTMLTable.AppendLine("        <td class=\"white_span\" rowspan=\"" + (match_white_span - column_stagger_offset) + "\">&nbsp;</td>");
                    }
                    else
                    {
                        effective_row = row + column_stagger_offset;
                        if (col <= rounds)
                        {
                            position_in_match_span = effective_row % match_span;
                            position_in_match_span = (position_in_match_span == 0) ? match_span : position_in_match_span;
                            col_match_num = (effective_row / match_span) + ((position_in_match_span < match_span) ? 1 : 0);
                            effective_match_id = cumulative_matches + col_match_num;
                            if ((position_in_match_span == 1) && (effective_row % match_span == position_in_match_span))
                            {
                                HTMLTable.AppendLine("        <td class=\"white_span\" rowspan=\"" + match_white_span + "\">&nbsp;</td>");
                            }
                            else if ((position_in_match_span == (match_span >> 1)) && (effective_row % match_span == position_in_match_span))
                            {
                                HTMLTable.AppendLine("        <td class=\"team\">" + 
                                                              tournament.playersTournamentRandomize.ElementAt(tournament.TournamentRoundMatches[col][effective_match_id].teamid1 - 1).FirstName + " " +
                                                              tournament.playersTournamentRandomize.ElementAt(tournament.TournamentRoundMatches[col][effective_match_id].teamid1 - 1).LastName +
                                                              "</td>");
                            }
                            else if ((position_in_match_span == ((match_span >> 1) + 1)) && (effective_row % match_span == position_in_match_span))
                            {
                                HTMLTable.AppendLine("        <td class=\"vs\" rowspan=\"" + match_white_span + "\">VS</td>");
                            }
                            else if ((position_in_match_span == match_span) && (effective_row % match_span == 0))
                            {
                                HTMLTable.AppendLine("        <td class=\"team\">" +
                                                              tournament.playersTournamentRandomize.ElementAt(tournament.TournamentRoundMatches[col][effective_match_id].teamid2 - 1).FirstName + " " +
                                                              tournament.playersTournamentRandomize.ElementAt(tournament.TournamentRoundMatches[col][effective_match_id].teamid2 - 1).LastName +
                                                              "</td>");
                            }
                        }
                        else
                        {
                            if (row == column_stagger_offset + 2)
                            {
                                HTMLTable.AppendLine("        <td class=\"winner\">" + tournament.playersTournamentRandomize.ElementAt(tournament.TournamentRoundMatches[rounds][cumulative_matches].winner - 1).FirstName + " " +
                                                                                       tournament.playersTournamentRandomize.ElementAt(tournament.TournamentRoundMatches[rounds][cumulative_matches].winner - 1).LastName + 
                                                                                       "</td>");
                            }
                            else if (row == column_stagger_offset + 3)
                            {
                                HTMLTable.AppendLine("        <td class=\"white_span\" rowspan=\"" + (match_white_span - column_stagger_offset) + "\">&nbsp;</td>");
                            }
                        }
                    }
                    if (col <= rounds)
                    {
                        cumulative_matches += tournament.TournamentRoundMatches[col].Count;
                    }
                }
                HTMLTable.AppendLine("    </tr>");
            }
            HTMLTable.AppendLine("</table>");

            HTMLTable.AppendLine("<h1>Third Place Results</h1>");
            HTMLTable.AppendLine("<table border=\"0\" cellspacing=\"0\">");
            HTMLTable.AppendLine("    <tr>");
            HTMLTable.AppendLine("        <th class=\"thd\">Round 1</th>");
            HTMLTable.AppendLine("        <th class=\"thd\">Third Place</th>");
            HTMLTable.AppendLine("    </tr>");
            HTMLTable.AppendLine("    <tr>");
            HTMLTable.AppendLine("        <td class=\"white_span\">&nbsp;</td>");
            HTMLTable.AppendLine("        <td class=\"white_span\" rowspan=\"2\">&nbsp;</td>");
            HTMLTable.AppendLine("    </tr>");
            HTMLTable.AppendLine("    <tr>");
            HTMLTable.AppendLine("        <td class=\"team\">" + tournament.playersTournamentRandomize.ElementAt(tournament.ThirdPlaceMatch.teamid1 - 1).FirstName + " " + 
                                                                 tournament.playersTournamentRandomize.ElementAt(tournament.ThirdPlaceMatch.teamid1 - 1).LastName + "</td>");
            HTMLTable.AppendLine("    </tr>");
            HTMLTable.AppendLine("    <tr>");
            HTMLTable.AppendLine("        <td class=\"vs\">VS</td>");
            HTMLTable.AppendLine("        <td class=\"winner\">" + tournament.playersTournamentRandomize.ElementAt(tournament.ThirdPlaceMatch.winner - 1).FirstName + " " +
                                                                   tournament.playersTournamentRandomize.ElementAt(tournament.ThirdPlaceMatch.winner - 1).LastName + "</td>");
            HTMLTable.AppendLine("    </tr>");
            HTMLTable.AppendLine("    <tr>");
            HTMLTable.AppendLine("        <td class=\"team\">" + tournament.playersTournamentRandomize.ElementAt(tournament.ThirdPlaceMatch.teamid2 - 1).FirstName + " " + 
                                                                 tournament.playersTournamentRandomize.ElementAt(tournament.ThirdPlaceMatch.teamid2 - 1).LastName + "</td>");
            HTMLTable.AppendLine("        <td class=\"white_span\">&nbsp;</td>");
            HTMLTable.AppendLine("    </tr>");
            HTMLTable.AppendLine("</table>");
            return HTMLTable.ToString();
        }

    }
}
