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

    public partial class ctrlBaseDGV : UserControl
    {
        protected string FilterString = "";
        protected string searchFilter = "";
        protected int ID = -1;
        public clsViews.enShowing Showing=clsViews.enShowing.enAdmin;
        protected DataTable FullData=new DataTable();
        protected BindingSource BS = new BindingSource();

        public ctrlBaseDGV()
        {
            InitializeComponent();
            AlterContextMenu = AlterContextMenuStrip;
        }
      
       virtual protected void ItemsToBeAddedToContextMenu()
        {

        }
        virtual protected void txtSearch_TextChanged(object sender, EventArgs e)
        { }
        protected class ItemsInfo
        {
            public string ItemName;
            public EventHandler onClick;
public ItemsInfo(string ItemName,EventHandler OnClick)
            {
                this.ItemName = ItemName;
                this.onClick = OnClick;
            }



        }
        protected EventHandler<ItemsInfo[]> AlterContextMenu;

        void AlterContextMenuStrip(object obj, ItemsInfo[] Items)
        {
            contextMenuStrip1.Items.Clear();
            foreach(var item in Items)
            {

              
                contextMenuStrip1.Items.Add(new ToolStripMenuItem(item.ItemName));
                contextMenuStrip1.Items[contextMenuStrip1.Items.Count - 1].Click += item.onClick;
            
            
            }



        }

        virtual protected void refreshDataGrid()
        {
            if (DGV1.Columns.Count > 0)
            {
                GetAllFileterResult();
                BS.Filter = FilterString;

                DGV1.DataSource = FullData;
            }
        }
        protected void GetSearchFileter(string Search)
        {
            if (!string.IsNullOrEmpty(Search))
            {
                searchFilter = Search;
            }
            else
            {
                searchFilter = "";
            }
        }
            virtual  protected void GetAllFileterResult() {

            FilterString = "";
            if (searchFilter.Length > 0)
            {
                FilterString = AddAnd(FilterString);
                FilterString += searchFilter;
            }
        }
        public void SetID(int ID)
        {
            this.ID = ID;
        }
        protected string AddAnd(string text)
        {
            if (text.Length > 0)
            {
                return text += " And ";
            }
            return text;
        }
        private void ctrlBaseDGV_Load(object sender, EventArgs e)
        {

        }

        virtual protected void DGV1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("Hi");

        }

        virtual protected void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        virtual protected void DGV1_DragOver(object sender, DragEventArgs e)
        {

        }

        virtual protected void DGV1_DragLeave(object sender, EventArgs e)
        {
        }

        virtual protected void DGV1_DragDrop(object sender, DragEventArgs e)
        {

        }

        virtual protected void DGV1_DragEnter(object sender, DragEventArgs e)
        {

        }
        protected void RefillDGV(DataTable dt)
        {
            FullData = dt;
            BS.DataSource = FullData;
            DGV1.DataSource = dt;



        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        public Action CloseForm;
        protected void button1_Click(object sender, EventArgs e)
        {
            CloseForm?.Invoke();
        }
    }
}
