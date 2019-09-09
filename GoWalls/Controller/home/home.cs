using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using System.Threading.Tasks;

namespace GoWalls
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class Home : AppCompatActivity
    {
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.home);
        }
    }
}