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
            this.MoveButton = new System.Windows.Forms.Button();
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
            this.AddButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.TwinButton = new System.Windows.Forms.Button();
            this.NameList = new System.Windows.Forms.TextBox();
            this.HistoryRButton = new System.Windows.Forms.Button();
            this.DescrizioneHistoryR = new System.Windows.Forms.ToolTip(this.components);
            this.ChiudiFormButton = new System.Windows.Forms.Button();
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
            // MoveButton
            // 
            this.MoveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(250)))));
            this.MoveButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MoveButton.BackgroundImage")));
            this.MoveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MoveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveButton.Location = new System.Drawing.Point(300, 125);
            this.MoveButton.Name = "MoveButton";
            this.MoveButton.Size = new System.Drawing.Size(120, 30);
            this.MoveButton.TabIndex = 1;
            this.MoveButton.Text = "Move";
            this.MoveButton.UseVisualStyleBackColor = false;
            this.MoveButton.Visible = false;
            this.MoveButton.Click += new System.EventHandler(this.MoveButton_Click);
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
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.Fuchsia;
            this.AddButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddButton.BackgroundImage")));
            this.AddButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Location = new System.Drawing.Point(100, 300);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(120, 30);
            this.AddButton.TabIndex = 21;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Visible = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.BackColor = System.Drawing.Color.Fuchsia;
            this.EditButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EditButton.BackgroundImage")));
            this.EditButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.EditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditButton.Location = new System.Drawing.Point(100, 375);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(120, 30);
            this.EditButton.TabIndex = 22;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = false;
            this.EditButton.Visible = false;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.BackColor = System.Drawing.Color.Fuchsia;
            this.RemoveButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RemoveButton.BackgroundImage")));
            this.RemoveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RemoveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveButton.Location = new System.Drawing.Point(300, 375);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(120, 30);
            this.RemoveButton.TabIndex = 23;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = false;
            this.RemoveButton.Visible = false;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // TwinButton
            // 
            this.TwinButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(250)))));
            this.TwinButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TwinButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TwinButton.Location = new System.Drawing.Point(300, 300);
            this.TwinButton.Name = "TwinButton";
            this.TwinButton.Size = new System.Drawing.Size(120, 30);
            this.TwinButton.TabIndex = 24;
            this.TwinButton.Text = "Twin";
            this.TwinButton.UseVisualStyleBackColor = false;
            this.TwinButton.Visible = false;
            this.TwinButton.Click += new System.EventHandler(this.TwinButton_Click);
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
            // HistoryRButton
            // 
            this.HistoryRButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.HistoryRButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.HistoryRButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HistoryRButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HistoryRButton.ForeColor = System.Drawing.Color.White;
            this.HistoryRButton.Location = new System.Drawing.Point(430, 375);
            this.HistoryRButton.Name = "HistoryRButton";
            this.HistoryRButton.Size = new System.Drawing.Size(30, 30);
            this.HistoryRButton.TabIndex = 26;
            this.HistoryRButton.Text = "H";
            this.HistoryRButton.UseVisualStyleBackColor = false;
            this.HistoryRButton.Visible = false;
            this.HistoryRButton.Click += new System.EventHandler(this.HistoryRButton_Click);
            // 
            // ChiudiFormButton
            // 
            this.ChiudiFormButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ChiudiFormButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ChiudiFormButton.BackgroundImage")));
            this.ChiudiFormButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChiudiFormButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChiudiFormButton.Location = new System.Drawing.Point(0, 0);
            this.ChiudiFormButton.Name = "ChiudiFormButton";
            this.ChiudiFormButton.Size = new System.Drawing.Size(20, 20);
            this.ChiudiFormButton.TabIndex = 27;
            this.ChiudiFormButton.UseVisualStyleBackColor = false;
            this.ChiudiFormButton.Visible = false;
            this.ChiudiFormButton.Click += new System.EventHandler(this.ChiudiFormButton_Click);
            // 
            // CRUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(984, 759);
            this.Controls.Add(this.ChiudiFormButton);
            this.Controls.Add(this.HistoryRButton);
            this.Controls.Add(this.NameList);
            this.Controls.Add(this.TwinButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.AddButton);
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
            this.Controls.Add(this.MoveButton);
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
		private System.Windows.Forms.Button MoveButton;
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
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button TwinButton;
        private System.Windows.Forms.TextBox NameList;
        private System.Windows.Forms.Button HistoryRButton;
        private System.Windows.Forms.ToolTip DescrizioneHistoryR;
        private System.Windows.Forms.Button ChiudiFormButton;
    }
}

