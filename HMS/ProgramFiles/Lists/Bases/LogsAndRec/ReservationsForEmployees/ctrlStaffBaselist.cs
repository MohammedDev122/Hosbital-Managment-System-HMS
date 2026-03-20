using HosbitalBussinessLayer;
using HosbitalBussinessLayer.Logs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Lists.Bases.LogsAndRec.ReservationsForEmployees
{
    public partial class ctrlStaffBaselist : ctrlReservationBaseList
    {
        string DepartmentFilter = "";
        public ctrlStaffBaselist()
        {
            InitializeComponent();
            FillCmbSearch();
            FillCmbDepartment();
            ID = -1;
            FullData = clsOperationStaff.GetAllOperationsStaff(ID);
            BS.DataSource = FullData;
            DGV1.DataSource = BS;





        }
        protected void FillCmbSearch()
        {

            cmbSearch.Items.Clear();
            cmbSearch.Items.Insert(0, "Room Num");
            cmbSearch.Items.Insert(0, "Employee Name");
            cmbSearch.Items.Insert(0, "Employee ID");
            cmbSearch.Items.Insert(0, "Operation ID");
            cmbSearch.Items.Insert(0, "Staff ID");
            cmbSearch.SelectedIndex = 0;

        }
        protected void FillCmbDepartment()
        {

            cmbDepartment.Items.Clear();
            cmbDepartment.Items.Insert(0, "Nursing");
            cmbDepartment.Items.Insert(0, "Doctor");
            cmbDepartment.Items.Insert(0, "All");
            cmbDepartment.SelectedIndex = 0;

        }
        override protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (cmbSearch.SelectedIndex)
            {


                case (0):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int StaffID))
                    {
                        GetSearchFileter(($"CONVERT(StaffID, 'System.String') like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }


                    break;


                case (1):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int OperationID))
                    {
                        GetSearchFileter(($"CONVERT(OperationID, 'System.String') like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }


                    break;

                case (2):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int EmployeeID))
                    {
                        GetSearchFileter(($"CONVERT(EmployeeID, 'System.String') like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }


                    break;

                case (3):
                    if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                    {
                        GetSearchFileter(($"EmployeeName like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }
                    break;
                case (4):
                    if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                    {
                        GetSearchFileter(($"RoomNum like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }

                    break;





            }

        }

        override protected void GetAllFileterResult()
        {

            FilterString = "";

            if (searchFilter.Length > 0)
            {
                FilterString = AddAnd(FilterString);
                FilterString += searchFilter;

            }
            if (StateFilter.Length > 0)
            {

                FilterString = AddAnd(FilterString);
                FilterString += StateFilter;


            }

            if (DepartmentFilter.Length > 0)
            {

                FilterString = AddAnd(FilterString);
                FilterString += DepartmentFilter;


            }


        }
        protected void GetDepartmentFilter(string Department)
        {

            if (Department != "'All'")
            {

                DepartmentFilter = $"Department = {Department}";


            }
            else
            {
                DepartmentFilter = "";
            }


        }
        private void ctrlStaffBaselist_Load(object sender, EventArgs e)
        {

        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            string FixedString = "'" + cmb.SelectedItem.ToString() + "'";
            GetDepartmentFilter(FixedString);
            refreshDataGrid();
        }
    }
}
