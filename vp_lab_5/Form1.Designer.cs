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
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonDrawVectorTrigger = new System.Windows.Forms.Button();
            this.buttonDrawRegionTrigger = new System.Windows.Forms.Button();
            this.mouseBox = new MouseBoxLib.MouseBox();
            this.textBoxStep = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonChangeStep = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(243, 12);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(257, 23);
            this.buttonClear.TabIndex = 1;
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonDrawVectorTrigger
            // 
            this.buttonDrawVectorTrigger.Location = new System.Drawing.Point(243, 41);
            this.buttonDrawVectorTrigger.Name = "buttonDrawVectorTrigger";
            this.buttonDrawVectorTrigger.Size = new System.Drawing.Size(257, 23);
            this.buttonDrawVectorTrigger.TabIndex = 2;
            this.buttonDrawVectorTrigger.Text = "Включить отрисовку векторов";
            this.buttonDrawVectorTrigger.UseVisualStyleBackColor = true;
            this.buttonDrawVectorTrigger.Click += new System.EventHandler(this.buttonDrawVectorTrigger_Click);
            // 
            // buttonDrawRegionTrigger
            // 
            this.buttonDrawRegionTrigger.Location = new System.Drawing.Point(243, 70);
            this.buttonDrawRegionTrigger.Name = "buttonDrawRegionTrigger";
            this.buttonDrawRegionTrigger.Size = new System.Drawing.Size(257, 23);
            this.buttonDrawRegionTrigger.TabIndex = 3;
            this.buttonDrawRegionTrigger.Text = "Включить отрисовку регионов";
            this.buttonDrawRegionTrigger.UseVisualStyleBackColor = true;
            this.buttonDrawRegionTrigger.Click += new System.EventHandler(this.buttonDrawRegionTrigger_Click);
            // 
            // mouseBox
            // 
            this.mouseBox.Location = new System.Drawing.Point(12, 12);
            this.mouseBox.Name = "mouseBox";
            this.mouseBox.Size = new System.Drawing.Size(225, 242);
            this.mouseBox.TabIndex = 0;
            // 
            // textBoxStep
            // 
            this.textBoxStep.Location = new System.Drawing.Point(279, 99);
            this.textBoxStep.Name = "textBoxStep";
            this.textBoxStep.Size = new System.Drawing.Size(122, 20);
            this.textBoxStep.TabIndex = 4;
            this.textBoxStep.Text = "10";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(243, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Шаг:";
            // 
            // buttonChangeStep
            // 
            this.buttonChangeStep.Location = new System.Drawing.Point(407, 97);
            this.buttonChangeStep.Name = "buttonChangeStep";
            this.buttonChangeStep.Size = new System.Drawing.Size(93, 23);
            this.buttonChangeStep.TabIndex = 6;
            this.buttonChangeStep.Text = "Изменить";
            this.buttonChangeStep.UseVisualStyleBackColor = true;
            this.buttonChangeStep.Click += new System.EventHandler(this.buttonChangeStep_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 258);
            this.Controls.Add(this.buttonChangeStep);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxStep);
            this.Controls.Add(this.buttonDrawRegionTrigger);
            this.Controls.Add(this.buttonDrawVectorTrigger);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.mouseBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MouseBoxLib.MouseBox mouseBox1;
        private MouseBoxLib.MouseBox mouseBox2;
        private MouseBoxLib.MouseBox mouseBox;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonDrawVectorTrigger;
        private System.Windows.Forms.Button buttonDrawRegionTrigger;
        private System.Windows.Forms.TextBox textBoxStep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonChangeStep;
    }
}

