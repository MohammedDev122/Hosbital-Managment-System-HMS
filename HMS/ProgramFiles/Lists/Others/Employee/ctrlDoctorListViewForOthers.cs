using HosbitalBussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HosbitalBussinessLayer.clsViews;

namespace HMS.Lists
{
    public partial class ctrlDoctorListViewForOthers : ctrlDoctorListViewBase
    {

        public ctrlDoctorListViewForOthers() 
        {


            InitializeComponent();
            Showing = clsViews.enShowing.enOther;
            FullData = clsDoctors.GetAll(Showing); ;
            BS.DataSource = FullData;
            DGV1.DataSource = BS;
        }
        private void ctrlDoctorListViewForOthers_Load(object sender, EventArgs e)
        {

        }
        public event EventHandler<int> OnSelectedID;

        void SelectID(int ID)
        {
            OnSelectedID?.Invoke(this, ID);

        }
        override protected void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int ID = Convert.ToInt32(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value);
            if (MessageBox.Show($"You Selected {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                SelectID(ID);
            }




        }
    }
}
