using HMS.Buttons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.ProgramFiles.Buttons
{
    public partial class ctrlSubPanelButton : ctrlButtonBase
    {
        public ctrlSubPanelButton()
        {
            InitializeComponent();
        }
        UserControl _control;
        public void SetThePanel(UserControl control)
        {
            _control = control;
        }
   public EventHandler ExtendMainPanel;
        void OpenAndCloseSupPanel(UserControl control)
        {
            if (control.Size != control.MaximumSize)
            {
                control.Size = control.MaximumSize;
                button1.BackgroundImage = Properties.Resources.arrow;
                ExtendMainPanel.Invoke(this, EventArgs.Empty);

            }
            else
            {
                control.Size = control.MinimumSize;
                button1.BackgroundImage = Properties.Resources.images__2_;

            }

        }
        public  void Shrink(object sender, EventArgs e)
        {
            if (_control != null)
            {
                _control.Size = _control.MinimumSize;
                button1.BackgroundImage = Properties.Resources.images__2_;
            }

        }
        override protected void button1_Click(object sender, EventArgs e)
        {
            if (_control != null)
                OpenAndCloseSupPanel(_control);

        }
        private void ctrlSubPanelButton_Load(object sender, EventArgs e)
        {

        }
    }
}
