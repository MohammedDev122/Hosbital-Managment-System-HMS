using HMS.Lists.Bases.LogsAndRec.ReservationsForEmployees;
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

namespace HMS.Lists.Owners
{
    public partial class ctrlStaffForOperation : ctrlStaffBaselist
    {
        public ctrlStaffForOperation()
        {
            InitializeComponent();
            FillCmbSearch();
        }
        protected void FillCmbSearch()
        {

            cmbSearch.Items.Clear();
            cmbSearch.Items.Insert(0, "Employee Name");
            cmbSearch.Items.Insert(0, "Employee ID");
            cmbSearch.Items.Insert(0, "Operation ID");
            cmbSearch.Items.Insert(0, "Staff ID");
            cmbSearch.SelectedIndex = 0;

        }
        bool _CheckIfAlreadyExist(int EmployeeID)
        {
            DataTable dt =clsOperationStaff.GetAllOperationsStaff(ID);
            foreach(DataRow dr in dt.Rows)
            {

                if (Convert.ToInt32(dr["EmployeeID"])==EmployeeID)
                {




                    return true;
                }

            }
            return false;

        }
       
        public void AddNewStaffForOperation(object obj,int EmployeeID)
        {
            if (clsEmployees.GetEmployeeRoleID(EmployeeID) != -1)
            {
                if (!_CheckIfAlreadyExist(EmployeeID))
                {
                    clsOperationStaff Member = new clsOperationStaff();
                    Member.EmployeeID = EmployeeID;
                    Member.OperationID = ID;

                    if (Member.Save())
                    {
                        FullData = clsOperationStaff.GetAllOperationsStaff(ID);
                        BS.DataSource = FullData;
                        DGV1.DataSource = FullData;
                    }
                    else
                    {
                        MessageBox.Show($"{Member.Cause} {EmployeeID}", "error");
                    }
                }
                else
                {
                    MessageBox.Show($"employee With ID{EmployeeID} already Exists in this Operation!", "notification");
                }
            }
            else
            {
                MessageBox.Show($"employee With ID{EmployeeID} is not assigned as active employee in the system!", "notification");
            }

        }

        override protected void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int ID = Convert.ToInt32(DGV1.Rows[DGV1.SelectedCells[0].RowIndex].Cells[0].Value);
            if (MessageBox.Show($"You Want to remove staff member with {ID}", "Selected ID", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                if (clsOperationStaff.DeleteStaff(ID))
                {
                    FullData = clsOperationStaff.GetAllOperationsStaff(this.ID);
                    BS.DataSource = FullData;
                    DGV1.DataSource = BS;
                }

}




        }

        private void ctrlStaffForOperation_Load(object sender, EventArgs e)
        {
            FullData = clsOperationStaff.GetAllOperationsStaff(ID);
            BS.DataSource = FullData;
            DGV1.DataSource = BS;
        }
    }
}
