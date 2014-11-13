using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
// デバッグ用追加
using System.Threading;
// 多分使う
using System.Windows.Media.Animation;
using MediaIIITest1;

namespace MediaIIITest1
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            // アニメーションの登録
            // 音量棒の変化で動作

            // 起動時に動作
            this.Loaded += MainWindowLoaded;
        }

        void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            InitializeFigure();
            double tick=100.0;
            TempoChange(tick);
            // キネクトここに書く
            // イベント登録とか

            // デバック用イベントの発生?
            //var Step = new MyDebug();
            //Step.Test();
        }
        void InitializeFigure()
        {
            // ボリューム表示の初期化
            Volume.Height = Volume.MinHeight;
            // スライダーの初期化
            TestSlider.Value = 0;
            // テンポの回転中心の初期化(ボトムが原点)
            Tempo.RenderTransformOrigin = new Point(0.5, 1.0);
            // テンポ棒の角度の初期化
            Tempo.RenderTransform = new RotateTransform(0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Volume.Height = 100;
        }
        /// <summary>
        /// スライダーの動きに合わせてボリュームが動く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VolumeChange(Volume.Height, TestSlider.Value*12);
        }

        /// <summary>
        /// ボリュームのアニメーション
        /// </summary>
        /// <param name="from"></param>　これ要らん
        /// <param name="to"></param>
        public void VolumeChange(double from, double to)
        {
            // ストーリボードクラスのインスタンス
            Storyboard storyboard = new Storyboard();
            storyboard.FillBehavior = FillBehavior.HoldEnd; // これいる？
            // 線形補間アニメーション
            DoubleAnimation animation = new DoubleAnimation { From = from, To = to, Duration = new Duration(TimeSpan.FromMilliseconds(100)) };
            animation.RepeatBehavior = new RepeatBehavior(1);
            Storyboard.SetTarget(animation, Volume);
            Storyboard.SetTargetProperty(animation, new PropertyPath("Height"));
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }

        public void TempoChange(double tick)
        {
            Tempo.RenderTransform = new RotateTransform();
            Storyboard storyboard = new Storyboard();
            DoubleAnimation animation = new DoubleAnimation { From = 10, To = 100, Duration = new Duration(TimeSpan.FromMilliseconds(1000)) };
            animation.RepeatBehavior = new RepeatBehavior(1);
            Storyboard.SetTarget(animation, Tempo);
            Storyboard.SetTargetProperty(animation, new PropertyPath();
        }
    }
}

public class MyDebug
{
    public void Test()
    {
        // MyTest.cs へのクラス作成
        MyTest evt = new MyTest();
        // ハンドラーをイベントリストに追加(+= で追加)
        // Handler はスタブで生成
        
        evt.Fire();
    }

    private static void Handler()
    {
        // 操作記述
        throw new NotImplementedException();
    }
}
