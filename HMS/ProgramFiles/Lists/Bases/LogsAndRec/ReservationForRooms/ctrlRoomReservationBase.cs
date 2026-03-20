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

namespace HMS.Lists.Bases.LogsAndRec.ReservationForRooms
{
    public partial class ctrlRoomReservationBase : ctrlReservationBaseList
    {
        public ctrlRoomReservationBase()
        {
            InitializeComponent();
            FillCmbSearch();
         FullData =clsOperationRoomReservation.GetAllReservations();
            BS.DataSource = FullData;
            DGV1.DataSource = FullData;

        }
        protected void FillCmbSearch()
        {

            cmbSearch.Items.Clear();
            cmbSearch.Items.Insert(0, "Room NUm");
            cmbSearch.Items.Insert(0, "Room ID");
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
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int RoomID))
                    {
                        GetSearchFileter(($"CONVERT(RoomID, 'System.String') like '{txtSearch.Text}%'"));
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
        private void ctrlRoomReservationBase_Load(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
