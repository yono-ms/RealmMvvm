using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealmMvvm
{
    /// <summary>
    /// エントリーシート.
    /// 入力が終わったデータを保存する.
    /// </summary>
    public class EntrySheet : RealmObject
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
        /// 年齢
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 住所
        /// </summary>
        public string Address { get; set; }
    }
}
