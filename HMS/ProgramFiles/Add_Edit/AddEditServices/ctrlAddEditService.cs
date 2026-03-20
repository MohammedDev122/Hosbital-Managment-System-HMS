using HosbitalBussinessLayer.DerivedTables;
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
using HosbitalBussinessLayer.Procedures;

namespace HMS.Add_Edit.AddEditServices
{
    public partial class ctrlAddEditService : ctrlAddEditBase
    {
        public ctrlAddEditService()
        {
            InitializeComponent();
            clsFillcmb.FillcmbcmbServiceState(cmbServiceState);
        }
       


     protected   string GetPaymentState(clsPayments.enPaymentStatus state)
        {

            switch (state)
            {

                case (clsPayments.enPaymentStatus.enPayed):
                    return "Payed";
                case (clsPayments.enPaymentStatus.enCancelled):
                    return "Cancelled";
                default:
                    return "bending";


            }
        }
        protected string GetServiceStatestring(clsServices.enState state)
        {

            switch (state)
            {

                case (clsServices.enState.enFinished):
                    return "Finished";
                case (clsServices.enState.enBending):
                    return "Bending";
                default:
                    return "Cancelled";


            }
        }
        protected clsServices.enState GetServiceState(string state)
        {

            switch (state)
            {

                case ("Finished"):
                    return clsServices.enState.enFinished;
                case ("Bending"):
                    return clsServices.enState.enBending;
                default:
                    return clsServices.enState.enCancelled;


            }
        }
        protected void FillServiceInfo(int ServiceID)
        {
            clsServices Service = clsServices.GetServiceInfoByID(ServiceID);
            lblID.Text = Convert.ToString(ID);
            dtpDate.Value = Service.ServiceStartDateTime.Date;
            dtpStartTime.Value=Service.ServiceStartDateTime;
            if (Service.ServiceEndTime != null)
            {
                lblEndTime.Text=Service.ServiceEndTime.ToString();
            }
            else
            {
                lblEndTime.Text = ".....";
            }
            cmbServiceState.SelectedIndex = cmbServiceState.Items.IndexOf(GetServiceStatestring(Service.State));
            clsPatients patients=clsPatients.FindByID(Service.PatientID);
            txtPatientID.Text = patients.PatientID.ToString();
            lblPatientName.Text=patients.FirstName+" "+patients.LastName;
            lblPatientPhone.Text=patients.Phone;
            lblPaymentID.Text=Service.PaymentID.ToString();
            lblPaymentState.Text=GetPaymentState(clsPayments.GetPaymentInfoByID(Service.PaymentID).status);
           





        }
        override protected void FillInfo(int ID)
        {
            clsServices Service = clsServices.GetServiceInfoByID(ID);

            if (ID != -1)
            {
                if (Service != null)
                {

                    setAddEdit("Edit Service");
                    _Mode = enMode.enUpdate;
                    FillServiceInfo(Service.ServiceID);
                    txtPatientID.ReadOnly = true;
                    btnSelectPatient.Visible = false;
                    //FillInfo

                }
                else
                {
                    setAddEdit("Add New Service");
                    _Mode = enMode.enAddNew;

                }

            }
            if (ID == -1)
            {
                setAddEdit("Add New Service");
                _Mode = enMode.enAddNew;
                //new Record


            }






        }
        protected void AddNewServices(clsServices Service)
        {
            Service.ServiceStartDateTime = new DateTime(dtpDate.Value.Year, dtpDate.Value.Month, dtpDate.Value.Day,
                dtpStartTime.Value.Hour, dtpStartTime.Value.Minute, dtpStartTime.Value.Second);
            Service.State= GetServiceState(cmbServiceState.SelectedItem.ToString());
            Service.PatientID=Convert.ToInt32(txtPatientID.Text);
           
            //if (Service.save())
            //{
            //    ID = Service.ServiceID;
            //    FillInfo(ID);

            //}
            //else
            //{
            //    MessageBox.Show(Service.Cause.ToString(), "Error");
            //}
        }
        protected void UpdateService(clsServices Services)
        {
            Services.ServiceStartDateTime = new DateTime(dtpDate.Value.Year, dtpDate.Value.Month, dtpDate.Value.Day,
                  dtpStartTime.Value.Hour, dtpStartTime.Value.Minute, dtpStartTime.Value.Second);
            Services.State = GetServiceState(cmbServiceState.SelectedItem.ToString());
            //if (Services.save())
            //{
            //    FillInfo(Services.ServiceID);

            //}
            //else
            //{
            //    MessageBox.Show(Services.Cause.ToString(), "Error");
            //}
        }

      virtual   protected void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.enAddNew)
            {
                clsServices Service = new clsServices();

                AddNewServices(Service);
            }
            else
            {

                clsServices Service = clsServices.GetServiceInfoByID(ID);
                UpdateService(Service);





            }
        }
     

        private void txtPatientID_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(Convert.ToString(txtPatientID.Text), out int PatientID))
            {
              clsPatients patient=  clsPatients.FindByID(PatientID);
                if (patient != null) { 
                lblPatientName.Text=patient.FirstName+"  "+patient.LastName;
                lblPatientPhone.Text=patient.Phone;
                
                }
                else
                {
                    lblPatientName.Text = ".....";
                    lblPatientPhone.Text = ".....";
                }

            }
            else
            {
                lblPatientName.Text = ".....";
                lblPatientPhone.Text = ".....";


            }
        }
        private void ctrlAddEditService_Load(object sender, EventArgs e)
        {

        }
        void FillPatientTextBox(int ID)
        {

            txtPatientID.Text = ID.ToString();



        }
        private void btnSelectPatient_Click(object sender, EventArgs e)
        {
            frmPatientSelectList frmPtientList = new frmPatientSelectList();
            frmPtientList.OnIDSelected = FillPatientTextBox;
            frmPtientList.MdiParent = clsMDIParent.MDIPARENT;
            frmPtientList.Dock = DockStyle.Fill;
            try
            {
                frmPtientList.Show();
            }
            catch { }
        }
    }
}
