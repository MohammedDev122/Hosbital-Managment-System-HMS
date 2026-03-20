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
    public partial class ctrlPharmacist : ctrlEmployeeInfo
    {
        public ctrlPharmacist()
        {
            InitializeComponent();
        }

        private void ctrlPharmacist_Load(object sender, EventArgs e)
        {

        }
        protected void EmptyAllPharmacistRec()
        {
            EmptyAllEmployeeRec();
            lblPharmacistID.Text = "-";


        }
        protected void FillPharmacistInfo(clsPharmacists Pharmacist)
        {
            lblPharmacistID.Text=Convert.ToString(Pharmacist.PharmacistID);

            FillEmployeeInfo(clsEmployees.FindByID(Pharmacist.EmplyeeID));




        }
        override protected void lblSearch_Click(object sender, EventArgs e)
        {
            int PharmacistID = -1;
            if (int.TryParse(Convert.ToString(txtSearch.Text), out int ID))
            {

                PharmacistID = ID;
                clsPharmacists Pharmacist = clsPharmacists.FindByID(PharmacistID);
                if (Pharmacist != null)
                {



                    FillPharmacistInfo(Pharmacist);





                }
                else { EmptyAllPharmacistRec(); }
            }
        }

    }
}
