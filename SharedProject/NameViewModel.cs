using System;
using System.Collections.Generic;
using System.Text;

namespace RealmMvvm
{
    /// <summary>
    /// 名前入力ページ.
    /// </summary>
    public class NameViewModel : BaseViewModel
    {
        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 名前（カナ）
        /// </summary>
        public string NameKana { get; set; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NameViewModel()
        {
            PageTitle = "名前の入力";
            PageDescription = "名前を入力して「次へ」ボタンを押してください。";
        }
    }
}
