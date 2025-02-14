namespace checkers_v2
{
    partial class Form1
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
            this.btn_skip = new System.Windows.Forms.Button();
            this.btn_2players = new System.Windows.Forms.Button();
            this.label_start = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btn_easy = new System.Windows.Forms.Button();
            this.label_comp = new System.Windows.Forms.Label();
            this.btn_medium = new System.Windows.Forms.Button();
            this.btn_hard = new System.Windows.Forms.Button();
            this.btn_mainMenu = new System.Windows.Forms.Button();
            this.btn_prevMove = new System.Windows.Forms.Button();
            this.playerText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_skip
            // 
            this.btn_skip.BackColor = System.Drawing.Color.CadetBlue;
            this.btn_skip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_skip.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_skip.Location = new System.Drawing.Point(529, 12);
            this.btn_skip.Name = "btn_skip";
            this.btn_skip.Size = new System.Drawing.Size(200, 50);
            this.btn_skip.TabIndex = 1;
            this.btn_skip.Text = "skip double take";
            this.btn_skip.UseVisualStyleBackColor = false;
            this.btn_skip.Visible = false;
            this.btn_skip.Click += new System.EventHandler(this.btn_skip_Click);
            // 
            // btn_2players
            // 
            this.btn_2players.BackColor = System.Drawing.Color.CadetBlue;
            this.btn_2players.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_2players.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_2players.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_2players.ForeColor = System.Drawing.Color.Black;
            this.btn_2players.Location = new System.Drawing.Point(166, 190);
            this.btn_2players.Name = "btn_2players";
            this.btn_2players.Size = new System.Drawing.Size(390, 140);
            this.btn_2players.TabIndex = 2;
            this.btn_2players.Text = "2 Players";
            this.btn_2players.UseVisualStyleBackColor = false;
            this.btn_2players.Click += new System.EventHandler(this.btn_2players_Click);
            // 
            // label_start
            // 
            this.label_start.AutoSize = true;
            this.label_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_start.Location = new System.Drawing.Point(166, 80);
            this.label_start.Name = "label_start";
            this.label_start.Size = new System.Drawing.Size(376, 91);
            this.label_start.TabIndex = 4;
            this.label_start.Text = "Checkers";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.CadetBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(12, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "SaveGame";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.CadetBlue;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Location = new System.Drawing.Point(93, 9);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 6;
            this.btnLoad.Text = "LoadGame";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Visible = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btn_easy
            // 
            this.btn_easy.BackColor = System.Drawing.Color.CadetBlue;
            this.btn_easy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_easy.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_easy.Location = new System.Drawing.Point(166, 375);
            this.btn_easy.Name = "btn_easy";
            this.btn_easy.Size = new System.Drawing.Size(390, 90);
            this.btn_easy.TabIndex = 7;
            this.btn_easy.Text = "Easy";
            this.btn_easy.UseVisualStyleBackColor = false;
            this.btn_easy.Click += new System.EventHandler(this.btn_easy_Click);
            // 
            // label_comp
            // 
            this.label_comp.AutoSize = true;
            this.label_comp.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_comp.Location = new System.Drawing.Point(227, 333);
            this.label_comp.Name = "label_comp";
            this.label_comp.Size = new System.Drawing.Size(268, 39);
            this.label_comp.TabIndex = 8;
            this.label_comp.Text = "VS COMPUTER";
            this.label_comp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_medium
            // 
            this.btn_medium.BackColor = System.Drawing.Color.CadetBlue;
            this.btn_medium.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_medium.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_medium.Location = new System.Drawing.Point(166, 471);
            this.btn_medium.Name = "btn_medium";
            this.btn_medium.Size = new System.Drawing.Size(390, 90);
            this.btn_medium.TabIndex = 9;
            this.btn_medium.Text = "Medium";
            this.btn_medium.UseVisualStyleBackColor = false;
            this.btn_medium.Click += new System.EventHandler(this.btn_medium_Click);
            // 
            // btn_hard
            // 
            this.btn_hard.BackColor = System.Drawing.Color.CadetBlue;
            this.btn_hard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_hard.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_hard.Location = new System.Drawing.Point(166, 567);
            this.btn_hard.Name = "btn_hard";
            this.btn_hard.Size = new System.Drawing.Size(390, 90);
            this.btn_hard.TabIndex = 10;
            this.btn_hard.Text = "Hard";
            this.btn_hard.UseVisualStyleBackColor = false;
            this.btn_hard.Click += new System.EventHandler(this.btn_hard_Click);
            // 
            // btn_mainMenu
            // 
            this.btn_mainMenu.BackColor = System.Drawing.Color.CadetBlue;
            this.btn_mainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_mainMenu.Location = new System.Drawing.Point(12, 38);
            this.btn_mainMenu.Name = "btn_mainMenu";
            this.btn_mainMenu.Size = new System.Drawing.Size(156, 23);
            this.btn_mainMenu.TabIndex = 11;
            this.btn_mainMenu.Text = "Main Menu";
            this.btn_mainMenu.UseVisualStyleBackColor = false;
            this.btn_mainMenu.Visible = false;
            this.btn_mainMenu.Click += new System.EventHandler(this.btn_mainMenu_Click);
            // 
            // btn_prevMove
            // 
            this.btn_prevMove.BackColor = System.Drawing.Color.CadetBlue;
            this.btn_prevMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_prevMove.Location = new System.Drawing.Point(13, 66);
            this.btn_prevMove.Name = "btn_prevMove";
            this.btn_prevMove.Size = new System.Drawing.Size(154, 24);
            this.btn_prevMove.TabIndex = 12;
            this.btn_prevMove.Text = "Previous Move";
            this.btn_prevMove.UseVisualStyleBackColor = false;
            this.btn_prevMove.Visible = false;
            this.btn_prevMove.Click += new System.EventHandler(this.btn_prevMove_Click);
            // 
            // playerText
            // 
            this.playerText.AutoSize = true;
            this.playerText.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerText.Location = new System.Drawing.Point(175, 23);
            this.playerText.Name = "playerText";
            this.playerText.Size = new System.Drawing.Size(115, 39);
            this.playerText.TabIndex = 13;
            this.playerText.Text = "label1";
            this.playerText.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(741, 749);
            this.Controls.Add(this.playerText);
            this.Controls.Add(this.btn_prevMove);
            this.Controls.Add(this.btn_mainMenu);
            this.Controls.Add(this.btn_hard);
            this.Controls.Add(this.btn_medium);
            this.Controls.Add(this.label_comp);
            this.Controls.Add(this.btn_easy);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label_start);
            this.Controls.Add(this.btn_2players);
            this.Controls.Add(this.btn_skip);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.Button btn_skip;
        private System.Windows.Forms.Button btn_2players;
        private System.Windows.Forms.Label label_start;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btn_easy;
        private System.Windows.Forms.Label label_comp;
        private System.Windows.Forms.Button btn_medium;
        private System.Windows.Forms.Button btn_hard;
        private System.Windows.Forms.Button btn_mainMenu;
        private System.Windows.Forms.Button btn_prevMove;
        private System.Windows.Forms.Label playerText;
    }
}

