using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.ProgramFiles.Panels.MainPanel
{
    public partial class mainPanelBase : ctrlPanelBase
    {
       protected int _ID = -1;
        public mainPanelBase()
        {
            InitializeComponent();
        }
        UserControl _Panel;
        Button _button;
        public void SetID(int id) { 
        
        _ID = id;
        }
        public void SetSupPanel(UserControl userControl, Button button) { 
        
        
        
        _Panel = userControl;
        
        _button = button;
        
        }
        private void mainPanelBase_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void Extened(object sender, EventArgs e)
        {
           this.Size = this.MaximumSize;
            

        }
        public EventHandler ShrinkSub;
        private void btnShrink_Click(object sender, EventArgs e)
        {
            if (this.Size != this.MaximumSize)
            {
                this.Size = this.MaximumSize;



            }  
            else
            {
                this.Size = this.MinimumSize;

                ShrinkSub?.Invoke(this, new EventArgs());

            }
        }
    }
}
