using HosbitalBussinessLayer.DerivedTables;
using HosbitalBussinessLayer.Procedures;
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

namespace HMS.ViewInfo.ViewServicesInfo.ViewOperationInfo
{
    public partial class ctrlOperationInfo : ctrlServiceInfo
    {
        public ctrlOperationInfo()
        {
            InitializeComponent();
        }


        protected void EmptyOperationRec()
        {
            EmptyServiceRec();
            lblOperationID.Text = "_";
            lblMedicalRecordID.Text = "_";
            lblRoomID.Text = "_";

            lblRoomNum.Text = "_";

            LblSpecilization.Text = "_";
            lblOperationResult.Text = "_";
           


        }

        string _PrintOperationResult(clsOperations.enOperationResult result)
        {
            if (result == clsOperations.enOperationResult.enSucceded)
            {
                return "Succeded";
            }
            else if (result == clsOperations.enOperationResult.enFailed)
            {
                return "Failed";
            }
            else
            {
                return "Unkown";

            }

        }
        protected void FillOperationRec(clsOperations Operation)
        {
            clsServices service=clsServices.GetServiceInfoByID(Operation.ServiceID);
            FillServiceRec(service);
            lblOperationID.Text = Convert.ToString(Operation.OperationID);
            lblMedicalRecordID.Text = Convert.ToString(Operation.MedicalRecordID);
            lblRoomID.Text = Convert.ToString(Operation.OperationRoomID);

            lblRoomNum.Text = clsOperationRoom.FindRoomByID(Operation.OperationRoomID).RoomNum;

            LblSpecilization.Text =clsSpecilization.FindSpecilizationByID(Operation.SpecilizationID).SpecilizationName;
            lblOperationResult.Text =_PrintOperationResult(Operation.Result);



        }
        override protected void btnSearch_Click(object sender, EventArgs e)
        {
            int OperationID = -1;
            if (int.TryParse(Convert.ToString(txtSearch.Text), out int ID))
            {
                OperationID = ID;
                clsOperations Operation = clsOperations.GetOperationInfoByID(OperationID);
                if (Operation != null)
                {
                    FillOperationRec(Operation);
                }
                else
                {
                    EmptyOperationRec();
                }
            }

        }














        private void ctrlOperationInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
