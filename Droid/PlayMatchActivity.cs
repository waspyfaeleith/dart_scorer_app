
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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            var jsonString = Intent.GetStringExtra("matchDetails");
            var match = JsonConvert.DeserializeObject<Match>(jsonString);
            Toast.MakeText(this, matchDetails(match), ToastLength.Long).Show();


        }

        private string matchDetails(Match match)
        {

            return match.Game.Player1.Name + " V " + match.Game.Player2.Name;
        }
    }
}
