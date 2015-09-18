namespace SseCsgoItemEditorGui
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
            this.grpFileLoad = new System.Windows.Forms.GroupBox();
            this.scFileLoad = new System.Windows.Forms.SplitContainer();
            this.grpItems_gameTxt = new System.Windows.Forms.GroupBox();
            this.btnBrowseItemsGame = new System.Windows.Forms.Button();
            this.lblItems_gameTxt = new System.Windows.Forms.Label();
            this.txtItems_games = new System.Windows.Forms.TextBox();
            this.grpItems_730Bin = new System.Windows.Forms.GroupBox();
            this.lblItems_730Bin = new System.Windows.Forms.Label();
            this.btnBrowseItems730 = new System.Windows.Forms.Button();
            this.txtItems_730Bin = new System.Windows.Forms.TextBox();
            this.btnReloadInv = new System.Windows.Forms.Button();
            this.ofdFileTxt = new System.Windows.Forms.OpenFileDialog();
            this.ofdFileBin = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabInventories = new System.Windows.Forms.TabPage();
            this.tlpInventoryManager = new System.Windows.Forms.TableLayoutPanel();
            this.btnRemove = new System.Windows.Forms.Button();
            this.clbInventories = new System.Windows.Forms.CheckedListBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.scInventory = new System.Windows.Forms.SplitContainer();
            this.gbInventoryDesc = new System.Windows.Forms.GroupBox();
            this.tlpInventoryDesc = new System.Windows.Forms.TableLayoutPanel();
            this.gbInventoryAttributes = new System.Windows.Forms.GroupBox();
            this.tlpInventoryAttr = new System.Windows.Forms.TableLayoutPanel();
            this.tabPageOfficialItemSet = new System.Windows.Forms.TabPage();
            this.tlpOfficialItems = new System.Windows.Forms.TableLayoutPanel();
            this.lvwItemSetDetails = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbItemSetsList = new System.Windows.Forms.GroupBox();
            this.clbItemSets = new System.Windows.Forms.CheckedListBox();
            this.chkStatTrakSets = new System.Windows.Forms.CheckBox();
            this.tabPageOfficialItems = new System.Windows.Forms.TabPage();
            this.scOfficialItems = new System.Windows.Forms.SplitContainer();
            this.gbRecognizedOfficialItems = new System.Windows.Forms.GroupBox();
            this.lvRecognizedOfficialItems = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chkCheckAll = new System.Windows.Forms.CheckBox();
            this.chkStatTrakOfficial = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpFileLoad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scFileLoad)).BeginInit();
            this.scFileLoad.Panel1.SuspendLayout();
            this.scFileLoad.Panel2.SuspendLayout();
            this.scFileLoad.SuspendLayout();
            this.grpItems_gameTxt.SuspendLayout();
            this.grpItems_730Bin.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabInventories.SuspendLayout();
            this.tlpInventoryManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scInventory)).BeginInit();
            this.scInventory.Panel1.SuspendLayout();
            this.scInventory.Panel2.SuspendLayout();
            this.scInventory.SuspendLayout();
            this.gbInventoryDesc.SuspendLayout();
            this.gbInventoryAttributes.SuspendLayout();
            this.tabPageOfficialItemSet.SuspendLayout();
            this.tlpOfficialItems.SuspendLayout();
            this.gbItemSetsList.SuspendLayout();
            this.tabPageOfficialItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scOfficialItems)).BeginInit();
            this.scOfficialItems.Panel1.SuspendLayout();
            this.scOfficialItems.Panel2.SuspendLayout();
            this.scOfficialItems.SuspendLayout();
            this.gbRecognizedOfficialItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpFileLoad
            // 
            this.grpFileLoad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFileLoad.Controls.Add(this.scFileLoad);
            this.grpFileLoad.Location = new System.Drawing.Point(13, 13);
            this.grpFileLoad.Name = "grpFileLoad";
            this.grpFileLoad.Size = new System.Drawing.Size(713, 81);
            this.grpFileLoad.TabIndex = 0;
            this.grpFileLoad.TabStop = false;
            this.grpFileLoad.Text = "File Load";
            // 
            // scFileLoad
            // 
            this.scFileLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scFileLoad.Location = new System.Drawing.Point(3, 16);
            this.scFileLoad.Name = "scFileLoad";
            // 
            // scFileLoad.Panel1
            // 
            this.scFileLoad.Panel1.Controls.Add(this.grpItems_gameTxt);
            // 
            // scFileLoad.Panel2
            // 
            this.scFileLoad.Panel2.Controls.Add(this.grpItems_730Bin);
            this.scFileLoad.Size = new System.Drawing.Size(707, 62);
            this.scFileLoad.SplitterDistance = 356;
            this.scFileLoad.TabIndex = 0;
            // 
            // grpItems_gameTxt
            // 
            this.grpItems_gameTxt.Controls.Add(this.btnBrowseItemsGame);
            this.grpItems_gameTxt.Controls.Add(this.lblItems_gameTxt);
            this.grpItems_gameTxt.Controls.Add(this.txtItems_games);
            this.grpItems_gameTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpItems_gameTxt.Location = new System.Drawing.Point(0, 0);
            this.grpItems_gameTxt.Name = "grpItems_gameTxt";
            this.grpItems_gameTxt.Size = new System.Drawing.Size(356, 62);
            this.grpItems_gameTxt.TabIndex = 0;
            this.grpItems_gameTxt.TabStop = false;
            this.grpItems_gameTxt.Text = "items_game.txt";
            // 
            // btnBrowseItemsGame
            // 
            this.btnBrowseItemsGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseItemsGame.Location = new System.Drawing.Point(274, 19);
            this.btnBrowseItemsGame.Name = "btnBrowseItemsGame";
            this.btnBrowseItemsGame.Size = new System.Drawing.Size(76, 23);
            this.btnBrowseItemsGame.TabIndex = 2;
            this.btnBrowseItemsGame.Text = "Browse";
            this.btnBrowseItemsGame.UseVisualStyleBackColor = true;
            this.btnBrowseItemsGame.Click += new System.EventHandler(this.btnBrowseItemsGame_Click);
            // 
            // lblItems_gameTxt
            // 
            this.lblItems_gameTxt.AutoSize = true;
            this.lblItems_gameTxt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblItems_gameTxt.Location = new System.Drawing.Point(3, 46);
            this.lblItems_gameTxt.Name = "lblItems_gameTxt";
            this.lblItems_gameTxt.Size = new System.Drawing.Size(106, 13);
            this.lblItems_gameTxt.TabIndex = 1;
            this.lblItems_gameTxt.Text = "items_game load info";
            // 
            // txtItems_games
            // 
            this.txtItems_games.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItems_games.Location = new System.Drawing.Point(6, 19);
            this.txtItems_games.Name = "txtItems_games";
            this.txtItems_games.Size = new System.Drawing.Size(262, 20);
            this.txtItems_games.TabIndex = 0;
            this.txtItems_games.Text = "items_game.txt path";
            // 
            // grpItems_730Bin
            // 
            this.grpItems_730Bin.Controls.Add(this.lblItems_730Bin);
            this.grpItems_730Bin.Controls.Add(this.btnBrowseItems730);
            this.grpItems_730Bin.Controls.Add(this.txtItems_730Bin);
            this.grpItems_730Bin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpItems_730Bin.Location = new System.Drawing.Point(0, 0);
            this.grpItems_730Bin.Name = "grpItems_730Bin";
            this.grpItems_730Bin.Size = new System.Drawing.Size(347, 62);
            this.grpItems_730Bin.TabIndex = 0;
            this.grpItems_730Bin.TabStop = false;
            this.grpItems_730Bin.Text = "items.bin";
            // 
            // lblItems_730Bin
            // 
            this.lblItems_730Bin.AutoSize = true;
            this.lblItems_730Bin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblItems_730Bin.Location = new System.Drawing.Point(3, 46);
            this.lblItems_730Bin.Name = "lblItems_730Bin";
            this.lblItems_730Bin.Size = new System.Drawing.Size(91, 13);
            this.lblItems_730Bin.TabIndex = 2;
            this.lblItems_730Bin.Text = "items.bin load info";
            // 
            // btnBrowseItems730
            // 
            this.btnBrowseItems730.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseItems730.Location = new System.Drawing.Point(263, 19);
            this.btnBrowseItems730.Name = "btnBrowseItems730";
            this.btnBrowseItems730.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseItems730.TabIndex = 1;
            this.btnBrowseItems730.Text = "Browse";
            this.btnBrowseItems730.UseVisualStyleBackColor = true;
            this.btnBrowseItems730.Click += new System.EventHandler(this.btnBrowseItems730_Click);
            // 
            // txtItems_730Bin
            // 
            this.txtItems_730Bin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItems_730Bin.Location = new System.Drawing.Point(6, 19);
            this.txtItems_730Bin.Name = "txtItems_730Bin";
            this.txtItems_730Bin.Size = new System.Drawing.Size(251, 20);
            this.txtItems_730Bin.TabIndex = 0;
            this.txtItems_730Bin.Text = "items.bin path";
            // 
            // btnReloadInv
            // 
            this.btnReloadInv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReloadInv.Location = new System.Drawing.Point(732, 13);
            this.btnReloadInv.Name = "btnReloadInv";
            this.btnReloadInv.Size = new System.Drawing.Size(89, 51);
            this.btnReloadInv.TabIndex = 3;
            this.btnReloadInv.Text = "Reload";
            this.btnReloadInv.UseVisualStyleBackColor = true;
            this.btnReloadInv.Click += new System.EventHandler(this.btnRescanInv_Click);
            // 
            // ofdFileTxt
            // 
            this.ofdFileTxt.FileName = "items_game.txt";
            this.ofdFileTxt.Filter = "CSGO items_game.txt file|items_game.txt";
            this.ofdFileTxt.ReadOnlyChecked = true;
            this.ofdFileTxt.Title = "Locate items_game.txt";
            // 
            // ofdFileBin
            // 
            this.ofdFileBin.FileName = "items.bin";
            this.ofdFileBin.Filter = "SSE items.bin file|items.bin";
            this.ofdFileBin.Title = "Locate items.bin";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabInventories);
            this.tabControl1.Controls.Add(this.tabPageOfficialItemSet);
            this.tabControl1.Controls.Add(this.tabPageOfficialItems);
            this.tabControl1.Location = new System.Drawing.Point(13, 100);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(812, 420);
            this.tabControl1.TabIndex = 1;
            // 
            // tabInventories
            // 
            this.tabInventories.Controls.Add(this.tlpInventoryManager);
            this.tabInventories.Location = new System.Drawing.Point(4, 22);
            this.tabInventories.Name = "tabInventories";
            this.tabInventories.Padding = new System.Windows.Forms.Padding(3);
            this.tabInventories.Size = new System.Drawing.Size(804, 394);
            this.tabInventories.TabIndex = 1;
            this.tabInventories.Text = "Inventories";
            this.tabInventories.UseVisualStyleBackColor = true;
            // 
            // tlpInventoryManager
            // 
            this.tlpInventoryManager.ColumnCount = 2;
            this.tlpInventoryManager.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInventoryManager.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 511F));
            this.tlpInventoryManager.Controls.Add(this.btnRemove, 1, 1);
            this.tlpInventoryManager.Controls.Add(this.clbInventories, 0, 0);
            this.tlpInventoryManager.Controls.Add(this.btnAddItem, 0, 1);
            this.tlpInventoryManager.Controls.Add(this.scInventory, 1, 0);
            this.tlpInventoryManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInventoryManager.Location = new System.Drawing.Point(3, 3);
            this.tlpInventoryManager.Name = "tlpInventoryManager";
            this.tlpInventoryManager.RowCount = 2;
            this.tlpInventoryManager.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.71951F));
            this.tlpInventoryManager.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.28049F));
            this.tlpInventoryManager.Size = new System.Drawing.Size(798, 388);
            this.tlpInventoryManager.TabIndex = 0;
            // 
            // btnRemove
            // 
            this.btnRemove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemove.Location = new System.Drawing.Point(290, 347);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(505, 38);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove Selected";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // clbInventories
            // 
            this.clbInventories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbInventories.FormattingEnabled = true;
            this.clbInventories.Location = new System.Drawing.Point(3, 3);
            this.clbInventories.Name = "clbInventories";
            this.clbInventories.Size = new System.Drawing.Size(281, 338);
            this.clbInventories.TabIndex = 3;
            this.clbInventories.SelectedIndexChanged += new System.EventHandler(this.clbInventories_SelectedIndexChanged);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddItem.Location = new System.Drawing.Point(3, 347);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(281, 38);
            this.btnAddItem.TabIndex = 1;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // scInventory
            // 
            this.scInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scInventory.Location = new System.Drawing.Point(290, 3);
            this.scInventory.Name = "scInventory";
            this.scInventory.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scInventory.Panel1
            // 
            this.scInventory.Panel1.Controls.Add(this.gbInventoryDesc);
            // 
            // scInventory.Panel2
            // 
            this.scInventory.Panel2.Controls.Add(this.gbInventoryAttributes);
            this.scInventory.Size = new System.Drawing.Size(505, 338);
            this.scInventory.SplitterDistance = 139;
            this.scInventory.TabIndex = 4;
            // 
            // gbInventoryDesc
            // 
            this.gbInventoryDesc.Controls.Add(this.tlpInventoryDesc);
            this.gbInventoryDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbInventoryDesc.Location = new System.Drawing.Point(0, 0);
            this.gbInventoryDesc.Name = "gbInventoryDesc";
            this.gbInventoryDesc.Size = new System.Drawing.Size(505, 139);
            this.gbInventoryDesc.TabIndex = 0;
            this.gbInventoryDesc.TabStop = false;
            this.gbInventoryDesc.Text = "Description";
            // 
            // tlpInventoryDesc
            // 
            this.tlpInventoryDesc.AutoScroll = true;
            this.tlpInventoryDesc.AutoSize = true;
            this.tlpInventoryDesc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpInventoryDesc.ColumnCount = 2;
            this.tlpInventoryDesc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.60686F));
            this.tlpInventoryDesc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.39314F));
            this.tlpInventoryDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInventoryDesc.Location = new System.Drawing.Point(3, 16);
            this.tlpInventoryDesc.Name = "tlpInventoryDesc";
            this.tlpInventoryDesc.RowCount = 1;
            this.tlpInventoryDesc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpInventoryDesc.Size = new System.Drawing.Size(499, 120);
            this.tlpInventoryDesc.TabIndex = 0;
            // 
            // gbInventoryAttributes
            // 
            this.gbInventoryAttributes.Controls.Add(this.tlpInventoryAttr);
            this.gbInventoryAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbInventoryAttributes.Location = new System.Drawing.Point(0, 0);
            this.gbInventoryAttributes.Name = "gbInventoryAttributes";
            this.gbInventoryAttributes.Size = new System.Drawing.Size(505, 195);
            this.gbInventoryAttributes.TabIndex = 0;
            this.gbInventoryAttributes.TabStop = false;
            this.gbInventoryAttributes.Text = "Attributes";
            // 
            // tlpInventoryAttr
            // 
            this.tlpInventoryAttr.AutoScroll = true;
            this.tlpInventoryAttr.AutoSize = true;
            this.tlpInventoryAttr.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpInventoryAttr.ColumnCount = 3;
            this.tlpInventoryAttr.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpInventoryAttr.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpInventoryAttr.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 499F));
            this.tlpInventoryAttr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInventoryAttr.Location = new System.Drawing.Point(3, 16);
            this.tlpInventoryAttr.Name = "tlpInventoryAttr";
            this.tlpInventoryAttr.RowCount = 1;
            this.tlpInventoryAttr.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpInventoryAttr.Size = new System.Drawing.Size(499, 176);
            this.tlpInventoryAttr.TabIndex = 0;
            // 
            // tabPageOfficialItemSet
            // 
            this.tabPageOfficialItemSet.Controls.Add(this.tlpOfficialItems);
            this.tabPageOfficialItemSet.Location = new System.Drawing.Point(4, 22);
            this.tabPageOfficialItemSet.Name = "tabPageOfficialItemSet";
            this.tabPageOfficialItemSet.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOfficialItemSet.Size = new System.Drawing.Size(804, 394);
            this.tabPageOfficialItemSet.TabIndex = 2;
            this.tabPageOfficialItemSet.Text = "Official Item Sets";
            this.tabPageOfficialItemSet.UseVisualStyleBackColor = true;
            // 
            // tlpOfficialItems
            // 
            this.tlpOfficialItems.ColumnCount = 2;
            this.tlpOfficialItems.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.57644F));
            this.tlpOfficialItems.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.42356F));
            this.tlpOfficialItems.Controls.Add(this.lvwItemSetDetails, 1, 0);
            this.tlpOfficialItems.Controls.Add(this.gbItemSetsList, 0, 0);
            this.tlpOfficialItems.Controls.Add(this.chkStatTrakSets, 0, 1);
            this.tlpOfficialItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpOfficialItems.Location = new System.Drawing.Point(3, 3);
            this.tlpOfficialItems.Name = "tlpOfficialItems";
            this.tlpOfficialItems.RowCount = 2;
            this.tlpOfficialItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpOfficialItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpOfficialItems.Size = new System.Drawing.Size(798, 388);
            this.tlpOfficialItems.TabIndex = 0;
            // 
            // lvwItemSetDetails
            // 
            this.lvwItemSetDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader5});
            this.lvwItemSetDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwItemSetDetails.Location = new System.Drawing.Point(246, 3);
            this.lvwItemSetDetails.Name = "lvwItemSetDetails";
            this.lvwItemSetDetails.Size = new System.Drawing.Size(549, 347);
            this.lvwItemSetDetails.TabIndex = 0;
            this.lvwItemSetDetails.UseCompatibleStateImageBehavior = false;
            this.lvwItemSetDetails.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Weapon";
            this.columnHeader1.Width = 219;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Paint";
            this.columnHeader2.Width = 234;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Rarity";
            // 
            // gbItemSetsList
            // 
            this.gbItemSetsList.Controls.Add(this.clbItemSets);
            this.gbItemSetsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbItemSetsList.Location = new System.Drawing.Point(3, 3);
            this.gbItemSetsList.Name = "gbItemSetsList";
            this.gbItemSetsList.Size = new System.Drawing.Size(237, 347);
            this.gbItemSetsList.TabIndex = 0;
            this.gbItemSetsList.TabStop = false;
            this.gbItemSetsList.Text = "Official Item Sets";
            // 
            // clbItemSets
            // 
            this.clbItemSets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbItemSets.FormattingEnabled = true;
            this.clbItemSets.Location = new System.Drawing.Point(3, 16);
            this.clbItemSets.Name = "clbItemSets";
            this.clbItemSets.Size = new System.Drawing.Size(231, 328);
            this.clbItemSets.TabIndex = 0;
            this.clbItemSets.SelectedIndexChanged += new System.EventHandler(this.clbItemSets_SelectedIndexChanged);
            // 
            // chkStatTrakSets
            // 
            this.chkStatTrakSets.AutoSize = true;
            this.chkStatTrakSets.Location = new System.Drawing.Point(3, 356);
            this.chkStatTrakSets.Name = "chkStatTrakSets";
            this.chkStatTrakSets.Size = new System.Drawing.Size(89, 17);
            this.chkStatTrakSets.TabIndex = 1;
            this.chkStatTrakSets.Text = "Add StatTrak";
            this.chkStatTrakSets.UseVisualStyleBackColor = true;
            // 
            // tabPageOfficialItems
            // 
            this.tabPageOfficialItems.Controls.Add(this.scOfficialItems);
            this.tabPageOfficialItems.Location = new System.Drawing.Point(4, 22);
            this.tabPageOfficialItems.Name = "tabPageOfficialItems";
            this.tabPageOfficialItems.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOfficialItems.Size = new System.Drawing.Size(804, 394);
            this.tabPageOfficialItems.TabIndex = 3;
            this.tabPageOfficialItems.Text = "Official Items";
            this.tabPageOfficialItems.UseVisualStyleBackColor = true;
            // 
            // scOfficialItems
            // 
            this.scOfficialItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scOfficialItems.IsSplitterFixed = true;
            this.scOfficialItems.Location = new System.Drawing.Point(3, 3);
            this.scOfficialItems.Name = "scOfficialItems";
            this.scOfficialItems.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scOfficialItems.Panel1
            // 
            this.scOfficialItems.Panel1.Controls.Add(this.gbRecognizedOfficialItems);
            // 
            // scOfficialItems.Panel2
            // 
            this.scOfficialItems.Panel2.Controls.Add(this.chkCheckAll);
            this.scOfficialItems.Panel2.Controls.Add(this.chkStatTrakOfficial);
            this.scOfficialItems.Size = new System.Drawing.Size(798, 388);
            this.scOfficialItems.SplitterDistance = 337;
            this.scOfficialItems.TabIndex = 1;
            // 
            // gbRecognizedOfficialItems
            // 
            this.gbRecognizedOfficialItems.Controls.Add(this.lvRecognizedOfficialItems);
            this.gbRecognizedOfficialItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbRecognizedOfficialItems.Location = new System.Drawing.Point(0, 0);
            this.gbRecognizedOfficialItems.Name = "gbRecognizedOfficialItems";
            this.gbRecognizedOfficialItems.Size = new System.Drawing.Size(798, 337);
            this.gbRecognizedOfficialItems.TabIndex = 0;
            this.gbRecognizedOfficialItems.TabStop = false;
            this.gbRecognizedOfficialItems.Text = "Recognized Official Items";
            // 
            // lvRecognizedOfficialItems
            // 
            this.lvRecognizedOfficialItems.CheckBoxes = true;
            this.lvRecognizedOfficialItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader6});
            this.lvRecognizedOfficialItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRecognizedOfficialItems.Location = new System.Drawing.Point(3, 16);
            this.lvRecognizedOfficialItems.Name = "lvRecognizedOfficialItems";
            this.lvRecognizedOfficialItems.Size = new System.Drawing.Size(792, 318);
            this.lvRecognizedOfficialItems.TabIndex = 1;
            this.lvRecognizedOfficialItems.UseCompatibleStateImageBehavior = false;
            this.lvRecognizedOfficialItems.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Weapon";
            this.columnHeader3.Width = 219;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Paint";
            this.columnHeader4.Width = 234;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Rarity";
            // 
            // chkCheckAll
            // 
            this.chkCheckAll.AutoSize = true;
            this.chkCheckAll.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chkCheckAll.Location = new System.Drawing.Point(0, 30);
            this.chkCheckAll.Name = "chkCheckAll";
            this.chkCheckAll.Size = new System.Drawing.Size(798, 17);
            this.chkCheckAll.TabIndex = 3;
            this.chkCheckAll.Text = "Check All";
            this.chkCheckAll.UseVisualStyleBackColor = true;
            this.chkCheckAll.CheckedChanged += new System.EventHandler(this.chkCheckAll_CheckedChanged);
            // 
            // chkStatTrakOfficial
            // 
            this.chkStatTrakOfficial.AutoSize = true;
            this.chkStatTrakOfficial.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkStatTrakOfficial.Location = new System.Drawing.Point(0, 0);
            this.chkStatTrakOfficial.Name = "chkStatTrakOfficial";
            this.chkStatTrakOfficial.Size = new System.Drawing.Size(798, 17);
            this.chkStatTrakOfficial.TabIndex = 2;
            this.chkStatTrakOfficial.Text = "Add StatTrak";
            this.chkStatTrakOfficial.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(732, 70);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 46);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 532);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnReloadInv);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.grpFileLoad);
            this.MinimumSize = new System.Drawing.Size(845, 510);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "CSGO SSE Inventory Manager 0.4.8 - [x3r0]";
            this.grpFileLoad.ResumeLayout(false);
            this.scFileLoad.Panel1.ResumeLayout(false);
            this.scFileLoad.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scFileLoad)).EndInit();
            this.scFileLoad.ResumeLayout(false);
            this.grpItems_gameTxt.ResumeLayout(false);
            this.grpItems_gameTxt.PerformLayout();
            this.grpItems_730Bin.ResumeLayout(false);
            this.grpItems_730Bin.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabInventories.ResumeLayout(false);
            this.tlpInventoryManager.ResumeLayout(false);
            this.scInventory.Panel1.ResumeLayout(false);
            this.scInventory.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scInventory)).EndInit();
            this.scInventory.ResumeLayout(false);
            this.gbInventoryDesc.ResumeLayout(false);
            this.gbInventoryDesc.PerformLayout();
            this.gbInventoryAttributes.ResumeLayout(false);
            this.gbInventoryAttributes.PerformLayout();
            this.tabPageOfficialItemSet.ResumeLayout(false);
            this.tlpOfficialItems.ResumeLayout(false);
            this.tlpOfficialItems.PerformLayout();
            this.gbItemSetsList.ResumeLayout(false);
            this.tabPageOfficialItems.ResumeLayout(false);
            this.scOfficialItems.Panel1.ResumeLayout(false);
            this.scOfficialItems.Panel2.ResumeLayout(false);
            this.scOfficialItems.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scOfficialItems)).EndInit();
            this.scOfficialItems.ResumeLayout(false);
            this.gbRecognizedOfficialItems.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpFileLoad;
        private System.Windows.Forms.SplitContainer scFileLoad;
        private System.Windows.Forms.GroupBox grpItems_gameTxt;
        private System.Windows.Forms.Label lblItems_gameTxt;
        private System.Windows.Forms.TextBox txtItems_games;
        private System.Windows.Forms.OpenFileDialog ofdFileTxt;
        private System.Windows.Forms.Button btnBrowseItemsGame;
        private System.Windows.Forms.GroupBox grpItems_730Bin;
        private System.Windows.Forms.Button btnBrowseItems730;
        private System.Windows.Forms.TextBox txtItems_730Bin;
        private System.Windows.Forms.Label lblItems_730Bin;
        private System.Windows.Forms.OpenFileDialog ofdFileBin;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabInventories;
        private System.Windows.Forms.Button btnReloadInv;
        private System.Windows.Forms.TableLayoutPanel tlpInventoryManager;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.SplitContainer scInventory;
        private System.Windows.Forms.GroupBox gbInventoryDesc;
        private System.Windows.Forms.TableLayoutPanel tlpInventoryDesc;
        private System.Windows.Forms.GroupBox gbInventoryAttributes;
        private System.Windows.Forms.TableLayoutPanel tlpInventoryAttr;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckedListBox clbInventories;
        private System.Windows.Forms.TabPage tabPageOfficialItemSet;
        private System.Windows.Forms.GroupBox gbItemSetsList;
        private System.Windows.Forms.CheckedListBox clbItemSets;
        private System.Windows.Forms.ListView lvwItemSetDetails;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TableLayoutPanel tlpOfficialItems;
        private System.Windows.Forms.CheckBox chkStatTrakSets;
        private System.Windows.Forms.TabPage tabPageOfficialItems;
        private System.Windows.Forms.SplitContainer scOfficialItems;
        private System.Windows.Forms.GroupBox gbRecognizedOfficialItems;
        private System.Windows.Forms.ListView lvRecognizedOfficialItems;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.CheckBox chkStatTrakOfficial;
        private System.Windows.Forms.CheckBox chkCheckAll;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}

