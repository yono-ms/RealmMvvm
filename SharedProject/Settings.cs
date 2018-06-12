using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealmMvvm
{
    /// <summary>
    /// BizLogicの設定情報
    /// </summary>
    public class Settings : RealmObject
    {
        /// <summary>
        /// 現在のページ.
        /// ViewModelのnameofを使用する.
        /// </summary>
        public string CurrentPage { get; set; }
    }
}
