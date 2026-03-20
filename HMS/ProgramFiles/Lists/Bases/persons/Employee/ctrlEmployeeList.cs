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

namespace HMS
{
    public partial class ctrlEmployeeList : ctrlPersonList
    {
        protected string DepartmentFilter = "";
        protected string StateFilter = "";

        public ctrlEmployeeList()
        {
            InitializeComponent();

            FullData = clsEmployees.GetAll(clsViews.enShowing.enAdmin);
            BS.DataSource = FullData;
            DGV1.DataSource = FullData;
            cmbSearch.Items.Clear();
            cmbSearch.Items.Insert(0,"LastName");
            cmbSearch.Items.Insert(0,"FirstName");
            cmbSearch.Items.Insert(0,"EmployeeID");
            cmbSearch.SelectedIndex = 0;
            FillDebpartmentCMB();
            FillStateCMB();
        }
        void FillDebpartmentCMB()
        {

            cmbDepartment.Items.Clear();
            DataTable dt = clsDeparmtments.GetAllDepartments();
            cmbDepartment.Items.Add("All");
            foreach (DataRow dr in dt.Rows)
            {
                cmbDepartment.Items.Add(dr["DepartmentName"]);


            }
            cmbDepartment.SelectedIndex = 0;
        }
        void FillStateCMB()
        {

            cmbState.Items.Clear();
            cmbState.Items.Add("All");
            cmbState.Items.Add("Working");
            cmbState.Items.Add("Fired");

            cmbState.SelectedIndex = 0;
        }
        private void ctrlEmployee_Load(object sender, EventArgs e)
        {

        }

        override protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (cmbSearch.SelectedIndex)
            {


                case (0):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int PersonID))
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


                case (1):
                    if (!string.IsNullOrEmpty(txtSearch.Text))
                    {
                        GetSearchFileter(($"FirstName like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }
                    ;
                    break;

                case (2):
                    if (!string.IsNullOrEmpty(txtSearch.Text))
                   {
                        GetSearchFileter(($"LastName like '{txtSearch.Text}%'"));
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
            if (GenderFilter.Length > 0)
            {
                FilterString += GenderFilter;

            }
            if (searchFilter.Length > 0)
            {
                FilterString = AddAnd(FilterString);
                FilterString += searchFilter;

            }
            if (CountryFilter.Length > 0)
            {
                FilterString = AddAnd(FilterString);
                FilterString += CountryFilter;

            }
            if (DepartmentFilter.Length > 0)
            {
                FilterString = AddAnd(FilterString);
                FilterString += DepartmentFilter;

            }
            if (StateFilter.Length > 0)
            {
                FilterString = AddAnd(FilterString);
                FilterString += StateFilter;

            }


        }
        protected void GetDepartmentFilter(string Department)
        {

            if (Department != "'All'")
            {
                DepartmentFilter = $"DepartmentName ={Department}";

            }
            else
            {
                DepartmentFilter = "";
            }


        }
        protected void GetStateFilter(string State)
        {

            if (State != "'All'")
            {
                StateFilter = $"State ={State}";

            }
            else
            {
                StateFilter = "";
            }


        }
        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            string FixString="'"+cmb.SelectedItem.ToString()+"'";
            GetDepartmentFilter(FixString);
            refreshDataGrid();
        
        
        }

        private void cmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            string FixString = "'" + cmb.SelectedItem.ToString() + "'";
            GetStateFilter(FixString);
            refreshDataGrid();

        }
    }
}
