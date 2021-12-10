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

namespace Kanaquizcs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public string Submited_Answer = "null";
        public string Chosen_Answer = "a";
        public int Correct = 0;
        public int Incorrect = 0;
        public bool EnableHiragana = true;
        public bool EnableKatakana = false;
        Random randomInstance = new Random();




        public MainWindow()
        {
            InitializeComponent();
            NewQuestion();
        }

        private void NewQuestion()
        {
            var HiraganaDict = new Dictionary<string, string>()
        {
            {"あ","a" },{"い","i" },{"う","u" },{"え","e" },{"お","o" },
            {"か","ka" },{"き","ki" },{"く","ku" },{"け","ke" },{"こ","ko" },{"きゃ","kya" },{"きゅ","kyu" },{"きょ","kyo" },
            {"さ","sa" },{"し","shi" },{"す","su" },{"せ","se" },{"そ","so" },{"しゃ","sha" },{"しゅ","shu" },{"しょ","sho" },
            {"た","ta" },{"ち","chi" },{"つ","tsu" },{"て","te"},{"と","to" },{"ちゃ","cha" },{"ちゅ","chu" },{"ちょ","cho" },
            {"な","na" },{"に","ni" },{"ぬ","nu" },{"ね","ne" },{"の","no" },{"にゃ","nya" },{"にゅ","nyu" },{"にょ","nyo" },
            {"は","ha" },{"ひ","hi" },{"ふ","fu" },{"へ","he" },{"ほ","ho" },{"ひゃ","hya" },{"ひゅ","hyu" },{"ひょ","hyo" },
            {"ま","ma" },{"み","mi" },{"む","mu" },{"め","me" },{"も","mo" },{"みゃ","mya" },{"みゅ","myu" },{"みょ","myo" },
            {"や","ya" },{"ゆ","yu" },{"よ","yo" },
            {"ら","ra" },{"り","ri" },{"る","ru" },{"れ","re" },{"ろ","ro" },{"りゃ","rya" },{"りゅ","ryu" },{"りょ","ryo" },
            {"わ","wa" },{"を","wo" },
            {"が","ga" },{"ぎ","gi" },{"ぐ","gu" },{"げ","ge" },{"ご","go" },{"ぎゃ","gya" },{"ぎゅ","gyu" },{"ぎょ","gyo" },
            {"ざ","za" },{"じ","ji" },{"ず","zu" },{"ぜ","ze" },{"ぞ","zo" },{"じゃ","ja" },{"じゅ","ju" },{"じょ","jo" },
            {"だ","da" },{"ぢ","zi" },{"づ","zu" },{"で","de" },{"ど","do" },
            {"ば","ba" },{"び","bi" },{"ぶ","bu" },{"べ","be" },{"ぼ","bo" },{"びゃ","bya" },{"びゅ","byu" },{"びょ","byo" },
            {"ぱ","pa" },{"ぴ","pi" },{"ぷ","pu" },{"ぺ","pe" },{"ぽ","po" },{"ぴゃ","pya" },{"ぴゅ","pyu" },{"ぴょ","pyo" }
        };

            var KatakanaDict = new Dictionary<string, string>()
        {
            {"ア","a" },{"イ","i" },{"ウ","u" },{"エ","e" },{"オ","o" },
            {"カ","ka" },{"キ","ki" },{"ク","ku" },{"ケ","ke" },{"コ","ko" },{"キャ","kya" },{"キュ","kyu" },{"キョ","kyo" },
            {"サ","sa" },{"シ","shi" },{"ス","su" },{"セ","se" },{"ソ","so" },{"シャ","sha" },{"シュ","shu" },{"ショ","sho" },
            {"タ","ta" },{"チ","chi" },{"ツ","tsu" },{"テ","te"},{"ト","to" },{"チャ","cha" },{"チュ","chu" },{"チョ","cho" },
            {"ナ","na" },{"ニ","ni" },{"ヌ","nu" },{"ネ","ne" },{"ノ","no" },{"ニャ","nya" },{"ニュ","nyu" },{"ニョ","nyo" },
            {"ハ","ha" },{"ヒ","hi" },{"フ","fu" },{"ヘ","he" },{"ホ","ho" },{"ヒャ","hya" },{"ヒュ","hyu" },{"ヒョ","hyo" },
            {"マ","ma" },{"ミ","mi" },{"ム","mu" },{"メ","me" },{"モ","mo" },{"ミャ","mya" },{"ミュ","myu" },{"ミョ","myo" },
            {"ヤ","ya" },{"ユ","yu" },{"ヨ","yo" },
            {"ラ","ra" },{"リ","ri" },{"ル","ru" },{"レ","re" },{"ロ","ro" },{"リャ","rya" },{"リュ","ryu" },{"リョ","ryo" },
            {"ワ","wa" },{"ヲ","wo" },
            {"ガ","ga" },{"ギ","gi" },{"グ","gu" },{"ゲ","ge" },{"ゴ","go" },{"ギャ","gya" },{"ギュ","gyu" },{"ギョ","gyo" },
            {"ザ","za" },{"ジ","ji" },{"ズ","zu" },{"ゼ","ze" },{"ゾ","zo" },{"ジャ","ja" },{"ジュ","ju" },{"ジョ","jo" },
            {"ダ","da" },{"ヂ","ji" },{"ヅ","zu" },{"デ","de" },{"ド","do" },
            {"バ","ba" },{"ビ","bi" },{"ブ","bu" },{"ベ","be" },{"ボ","bo" },{"ビャ","bya" },{"ビュ","byu" },{"ビョ","byo" },
            {"パ","pa" },{"ピ","pi" },{"プ","pu" },{"ペ","pe" },{"ポ","po" },{"ピャ","pya" },{"ピュ","pyu" },{"ピョ","pyo" }
        };

            var DualDict = new Dictionary<string, string>()
        {
            {"あ","a" },{"い","i" },{"う","u" },{"え","e" },{"お","o" },
            {"か","ka" },{"き","ki" },{"く","ku" },{"け","ke" },{"こ","ko" },{"きゃ","kya" },{"きゅ","kyu" },{"きょ","kyo" },
            {"さ","sa" },{"し","shi" },{"す","su" },{"せ","se" },{"そ","so" },{"しゃ","sha" },{"しゅ","shu" },{"しょ","sho" },
            {"た","ta" },{"ち","chi" },{"つ","tsu" },{"て","te"},{"と","to" },{"ちゃ","cha" },{"ちゅ","chu" },{"ちょ","cho" },
            {"な","na" },{"に","ni" },{"ぬ","nu" },{"ね","ne" },{"の","no" },{"にゃ","nya" },{"にゅ","nyu" },{"にょ","nyo" },
            {"は","ha" },{"ひ","hi" },{"ふ","fu" },{"へ","he" },{"ほ","ho" },{"ひゃ","hya" },{"ひゅ","hyu" },{"ひょ","hyo" },
            {"ま","ma" },{"み","mi" },{"む","mu" },{"め","me" },{"も","mo" },{"みゃ","mya" },{"みゅ","myu" },{"みょ","myo" },
            {"や","ya" },{"ゆ","yu" },{"よ","yo" },
            {"ら","ra" },{"り","ri" },{"る","ru" },{"れ","re" },{"ろ","ro" },{"りゃ","rya" },{"りゅ","ryu" },{"りょ","ryo" },
            {"わ","wa" },{"を","wo" },
            {"が","ga" },{"ぎ","gi" },{"ぐ","gu" },{"げ","ge" },{"ご","go" },{"ぎゃ","gya" },{"ぎゅ","gyu" },{"ぎょ","gyo" },
            {"ざ","za" },{"じ","ji" },{"ず","zu" },{"ぜ","ze" },{"ぞ","zo" },{"じゃ","ja" },{"じゅ","ju" },{"じょ","jo" },
            {"だ","da" },{"ぢ","zi" },{"づ","zu" },{"で","de" },{"ど","do" },
            {"ば","ba" },{"び","bi" },{"ぶ","bu" },{"べ","be" },{"ぼ","bo" },{"びゃ","bya" },{"びゅ","byu" },{"びょ","byo" },
            {"ぱ","pa" },{"ぴ","pi" },{"ぷ","pu" },{"ぺ","pe" },{"ぽ","po" },{"ぴゃ","pya" },{"ぴゅ","pyu" },{"ぴょ","pyo" },
            {"ア","a" },{"イ","i" },{"ウ","u" },{"エ","e" },{"オ","o" },
            {"カ","ka" },{"キ","ki" },{"ク","ku" },{"ケ","ke" },{"コ","ko" },{"キャ","kya" },{"キュ","kyu" },{"キョ","kyo" },
            {"サ","sa" },{"シ","shi" },{"ス","su" },{"セ","se" },{"ソ","so" },{"シャ","sha" },{"シュ","shu" },{"ショ","sho" },
            {"タ","ta" },{"チ","chi" },{"ツ","tsu" },{"テ","te"},{"ト","to" },{"チャ","cha" },{"チュ","chu" },{"チョ","cho" },
            {"ナ","na" },{"ニ","ni" },{"ヌ","nu" },{"ネ","ne" },{"ノ","no" },{"ニャ","nya" },{"ニュ","nyu" },{"ニョ","nyo" },
            {"ハ","ha" },{"ヒ","hi" },{"フ","fu" },{"ヘ","he" },{"ホ","ho" },{"ヒャ","hya" },{"ヒュ","hyu" },{"ヒョ","hyo" },
            {"マ","ma" },{"ミ","mi" },{"ム","mu" },{"メ","me" },{"モ","mo" },{"ミャ","mya" },{"ミュ","myu" },{"ミョ","myo" },
            {"ヤ","ya" },{"ユ","yu" },{"ヨ","yo" },
            {"ラ","ra" },{"リ","ri" },{"ル","ru" },{"レ","re" },{"ロ","ro" },{"リャ","rya" },{"リュ","ryu" },{"リョ","ryo" },
            {"ワ","wa" },{"ヲ","wo" },
            {"ガ","ga" },{"ギ","gi" },{"グ","gu" },{"ゲ","ge" },{"ゴ","go" },{"ギャ","gya" },{"ギュ","gyu" },{"ギョ","gyo" },
            {"ザ","za" },{"ジ","ji" },{"ズ","zu" },{"ゼ","ze" },{"ゾ","zo" },{"ジャ","ja" },{"ジュ","ju" },{"ジョ","jo" },
            {"ダ","da" },{"ヂ","ji" },{"ヅ","zu" },{"デ","de" },{"ド","do" },
            {"バ","ba" },{"ビ","bi" },{"ブ","bu" },{"ベ","be" },{"ボ","bo" },{"ビャ","bya" },{"ビュ","byu" },{"ビョ","byo" },
            {"パ","pa" },{"ピ","pi" },{"プ","pu" },{"ペ","pe" },{"ポ","po" },{"ピャ","pya" },{"ピュ","pyu" },{"ピョ","pyo" }
        };

            if (EnableHiragana == true & EnableKatakana == false)
            {
                int index = randomInstance.Next(HiraganaDict.Count);
                KeyValuePair<string, string> pair = HiraganaDict.ElementAt(index);
                Chosen_Answer = pair.Value;
                Question_FG.Text = pair.Key;
                Question_BG.Text = pair.Key;
            }
            else if(EnableKatakana == true & EnableHiragana == false)
            {
                int index = randomInstance.Next(KatakanaDict.Count);
                KeyValuePair<string, string> pair = KatakanaDict.ElementAt(index);
                Chosen_Answer = pair.Value;
                Question_FG.Text = pair.Key;
                Question_BG.Text = pair.Key;
            }
            else if (EnableKatakana == true & EnableHiragana == true)
            {
                int index = randomInstance.Next(DualDict.Count);
                KeyValuePair<string, string> pair = DualDict.ElementAt(index);
                Chosen_Answer = pair.Value;
                Question_FG.Text = pair.Key;
                Question_BG.Text = pair.Key;
            }
            

        }

        private void Exit_Mousedown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
        private void Menu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void CheckAnswer()
        {
            if (Submited_Answer == Chosen_Answer)
            {
                Answer_Response.Text = "Correct!";
                Answer_Response.Foreground = new SolidColorBrush(Color.FromRgb(46, 204, 113));
                Question_FG.Foreground = new SolidColorBrush(Color.FromRgb(46, 204, 113));
                Correct += 1;
                Score.Text = ("R: " + Correct + " W: " + Incorrect);
                NewQuestion();
            }
            else
            {
                Answer_Response.Text = "Incorrect!";
                Answer_Response.Foreground = new SolidColorBrush(Color.FromRgb(231, 76, 60));
                Question_FG.Foreground = new SolidColorBrush(Color.FromRgb(231, 76, 60));
                Incorrect += 1;
                Score.Text = ("R: " + Correct + " W: " + Incorrect); 
            }
        }
        private void answer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) 
            {
                    Submited_Answer = answer.Text;
                    CheckAnswer();
                    answer.Clear();
            }
        }

        private void Hiragana_Toggle(object sender, MouseButtonEventArgs e)
        {
            if (EnableHiragana == true & EnableKatakana == true)
            {
            HiraganaToggleText.Foreground = new SolidColorBrush(Color.FromRgb(52, 73, 94));
            EnableHiragana = false;
            }

            else
            {
            HiraganaToggleText.Foreground = new SolidColorBrush(Color.FromRgb(46, 204, 113));
            EnableHiragana = true;
            }
           
        }

        private void Katakana_Toggle(object sender, MouseButtonEventArgs e)
        {
            if (EnableKatakana == true & EnableHiragana == true)
            {
                KatakanaToggleText.Foreground = new SolidColorBrush(Color.FromRgb(52, 73, 94));
                EnableKatakana = false;
            }

            else
            {
                KatakanaToggleText.Foreground = new SolidColorBrush(Color.FromRgb(46, 204, 113));
                EnableKatakana = true;
            }
        }

        private void TextBlock_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {

        }
    }
}
