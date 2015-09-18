using CsgoItemDataType;
using CsgoItemDataType.FriendlyDataType;
using ItemEditor;
using SseCsgoItemEditorGui.InventoryHelper;
using SteamKit2.GC.Internal;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ValveKvReader;

namespace SseCsgoItemEditorGui
{
    public partial class MainForm : Form
    {
        private InventoryFileLoader _inventoryFileLoader;
        private CsgoItemsGameFileParser _kvFileReader;
        private InventoryRetriever _invRetriever;
        private CompleteItemInfo savedSelected;
        private int currentSelectedItemIdx = -1, oldSelectedItemIdx;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnBrowseItemsGame_Click(object sender, EventArgs e)
        {
            if (ofdFileTxt.ShowDialog() == DialogResult.OK)
            {
                txtItems_games.Text = ofdFileTxt.FileName;

                _kvFileReader = new CsgoItemsGameFileParser(ofdFileTxt.FileName);

                if (_kvFileReader.IsValid)
                {
                    lblItems_gameTxt.ForeColor = Color.Green;
                    lblItems_gameTxt.Text = @"Correct file";
                }
                else
                {
                    lblItems_gameTxt.ForeColor = Color.Red;
                    lblItems_gameTxt.Text = @"Invalid file";
                }
            }
        }

        ListViewItem lvItem;
        private void btnBrowseItems730_Click(object sender, EventArgs e)
        {
            if (ofdFileBin.ShowDialog() == DialogResult.OK)
            {
                txtItems_730Bin.Text = ofdFileBin.FileName;

                _inventoryFileLoader = new InventoryFileLoader(ofdFileBin.FileName);

                switch (_inventoryFileLoader.FileLoadResult)
                {
                    case LoadFileReturnValue.ValidAndUseable:
                        lblItems_730Bin.ForeColor = Color.Green;
                        lblItems_730Bin.Text = @"Correct file";

                        break;
                    case LoadFileReturnValue.ReadOnly:
                        lblItems_730Bin.ForeColor = Color.Red;
                        lblItems_730Bin.Text = @"File is readonly!";
                        break;
                    case LoadFileReturnValue.ValidHeaderBrokenInside:
                        lblItems_730Bin.ForeColor = Color.Red;
                        lblItems_730Bin.Text = @"File is unsupported/wrong file!";
                        break;
                    case LoadFileReturnValue.NotValid:
                        lblItems_730Bin.ForeColor = Color.Red;
                        lblItems_730Bin.Text = @"Invalid file!";
                        break;
                    case LoadFileReturnValue.NotExist:
                        lblItems_730Bin.ForeColor = Color.Red;
                        lblItems_730Bin.Text = @"File does not exist!";
                        break;
                    default:
                        break;
                }
            }
        }

        private void btnRescanInv_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItems_games.Text) == false && string.IsNullOrWhiteSpace(txtItems_730Bin.Text) == false)
            {
                if (_kvFileReader == null || _kvFileReader.IsClosed)
                {
                    _kvFileReader = new CsgoItemsGameFileParser(txtItems_games.Text);
                } 

                if (_kvFileReader.IsValid)
                {
                    lblItems_gameTxt.ForeColor = Color.Green;
                    lblItems_gameTxt.Text = @"Correct file";
                }
                else
                {
                    lblItems_gameTxt.ForeColor = Color.Red;
                    lblItems_gameTxt.Text = @"Invalid file";
                }
                
                if (_inventoryFileLoader == null)
                {
                    _inventoryFileLoader = new InventoryFileLoader(txtItems_730Bin.Text);
                }

                switch (_inventoryFileLoader.FileLoadResult)
                {
                    case LoadFileReturnValue.ValidAndUseable:
                        lblItems_730Bin.ForeColor = Color.Green;
                        lblItems_730Bin.Text = @"Correct file";
                        btnReloadInv.Enabled = false;
                        btnSave.Enabled = true;

                        if (_inventoryFileLoader.Manager.IsClosed)
                        {
                            _inventoryFileLoader = new InventoryFileLoader(txtItems_730Bin.Text);
                        }
                        break;
                    case LoadFileReturnValue.ReadOnly:
                        lblItems_730Bin.ForeColor = Color.Red;
                        lblItems_730Bin.Text = @"File is readonly!";
                        btnReloadInv.Enabled = true;
                        btnSave.Enabled = false;
                        break;
                    case LoadFileReturnValue.ValidHeaderBrokenInside:
                        lblItems_730Bin.ForeColor = Color.Red;
                        lblItems_730Bin.Text = @"File is unsupported/wrong file!";
                        btnReloadInv.Enabled = true;
                        btnSave.Enabled = false;
                        break;
                    case LoadFileReturnValue.NotValid:
                        lblItems_730Bin.ForeColor = Color.Red;
                        lblItems_730Bin.Text = @"Invalid file!";
                        btnReloadInv.Enabled = true;
                        btnSave.Enabled = false;
                        break;
                    case LoadFileReturnValue.NotExist:
                        lblItems_730Bin.ForeColor = Color.Red;
                        lblItems_730Bin.Text = @"File does not exist!";
                        btnReloadInv.Enabled = true;
                        btnSave.Enabled = false;
                        break;
                    default:
                        break;
                }
            }

            clbInventories.Items.Clear();

            if (_kvFileReader.IsValid && _inventoryFileLoader.FileLoadResult == LoadFileReturnValue.ValidAndUseable)
            {
                _invRetriever = new InventoryRetriever(_kvFileReader, _inventoryFileLoader);

                foreach (var item in _invRetriever.GetAllInventories())
                {
                    clbInventories.Items.Add(item);
                }
                clbInventories.SelectedIndex = 0;

                foreach (var item in _kvFileReader.GetItemSets())
                {
                    clbItemSets.Items.Add(item);
                }

                foreach (var item in _kvFileReader.GetOfficialItems())
                {
                    lvItem = new ListViewItem();
                    lvItem.Text = item.Item1.CodedName;
                    lvItem.SubItems.Add(item.Item2.Name);
                    lvItem.SubItems.Add(item.Item2.Rarity);
                    lvItem.Checked = false;
                    lvRecognizedOfficialItems.Items.Add(lvItem);
                }
            }
        }

        private void clbInventories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentSelectedItemIdx != -1)
            {
                this.SaveCheckBoxListItemState();
            }

            currentSelectedItemIdx = clbInventories.SelectedIndex;

            this.ClearTableLayoutPanel(tlpInventoryDesc);
            this.ClearTableLayoutPanel(tlpInventoryAttr);

            // get selected item first
            CompleteItemInfo selected = clbInventories.SelectedItem as CompleteItemInfo;

            if (selected != null)
            {
                Label itemTypeLabel = new Label();
                itemTypeLabel.Text = "Item Type";
                itemTypeLabel.Name = "lblItemType";
                itemTypeLabel.AutoSize = true;

                ComboBox cmbSelectedItemType = new ComboBox();
                cmbSelectedItemType.Name = "cmbSelectedItemType";

                foreach (var item in _invRetriever.InventorySolver.CsgoItemList)
                {
                    cmbSelectedItemType.Items.Add(item);
                }

                cmbSelectedItemType.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbSelectedItemType.SelectedIndex = cmbSelectedItemType.Items.IndexOf(selected.Item);
                cmbSelectedItemType.Dock = DockStyle.Left;
                cmbSelectedItemType.Width = this.DropDownWidth(cmbSelectedItemType);

                this.AddNewRow(itemTypeLabel, cmbSelectedItemType, tlpInventoryDesc);

                Label qualityLabel = new Label();
                qualityLabel.Text = "Quality";
                qualityLabel.Name = "lblQuality";
                qualityLabel.AutoSize = true;

                ComboBox cmbSelectedItemQuality = new ComboBox();
                cmbSelectedItemQuality.Name = "cmbSelectedItemQuality";

                foreach (var item in _invRetriever.InventorySolver.CsgoQualityList)
                {
                    cmbSelectedItemQuality.Items.Add(item);
                }

                cmbSelectedItemQuality.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbSelectedItemQuality.SelectedIndex = cmbSelectedItemQuality.Items.IndexOf(selected.Quality);
                cmbSelectedItemQuality.Dock = DockStyle.Left;
                cmbSelectedItemQuality.Width = this.DropDownWidth(cmbSelectedItemQuality);

                this.AddNewRow(qualityLabel, cmbSelectedItemQuality, tlpInventoryDesc);

                Label rarityLabel = new Label();
                rarityLabel.Text = "Rarity";
                rarityLabel.Name = "lblRarity";
                rarityLabel.AutoSize = true;

                ComboBox cmbSelectedItemRarity = new ComboBox();
                cmbSelectedItemRarity.Name = "cmbSelectedItemRarity";

                foreach (var item in _invRetriever.InventorySolver.CsgoRarityList)
                {
                    cmbSelectedItemRarity.Items.Add(item);
                }

                cmbSelectedItemRarity.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbSelectedItemRarity.SelectedIndex = cmbSelectedItemRarity.Items.IndexOf(selected.Rarity);
                cmbSelectedItemRarity.Dock = DockStyle.Left;
                cmbSelectedItemRarity.Width = this.DropDownWidth(cmbSelectedItemRarity);

                this.AddNewRow(rarityLabel, cmbSelectedItemRarity, tlpInventoryDesc);

                int stickerCount = 0;

                foreach (var attr in selected.CompleteAttributes)
                {
                    Button btnRemoveAnAttribute = new Button();
                    btnRemoveAnAttribute.Text = "-";
                    btnRemoveAnAttribute.Name = "btnRemoveAnAttribute" + tlpInventoryAttr.RowCount;
                    btnRemoveAnAttribute.AutoSize = true;
                    btnRemoveAnAttribute.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                    btnRemoveAnAttribute.Click += btnRemoveAnAttribute_Click;

                    ComboBox cmbReadItemAttr = new ComboBox();

                    foreach (var item in _invRetriever.InventorySolver.CsgoSortedAttributeList)
                    {
                        cmbReadItemAttr.Items.Add(item.Value);
                    }

                    cmbReadItemAttr.Name = "cmbReadItemAttr" + tlpInventoryAttr.RowCount;
                    cmbReadItemAttr.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmbReadItemAttr.SelectedIndex = cmbReadItemAttr.Items.IndexOf(attr.Key);
                    cmbReadItemAttr.Dock = DockStyle.Left;
                    cmbReadItemAttr.Width = this.DropDownWidth(cmbReadItemAttr);

                    ComboBox cmbSelectedItemAttr = new ComboBox();
                    cmbSelectedItemAttr.Name = "cmbSelectedItemAttr" + tlpInventoryAttr.RowCount;

                    TextBox tbAttrValue = new TextBox();
                    tbAttrValue.Name = "tbAttrValue" + tlpInventoryAttr.RowCount;

                    // paint
                    if (attr.Key.CodedValue == 6)
                    {
                        foreach (var item in _invRetriever.InventorySolver.CsgoPaintList)
                        {
                            cmbSelectedItemAttr.Items.Add(item);
                        }

                        cmbSelectedItemAttr.DropDownStyle = ComboBoxStyle.DropDownList;
                        cmbSelectedItemAttr.SelectedIndex = cmbSelectedItemAttr.Items.IndexOf(selected.PaintAttributeLookup);
                        if (cmbSelectedItemAttr.SelectedIndex == -1)
                        {
                            cmbSelectedItemAttr.SelectedIndex = 0;
                        }
                        cmbSelectedItemAttr.Dock = DockStyle.Left;
                        cmbSelectedItemAttr.Width = this.DropDownWidth(cmbSelectedItemAttr);

                        this.AddNewRow(btnRemoveAnAttribute, cmbReadItemAttr, cmbSelectedItemAttr, tlpInventoryAttr);
                    } // wear
                    else if (attr.Key.CodedValue == 8)
                    {
                        if (string.IsNullOrEmpty(selected.PaintAttributeLookup.Name) == false)
                        {
                            TrackBar wearTrack = new TrackBar();
                            wearTrack.Minimum = Convert.ToInt32(selected.PaintAttributeLookup.WearMinLevel) * 100;
                            wearTrack.Maximum = Convert.ToInt32(selected.PaintAttributeLookup.WearMaxLevel) * 100;
                            wearTrack.Name = "trkWearPaint" + tlpInventoryAttr.RowCount;

                            float wearLevel = BitConverter.ToSingle(selected.CompleteAttributes[_invRetriever.InventorySolver.GetAttribute(8)].value_bytes, 0);
                            wearTrack.Value = Convert.ToInt32(wearLevel * 100f);
                            wearTrack.TickFrequency = 10;
                            wearTrack.SmallChange = 1;
                            wearTrack.Dock = DockStyle.Left;

                            this.AddNewRow(btnRemoveAnAttribute, cmbReadItemAttr, wearTrack, tlpInventoryAttr);
                        }
                    }
                    else if (attr.Key.CodedName.Contains("sticker slot "))
                    {
                        foreach (var item in _invRetriever.InventorySolver.CsgoStickerList)
                        {
                            cmbSelectedItemAttr.Items.Add(item);
                        }

                        if (selected.StickerAttributeLookup.Count > 1)
                        {
                            cmbSelectedItemAttr.DropDownStyle = ComboBoxStyle.DropDownList;
                            cmbSelectedItemAttr.SelectedIndex = cmbSelectedItemAttr.Items.IndexOf(selected.StickerAttributeLookup[stickerCount]);
                            cmbSelectedItemAttr.Dock = DockStyle.Left;
                            cmbSelectedItemAttr.Width = this.DropDownWidth(cmbSelectedItemAttr);
                            stickerCount++;
                        }
                        else if (selected.StickerAttributeLookup.Count == 1)
                        {
                            cmbSelectedItemAttr.DropDownStyle = ComboBoxStyle.DropDownList;
                            cmbSelectedItemAttr.SelectedIndex = cmbSelectedItemAttr.Items.IndexOf(selected.StickerAttributeLookup[0]);
                            cmbSelectedItemAttr.Dock = DockStyle.Left;
                            cmbSelectedItemAttr.Width = this.DropDownWidth(cmbSelectedItemAttr);
                        }

                        this.AddNewRow(btnRemoveAnAttribute, cmbReadItemAttr, cmbSelectedItemAttr, tlpInventoryAttr);
                    }
                        // name tag
                    else if (attr.Key.CodedValue == 111)
                    {
                        Label lblNameTag = new Label();
                        lblNameTag.Text = "Custom Name";
                        lblNameTag.Name = "lblNameTag";
                        lblNameTag.AutoSize = true;

                        TextBox tbAttrNameTag = new TextBox();
                        tbAttrNameTag.Name = "tbAttrNameTag";
                        tbAttrNameTag.AutoSize = true;
                        tbAttrNameTag.Text = string.Format("{0}", selected.CustomName);

                        this.AddNewRow(lblNameTag, tbAttrNameTag, tlpInventoryDesc);

                        tbAttrValue.Text = string.Format("{0}", attr.Value.value);
                        this.AddNewRow(btnRemoveAnAttribute, cmbReadItemAttr, tbAttrValue, tlpInventoryAttr);
                    }
                    else if (attr.Key.CodedValue == 166)
                    {
                        foreach (var item in _invRetriever.InventorySolver.CsgoMusicList)
                        {
                            cmbSelectedItemAttr.Items.Add(item);
                        }

                        cmbSelectedItemAttr.DropDownStyle = ComboBoxStyle.DropDownList;
                        cmbSelectedItemAttr.SelectedIndex = cmbSelectedItemAttr.Items.IndexOf(selected.MusicAttributeLookup);
                        cmbSelectedItemAttr.Dock = DockStyle.Left;
                        cmbSelectedItemAttr.Width = this.DropDownWidth(cmbSelectedItemAttr);

                        this.AddNewRow(btnRemoveAnAttribute, cmbReadItemAttr, cmbSelectedItemAttr, tlpInventoryAttr);
                    }
                    else 
                    {
                        if (attr.Key.IsInteger)
                        {
                            tbAttrValue.Text = string.Format("{0}", BitConverter.ToInt32(attr.Value.value_bytes, 0));
                        }
                        else if (attr.Key.IsString)
                        {
                            tbAttrValue.Text = string.Format("{0}", attr.Value.value);
                        }
                        else
                        {
                            tbAttrValue.Text = string.Format("{0}", BitConverter.ToSingle(attr.Value.value_bytes, 0));
                        }
                        tbAttrValue.AutoSize = true;

                        this.AddNewRow(btnRemoveAnAttribute, cmbReadItemAttr, tbAttrValue, tlpInventoryAttr);
                    }
                }

                AddNewAttributeButton();
            }
        }

        private void SaveCheckBoxListItemState()
        {
            savedSelected = new CompleteItemInfo();

            Dictionary<AttributeInfo, CSOEconItemAttribute> attibuteInfoWithCso = new Dictionary<AttributeInfo, CSOEconItemAttribute>();
            AttributeInfo attrInfo = new AttributeInfo();
            CSOEconItemAttribute csoAttr = new CSOEconItemAttribute();

            int stickerCount = 0;
            foreach (var item in tlpInventoryAttr.Controls)
            {
                if (item is ComboBox)
                {
                    if (((ComboBox)item).Name.Contains("cmbReadItemAttr"))
                    {
                        attrInfo = (AttributeInfo)((ComboBox)item).SelectedItem;
                        csoAttr = new CSOEconItemAttribute();
                    }

                    if (((ComboBox)item).Name.Contains("cmbSelectedItemAttr"))
                    {
                        csoAttr.def_index = (uint)attrInfo.CodedValue;
                        // paint kits
                        if (attrInfo.CodedValue == 6)
                        {
                            if (((ComboBox)item).SelectedItem != null)
                            {
                                savedSelected.PaintAttributeLookup = (PaintInfo)((ComboBox)item).SelectedItem;
                                csoAttr.value_bytes = BitConverter.GetBytes(Convert.ToSingle(savedSelected.PaintAttributeLookup.CodedValue));
                            }
                        } 
                        // sticker
                        else if (attrInfo.CodedName.Contains("sticker slot "))
                        {
                            if (((ComboBox)item).SelectedItem != null)
                            {
                                savedSelected.StickerAttributeLookup.Add((StickerInfo)((ComboBox)item).SelectedItem);
                                csoAttr.value_bytes = BitConverter.GetBytes(savedSelected.StickerAttributeLookup[stickerCount].CodedValue);
                                stickerCount++;
                            }
                        }
                        // music
                        else if (attrInfo.CodedValue == 166)
                        {
                            if (((ComboBox)item).SelectedItem != null)
                            {
                                savedSelected.MusicAttributeLookup = (MusicInfo)((ComboBox)item).SelectedItem;
                                csoAttr.value_bytes = BitConverter.GetBytes(savedSelected.MusicAttributeLookup.CodedValue);
                            }
                        }
                    }
                }// wear
                else if (item is TrackBar)
                {
                    if (string.IsNullOrEmpty(savedSelected.PaintAttributeLookup.Name) == false)
                    {
                        csoAttr.def_index = Convert.ToUInt32(attrInfo.CodedValue);

                        float wearLevel = Convert.ToSingle((((TrackBar)item).Value / 100f));
                        csoAttr.value_bytes = BitConverter.GetBytes(wearLevel);
                    }
                }
                else if (item is TextBox)
                {
                    if (((TextBox)item).Name.Contains("tbAttrValue"))
                    {
                        csoAttr.def_index = Convert.ToUInt32(attrInfo.CodedValue);

                        if (attrInfo.IsInteger)
                        {
                            csoAttr.value_bytes = BitConverter.GetBytes(int.Parse(((TextBox)item).Text));
                        }
                        else if (attrInfo.IsString)
                        {
                            csoAttr.value = Convert.ToUInt32(int.Parse(((TextBox)item).Text));
                        }
                        else
                        {
                            csoAttr.value_bytes = BitConverter.GetBytes(float.Parse(((TextBox)item).Text));
                        }
                    }
                }
                else
                {
                    continue;
                }

                if (attrInfo.CodedValue > 0 && csoAttr.def_index > 0)
                {
                    savedSelected.CompleteAttributes.Add(attrInfo, csoAttr);
                }
            }

            foreach (var item in tlpInventoryDesc.Controls)
            {
                if (item is ComboBox)
                {
                    if (((ComboBox)item).Name.Contains("cmbSelectedItemType"))
                    {
                        savedSelected.Item = (ItemInfo)((ComboBox)item).SelectedItem;
                    }
                    else if (((ComboBox)item).Name.Contains("cmbSelectedItemQuality"))
                    {
                        savedSelected.Quality = (QualityInfo)((ComboBox)item).SelectedItem;
                    }
                    else if (((ComboBox)item).Name.Contains("cmbSelectedItemRarity"))
                    {
                        savedSelected.Rarity = (RarityInfo)((ComboBox)item).SelectedItem;
                    }
                }
                else if (item is TextBox)
                {
                    foreach (var attr in savedSelected.CompleteAttributes)
                    {
                        // it has name tag
                        if (attr.Key.CodedValue == 111)
                        {
                            if (((TextBox)item).Name.Contains("tbAttrNameTag"))
                            {
                                savedSelected.CustomName = ((TextBox)item).Text;
                            }
                        }
                    }
                }

                savedSelected.IsChanged = true;
            }

            if (clbInventories.SelectedIndex != currentSelectedItemIdx)
            {
                if (currentSelectedItemIdx != -1)
                {
                    oldSelectedItemIdx = currentSelectedItemIdx;
                    currentSelectedItemIdx = clbInventories.SelectedIndex;
                }

                if (savedSelected != null)
                {
                    if (savedSelected.Item.CodedValue > 0)
                    {
                        if (oldSelectedItemIdx < clbInventories.Items.Count)
                        {
                            clbInventories.SelectedIndexChanged -= clbInventories_SelectedIndexChanged;
                            clbInventories.Items[oldSelectedItemIdx] = savedSelected;
                            clbInventories.SelectedIndexChanged += clbInventories_SelectedIndexChanged;
                        }
                    }
                }
            }
            else
            {
                if (savedSelected != null)
                {
                    if (savedSelected.Item.CodedValue > 0)
                    {
                        clbInventories.SelectedIndexChanged -= clbInventories_SelectedIndexChanged;
                        clbInventories.Items[currentSelectedItemIdx] = savedSelected;
                        clbInventories.SelectedIndexChanged += clbInventories_SelectedIndexChanged;
                    }
                }
            }
        }

        private void btnRemoveAnAttribute_Click(object sender, EventArgs e)
        {
            RemoveAddNewAttributeButton();

            int btnRemoveAnAttributeIdx = tlpInventoryAttr.Controls.IndexOfKey("btnRemoveAnAttribute" + (tlpInventoryAttr.RowCount - 1));
            if (btnRemoveAnAttributeIdx != -1)
            {
                tlpInventoryAttr.Controls.RemoveAt(btnRemoveAnAttributeIdx);
            }

            int cmbReadItemAttrIdx = tlpInventoryAttr.Controls.IndexOfKey("cmbReadItemAttr" + (tlpInventoryAttr.RowCount - 1));
            if (cmbReadItemAttrIdx != -1)
            {
                tlpInventoryAttr.Controls.RemoveAt(cmbReadItemAttrIdx);
            }

            int cmbSelectedItemAttrIdx = tlpInventoryAttr.Controls.IndexOfKey("cmbSelectedItemAttr" + (tlpInventoryAttr.RowCount - 1));
            if (cmbSelectedItemAttrIdx != -1)
            {
                tlpInventoryAttr.Controls.RemoveAt(cmbSelectedItemAttrIdx);
            }

            int tbAttrValueIdx = tlpInventoryAttr.Controls.IndexOfKey("tbAttrValue" + (tlpInventoryAttr.RowCount - 1));
            if (tbAttrValueIdx != -1)
            {
                tlpInventoryAttr.Controls.RemoveAt(tbAttrValueIdx);
            }

            int wearTrackIdx = tlpInventoryAttr.Controls.IndexOfKey("trkWearPaint" + (tlpInventoryAttr.RowCount - 1));
            if (wearTrackIdx != -1)
            {
                tlpInventoryAttr.Controls.RemoveAt(wearTrackIdx);
            }

            tlpInventoryAttr.RowCount -= 1;

            AddNewAttributeButton();
        }

        private void btnAddAnAttribute_Click(object sender, EventArgs e)
        {
            RemoveAddNewAttributeButton();

            Button btnRemoveAnAttribute = new Button();
            btnRemoveAnAttribute.Text = "-";
            btnRemoveAnAttribute.Name = "btnRemoveAnAttribute" + tlpInventoryAttr.RowCount;
            btnRemoveAnAttribute.AutoSize = true;
            btnRemoveAnAttribute.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRemoveAnAttribute.Click += btnRemoveAnAttribute_Click;

            ComboBox cmbReadItemAttr = new ComboBox();

            foreach (var item in _invRetriever.InventorySolver.CsgoAttributeList)
            {
                cmbReadItemAttr.Items.Add(item);
            }

            cmbReadItemAttr.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReadItemAttr.Name = "cmbReadItemAttr" + tlpInventoryAttr.RowCount;
            cmbReadItemAttr.Dock = DockStyle.Left;
            cmbReadItemAttr.SelectedItem = _invRetriever.InventorySolver.GetAttribute(6);
            cmbReadItemAttr.Width = this.DropDownWidth(cmbReadItemAttr);
            cmbReadItemAttr.SelectedIndexChanged += cmbReadItemAttr_SelectedIndexChanged;

            ComboBox cmbSelectedItemAttr = new ComboBox();
            cmbSelectedItemAttr.Name = "cmbSelectedItemAttr" + tlpInventoryAttr.RowCount;

            TextBox tbAttrValue = new TextBox();
            tbAttrValue.Text = string.Empty;
            tbAttrValue.Name = "tbAttrValue" + tlpInventoryAttr.RowCount;
            tbAttrValue.AutoSize = true;

            // if it's a sticker
            if (cmbReadItemAttr.SelectedItem.Equals(_invRetriever.InventorySolver.GetAttribute(6)))
            {
                foreach (var item in _invRetriever.InventorySolver.CsgoPaintList)
                {
                    cmbSelectedItemAttr.Items.Add(item);
                }

                cmbSelectedItemAttr.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbSelectedItemAttr.Dock = DockStyle.Left;
                cmbSelectedItemAttr.Width = this.DropDownWidth(cmbSelectedItemAttr);

                this.AddNewRow(btnRemoveAnAttribute, cmbReadItemAttr, cmbSelectedItemAttr, tlpInventoryAttr);
            }

            AddNewAttributeButton();
        }

        private void cmbReadItemAttr_SelectedIndexChanged(object sender, EventArgs e)
        {
            // remove the cmbSelectedItemAttr or tbAttrValue based on SelectedItem
            int cmbSelectedItemAttrIdx = tlpInventoryAttr.Controls.IndexOfKey("cmbSelectedItemAttr" + (tlpInventoryAttr.RowCount - 2));

            if (cmbSelectedItemAttrIdx != -1)
            {
                tlpInventoryAttr.Controls.RemoveAt(cmbSelectedItemAttrIdx);
            }

            int tbAttrValueIdx = tlpInventoryAttr.Controls.IndexOfKey("tbAttrValue" + (tlpInventoryAttr.RowCount - 2));
            if (tbAttrValueIdx != -1)
            {
                tlpInventoryAttr.Controls.RemoveAt(tbAttrValueIdx);
            }

            ComboBox cmbSelectedItemAttr = new ComboBox();
            cmbSelectedItemAttr.Name = "cmbSelectedItemAttr" + (tlpInventoryAttr.RowCount - 2);

            TextBox tbAttrValue = new TextBox();
            tbAttrValue.Text = string.Empty;
            tbAttrValue.Name = "tbAttrValue" + (tlpInventoryAttr.RowCount - 2);
            tbAttrValue.AutoSize = true;

            if (((ComboBox) sender).SelectedItem.Equals(_invRetriever.InventorySolver.GetAttribute(6)))
            {
                foreach (var item in _invRetriever.InventorySolver.CsgoPaintList)
                {
                    cmbSelectedItemAttr.Items.Add(item);
                }

                cmbSelectedItemAttr.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbSelectedItemAttr.Dock = DockStyle.Left;
                cmbSelectedItemAttr.Width = this.DropDownWidth(cmbSelectedItemAttr);

                tlpInventoryAttr.Controls.Add(cmbSelectedItemAttr, 2, tlpInventoryAttr.RowCount - 1);
            } // wear
            else if (((ComboBox) sender).SelectedItem.Equals(_invRetriever.InventorySolver.GetAttribute(8)))
            {
                int cmbInt = tlpInventoryAttr.Controls.IndexOfKey("cmbSelectedItemAttr" + 0);

                if (cmbInt != -1)
                {
                    ComboBox cmbSelectPaint = tlpInventoryAttr.Controls[cmbInt] as ComboBox;

                    if (string.IsNullOrEmpty(((PaintInfo)cmbSelectPaint.SelectedItem).Name) == false)
                    {
                        TrackBar wearTrack = new TrackBar();

                        wearTrack.Name = "trkWeakTrack" + (tlpInventoryAttr.RowCount - 2);
                        wearTrack.Minimum = Convert.ToInt32(((PaintInfo)cmbSelectPaint.SelectedItem).WearMinLevel) * 100;
                        wearTrack.Maximum = Convert.ToInt32(((PaintInfo)cmbSelectPaint.SelectedItem).WearMaxLevel) * 100;

                        wearTrack.TickFrequency = 10;
                        wearTrack.SmallChange = 1;
                        wearTrack.LargeChange = 10;
                        wearTrack.Dock = DockStyle.Left;

                        tlpInventoryAttr.Controls.Add(wearTrack, 2, tlpInventoryAttr.RowCount - 1);
                    }
                }
            } 
            else if (((ComboBox)sender).SelectedItem.Equals(_invRetriever.InventorySolver.GetAttribute(113)))
            {
                foreach (var item in _invRetriever.InventorySolver.CsgoStickerList)
                {
                    cmbSelectedItemAttr.Items.Add(item);
                }

                cmbSelectedItemAttr.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbSelectedItemAttr.Dock = DockStyle.Left;
                cmbSelectedItemAttr.Width = this.DropDownWidth(cmbSelectedItemAttr);

                tlpInventoryAttr.Controls.Add(cmbSelectedItemAttr, 2, tlpInventoryAttr.RowCount - 1);
            }
            else if (((ComboBox)sender).SelectedItem.Equals(_invRetriever.InventorySolver.GetAttribute(166)))
            {
                foreach (var item in _invRetriever.InventorySolver.CsgoMusicList)
                {
                    cmbSelectedItemAttr.Items.Add(item);
                }

                cmbSelectedItemAttr.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbSelectedItemAttr.Dock = DockStyle.Left;
                cmbSelectedItemAttr.Width = this.DropDownWidth(cmbSelectedItemAttr);

                tlpInventoryAttr.Controls.Add(cmbSelectedItemAttr, 2, tlpInventoryAttr.RowCount - 1);
            }
            else
            {
                tlpInventoryAttr.Controls.Add(tbAttrValue, 2, tlpInventoryAttr.RowCount - 1);
            }
        }

        private void RemoveAddNewAttributeButton()
        {
            tlpInventoryAttr.Controls.RemoveByKey("btnAddAnAttribute");
            tlpInventoryAttr.Controls.RemoveByKey("empty2ndControl");
            tlpInventoryAttr.Controls.RemoveByKey("empty3rdControl");
            tlpInventoryAttr.RowCount = tlpInventoryAttr.RowCount - 1;
        }

        private void AddNewAttributeButton()
        {
            Button btnAddAnAttribute = new Button();
            btnAddAnAttribute.Text = "+";
            btnAddAnAttribute.Name = "btnAddAnAttribute";
            btnAddAnAttribute.AutoSize = true;
            btnAddAnAttribute.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAddAnAttribute.Click += btnAddAnAttribute_Click;

            this.AddNewRow(btnAddAnAttribute, new Control { Name = "empty2ndControl" }, new Control { Name = "empty3rdControl" }, tlpInventoryAttr);
        }

        private int DropDownWidth(ComboBox myCombo)
        {
            int maxWidth = 0, temp = 0;
            foreach (var obj in myCombo.Items)
            {
                temp = TextRenderer.MeasureText(obj.ToString(), myCombo.Font).Width;
                if (temp > maxWidth)
                {
                    maxWidth = temp;
                }
            } 
            return maxWidth + 20;
        }

        /// <summary>
        ///     Add Control to TableLayoutPanel
        /// </summary>
        /// <param name="column">column position</param>
        /// <param name="row">row position</param>
        private void AddNewRow(Control control1stColumn, Control control2ndColumn, TableLayoutPanel panel)
        {
            panel.RowCount = panel.RowCount + 1;
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            panel.Controls.Add(control1stColumn, 0, panel.RowCount);
            panel.Controls.Add(control2ndColumn, 1, panel.RowCount);
        }

        /// <summary>
        ///     Add Control to TableLayoutPanel
        /// </summary>
        /// <param name="column">column position</param>
        /// <param name="row">row position</param>
        private void AddNewRow(Control control1stColumn, Control control2ndColumn, Control control3rdColumn, TableLayoutPanel panel)
        {
            panel.RowCount = panel.RowCount + 1;
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            panel.Controls.Add(control1stColumn, 0, panel.RowCount);
            panel.Controls.Add(control2ndColumn, 1, panel.RowCount);
            panel.Controls.Add(control3rdColumn, 2, panel.RowCount);
        }

        private void ClearTableLayoutPanel(TableLayoutPanel panel)
        {
            panel.RowCount = 0;
            panel.Controls.Clear();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            CompleteItemInfo newItem = new CompleteItemInfo();
            newItem.Item = _invRetriever.InventorySolver.CsgoItemList[1];
            newItem.Quality = _invRetriever.InventorySolver.CsgoQualityList[1];
            newItem.Rarity = _invRetriever.InventorySolver.CsgoRarityList[1];

            clbInventories.Items.Add(newItem);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            List<CompleteItemInfo> toBeRemovedItems = new List<CompleteItemInfo>();
            foreach (var item in clbInventories.CheckedItems)
            {
                toBeRemovedItems.Add(item as CompleteItemInfo);
            }

            foreach (var toBeRemove in toBeRemovedItems)
            {
                clbInventories.Items.Remove(toBeRemove);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<CompleteItemInfo> itemsToBeWritten = new List<CompleteItemInfo>();

            foreach (CompleteItemInfo item in clbInventories.Items)
            {
                itemsToBeWritten.Add(item);
            }

            CompleteItemInfo itemSets;

            foreach (ItemSetsInfo item in clbItemSets.CheckedItems)
            {
                foreach (var itemSet in item.ItemSet)
                {
                    itemSets = new CompleteItemInfo();

                    itemSets.Item = itemSet.Item2;
                    itemSets.PaintAttributeLookup = itemSet.Item1;

                    itemSets.CompleteAttributes.Add(_invRetriever.InventorySolver.GetAttribute(6), new CSOEconItemAttribute()
                    {
                        def_index = 6,
                        value_bytes = BitConverter.GetBytes((float)itemSet.Item1.CodedValue)
                    });

                    itemSets.Rarity = _invRetriever.InventorySolver.GetRarity(itemSet.Item1.Rarity);

                    if (chkStatTrakSets.Checked)
                    {
                        itemSets.CompleteAttributes.Add(_invRetriever.InventorySolver.GetAttribute(80), new CSOEconItemAttribute() 
                        {
                            def_index = 80,
                            value_bytes = new byte[4] { 0x00, 0x00, 0x00, 0x00 }
                        });
                        itemSets.Quality = _invRetriever.InventorySolver.GetQuality("strange");
                    }
                    else
                    {
                        itemSets.Quality = _invRetriever.InventorySolver.GetQuality("tournament");
                    }

                    itemsToBeWritten.Add(itemSets);
                }
            }

            foreach (ListViewItem item in lvRecognizedOfficialItems.Items)
            {
                if (item.Checked)
                {
                    itemSets = new CompleteItemInfo();

                    itemSets.Item = _invRetriever.InventorySolver.GetItem(item.Text);
                    itemSets.PaintAttributeLookup = _invRetriever.InventorySolver.GetPaint(item.SubItems[1].Text);

                    itemSets.CompleteAttributes.Add(_invRetriever.InventorySolver.GetAttribute(6), new CSOEconItemAttribute()
                    {
                        def_index = 6,
                        value_bytes = BitConverter.GetBytes(Convert.ToSingle(itemSets.PaintAttributeLookup.CodedValue))
                    });

                    itemSets.Rarity = _invRetriever.InventorySolver.GetRarity(itemSets.PaintAttributeLookup.Rarity);

                    if (chkStatTrakOfficial.Checked)
                    {
                        if (itemSets.Item.CodedName.Contains("knife") == false && itemSets.Item.CodedName.Contains("bayonet") == false)
                        {
                            itemSets.CompleteAttributes.Add(_invRetriever.InventorySolver.GetAttribute(80), new CSOEconItemAttribute()
                            {
                                def_index = 80,
                                value_bytes = new byte[4] { 0x00, 0x00, 0x00, 0x00 }
                            });
                            itemSets.Quality = _invRetriever.InventorySolver.GetQuality("strange");
                        }
                        else
                        {
                            itemSets.CompleteAttributes.Add(_invRetriever.InventorySolver.GetAttribute(80), new CSOEconItemAttribute()
                            {
                                def_index = 80,
                                value_bytes = new byte[4] { 0x00, 0x00, 0x00, 0x00 }
                            });
                            itemSets.Quality = _invRetriever.InventorySolver.GetQuality("unusual");
                        }
                    }
                    else
                    {
                        itemSets.Quality = _invRetriever.InventorySolver.GetQuality("tournament");
                    }

                    itemsToBeWritten.Add(itemSets);
                }
            }

            _inventoryFileLoader.Manager.WriteItems(itemsToBeWritten);

            btnSave.Enabled = false;
            btnReloadInv.Enabled = true;
        }

        private ListViewItem _lvitem;

        private void clbItemSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvwItemSetDetails.Items.Clear();

            foreach (var item in ((ItemSetsInfo)clbItemSets.SelectedItem).ItemSet)
            {
                _lvitem = new ListViewItem();
                _lvitem.Text = item.Item2.CodedName;
                _lvitem.Checked = true;
                _lvitem.SubItems.Add(item.Item1.Name);
                _lvitem.SubItems.Add(item.Item1.Rarity);
                lvwItemSetDetails.Items.Add(_lvitem);
            }
        }

        private void chkCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCheckAll.Checked)
            {
                if (lvRecognizedOfficialItems.Items.Count > 0)
                {
                    foreach (ListViewItem item in lvRecognizedOfficialItems.Items)
                    {
                        item.Checked = true;
                    }
                }
            }
            else
            {

                if (lvRecognizedOfficialItems.Items.Count > 0)
                {
                    foreach (ListViewItem item in lvRecognizedOfficialItems.Items)
                    {
                        item.Checked = false;
                    }
                }
            }
        }
    }
}
