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

namespace HMS.Lists
{
    public partial class ctrlDoctorListViewBase : ctrlEmployeeList
    {
        protected string SpecilizationFilter = "";
        public ctrlDoctorListViewBase()
        {

            InitializeComponent();

            cmbSearch.Items.Clear();
            cmbSearch.Items.Insert(0,"Last Name");
            cmbSearch.Items.Insert(0, "First Name");
            cmbSearch.Items.Insert(0, "Doctor ID");
            cmbSearch.SelectedIndex = 0;
            FullData = clsDoctors.GetAll(Showing);
BS.DataSource = FullData;
            DGV1.DataSource = FullData;
            FillSpecilizationcmb();
        }

        void FillSpecilizationcmb()
        {

            cmbSpecilization.Items.Clear();
            cmbSpecilization.Items.Add("All");
            DataTable dt = clsSpecilization.GetAllSpecilizations();
            foreach (DataRow dr in dt.Rows)
            {
                cmbSpecilization.Items.Add(dr["Specilization"]);
            }
            cmbSpecilization.SelectedIndex = 0;
        }


        override protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (cmbSearch.SelectedIndex)
            {


                case (0):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int EmployeeID))
                    {
                        GetSearchFileter(($"CONVERT(DoctorID, 'System.String') like '{txtSearch.Text}%'"));
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
        private void ctrlDoctorListViewForAdmin_Load(object sender, EventArgs e)
        {

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
            if (SpecilizationFilter.Length > 0) { 
            
            FilterString= AddAnd(FilterString);
                FilterString += SpecilizationFilter;
            
            }


        }

        protected void GetSpecilizationFilter(string Specilization)
        {

            if (Specilization != "'All'")
            {
                SpecilizationFilter=$" Specilization={Specilization}";

            }
            else
            {
                SpecilizationFilter = "";
            }



        }
        private void cmbSpecilization_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            string FixString="'"+cmb.SelectedItem.ToString()+"'";
            GetSpecilizationFilter(FixString);
            refreshDataGrid();
        }
    }
}
