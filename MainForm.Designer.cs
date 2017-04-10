namespace CincCamins
{
    partial class MainForm
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
            this.ButtonsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SelectedPon = new System.Windows.Forms.TextBox();
            this.MoveUp = new System.Windows.Forms.Button();
            this.MoveDown = new System.Windows.Forms.Button();
            this.MoveRight = new System.Windows.Forms.Button();
            this.MoveLeft = new System.Windows.Forms.Button();
            this.SFMLRenderControl = new CincCamins.SFMLRenderControl();
            this.ButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.ColumnCount = 3;
            this.ButtonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.ButtonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.ButtonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.ButtonsPanel.Controls.Add(this.SelectedPon, 1, 1);
            this.ButtonsPanel.Controls.Add(this.MoveUp, 1, 0);
            this.ButtonsPanel.Controls.Add(this.MoveDown, 1, 2);
            this.ButtonsPanel.Controls.Add(this.MoveRight, 2, 1);
            this.ButtonsPanel.Controls.Add(this.MoveLeft, 0, 1);
            this.ButtonsPanel.Location = new System.Drawing.Point(601, 171);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.RowCount = 3;
            this.ButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ButtonsPanel.Size = new System.Drawing.Size(200, 200);
            this.ButtonsPanel.TabIndex = 1;
            // 
            // SelectedPon
            // 
            this.SelectedPon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SelectedPon.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SelectedPon.Location = new System.Drawing.Point(69, 69);
            this.SelectedPon.Name = "SelectedPon";
            this.SelectedPon.Size = new System.Drawing.Size(62, 60);
            this.SelectedPon.TabIndex = 0;
            this.SelectedPon.Text = "1";
            this.SelectedPon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MoveUp
            // 
            this.MoveUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MoveUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MoveUp.Location = new System.Drawing.Point(69, 3);
            this.MoveUp.Name = "MoveUp";
            this.MoveUp.Size = new System.Drawing.Size(62, 60);
            this.MoveUp.TabIndex = 1;
            this.MoveUp.Text = "↑";
            this.MoveUp.UseVisualStyleBackColor = true;
            this.MoveUp.Click += new System.EventHandler(this.Up_Click);
            // 
            // MoveDown
            // 
            this.MoveDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MoveDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MoveDown.Location = new System.Drawing.Point(69, 135);
            this.MoveDown.Name = "MoveDown";
            this.MoveDown.Size = new System.Drawing.Size(62, 62);
            this.MoveDown.TabIndex = 2;
            this.MoveDown.Text = "↓";
            this.MoveDown.UseVisualStyleBackColor = true;
            this.MoveDown.Click += new System.EventHandler(this.Down_Click);
            // 
            // MoveRight
            // 
            this.MoveRight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MoveRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MoveRight.Location = new System.Drawing.Point(137, 69);
            this.MoveRight.Name = "MoveRight";
            this.MoveRight.Size = new System.Drawing.Size(60, 60);
            this.MoveRight.TabIndex = 4;
            this.MoveRight.Text = "→";
            this.MoveRight.UseVisualStyleBackColor = true;
            this.MoveRight.Click += new System.EventHandler(this.Right_Click);
            // 
            // MoveLeft
            // 
            this.MoveLeft.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MoveLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MoveLeft.Location = new System.Drawing.Point(3, 69);
            this.MoveLeft.Name = "MoveLeft";
            this.MoveLeft.Size = new System.Drawing.Size(60, 60);
            this.MoveLeft.TabIndex = 3;
            this.MoveLeft.Text = "←";
            this.MoveLeft.UseVisualStyleBackColor = true;
            this.MoveLeft.Click += new System.EventHandler(this.Left_Click);
            // 
            // SFMLRenderControl
            // 
            this.SFMLRenderControl.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.SFMLRenderControl.Location = new System.Drawing.Point(12, 12);
            this.SFMLRenderControl.Name = "SFMLRenderControl";
            this.SFMLRenderControl.Size = new System.Drawing.Size(500, 500);
            this.SFMLRenderControl.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 522);
            this.Controls.Add(this.ButtonsPanel);
            this.Controls.Add(this.SFMLRenderControl);
            this.Name = "MainForm";
            this.Text = "Cinc Camins";
            this.ButtonsPanel.ResumeLayout(false);
            this.ButtonsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SFMLRenderControl SFMLRenderControl;
        private System.Windows.Forms.TableLayoutPanel ButtonsPanel;
        private System.Windows.Forms.TextBox SelectedPon;
        private System.Windows.Forms.Button MoveUp;
        private System.Windows.Forms.Button MoveDown;
        private System.Windows.Forms.Button MoveRight;
        private System.Windows.Forms.Button MoveLeft;
    }
}

