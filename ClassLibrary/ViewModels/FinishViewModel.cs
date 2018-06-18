using System;
using System.Collections.Generic;
using System.Text;

namespace RealmMvvm
{
    /// <summary>
    /// 完了画面.
    /// </summary>
    public class FinishViewModel : BaseViewModel
    {
        public FinishViewModel()
        {
            PageTitle = "お申し込み完了";
            PageDescription = "ありがとうございました。";
        }
    }
}
