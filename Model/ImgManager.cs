using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class ImgManager
    {
        public Bitmap CreateImage(ImgInfo imgInfo) {
            const int fontSize = 30;
            const string fontFamily = "MS UI Gothic";
            const int width = 300;  // 画像の幅
            const int height = 300; // 画像の高さ
            const int margin = 30; // マージン

            Bitmap bmp = new Bitmap(width, height);
            {
                using (Graphics g = Graphics.FromImage(bmp))
                using (Font fnt = new Font(fontFamily, fontSize))
                // using (Pen bluePen = new Pen(imgInfo.color, margin))
                // using (Pen grayPen = new Pen(Color.Gainsboro, margin))
                {
                    // 背景
                    Rectangle bgRect = new Rectangle(0, 0, width, height);
                    g.FillRectangle(Brushes.White, bgRect);

                    // 枠
                    // grayPen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
                    // Rectangle bdsRect = new Rectangle(margin + 6, margin + 6, width - margin * 2, height - margin * 2);
                    // g.DrawRectangle(grayPen, bdsRect);
                    // bluePen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
                    Rectangle bdRect = new Rectangle(margin, margin, width - margin * 2, height - margin * 2);
                    // g.DrawRectangle(bluePen, bdRect);
                    g.FillRectangle(imgInfo.color, bdRect);

                    // テキスト
                    g.DrawString(imgInfo.colorText, fnt, Brushes.White, bdRect);
                }
                return bmp;
            }
        }
    }

    class ImgInfo
    {
        public string colorText { get;  set; }
        public Brush color { get;  set; }

    }
}
