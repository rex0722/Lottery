using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery
{
    class Strings
    {
        public static string[] comboxItem = new string[21]
        {"六獎", "五獎", "四獎", "三獎", "二獎",
         "一獎", "加碼1", "加碼2", "加碼3", "加碼4", 
         "加碼5", "加碼6", "加碼7", "加碼8", "加碼9", 
         "加碼10", "加碼11", "加碼12", "加碼13", "加碼14", "加碼15"};

        public static string[] lotteryLabelText = new string[152]
        {"嚴漢民(出差)", "涂銀發", "歐仁輝", "王耀東", "陳政雄", "林春喜", "劉銘怡", "王文彬(出差)", "顏俊銘(出差)",
         "莊育凱", "張忠祥", "馮俊泓", "潘逸賓", "葉　崧", "劉金原", "蕭志緯", "莊偉泰", "洪銘聰", "陳懷文",
         "鐘文祥", "吳俊毅", "鄭明發", "李克強", "高建隆", "黃新哲", "徐世龍", "方志翔", "王炳堯", "許耀仁",
         "陳克維", "甯光輝", "伍義銘", "賴協欣", "許濬麒(出差)", "李文達(出差)", "陳昭成(出差)", "翁秋煌", "蔡慶華", "陳志平",
         "鍾耀時", "李隆興", "吳錦楠", "李依柔", "吳兆慧", "呂　豪", "吳俊興", "賴柏嘉", "葉承慧",
         "戴澄瑋", "楊任祐", "陳慧蕙", "邱明志", "林翰韋", "張博堯", "李志鴻", "許哲維", "林彬輝", "蕭俊鴻", "蔡宜伶",
         "邱創儀", "蔡寬騰", "傅裕元", "林光隆(出差)", "李榮祥(出差)", "廖彥翔(出差)", "邱順隆(出差)", "謝育倫(出差)", "劉世才", "夏湘玲",
         "詹證富", "曾文亮", "米正光", "張菡珍", "黃宏仁", "林雅蘭", "林立堂(出差)", "范瑜娟(出差)", "黃彥豪", "徐明利",
         "吳豪淵", "陳力維", "高旭佳", "高旭彬", "張佳煌", "洪敏雄", "張尤守", "黃ㄧ庭", "方嘉駿", "陳志賢",
         "李昱麒", "董紹安", "余發聖", "賴裕翔", "陳元任(出差)", "黃焜琳(出差)", "蔡諭典", "曹杞龍", "江宏泰", "徐振程",
         "劉天立", "林書鋒", "陳冠宇(大)", "許瑞楓", "顏淑春", "吳佩倫", "陳冠宇(小)", "王葉申", "周能誠", "吳坤龍",
         "莊青斌", "楊智昇", "葉致均", "王俊傑", "吳智揚", "楊卓川(出差)", "吳光凱", "錢威廷", "丁世芳(出差)", "彭家賢",
         "鄭翔任", "呂銘杰", "楊盛標", "古哲偉(出差)", "簡嘉宏", "李建欣", "呂紹綱", "蕭敏哲", "李世傑", "杞伯樂",
         "張祐維", "林培倫", "葉家成", "陳暐盛", "周容慈", "吳輔章", "陳宏墀", "彭政凱(出差)", "張銘晃", "吳仲濤(出差)",
         "李欣曄(出差)", "陳約翰(高雄)", "葉志雄(高雄)", "田邱添(高雄)", "黃世緯(高雄)", "甘俊山(台南)", "鍾正發(台南)", "郭仲銘(台南)", "歐俊麟(台南)", "戴宏南(台南)",
         "詹貴宏(台南)", "蔡青和(台南)", "張士偉(出差)"};

        public static string[] lotteryCountList = new string[5]{"1", "2", "3", "4", "5"};

        public static string nextLine = "\n";
        public static string label = "label";
        public static string author = "Powered by ETVG RD4 SW Rex && Jim(App)";

        public static string databasePath = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= ../../Record.mdb";
        public static string selectCommand = "SELECT 獎項,中獎人 FROM record";
        public static string deleteCommand = "DELETE FROM record";

        public static string messagebox_warning_title = "注意";
        public static string messagebox_information_title = "通知";
        public static string messagebox_error_title = "錯誤";

        public static string normal_background_music = "../../Music/Happy.mp3";
        public static string selecting_background_music = "../../Music/Beat.mp3";
        public static string winner_background_music = "../../Music/Colonel_Bogey_March.mp3";
        public static string turn_on_backgrond_music = "開啟背景音樂";
        public static string turn_off_backgrond_music = "關閉背景音樂";

        public static string turn_off_lottery_program = "確定要關閉抽獎程式?";
        public static string lottery_error1 = "已經沒有人可供抽獎了！"; 
        public static string lottery_error2 = "抽獎次數大於可抽獎的人數了！";

        public static string prizeItemsDuplicate = "已經抽過了\n是否再抽一次?";
        public static string resetList = "中獎名單內已有先前紀錄，開始抽獎會將先前紀錄清除\n請問是否開始抽獎?";
        public static string keep_record_start_lottery = "中獎名單內已有紀錄，請問是否延續先前紀錄?";

        public static string ipAddress = "本機有使用的 IP 位址為: \n";
        public static string socket_service_turn_on_success = "遠端控制功能已成功開啟！\n\n";
        public static string start_lottery_keyword = "start";
        public static string connect_error = "請確認電腦網路是否開啟並且與手機連線";
    }
}
