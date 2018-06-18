using RealmMvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace RealmMvvmUwp
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class AgePage : Page
    {
        AgeViewModel viewModel;

        public AgePage()
        {
            this.InitializeComponent();

            viewModel = (Application.Current as App).BizLogic.GetViewModel<AgeViewModel>();
            DataContext = viewModel;
        }

        private void ButtonCommit_Click(object sender, RoutedEventArgs e)
        {
            viewModel.OnClickCommitInvoke(viewModel, new EventArgs());
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            viewModel.OnClickBackInvoke(viewModel, new EventArgs());
        }
    }
}
