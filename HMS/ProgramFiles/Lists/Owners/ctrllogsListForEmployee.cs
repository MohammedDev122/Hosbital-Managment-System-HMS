using HMS.Lists.Bases.LogsAndRec;
using HosbitalBussinessLayer.Logs.SystemLoginsAndLogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Lists.Owners
{
    public partial class ctrllogsListForEmployee : ctrlLogsListBase
    {
        public ctrllogsListForEmployee()
        {
            InitializeComponent();


        }

        private void ctrllogsListForEmployee_Load(object sender, EventArgs e)
        {

            RefillDGV(clsLogs.GetAllEmployeeLogs(ID));
        }
    }
}
