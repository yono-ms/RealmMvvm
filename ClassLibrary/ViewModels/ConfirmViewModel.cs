using System;
using System.Collections.Generic;
using System.Text;

namespace RealmMvvm
{
    /// <summary>
    /// 確認画面.
    /// </summary>
    public class ConfirmViewModel : BaseViewModel
    {
        /// <summary>
        /// 確認項目
        /// </summary>
        public enum ConfirmItemType
        {
            Name,
            NameKana,
            Age,
            Address
        }
        /// <summary>
        /// 確認項目
        /// </summary>
        public class ConfirmItem
        {
            public ConfirmItemType ItemType { get; set; }
            public string Name { get; set; }
            public string Value { get; set; }
        }
        /// <summary>
        /// 確認項目
        /// </summary>
        public List<ConfirmItem> ConfirmItems { get; set; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ConfirmViewModel()
        {
            PageTitle = "入力内容の確認";
            PageDescription = "入力内容がよろしければ「次へ」ボタンを押してください。";
            ConfirmItems = new List<ConfirmItem>();
        }
        /// <summary>
        /// 編集イベント
        /// </summary>
        public event EventHandler<EditEventArgs> OnClickEdit;
        /// <summary>
        /// 編集イベント引数
        /// </summary>
        public class EditEventArgs : EventArgs
        {
            public ConfirmItemType ItemType { get; set; }
        }
        /// <summary>
        /// 外部から編集イベントをキックする.
        /// </summary>
        /// <param name="sender">送信者</param>
        /// <param name="e">イベント引数</param>
        public void OnClickEditInvoke(object sender, EditEventArgs e)
        {
            OnClickEdit?.Invoke(sender, e);
        }

    }
}
