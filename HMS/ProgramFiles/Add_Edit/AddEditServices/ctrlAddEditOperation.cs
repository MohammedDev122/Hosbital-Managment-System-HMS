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
using HosbitalBussinessLayer.Logs;
using HMS.Lists.Others.Employee;

namespace HMS.Add_Edit.AddEditServices
{
    public partial class ctrlAddEditOperation : ctrlAddEditService
    {
        
            public ctrlAddEditOperation()
        {
            InitializeComponent();
            clsFillcmb.FillSpecilizationCMB(cmbSpecilization);
            clsFillcmb.FillcmbResult(cmbOperationResult);

        }
        int SignedMemberID = -1;

        public void SetSignedMember(int SignedMemberID)
        {
            this.SignedMemberID = SignedMemberID;

        }
        string GetResult(clsOperations.enOperationResult result)
        {
            switch (result) { 
            case(clsOperations.enOperationResult.enFailed):
                    return "Failed";
                    case(clsOperations.enOperationResult.enSucceded):
                    return "Succeded";
                default:
                    return "Unknown";
            
            
            
            
            
            
            } }
        protected void FillOperationInfo(int OperationID)
        {
            clsOperations Operation = clsOperations.GetOperationInfoByID(OperationID);
            lblID.Text = Convert.ToString(ID);

            txtMedicalRecordID.Text = Operation.MedicalRecordID.ToString();
            txtOperationRoomID.Text = Operation.OperationRoomID.ToString();
            cmbOperationResult.SelectedIndex = cmbOperationResult.Items.IndexOf(GetResult(Operation.Result));



            cmbSpecilization.SelectedIndex = cmbSpecilization.Items.IndexOf(clsSpecilization.FindSpecilizationByID(Operation.SpecilizationID).SpecilizationName);
        }

        override protected void FillInfo(int ID)
        {
            clsOperations Operation = clsOperations.GetOperationInfoByID(ID);

            if (ID != -1)
            {
                if (Operation != null)
                {

                    setAddEdit("Edit Operation");
                    _Mode = enMode.enUpdate;
                    FillServiceInfo(Operation.ServiceID);
                    FillOperationInfo(Operation.OperationID);
                    txtPatientID.ReadOnly = true;
                    btnSelectPatient.Visible = false;
                    cmbSpecilization.Enabled = false;
                    btnGetMedicalRecord.Enabled = false;
                    txtMedicalRecordID.Enabled = false;
                    btnOperationStaff.Enabled = true;
                    //FillInfo
                    if (Operation.State == clsOperations.enState.enCancelled)
                    {
                        btnOperationStaff.Enabled = false;
btnSave.Enabled = false;
                        btnOperationRoomList.Enabled = false;
                        cmbServiceState.Enabled = false;
                        txtOperationRoomID.Enabled = false;


                    }

                }
                else
                {
                    setAddEdit("Add New Operation");
                    _Mode = enMode.enAddNew;
                    btnOperationStaff.Enabled = false;

                }

            }
            if (ID == -1)
            {
                setAddEdit("Add New Operation");
                _Mode = enMode.enAddNew;
                btnOperationStaff.Enabled = false;

                //new Record


            }






        }
        protected void AddNewOperation(clsOperations Operation)
        {
            Operation.ServiceStartDateTime = new DateTime(dtpDate.Value.Year, dtpDate.Value.Month, dtpDate.Value.Day,
                dtpStartTime.Value.Hour, dtpStartTime.Value.Minute, dtpStartTime.Value.Second);
            Operation.State = GetServiceState(cmbServiceState.SelectedItem.ToString());
            if (int.TryParse(Convert.ToString(txtPatientID.Text), out int PatientID))
                Operation.PatientID = PatientID;
            if (int.TryParse(Convert.ToString(txtOperationRoomID.Text), out int OperationRoomID))
            {
                Operation.OperationRoomID = OperationRoomID;
            }
          
            Operation.SpecilizationID = clsSpecilization.FindSpecilizationByName(cmbSpecilization.SelectedItem.ToString()).SpecilizationID;
            if (int.TryParse(Convert.ToString(txtMedicalRecordID.Text), out int MedicalRecordID))
                Operation.MedicalRecordID = MedicalRecordID;
            if (int.TryParse(Convert.ToString(txtOperationRoomID.Text), out int RoomID))
                Operation.OperationRoomID = RoomID;
            if (Operation.SaveOperation())
            {
                ID = Operation.OperationID;
                FillInfo(ID);

            }
            else
            {
                MessageBox.Show(Operation.Cause.ToString(), "Error");
            }
        }

        clsOperations.enOperationResult GetOperationResult(string OperationResult)
        {

            switch (OperationResult) {

                case ("Failed"):

                    return clsOperations.enOperationResult.enFailed;
                case ("Succeded"):

                    return clsOperations.enOperationResult.enSucceded;
          
            default:
                    return clsOperations.enOperationResult.enUnknown;
            
            } }
        protected void UpdateOperation(clsOperations Operation)
        {
            Operation.ServiceStartDateTime = new DateTime(dtpDate.Value.Year, dtpDate.Value.Month, dtpDate.Value.Day,
                  dtpStartTime.Value.Hour, dtpStartTime.Value.Minute, dtpStartTime.Value.Second);
            Operation.State = GetServiceState(cmbServiceState.SelectedItem.ToString());
            if (!int.TryParse(Convert.ToString(txtOperationRoomID.Text),out int RoomID))
            {
                Operation.OperationRoomID =(RoomID);


            }
            Operation.SpecilizationID = clsSpecilization.FindSpecilizationByName(cmbSpecilization.SelectedItem.ToString()).SpecilizationID;
            Operation.Result = GetOperationResult(cmbOperationResult.SelectedItem.ToString());
            if (Operation.SaveOperation())
            {
                FillInfo(Operation.OperationID);

            }
            else
            {
                MessageBox.Show(Operation.Cause.ToString(), "Error");
            }
        }

        override protected void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.enAddNew)
            {
                clsOperations Operation = new clsOperations();

                AddNewOperation(Operation);
            }
            else
            {

                clsOperations Operation = clsOperations.GetOperationInfoByID(ID);
                UpdateOperation(Operation);
                FillInfo(Operation.OperationID);




            }
        }


        private void ctrlAddEditDiagnosis_Load(object sender, EventArgs e)
        {

        }
        void FillSelectedMedicalRecord(int ID)
        {
            txtMedicalRecordID.Text = ID.ToString();

        }
     
        bool _IsItMemberInOperation(int SignedMemberID)
        {


            DataTable dt = clsOperationStaff.GetAllStaffForOperation(Convert.ToInt32(lblID.Text));

            foreach (DataRow dr in dt.Rows) {

                if (Convert.ToInt32(dr["EmployeeID"]) == SignedMemberID)
                {
                    return true;
                }
            
            
            
            
            }
            return false;
        }
        private void cmbServiceState_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbServiceState.SelectedIndex == 1 && _Mode == enMode.enUpdate)
            {
                if (clsOperations.GetOperationInfoByID(ID).State != clsOperations.enState.enFinished)
                {
                   
                        if (_IsItMemberInOperation(SignedMemberID) )
                        {
                                        cmbOperationResult.Enabled = true;

                        }
                        else
                        {
                        cmbOperationResult.Enabled = false;

                        btnSave.Enabled = false;
                            MessageBox.Show("You Are Not Member in This Operation!", "Error");
                        }
                   
                }
            }
            else
            {
                cmbOperationResult.Enabled = false;
                btnSave.Enabled = true;
            }
        }
        private void ctrlAddEditOperation_Load(object sender, EventArgs e)
        {

        }
        bool CheckIfRecordisDoneByDoctor(int RecordID, int DoctorID)
        {
            DataTable dt = clsMedicalRecords.GetAllRecords(clsViews.enShowing.enInfoEmployeeOwner, DoctorID);
            foreach (DataRow dr in dt.Rows) {

                if (RecordID == Convert.ToInt32(dr["RecordID"])){

                    return true;    
                }
            
            
            }
            return false;
        }
        private void txtMedicalRecordID_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(Convert.ToString(lblID.Text), out int OperationID))
            {
                if (int.TryParse(Convert.ToString(txtMedicalRecordID.Text), out int id))
                {

                    clsMedicalRecords record = clsMedicalRecords.FindMedicalRecordByID(id);
                    if (record != null)
                    {
                        clsEmployees employee = clsEmployees.FindByID(SignedMemberID);
                        if (employee != null)
                        {
                            if (employee.DepartmentID == 9)
                            {
                                if (CheckIfRecordisDoneByDoctor(record.RecordID, clsEmployees.GetEmployeeRoleID(employee.EmplyeeID)))
                                {
                                    txtPatientID.Text = record.PatientID.ToString();
                                    clsPatients patient = clsPatients.FindByID(record.PatientID);
                                    lblPatientName.Text = patient.FirstName + " " + patient.LastName;
                                    lblPatientPhone.Text = patient.Phone;
                                    btnSave.Enabled = true;
                                }
                                else
                                {
                                    txtPatientID.Text = "............";
                                    lblPatientName.Text = "..............";
                                    lblPatientPhone.Text = "...........";
                                    btnSave.Enabled = false;
                                }
                            }
                            else
                            {
                                txtPatientID.Text = "............";
                                lblPatientName.Text = "..............";
                                lblPatientPhone.Text = "...........";
                                btnSave.Enabled = false;
                            }
                        }
                        else
                        {
                            txtPatientID.Text = "............";
                            lblPatientName.Text = "..............";
                            lblPatientPhone.Text = "...........";
                            btnSave.Enabled = false;
                        }


                    }
                    else
                    {
                        txtPatientID.Text = "............";
                        lblPatientName.Text = "..............";
                        lblPatientPhone.Text = "...........";
                        btnSave.Enabled = false;
                    }

                }
                else
                {
                    txtPatientID.Text = "............";
                    lblPatientName.Text = "..............";
                    lblPatientPhone.Text = "...........";
                    btnSave.Enabled = false;
                }
            }
            else
            {

                clsMedicalRecords record = clsMedicalRecords.FindMedicalRecordByID(Convert.ToInt32(txtMedicalRecordID.Text));

                txtPatientID.Text = record.PatientID.ToString();
                clsPatients patient = clsPatients.FindByID(record.PatientID);
                lblPatientName.Text = patient.FirstName + " " + patient.LastName;
                lblPatientPhone.Text = patient.Phone;
                btnSave.Enabled = true;
            }
        }
        void _FillRoomInfo(int RoomID) { 
        
        txtOperationRoomID.Text = RoomID.ToString();
        
        }
        private void btnOperationRoomList_Click(object sender, EventArgs e)
        {
            frmRoomsSelectList roomsSelectList = new frmRoomsSelectList();
            roomsSelectList.OnSelected = _FillRoomInfo;
            roomsSelectList.MdiParent = clsMDIParent.MDIPARENT;
            roomsSelectList.Dock = DockStyle.Fill;
            try
            {
                roomsSelectList.Show();
            }
            catch { }
            }
        void FillRecordAndPatientInfo(ctrlMedicalRecordSelectListForDoctor.info Info)
        {
            txtMedicalRecordID.Text=Convert.ToString(Info.RecordID);
            clsPatients Patient=clsPatients.FindByID(Info.PatientID);
            txtPatientID.Text=Convert.ToString(Patient.PatientID);
            lblPatientName.Text=Patient.FirstName+" "+Patient.LastName;


        }
        private void btnGetMedicalRecord_Click(object sender, EventArgs e)
        {
            if (clsEmployees.FindByID(SignedMemberID).DepartmentID == 9)
            {
                frmMedicalRecordSelectListForDoc frmMedRecListForDoc = new frmMedicalRecordSelectListForDoc(clsEmployees.GetEmployeeRoleID(SignedMemberID));
                frmMedRecListForDoc.Selected = FillRecordAndPatientInfo;
                frmMedRecListForDoc.MdiParent = clsMDIParent.MDIPARENT;
                frmMedRecListForDoc.Dock = DockStyle.Fill;
                try {
                    frmMedRecListForDoc.Show();
                }catch { }
                }
        }

        private void ctrlAddEditOperation_Load_1(object sender, EventArgs e)
        {
            if (SignedMemberID == -1)
            {
              
                
                    btnSave.Enabled = false;
                    btnGetMedicalRecord.Enabled = false;
                    txtMedicalRecordID.Enabled = false;
                
            }
            else
            {
                if (clsEmployees.FindByID(SignedMemberID) == null)
                {
                    btnSave.Enabled = false;
                    btnGetMedicalRecord.Enabled = false;
                    txtMedicalRecordID.Enabled = false;
                }
            }
        }

        private void btnOperationStaff_Click(object sender, EventArgs e)
        {
            frmAddEditStaffMember frmAddEditStaffMeb = new frmAddEditStaffMember(Convert.ToInt32(lblID.Text));
            frmAddEditStaffMeb.MdiParent = clsMDIParent.MDIPARENT;
            frmAddEditStaffMeb.Dock = DockStyle.Fill;
            try {
                frmAddEditStaffMeb.Show();
            }catch {}
            }
    }

}