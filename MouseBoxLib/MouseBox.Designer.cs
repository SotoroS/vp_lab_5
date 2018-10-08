using System;

namespace MouseBoxLib
{
    partial class MouseBox
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.drawPanel = new System.Windows.Forms.Panel();
            this.labelCoord = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // drawPanel
            // 
            this.drawPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawPanel.Location = new System.Drawing.Point(0, 0);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(300, 300);
            this.drawPanel.TabIndex = 0;
            this.drawPanel.MouseEnter += new System.EventHandler(this.drawPanel_MouseEnter);
            this.drawPanel.MouseLeave += new System.EventHandler(this.drawPanel_MouseLeave);
            this.drawPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseBox_MouseMove);
            // 
            // labelCoord
            // 
            this.labelCoord.AutoSize = true;
            this.labelCoord.Location = new System.Drawing.Point(3, 303);
            this.labelCoord.Name = "labelCoord";
            this.labelCoord.Size = new System.Drawing.Size(59, 13);
            this.labelCoord.TabIndex = 1;
            this.labelCoord.Text = "{X=0, Y=0}";
            // 
            // MouseBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelCoord);
            this.Controls.Add(this.drawPanel);
            this.Name = "MouseBox";
            this.Size = new System.Drawing.Size(301, 317);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel drawPanel;
        private System.Windows.Forms.Label labelCoord;
    }
}
