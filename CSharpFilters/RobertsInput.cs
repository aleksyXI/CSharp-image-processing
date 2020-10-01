using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CSharpFilters
{
    /// <summary>
    /// Summary description for RobertsInput.
    /// </summary>
    public class RobertsInput : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button OK;
		private System.Windows.Forms.Label label2;
        private TrackBar trackBar1;
        private Label label1;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

		public RobertsInput()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			OK.DialogResult = System.Windows.Forms.DialogResult.OK;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.OK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(137, 92);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(102, 45);
            this.OK.TabIndex = 1;
            this.OK.Text = "ОК";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(125, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Введите степень детектирования";
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(12, 35);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(364, 45);
            this.trackBar1.TabIndex = 4;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(252, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "0";
            // 
            // RobertsInput
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(388, 149);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OK);
            this.Name = "RobertsInput";
            this.Text = "Степень детектирования";
            this.Load += new System.EventHandler(this.RobertsInput_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void RobertsInput_Load(object sender, System.EventArgs e)
		{
		
		}

		public double gams
        {
			get 
			{
				return (Convert.ToDouble(trackBar1.Value));
			}
			set{ trackBar1.Value = (Convert.ToInt32(value)); }
		}

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();

        }
    }
}
