using System;
using System.Drawing;

namespace Model
{
    public class ModelControl
    {
        // private static bool isRunning;
        public event EventHandler<ImgUpdatedEventArgs> ImgUpdated = delegate { };

        public void JudgeColor(string data)
        {
            // 画像情報をセット
            var imgInfo = new ImgInfo();
            switch (data)
            {
                case "赤":
                    imgInfo.colorText = "red";
                    imgInfo.color = Brushes.Red;
                    break;

                case "青":
                    imgInfo.colorText = "blue";
                    imgInfo.color = Brushes.Blue;
                    break;

                case "黄":
                    imgInfo.colorText = "yellow";
                    imgInfo.color = Brushes.Yellow;
                    break;
                default:
                    imgInfo.colorText = "対象外";
                    break;
            }
            // 画像を作成
            var imgManager = new ImgManager();
            var bitmap = imgManager.CreateImage(imgInfo);

            ImgUpdated(this,new ImgUpdatedEventArgs(data, bitmap));
        }
    }

    public class ImgUpdatedEventArgs : EventArgs
    {
        public string category { get;  private set; }
        public Bitmap Bitmap { get; }

        public ImgUpdatedEventArgs(string category, Bitmap bitmap)
        {
            this.category = category;
            Bitmap = bitmap;
        }
    }
}
