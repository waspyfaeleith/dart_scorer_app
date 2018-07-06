using System;
using System.Collections.Generic;

namespace DartScorer
{
    public class Match
    {
        private int sets;
        private int legsPerSet;
        private int startScore;
        List<Player> players;
        Player setThrower;
        Player legThrower;
        Game game;

        public Game Game
        {
            get { return this.game; }
            set { this.game = value; }
        }

        public List<Player> Players
        {
            get { return this.players; }
        }

        public Match() {
            
        }

        public Match(String player1Name, String player2Name, int sets, int legsPerSet, int startScore)
        {
            Player player1 = new Player(player1Name, startScore);
            Player player2 = new Player(player2Name, startScore);
            this.sets = sets;
            this.legsPerSet = legsPerSet;
            this.startScore = startScore;
            this.players = new List<Player>();
            this.players.Add(player1);
            this.players.Add(player2);

            this.game = new Game(startScore, players, sets, legsPerSet);

            this.setThrower = player1;
            this.legThrower = player1;
        }

        public int SetsNeededToWinMatch()
        {
            return (this.sets / 2) + 1;
        }

        public int LegsNeededToWinSet()
        {
            return (this.legsPerSet / 2) + 1;
        }

        public bool SetWon()
        {
            if ((game.Player1.LegsWon == this.LegsNeededToWinSet()) ||
                    (game.Player2.LegsWon == this.LegsNeededToWinSet()))
            {
                game.Winner().SetsWon++;
                return true;
            }
            return false;
        }

        public bool MatchWon()
        {
            return ((game.Player1.SetsWon == SetsNeededToWinMatch()) ||
                    (game.Player2.SetsWon == SetsNeededToWinMatch()));
        }

        private void NewSet()
        {
            game.Player1.LegsWon = 0;
            game.Player2.LegsWon = 0;
            this.NewGame();
            game.Thrower = this.SwitchThrower(this.setThrower);
            this.setThrower = game.Thrower;
        }

        private void NewGame()
        {
            game.Player1.ResetScores(this.startScore);
            game.Player2.ResetScores(this.startScore);
            game = new Game(startScore, players, sets, legsPerSet);
        }

        public void NewLeg()
        {
            this.NewGame();
            game.Thrower = this.SwitchThrower(this.legThrower);
            this.legThrower = game.Thrower;
        }

        private void Turn(Player player)
        {

            Throw playerThrow = new Throw(0);

            player.ThrowDarts(playerThrow);
        }

        private Player SwitchThrower(Player thrower)
        {
            if (thrower == game.Player1)
            {
                thrower = game.Player2;
            }
            else
            {
                thrower = game.Player1;
            }
            return thrower;
        }

        public void Play()
        {
            while (this.MatchWon() == false)
            {
                this.PlayLeg();
                this.LegWon();
            }
        }

        private void PlayLeg()
        {
            while (!game.IsWon())
            {
                this.Turn(game.Thrower);
                this.game.ChangeThrower();
            }
        }

        private void LegWon()
        {
            game.Winner().LegsWon++;
            if (this.SetWon())
            {
                if (this.MatchWon())
                {
                    // TODO: game shot and the MATCH
                    return;
                }
                else
                {
                    // TODO: game shot and the SET
                    this.NewSet();
                }
            }
            else
            {
                // TODO: game shot and the LEG
                this.NewLeg();
            }
        }
    }
}
