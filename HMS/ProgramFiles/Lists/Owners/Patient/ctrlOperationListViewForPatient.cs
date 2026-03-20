using HMS.Lists.Bases.Services;
using HosbitalBussinessLayer;
using HosbitalBussinessLayer.Procedures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Lists.Owners.Patient
{
    public partial class ctrlOperationListViewForPatient : ctrlOperationListViewBase
    {
        public ctrlOperationListViewForPatient()
        {
            InitializeComponent();
            FillCmbSearch();
        }
        protected void FillCmbSearch()
        {

            cmbSearch.Items.Clear();
            cmbSearch.Items.Insert(0, "Room Num");
            cmbSearch.Items.Insert(0, "Payment ID");
            cmbSearch.Items.Insert(0, "Medical Record ID");
            cmbSearch.Items.Insert(0, "Operation ID");
            cmbSearch.SelectedIndex = 0;

        }

        private void ctrlOperationListViewForPatient_Load(object sender, EventArgs e)
        {
            Showing = clsViews.enShowing.enPatientOwner;
            FullData = clsOperations.GetAll(ID, Showing);
            BS.DataSource = FullData;
            DGV1.DataSource = BS;

        }

    }
}
