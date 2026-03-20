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
    public partial class ctrlNurseReservationBase : ctrlReservationBaseList
    {
        public ctrlNurseReservationBase()
        {
            InitializeComponent();
            FillCmbSearch();
            Showing = clsViews.enShowing.enAdmin;
            ID = -1;
            FullData =clsNurseReservation.GetAllReservations(Showing,ID);
            BS.DataSource = FullData;
            DGV1.DataSource = FullData;
        }
        protected void FillCmbSearch()
        {

            cmbSearch.Items.Clear();
            cmbSearch.Items.Insert(0, "Nurse Name");
            cmbSearch.Items.Insert(0, "Nurse ID");
            cmbSearch.Items.Insert(0, "Service ID");
            cmbSearch.Items.Insert(0, "Reservation ID");
            cmbSearch.SelectedIndex = 0;

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
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int NurseID))
                    {
                        GetSearchFileter(($"CONVERT(NurseID, 'System.String') like '{txtSearch.Text}%'"));
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
                        GetSearchFileter(($"NurseName like '{txtSearch.Text}%'"));
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

        private void ctrlNurseReservationBase_Load(object sender, EventArgs e)
        {

        }
    }
}
