using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kelime_Öğren
{
    public partial class KelimeCrud : Form
    {
        public KelimeCrud()
        {
            InitializeComponent();
        }

        private void kelimeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.kelimeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.modelDataSet);

        }

        private void KelimeCrud_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'modelDataSet.Kelime' table. You can move, or remove it, as needed.
            this.kelimeTableAdapter.Fill(this.modelDataSet.Kelime);

        }
    }
}
