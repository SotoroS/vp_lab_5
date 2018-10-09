namespace vp_lab_5
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownRadius = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownStep = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSizePoint = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxTrajectory = new System.Windows.Forms.CheckBox();
            this.checkBoxSAB = new System.Windows.Forms.CheckBox();
            this.checkBoxPMK = new System.Windows.Forms.CheckBox();
            this.checkBoxSMK = new System.Windows.Forms.CheckBox();
            this.checkBoxPRO = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxO = new System.Windows.Forms.CheckBox();
            this.checkBoxR = new System.Windows.Forms.CheckBox();
            this.checkBoxK = new System.Windows.Forms.CheckBox();
            this.checkBoxM = new System.Windows.Forms.CheckBox();
            this.checkBoxB = new System.Windows.Forms.CheckBox();
            this.checkBoxA = new System.Windows.Forms.CheckBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.mouseBox = new MouseBoxLib.MouseBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizePoint)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(12, 336);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(300, 23);
            this.buttonClear.TabIndex = 1;
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 401);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Шаг аппроксимации:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 371);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Радиус допустимой кривизны:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 595);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Статус кругового движения:";
            // 
            // numericUpDownRadius
            // 
            this.numericUpDownRadius.Location = new System.Drawing.Point(192, 369);
            this.numericUpDownRadius.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownRadius.Name = "numericUpDownRadius";
            this.numericUpDownRadius.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownRadius.TabIndex = 11;
            this.numericUpDownRadius.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownRadius.Validated += new System.EventHandler(this.numericUpDownRadius_Validated);
            // 
            // numericUpDownStep
            // 
            this.numericUpDownStep.Location = new System.Drawing.Point(192, 399);
            this.numericUpDownStep.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownStep.Name = "numericUpDownStep";
            this.numericUpDownStep.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownStep.TabIndex = 12;
            this.numericUpDownStep.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownStep.Validated += new System.EventHandler(this.numericUpDownStep_Validated);
            // 
            // numericUpDownSizePoint
            // 
            this.numericUpDownSizePoint.Location = new System.Drawing.Point(192, 427);
            this.numericUpDownSizePoint.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownSizePoint.Name = "numericUpDownSizePoint";
            this.numericUpDownSizePoint.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownSizePoint.TabIndex = 14;
            this.numericUpDownSizePoint.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownSizePoint.Validated += new System.EventHandler(this.numericUpDownSizePoint_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 429);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Размер точек:";
            // 
            // checkBoxTrajectory
            // 
            this.checkBoxTrajectory.AutoSize = true;
            this.checkBoxTrajectory.Checked = true;
            this.checkBoxTrajectory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTrajectory.Location = new System.Drawing.Point(15, 460);
            this.checkBoxTrajectory.Name = "checkBoxTrajectory";
            this.checkBoxTrajectory.Size = new System.Drawing.Size(142, 17);
            this.checkBoxTrajectory.TabIndex = 16;
            this.checkBoxTrajectory.Text = "Отрисовка траектории";
            this.checkBoxTrajectory.UseVisualStyleBackColor = true;
            this.checkBoxTrajectory.CheckedChanged += new System.EventHandler(this.checkBoxTrajectory_CheckedChanged);
            // 
            // checkBoxSAB
            // 
            this.checkBoxSAB.AutoSize = true;
            this.checkBoxSAB.Checked = true;
            this.checkBoxSAB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSAB.Location = new System.Drawing.Point(15, 483);
            this.checkBoxSAB.Name = "checkBoxSAB";
            this.checkBoxSAB.Size = new System.Drawing.Size(142, 17);
            this.checkBoxSAB.TabIndex = 17;
            this.checkBoxSAB.Text = "Отрисовка отрезка AB";
            this.checkBoxSAB.UseVisualStyleBackColor = true;
            this.checkBoxSAB.CheckedChanged += new System.EventHandler(this.checkBoxSAB_CheckedChanged);
            // 
            // checkBoxPMK
            // 
            this.checkBoxPMK.AutoSize = true;
            this.checkBoxPMK.Location = new System.Drawing.Point(15, 506);
            this.checkBoxPMK.Name = "checkBoxPMK";
            this.checkBoxPMK.Size = new System.Drawing.Size(141, 17);
            this.checkBoxPMK.TabIndex = 18;
            this.checkBoxPMK.Text = "Отрисовка прямой MK";
            this.checkBoxPMK.UseVisualStyleBackColor = true;
            this.checkBoxPMK.CheckedChanged += new System.EventHandler(this.checkBoxPMK_CheckedChanged);
            // 
            // checkBoxSMK
            // 
            this.checkBoxSMK.AutoSize = true;
            this.checkBoxSMK.Location = new System.Drawing.Point(173, 460);
            this.checkBoxSMK.Name = "checkBoxSMK";
            this.checkBoxSMK.Size = new System.Drawing.Size(144, 17);
            this.checkBoxSMK.TabIndex = 19;
            this.checkBoxSMK.Text = "Отрисовка отрезка MK";
            this.checkBoxSMK.UseVisualStyleBackColor = true;
            this.checkBoxSMK.CheckedChanged += new System.EventHandler(this.checkBoxSMK_CheckedChanged);
            // 
            // checkBoxPRO
            // 
            this.checkBoxPRO.AutoSize = true;
            this.checkBoxPRO.Location = new System.Drawing.Point(173, 483);
            this.checkBoxPRO.Name = "checkBoxPRO";
            this.checkBoxPRO.Size = new System.Drawing.Size(141, 17);
            this.checkBoxPRO.TabIndex = 20;
            this.checkBoxPRO.Text = "Отрисовка прямой RO";
            this.checkBoxPRO.UseVisualStyleBackColor = true;
            this.checkBoxPRO.CheckedChanged += new System.EventHandler(this.checkBoxPRO_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxO);
            this.groupBox1.Controls.Add(this.checkBoxR);
            this.groupBox1.Controls.Add(this.checkBoxK);
            this.groupBox1.Controls.Add(this.checkBoxM);
            this.groupBox1.Controls.Add(this.checkBoxB);
            this.groupBox1.Controls.Add(this.checkBoxA);
            this.groupBox1.Location = new System.Drawing.Point(15, 533);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 47);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Отрисовка точек";
            // 
            // checkBoxO
            // 
            this.checkBoxO.AutoSize = true;
            this.checkBoxO.Location = new System.Drawing.Point(257, 18);
            this.checkBoxO.Name = "checkBoxO";
            this.checkBoxO.Size = new System.Drawing.Size(34, 17);
            this.checkBoxO.TabIndex = 24;
            this.checkBoxO.Text = "O";
            this.checkBoxO.UseVisualStyleBackColor = true;
            this.checkBoxO.CheckedChanged += new System.EventHandler(this.checkBoxO_CheckedChanged);
            // 
            // checkBoxR
            // 
            this.checkBoxR.AutoSize = true;
            this.checkBoxR.Location = new System.Drawing.Point(205, 19);
            this.checkBoxR.Name = "checkBoxR";
            this.checkBoxR.Size = new System.Drawing.Size(34, 17);
            this.checkBoxR.TabIndex = 23;
            this.checkBoxR.Text = "R";
            this.checkBoxR.UseVisualStyleBackColor = true;
            this.checkBoxR.CheckedChanged += new System.EventHandler(this.checkBoxR_CheckedChanged);
            // 
            // checkBoxK
            // 
            this.checkBoxK.AutoSize = true;
            this.checkBoxK.Location = new System.Drawing.Point(158, 18);
            this.checkBoxK.Name = "checkBoxK";
            this.checkBoxK.Size = new System.Drawing.Size(33, 17);
            this.checkBoxK.TabIndex = 23;
            this.checkBoxK.Text = "K";
            this.checkBoxK.UseVisualStyleBackColor = true;
            this.checkBoxK.CheckedChanged += new System.EventHandler(this.checkBoxK_CheckedChanged);
            // 
            // checkBoxM
            // 
            this.checkBoxM.AutoSize = true;
            this.checkBoxM.Location = new System.Drawing.Point(106, 18);
            this.checkBoxM.Name = "checkBoxM";
            this.checkBoxM.Size = new System.Drawing.Size(35, 17);
            this.checkBoxM.TabIndex = 23;
            this.checkBoxM.Text = "M";
            this.checkBoxM.UseVisualStyleBackColor = true;
            this.checkBoxM.CheckedChanged += new System.EventHandler(this.checkBoxM_CheckedChanged);
            // 
            // checkBoxB
            // 
            this.checkBoxB.AutoSize = true;
            this.checkBoxB.Location = new System.Drawing.Point(55, 18);
            this.checkBoxB.Name = "checkBoxB";
            this.checkBoxB.Size = new System.Drawing.Size(33, 17);
            this.checkBoxB.TabIndex = 1;
            this.checkBoxB.Text = "B";
            this.checkBoxB.UseVisualStyleBackColor = true;
            this.checkBoxB.CheckedChanged += new System.EventHandler(this.checkBoxB_CheckedChanged);
            // 
            // checkBoxA
            // 
            this.checkBoxA.AutoSize = true;
            this.checkBoxA.Location = new System.Drawing.Point(6, 18);
            this.checkBoxA.Name = "checkBoxA";
            this.checkBoxA.Size = new System.Drawing.Size(33, 17);
            this.checkBoxA.TabIndex = 0;
            this.checkBoxA.Text = "A";
            this.checkBoxA.UseVisualStyleBackColor = true;
            this.checkBoxA.CheckedChanged += new System.EventHandler(this.checkBoxA_CheckedChanged);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.ForeColor = System.Drawing.Color.Red;
            this.labelStatus.Location = new System.Drawing.Point(277, 595);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(32, 13);
            this.labelStatus.TabIndex = 23;
            this.labelStatus.Text = "False";
            // 
            // mouseBox
            // 
            this.mouseBox.Location = new System.Drawing.Point(12, 12);
            this.mouseBox.Name = "mouseBox";
            this.mouseBox.Size = new System.Drawing.Size(300, 318);
            this.mouseBox.TabIndex = 0;
            this.mouseBox.MoveMouseCircularPath += new System.EventHandler(this.mouseBox_MoveMouseCircularPath);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(326, 621);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBoxPRO);
            this.Controls.Add(this.checkBoxSMK);
            this.Controls.Add(this.checkBoxPMK);
            this.Controls.Add(this.checkBoxSAB);
            this.Controls.Add(this.checkBoxTrajectory);
            this.Controls.Add(this.numericUpDownSizePoint);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDownStep);
            this.Controls.Add(this.numericUpDownRadius);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.mouseBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Detected circular path";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizePoint)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MouseBoxLib.MouseBox mouseBox1;
        private MouseBoxLib.MouseBox mouseBox2;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label label1;
        private MouseBoxLib.MouseBox mouseBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownRadius;
        private System.Windows.Forms.NumericUpDown numericUpDownStep;
        private System.Windows.Forms.NumericUpDown numericUpDownSizePoint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxTrajectory;
        private System.Windows.Forms.CheckBox checkBoxSAB;
        private System.Windows.Forms.CheckBox checkBoxPMK;
        private System.Windows.Forms.CheckBox checkBoxSMK;
        private System.Windows.Forms.CheckBox checkBoxPRO;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxR;
        private System.Windows.Forms.CheckBox checkBoxK;
        private System.Windows.Forms.CheckBox checkBoxM;
        private System.Windows.Forms.CheckBox checkBoxB;
        private System.Windows.Forms.CheckBox checkBoxA;
        private System.Windows.Forms.CheckBox checkBoxO;
        private System.Windows.Forms.Label labelStatus;
    }
}

