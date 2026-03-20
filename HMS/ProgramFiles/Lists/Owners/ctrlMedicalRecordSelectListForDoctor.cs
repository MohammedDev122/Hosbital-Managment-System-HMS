using HMS.Lists.Bases.LogsAndRec.PatientLogs;
using HosbitalBussinessLayer;
using HosbitalBussinessLayer.Logs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Lists.Others.Employee
{
    public partial class ctrlMedicalRecordSelectListForDoctor : ctrlMedicalRecordBaseList
    {
        public ctrlMedicalRecordSelectListForDoctor()
        {
            InitializeComponent();
            Showing = clsViews.enShowing.enInfoEmployeeOwner;
            ID = -1;
            ItemsToBeAddedToContextMenu();
        }
       public class info
        {
            public int RecordID;
            public int PatientID;
            public info(int RecordID,int PatientID)
            {
                this.RecordID = RecordID;
                this.PatientID = PatientID;
            }

        }
        public event EventHandler<info> OnIdSelected;
        void SelectInfo(int RecordID,int PatientID)
        {

            OnIdSelected?.Invoke(this,new info(RecordID, PatientID));

        }
        override protected void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int RecordID = Convert.ToInt32(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value);
            int PatientID = Convert.ToInt32(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[2].Value);
            if (MessageBox.Show($"You Selected {RecordID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                SelectInfo(RecordID,PatientID);
            }
        }
        private void ctrlMedicalRecordListForDoctor_Load(object sender, EventArgs e)
        {
            FullData=clsMedicalRecords.GetAllRecords(Showing, ID);
            BS.DataSource = FullData;
            DGV1.DataSource = BS; 
            refreshDataGrid();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
