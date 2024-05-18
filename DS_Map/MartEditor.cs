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
        uint MainMartOffset;
        byte[] MainMart;
        private bool IsUpdating = false;
        private bool dirty;
        private static readonly string formName = "Mart Editor";

        public MartEditor(string[] itemnames) {
            InitializeComponent();

            GetMartOffset();

            ItemCB.Items.AddRange(itemnames);
            ItemCB.SelectedIndex = 0;

            string[] Levels = { "No Badges", "1 Badge", "3 Badges", "5 Badges", "7 Badges", "8 Badges"};
            LevelCB.Items.AddRange(Levels);
            LevelCB.SelectedIndex = 0;

            LoadMainMart();
        }

        void GetMartOffset() {
            switch (RomInfo.gameFamily) {
                case RomInfo.GameFamilies.DP:
                case RomInfo.GameFamilies.Plat:
                    break;
                case RomInfo.GameFamilies.HGSS:
                    if(RomInfo.gameLanguage == RomInfo.GameLanguages.English) MainMartOffset = 0xFBF22;
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
            MainMart = DSUtils.ARM9.ReadBytes(MainMartOffset, 76);
            for (int i = 0; i < MainMart.Length; i += 4) {
                int Item = BitConverter.ToUInt16(MainMart, i);
                int Level = BitConverter.ToUInt16(MainMart, i + 2);

                MainMartLB.Items.Add(ItemCB.Items[Item] + ", " + LevelCB.Items[Level - 1]);
            }
        }

        private void MainMartLB_SelectedIndexChanged(object sender, EventArgs e) {
            if (MainMartLB.SelectedIndex == -1 || IsUpdating) return;

            IsUpdating = true;

            int baseIndex = MainMartLB.SelectedIndex * 4;


            int itemIndex = BitConverter.ToUInt16(MainMart, baseIndex);
            int levelIndex = BitConverter.ToUInt16(MainMart, baseIndex + 2) - 1;

            ItemCB.SelectedIndex = itemIndex;
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

                MainMartLB.Items[MainMartLB.SelectedIndex] = ItemCB.Items[ItemCB.SelectedIndex] + ", " + LevelCB.Items[LevelCB.SelectedIndex];

                byte[] itemByteArray = BitConverter.GetBytes((ushort)ItemCB.SelectedIndex);
                Array.Copy(itemByteArray, 0, MainMart, MainMartLB.SelectedIndex * 4, itemByteArray.Length);

                byte[] levelByteArray = BitConverter.GetBytes((ushort)(LevelCB.SelectedIndex + 1));
                Array.Copy(levelByteArray, 0, MainMart, MainMartLB.SelectedIndex * 4 + 2, levelByteArray.Length);

                IsUpdating = false;
                setDirty(true);
            }
        }


        private void MainMartSaveBTN_Click(object sender, EventArgs e) {
            DSUtils.ARM9.WriteBytes(MainMart, MainMartOffset);
            MessageBox.Show("Mart Saved Succesfully", "Saved...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            setDirty(false);
        }

        private void MartEditor_FormClosing(object sender, FormClosingEventArgs e) {
            if(dirty) {
                DialogResult res = MessageBox.Show("Mart Editor\nThere are unsaved changes to the current Evolution data.\nDiscard and proceed?", "Mart Editor - Unsaved changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(res == DialogResult.No) {
                    e.Cancel = true;
                }
            }
        }
    }
}
