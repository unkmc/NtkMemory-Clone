

namespace TkMemory.Application
{
    partial class TkMemoryForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TkMemoryForm));
            this.MageActiveCheckBox = new System.Windows.Forms.CheckBox();
            this.PoetActiveCheckBox = new System.Windows.Forms.CheckBox();
            this.RogueActiveCheckBox = new System.Windows.Forms.CheckBox();
            this.WarriorActiveCheckBox = new System.Windows.Forms.CheckBox();
            this.ApplicationNameLabel = new System.Windows.Forms.Label();
            this.ApplicationNameTextBox = new System.Windows.Forms.TextBox();
            this.CommandDelayLabel = new System.Windows.Forms.Label();
            this.MageLabel = new System.Windows.Forms.Label();
            this.PoetLabel = new System.Windows.Forms.Label();
            this.RogueLabel = new System.Windows.Forms.Label();
            this.WarriorLabel = new System.Windows.Forms.Label();
            this.MageHealCheckBox = new System.Windows.Forms.CheckBox();
            this.MageVexCheckBox = new System.Windows.Forms.CheckBox();
            this.MageZapCheckBox = new System.Windows.Forms.CheckBox();
            this.PoetHardenBodyCheckbox = new System.Windows.Forms.CheckBox();
            this.RogueAttackCheckBox = new System.Windows.Forms.CheckBox();
            this.RogueDesperateAttackCheckBox = new System.Windows.Forms.CheckBox();
            this.RogueLethalStrikeCheckBox = new System.Windows.Forms.CheckBox();
            this.WarriorAttackCheckBox = new System.Windows.Forms.CheckBox();
            this.WarriorBerserkCheckBox = new System.Windows.Forms.CheckBox();
            this.WarriorWhirlwindCheckBox = new System.Windows.Forms.CheckBox();
            this.CommandDelayUpDown = new System.Windows.Forms.NumericUpDown();
            this.MageBlindCheckBox = new System.Windows.Forms.CheckBox();
            this.MageParalyzeCheckBox = new System.Windows.Forms.CheckBox();
            this.MageVenomCheckBox = new System.Windows.Forms.CheckBox();
            this.RogueAmbushCheckBox = new System.Windows.Forms.CheckBox();
            this.HorizontalRule = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AutoFollowLabel = new System.Windows.Forms.Label();
            this.AutoFollowActiveCheckBox = new System.Windows.Forms.CheckBox();
            this.AutoFollowLeaderTextBox = new System.Windows.Forms.TextBox();
            this.AutoFollowLeaderLabel = new System.Windows.Forms.Label();
            this.AutoFollowDistanceUpDown = new System.Windows.Forms.NumericUpDown();
            this.AutoFollowDistanceLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MinimizeCheckBox = new System.Windows.Forms.CheckBox();
            this.DeactivateButton = new System.Windows.Forms.Button();
            this.KillSwitch = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.LogFilesButton = new System.Windows.Forms.Button();
            this.MageNameTextBox = new System.Windows.Forms.TextBox();
            this.PoetNameTextBox = new System.Windows.Forms.TextBox();
            this.RogueNameTextBox = new System.Windows.Forms.TextBox();
            this.WarriorNameTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.CommandDelayUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoFollowDistanceUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // MageActiveCheckBox
            // 
            this.MageActiveCheckBox.AutoSize = true;
            this.MageActiveCheckBox.Location = new System.Drawing.Point(182, 87);
            this.MageActiveCheckBox.Name = "MageActiveCheckBox";
            this.MageActiveCheckBox.Size = new System.Drawing.Size(56, 17);
            this.MageActiveCheckBox.TabIndex = 3;
            this.MageActiveCheckBox.Text = "Active";
            this.toolTip1.SetToolTip(this.MageActiveCheckBox, "Check to start the Mage trainer. Uncheck to close the trainer.");
            this.MageActiveCheckBox.UseVisualStyleBackColor = true;
            this.MageActiveCheckBox.CheckedChanged += new System.EventHandler(this.MageActiveCheckBox_CheckedChanged);
            // 
            // PoetActiveCheckBox
            // 
            this.PoetActiveCheckBox.AutoSize = true;
            this.PoetActiveCheckBox.Location = new System.Drawing.Point(182, 133);
            this.PoetActiveCheckBox.Name = "PoetActiveCheckBox";
            this.PoetActiveCheckBox.Size = new System.Drawing.Size(56, 17);
            this.PoetActiveCheckBox.TabIndex = 11;
            this.PoetActiveCheckBox.Text = "Active";
            this.toolTip1.SetToolTip(this.PoetActiveCheckBox, "Check to start the Poet trainer. Uncheck to close the trainer.");
            this.PoetActiveCheckBox.UseVisualStyleBackColor = true;
            this.PoetActiveCheckBox.CheckedChanged += new System.EventHandler(this.PoetActiveCheckBox_CheckedChanged);
            // 
            // RogueActiveCheckBox
            // 
            this.RogueActiveCheckBox.AutoSize = true;
            this.RogueActiveCheckBox.Location = new System.Drawing.Point(182, 179);
            this.RogueActiveCheckBox.Name = "RogueActiveCheckBox";
            this.RogueActiveCheckBox.Size = new System.Drawing.Size(56, 17);
            this.RogueActiveCheckBox.TabIndex = 14;
            this.RogueActiveCheckBox.Text = "Active";
            this.toolTip1.SetToolTip(this.RogueActiveCheckBox, "Check to start the Rogue trainer. Uncheck to close the trainer.");
            this.RogueActiveCheckBox.UseVisualStyleBackColor = true;
            this.RogueActiveCheckBox.CheckedChanged += new System.EventHandler(this.RogueActiveCheckBox_CheckedChanged);
            // 
            // WarriorActiveCheckBox
            // 
            this.WarriorActiveCheckBox.AutoSize = true;
            this.WarriorActiveCheckBox.Location = new System.Drawing.Point(182, 224);
            this.WarriorActiveCheckBox.Name = "WarriorActiveCheckBox";
            this.WarriorActiveCheckBox.Size = new System.Drawing.Size(56, 17);
            this.WarriorActiveCheckBox.TabIndex = 20;
            this.WarriorActiveCheckBox.Text = "Active";
            this.toolTip1.SetToolTip(this.WarriorActiveCheckBox, "Check to start the Warrior trainer. Uncheck to close the trainer.");
            this.WarriorActiveCheckBox.UseVisualStyleBackColor = true;
            this.WarriorActiveCheckBox.CheckedChanged += new System.EventHandler(this.WarriorActiveCheckBox_CheckedChanged);
            // 
            // ApplicationNameLabel
            // 
            this.ApplicationNameLabel.AutoSize = true;
            this.ApplicationNameLabel.Location = new System.Drawing.Point(13, 13);
            this.ApplicationNameLabel.Name = "ApplicationNameLabel";
            this.ApplicationNameLabel.Size = new System.Drawing.Size(93, 13);
            this.ApplicationNameLabel.TabIndex = 26;
            this.ApplicationNameLabel.Text = "Application Name:";
            this.toolTip1.SetToolTip(this.ApplicationNameLabel, "Name of the executable for the TK client application.");
            // 
            // ApplicationNameTextBox
            // 
            this.ApplicationNameTextBox.Location = new System.Drawing.Point(12, 31);
            this.ApplicationNameTextBox.Name = "ApplicationNameTextBox";
            this.ApplicationNameTextBox.Size = new System.Drawing.Size(150, 20);
            this.ApplicationNameTextBox.TabIndex = 0;
            this.ApplicationNameTextBox.Text = "ClassicTK.exe";
            this.toolTip1.SetToolTip(this.ApplicationNameTextBox, "Name of the executable for the TK client application.");
            this.ApplicationNameTextBox.TextChanged += new System.EventHandler(this.ApplicationNameTextBox_TextChanged);
            // 
            // CommandDelayLabel
            // 
            this.CommandDelayLabel.AutoSize = true;
            this.CommandDelayLabel.Location = new System.Drawing.Point(179, 13);
            this.CommandDelayLabel.Name = "CommandDelayLabel";
            this.CommandDelayLabel.Size = new System.Drawing.Size(87, 13);
            this.CommandDelayLabel.TabIndex = 27;
            this.CommandDelayLabel.Text = "Command Delay:";
            this.toolTip1.SetToolTip(this.CommandDelayLabel, "Number of milliseconds to wait in between commands. Only increase this if the TK " +
        "server is consistenly dropping commands.");
            // 
            // MageLabel
            // 
            this.MageLabel.AutoSize = true;
            this.MageLabel.Location = new System.Drawing.Point(13, 69);
            this.MageLabel.Name = "MageLabel";
            this.MageLabel.Size = new System.Drawing.Size(37, 13);
            this.MageLabel.TabIndex = 28;
            this.MageLabel.Text = "Mage:";
            this.toolTip1.SetToolTip(this.MageLabel, "(Optional) The name of the Mage to control with the trainer. If left blank, the f" +
        "irst Mage found will be selected.");
            // 
            // PoetLabel
            // 
            this.PoetLabel.AutoSize = true;
            this.PoetLabel.Location = new System.Drawing.Point(13, 115);
            this.PoetLabel.Name = "PoetLabel";
            this.PoetLabel.Size = new System.Drawing.Size(32, 13);
            this.PoetLabel.TabIndex = 29;
            this.PoetLabel.Text = "Poet:";
            this.toolTip1.SetToolTip(this.PoetLabel, "(Optional) The name of the Poet to control with the trainer. If left blank, the f" +
        "irst Poet found will be selected.");
            // 
            // RogueLabel
            // 
            this.RogueLabel.AutoSize = true;
            this.RogueLabel.Location = new System.Drawing.Point(13, 161);
            this.RogueLabel.Name = "RogueLabel";
            this.RogueLabel.Size = new System.Drawing.Size(42, 13);
            this.RogueLabel.TabIndex = 30;
            this.RogueLabel.Text = "Rogue:";
            this.toolTip1.SetToolTip(this.RogueLabel, "(Optional) The name of the Rogue to control with the trainer. If left blank, the " +
        "first Rogue found will be selected.");
            // 
            // WarriorLabel
            // 
            this.WarriorLabel.AutoSize = true;
            this.WarriorLabel.Location = new System.Drawing.Point(13, 206);
            this.WarriorLabel.Name = "WarriorLabel";
            this.WarriorLabel.Size = new System.Drawing.Size(44, 13);
            this.WarriorLabel.TabIndex = 31;
            this.WarriorLabel.Text = "Warrior:";
            this.toolTip1.SetToolTip(this.WarriorLabel, "(Optional) The name of the Warrior to control with the trainer. If left blank, th" +
        "e first Warrior found will be selected.");
            // 
            // MageHealCheckBox
            // 
            this.MageHealCheckBox.AutoSize = true;
            this.MageHealCheckBox.Location = new System.Drawing.Point(244, 87);
            this.MageHealCheckBox.Name = "MageHealCheckBox";
            this.MageHealCheckBox.Size = new System.Drawing.Size(48, 17);
            this.MageHealCheckBox.TabIndex = 4;
            this.MageHealCheckBox.Text = "Heal";
            this.toolTip1.SetToolTip(this.MageHealCheckBox, "Toggles whether or not the Mage should heal self and group members.");
            this.MageHealCheckBox.UseVisualStyleBackColor = true;
            this.MageHealCheckBox.CheckedChanged += new System.EventHandler(this.MageHealCheckbox_CheckedChanged);
            // 
            // MageVexCheckBox
            // 
            this.MageVexCheckBox.AutoSize = true;
            this.MageVexCheckBox.Location = new System.Drawing.Point(490, 87);
            this.MageVexCheckBox.Name = "MageVexCheckBox";
            this.MageVexCheckBox.Size = new System.Drawing.Size(44, 17);
            this.MageVexCheckBox.TabIndex = 8;
            this.MageVexCheckBox.Text = "Vex";
            this.toolTip1.SetToolTip(this.MageVexCheckBox, "Toggles whether or not the Mage should curse enemies.");
            this.MageVexCheckBox.UseVisualStyleBackColor = true;
            this.MageVexCheckBox.CheckedChanged += new System.EventHandler(this.MageVexCheckbox_CheckedChanged);
            // 
            // MageZapCheckBox
            // 
            this.MageZapCheckBox.AutoSize = true;
            this.MageZapCheckBox.Location = new System.Drawing.Point(540, 87);
            this.MageZapCheckBox.Name = "MageZapCheckBox";
            this.MageZapCheckBox.Size = new System.Drawing.Size(45, 17);
            this.MageZapCheckBox.TabIndex = 9;
            this.MageZapCheckBox.Text = "Zap";
            this.toolTip1.SetToolTip(this.MageZapCheckBox, "Toggles whether or not the Mage should zap enemies. When toggled, the Mage will z" +
        "ap a single enemy until it is defeated and then move on to another one.");
            this.MageZapCheckBox.UseVisualStyleBackColor = true;
            this.MageZapCheckBox.CheckedChanged += new System.EventHandler(this.MageZapCheckbox_CheckedChanged);
            // 
            // PoetHardenBodyCheckbox
            // 
            this.PoetHardenBodyCheckbox.AutoSize = true;
            this.PoetHardenBodyCheckbox.Location = new System.Drawing.Point(244, 133);
            this.PoetHardenBodyCheckbox.Name = "PoetHardenBodyCheckbox";
            this.PoetHardenBodyCheckbox.Size = new System.Drawing.Size(88, 17);
            this.PoetHardenBodyCheckbox.TabIndex = 12;
            this.PoetHardenBodyCheckbox.Text = "Harden Body";
            this.toolTip1.SetToolTip(this.PoetHardenBodyCheckbox, "Toggles whether or not the Poet should cast Harden Body as often as possible.");
            this.PoetHardenBodyCheckbox.UseVisualStyleBackColor = true;
            this.PoetHardenBodyCheckbox.CheckedChanged += new System.EventHandler(this.PoetHardenBodyCheckbox_CheckedChanged);
            // 
            // RogueAttackCheckBox
            // 
            this.RogueAttackCheckBox.AutoSize = true;
            this.RogueAttackCheckBox.Location = new System.Drawing.Point(244, 179);
            this.RogueAttackCheckBox.Name = "RogueAttackCheckBox";
            this.RogueAttackCheckBox.Size = new System.Drawing.Size(57, 17);
            this.RogueAttackCheckBox.TabIndex = 15;
            this.RogueAttackCheckBox.Text = "Attack";
            this.toolTip1.SetToolTip(this.RogueAttackCheckBox, "Toggles whether or not the Rogue should automatically perform melee attacks as of" +
        "ten as possible.");
            this.RogueAttackCheckBox.UseVisualStyleBackColor = true;
            this.RogueAttackCheckBox.CheckedChanged += new System.EventHandler(this.RogueAttackCheckbox_CheckedChanged);
            // 
            // RogueDesperateAttackCheckBox
            // 
            this.RogueDesperateAttackCheckBox.AutoSize = true;
            this.RogueDesperateAttackCheckBox.Location = new System.Drawing.Point(377, 179);
            this.RogueDesperateAttackCheckBox.Name = "RogueDesperateAttackCheckBox";
            this.RogueDesperateAttackCheckBox.Size = new System.Drawing.Size(109, 17);
            this.RogueDesperateAttackCheckBox.TabIndex = 17;
            this.RogueDesperateAttackCheckBox.Text = "Desperate Attack";
            this.toolTip1.SetToolTip(this.RogueDesperateAttackCheckBox, "Toggles whether or not the Rogue should use Desperate Attack as often as possible" +
        ". Vita attacks will only be performed if Attack is checked and the Rogue has at " +
        "least 85% of its max vita.");
            this.RogueDesperateAttackCheckBox.UseVisualStyleBackColor = true;
            this.RogueDesperateAttackCheckBox.CheckedChanged += new System.EventHandler(this.RogueDesperateAttackCheckBox_CheckedChanged);
            // 
            // RogueLethalStrikeCheckBox
            // 
            this.RogueLethalStrikeCheckBox.AutoSize = true;
            this.RogueLethalStrikeCheckBox.Location = new System.Drawing.Point(492, 179);
            this.RogueLethalStrikeCheckBox.Name = "RogueLethalStrikeCheckBox";
            this.RogueLethalStrikeCheckBox.Size = new System.Drawing.Size(85, 17);
            this.RogueLethalStrikeCheckBox.TabIndex = 18;
            this.RogueLethalStrikeCheckBox.Text = "Lethal Strike";
            this.toolTip1.SetToolTip(this.RogueLethalStrikeCheckBox, "Toggles whether or not the Rogue should use Lethal Strike as often as possible. V" +
        "ita attacks will only be performed if Attack is checked and the Rogue has at lea" +
        "st 85% of its max vita.");
            this.RogueLethalStrikeCheckBox.UseVisualStyleBackColor = true;
            this.RogueLethalStrikeCheckBox.CheckedChanged += new System.EventHandler(this.RogueLethalStrikeCheckbox_CheckedChanged);
            // 
            // WarriorAttackCheckBox
            // 
            this.WarriorAttackCheckBox.AutoSize = true;
            this.WarriorAttackCheckBox.Location = new System.Drawing.Point(244, 224);
            this.WarriorAttackCheckBox.Name = "WarriorAttackCheckBox";
            this.WarriorAttackCheckBox.Size = new System.Drawing.Size(57, 17);
            this.WarriorAttackCheckBox.TabIndex = 21;
            this.WarriorAttackCheckBox.Text = "Attack";
            this.toolTip1.SetToolTip(this.WarriorAttackCheckBox, "Toggles whether or not the Warrior should automatically perform melee attacks as " +
        "often as possible.");
            this.WarriorAttackCheckBox.UseVisualStyleBackColor = true;
            this.WarriorAttackCheckBox.CheckedChanged += new System.EventHandler(this.WarriorAttackCheckbox_CheckedChanged);
            // 
            // WarriorBerserkCheckBox
            // 
            this.WarriorBerserkCheckBox.AutoSize = true;
            this.WarriorBerserkCheckBox.Location = new System.Drawing.Point(307, 224);
            this.WarriorBerserkCheckBox.Name = "WarriorBerserkCheckBox";
            this.WarriorBerserkCheckBox.Size = new System.Drawing.Size(62, 17);
            this.WarriorBerserkCheckBox.TabIndex = 22;
            this.WarriorBerserkCheckBox.Text = "Berserk";
            this.toolTip1.SetToolTip(this.WarriorBerserkCheckBox, "Toggles whether or not the Warrior should use Berserk as often as possible. Vita " +
        "attacks will only be performed if Attack is checked and the Warrior has at least" +
        " 85% of its max vita.");
            this.WarriorBerserkCheckBox.UseVisualStyleBackColor = true;
            this.WarriorBerserkCheckBox.CheckedChanged += new System.EventHandler(this.WarriorBerserkCheckbox_CheckedChanged);
            // 
            // WarriorWhirlwindCheckBox
            // 
            this.WarriorWhirlwindCheckBox.AutoSize = true;
            this.WarriorWhirlwindCheckBox.Location = new System.Drawing.Point(375, 224);
            this.WarriorWhirlwindCheckBox.Name = "WarriorWhirlwindCheckBox";
            this.WarriorWhirlwindCheckBox.Size = new System.Drawing.Size(72, 17);
            this.WarriorWhirlwindCheckBox.TabIndex = 23;
            this.WarriorWhirlwindCheckBox.Text = "Whirlwind";
            this.toolTip1.SetToolTip(this.WarriorWhirlwindCheckBox, "Toggles whether or not the Warrior should use Whirlwind as often as possible. Vit" +
        "a attacks will only be performed if Attack is checked and the Warrior has at lea" +
        "st 85% of its max vita.");
            this.WarriorWhirlwindCheckBox.UseVisualStyleBackColor = true;
            this.WarriorWhirlwindCheckBox.CheckedChanged += new System.EventHandler(this.WarriorWhirlwindCheckbox_CheckedChanged);
            // 
            // CommandDelayUpDown
            // 
            this.CommandDelayUpDown.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.CommandDelayUpDown.Location = new System.Drawing.Point(182, 31);
            this.CommandDelayUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.CommandDelayUpDown.Minimum = new decimal(new int[] {
            333,
            0,
            0,
            0});
            this.CommandDelayUpDown.Name = "CommandDelayUpDown";
            this.CommandDelayUpDown.Size = new System.Drawing.Size(99, 20);
            this.CommandDelayUpDown.TabIndex = 1;
            this.CommandDelayUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.CommandDelayUpDown, "Number of milliseconds to wait in between commands. Only increase this if the TK " +
        "server is consistenly dropping commands.");
            this.CommandDelayUpDown.Value = new decimal(new int[] {
            333,
            0,
            0,
            0});
            this.CommandDelayUpDown.ValueChanged += new System.EventHandler(this.CommandDelayUpDown_ValueChanged);
            // 
            // MageBlindCheckBox
            // 
            this.MageBlindCheckBox.AutoSize = true;
            this.MageBlindCheckBox.Location = new System.Drawing.Point(298, 87);
            this.MageBlindCheckBox.Name = "MageBlindCheckBox";
            this.MageBlindCheckBox.Size = new System.Drawing.Size(49, 17);
            this.MageBlindCheckBox.TabIndex = 5;
            this.MageBlindCheckBox.Text = "Blind";
            this.toolTip1.SetToolTip(this.MageBlindCheckBox, "Toggles whether or not the Mage should blind enemies.");
            this.MageBlindCheckBox.UseVisualStyleBackColor = true;
            this.MageBlindCheckBox.CheckedChanged += new System.EventHandler(this.MageBlindCheckBox_CheckedChanged);
            // 
            // MageParalyzeCheckBox
            // 
            this.MageParalyzeCheckBox.AutoSize = true;
            this.MageParalyzeCheckBox.Location = new System.Drawing.Point(353, 87);
            this.MageParalyzeCheckBox.Name = "MageParalyzeCheckBox";
            this.MageParalyzeCheckBox.Size = new System.Drawing.Size(66, 17);
            this.MageParalyzeCheckBox.TabIndex = 6;
            this.MageParalyzeCheckBox.Text = "Paralyze";
            this.toolTip1.SetToolTip(this.MageParalyzeCheckBox, "Toggles whether or not the Mage should paralyze enemies.");
            this.MageParalyzeCheckBox.UseVisualStyleBackColor = true;
            this.MageParalyzeCheckBox.CheckedChanged += new System.EventHandler(this.MageParalyzeCheckBox_CheckedChanged);
            // 
            // MageVenomCheckBox
            // 
            this.MageVenomCheckBox.AutoSize = true;
            this.MageVenomCheckBox.Location = new System.Drawing.Point(425, 87);
            this.MageVenomCheckBox.Name = "MageVenomCheckBox";
            this.MageVenomCheckBox.Size = new System.Drawing.Size(59, 17);
            this.MageVenomCheckBox.TabIndex = 7;
            this.MageVenomCheckBox.Text = "Venom";
            this.toolTip1.SetToolTip(this.MageVenomCheckBox, "Toggles whether or not the Mage should poison enemies. When toggled, enemies will" +
        " be poisoned every 30 seconds.");
            this.MageVenomCheckBox.UseVisualStyleBackColor = true;
            this.MageVenomCheckBox.CheckedChanged += new System.EventHandler(this.MageVenomCheckBox_CheckedChanged);
            // 
            // RogueAmbushCheckBox
            // 
            this.RogueAmbushCheckBox.AutoSize = true;
            this.RogueAmbushCheckBox.Location = new System.Drawing.Point(307, 179);
            this.RogueAmbushCheckBox.Name = "RogueAmbushCheckBox";
            this.RogueAmbushCheckBox.Size = new System.Drawing.Size(64, 17);
            this.RogueAmbushCheckBox.TabIndex = 16;
            this.RogueAmbushCheckBox.Text = "Ambush";
            this.toolTip1.SetToolTip(this.RogueAmbushCheckBox, "Check to use Ambush for melee attacks. Uncheck to use normal attacks. Normal atta" +
        "cks may be preferable for paralyzed enemies. Invisible will be used either way.");
            this.RogueAmbushCheckBox.UseVisualStyleBackColor = true;
            this.RogueAmbushCheckBox.CheckedChanged += new System.EventHandler(this.RogueAmbushCheckBox_CheckedChanged);
            // 
            // HorizontalRule
            // 
            this.HorizontalRule.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.HorizontalRule.Location = new System.Drawing.Point(-227, 59);
            this.HorizontalRule.Name = "HorizontalRule";
            this.HorizontalRule.Size = new System.Drawing.Size(862, 2);
            this.HorizontalRule.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(-214, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(862, 2);
            this.label1.TabIndex = 22;
            // 
            // AutoFollowLabel
            // 
            this.AutoFollowLabel.AutoSize = true;
            this.AutoFollowLabel.Location = new System.Drawing.Point(14, 263);
            this.AutoFollowLabel.Name = "AutoFollowLabel";
            this.AutoFollowLabel.Size = new System.Drawing.Size(65, 13);
            this.AutoFollowLabel.TabIndex = 32;
            this.AutoFollowLabel.Text = "Auto-Follow:";
            this.toolTip1.SetToolTip(this.AutoFollowLabel, "Check to start the AutoFollow trainer. Uncheck to close the trainer.");
            // 
            // AutoFollowActiveCheckBox
            // 
            this.AutoFollowActiveCheckBox.AutoSize = true;
            this.AutoFollowActiveCheckBox.Location = new System.Drawing.Point(16, 282);
            this.AutoFollowActiveCheckBox.Name = "AutoFollowActiveCheckBox";
            this.AutoFollowActiveCheckBox.Size = new System.Drawing.Size(56, 17);
            this.AutoFollowActiveCheckBox.TabIndex = 24;
            this.AutoFollowActiveCheckBox.Text = "Active";
            this.toolTip1.SetToolTip(this.AutoFollowActiveCheckBox, "Check to start the AutoFollow trainer. Uncheck to close the trainer.");
            this.AutoFollowActiveCheckBox.UseVisualStyleBackColor = true;
            this.AutoFollowActiveCheckBox.CheckedChanged += new System.EventHandler(this.AutoFollowActiveCheckBox_CheckedChanged);
            // 
            // AutoFollowLeaderTextBox
            // 
            this.AutoFollowLeaderTextBox.Location = new System.Drawing.Point(92, 281);
            this.AutoFollowLeaderTextBox.Name = "AutoFollowLeaderTextBox";
            this.AutoFollowLeaderTextBox.Size = new System.Drawing.Size(150, 20);
            this.AutoFollowLeaderTextBox.TabIndex = 25;
            this.toolTip1.SetToolTip(this.AutoFollowLeaderTextBox, "The name of the character to follow. Only multiboxed characters are eligiible to " +
        "be leaders or followers.");
            this.AutoFollowLeaderTextBox.TextChanged += new System.EventHandler(this.LeaderTextBox_TextChanged);
            // 
            // AutoFollowLeaderLabel
            // 
            this.AutoFollowLeaderLabel.AutoSize = true;
            this.AutoFollowLeaderLabel.Location = new System.Drawing.Point(93, 263);
            this.AutoFollowLeaderLabel.Name = "AutoFollowLeaderLabel";
            this.AutoFollowLeaderLabel.Size = new System.Drawing.Size(43, 13);
            this.AutoFollowLeaderLabel.TabIndex = 33;
            this.AutoFollowLeaderLabel.Text = "Leader:";
            // 
            // AutoFollowDistanceUpDown
            // 
            this.AutoFollowDistanceUpDown.Location = new System.Drawing.Point(259, 281);
            this.AutoFollowDistanceUpDown.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.AutoFollowDistanceUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AutoFollowDistanceUpDown.Name = "AutoFollowDistanceUpDown";
            this.AutoFollowDistanceUpDown.Size = new System.Drawing.Size(99, 20);
            this.AutoFollowDistanceUpDown.TabIndex = 26;
            this.AutoFollowDistanceUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.AutoFollowDistanceUpDown, "The maximum distance in either direction that a follower can be from its leader b" +
        "efore it moves to follow.");
            this.AutoFollowDistanceUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.AutoFollowDistanceUpDown.ValueChanged += new System.EventHandler(this.AutoFollowDistanceUpDown_ValueChanged);
            // 
            // AutoFollowDistanceLabel
            // 
            this.AutoFollowDistanceLabel.AutoSize = true;
            this.AutoFollowDistanceLabel.Location = new System.Drawing.Point(256, 263);
            this.AutoFollowDistanceLabel.Name = "AutoFollowDistanceLabel";
            this.AutoFollowDistanceLabel.Size = new System.Drawing.Size(52, 13);
            this.AutoFollowDistanceLabel.TabIndex = 34;
            this.AutoFollowDistanceLabel.Text = "Distance:";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(-214, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(862, 2);
            this.label2.TabIndex = 29;
            // 
            // MinimizeCheckBox
            // 
            this.MinimizeCheckBox.AutoSize = true;
            this.MinimizeCheckBox.Location = new System.Drawing.Point(16, 329);
            this.MinimizeCheckBox.Name = "MinimizeCheckBox";
            this.MinimizeCheckBox.Size = new System.Drawing.Size(142, 17);
            this.MinimizeCheckBox.TabIndex = 27;
            this.MinimizeCheckBox.Text = "Minimize Console Output";
            this.toolTip1.SetToolTip(this.MinimizeCheckBox, "Check to start the console output window minimized. Uncheck to start the console " +
        "output window normally.");
            this.MinimizeCheckBox.UseVisualStyleBackColor = true;
            this.MinimizeCheckBox.CheckedChanged += new System.EventHandler(this.MinimizeCheckBox_CheckedChanged);
            // 
            // DeactivateButton
            // 
            this.DeactivateButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTabList;
            this.DeactivateButton.Location = new System.Drawing.Point(394, 325);
            this.DeactivateButton.Name = "DeactivateButton";
            this.DeactivateButton.Size = new System.Drawing.Size(93, 23);
            this.DeactivateButton.TabIndex = 29;
            this.DeactivateButton.Text = "Deactivate All";
            this.toolTip1.SetToolTip(this.DeactivateButton, "Closes any active trainers and unchecks the corresponding Active check boxes.");
            this.DeactivateButton.UseVisualStyleBackColor = true;
            this.DeactivateButton.Click += new System.EventHandler(this.DeactivateButton_Click);
            // 
            // KillSwitch
            // 
            this.KillSwitch.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTabList;
            this.KillSwitch.Location = new System.Drawing.Point(493, 325);
            this.KillSwitch.Name = "KillSwitch";
            this.KillSwitch.Size = new System.Drawing.Size(93, 23);
            this.KillSwitch.TabIndex = 30;
            this.KillSwitch.Text = "Kill Switch";
            this.toolTip1.SetToolTip(this.KillSwitch, "Closes all active trainers, all open TK clients, and this application.");
            this.KillSwitch.UseVisualStyleBackColor = true;
            this.KillSwitch.Click += new System.EventHandler(this.KillSwitch_Click);
            // 
            // LogFilesButton
            // 
            this.LogFilesButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTabList;
            this.LogFilesButton.Location = new System.Drawing.Point(295, 325);
            this.LogFilesButton.Name = "LogFilesButton";
            this.LogFilesButton.Size = new System.Drawing.Size(93, 23);
            this.LogFilesButton.TabIndex = 28;
            this.LogFilesButton.Text = "Log Files";
            this.toolTip1.SetToolTip(this.LogFilesButton, "Opens the Local AppData folder where log files are automatically saved.");
            this.LogFilesButton.UseVisualStyleBackColor = true;
            this.LogFilesButton.Click += new System.EventHandler(this.LogFilesButton_Click);
            // 
            // MageNameTextBox
            // 
            this.MageNameTextBox.Location = new System.Drawing.Point(12, 85);
            this.MageNameTextBox.Name = "MageNameTextBox";
            this.MageNameTextBox.Size = new System.Drawing.Size(150, 20);
            this.MageNameTextBox.TabIndex = 2;
            this.toolTip1.SetToolTip(this.MageNameTextBox, "(Optional) The name of the Mage to control with the trainer. If left blank, the f" +
        "irst Mage found will be selected.");
            this.MageNameTextBox.TextChanged += new System.EventHandler(this.MageTextBox_TextChanged);
            // 
            // PoetNameTextBox
            // 
            this.PoetNameTextBox.Location = new System.Drawing.Point(12, 131);
            this.PoetNameTextBox.Name = "PoetNameTextBox";
            this.PoetNameTextBox.Size = new System.Drawing.Size(150, 20);
            this.PoetNameTextBox.TabIndex = 10;
            this.toolTip1.SetToolTip(this.PoetNameTextBox, "(Optional) The name of the Poet to control with the trainer. If left blank, the f" +
        "irst Poet found will be selected.");
            this.PoetNameTextBox.TextChanged += new System.EventHandler(this.PoetTextBox_TextChanged);
            // 
            // RogueNameTextBox
            // 
            this.RogueNameTextBox.Location = new System.Drawing.Point(12, 177);
            this.RogueNameTextBox.Name = "RogueNameTextBox";
            this.RogueNameTextBox.Size = new System.Drawing.Size(150, 20);
            this.RogueNameTextBox.TabIndex = 13;
            this.toolTip1.SetToolTip(this.RogueNameTextBox, "(Optional) The name of the Rogue to control with the trainer. If left blank, the " +
        "first Rogue found will be selected.");
            this.RogueNameTextBox.TextChanged += new System.EventHandler(this.RogueTextBox_TextChanged);
            // 
            // WarriorNameTextBox
            // 
            this.WarriorNameTextBox.Location = new System.Drawing.Point(12, 222);
            this.WarriorNameTextBox.Name = "WarriorNameTextBox";
            this.WarriorNameTextBox.Size = new System.Drawing.Size(150, 20);
            this.WarriorNameTextBox.TabIndex = 19;
            this.toolTip1.SetToolTip(this.WarriorNameTextBox, "(Optional) The name of the Warrior to control with the trainer. If left blank, th" +
        "e first Warrior found will be selected.");
            this.WarriorNameTextBox.TextChanged += new System.EventHandler(this.WarriorTextBox_TextChanged);
            // 
            // TkMemoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 361);
            this.Controls.Add(this.WarriorNameTextBox);
            this.Controls.Add(this.RogueNameTextBox);
            this.Controls.Add(this.PoetNameTextBox);
            this.Controls.Add(this.MageNameTextBox);
            this.Controls.Add(this.LogFilesButton);
            this.Controls.Add(this.PoetHardenBodyCheckbox);
            this.Controls.Add(this.KillSwitch);
            this.Controls.Add(this.DeactivateButton);
            this.Controls.Add(this.MinimizeCheckBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AutoFollowDistanceUpDown);
            this.Controls.Add(this.AutoFollowDistanceLabel);
            this.Controls.Add(this.AutoFollowLeaderTextBox);
            this.Controls.Add(this.AutoFollowLeaderLabel);
            this.Controls.Add(this.AutoFollowLabel);
            this.Controls.Add(this.AutoFollowActiveCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HorizontalRule);
            this.Controls.Add(this.RogueAmbushCheckBox);
            this.Controls.Add(this.MageVenomCheckBox);
            this.Controls.Add(this.MageParalyzeCheckBox);
            this.Controls.Add(this.MageBlindCheckBox);
            this.Controls.Add(this.CommandDelayUpDown);
            this.Controls.Add(this.WarriorWhirlwindCheckBox);
            this.Controls.Add(this.WarriorBerserkCheckBox);
            this.Controls.Add(this.WarriorAttackCheckBox);
            this.Controls.Add(this.RogueLethalStrikeCheckBox);
            this.Controls.Add(this.RogueDesperateAttackCheckBox);
            this.Controls.Add(this.RogueAttackCheckBox);
            this.Controls.Add(this.MageZapCheckBox);
            this.Controls.Add(this.MageVexCheckBox);
            this.Controls.Add(this.MageHealCheckBox);
            this.Controls.Add(this.WarriorLabel);
            this.Controls.Add(this.RogueLabel);
            this.Controls.Add(this.PoetLabel);
            this.Controls.Add(this.MageLabel);
            this.Controls.Add(this.CommandDelayLabel);
            this.Controls.Add(this.ApplicationNameTextBox);
            this.Controls.Add(this.ApplicationNameLabel);
            this.Controls.Add(this.WarriorActiveCheckBox);
            this.Controls.Add(this.RogueActiveCheckBox);
            this.Controls.Add(this.PoetActiveCheckBox);
            this.Controls.Add(this.MageActiveCheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TkMemoryForm";
            this.Text = "TkMemory";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CommandDelayUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoFollowDistanceUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox MageActiveCheckBox;
        private System.Windows.Forms.CheckBox PoetActiveCheckBox;
        private System.Windows.Forms.CheckBox RogueActiveCheckBox;
        private System.Windows.Forms.CheckBox WarriorActiveCheckBox;
        private System.Windows.Forms.Label ApplicationNameLabel;
        private System.Windows.Forms.TextBox ApplicationNameTextBox;
        private System.Windows.Forms.Label CommandDelayLabel;
        private System.Windows.Forms.Label MageLabel;
        private System.Windows.Forms.Label PoetLabel;
        private System.Windows.Forms.Label RogueLabel;
        private System.Windows.Forms.Label WarriorLabel;
        private System.Windows.Forms.CheckBox MageHealCheckBox;
        private System.Windows.Forms.CheckBox MageVexCheckBox;
        private System.Windows.Forms.CheckBox MageZapCheckBox;
        private System.Windows.Forms.CheckBox RogueAttackCheckBox;
        private System.Windows.Forms.CheckBox RogueDesperateAttackCheckBox;
        private System.Windows.Forms.CheckBox RogueLethalStrikeCheckBox;
        private System.Windows.Forms.CheckBox WarriorAttackCheckBox;
        private System.Windows.Forms.CheckBox WarriorBerserkCheckBox;
        private System.Windows.Forms.CheckBox WarriorWhirlwindCheckBox;
        private System.Windows.Forms.NumericUpDown CommandDelayUpDown;
        private System.Windows.Forms.CheckBox MageBlindCheckBox;
        private System.Windows.Forms.CheckBox MageParalyzeCheckBox;
        private System.Windows.Forms.CheckBox MageVenomCheckBox;
        private System.Windows.Forms.CheckBox RogueAmbushCheckBox;
        private System.Windows.Forms.Label HorizontalRule;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label AutoFollowLabel;
        private System.Windows.Forms.CheckBox AutoFollowActiveCheckBox;
        private System.Windows.Forms.TextBox AutoFollowLeaderTextBox;
        private System.Windows.Forms.Label AutoFollowLeaderLabel;
        private System.Windows.Forms.NumericUpDown AutoFollowDistanceUpDown;
        private System.Windows.Forms.Label AutoFollowDistanceLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox MinimizeCheckBox;
        private System.Windows.Forms.Button DeactivateButton;
        private System.Windows.Forms.Button KillSwitch;
        private System.Windows.Forms.CheckBox PoetHardenBodyCheckbox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button LogFilesButton;
        private System.Windows.Forms.TextBox MageNameTextBox;
        private System.Windows.Forms.TextBox PoetNameTextBox;
        private System.Windows.Forms.TextBox RogueNameTextBox;
        private System.Windows.Forms.TextBox WarriorNameTextBox;
    }
}

