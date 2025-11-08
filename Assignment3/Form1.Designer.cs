using System.Drawing;
using System.Windows.Forms;

namespace Assignment3
{
    partial class Assignment3Form
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
            btnDeal = new Button();
            btnSave = new Button();
            btnLoad = new Button();
            btnShowDeck = new Button();
            chkKeep1 = new CheckBox();
            chkKeep2 = new CheckBox();
            chkKeep3 = new CheckBox();
            chkKeep4 = new CheckBox();
            chkKeep5 = new CheckBox();
            picCard1 = new PictureBox();
            picCard2 = new PictureBox();
            picCard3 = new PictureBox();
            picCard4 = new PictureBox();
            picCard5 = new PictureBox();

            SuspendLayout();
            // 
            // btnDeal
            // 
            btnDeal.Location = new Point(30, 12);
            btnDeal.Name = "btnDeal";
            btnDeal.Size = new Size(75, 30);
            btnDeal.TabIndex = 0;
            btnDeal.Text = "&Deal";
            btnDeal.UseVisualStyleBackColor = true;
            btnDeal.Click += btnDeal_Click;
            // 
            // btnShowDeck
            // 
            btnShowDeck.Location = new Point(120, 12);
            btnShowDeck.Name = "btnShowDeck";
            btnShowDeck.Size = new Size(90, 30);
            btnShowDeck.TabIndex = 1;
            btnShowDeck.Text = "Show &Deck";
            btnShowDeck.UseVisualStyleBackColor = true;
            btnShowDeck.Click += btnShowDeck_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(491, 12);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(87, 40);
            btnSave.TabIndex = 6;
            btnSave.Text = "&Save Hand";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(674, 12);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(89, 40);
            btnLoad.TabIndex = 7;
            btnLoad.Text = "&Load Hand";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // chkKeep1
            // 
            chkKeep1.AutoSize = true;
            chkKeep1.Location = new Point(50, 108);
            chkKeep1.Name = "chkKeep1";
            chkKeep1.Size = new Size(61, 19);
            chkKeep1.TabIndex = 2;
            chkKeep1.Text = "&Keep 1";
            chkKeep1.UseVisualStyleBackColor = true;
            chkKeep1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // chkKeep2
            // 
            chkKeep2.AutoSize = true;
            chkKeep2.Location = new Point(196, 108);
            chkKeep2.Name = "chkKeep2";
            chkKeep2.Size = new Size(61, 19);
            chkKeep2.TabIndex = 3;
            chkKeep2.Text = "&Keep 2";
            chkKeep2.UseVisualStyleBackColor = true;
            // 
            // chkKeep3
            // 
            chkKeep3.AutoSize = true;
            chkKeep3.Location = new Point(350, 108);
            chkKeep3.Name = "chkKeep3";
            chkKeep3.Size = new Size(61, 19);
            chkKeep3.TabIndex = 4;
            chkKeep3.Text = "&Keep 3";
            chkKeep3.UseVisualStyleBackColor = true;
            chkKeep3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // chkKeep4
            // 
            chkKeep4.AutoSize = true;
            chkKeep4.Location = new Point(491, 108);
            chkKeep4.Name = "chkKeep4";
            chkKeep4.Size = new Size(61, 19);
            chkKeep4.TabIndex = 5;
            chkKeep4.Text = "&Keep 4";
            chkKeep4.UseVisualStyleBackColor = true;
            // 
            // chkKeep5
            // 
            chkKeep5.AutoSize = true;
            chkKeep5.Location = new Point(640, 108);
            chkKeep5.Name = "chkKeep5";
            chkKeep5.Size = new Size(61, 19);
            chkKeep5.TabIndex = 6;
            chkKeep5.Text = "&Keep 5";
            chkKeep5.UseVisualStyleBackColor = true;
            // 
            // picCard1
            // 
            picCard1.Location = new Point(30, 150);
            picCard1.Size = new Size(120, 170);
            picCard1.SizeMode = PictureBoxSizeMode.StretchImage;
            picCard1.Click += picCard_Click;
            // 
            // picCard2
            // 
            picCard2.Location = new Point(170, 150);
            picCard2.Size = new Size(120, 170);
            picCard2.SizeMode = PictureBoxSizeMode.StretchImage;
            picCard2.Click += picCard_Click;
            // 
            // picCard3
            // 
            picCard3.Location = new Point(310, 150);
            picCard3.Size = new Size(120, 170);
            picCard3.SizeMode = PictureBoxSizeMode.StretchImage;
            picCard3.Click += picCard_Click;
            // 
            // picCard4
            // 
            picCard4.Location = new Point(450, 150);
            picCard4.Size = new Size(120, 170);
            picCard4.SizeMode = PictureBoxSizeMode.StretchImage;
            picCard4.Click += picCard_Click;
            // 
            // picCard5
            // 
            picCard5.Location = new Point(590, 150);
            picCard5.Size = new Size(120, 170);
            picCard5.SizeMode = PictureBoxSizeMode.StretchImage;
            picCard5.Click += picCard_Click;
            // 
            // Assignment3Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnShowDeck);
            Controls.Add(picCard5);
            Controls.Add(picCard4);
            Controls.Add(picCard3);
            Controls.Add(picCard2);
            Controls.Add(picCard1);
            Controls.Add(chkKeep5);
            Controls.Add(chkKeep4);
            Controls.Add(chkKeep3);
            Controls.Add(chkKeep2);
            Controls.Add(chkKeep1);
            Controls.Add(btnLoad);
            Controls.Add(btnSave);
            Controls.Add(btnDeal);
            Name = "Assignment3Form";
            Text = "Assignment 4 – Poker Hand Simulator";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Load += Assignment3Form_Load;
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
        private Button btnDeal;
        private Button btnSave;
        private Button btnLoad;
        private Button btnShowDeck;
        private CheckBox chkKeep1;
        private CheckBox chkKeep2;
        private CheckBox chkKeep3;
        private CheckBox chkKeep4;
        private CheckBox chkKeep5;
        private PictureBox picCard1;
        private PictureBox picCard2;
        private PictureBox picCard3;
        private PictureBox picCard4;
        private PictureBox picCard5;
    }
}
