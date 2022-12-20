namespace Kursovaya
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbMain = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.speedRocket = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_Debug = new System.Windows.Forms.CheckBox();
            this.bt_StepDebug = new System.Windows.Forms.Button();
            this.tb_updateSpeed = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedRocket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_updateSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMain
            // 
            this.pbMain.BackgroundImage = global::Kursovaya.Properties.Resources.space;
            this.pbMain.Location = new System.Drawing.Point(1, 2);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(807, 446);
            this.pbMain.TabIndex = 0;
            this.pbMain.TabStop = false;
            this.pbMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pbMain_Paint);
            this.pbMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbMain_MouseClick);
            this.pbMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pbMain_MouseDoubleClick);
            this.pbMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbMain_MouseMove);
            this.pbMain.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pbMain_MouseWheel);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(805, 2);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(234, 446);
            this.txtLog.TabIndex = 1;
            this.txtLog.Text = "";
            // 
            // speedRocket
            // 
            this.speedRocket.Location = new System.Drawing.Point(1, 454);
            this.speedRocket.Minimum = 4;
            this.speedRocket.Name = "speedRocket";
            this.speedRocket.Size = new System.Drawing.Size(104, 45);
            this.speedRocket.TabIndex = 3;
            this.speedRocket.Value = 4;
            this.speedRocket.Scroll += new System.EventHandler(this.speedRocket_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 454);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Скорость ракеты";
            // 
            // cb_Debug
            // 
            this.cb_Debug.AutoSize = true;
            this.cb_Debug.Location = new System.Drawing.Point(247, 454);
            this.cb_Debug.Name = "cb_Debug";
            this.cb_Debug.Size = new System.Drawing.Size(102, 19);
            this.cb_Debug.TabIndex = 5;
            this.cb_Debug.Text = "Debug режим";
            this.cb_Debug.UseVisualStyleBackColor = true;
            this.cb_Debug.CheckedChanged += new System.EventHandler(this.cb_Debug_CheckedChanged);
            // 
            // bt_StepDebug
            // 
            this.bt_StepDebug.Location = new System.Drawing.Point(355, 454);
            this.bt_StepDebug.Name = "bt_StepDebug";
            this.bt_StepDebug.Size = new System.Drawing.Size(110, 23);
            this.bt_StepDebug.TabIndex = 6;
            this.bt_StepDebug.Text = "Следующий шаг";
            this.bt_StepDebug.UseVisualStyleBackColor = true;
            this.bt_StepDebug.Click += new System.EventHandler(this.bt_StepDebug_Click);
            // 
            // tb_updateSpeed
            // 
            this.tb_updateSpeed.Location = new System.Drawing.Point(482, 454);
            this.tb_updateSpeed.Maximum = 6;
            this.tb_updateSpeed.Name = "tb_updateSpeed";
            this.tb_updateSpeed.Size = new System.Drawing.Size(104, 45);
            this.tb_updateSpeed.TabIndex = 7;
            this.tb_updateSpeed.Value = 6;
            this.tb_updateSpeed.Scroll += new System.EventHandler(this.tb_updateSpeed_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(592, 458);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Скорость перемещения";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 529);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_updateSpeed);
            this.Controls.Add(this.bt_StepDebug);
            this.Controls.Add(this.cb_Debug);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.speedRocket);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.pbMain);
            this.Name = "Form1";
            this.Text = "Игра про ракету и частицы";
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedRocket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_updateSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pbMain;
        private System.Windows.Forms.Timer timer1;
        private RichTextBox txtLog;
        private TrackBar speedRocket;
        private Label label1;
        private CheckBox cb_Debug;
        private Button bt_StepDebug;
        private TrackBar tb_updateSpeed;
        private Label label2;
    }
}