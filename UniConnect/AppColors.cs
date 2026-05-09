using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace UniConnect
{
    public static class AppColors
    {
        // Brand reds (from Figma)
        public static readonly Color Primary = Color.FromArgb(139, 21, 56);   // #8B1538 - main red
        public static readonly Color PrimaryDark = Color.FromArgb(107, 15, 42);   // hover / pill bg
        public static readonly Color PrimaryLight = Color.FromArgb(196, 30, 58);   // accents
        public static readonly Color SidebarRed = Color.FromArgb(139, 21, 56);   // sidebar bg

        // Neutrals
        public static readonly Color Background = Color.FromArgb(248, 248, 248);
        public static readonly Color CardBg = Color.FromArgb(245, 245, 245);
        public static readonly Color Border = Color.FromArgb(224, 224, 224);
        public static readonly Color TextDark = Color.FromArgb(33, 33, 33);
        public static readonly Color TextMuted = Color.FromArgb(117, 117, 117);
        public static readonly Color TextFooter = Color.FromArgb(160, 160, 160);

        // Action colors (for grades: Passed / Failed / Pending later)
        public static readonly Color Success = Color.FromArgb(34, 139, 34);
        public static readonly Color Danger = Color.FromArgb(220, 38, 38);
        public static readonly Color Warning = Color.FromArgb(217, 119, 6);
    }
}