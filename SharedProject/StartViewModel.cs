using System;
using System.Collections.Generic;
using System.Text;

namespace RealmMvvm
{
    /// <summary>
    /// スタートページ.
    /// </summary>
    public class StartViewModel : BaseViewModel
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public StartViewModel()
        {
            PageTitle = "エントリー開始";
            PageDescription = "エントリーシートへの入力を開始する場合は「次へ」ボタンを押してください。";
        }
    }
}
