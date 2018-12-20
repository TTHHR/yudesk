using System;
namespace cn.qingyuyu.yudesk.view
{
    public partial class InputDialog : Gtk.Dialog
    {
        public InputDialog()
        {
            this.Build();
        }

        protected void OnButtonOkClicked(object sender, EventArgs e)
        {
        }
        public void SetTitle(String s)
        {
            this.Title = s;
        }
        public void SetInfoLabel(String s)
        {
            infoLabel.Text = s;
        }
        public  String GetText()
        {
            if (textEdit.Text != null)
                return textEdit.Text;
            return "";
        }
    }
}
