using System;
using cn.qingyuyu.yudesk.presenter;
using Gtk;

namespace cn.qingyuyu.yudesk.view
{
    public partial class MainWindow : Gtk.Window ,MainWindowInterface
    {
        private MainPresenter mp = null;
        public MainWindow() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            mp = new MainPresenter(this);
        }

        protected void OnTokenActionActivated(object sender, EventArgs e)
        {
            InputDialog id = new InputDialog();
            id.SetTitle("Input Token");
            id.SetInfoLabel("you can contact me tthhr@qingyuyu.cn");
            id.Run();
            mp.SetToken(id.GetText());
            id.Destroy();
           
        }

        protected void OnAboutActionActivated(object sender, EventArgs e)
        {
            AboutDialog ad = new AboutDialog
            {
                Title = "About",
                ProgramName = "YuDesk",
                Version = "1.0",
                Copyright = "@tthhr",
                Website = "https://github.com/tthhr/yudesk"
            };
            ad.Run();
            ad.Destroy();
        }
        protected override void OnDestroyed()
        {
            base.OnDestroyed();
            mp.exit();
            Environment.Exit(0);
        }

        public void SetInfoLabel(string s)
        {
            infoLabel.Text = s;
        }
    }
}
