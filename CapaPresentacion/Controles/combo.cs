using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Controles
{
    public partial class combo : ComboBox
    {
        private const int WM_PAINT = 0xF;
        private Color _BorderColor;

        public combo()
        {
            base.DropDownStyle = ComboBoxStyle.DropDownList;
            base.FlatStyle = FlatStyle.Flat;

            InitializeComponent();
        }

        public combo(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        [CategoryAttribute("Appearance")]
        public Color BorderColor
        {
            get { return _BorderColor; }
            set { _BorderColor = value; }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_PAINT)
            {
                Graphics g = this.CreateGraphics();
                Rectangle Cliente = this.ClientRectangle;

                g.DrawRectangle(new Pen(_BorderColor), 0, 0,
                   Cliente.Width - 1, Cliente.Height - 1);

                g.Dispose();
            }
        }
    }
}
