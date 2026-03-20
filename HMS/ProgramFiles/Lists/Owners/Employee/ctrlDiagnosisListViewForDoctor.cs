using HMS.Lists.Bases.Services;
using HosbitalBussinessLayer.Procedures;
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

namespace HMS.Lists.Owners.Employee
{
    public partial class ctrlDiagnosisListViewForDoctor : ctrlDiagnosisListViewBase
    {
        public ctrlDiagnosisListViewForDoctor()
        {
            InitializeComponent();
            FillCmbSearch();
            //RearangeDGV();
            ItemsToBeAddedToContextMenu();
        }
        override protected void ItemsToBeAddedToContextMenu()
        {

            ItemsInfo[] items = new ItemsInfo[] { new ItemsInfo("Edit", editToolStripMenuItem_Click)};
            AlterContextMenu.Invoke(this, items);


        }
        void RefillThisDGV()
        {
            RefillDGV(clsDiagnosis.GetAll(clsEmployees.GetEmployeeRoleID(this.ID), clsViews.enShowing.enInfoEmployeeOwner));

        }
        override protected void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
            {
                if (MessageBox.Show($"You want to edit This Diagnosis with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    frmAddEditDiagnosis frmDiagnosis = new frmAddEditDiagnosis(ID,this.ID);
                    frmDiagnosis.MdiParent = clsMDIParent.MDIPARENT;
                    frmDiagnosis.Dock = DockStyle.Fill;
                    frmDiagnosis.ReloadCallingDGV = RefillThisDGV;

                    frmDiagnosis.Show();


                }
            }
        }


        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (int.TryParse(Convert.ToString(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value), out int ID))
            {
                if (MessageBox.Show($"You want to edit This Diagnosis with ID: {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    frmAddEditDiagnosis frmDiagnosis = new frmAddEditDiagnosis(ID, this.ID);
                    frmDiagnosis.MdiParent = clsMDIParent.MDIPARENT;
                    frmDiagnosis.Dock = DockStyle.Fill;
                    frmDiagnosis.ReloadCallingDGV = RefillThisDGV;

                    frmDiagnosis.Show();


                }
            }
        }

    

        private void ctrlDiagnosisListViewForPatient_Load(object sender, EventArgs e)
        {

        }



        protected void FillCmbSearch()
        {

            cmbSearch.Items.Clear();
            cmbSearch.Items.Insert(0, "Medical Record ID");
            cmbSearch.Items.Insert(0, "Payment ID");
            cmbSearch.Items.Insert(0, "Patient ID");
            cmbSearch.Items.Insert(0, "Diagnosis ID");
            cmbSearch.SelectedIndex = 0;

        }

        override protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (cmbSearch.SelectedIndex)
            {


                case (0):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int ServiceID))
                    {
                        GetSearchFileter(($"CONVERT(DiagnosisID, 'System.String') like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else if (string.IsNullOrEmpty(txtSearch.Text))
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }

                    break;


                case (1):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int PatientID))
                    {
                        GetSearchFileter(($"CONVERT(PatientID, 'System.String') like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else if (string.IsNullOrEmpty(txtSearch.Text))
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }

                    break;

                case (2):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int PaymentID))
                    {
                        GetSearchFileter(($"CONVERT(PaymentID, 'System.String') like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else if (string.IsNullOrEmpty(txtSearch.Text))
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }

                    break;
             

                case (3):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int MedicalRecordID))
                    {
                        GetSearchFileter(($"CONVERT(MedicalRecordID, 'System.String') like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else if (string.IsNullOrEmpty(txtSearch.Text))
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }

                    break;




            }

        }


        private void cmbSpecilization_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void ctrlDiagnosisListViewForDoctor_Load(object sender, EventArgs e)
        {
            Showing = clsViews.enShowing.enInfoEmployeeOwner;
            FullData = clsDiagnosis.GetAll(clsEmployees.GetEmployeeRoleID(this.ID), Showing);
            BS.DataSource = FullData;
            DGV1.DataSource = BS;
        }
    }
}
