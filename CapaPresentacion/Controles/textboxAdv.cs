using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class textboxAdv : TextBox
    {
        private Boolean isnumeric;
        private Color _BorderColor;
        private Color _FocusColor;
        private const int WM_PAINT = 0xF;

        public textboxAdv()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public Boolean Numerico
        {
            get { return isnumeric; }
            set { isnumeric = value; }
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

        private void textboxAdv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
            else
            {
                if (Numerico == true)
                {
                    if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                    {
                        e.Handled = true;
                        return;
                    }
                }
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

        private void textboxAdv_Enter(object sender, EventArgs e)
        {
            this.BackColor = FocusColor;

            if (FocusColor.IsEmpty == false)
            {
                this.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                this.ForeColor = Color.White;
            }
        }

        private void textboxAdv_Leave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            this.ForeColor = Color.FromArgb(55, 71, 79);
        }
    }
}
