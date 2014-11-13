using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/* デリゲート文
 * delegate 戻り値の型 名前(仮引数リスト);
 */
delegate void MyEventHandler();


namespace MediaIIITest1
{
    /// <summary>
    /// とりあえずテスト用のイベント確認
    /// </summary>
    class MyTest
    {
        /* イベントの宣言
         * event イベントデリゲート イベント名;
         */
        public event MyEventHandler SomeEvent;

        internal void Fire()
        {
            if (SomeEvent != null)
            {
                // イベント送信
                SomeEvent();
            }
        }
    }
}
