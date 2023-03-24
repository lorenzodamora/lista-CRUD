namespace lista_CRUD
{
	partial class CRUD
	{
		/// <summary>
		/// Variabile di progettazione necessaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Pulire le risorse in uso.
		/// </summary>
		/// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Codice generato da Progettazione Windows Form

		/// <summary>
		/// Metodo necessario per il supporto della finestra di progettazione. Non modificare
		/// il contenuto del metodo con l'editor di codice.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CRUD));
            this.CreateButton = new System.Windows.Forms.Button();
            this.GraphicTitle = new System.Windows.Forms.Label();
            this.TwinButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.TextBox = new System.Windows.Forms.TextBox();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.PriceBox = new System.Windows.Forms.TextBox();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.CancelButton1 = new System.Windows.Forms.Button();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.TextLabel = new System.Windows.Forms.Label();
            this.ListaProdotti = new System.Windows.Forms.ListView();
            this.DescrizioneCreate = new System.Windows.Forms.ToolTip(this.components);
            this.ClearButton = new System.Windows.Forms.Button();
            this.ClearLabel = new System.Windows.Forms.Label();
            this.file_esterno = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.NameList = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CreateButton
            // 
            this.CreateButton.BackColor = System.Drawing.Color.Fuchsia;
            this.CreateButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CreateButton.BackgroundImage")));
            this.CreateButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CreateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateButton.Location = new System.Drawing.Point(100, 125);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(120, 30);
            this.CreateButton.TabIndex = 0;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = false;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // GraphicTitle
            // 
            this.GraphicTitle.BackColor = System.Drawing.Color.Black;
            this.GraphicTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.30189F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GraphicTitle.ForeColor = System.Drawing.Color.White;
            this.GraphicTitle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.GraphicTitle.Location = new System.Drawing.Point(300, 10);
            this.GraphicTitle.Name = "GraphicTitle";
            this.GraphicTitle.Size = new System.Drawing.Size(400, 40);
            this.GraphicTitle.TabIndex = 15;
            this.GraphicTitle.Text = "GESTIONE PRODOTTI CRUD";
            this.GraphicTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TwinButton
            // 
            this.TwinButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(250)))));
            this.TwinButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TwinButton.BackgroundImage")));
            this.TwinButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TwinButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TwinButton.Location = new System.Drawing.Point(300, 125);
            this.TwinButton.Name = "TwinButton";
            this.TwinButton.Size = new System.Drawing.Size(120, 30);
            this.TwinButton.TabIndex = 1;
            this.TwinButton.Text = "Twin";
            this.TwinButton.UseVisualStyleBackColor = false;
            this.TwinButton.Visible = false;
            this.TwinButton.Click += new System.EventHandler(this.TwinButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.Location = new System.Drawing.Point(300, 200);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(120, 30);
            this.DeleteButton.TabIndex = 3;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Visible = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateButton.Location = new System.Drawing.Point(100, 200);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(120, 30);
            this.UpdateButton.TabIndex = 2;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = false;
            this.UpdateButton.Visible = false;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // TextBox
            // 
            this.TextBox.AutoCompleteCustomSource.AddRange(new string[] {
            "Pane",
            "Pasta",
            "Tonno",
            "Pomodori"});
            this.TextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox.Location = new System.Drawing.Point(100, 550);
            this.TextBox.MaxLength = 20;
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(125, 24);
            this.TextBox.TabIndex = 5;
            this.TextBox.Visible = false;
            // 
            // SearchBox
            // 
            this.SearchBox.AutoCompleteCustomSource.AddRange(new string[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13"});
            this.SearchBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.SearchBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.SearchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SearchBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBox.Location = new System.Drawing.Point(100, 500);
            this.SearchBox.MaxLength = 20;
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(125, 24);
            this.SearchBox.TabIndex = 4;
            this.SearchBox.Visible = false;
            // 
            // PriceBox
            // 
            this.PriceBox.AutoCompleteCustomSource.AddRange(new string[] {
            "1,00",
            "50,34",
            "23,56"});
            this.PriceBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.PriceBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.PriceBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PriceBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PriceBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PriceBox.Location = new System.Drawing.Point(300, 550);
            this.PriceBox.MaxLength = 20;
            this.PriceBox.Name = "PriceBox";
            this.PriceBox.Size = new System.Drawing.Size(125, 24);
            this.PriceBox.TabIndex = 6;
            this.PriceBox.Visible = false;
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ConfirmButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfirmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmButton.Location = new System.Drawing.Point(100, 620);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(120, 30);
            this.ConfirmButton.TabIndex = 7;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = false;
            this.ConfirmButton.Visible = false;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // CancelButton1
            // 
            this.CancelButton1.BackColor = System.Drawing.Color.Red;
            this.CancelButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton1.Location = new System.Drawing.Point(300, 620);
            this.CancelButton1.Name = "CancelButton1";
            this.CancelButton1.Size = new System.Drawing.Size(120, 30);
            this.CancelButton1.TabIndex = 8;
            this.CancelButton1.Text = "Cancel";
            this.CancelButton1.UseVisualStyleBackColor = false;
            this.CancelButton1.Visible = false;
            this.CancelButton1.Click += new System.EventHandler(this.CancelButton1_Click);
            // 
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Location = new System.Drawing.Point(100, 481);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(41, 13);
            this.SearchLabel.TabIndex = 10;
            this.SearchLabel.Text = "Search";
            this.SearchLabel.Visible = false;
            // 
            // PriceLabel
            // 
            this.PriceLabel.AutoSize = true;
            this.PriceLabel.Location = new System.Drawing.Point(394, 534);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(31, 13);
            this.PriceLabel.TabIndex = 11;
            this.PriceLabel.Text = "Price";
            this.PriceLabel.Visible = false;
            // 
            // TextLabel
            // 
            this.TextLabel.AutoSize = true;
            this.TextLabel.Location = new System.Drawing.Point(100, 577);
            this.TextLabel.Name = "TextLabel";
            this.TextLabel.Size = new System.Drawing.Size(47, 13);
            this.TextLabel.TabIndex = 12;
            this.TextLabel.Text = "Prodotto";
            this.TextLabel.Visible = false;
            // 
            // ListaProdotti
            // 
            this.ListaProdotti.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListaProdotti.HideSelection = false;
            this.ListaProdotti.Location = new System.Drawing.Point(525, 150);
            this.ListaProdotti.Name = "ListaProdotti";
            this.ListaProdotti.Size = new System.Drawing.Size(400, 575);
            this.ListaProdotti.TabIndex = 16;
            this.ListaProdotti.UseCompatibleStateImageBehavior = false;
            this.ListaProdotti.View = System.Windows.Forms.View.List;
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.Color.Black;
            this.ClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearButton.ForeColor = System.Drawing.Color.Snow;
            this.ClearButton.Location = new System.Drawing.Point(246, 550);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(30, 30);
            this.ClearButton.TabIndex = 17;
            this.ClearButton.Text = "C";
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Visible = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // ClearLabel
            // 
            this.ClearLabel.AutoSize = true;
            this.ClearLabel.Location = new System.Drawing.Point(245, 534);
            this.ClearLabel.Name = "ClearLabel";
            this.ClearLabel.Size = new System.Drawing.Size(31, 13);
            this.ClearLabel.TabIndex = 18;
            this.ClearLabel.Text = "Clear";
            this.ClearLabel.Visible = false;
            // 
            // file_esterno
            // 
            this.file_esterno.Location = new System.Drawing.Point(882, -1);
            this.file_esterno.Name = "file_esterno";
            this.file_esterno.Size = new System.Drawing.Size(100, 20);
            this.file_esterno.TabIndex = 20;
            this.file_esterno.Text = "con file esterno";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Fuchsia;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(100, 300);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 30);
            this.button1.TabIndex = 21;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Fuchsia;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(100, 375);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 30);
            this.button2.TabIndex = 22;
            this.button2.Text = "Edit";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Fuchsia;
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(300, 375);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 30);
            this.button3.TabIndex = 23;
            this.button3.Text = "Remove";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(250)))));
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(300, 300);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 30);
            this.button4.TabIndex = 24;
            this.button4.Text = "Duplicate";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Visible = false;
            // 
            // NameList
            // 
            this.NameList.AutoCompleteCustomSource.AddRange(new string[] {
            "1,00",
            "50,34",
            "23,56"});
            this.NameList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.NameList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.NameList.BackColor = System.Drawing.Color.White;
            this.NameList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameList.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.NameList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameList.ForeColor = System.Drawing.Color.Black;
            this.NameList.Location = new System.Drawing.Point(525, 120);
            this.NameList.MaxLength = 100;
            this.NameList.Name = "NameList";
            this.NameList.ReadOnly = true;
            this.NameList.Size = new System.Drawing.Size(400, 24);
            this.NameList.TabIndex = 25;
            this.NameList.Text = "Non è aperta nessuna lista";
            // 
            // CRUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(984, 759);
            this.Controls.Add(this.NameList);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.file_esterno);
            this.Controls.Add(this.ClearLabel);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.ListaProdotti);
            this.Controls.Add(this.TextLabel);
            this.Controls.Add(this.PriceLabel);
            this.Controls.Add(this.SearchLabel);
            this.Controls.Add(this.CancelButton1);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.PriceBox);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.TextBox);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.TwinButton);
            this.Controls.Add(this.GraphicTitle);
            this.Controls.Add(this.CreateButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CRUD";
            this.Text = "Lista CRUD";
            this.Load += new System.EventHandler(this.CRUD_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button CreateButton;
		private System.Windows.Forms.Label GraphicTitle;
		private System.Windows.Forms.Button TwinButton;
		private System.Windows.Forms.Button DeleteButton;
		private System.Windows.Forms.Button UpdateButton;
		private System.Windows.Forms.TextBox TextBox;
		private System.Windows.Forms.TextBox SearchBox;
		private System.Windows.Forms.TextBox PriceBox;
		private System.Windows.Forms.Button ConfirmButton;
		private System.Windows.Forms.Button CancelButton1;
		private System.Windows.Forms.Label SearchLabel;
		private System.Windows.Forms.Label PriceLabel;
		private System.Windows.Forms.Label TextLabel;
        private System.Windows.Forms.ListView ListaProdotti;
        private System.Windows.Forms.ToolTip DescrizioneCreate;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Label ClearLabel;
        private System.Windows.Forms.TextBox file_esterno;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox NameList;
    }
}

