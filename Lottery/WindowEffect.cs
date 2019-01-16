using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lottery
{
    class WindowEffect
    {
        public const Int32 AW_HOR_POSITIVE = 0x00000001; // 從左到右打開窗口
        public const Int32 AW_HOR_NEGATIVE = 0x00000002; // 從右到左打開窗口
        public const Int32 AW_VER_POSITIVE = 0x00000004; // 從上到下打開窗口
        public const Int32 AW_VER_NEGATIVE = 0x00000008; // 從下到上打開窗口
        public const Int32 AW_CENTER = 0x00000010; //若使用了AW_HIDE，則使窗口向内重叠；若未使用AW_HIDE，則使窗口向外擴展。
        public const Int32 AW_HIDE = 0x00010000; //隐藏窗口。
        public const Int32 AW_ACTIVATE = 0x00020000; //啟用窗口。在使用了AW_HIDE後不要使用這個。
        public const Int32 AW_SLIDE = 0x00040000; //使用滑動效果。當使用AW_CENTER时，這效果就被忽略。
        public const Int32 AW_BLEND = 0x00080000; //使用淡出效果。只有當hWnd為頂層窗口的时候才可以使用此效果。
        [DllImport("user32.dll", CharSet = CharSet.Auto)]

        public static extern bool AnimateWindow(
            IntPtr hwnd, // handle to window
          int dwTime, // duration of animation
          int dwFlags // animation type
          );
    }
}
