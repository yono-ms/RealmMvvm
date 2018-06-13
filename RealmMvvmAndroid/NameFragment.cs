using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using RealmMvvm;

namespace RealmMvvmAndroid
{
    public class NameFragment : Fragment
    {
        private NameViewModel ViewModel;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            return inflater.Inflate(Resource.Layout.fragment_name, container, false);
        }

        public override void OnResume()
        {
            base.OnResume();

            ViewModel = (Activity as MainActivity).BizLogic.GetViewModel<NameViewModel>();

            // VMイベント
            ViewModel.PropertyChanged += ViewModel_PropertyChanged;

            // コントロールイベント
            View.FindViewById<Button>(Resource.Id.buttonCommit).Click += StartFragment_Click;

            // 初期設定
            View.FindViewById<TextView>(Resource.Id.textViewTitle).Text = ViewModel.PageTitle;
            View.FindViewById<TextView>(Resource.Id.textViewDescription).Text = ViewModel.PageDescription;
        }

        private void StartFragment_Click(object sender, EventArgs e)
        {
            ViewModel.OnClickCommitInvoke(sender, e);
        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"ViewModel_PropertyChanged {e.PropertyName}");
        }

        public override void OnPause()
        {
            base.OnPause();

            // VMイベント
            ViewModel.PropertyChanged -= ViewModel_PropertyChanged;

            // コントロールイベント
            View.FindViewById<Button>(Resource.Id.buttonCommit).Click -= StartFragment_Click;

            ViewModel = null;
        }
    }
}