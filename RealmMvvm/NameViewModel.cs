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
    }
}
