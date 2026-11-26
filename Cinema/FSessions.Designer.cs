namespace Cinema
{
    partial class FSessions
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvSession = new System.Windows.Forms.DataGridView();
            this.lblmovieid = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSession)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSession
            // 
            this.dgvSession.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSession.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSession.Location = new System.Drawing.Point(0, 0);
            this.dgvSession.Name = "dgvSession";
            this.dgvSession.Size = new System.Drawing.Size(800, 450);
            this.dgvSession.TabIndex = 0;
            this.dgvSession.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSession_CellContentClick);
            // 
            // lblmovieid
            // 
            this.lblmovieid.AutoSize = true;
            this.lblmovieid.Location = new System.Drawing.Point(738, 9);
            this.lblmovieid.Name = "lblmovieid";
            this.lblmovieid.Size = new System.Drawing.Size(50, 13);
            this.lblmovieid.TabIndex = 1;
            this.lblmovieid.Text = "ID Movie";
            this.lblmovieid.Visible = false;
            // 
            // FSessions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblmovieid);
            this.Controls.Add(this.dgvSession);
            this.Name = "FSessions";
            this.Text = "Выбор сессии";
            this.Load += new System.EventHandler(this.FSessions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSession)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSession;
        public System.Windows.Forms.Label lblmovieid;
    }
}