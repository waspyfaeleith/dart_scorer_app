
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace DartScorer.Droid
{
    [Activity(Label = "PlayMatchActivity")]
    public class PlayMatchActivity : Activity
    {
        TextView player1NameText;
        TextView player2NameText;
        TextView player1SetsText;
        TextView player2SetsText;
        TextView player1LegsText;
        TextView player2LegsText;
        TextView player1ScoreText;
        TextView player2ScoreText;
        TextView messageThrower;

        static TextView messageWinner;
        TextView messageText;
        EditText enterScoreText;
        Button enterScoreButton;

        String message;

        static Context context;

        Match match;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.PlayMatch);

            player1NameText = FindViewById<TextView>(Resource.Id.player_1_name);
            player2NameText = FindViewById<TextView>(Resource.Id.player_2_name);
            player1SetsText = FindViewById<TextView>(Resource.Id.player_1_sets);
            player2SetsText = FindViewById<TextView>(Resource.Id.player_2_sets);
            player1LegsText = FindViewById<TextView>(Resource.Id.player_1_legs);
            player2LegsText = FindViewById<TextView>(Resource.Id.player_2_legs);
            player1ScoreText = FindViewById<TextView>(Resource.Id.player_1_score);
            player2ScoreText = FindViewById<TextView>(Resource.Id.player_2_score);

            messageThrower = FindViewById<TextView>(Resource.Id.message_thrower);
            messageWinner = FindViewById<TextView>(Resource.Id.message_winner);

            messageText = FindViewById<TextView>(Resource.Id.message_winner);

            enterScoreText = FindViewById<EditText>(Resource.Id.score_entry);
            enterScoreButton = FindViewById<Button>(Resource.Id.enter_score_btn);

            var jsonString = Intent.GetStringExtra("matchDetails");
            match = JsonConvert.DeserializeObject<Match>(jsonString);
            //Toast.MakeText(this, matchDetails(), ToastLength.Long).Show();

            player1NameText.Text = this.match.Game.Player1.Name;
            player2NameText.Text = this.match.Game.Player2.Name;

            enterScoreButton.Click += delegate {
                this.enterScoreButtonClick();
            };

            this.updateTextViews();
            context = this;
            this.message = match.Game.Thrower.Name + " to throw";
        }

        private void enterScoreButtonClick() {
            String enteredScore = !String.IsNullOrEmpty(enterScoreText.Text) ? enterScoreText.Text : "";
            if (!String.IsNullOrEmpty(enteredScore))
            {
                int score = int.Parse(enteredScore);
    
                if (!match.MatchWon())
                {
                    match.ProcessScore(score);
                }
                updateTextViews();
            }
        }

        private void updateTextViews()
        {
            player1SetsText.Text = this.match.Game.Player1.SetsWon.ToString();
            player2SetsText.Text = this.match.Game.Player2.SetsWon.ToString();

            player1LegsText.Text = this.match.Game.Player1.LegsWon.ToString();
            player2LegsText.Text = this.match.Game.Player2.LegsWon.ToString();

            player1ScoreText.Text = this.match.Game.Player1.CurrentScore.ToString();
            player2ScoreText.Text = this.match.Game.Player2.CurrentScore.ToString();

            if (match.Game.Thrower != null)
            {
                messageThrower.Text = match.Game.Thrower.Name + " to throw";
            }
            else
            {
                messageThrower.Text = "";
            }

            if (match.Game.Winner() != null)
            {
                messageWinner.Text = match.Game.Winner().Name;
            }
            else
            {
                messageWinner.Text = match.Message;
            }

            enterScoreText.Text = "";
            if (match.MatchWon())
            {
                enterScoreText.Visibility = ViewStates.Invisible;
                enterScoreButton.Visibility = ViewStates.Invisible;
            }
        }

        private string matchDetails()
        {

            return this.match.Game.Player1.Name + " V " + match.Game.Player2.Name;
        }
    }
}
