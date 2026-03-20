using HMS.Lists.Bases.LogsAndRec.PatientLogs;
using HosbitalBussinessLayer.Logs;
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

namespace HMS.Lists.Owners
{
    public partial class ctrlMedicalRecordListForDoctor : ctrlMedicalRecordBaseList
    {
        public ctrlMedicalRecordListForDoctor()
        {
            InitializeComponent();
            Showing = clsViews.enShowing.enInfoEmployeeOwner;
            ID = -1;
            ItemsToBeAddedToContextMenu();
        }
        
        override protected void ItemsToBeAddedToContextMenu()
        {

            ItemsInfo[] items = new ItemsInfo[] { new ItemsInfo("Canelle", cancelToolStripMenuItem1_Click) };
            AlterContextMenu.Invoke(this, items);


        }
      
        private void ctrlMedicalRecordListForDoctor_Load(object sender, EventArgs e)
        {
            FullData = clsMedicalRecords.GetAllRecords(Showing, ID);
            BS.DataSource = FullData;
            DGV1.DataSource = BS;
            refreshDataGrid();
        }

   
        private void cancelToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int RecordID))
            {
                if (MessageBox.Show("do you want to cancelle this record!", "notification", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    clsMedicalRecords medicalRecords = clsMedicalRecords.FindMedicalRecordByID(RecordID);
                    if (medicalRecords.State != clsMedicalRecords.enState.enCancelled)
                    {
                        medicalRecords.State = clsMedicalRecords.enState.enCancelled;
                        if (medicalRecords.Save())
                        {
                            MessageBox.Show("record cancelled", "info");
                            FullData = clsMedicalRecords.GetAllRecords(Showing, ID);
                            BS.DataSource = FullData;
                            DGV1.DataSource = BS;
                        }


                    }
                }
            }

        }
    
    }
}
