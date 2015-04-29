namespace Colorado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pbox = new System.Windows.Forms.PictureBox();
            this.bPen = new System.Windows.Forms.Button();
            this.bFill = new System.Windows.Forms.Button();
            this.tTime = new System.Windows.Forms.TextBox();
            this.bSet = new System.Windows.Forms.Button();
            this.bDone = new System.Windows.Forms.Button();
            this.bClear = new System.Windows.Forms.Button();
            this.rbRecursive = new System.Windows.Forms.RadioButton();
            this.rbLoop = new System.Windows.Forms.RadioButton();
            this.rbFigure = new System.Windows.Forms.RadioButton();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.bSelectColor = new System.Windows.Forms.Button();
            this.cbox = new System.Windows.Forms.PictureBox();
            this.lTime = new System.Windows.Forms.Label();
            this.colorDialogPen = new System.Windows.Forms.ColorDialog();
            this.cboxPen = new System.Windows.Forms.PictureBox();
            this.bSelectColorPen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxPen)).BeginInit();
            this.SuspendLayout();
            // 
            // pbox
            // 
            this.pbox.BackColor = System.Drawing.Color.Gainsboro;
            this.pbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbox.Location = new System.Drawing.Point(2, 2);
            this.pbox.Name = "pbox";
            this.pbox.Size = new System.Drawing.Size(1000, 400);
            this.pbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbox.TabIndex = 1;
            this.pbox.TabStop = false;
            this.pbox.Click += new System.EventHandler(this.pbox_Click);
            this.pbox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbox_MouseDown);
            this.pbox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbox_MouseMove);
            this.pbox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbox_MouseUp);
            // 
            // bPen
            // 
            this.bPen.Location = new System.Drawing.Point(2, 466);
            this.bPen.Name = "bPen";
            this.bPen.Size = new System.Drawing.Size(75, 23);
            this.bPen.TabIndex = 3;
            this.bPen.Text = "Pen";
            this.bPen.UseVisualStyleBackColor = true;
            this.bPen.Click += new System.EventHandler(this.bPen_Click);
            // 
            // bFill
            // 
            this.bFill.Location = new System.Drawing.Point(927, 408);
            this.bFill.Name = "bFill";
            this.bFill.Size = new System.Drawing.Size(75, 23);
            this.bFill.TabIndex = 4;
            this.bFill.Text = "Fill";
            this.bFill.UseVisualStyleBackColor = true;
            this.bFill.Click += new System.EventHandler(this.bFill_Click);
            // 
            // tTime
            // 
            this.tTime.Location = new System.Drawing.Point(209, 411);
            this.tTime.Name = "tTime";
            this.tTime.Size = new System.Drawing.Size(100, 20);
            this.tTime.TabIndex = 5;
            this.tTime.Visible = false;
            // 
            // bSet
            // 
            this.bSet.Location = new System.Drawing.Point(2, 408);
            this.bSet.Name = "bSet";
            this.bSet.Size = new System.Drawing.Size(75, 23);
            this.bSet.TabIndex = 6;
            this.bSet.Text = "Set Points";
            this.bSet.UseVisualStyleBackColor = true;
            this.bSet.Click += new System.EventHandler(this.bSet_Click);
            // 
            // bDone
            // 
            this.bDone.Enabled = false;
            this.bDone.Location = new System.Drawing.Point(2, 437);
            this.bDone.Name = "bDone";
            this.bDone.Size = new System.Drawing.Size(75, 23);
            this.bDone.TabIndex = 7;
            this.bDone.Text = "Done";
            this.bDone.UseVisualStyleBackColor = true;
            this.bDone.Click += new System.EventHandler(this.bDone_Click);
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(927, 437);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(75, 23);
            this.bClear.TabIndex = 8;
            this.bClear.Text = "Clear";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // rbRecursive
            // 
            this.rbRecursive.AutoSize = true;
            this.rbRecursive.Checked = true;
            this.rbRecursive.Location = new System.Drawing.Point(500, 408);
            this.rbRecursive.Name = "rbRecursive";
            this.rbRecursive.Size = new System.Drawing.Size(73, 17);
            this.rbRecursive.TabIndex = 10;
            this.rbRecursive.TabStop = true;
            this.rbRecursive.Text = "Recursive";
            this.rbRecursive.UseVisualStyleBackColor = true;
            // 
            // rbLoop
            // 
            this.rbLoop.AutoSize = true;
            this.rbLoop.Location = new System.Drawing.Point(500, 431);
            this.rbLoop.Name = "rbLoop";
            this.rbLoop.Size = new System.Drawing.Size(49, 17);
            this.rbLoop.TabIndex = 11;
            this.rbLoop.Text = "Loop";
            this.rbLoop.UseVisualStyleBackColor = true;
            // 
            // rbFigure
            // 
            this.rbFigure.AutoSize = true;
            this.rbFigure.Enabled = false;
            this.rbFigure.Location = new System.Drawing.Point(500, 454);
            this.rbFigure.Name = "rbFigure";
            this.rbFigure.Size = new System.Drawing.Size(54, 17);
            this.rbFigure.TabIndex = 12;
            this.rbFigure.Text = "Figure";
            this.rbFigure.UseVisualStyleBackColor = true;
            // 
            // colorDialog
            // 
            this.colorDialog.AnyColor = true;
            // 
            // bSelectColor
            // 
            this.bSelectColor.Location = new System.Drawing.Point(927, 466);
            this.bSelectColor.Name = "bSelectColor";
            this.bSelectColor.Size = new System.Drawing.Size(75, 23);
            this.bSelectColor.TabIndex = 18;
            this.bSelectColor.Text = "Select color";
            this.bSelectColor.UseVisualStyleBackColor = true;
            this.bSelectColor.Click += new System.EventHandler(this.bSelectColor_Click);
            // 
            // cbox
            // 
            this.cbox.BackColor = System.Drawing.Color.Black;
            this.cbox.Location = new System.Drawing.Point(846, 466);
            this.cbox.Name = "cbox";
            this.cbox.Size = new System.Drawing.Size(75, 23);
            this.cbox.TabIndex = 19;
            this.cbox.TabStop = false;
            this.cbox.DoubleClick += new System.EventHandler(this.bSelectColor_Click);
            // 
            // lTime
            // 
            this.lTime.AutoSize = true;
            this.lTime.Location = new System.Drawing.Point(170, 415);
            this.lTime.Name = "lTime";
            this.lTime.Size = new System.Drawing.Size(30, 13);
            this.lTime.TabIndex = 20;
            this.lTime.Text = "Time";
            this.lTime.Visible = false;
            // 
            // colorDialogPen
            // 
            this.colorDialogPen.AnyColor = true;
            // 
            // cboxPen
            // 
            this.cboxPen.BackColor = System.Drawing.Color.Black;
            this.cboxPen.Location = new System.Drawing.Point(246, 466);
            this.cboxPen.Name = "cboxPen";
            this.cboxPen.Size = new System.Drawing.Size(75, 23);
            this.cboxPen.TabIndex = 22;
            this.cboxPen.TabStop = false;
            this.cboxPen.DoubleClick += new System.EventHandler(this.bSelectColorPen_Click);
            // 
            // bSelectColorPen
            // 
            this.bSelectColorPen.Location = new System.Drawing.Point(165, 466);
            this.bSelectColorPen.Name = "bSelectColorPen";
            this.bSelectColorPen.Size = new System.Drawing.Size(75, 23);
            this.bSelectColorPen.TabIndex = 21;
            this.bSelectColorPen.Text = "Select color";
            this.bSelectColorPen.UseVisualStyleBackColor = true;
            this.bSelectColorPen.Click += new System.EventHandler(this.bSelectColorPen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(795, 471);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Fill color";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 471);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Pen color";
            this.label2.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1004, 508);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboxPen);
            this.Controls.Add(this.bSelectColorPen);
            this.Controls.Add(this.lTime);
            this.Controls.Add(this.cbox);
            this.Controls.Add(this.bSelectColor);
            this.Controls.Add(this.rbFigure);
            this.Controls.Add(this.rbLoop);
            this.Controls.Add(this.rbRecursive);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.bDone);
            this.Controls.Add(this.bSet);
            this.Controls.Add(this.tTime);
            this.Controls.Add(this.bFill);
            this.Controls.Add(this.bPen);
            this.Controls.Add(this.pbox);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Colorado Project";
            ((System.ComponentModel.ISupportInitialize)(this.pbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxPen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbox;
        private System.Windows.Forms.Button bPen;
        private System.Windows.Forms.Button bFill;
        private System.Windows.Forms.TextBox tTime;
        private System.Windows.Forms.Button bSet;
        private System.Windows.Forms.Button bDone;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.RadioButton rbRecursive;
        private System.Windows.Forms.RadioButton rbLoop;
        private System.Windows.Forms.RadioButton rbFigure;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button bSelectColor;
        private System.Windows.Forms.PictureBox cbox;
        private System.Windows.Forms.Label lTime;
        private System.Windows.Forms.ColorDialog colorDialogPen;
        private System.Windows.Forms.PictureBox cboxPen;
        private System.Windows.Forms.Button bSelectColorPen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

