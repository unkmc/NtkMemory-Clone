using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TkMemory.Application.Common;
using TkMemory.Application.Infrastructure;

namespace TkMemory.Application
{
    public partial class TkMemoryForm : Form
    {
        #region Fields

        private const int PollingInterval = 1000;

        private readonly CheckBox[] _activeCheckBoxes;
        private readonly CheckBox[] _mageFeatureCheckBoxes;
        private readonly CheckBox[] _poetFeatureCheckBoxes;
        private readonly CheckBox[] _rogueFeatureCheckBoxes;
        private readonly CheckBox[] _warriorFeatureCheckBoxes;
        private readonly List<CheckBox> _featureCheckBoxes;

        #endregion Fields

        #region Form

        public TkMemoryForm()
        {
            InitializeComponent();

            ApplicationNameTextBox.Text = Properties.Settings.Default.ApplicationName;
            CommandDelayUpDown.Value = Properties.Settings.Default.CommandDelay;
            MageBlindCheckBox.Checked = Properties.Settings.Default.MageBlind;
            MageHealCheckBox.Checked = Properties.Settings.Default.MageHeal;
            MageParalyzeCheckBox.Checked = Properties.Settings.Default.MageParalyze;
            MageVenomCheckBox.Checked = Properties.Settings.Default.MageVenom;
            MageVexCheckBox.Checked = Properties.Settings.Default.MageVex;
            MageZapCheckBox.Checked = Properties.Settings.Default.MageZap;
            PoetHardenBodyCheckbox.Checked = Properties.Settings.Default.PoetHardenBody;
            RogueAttackCheckBox.Checked = Properties.Settings.Default.RogueAttack;
            RogueAmbushCheckBox.Checked = Properties.Settings.Default.RogueAmbush;
            RogueDesperateAttackCheckBox.Checked = Properties.Settings.Default.RogueDesperateAttack;
            RogueLethalStrikeCheckBox.Checked = Properties.Settings.Default.RogueLethalStrike;
            WarriorAttackCheckBox.Checked = Properties.Settings.Default.WarriorAttack;
            WarriorBerserkCheckBox.Checked = Properties.Settings.Default.WarriorBerserk;
            WarriorWhirlwindCheckBox.Checked = Properties.Settings.Default.WarriorWhirlwind;
            AutoFollowLeaderTextBox.Text = Properties.Settings.Default.AutoFollowLeader;
            AutoFollowDistanceUpDown.Value = Properties.Settings.Default.AutoFollowDistance;
            MinimizeCheckBox.Checked = Properties.Settings.Default.MinimizeConsoleOutput;

            _activeCheckBoxes = new[] { MageActiveCheckBox, PoetActiveCheckBox, RogueActiveCheckBox, WarriorActiveCheckBox, AutoFollowActiveCheckBox };
            _mageFeatureCheckBoxes = new[] { MageHealCheckBox, MageBlindCheckBox, MageParalyzeCheckBox, MageVenomCheckBox, MageVexCheckBox, MageZapCheckBox };
            _poetFeatureCheckBoxes = new[] { PoetHardenBodyCheckbox };
            _rogueFeatureCheckBoxes = new[] { RogueAttackCheckBox, RogueAmbushCheckBox, RogueDesperateAttackCheckBox, RogueLethalStrikeCheckBox };
            _warriorFeatureCheckBoxes = new[] { WarriorAttackCheckBox, WarriorBerserkCheckBox, WarriorWhirlwindCheckBox };

            _featureCheckBoxes = new List<CheckBox>();
            _featureCheckBoxes.AddRange(_mageFeatureCheckBoxes);
            _featureCheckBoxes.AddRange(_poetFeatureCheckBoxes);
            _featureCheckBoxes.AddRange(_rogueFeatureCheckBoxes);
            _featureCheckBoxes.AddRange(_warriorFeatureCheckBoxes);
        }

        [SuppressMessage("ReSharper", "FunctionNeverReturns")]
        private void Form1_Load(object sender, EventArgs e)
        {
            using (var cancellationTokenSource = new CancellationTokenSource())
            {
                var token = cancellationTokenSource.Token;

                Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        var ahkErrorWindow = Process.GetProcesses()
                            .FirstOrDefault(p => p.MainWindowTitle == "AutoHotkey.dll");

                        ahkErrorWindow?.Close();

                        if (MageActiveCheckBox.Checked)
                        {
                            StartEmbeddedExe(Constants.Mage,
                                new[]
                                {
                                    $"-h {MageHealCheckBox.Checked}",
                                    $"-b {MageBlindCheckBox.Checked}",
                                    $"-f {MageParalyzeCheckBox.Checked}",
                                    $"-v {MageVenomCheckBox.Checked}",
                                    $"-c {MageVexCheckBox.Checked}",
                                    $"-z {MageZapCheckBox.Checked}"
                                });
                        }

                        if (PoetActiveCheckBox.Checked)
                        {
                            StartEmbeddedExe(Constants.Poet,
                                new[]
                                {
                                    $"-h {PoetHardenBodyCheckbox.Checked}"
                                });
                        }

                        if (RogueActiveCheckBox.Checked)
                        {
                            StartEmbeddedExe(Constants.Rogue,
                                new[]
                                {
                                    $"-m {RogueAttackCheckBox.Checked}",
                                    $"-a {RogueAmbushCheckBox.Checked}",
                                    $"-d {RogueDesperateAttackCheckBox.Checked}",
                                    $"-l {RogueLethalStrikeCheckBox.Checked}"
                                });
                        }

                        if (WarriorActiveCheckBox.Checked)
                        {
                            StartEmbeddedExe(Constants.Warrior,
                                new[]
                                {
                                    $"-m {WarriorAttackCheckBox.Checked}",
                                    $"-b {WarriorBerserkCheckBox.Checked}",
                                    $"-w {WarriorWhirlwindCheckBox.Checked}"
                                });
                        }

                        if (AutoFollowActiveCheckBox.Checked)
                        {
                            ProcessHelpers.StartEmbeddedExe(Constants.AutoFollow,
                                new[]
                                {
                                    $@"-p ""{ApplicationNameTextBox.Text}""",
                                    $@"-l ""{AutoFollowLeaderTextBox.Text}""",
                                    $"-d {AutoFollowDistanceUpDown.Value}"
                                },
                                MinimizeCheckBox.Checked);
                        }

                        Thread.Sleep(PollingInterval);
                    }
                }, token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
            }
        }

        private void StartEmbeddedExe(string exeName, IEnumerable<string> commandLineArguments)
        {
            var args = new List<string>
            {
                $@"-p ""{ApplicationNameTextBox.Text}""",
                $"-i {CommandDelayUpDown.Value}"
            };

            args.AddRange(commandLineArguments);

            ProcessHelpers.StartEmbeddedExe(exeName,
                args.ToArray(),
                MinimizeCheckBox.Checked);
        }

        #endregion Form

        #region Application Configuration

        private void ApplicationNameTextBox_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ApplicationName = ApplicationNameTextBox.Text;
            Properties.Settings.Default.Save();
        }

        private void CommandDelayUpDown_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CommandDelay = (int)CommandDelayUpDown.Value;
            Properties.Settings.Default.Save();
        }

        #endregion Application Configuration

        #region Active CheckBoxes

        private void MageActiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var checkBox in _mageFeatureCheckBoxes)
            {
                checkBox.Enabled = !MageActiveCheckBox.Checked;
            }

            if (MageActiveCheckBox.Checked)
            {
                return;
            }

            foreach (var process in Process.GetProcessesByName(Constants.Mage))
            {
                process.Kill();
            }
        }

        private void PoetActiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var checkBox in _poetFeatureCheckBoxes)
            {
                checkBox.Enabled = !PoetActiveCheckBox.Checked;
            }

            if (PoetActiveCheckBox.Checked)
            {
                return;
            }

            foreach (var process in Process.GetProcessesByName(Constants.Poet))
            {
                process.Kill();
            }
        }

        private void RogueActiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var checkBox in _rogueFeatureCheckBoxes)
            {
                checkBox.Enabled = !RogueActiveCheckBox.Checked;
            }

            if (RogueActiveCheckBox.Checked)
            {
                return;
            }

            foreach (var process in Process.GetProcessesByName(Constants.Rogue))
            {
                process.Kill();
            }
        }

        private void WarriorActiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var checkBox in _warriorFeatureCheckBoxes)
            {
                checkBox.Enabled = !WarriorActiveCheckBox.Checked;
            }

            if (WarriorActiveCheckBox.Checked)
            {
                return;
            }

            foreach (var process in Process.GetProcessesByName(Constants.Warrior))
            {
                process.Kill();
            }
        }

        private void AutoFollowActiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var isActive = AutoFollowActiveCheckBox.Checked;

            AutoFollowLeaderTextBox.Enabled = !isActive;
            AutoFollowDistanceUpDown.Enabled = !isActive;

            if (AutoFollowActiveCheckBox.Checked)
            {
                return;
            }

            foreach (var process in Process.GetProcessesByName(Constants.AutoFollow))
            {
                process.Kill();
            }
        }

        #endregion Active CheckBoxes

        #region Mage

        private void MageBlindCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.MageBlind = MageBlindCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void MageHealCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.MageHeal = MageHealCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void MageParalyzeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.MageParalyze = MageParalyzeCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void MageVenomCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.MageVenom = MageVenomCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void MageVexCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.MageVex = MageVexCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void MageZapCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.MageZap = MageZapCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        #endregion Mage

        #region Poet

        private void PoetHardenBodyCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.PoetHardenBody = PoetHardenBodyCheckbox.Checked;
            Properties.Settings.Default.Save();
        }

        #endregion Poet

        #region Rogue

        private void RogueAttackCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.RogueAttack = RogueAttackCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void RogueAmbushCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.RogueAmbush = RogueAmbushCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void RogueDesperateAttackCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.RogueDesperateAttack = RogueDesperateAttackCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void RogueLethalStrikeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.RogueLethalStrike = RogueLethalStrikeCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        #endregion Rogue

        #region Warrior

        private void WarriorAttackCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.WarriorAttack = WarriorAttackCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void WarriorBerserkCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.WarriorBerserk = WarriorBerserkCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void WarriorWhirlwindCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.WarriorWhirlwind = WarriorWhirlwindCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        #endregion Warrior

        #region AutoFollow

        private void LeaderTextBox_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoFollowLeader = AutoFollowLeaderTextBox.Text;
            Properties.Settings.Default.Save();
        }

        private void AutoFollowDistanceUpDown_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoFollowDistance = (int)AutoFollowDistanceUpDown.Value;
            Properties.Settings.Default.Save();
        }

        #endregion AutoFollow

        #region Footer

        private void MinimizeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.MinimizeConsoleOutput = MinimizeCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void LogFilesButton_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Constants.FileSinkPath);
        }

        private void DeactivateButton_Click(object sender, EventArgs e)
        {
            foreach (var activeCheckbox in _activeCheckBoxes)
            {
                activeCheckbox.Checked = false;
            }

            foreach (var featureCheckbox in _featureCheckBoxes)
            {
                featureCheckbox.Enabled = true;
            }
        }

        private void KillSwitch_Click(object sender, EventArgs e)
        {
            ProcessHelpers.KillTrainers();
            ProcessHelpers.KillClients(ApplicationNameTextBox.Text);
            System.Windows.Forms.Application.Exit();
        }

        #endregion Footer
    }
}
