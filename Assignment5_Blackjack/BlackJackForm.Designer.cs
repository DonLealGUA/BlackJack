namespace Assignment4_Blackjack
{
    partial class BlackJackForm
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
            ShuffleButton = new Button();
            HitButton = new Button();
            StandButton = new Button();
            StartButton = new Button();
            DealerPicture1 = new PictureBox();
            PlayerpictureBox1 = new PictureBox();
            PlayerpictureBox2 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            PlayerLabel = new Label();
            DealerLabel = new Label();
            ResetButton = new Button();
            PlayerpictureBox3 = new PictureBox();
            PlayerpictureBox4 = new PictureBox();
            PlayerpictureBox5 = new PictureBox();
            DealerPicture2 = new PictureBox();
            DealerPicture3 = new PictureBox();
            DealerPicture4 = new PictureBox();
            DealerPicture5 = new PictureBox();
            PlayerpictureBox6 = new PictureBox();
            PlayerpictureBox7 = new PictureBox();
            DealerPicture6 = new PictureBox();
            DealerPicture7 = new PictureBox();
            playerNameLabel = new Label();
            changeNameBTN = new Button();
            DeletePlayerBTN = new Button();
            gameCardGridView = new DataGridView();
            dataGridView3 = new DataGridView();
            PlayerTableGridView = new Label();
            label3 = new Label();
            newPlayerBTN = new Button();
            ((System.ComponentModel.ISupportInitialize)DealerPicture1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PlayerpictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PlayerpictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PlayerpictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PlayerpictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PlayerpictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DealerPicture2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DealerPicture3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DealerPicture4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DealerPicture5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PlayerpictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PlayerpictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DealerPicture6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DealerPicture7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gameCardGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            SuspendLayout();
            // 
            // ShuffleButton
            // 
            ShuffleButton.Location = new Point(267, 477);
            ShuffleButton.Margin = new Padding(4, 3, 4, 3);
            ShuffleButton.Name = "ShuffleButton";
            ShuffleButton.Size = new Size(98, 29);
            ShuffleButton.TabIndex = 0;
            ShuffleButton.Text = "Shuffle";
            ShuffleButton.UseVisualStyleBackColor = true;
            // 
            // HitButton
            // 
            HitButton.Location = new Point(162, 477);
            HitButton.Margin = new Padding(4, 3, 4, 3);
            HitButton.Name = "HitButton";
            HitButton.Size = new Size(98, 29);
            HitButton.TabIndex = 1;
            HitButton.Text = "Hit";
            HitButton.UseVisualStyleBackColor = true;
            HitButton.Click += HitButton_Click;
            // 
            // StandButton
            // 
            StandButton.Location = new Point(57, 477);
            StandButton.Margin = new Padding(4, 3, 4, 3);
            StandButton.Name = "StandButton";
            StandButton.Size = new Size(98, 29);
            StandButton.TabIndex = 2;
            StandButton.Text = "Stand";
            StandButton.UseVisualStyleBackColor = true;
            StandButton.Click += StandButton_Click;
            // 
            // StartButton
            // 
            StartButton.Location = new Point(6, 40);
            StartButton.Margin = new Padding(4, 3, 4, 3);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(139, 44);
            StartButton.TabIndex = 3;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // DealerPicture1
            // 
            DealerPicture1.Location = new Point(58, 121);
            DealerPicture1.Margin = new Padding(4, 3, 4, 3);
            DealerPicture1.Name = "DealerPicture1";
            DealerPicture1.Size = new Size(114, 166);
            DealerPicture1.TabIndex = 4;
            DealerPicture1.TabStop = false;
            // 
            // PlayerpictureBox1
            // 
            PlayerpictureBox1.Location = new Point(58, 293);
            PlayerpictureBox1.Margin = new Padding(4, 3, 4, 3);
            PlayerpictureBox1.Name = "PlayerpictureBox1";
            PlayerpictureBox1.Size = new Size(114, 166);
            PlayerpictureBox1.TabIndex = 5;
            PlayerpictureBox1.TabStop = false;
            // 
            // PlayerpictureBox2
            // 
            PlayerpictureBox2.Location = new Point(180, 293);
            PlayerpictureBox2.Margin = new Padding(4, 3, 4, 3);
            PlayerpictureBox2.Name = "PlayerpictureBox2";
            PlayerpictureBox2.Size = new Size(114, 166);
            PlayerpictureBox2.TabIndex = 6;
            PlayerpictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 187);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 7;
            label1.Text = "Dealer";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 376);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 8;
            label2.Text = "Player";
            // 
            // PlayerLabel
            // 
            PlayerLabel.AutoSize = true;
            PlayerLabel.Location = new Point(384, 483);
            PlayerLabel.Margin = new Padding(4, 0, 4, 0);
            PlayerLabel.Name = "PlayerLabel";
            PlayerLabel.Size = new Size(87, 15);
            PlayerLabel.TabIndex = 9;
            PlayerLabel.Text = "Player amount:";
            // 
            // DealerLabel
            // 
            DealerLabel.AutoSize = true;
            DealerLabel.Location = new Point(67, 103);
            DealerLabel.Margin = new Padding(4, 0, 4, 0);
            DealerLabel.Name = "DealerLabel";
            DealerLabel.Size = new Size(88, 15);
            DealerLabel.TabIndex = 10;
            DealerLabel.Text = "Dealer amount:";
            DealerLabel.Click += DealerLabel_Click;
            // 
            // ResetButton
            // 
            ResetButton.Location = new Point(162, 40);
            ResetButton.Margin = new Padding(4, 3, 4, 3);
            ResetButton.Name = "ResetButton";
            ResetButton.Size = new Size(139, 44);
            ResetButton.TabIndex = 11;
            ResetButton.Text = "Reset";
            ResetButton.UseVisualStyleBackColor = true;
            ResetButton.Click += ResetButton_Click;
            // 
            // PlayerpictureBox3
            // 
            PlayerpictureBox3.Location = new Point(301, 293);
            PlayerpictureBox3.Margin = new Padding(4, 3, 4, 3);
            PlayerpictureBox3.Name = "PlayerpictureBox3";
            PlayerpictureBox3.Size = new Size(114, 166);
            PlayerpictureBox3.TabIndex = 12;
            PlayerpictureBox3.TabStop = false;
            // 
            // PlayerpictureBox4
            // 
            PlayerpictureBox4.Location = new Point(422, 293);
            PlayerpictureBox4.Margin = new Padding(4, 3, 4, 3);
            PlayerpictureBox4.Name = "PlayerpictureBox4";
            PlayerpictureBox4.Size = new Size(114, 166);
            PlayerpictureBox4.TabIndex = 13;
            PlayerpictureBox4.TabStop = false;
            // 
            // PlayerpictureBox5
            // 
            PlayerpictureBox5.Location = new Point(544, 293);
            PlayerpictureBox5.Margin = new Padding(4, 3, 4, 3);
            PlayerpictureBox5.Name = "PlayerpictureBox5";
            PlayerpictureBox5.Size = new Size(114, 166);
            PlayerpictureBox5.TabIndex = 14;
            PlayerpictureBox5.TabStop = false;
            // 
            // DealerPicture2
            // 
            DealerPicture2.Location = new Point(180, 121);
            DealerPicture2.Margin = new Padding(4, 3, 4, 3);
            DealerPicture2.Name = "DealerPicture2";
            DealerPicture2.Size = new Size(114, 166);
            DealerPicture2.TabIndex = 15;
            DealerPicture2.TabStop = false;
            // 
            // DealerPicture3
            // 
            DealerPicture3.Location = new Point(301, 121);
            DealerPicture3.Margin = new Padding(4, 3, 4, 3);
            DealerPicture3.Name = "DealerPicture3";
            DealerPicture3.Size = new Size(114, 166);
            DealerPicture3.TabIndex = 16;
            DealerPicture3.TabStop = false;
            // 
            // DealerPicture4
            // 
            DealerPicture4.Location = new Point(422, 121);
            DealerPicture4.Margin = new Padding(4, 3, 4, 3);
            DealerPicture4.Name = "DealerPicture4";
            DealerPicture4.Size = new Size(114, 166);
            DealerPicture4.TabIndex = 17;
            DealerPicture4.TabStop = false;
            // 
            // DealerPicture5
            // 
            DealerPicture5.Location = new Point(544, 121);
            DealerPicture5.Margin = new Padding(4, 3, 4, 3);
            DealerPicture5.Name = "DealerPicture5";
            DealerPicture5.Size = new Size(114, 166);
            DealerPicture5.TabIndex = 18;
            DealerPicture5.TabStop = false;
            // 
            // PlayerpictureBox6
            // 
            PlayerpictureBox6.Location = new Point(665, 293);
            PlayerpictureBox6.Margin = new Padding(4, 3, 4, 3);
            PlayerpictureBox6.Name = "PlayerpictureBox6";
            PlayerpictureBox6.Size = new Size(114, 166);
            PlayerpictureBox6.TabIndex = 19;
            PlayerpictureBox6.TabStop = false;
            // 
            // PlayerpictureBox7
            // 
            PlayerpictureBox7.Location = new Point(786, 293);
            PlayerpictureBox7.Margin = new Padding(4, 3, 4, 3);
            PlayerpictureBox7.Name = "PlayerpictureBox7";
            PlayerpictureBox7.Size = new Size(114, 166);
            PlayerpictureBox7.TabIndex = 20;
            PlayerpictureBox7.TabStop = false;
            // 
            // DealerPicture6
            // 
            DealerPicture6.Location = new Point(665, 121);
            DealerPicture6.Margin = new Padding(4, 3, 4, 3);
            DealerPicture6.Name = "DealerPicture6";
            DealerPicture6.Size = new Size(114, 166);
            DealerPicture6.TabIndex = 21;
            DealerPicture6.TabStop = false;
            // 
            // DealerPicture7
            // 
            DealerPicture7.Location = new Point(786, 121);
            DealerPicture7.Margin = new Padding(4, 3, 4, 3);
            DealerPicture7.Name = "DealerPicture7";
            DealerPicture7.Size = new Size(114, 166);
            DealerPicture7.TabIndex = 22;
            DealerPicture7.TabStop = false;
            // 
            // playerNameLabel
            // 
            playerNameLabel.AutoSize = true;
            playerNameLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            playerNameLabel.Location = new Point(12, 6);
            playerNameLabel.Name = "playerNameLabel";
            playerNameLabel.Size = new Size(80, 30);
            playerNameLabel.TabIndex = 23;
            playerNameLabel.Text = "Player:";
            // 
            // changeNameBTN
            // 
            changeNameBTN.Location = new Point(1279, 427);
            changeNameBTN.Name = "changeNameBTN";
            changeNameBTN.Size = new Size(120, 32);
            changeNameBTN.TabIndex = 25;
            changeNameBTN.Text = "Change Username";
            changeNameBTN.UseVisualStyleBackColor = true;
            changeNameBTN.Click += changeNameBTN_Click;
            // 
            // DeletePlayerBTN
            // 
            DeletePlayerBTN.Location = new Point(1142, 427);
            DeletePlayerBTN.Name = "DeletePlayerBTN";
            DeletePlayerBTN.Size = new Size(120, 32);
            DeletePlayerBTN.TabIndex = 26;
            DeletePlayerBTN.Text = "Delete Player:";
            DeletePlayerBTN.UseVisualStyleBackColor = true;
            DeletePlayerBTN.Click += DeletePlayerBTN_Click;
            // 
            // gameCardGridView
            // 
            gameCardGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gameCardGridView.Location = new Point(962, 40);
            gameCardGridView.Name = "gameCardGridView";
            gameCardGridView.RowTemplate.Height = 25;
            gameCardGridView.Size = new Size(448, 162);
            gameCardGridView.TabIndex = 27;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(962, 232);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowTemplate.Height = 25;
            dataGridView3.Size = new Size(448, 176);
            dataGridView3.TabIndex = 28;
            // 
            // PlayerTableGridView
            // 
            PlayerTableGridView.AutoSize = true;
            PlayerTableGridView.Location = new Point(962, 214);
            PlayerTableGridView.Name = "PlayerTableGridView";
            PlayerTableGridView.Size = new Size(72, 15);
            PlayerTableGridView.TabIndex = 29;
            PlayerTableGridView.Text = "Player Table:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(962, 22);
            label3.Name = "label3";
            label3.Size = new Size(96, 15);
            label3.TabIndex = 30;
            label3.Text = "GameCard Table:";
            // 
            // newPlayerBTN
            // 
            newPlayerBTN.Location = new Point(1279, 474);
            newPlayerBTN.Name = "newPlayerBTN";
            newPlayerBTN.Size = new Size(120, 32);
            newPlayerBTN.TabIndex = 31;
            newPlayerBTN.Text = "New Player:";
            newPlayerBTN.UseVisualStyleBackColor = true;
            newPlayerBTN.Click += newPlayerBTN_Click;
            // 
            // BlackJackForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1422, 519);
            Controls.Add(newPlayerBTN);
            Controls.Add(label3);
            Controls.Add(PlayerTableGridView);
            Controls.Add(dataGridView3);
            Controls.Add(gameCardGridView);
            Controls.Add(DeletePlayerBTN);
            Controls.Add(changeNameBTN);
            Controls.Add(playerNameLabel);
            Controls.Add(DealerPicture7);
            Controls.Add(DealerPicture6);
            Controls.Add(PlayerpictureBox7);
            Controls.Add(PlayerpictureBox6);
            Controls.Add(DealerPicture5);
            Controls.Add(DealerPicture4);
            Controls.Add(DealerPicture3);
            Controls.Add(DealerPicture2);
            Controls.Add(PlayerpictureBox5);
            Controls.Add(PlayerpictureBox4);
            Controls.Add(PlayerpictureBox3);
            Controls.Add(ResetButton);
            Controls.Add(DealerLabel);
            Controls.Add(PlayerLabel);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(PlayerpictureBox2);
            Controls.Add(PlayerpictureBox1);
            Controls.Add(DealerPicture1);
            Controls.Add(StartButton);
            Controls.Add(StandButton);
            Controls.Add(HitButton);
            Controls.Add(ShuffleButton);
            Margin = new Padding(4, 3, 4, 3);
            Name = "BlackJackForm";
            Text = "BlackJack";
            Load += BlackJackForm_Load;
            ((System.ComponentModel.ISupportInitialize)DealerPicture1).EndInit();
            ((System.ComponentModel.ISupportInitialize)PlayerpictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)PlayerpictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)PlayerpictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)PlayerpictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)PlayerpictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)DealerPicture2).EndInit();
            ((System.ComponentModel.ISupportInitialize)DealerPicture3).EndInit();
            ((System.ComponentModel.ISupportInitialize)DealerPicture4).EndInit();
            ((System.ComponentModel.ISupportInitialize)DealerPicture5).EndInit();
            ((System.ComponentModel.ISupportInitialize)PlayerpictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)PlayerpictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)DealerPicture6).EndInit();
            ((System.ComponentModel.ISupportInitialize)DealerPicture7).EndInit();
            ((System.ComponentModel.ISupportInitialize)gameCardGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ShuffleButton;
        private Button HitButton;
        private Button StandButton;
        private Button StartButton;
        private PictureBox DealerPicture1;
        private PictureBox PlayerpictureBox1;
        private PictureBox PlayerpictureBox2;
        private Label label1;
        private Label label2;
        private Label PlayerLabel;
        private Label DealerLabel;
        private Button ResetButton;
        private PictureBox PlayerpictureBox3;
        private PictureBox PlayerpictureBox4;
        private PictureBox PlayerpictureBox5;
        private PictureBox DealerPicture2;
        private PictureBox DealerPicture3;
        private PictureBox DealerPicture4;
        private PictureBox DealerPicture5;
        private PictureBox PlayerpictureBox6;
        private PictureBox PlayerpictureBox7;
        private PictureBox DealerPicture6;
        private PictureBox DealerPicture7;
        private Label playerNameLabel;
        private Button changeNameBTN;
        private Button DeletePlayerBTN;
        private DataGridView gameCardGridView;
        private DataGridView dataGridView3;
        private Label PlayerTableGridView;
        private Label label3;
        private Button newPlayerBTN;
    }
}

