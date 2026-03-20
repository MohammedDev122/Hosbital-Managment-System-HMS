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

namespace HMS.Lists.Owners.Employee
{
    public partial class ctrlDoctorReservationForDoctorList : ctrlDoctorReservationListBase
    {
        public ctrlDoctorReservationForDoctorList()
        {
            InitializeComponent();
            FillCmbSearch();

        }
        protected void FillCmbSearch()
        {

            cmbSearch.Items.Clear();
            cmbSearch.Items.Insert(0, "Service ID");
            cmbSearch.Items.Insert(0, "Reservation ID");
            cmbSearch.SelectedIndex = 0;

        }
        private void ctrlDoctorReservationForDoctorList_Load(object sender, EventArgs e)
        {
            Showing = clsViews.enShowing.enInfoEmployeeOwner;
            FullData=clsDoctorReservation.GetDoctorReservations(Showing,ID);
            BS.DataSource = FullData;
            DGV1.DataSource = BS;
        }
    }
}
