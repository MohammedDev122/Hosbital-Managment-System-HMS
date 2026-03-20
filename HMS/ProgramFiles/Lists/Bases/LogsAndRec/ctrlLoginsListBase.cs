using HosbitalBussinessLayer.Logs.SystemLoginsAndLogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Lists.Bases.LogsAndRec
{
    public partial class ctrlLoginsListBase : ctrlBaseDGV
    {
        string StatusFilter = "";
        public ctrlLoginsListBase()
        {
            InitializeComponent();
            FillCmbSearch();
            FillCmbSTatus();
            FullData =clsLogins.GetAllLogins();
            BS.DataSource = FullData;
            DGV1.DataSource = BS;



        }
        protected void FillCmbSearch()
        {

            cmbSearch.Items.Clear();
            cmbSearch.Items.Insert(0, "Employee ID");
            cmbSearch.Items.Insert(0, "Login Name");
            cmbSearch.Items.Insert(0, "Login ID");
            cmbSearch.SelectedIndex = 0;

        }
        protected void FillCmbSTatus()
        {

            cmbStatus.Items.Clear();
           cmbStatus.Items.Insert(0, "HaveAccess");
           cmbStatus.Items.Insert(0, "Denied");
           cmbStatus.Items.Insert(0, "All");
            cmbStatus.SelectedIndex = 0;

        }
        override protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (cmbSearch.SelectedIndex)
            {


                case (0):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int LoginID))
                    {
                        GetSearchFileter(($"CONVERT(LoginID, 'System.String') like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }
                    break;

                case (1):
                    if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                    {
                        GetSearchFileter(($"LoginName like '{txtSearch.Text}%'"));
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



            }

        }
        private void ctrlLoginsListBase_Load(object sender, EventArgs e)
        {

        }
        void GetStatusFilter(string Status)
        {
            StatusFilter = "";
            if (Status != "'All'")
            {
                StatusFilter = $"Status={Status}";

            }
            else
            {
                StatusFilter = "";
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
            if (StatusFilter.Length > 0)
            {

                FilterString = AddAnd(FilterString);
                FilterString += StatusFilter;

            }
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            string FixedString="'"+cmb.SelectedItem.ToString()+"'";
            GetStatusFilter(FixedString);
            refreshDataGrid();
        }
    }
}
