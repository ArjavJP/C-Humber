using System.Windows.Forms;

namespace Week10
{
    public partial class Form1 : Form
    {
        private List<Inventroy> inventory = new List<Inventroy>();
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadInventory()
        {
            inventory = InventoryDB.GetItems();
            UpdateListBox();
        }

        private void UpdateListBox()
        {
            lst_groc.Items.Clear();
            foreach (var item in inventory)
            {
                lst_groc.Items.Add($"{item.ItemNo} | {item.Description} | {item.Price:C}");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadInventory();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                inventory.Add(frm.NewItem);
                InventoryDB.SaveItems(inventory);
                UpdateListBox();
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if(lst_groc.SelectedIndex != -1)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this item?", "Delete Item", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int selectedIndex = lst_groc.SelectedIndex;
                    inventory.RemoveAt(selectedIndex);
                    InventoryDB.SaveItems(inventory);
                    UpdateListBox();
                }
            }
        }
    }
}
