using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using System.Threading.Tasks;
using Com.Airbnb.Lottie;

namespace GoWalls
{
    [Activity(Label = "@string/app_name", Theme = "@style/FullscreenTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public static Activity is_this;
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            is_this = this;
            SetContentView(Resource.Layout.activity_main);

            LottieAnimationView animationView = FindViewById<LottieAnimationView>(Resource.Id.animation_view);
            animationView.SetAnimation("intro_logo_anim.json");
            animationView.Loop(false);
            await Task.Delay(3000);
            StartActivity(typeof(Intro));
        }
    }
}