using HosbitalBussinessLayer;
using HosbitalBussinessLayer.DerivedTables;
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

namespace HMS.ViewInfo.ViewServicesInfo
{
    public partial class ctrlServiceInfo : UserControl
    {
        public ctrlServiceInfo()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        protected void EmptyServiceRec()
        {

            lblServiceID.Text = "_";
            lblDate.Text = "_";
            lblStartTime.Text = "_";
           
                lblEndTime.Text = "_";
            
            lblPatientID.Text  = "_";
            lblPatientName.Text= "_";
            lblPaymentID.Text  = "_";
            lblPaymentAmmount.Text = "_";
            lblPaymentStatus.Text = "_";
            lblServiceType.Text = "_";
            lblServiceState.Text = "_";


        }

        string _PrintPaymentStatus(clsPayments.enPaymentStatus PaymentStatus)
        {
            if (PaymentStatus == clsPayments.enPaymentStatus.enPayed)
            {
                return "Payed";
            }
            else if (PaymentStatus == clsPayments.enPaymentStatus.enCancelled)
            {
                return "Cancelled";
            }
            else
            {
                return "Bending";

            }

        }
        string _PrintServiceStatus(clsServices.enState State)
        {
            if (State == clsServices.enState.enFinished)
            {
                return "Finished";
            }
            else if (State == clsServices.enState.enCancelled)
            {
                return "Cancelled";
            }
            else
            {
                return "Bending";

            }

        }
        protected void FillServiceRec(clsServices service)
        {

            lblServiceID.Text=Convert.ToString(service.ServiceID);
            lblDate.Text = Convert.ToString(service.ServiceStartDateTime.ToString("yyyy/MM/dd"));
            lblStartTime.Text = Convert.ToString(service.ServiceStartDateTime.ToString("hh:mm"));
            if (service.ServiceEndTime != null) {
                lblEndTime.Text = Convert.ToString(Convert.ToDateTime(service.ServiceEndTime).ToString("hh:mm"));
            }
            else
            {
                lblEndTime.Text = "_";
            }
            lblPatientID.Text = Convert.ToString(service.PatientID);
            clsPatients patient = clsPatients.FindByID(service.PatientID);
            lblPatientName.Text =patient.FirstName+" "+patient.LastName;
            lblPaymentID.Text = Convert.ToString(service.PaymentID);
            clsPayments payment=clsPayments.GetPaymentInfoByID(service.PaymentID);
            lblPaymentAmmount.Text = Convert.ToString(payment.PayedAmmount);
            lblPaymentStatus.Text =_PrintPaymentStatus(payment.status);
            lblServiceType.Text = clsServiceTypes.FindServiceTypeByID(service.ServiceTypeID).ServiceName;
            lblServiceState.Text = _PrintServiceStatus(service.State);


        }
       virtual protected void btnSearch_Click(object sender, EventArgs e)
        {
            int ServiceID = -1;
            if(int.TryParse(Convert.ToString(txtSearch.Text), out int ID))
            {
                ServiceID = ID;
                clsServices service=clsServices.GetServiceInfoByID(ServiceID);
                if (service != null) { 
                FillServiceRec(service);
                }
                else
                {
                    EmptyServiceRec();
                }
            }

        }
    }
}
