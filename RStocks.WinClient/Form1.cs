using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RStocks.Model.Repositories;

namespace RStocks.WinClient
{
    public partial class Form1 : Form
    {
        protected CategoryRepository CatRepository = Program.RepositoryFactory.GetCategoryRepository();
        
        protected int? parentId = null;
        protected List<int?> breadCrumbs;

        private void Move()
        {
            dataGridView1.DataSource = null;
            
            var r = CatRepository.GetCategories(parentId);
            dataGridView1.DataSource = r;
        }

        public Form1()
        {
            InitializeComponent();
            breadCrumbs = new List<int?>();
            Move();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            breadCrumbs.Add(parentId);
            parentId = (int?)dataGridView1.CurrentRow.Cells["Id"].Value;
            Move();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (breadCrumbs.Count > 0)
            {
                parentId = breadCrumbs[breadCrumbs.Count - 1];
                breadCrumbs.RemoveAt(breadCrumbs.Count - 1);
            }
            Move();
        }
    }
}
