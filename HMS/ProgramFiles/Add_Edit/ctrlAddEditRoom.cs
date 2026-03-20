using HMS.Lists.Others.Employee;
using HosbitalBussinessLayer.Logs;
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
using HosbitalBussinessLayer.DerivedTables;

namespace HMS.Add_Edit
{
    public partial class ctrlAddEditRoom : ctrlAddEditBase
    {
        public ctrlAddEditRoom()
        {
            InitializeComponent();
        }

     

        
        protected void FilRoomInfo(int RoomID)
        {
            clsOperationRoom Room = clsOperationRoom.FindRoomByID(RoomID);
            lblID.Text = Convert.ToString(ID);
            txtRoomNum.Text=Room.RoomNum;
         
        }

        override protected void FillInfo(int ID)
        {
            clsOperationRoom Room = clsOperationRoom.FindRoomByID(ID);

            if (ID != -1)
            {
                if (Room != null)
                {

                    setAddEdit("Edit Room");
                    _Mode = enMode.enUpdate;
                    FilRoomInfo(Room.RoomID);
                  

                }
                else
                {
                    setAddEdit("Add New Room");
                    _Mode = enMode.enAddNew;

                }

            }
            if (ID == -1)
            {
                setAddEdit("Add New Room");
                _Mode = enMode.enAddNew;

                //new Record


            }






        }
        protected void AddNewRoom(clsOperationRoom Room)
        {
            Room.RoomNum =txtRoomNum.Text;
           
            if (Room.Save())
            {
                ID = Room.RoomID;
                FillInfo(ID);

            }
            else
            {
                MessageBox.Show(Room.FailCause.ToString(), "Error");
            }
        }

        protected void UpdateRoom(clsOperationRoom Room)
        {
            Room.RoomNum = txtRoomNum.Text;

            if (Room.Save())
            {
                FillInfo(Room.RoomID);

            }
            else
            {
                MessageBox.Show(Room.FailCause.ToString(), "Error");
            }
        }


         protected void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.enAddNew)
            {
                clsOperationRoom Operation = new clsOperationRoom();

                AddNewRoom(Operation);
            }
            else
            {

                clsOperationRoom Operation = clsOperationRoom.FindRoomByID(ID);
                UpdateRoom(Operation);
                FillInfo(Operation.RoomID);




            }
        }



        private void ctrlAddEditRoom_Load(object sender, EventArgs e)
        {

        }
    }
}
