using DeliveryService.DataBase;
using DeliveryService.Forms;

namespace DeliveryService
{
    public partial class MainForm : Form
    {
        DatabaseManager DatabaseManager;
        public MainForm()
        {
            DatabaseManager = DatabaseManager.GetInstance();
            InitializeComponent();
        }

        private void CreateOrderButton_Click(object sender, EventArgs e)
        {
            Form form = new AddOrderForm();
            form.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
