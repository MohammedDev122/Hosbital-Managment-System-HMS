using HMS.Lists.Admins;
using HosbitalBussinessLayer.DerivedTables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS
{
    public partial class frmRoomsSelectList : Form
    {
        public frmRoomsSelectList()
        {
            InitializeComponent();
            ctrlOperationRoomForOthers1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            this.Close();
        }
        public Action<int> OnSelected;
        private void ctrlOperationRoomForOthers1_Load(object sender, EventArgs e)
        {

        }

        private void frmRoomsSelectList_Load(object sender, EventArgs e)
        {

        }

        private void ctrlOperationRoomForOthers1_onIDSelected(object sender, int e)
        {
            if (e != -1)
            {
                if (clsOperationRoom.FindRoomByID(e) != null) {

                    OnSelected?.Invoke(e);
                    this.Close();
                
                }
            }

        }
    }
}
