using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Controles
{
    public partial class boton : Button
    {
        public boton()
        {
            InitializeComponent();

            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackColor = Color.FromArgb(15, 76, 100);
            this.FlatAppearance.BorderColor = Color.FromArgb(34, 174, 170);
            this.FlatAppearance.MouseDownBackColor = Color.FromArgb(34, 174, 170);
            this.FlatAppearance.MouseOverBackColor = Color.FromArgb(36, 187, 183);
            this.FlatAppearance.BorderSize = 0;
            this.ImageAlign = ContentAlignment.MiddleRight;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.UseVisualStyleBackColor = true;
        }
    }
}
