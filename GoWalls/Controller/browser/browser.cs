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
using Android.Webkit;
using Android.Graphics.Drawables;

namespace GoWalls
{
    [Activity(Theme = "@style/AppTheme")]
    public class browser : DialogFragment
    {
        public static WebView web_view;
        public static string url = null;
        public static string titlee = null;
        public static LinearLayout layoutprogress;
        System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        View view;
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.SetGravity(GravityFlags.Right);
            Dialog.Window.SetLayout(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            Dialog.Window.SetBackgroundDrawable(new ColorDrawable(Android.Graphics.Color.Transparent));

            var url = this.Activity.GetString(Resource.String.powermeter);
            Console.WriteLine(url);
            this.Activity.RunOnUiThread(() =>
            {
                web_view = view.FindViewById<WebView>(Resource.Id.webView1);
                web_view.Settings.JavaScriptEnabled = true;
                web_view.Settings.DomStorageEnabled = true;
                web_view.Settings.CacheMode = CacheModes.NoCache;
                web_view.Settings.PluginsEnabled = true;
                web_view.Settings.SetPluginState(WebSettings.PluginState.On);
                //web_view.SetWebChromeClient(new WebChromeClient());
                web_view.SetWebViewClient(new HelloWebViewClient());
                web_view.SetWebChromeClient(new WebChromeClient());
                //web_view.SetWebViewClient(new HelloWebViewClient());
                web_view.LoadUrl(url);
            });

            try
            {
                var progressDialog = view.FindViewById<ProgressBar>(Resource.Id.progress);
                layoutprogress = view.FindViewById<LinearLayout>(Resource.Id.layoutprogress);
                progressDialog.Visibility = ViewStates.Visible;
            }
            catch
            {
                //SellingActivity.mc.RunOnUiThread(() =>
                //{
                //    Toast.MakeText(this.Activity, GetString(Resource.String.ada_kesalahan), ToastLength.Short).Show();
                //});
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle); //set title bar to invisible
            if (Build.VERSION.SdkInt >= Build.VERSION_CODES.Lollipop)
            {
                Dialog.Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
                Dialog.Window.ClearFlags(WindowManagerFlags.DimBehind);
                Dialog.Window.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.LayoutStable;
                SetStyle(DialogFragmentStyle.NoTitle, Resource.Style.DialogTheme);
            }
            view = inflater.Inflate(Resource.Layout.browser, container, false);


            return view;
        }

        //public override bool OnOptionsItemSelected(IMenuItem item)
        //{
        //    if (item.ItemId == Android.Resource.Id.Home)
        //    {
        //        OnBackPressed();
        //    }
        //    return base.OnOptionsItemSelected(item);
        //}
        //public override void OnBackPressed()
        //{
        //    base.OnBackPressed();
        //    OverridePendingTransition(Resource.Animation.Stay, Resource.Animation.slide_right);
        //}
        public class HelloWebViewClientt : WebChromeClient
        {
            //public override bool ShouldOverrideUrlLoading(WebView view, IWebResourceRequest request)
            //{
            //    view.LoadUrl(request.Url.ToString());
            //    return false;
            //}

            public void onReceivedTitle(WebView view, String title)
            {
                //Window.setTitle(title); //Set Activity tile to page title.
            }

            //public override void OnPageFinished(WebView view, String url)
            //{
            //    base.OnPageFinished(view, url);
            //    //Application.SynchronizationContext.Post(_ =>
            //    //{
            //        WebviewAbout.layoutprogress.Visibility = ViewStates.Gone;
            //        WebviewAbout.web_view.Visibility = ViewStates.Visible;
            //    //}, null);
            //    //Console.WriteLine("finish");
            //}
        }

        public class HelloWebViewClient : WebViewClient
        {
            public override bool ShouldOverrideUrlLoading(WebView view, IWebResourceRequest request)
            {
                view.LoadUrl(request.Url.ToString());
                return false;
            }

            public override void OnPageFinished(WebView view, String url)
            {
                base.OnPageFinished(view, url);
                MainActivity.is_this.RunOnUiThread(() =>
                {

                    try
                    {
                        browser.layoutprogress.Visibility = ViewStates.Gone;
                        browser.web_view.Visibility = ViewStates.Visible;
                    }
                    catch
                    {

                    }
                });
            }
        }
    }
}