using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace processlogger
{
    public partial class UserControl1: UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void l1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            b1.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            b2.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            l1.Anchor = (AnchorStyles.Top| AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
        }
    }
}
