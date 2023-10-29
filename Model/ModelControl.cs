using System;

namespace Model
{
    public class ModelControl
    {
        // private static bool isRunning;
        public event EventHandler<CategoryUpdatedEventArgs> CategoryUpdated = delegate { };

        static void Main(string[] args)
        {
            // Recevier();
        }

        //public static void Recevier()
        //{
        //    while (isRunning)
        //    {
        //        // 終了条件をチェック
        //        if (false)
        //        {
        //            isRunning = false;
        //        }

        //        JudgeCategory();
        //    }
        //}


        //public void Stop()
        //{
        //    isRunning = false;
        //}

        public void JudgeCategory(string data)
        {
            string ret = string.Empty;
            switch (data)
            {
                case "トマト":
                    ret = "野菜";
                    break;

                case "リンゴ":
                    ret = "くだもの";
                    break;

                case "鶏":
                    ret = "お肉";
                    break;
            }
            CategoryUpdated(this,new CategoryUpdatedEventArgs(ret));
        }
    }

    public class CategoryUpdatedEventArgs
    {
        public string category { get; set; }

        public CategoryUpdatedEventArgs(string category)
        {
            this.category = category;
        }
    }
}
