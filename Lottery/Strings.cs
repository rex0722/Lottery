using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery
{
    class Strings
    {
        public static string[] comboxItem = new string[25]
        {"抽獎1", "抽獎2", "抽獎3", "抽獎4", "抽獎5",
        "抽獎6", "抽獎7", "抽獎8", "抽獎9", "抽獎10",
        "加碼1", "加碼2", "加碼3", "加碼4", "加碼5",
        "加碼6", "加碼7", "加碼8", "加碼9", "加碼10",
        "加碼11", "加碼12", "加碼13", "加碼14", "加碼15"};

        public static string[] lotteryLabelText = new string[100]
        {"一元復始", "一路發財", "如有神助", "萬眾矚目", "事事順心", "事業興旺", "五福臨門",
        "六六大順", "出入平安", "十全十美", "升官發財", "合璧連珠", "吉慶有餘", "吉星高照",
        "吉祥如意", "吉祥富貴", "萬事亨通", "喜樂年年", "名花有主", "四季平安", "四季進財",
        "多福多壽", "大吉大利", "大展經綸", "大展鴻猷", "大業千秋", "大紅大紫", "天官賜福",
        "好事成雙", "富貴吉祥", "富貴安康", "富貴有餘", "平安順利", "年年有餘", "心想事成",
        "恭喜發財", "恭賀新喜", "招財進寶", "新年吉祥", "新年快樂", "新春吉祥", "新春如意",
        "新春快樂", "日日見財", "時來運轉", "步步高升", "歲歲平安", "福星高照", "福祿齊來",
        "花開富貴", "萬事吉祥", "萬事如意", "萬象更新", "蒸蒸日上", "諸事大吉", "諸事平安",
        "諸凡順遂", "諸運亨通", "豐衣足食", "財源廣進", "財源滾滾", "財運亨通", "身心長健",
        "身體健康", "迎春納福", "金玉滿堂", "金磚滿屋", "金豬吉祥", "金豬報喜", "金豬富貴",
        "金豬獻吉", "豬年亨通", "豬年富貴", "開春吉祥", "開春大吉", "闔家平安", "闔家團圓",
        "雙喜臨門", "飛黃騰達", "鴻圖大啟", "珠光寶氣", "胸有成竹", "前途似錦", "笑逐顏開",
        "掌上明珠", "青春永駐", "珠聯璧合", "神采飛揚", "鴻運當頭", "好運旺來", "名揚四海",
        "新春飛揚", "舉步迎春", "和氣致祥", "福隨春至", "富伴勤來", "春風及第", "四方來財",
        "八路進寶", "事事如意"};

        public static string[] lotteryCountList = new string[5]{"1", "2", "3", "4", "5"};

        public static string nextLine = "\n";
        public static string label = "label";
        public static string author = "Powered by ETVG RD4 SW Rex && Ian && Jim(App)";

        public static string databasePath = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= ../../Record.mdb";
        public static string selectCommand = "SELECT 獎項,中獎人 FROM record";
        public static string deleteCommand = "DELETE FROM record";

        public static string messagebox_warning_title = "注意";
        public static string messagebox_information_title = "通知";
        public static string messagebox_error_title = "錯誤";

        public static string normal_background_music = "../../Music/Happy.mp3";
        public static string selecting_background_music = "../../Music/Beat.mp3";
        public static string winner_background_music = "../../Music/Colonel_Bogey_March.mp3";

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
