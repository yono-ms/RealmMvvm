using System;
using System.Collections.Generic;
using System.Text;

namespace RealmMvvm
{
    /// <summary>
    /// OS依存機能
    /// </summary>
    public interface INativeCall
    {
        /// <summary>
        /// アラート表示
        /// </summary>
        /// <param name="message">エラーメッセージ</param>
        void ShowAlert(string message);
        /// <summary>
        /// 画面遷移
        /// </summary>
        /// <param name="viewName">ビューモデル名</param>
        void NavigateTo(string viewName);
    }
}
