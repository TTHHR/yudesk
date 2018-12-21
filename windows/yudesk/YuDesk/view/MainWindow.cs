using cn.qingyuyu.yudesk.presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cn.qingyuyu.yudesk.view
{
    public partial class MainWindow : Form,MainWindowInterface
    {
        private MainPresenter mp = null;
        public MainWindow()
        {
            InitializeComponent();
            mp = new MainPresenter(this);
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
            infoLabel.Invoke(new Action(()=> { infoLabel.Text = s; }));
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            mp.exit();

            base.OnFormClosed(e);
        }
    }
}
