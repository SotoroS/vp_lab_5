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
            this.mouseBox1 = new MouseBoxLib.MouseBox();
            this.mouseBox2 = new MouseBoxLib.MouseBox();
            this.SuspendLayout();
            // 
            // mouseBox1
            // 
            this.mouseBox1.Location = new System.Drawing.Point(0, 0);
            this.mouseBox1.Name = "mouseBox1";
            this.mouseBox1.Size = new System.Drawing.Size(226, 236);
            this.mouseBox1.TabIndex = 0;
            // 
            // mouseBox2
            // 
            this.mouseBox2.Location = new System.Drawing.Point(232, 74);
            this.mouseBox2.Name = "mouseBox2";
            this.mouseBox2.Size = new System.Drawing.Size(226, 236);
            this.mouseBox2.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mouseBox2);
            this.Controls.Add(this.mouseBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private MouseBoxLib.MouseBox mouseBox1;
        private MouseBoxLib.MouseBox mouseBox2;
    }
}

