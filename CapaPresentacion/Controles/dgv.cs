using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Controles
{
    public partial class dgv : DataGridView
    {

        public dgv()
        {
            InitializeComponent();

            this.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Light", 14, FontStyle.Regular);
        }

        public dgv(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

    }
}
