
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

namespace DartScorer.Droid
{
    [Activity(Label = "MatchSetUpActivity" , MainLauncher = true)]
    public class MatchSetUpActivity : Activity
    {
        //int numSets;
        //int numLegsPerSet;
        //int startScore;
        //String player1Name;
        //String player2Name;
        //TextView selectedSets;
        //TextView selectedLegsPerSet;
        //TextView selectedStartScore;
        //EditText textEditPlayer1Name;
        //EditText textEditPlayer2Name;
        //Button gameOnButton;
        Spinner numberOfSetsSpinner;
        Spinner numberOfLegsPerSetSpinner;
        Spinner startScoreSpinner;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.MatchSetUp);

            numberOfSetsSpinner = FindViewById<Spinner>(Resource.Id.sets_spinner);
            numberOfLegsPerSetSpinner = FindViewById<Spinner>(Resource.Id.legs_per_set_spinner);
            startScoreSpinner = FindViewById<Spinner>(Resource.Id.start_score_spinner);

            SetUpSpinners();
        }

        private void SetUpSpinners()
        {
            numberOfSetsSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(SpinnerItemSelected);
            var setsAdapter = ArrayAdapter.CreateFromResource(this, Resource.Array.sets_array, Android.Resource.Layout.SimpleSpinnerItem);
            setsAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            numberOfSetsSpinner.Adapter = setsAdapter;
        }

        private void SpinnerItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            string toast = string.Format("Selected sets is {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }
    }
}
