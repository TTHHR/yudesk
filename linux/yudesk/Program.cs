using System;
using Gtk;
using cn.qingyuyu.yudesk.view;
namespace cn.qingyuyu.yudesk
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Application.Init();
            MainWindow win = new MainWindow();
            win.Show();
            Application.Run();
        }
    }
}
