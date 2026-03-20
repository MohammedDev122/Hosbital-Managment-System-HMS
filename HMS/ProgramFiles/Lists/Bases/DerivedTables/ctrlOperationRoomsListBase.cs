using HosbitalBussinessLayer.DerivedTables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Lists.Bases.DerivedTables
{
    public partial class ctrlOperationRoomsListBase : ctrlBaseDGV
    {
        public ctrlOperationRoomsListBase()
        {
            InitializeComponent();
            FillCmbSearch();
            FullData = clsOperationRoom.GetAllOperationRooms();
            BS.DataSource = FullData;
            DGV1.DataSource = BS;
        }
        protected void FillCmbSearch()
        {

            cmbSearch.Items.Clear();
            cmbSearch.Items.Insert(0, "Room Num");
            cmbSearch.Items.Insert(0, "Room ID");

            cmbSearch.SelectedIndex = 0;

        }
        override protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (cmbSearch.SelectedIndex)
            {


                case (0):
                    if (int.TryParse(Convert.ToString(txtSearch.Text), out int RoomID))
                    {
                        GetSearchFileter(($"CONVERT(OperationRoomID, 'System.String') like '{txtSearch.Text}%'"));
                        refreshDataGrid();
                    }
                    else
                    {
                        GetSearchFileter(($""));
                        refreshDataGrid();
                    }
                    break;


                case (1):
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

        private void ctrlOperationRoomsListBase_Load(object sender, EventArgs e)
        {

        }
    }
}
