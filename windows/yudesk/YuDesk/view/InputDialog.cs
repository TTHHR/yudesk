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
    public partial class InputDialog : Form
    {
        public InputDialog()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void okButtonClick(object sender, EventArgs e)
        {


        Hide();
    }
    public void setTile(String s)
    {
        this.Text = s;
    }

    public void setInfoLabel(String s)
    {
        infoLabel.Text = s;
    }
    public String getText()
    {
        Dispose();
        return textBox.Text.ToString();
    }
}
}
