using DSPRE.ROMFiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties.System;

namespace DSPRE {
    public partial class MartEditor : Form {
        uint MartsOffset;
        uint MainMartDifference;
        byte[] MainMart;

        private bool IsUpdating = false;
        private bool dirty;
        private static readonly string formName = "Mart Editor";

        public MartEditor(string[] itemnames) {
            InitializeComponent();

            GetMartOffset();

            AltMartItemCB.Items.AddRange(itemnames);
            AltMartItemCB.SelectedIndex = 0;
            MainItemCB.Items.AddRange(itemnames);
            MainItemCB.SelectedIndex = 1;

            string[] Levels = { "No Badges", "1 Badge", "3 Badges", "5 Badges", "7 Badges", "8 Badges"};
            LevelCB.Items.AddRange(Levels);
            LevelCB.SelectedIndex = 0;

            LoadMainMart();
            ((Control)OtherMartsTAB).Enabled = false;
            //LoadAltMarts();
        }

        void GetMartOffset() {
            switch (RomInfo.gameFamily) {
                case RomInfo.GameFamilies.DP:
                    break;
                case RomInfo.GameFamilies.Plat:
                    MainMartDifference = 0x184;
                    if (RomInfo.gameLanguage == RomInfo.GameLanguages.English) MartsOffset = 0xEB978;
                    if (RomInfo.gameLanguage == RomInfo.GameLanguages.French) MartsOffset = 0xEBA00;
                    if (RomInfo.gameLanguage == RomInfo.GameLanguages.German) MartsOffset = 0xEB9D0;
                    if (RomInfo.gameLanguage == RomInfo.GameLanguages.Italian) MartsOffset = 0xEB994;
                    if (RomInfo.gameLanguage == RomInfo.GameLanguages.Japanese) MartsOffset = 0xEB008;
                    if (RomInfo.gameLanguage == RomInfo.GameLanguages.Spanish) MartsOffset = 0xEBA0C;
                    break;
                case RomInfo.GameFamilies.HGSS:
                    MainMartDifference = 0x4CE;
                    if (RomInfo.gameLanguage == RomInfo.GameLanguages.English) MartsOffset = 0xFBA54;
                    if (RomInfo.gameLanguage == RomInfo.GameLanguages.French) MartsOffset = 0xFBA38;
                    if (RomInfo.gameLanguage == RomInfo.GameLanguages.German) MartsOffset = 0xFB9E8;
                    if (RomInfo.gameLanguage == RomInfo.GameLanguages.Italian) MartsOffset = 0xFB9AC;
                    if (RomInfo.gameLanguage == RomInfo.GameLanguages.Japanese) MartsOffset = 0xFB1D4; 
                    if (RomInfo.gameLanguage == RomInfo.GameLanguages.Spanish) MartsOffset = 0xFBA3C;
                    break;
            }
        }

        private void setDirty(bool status) {
            if (status) {
                dirty = true;
                this.Text = formName + "*";
            }
            else {
                dirty = false;
                this.Text = formName;
            }
        }

        void LoadMainMart() {
            MainMart = ARM9.ReadBytes(MartsOffset + MainMartDifference, 76);
            for (int i = 0; i < MainMart.Length; i += 4) {
                int Item = BitConverter.ToUInt16(MainMart, i);
                int Level = BitConverter.ToUInt16(MainMart, i + 2);

                MainMartLB.Items.Add(MainItemCB.Items[Item] + ", " + LevelCB.Items[Level - 1]);
            }
        }

        private void MainMartLB_SelectedIndexChanged(object sender, EventArgs e) {
            if (MainMartLB.SelectedIndex == -1 || IsUpdating) return;

            IsUpdating = true;

            int baseIndex = MainMartLB.SelectedIndex * 4;


            int itemIndex = BitConverter.ToUInt16(MainMart, baseIndex);
            int levelIndex = BitConverter.ToUInt16(MainMart, baseIndex + 2) - 1;

            MainItemCB.SelectedIndex = itemIndex;
            LevelCB.SelectedIndex = levelIndex;


            IsUpdating = false;
        }


        private void ItemCB_SelectedIndexChanged(object sender, EventArgs e) {
            if (!IsUpdating)
                UpdateItem();
        }

        private void LevelCB_SelectedIndexChanged(object sender, EventArgs e) {
            if(!IsUpdating)
                UpdateItem();
        }

        void UpdateItem() {
            if (MainMartLB.SelectedIndex != -1) {
                IsUpdating = true;

                MainMartLB.Items[MainMartLB.SelectedIndex] = MainItemCB.Items[MainItemCB.SelectedIndex] + ", " + LevelCB.Items[LevelCB.SelectedIndex];

                byte[] itemByteArray = BitConverter.GetBytes((ushort)MainItemCB.SelectedIndex);
                Array.Copy(itemByteArray, 0, MainMart, MainMartLB.SelectedIndex * 4, itemByteArray.Length);

                byte[] levelByteArray = BitConverter.GetBytes((ushort)(LevelCB.SelectedIndex + 1));
                Array.Copy(levelByteArray, 0, MainMart, MainMartLB.SelectedIndex * 4 + 2, levelByteArray.Length);

                IsUpdating = false;
                setDirty(true);
            }
        }


        private void MainMartSaveBTN_Click(object sender, EventArgs e) {
            ARM9.WriteBytes(MainMart, MartsOffset + MainMartDifference);
            MessageBox.Show("Mart Saved Succesfully", "Saved...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            setDirty(false);
        }

        private void MartEditor_FormClosing(object sender, FormClosingEventArgs e) {
            if(dirty) {
                DialogResult res = MessageBox.Show("Mart Editor\nThere are unsaved changes to the current Mart data.\nDiscard and proceed?", "Mart Editor - Unsaved changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(res == DialogResult.No) {
                    e.Cancel = true;
                }
            }
        }

        void LoadAltMarts() {
            List<byte> altMart = new List<byte>();
            using (ARM9.Reader rd = new ARM9.Reader()) {
                rd.BaseStream.Position = MartsOffset;
                byte[] data = new byte[2];
                int index = 0;
                while (true) {
                    data = rd.ReadBytes(2);
                    altMart.AddRange(data);

                    if (data[0] != 0xFF) {
                        MartLB.Items.Add(AltMartItemCB.Items[BitConverter.ToUInt16(altMart.ToArray(), index)]);
                    }
                    else if (RomInfo.gameFamily == RomInfo.GameFamilies.HGSS) {
                        MartLB.Items.Add(string.Empty);
                    }
                    if (rd.BaseStream.Position == MartsOffset + MainMartDifference) break;
                    index += 2;
                }
            }
        }
    }
}
