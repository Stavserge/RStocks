﻿using System;
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

        public Form1()
        {
            InitializeComponent();
            CatRepository.GetCategories(null);
        }
    }
}