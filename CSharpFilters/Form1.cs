using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Windows.Forms.VisualStyles;
using System.Windows.Forms.DataVisualization.Charting;

namespace CSharpFilters
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Drawing.Bitmap m_Bitmap;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem FileLoad;
		private System.Windows.Forms.MenuItem FileSave;
		private System.Windows.Forms.MenuItem FileExit;
		private System.Windows.Forms.MenuItem FilterInvert;
		private System.Windows.Forms.MenuItem FilterGrayScale;
		private double Zoom = 1.0;
        private PictureBox pictureBox1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private PictureBox pictureBox2;
        private Button changePic;
        public Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private MenuItem menuItem3;
        private MenuItem FilterGamma;
        private MenuItem menuItem5;
        private MenuItem menuItem6;
        private MenuItem menuItem7;
        private MenuItem menuItem8;
        private GroupBox groupBox1;
        private GroupBox groupBox4;
        private GroupBox groupBox3;
        private GroupBox groupBox5;
        private GroupBox groupBox2;
        private GroupBox groupBox6;
        private MenuItem menuItem2;
        private IContainer components;
        private MenuItem menuItem9;
        private MenuItem menuItem10;
        private MenuItem menuItem11;
        public int[] first_his;

        public Form1()
		{
			InitializeComponent();

			m_Bitmap= new Bitmap(2, 2);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.FileLoad = new System.Windows.Forms.MenuItem();
            this.FileSave = new System.Windows.Forms.MenuItem();
            this.FileExit = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.FilterInvert = new System.Windows.Forms.MenuItem();
            this.FilterGrayScale = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.FilterGamma = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.changePic = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem4,
            this.menuItem3});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.FileLoad,
            this.FileSave,
            this.FileExit});
            this.menuItem1.Text = "Файл";
            // 
            // FileLoad
            // 
            this.FileLoad.Index = 0;
            this.FileLoad.Shortcut = System.Windows.Forms.Shortcut.CtrlL;
            this.FileLoad.Text = "Открыть";
            this.FileLoad.Click += new System.EventHandler(this.File_Load);
            // 
            // FileSave
            // 
            this.FileSave.Index = 1;
            this.FileSave.Text = "Сохранить";
            this.FileSave.Click += new System.EventHandler(this.File_Save);
            // 
            // FileExit
            // 
            this.FileExit.Index = 2;
            this.FileExit.Text = "Выход";
            this.FileExit.Click += new System.EventHandler(this.File_Exit);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 1;
            this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.FilterInvert,
            this.FilterGrayScale});
            this.menuItem4.Text = "Фильтры";
            // 
            // FilterInvert
            // 
            this.FilterInvert.Index = 0;
            this.FilterInvert.Text = "Негатив";
            this.FilterInvert.Click += new System.EventHandler(this.Filter_Invert);
            // 
            // FilterGrayScale
            // 
            this.FilterGrayScale.Index = 1;
            this.FilterGrayScale.Text = "Ч/Б";
            this.FilterGrayScale.Click += new System.EventHandler(this.Filter_GrayScale);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.FilterGamma,
            this.menuItem5,
            this.menuItem8,
            this.menuItem2,
            this.menuItem9,
            this.menuItem10,
            this.menuItem11});
            this.menuItem3.Text = "Преобразование";
            // 
            // FilterGamma
            // 
            this.FilterGamma.Index = 0;
            this.FilterGamma.Text = "Степенное преобразование";
            this.FilterGamma.Click += new System.EventHandler(this.Filter_Gamma);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 1;
            this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem6,
            this.menuItem7});
            this.menuItem5.Text = "Повышение резкости";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 0;
            this.menuItem6.Text = "Градиент";
            this.menuItem6.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 1;
            this.menuItem7.Text = "Лапласиан";
            this.menuItem7.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 2;
            this.menuItem8.Text = "Эквализация гистограммы";
            this.menuItem8.Click += new System.EventHandler(this.menuItem2_Click_1);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 3;
            this.menuItem2.Text = "Пороговый фильтр";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click_2);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 4;
            this.menuItem9.Text = "Дилатация";
            this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 5;
            this.menuItem10.Text = "Медианный фильтр";
            this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 18);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(1600, 900);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(553, 380);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(40, 81);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(51, 22);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(111, 81);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(52, 22);
            this.textBox2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "W";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "H";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "x";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(3, 18);
            this.pictureBox2.MaximumSize = new System.Drawing.Size(1600, 900);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(549, 380);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // changePic
            // 
            this.changePic.Dock = System.Windows.Forms.DockStyle.Top;
            this.changePic.Location = new System.Drawing.Point(3, 18);
            this.changePic.Margin = new System.Windows.Forms.Padding(0);
            this.changePic.Name = "changePic";
            this.changePic.Size = new System.Drawing.Size(1149, 25);
            this.changePic.TabIndex = 8;
            this.changePic.Text = "<-";
            this.changePic.UseVisualStyleBackColor = true;
            this.changePic.Click += new System.EventHandler(this.changePic_Click);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.PeachPuff;
            this.chart1.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Left;
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(3, 18);
            this.chart1.Margin = new System.Windows.Forms.Padding(0);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.IsVisibleInLegend = false;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            series3.SmartLabelStyle.Enabled = false;
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(469, 160);
            this.chart1.TabIndex = 9;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.Color.PeachPuff;
            this.chart2.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea4.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea4);
            this.chart2.Dock = System.Windows.Forms.DockStyle.Right;
            legend4.Name = "Legend1";
            this.chart2.Legends.Add(legend4);
            this.chart2.Location = new System.Drawing.Point(683, 18);
            this.chart2.Name = "chart2";
            series4.ChartArea = "ChartArea1";
            series4.IsVisibleInLegend = false;
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart2.Series.Add(series4);
            this.chart2.Size = new System.Drawing.Size(469, 160);
            this.chart2.TabIndex = 10;
            this.chart2.Text = "chart2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1161, 649);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox2);
            this.groupBox5.Controls.Add(this.groupBox3);
            this.groupBox5.Controls.Add(this.changePic);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(3, 199);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1155, 447);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(3, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(559, 401);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pictureBox2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.Location = new System.Drawing.Point(597, 43);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(555, 401);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.chart2);
            this.groupBox4.Controls.Add(this.chart1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 18);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1155, 181);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textBox1);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.textBox2);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(472, 18);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(211, 160);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 6;
            this.menuItem11.Text = "Эррозия";
            this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Moccasin;
            this.ClientSize = new System.Drawing.Size(1161, 649);
            this.Controls.Add(this.groupBox1);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Обработка Изображений";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		}

		private void File_Load(object sender, System.EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();

			openFileDialog.InitialDirectory = "c:\\" ;
			openFileDialog.Filter = "Bitmap files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg|All valid files (*.bmp/*.jpg)|*.bmp/*.jpg";
			openFileDialog.FilterIndex = 2 ;
			openFileDialog.RestoreDirectory = true ;

			if(DialogResult.OK == openFileDialog.ShowDialog())
			{
				m_Bitmap = (Bitmap)Bitmap.FromFile(openFileDialog.FileName, false);
				pictureBox1.Image = m_Bitmap;
                pictureBox1.Refresh();
                pictureBox2.Refresh();
                SetHistogram(1);
            }
            Get_ImgSIze();
        }

		private void File_Save(object sender, System.EventArgs e)
		{
            
            SaveFileDialog saveFileDialog = new SaveFileDialog();

			saveFileDialog.InitialDirectory = "c:\\" ;
			saveFileDialog.Filter = "Bitmap files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg|All valid files (*.bmp/*.jpg)|*.bmp/*.jpg" ;
			saveFileDialog.FilterIndex = 1 ;
			saveFileDialog.RestoreDirectory = true ;

			if(DialogResult.OK == saveFileDialog.ShowDialog())
			{
				m_Bitmap.Save(saveFileDialog.FileName);
			}
           
        }

        public void Get_ImgSIze()
        {
            textBox1.Text = m_Bitmap.Width.ToString();
            textBox2.Text = m_Bitmap.Height.ToString();
        }

        public void SetHistogram(int pos)
        {
            int[] mas = new int[256];
            if (pos == 1) {
                this.chart1.Invalidate();
                for (int i = 0; i < 256; i++)
                    mas[i] = i;
                first_his = BitmapFilter.Histogramm(m_Bitmap);

                this.chart1.Series["Series1"].Points.DataBindXY(mas, first_his);
            }
            if (pos == 2)
            {
                this.chart2.Invalidate();
                for (int i = 0; i < 256; i++)
                    mas[i] = i;
                this.chart2.Series["Series1"].Points.DataBindXY(mas, BitmapFilter.Histogramm((Bitmap)pictureBox2.Image));
            }

        }

		private void File_Exit(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void Filter_Invert(object sender, System.EventArgs e)
		{
                pictureBox2.Image = BitmapFilter.Invert(m_Bitmap);
                pictureBox2.Refresh();
                pictureBox2.Invalidate();
            SetHistogram(2);

        }

		private void Filter_GrayScale(object sender, System.EventArgs e)
		{
            pictureBox2.Image = BitmapFilter.GrayScale(m_Bitmap);
            pictureBox2.Refresh();
            pictureBox2.Invalidate();
            SetHistogram(2);
        }		

		private void Filter_Gamma(object sender, System.EventArgs e)
		{
			GammaInput dlg = new GammaInput();

			if (DialogResult.OK == dlg.ShowDialog())
			{
                pictureBox2.Image = BitmapFilter.Gamma(m_Bitmap, dlg.gams);
                pictureBox2.Refresh();
                pictureBox2.Invalidate();
                SetHistogram(2);
            }
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            RobertsInput dlg = new RobertsInput();

            if (DialogResult.OK == dlg.ShowDialog())
            {
                pictureBox2.Image = BitmapFilter.RobertsPic(m_Bitmap, dlg.gams);
                pictureBox2.Refresh();
                pictureBox2.Invalidate();
                SetHistogram(2);
            }
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = BitmapFilter.Laplacian3x3Filter(m_Bitmap, false);
            pictureBox2.Refresh();
            pictureBox2.Invalidate();
            SetHistogram(2);
        }

        private void changePic_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = pictureBox2.Image;
            pictureBox1.Refresh();
            pictureBox2.Image = null;
            pictureBox2.Invalidate();
            SetHistogram(1);
            this.chart2.Invalidate();
        }

        private void menuItem2_Click_1(object sender, EventArgs e)
        {
            pictureBox2.Image = BitmapFilter.equalizing(m_Bitmap);
            pictureBox2.Refresh();
            pictureBox2.Invalidate();
            SetHistogram(2);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            pictureBox2.Refresh();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void menuItem2_Click_2(object sender, EventArgs e)
        {
            TresholdInput dlg = new TresholdInput(this);

            if (DialogResult.OK == dlg.ShowDialog())
            {
                pictureBox2.Image = BitmapFilter.TresholdFilter(m_Bitmap, dlg.treshold);
                pictureBox2.Refresh();
                pictureBox2.Invalidate();
            }
        }

        private void menuItem9_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = BitmapFilter.Dilotation((Bitmap)pictureBox1.Image);
            pictureBox2.Refresh();
            pictureBox2.Invalidate();
            SetHistogram(2);
        }

        private void menuItem10_Click(object sender, EventArgs e)
        {
            MedianInput dlg = new MedianInput();

            if (DialogResult.OK == dlg.ShowDialog())
            {
                pictureBox2.Image = BitmapFilter.MedianFilter((Bitmap)pictureBox1.Image, dlg.gams);
                pictureBox2.Refresh();
                pictureBox2.Invalidate();
                SetHistogram(2);
            }
        }

        private void menuItem11_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = BitmapFilter.Errosion((Bitmap)pictureBox1.Image,3);
            pictureBox2.Refresh();
            pictureBox2.Invalidate();
            SetHistogram(2);
        }
    }
}

