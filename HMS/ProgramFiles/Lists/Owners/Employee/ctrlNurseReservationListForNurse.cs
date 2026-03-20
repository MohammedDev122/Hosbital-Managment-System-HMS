using HMS.Lists.Bases.LogsAndRec.ReservationsForEmployees;
using HosbitalBussinessLayer.Logs;
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

namespace HMS.Lists.Owners.Employee
{
    public partial class ctrlNurseReservationListForNurse : ctrlNurseReservationBase
    {
        public ctrlNurseReservationListForNurse()
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
        private void ctrlNurseReservationListForNurse_Load(object sender, EventArgs e)
        {
            Showing = clsViews.enShowing.enInfoEmployeeOwner;
            FullData = clsNurseReservation.GetAllReservations(Showing,clsEmployees.GetEmployeeRoleID(ID));
            BS.DataSource = FullData;
            DGV1.DataSource = BS;
        }
    }
}
