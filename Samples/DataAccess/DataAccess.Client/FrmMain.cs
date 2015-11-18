using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EC;
namespace DataAccess.Client
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        private ProtoSyncClient mClient = new ProtoSyncClient("127.0.0.1");

        private void FrmMain_Load(object sender, EventArgs e)
        {
            cbEmployees.Items.Add(new Employee());
            foreach (Employee item in mClient.Send<IList<Employee>>(new EmployeeSearch()))
            {
                cbEmployees.Items.Add(item);
            }
            cbCustomers.Items.Add(new Customer());
            foreach (Customer item in mClient.Send<IList<Customer>>(new CustomerSearch()))
            {
                cbCustomers.Items.Add(item);
            }
            
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            OrderSearch os = new OrderSearch();
            if (cbCustomers.SelectedItem != null)
                os.CustomerID = ((Customer)cbCustomers.SelectedItem).CustomerID;
            if (cbEmployees.SelectedItem != null)
                os.EmployeeID = ((Employee)cbEmployees.SelectedItem).EmployeeID;
            gdOrder.DataSource = mClient.Send<IList<Order>>(os);
        }

        private void gdOrder_SelectionChanged(object sender, EventArgs e)
        {
            if (gdOrder.SelectedRows.Count > 0)
            {
                Order order = (Order)gdOrder.SelectedRows[0].DataBoundItem;
                GetDetail getdetail = new GetDetail();
                getdetail.OrderID = order.OrderID;
                gdDetail.DataSource = mClient.Send<IList<OrderDetail>>(getdetail);
            }
        }
    }
}
