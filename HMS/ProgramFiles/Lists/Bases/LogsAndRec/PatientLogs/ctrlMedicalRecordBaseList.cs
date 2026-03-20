using HosbitalBussinessLayer;
using HosbitalBussinessLayer.Logs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Lists.Bases.LogsAndRec.PatientLogs
{
    public partial class ctrlMedicalRecordBaseList : ctrlReservationBaseList
    {
        public ctrlMedicalRecordBaseList()
        {
            InitializeComponent();
            FillCmbSearch();
            FillCmbState();

            Showing = clsViews.enShowing.enAdmin;
            ID = -1;
            FullData = clsMedicalRecords.GetAllRecords(Showing, ID);
            BS.DataSource = FullData;
            DGV1.DataSource = BS;





            
        }
        protected void FillCmbSearch()
        {

            cmbSearch.Items.Clear();
            cmbSearch.Items.Insert(0, "Patient Name");
            cmbSearch.Items.Insert(0, "Patient ID");
            cmbSearch.Items.Insert(0, "Record ID");
            cmbSearch.SelectedIndex = 0;

        }
        protected void FillCmbState()
        {

            cmbState.Items.Clear();
            cmbState.Items.Insert(0, "Cancelled");
            cmbState.Items.Insert(0, "Working");
            cmbState.Items.Insert(0, "All");
            cmbState.SelectedIndex = 0;

        }
        override protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (cmbSearch.SelectedIndex)
            {


                case (0):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int RecordID))
                    {
                        GetSearchFileter(($"CONVERT(RecordID, 'System.String') like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }


                    break;


                case (1):
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



                case (2):
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

        private void ctrlMedicalRecordBaseList_Load(object sender, EventArgs e)
        {
            refreshDataGrid();
        }
    }
}
