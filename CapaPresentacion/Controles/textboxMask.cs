using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Controles
{
    public partial class textboxMask : MaskedTextBox
    {
        private Color _BorderColor;
        private Color _FocusColor;
        private const int WM_PAINT = 0xF;

        public textboxMask()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        [CategoryAttribute("Appearance")]
        public Color BorderColor
        {
            get { return _BorderColor; }
            set { _BorderColor = value; }
        }

        [CategoryAttribute("Appearance")]
        public Color FocusColor
        {
            get { return _FocusColor; }
            set { _FocusColor = value; }
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

        private void textboxMask_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
