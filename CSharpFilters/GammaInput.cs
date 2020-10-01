using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CSharpFilters
{
	/// <summary>
	/// Summary description for GammaInput.
	/// </summary>
	public class GammaInput : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button Cancel;
		private System.Windows.Forms.Button OK;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox gam;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public GammaInput()
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
            this.Cancel = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gam = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(197, 59);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(85, 39);
            this.Cancel.TabIndex = 0;
            this.Cancel.Text = "Выход";
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(15, 56);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(85, 39);
            this.OK.TabIndex = 1;
            this.OK.Text = "ОК";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(194, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 42);
            this.label1.TabIndex = 2;
            this.label1.Text = "Введите значение между .2 и 5.0";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Гамма";
            // 
            // gam
            // 
            this.gam.Location = new System.Drawing.Point(88, 21);
            this.gam.Name = "gam";
            this.gam.Size = new System.Drawing.Size(100, 20);
            this.gam.TabIndex = 4;
            this.gam.Text = "textBox1";
            // 
            // GammaInput
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(316, 110);
            this.Controls.Add(this.gam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.Cancel);
            this.Name = "GammaInput";
            this.Text = "Ввод гаммы";
            this.Load += new System.EventHandler(this.GammaInput_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void GammaInput_Load(object sender, System.EventArgs e)
		{
		
		}

		public double gams
        {
			get 
			{
				return (Convert.ToDouble(gam.Text));
			}
			set{ gam.Text = value.ToString();}
		}
    }
}
