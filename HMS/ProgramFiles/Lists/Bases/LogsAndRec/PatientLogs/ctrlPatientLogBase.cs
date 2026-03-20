using HosbitalBussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Lists.Bases.LogsAndRec.PatientLogs
{
    public partial class ctrlPatientLogBase : ctrlReservationBaseList
    {
        string TypeFilter = "";
        public ctrlPatientLogBase()
        {
            InitializeComponent();
            FillCmbType();
            FillCmbSearch();
            FullData =clsPatientLogs.GetAllLogs();
            BS.DataSource = FullData;
            DGV1.DataSource = BS;
        }

        private void ctrlPatientLogBase_Load(object sender, EventArgs e)
        {
            switch (cmbSearch.SelectedIndex)
            {


                case (0):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int LogID))
                    {
                        GetSearchFileter(($"CONVERT(LogID, 'System.String') like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }


                    break;


                case (1):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int ServiceID))
                    {
                        GetSearchFileter(($"CONVERT(ServiceID, 'System.String') like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }


                    break;

                case (2):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int PatientID))
                    {
                        GetSearchFileter(($"CONVERT(PatientID, 'System.String') like '{txtSearch.Text}%'"));
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
                        GetSearchFileter(($"PatientName like '{txtSearch.Text}%'"));
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
        protected void FillCmbSearch()
        {

            cmbSearch.Items.Clear();
            cmbSearch.Items.Insert(0, "Patient Name");
            cmbSearch.Items.Insert(0, "Patient ID");
            cmbSearch.Items.Insert(0, "Service ID");
            cmbSearch.Items.Insert(0, "Log ID");
            cmbSearch.SelectedIndex = 0;

        }
        protected void FillCmbType()
        {

            cmbType.Items.Clear();
            cmbType.Items.Insert(0, "Operation");
            cmbType.Items.Insert(0, "Diagnosis");
            cmbType.Items.Insert(0, "All");
            cmbType.SelectedIndex = 0;

        }
        override protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (cmbSearch.SelectedIndex)
            {


                case (0):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int LogID))
                    {
                        GetSearchFileter(($"CONVERT(LogID, 'System.String') like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }


                    break;
                case (1):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int ServiceID))
                    {
                        GetSearchFileter(($"CONVERT(ServiceID, 'System.String') like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }


                    break;

                case (2):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int PatientID))
                    {
                        GetSearchFileter(($"CONVERT(PatientID, 'System.String') like '{txtSearch.Text}%'"));
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
                        GetSearchFileter(($"PatientName like '{txtSearch.Text}%'"));
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
        protected void GetTypeFilter(string Type)
        {

            if (Type != "'All'")
            {

                TypeFilter = $"Type = {Type}";


            }
            else
            {
                TypeFilter = "";
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

            if (TypeFilter.Length > 0)
            {

                FilterString = AddAnd(FilterString);
                FilterString += TypeFilter;


            }


        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            string FixedString = "'" + cmb.SelectedItem.ToString() + "'";
            GetTypeFilter(FixedString);
            refreshDataGrid();
        }
    }
}
