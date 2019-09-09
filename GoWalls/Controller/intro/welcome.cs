using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using System.Threading.Tasks;
using Android.Widget;
using Android;
using Android.Content.PM;

namespace GoWalls
{
    [Activity(Theme = "@style/AppTheme")]
    public class Welcome : AppCompatActivity
    {
        public static Activity is_this;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            is_this = this;
            SetContentView(Resource.Layout.welcome);

            TextView masuk = FindViewById<TextView>(Resource.Id.masuk);
            masuk.Click += delegate {
                StartActivity(typeof(WeatherSample));
            };
            TextView daftar = FindViewById<TextView>(Resource.Id.daftar);
            daftar.Click += delegate {
                StartActivity(typeof(WeatherSample));
            };
            ImageView back = FindViewById<ImageView>(Resource.Id.back);
            back.Click += delegate {
                Finish();
                StartActivity(typeof(Intro));
            };

            if (CheckSelfPermission(Manifest.Permission.AccessCoarseLocation) != (int)Permission.Granted)
            {
                RequestPermissions(new string[] { Manifest.Permission.AccessCoarseLocation, Manifest.Permission.AccessFineLocation }, 0);
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}