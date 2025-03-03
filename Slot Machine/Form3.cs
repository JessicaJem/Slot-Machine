using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Slot_Machine
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection(@"Data Source = databasecoins.db; Version = 3; FailIfMissing = True");
            con.Open();
            string query = "SELECT* from COINS";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            DataTable dt = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;

        }

    }
}
