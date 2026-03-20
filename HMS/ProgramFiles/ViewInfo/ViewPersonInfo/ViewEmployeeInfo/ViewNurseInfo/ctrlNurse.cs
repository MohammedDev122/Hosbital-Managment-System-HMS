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

namespace HMS
{
    public partial class ctrlNurse : ctrlEmployeeInfo
    {
        public ctrlNurse()
        {
            InitializeComponent();
        }
        protected void EmptyAllNurseRec()
        {
            EmptyAllEmployeeRec();
            lblNurseID.Text = "_";

        }
        protected void FillNurseInfo(clsNurses Nurses)
        {
            clsEmployees Employee = clsEmployees.FindByID(Nurses.EmplyeeID);

            FillEmployeeInfo(Employee);
            lblNurseID.Text = Convert.ToString(Nurses.NurseID);




        }


        override protected void lblSearch_Click(object sender, EventArgs e)
        {
            int NurseID = -1;
            if (int.TryParse(Convert.ToString(txtSearch.Text), out int ID))
            {
                NurseID = ID;
                clsNurses Employee = clsNurses.FindByID(NurseID);
                if (Employee != null)
                {
                    FillNurseInfo(Employee);
                }
                else
                {
                    EmptyAllNurseRec();
                }

            }

        }


            private void ctrlNurse_Load(object sender, EventArgs e)
            {

            }
        }
    } 
