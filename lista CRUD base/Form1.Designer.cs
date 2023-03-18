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
            this.CreateButton = new System.Windows.Forms.Button();
            this.GraphicTitle = new System.Windows.Forms.Label();
            this.ReadButton = new System.Windows.Forms.Button();
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
            this.Lista = new System.Windows.Forms.ListView();
            this.DescrizioneCreate = new System.Windows.Forms.ToolTip(this.components);
            this.CleareButton = new System.Windows.Forms.Button();
            this.ClearLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CreateButton
            // 
            this.CreateButton.BackColor = System.Drawing.Color.Fuchsia;
            this.CreateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateButton.Location = new System.Drawing.Point(100, 150);
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
            // ReadButton
            // 
            this.ReadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(250)))));
            this.ReadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReadButton.Location = new System.Drawing.Point(300, 150);
            this.ReadButton.Name = "ReadButton";
            this.ReadButton.Size = new System.Drawing.Size(120, 30);
            this.ReadButton.TabIndex = 1;
            this.ReadButton.Text = "Read";
            this.ReadButton.UseVisualStyleBackColor = false;
            this.ReadButton.Click += new System.EventHandler(this.ReadButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.Location = new System.Drawing.Point(300, 250);
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
            this.UpdateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateButton.Location = new System.Drawing.Point(100, 250);
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
            this.TextBox.Location = new System.Drawing.Point(100, 400);
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
            this.SearchBox.Location = new System.Drawing.Point(100, 350);
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
            this.PriceBox.Location = new System.Drawing.Point(300, 400);
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
            this.ConfirmButton.Location = new System.Drawing.Point(100, 470);
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
            this.CancelButton1.Location = new System.Drawing.Point(300, 470);
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
            this.SearchLabel.Location = new System.Drawing.Point(100, 331);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(41, 13);
            this.SearchLabel.TabIndex = 10;
            this.SearchLabel.Text = "Search";
            this.SearchLabel.Visible = false;
            // 
            // PriceLabel
            // 
            this.PriceLabel.AutoSize = true;
            this.PriceLabel.Location = new System.Drawing.Point(394, 384);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(31, 13);
            this.PriceLabel.TabIndex = 11;
            this.PriceLabel.Text = "Price";
            this.PriceLabel.Visible = false;
            // 
            // TextLabel
            // 
            this.TextLabel.AutoSize = true;
            this.TextLabel.Location = new System.Drawing.Point(100, 427);
            this.TextLabel.Name = "TextLabel";
            this.TextLabel.Size = new System.Drawing.Size(47, 13);
            this.TextLabel.TabIndex = 12;
            this.TextLabel.Text = "Prodotto";
            this.TextLabel.Visible = false;
            // 
            // Lista
            // 
            this.Lista.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lista.HideSelection = false;
            this.Lista.Location = new System.Drawing.Point(517, 76);
            this.Lista.Name = "Lista";
            this.Lista.Size = new System.Drawing.Size(387, 639);
            this.Lista.TabIndex = 16;
            this.Lista.UseCompatibleStateImageBehavior = false;
            this.Lista.View = System.Windows.Forms.View.List;
            // 
            // CleareButton
            // 
            this.CleareButton.BackColor = System.Drawing.Color.Black;
            this.CleareButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CleareButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CleareButton.ForeColor = System.Drawing.Color.Snow;
            this.CleareButton.Location = new System.Drawing.Point(246, 400);
            this.CleareButton.Name = "CleareButton";
            this.CleareButton.Size = new System.Drawing.Size(30, 30);
            this.CleareButton.TabIndex = 17;
            this.CleareButton.Text = "C";
            this.CleareButton.UseVisualStyleBackColor = false;
            this.CleareButton.Visible = false;
            this.CleareButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // ClearLabel
            // 
            this.ClearLabel.AutoSize = true;
            this.ClearLabel.Location = new System.Drawing.Point(245, 384);
            this.ClearLabel.Name = "ClearLabel";
            this.ClearLabel.Size = new System.Drawing.Size(31, 13);
            this.ClearLabel.TabIndex = 18;
            this.ClearLabel.Text = "Clear";
            this.ClearLabel.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(884, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 19;
            this.textBox1.Text = "senza file esterno";
            // 
            // CRUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(984, 759);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ClearLabel);
            this.Controls.Add(this.CleareButton);
            this.Controls.Add(this.Lista);
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
            this.Controls.Add(this.ReadButton);
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
		private System.Windows.Forms.Button ReadButton;
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
        private System.Windows.Forms.ListView Lista;
        private System.Windows.Forms.ToolTip DescrizioneCreate;
        private System.Windows.Forms.Button CleareButton;
        private System.Windows.Forms.Label ClearLabel;
        private System.Windows.Forms.TextBox textBox1;
    }
}

