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

namespace HMS.Lists.Bases.LogsAndRec.ReservationsForEmployees
{
    public partial class ctrlDoctorReservationListBase : ctrlReservationBaseList
    {
        protected string TypeFilter = "";
        public ctrlDoctorReservationListBase()
        {
            InitializeComponent();
            FillCmbSearch();
            FillCmbType();
            Showing = clsViews.enShowing.enAdmin;
            ID = -1;
            FullData = clsDoctorReservation.GetDoctorReservations(Showing,ID);
            BS.DataSource = FullData;
            DGV1.DataSource = BS;




        }
        protected void FillCmbSearch()
        {

            cmbSearch.Items.Clear();
            cmbSearch.Items.Insert(0, "Doctor Name");
            cmbSearch.Items.Insert(0, "Doctor ID");
            cmbSearch.Items.Insert(0, "Service ID");
            cmbSearch.Items.Insert(0, "Reservation ID");
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
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int ReservationID))
                    {
                        GetSearchFileter(($"CONVERT(ReservationID, 'System.String') like '{txtSearch.Text}%'"));
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
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int DoctorID))
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

                case (3):
                    if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                    {
                        GetSearchFileter(($"DoctorName like '{txtSearch.Text}%'"));
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

            if (TypeFilter.Length > 0)
            {

                FilterString = AddAnd(FilterString);
                FilterString += TypeFilter;


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


        private void ctrlDoctorReservationListBase_Load(object sender, EventArgs e)

        {

        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb=(ComboBox)sender;
            string FixedString="'"+cmb.SelectedItem.ToString() + "'";
            GetTypeFilter(FixedString);
            refreshDataGrid();
        }
    }
}
