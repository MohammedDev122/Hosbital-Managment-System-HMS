using HMS.Lists.Bases.Patient;
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

namespace HMS.Lists.Others.Patient
{
    public partial class ctrlPatientListViewForOthers : ctrlPatientListViewBase
    {
        public ctrlPatientListViewForOthers()
        {
            InitializeComponent();
            Showing = clsViews.enShowing.enOther;
            FullData = clsPatients.GetAll(Showing);
            BS.DataSource = FullData;
            DGV1.DataSource = FullData;
        }
        public event EventHandler<int> OnSelectedID;
       void  SelectID(int ID)
        {



            OnSelectedID?.Invoke(this, ID);



        }
        override protected void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int ID = Convert.ToInt32(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value);
         if (   MessageBox.Show($"You Selected {ID}","Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                SelectID(ID);
            }
        }

        private void ctrlPatientListViewForOthers_Load(object sender, EventArgs e)
        {
            DGV1.DataSource = FullData;


        }
    }
}
