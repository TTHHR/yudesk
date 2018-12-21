using cn.qingyuyu.yudesk.presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cn.qingyuyu.yudesk.view
{
    public partial class MainWindow : Form,MainWindowInterface
    {
        NotifyIcon notifyicon;
        Icon ico;
        private MainPresenter mp = null;
       
      
        public MainWindow()
        {
            InitializeComponent();
            mp = new MainPresenter(this);

            //创建NotifyIcon对象 
             notifyicon = new NotifyIcon();
            //创建托盘图标对象 
            ico = (Icon)(Resource.ResourceManager.GetObject("ico"));//获取图标
             //创建托盘菜单对象 
            ContextMenu notifyContextMenu = new ContextMenu();
            MenuItem exitItem = new MenuItem("Exit");
            exitItem.Click += ExitItem_Click;
            notifyContextMenu.MenuItems.Add(exitItem);
            notifyicon.ContextMenu = notifyContextMenu;


            notifyicon.Text = "YuDesk";
            notifyicon.MouseDoubleClick+=notifyicon_DoubleClick;
        }

        private void ExitItem_Click(object sender, EventArgs e)
        {
            mp.exit();
            notifyicon.Visible = false;
            Environment.Exit(0);
            
        }

        private void onTokenItemClick(object sender, EventArgs e)
        {
            InputDialog id = new InputDialog();
            id.setTile("input your token");
            id.setInfoLabel("you can contact tthhr@qingyuyu.cn");
            id.ShowDialog();
            mp.SetToken(id.getText());
        }

        private void onAboutItemClick(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        public void SetInfoLabel(string s)
        {
            infoLabel.Invoke(new Action(()=> { infoLabel.Text = s; notifyicon.Text =s; }));
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            mp.exit();

            base.OnFormClosed(e);
        }

        private void MainWindow_SizeChanged(object sender, EventArgs e)
        {
            //判断是否选择的是最小化按钮 
            if (WindowState == FormWindowState.Minimized)
            {
                //托盘显示图标等于托盘图标对象 
                //注意notifyIcon1是控件的名字而不是对象的名字 
                notifyicon.Icon = ico;
                //隐藏任务栏区图标 
                this.ShowInTaskbar = false;
                //图标显示在托盘区 
                notifyicon.Visible = true;
            }
        }
        private void notifyicon_DoubleClick(object sender, EventArgs e)
        {
            //判断是否已经最小化于托盘 
            if (WindowState == FormWindowState.Minimized)
            {
                //还原窗体显示 
                WindowState = FormWindowState.Normal;
                //激活窗体并给予它焦点 
                this.Activate();
                //任务栏区显示图标 
                this.ShowInTaskbar = true;
                //托盘区图标隐藏 
                notifyicon.Visible = false;
            }
        }

    }
}
