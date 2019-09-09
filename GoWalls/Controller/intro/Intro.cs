
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Sample;

namespace GoWalls
{
    [Activity(Theme = "@style/FullscreenTheme")]
    public class Intro : AppIntro.AppIntro
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            AddSlide(SampleSlide.NewInstance(Resource.Layout.intro));
            AddSlide(SampleSlide.NewInstance(Resource.Layout.intro2));
            AddSlide(SampleSlide.NewInstance(Resource.Layout.intro3));

            SetBarColor(Color.ParseColor("#ff0057"));
            SetSeparatorColor(Color.ParseColor("#ff0057"));
        }

        public void GetStarted(View v)
        {
            StartActivity(typeof(Home));
        }

        public override void OnDonePressed()
        {
            base.OnDonePressed();

            StartActivity(typeof(Home));
        }

        public override void OnSkipPressed()
        {
            base.OnSkipPressed();
            StartActivity(typeof(Home));
            Toast.MakeText(ApplicationContext, Resource.String.skip, ToastLength.Short).Show();
        }
    }
}
