namespace CapaPresentacion
{
    partial class textboxAdv
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // textboxAdv
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Enter += new System.EventHandler(this.textboxAdv_Enter);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxAdv_KeyPress);
            this.Leave += new System.EventHandler(this.textboxAdv_Leave);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
