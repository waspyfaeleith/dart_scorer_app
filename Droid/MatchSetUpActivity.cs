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
    [Activity(Label = "Match Details" , MainLauncher = true)]
    public class MatchSetUpActivity : Activity
    {
        int numSets;
        int numLegsPerSet;
        int startScore;
        String player1Name;
        String player2Name;
        TextView selectedSets;
        TextView selectedLegsPerSet;
        TextView selectedStartScore;
        EditText textEditPlayer1Name;
        EditText textEditPlayer2Name;
        Button gameOnButton;
        Spinner numberOfSetsSpinner;
        Spinner numberOfLegsPerSetSpinner;
        Spinner startScoreSpinner;

        Match match;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.MatchSetUp);

            numberOfSetsSpinner = FindViewById<Spinner>(Resource.Id.sets_spinner);
            numberOfLegsPerSetSpinner = FindViewById<Spinner>(Resource.Id.legs_per_set_spinner);
            startScoreSpinner = FindViewById<Spinner>(Resource.Id.start_score_spinner);

            selectedSets = FindViewById<TextView>(Resource.Id.sets_chosen);
            selectedLegsPerSet = FindViewById<TextView>(Resource.Id.legs_per_set_chosen);
            selectedStartScore = FindViewById<TextView>(Resource.Id.start_score_chosen);

            textEditPlayer1Name = FindViewById<EditText>(Resource.Id.player1_text_edit);
            textEditPlayer2Name = FindViewById<EditText>(Resource.Id.player2_text_edit);

            gameOnButton = FindViewById<Button>(Resource.Id.game_on_button);
            gameOnButton.Click += delegate {
                gameOnButtonClick();
            }; 

            SetUpSpinners();
        }

        private void SetUpSpinners()
        {
            numberOfSetsSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(SpinnerItemSelected);
            var setsAdapter = ArrayAdapter.CreateFromResource(this, Resource.Array.sets_array, Android.Resource.Layout.SimpleSpinnerItem);
            setsAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            numberOfSetsSpinner.Adapter = setsAdapter;

            numberOfLegsPerSetSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(SpinnerItemSelected);
            var legsPerSetAdapter = ArrayAdapter.CreateFromResource(this, Resource.Array.legs_per_set_array, Android.Resource.Layout.SimpleSpinnerItem);
            legsPerSetAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            numberOfLegsPerSetSpinner.Adapter = legsPerSetAdapter;

            startScoreSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(SpinnerItemSelected);
            var startScoreAdapter = ArrayAdapter.CreateFromResource(this, Resource.Array.start_score_array, Android.Resource.Layout.SimpleSpinnerItem);
            startScoreAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            startScoreSpinner.Adapter = startScoreAdapter;
        }

        private void SpinnerItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            string toast;
            var selectedItem = spinner.GetItemAtPosition(e.Position).ToString();
            int selectedValue = int.Parse(selectedItem);

            switch(spinner.Id) {
                case Resource.Id.sets_spinner:
                    toast = string.Format("{0} sets", selectedItem);
                    selectedSets.Text = selectedItem;
                    numSets = selectedValue;
                    //Toast.MakeText(this, toast, ToastLength.Long).Show();
                    break;
                case Resource.Id.legs_per_set_spinner:
                    toast = string.Format("{0} legs per set", selectedItem);
                    selectedLegsPerSet.Text = selectedItem;
                    numLegsPerSet = selectedValue;
                    //Toast.MakeText(this, toast, ToastLength.Long).Show();
                    break;
                case Resource.Id.start_score_spinner:
                    toast = string.Format("{0} start", selectedItem);
                    selectedStartScore.Text = selectedItem;
                    startScore = selectedValue;
                    //Toast.MakeText(this, toast, ToastLength.Long).Show();
                    break;
            }
        }

        public void gameOnButtonClick() {
            player1Name = textEditPlayer1Name.Text;
            player2Name = textEditPlayer2Name.Text;

            match = new Match(player1Name, player2Name, numSets, numLegsPerSet, startScore);
            //Toast.MakeText(this, matchDetails(), ToastLength.Long).Show();
            var intent = new Intent(this, typeof(PlayMatchActivity));
            Bundle bundle = new Bundle();
            intent.PutExtra("matchDetails", JsonConvert.SerializeObject(match));
            StartActivity(intent);
        }

        private string matchDetails()
        {
            return player1Name + " V " + player2Name + "\n"
                    + startScore + "\n"
                    + "Best of  " + numSets + " sets\n"
                + "Best of " + numLegsPerSet + " per set";
        }
    }
}
