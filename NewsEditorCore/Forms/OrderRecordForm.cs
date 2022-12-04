using Atom.VectorSiteLibrary.Models;
using System.Windows.Forms;

namespace AssistantCore.Forms
{
    public partial class OrderRecordForm : Form
    {
        private Order _order;
        public Order Order
        {
            get => _order;
        }

        public OrderRecordForm()
        {
            InitializeComponent();

            _order = new Order();
        }

        public OrderRecordForm(Order order, bool isEdit = false) : this()
        {
            _order = order;

            if (_order != null)
            {
                txtId.Text = $"{_order.Id}";
                dtpDate.Value = _order.Date;
                txtTitle.Text = _order.Label;
            }

            if (isEdit)
            {
                txtId.Enabled = false;
                dtpDate.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;

            _order.Id = long.Parse(txtId.Text);
            _order.Label = txtTitle.Text;
            _order.Date = dtpDate.Value;

            this.Close();
        }
    }
}
