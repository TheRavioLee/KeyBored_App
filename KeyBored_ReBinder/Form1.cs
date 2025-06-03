using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace KeyBored_ReBinder
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> keyCodes = new Dictionary<string, string>
        {
            { "NONE", "00" },
            { "aA", "04" },
            { "bB", "05" },
            { "cC", "06" },
            { "dD", "07" },
            { "eE", "08" },
            { "fF", "09" },
            { "gG", "0A" },
            { "hH", "0B" },
            { "iI", "0C" },
            { "jJ", "0D" },
            { "kK", "0E" },
            { "lL", "0F" },
            { "mM", "10" },
            { "nN", "11" },
            { "oO", "12" },
            { "pP", "13" },
            { "qQ", "14" },
            { "rR", "15" },
            { "sS", "16" },
            { "tT", "17" },
            { "uU", "18" },
            { "vV", "19" },
            { "wW", "1A" },
            { "xX", "1B" },
            { "yY", "1C" },
            { "xZ", "1D" },
            { "1!", "1E" },
            { "2@", "1F" },
            { "3#", "20" },
            { "4$", "21" },
            { "5%", "22" },
            { "6^", "23" },
            { "7", "24" },
            { "8*", "25" },
            { "9(", "26" },
            { "0)", "27" },
            { "ENTER", "28" },
            { "ESC", "29" },
            { "BACKSPACE", "2A" },
            { "TAB", "2B" },
            { "SPACE", "2C" },
            { "-_", "2D" },
            { "=+", "2E" },
            { "[{", "2F" },
            { "]}", "30" },
            { "|", "31" },
            { ";:", "33" },
            { "'", "34" },
            { "`~", "35" },
            { ",<", "36" },
            { ".>", "37" },
            { "/?", "38" },
            { "CAPSLOCK", "39" },
            { "F1", "3A" },
            { "F2", "3B" },
            { "F3", "3C" },
            { "F4", "3D" },
            { "F5", "3E" },
            { "F6", "3F" },
            { "F7", "40" },
            { "F8", "41" },
            { "F9", "42" },
            { "F10", "43" },
            { "F11", "44" },
            { "F12", "45" },
            { "PRNTSCRN", "46" },
            { "SCROLL_LOCK", "47" },
            { "PAUSE", "48" },
            { "INSERT", "49" },
            { "HOME", "4A" },
            { "PAGEUP", "4B" },
            { "DEL_FORWARD", "4C" },
            { "END", "4D" },
            { "PAGEDOWN", "4E" },
            { "RIGHT_ARROW", "4F" },
            { "LEFT_ARROW", "50" },
            { "DOWN_ARROW", "51" },
            { "UP_ARROW", "52" },
            { "PLAY/PAUSE", "CD" },
            { "MUTE", "E2" },
            { "VOL_UP", "E9" },
            { "VOL_DOWN", "EA" },
            { "NEXT", "B5" },
            { "PREVIOUS", "B6" },
            { "BRIGHT_DOWN", "70" },
            { "BRIGHT_UP", "6F" },
            { "LCTRL", "E0" },
            { "LSHIFT", "E1" },
            { "LALT", "E2" },
            { "LSUPER", "E3" },
            { "RCTRL", "E4" },
            { "RSHIFT", "E5" },
            { "RALT", "E6" },
            { "RSUPER", "E7" }
        };


        System.Windows.Forms.Button lastButtonClicked = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonRemap_Click(object sender, EventArgs e)
        {
            lastButtonClicked = null;
            contextMenuStripSelection.Show(((System.Windows.Forms.Button)sender), new Point(0, ((System.Windows.Forms.Button)sender).Height));
            lastButtonClicked = ((System.Windows.Forms.Button)sender);
        }

        private void buttonCopieFN_Click(object sender, EventArgs e)
        {
            StringBuilder keymap = new StringBuilder();

            switch(((System.Windows.Forms.Button)sender).Name)
            {
                case "buttonCopieFN":
                    keymap.Append("03");
                    break;
                case "buttonCopieFN_3":
                    keymap.Append("05");
                    break;
            }

            for (int i = 1; i <= 63; i++)
            {
                System.Windows.Forms.Button b = this.Controls.Find($"Key{i}", true).FirstOrDefault() as Button;
                string key;
                switch(i)
                {
                    case 54:
                    case 61:
                    case 62:
                    case 63:
                        keymap.Append(" 00");
                        break;
                    default:
                        if (keyCodes.TryGetValue((string)b.Text, out key))
                        {
                            keymap.Append(" ").Append(key);
                        }
                        else
                        {
                            keymap.Append(" 00");
                        }
                        break;
                }
            }

            string finalString = keymap.ToString().Trim();

            Clipboard.SetText(finalString);
            MessageBox.Show("Résultat copié dans le presse-papier:\n" + finalString, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonCopieAlt_Click(object sender, EventArgs e)
        {
            StringBuilder keymap = new StringBuilder();
            

            switch (((System.Windows.Forms.Button)sender).Name)
            {
                case "buttonCopieAlt":
                    keymap.Append("04");
                    break;
                case "buttonCopieAlt_3":
                    keymap.Append("06");
                    break;
            }

            for (int i = 65; i <= 127; i++)
            {
                System.Windows.Forms.Button b = this.Controls.Find($"Key{i}", true).FirstOrDefault() as Button;
                string key;
                switch (i)
                {
                    case 117:
                    case 124:
                    case 125:
                    case 126:
                    case 127:
                        keymap.Append(" 00");
                        break;
                    default:
                        if (keyCodes.TryGetValue((string)b.Text, out key))
                        {
                            keymap.Append(" ").Append(key);
                        }
                        else
                        {
                            keymap.Append(" 00");
                        }
                        break;
                }
            }

            string finalString = keymap.ToString().Trim();

            Clipboard.SetText(finalString);
            MessageBox.Show("Résultat copié dans le presse-papier:\n" + finalString, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Selection_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string key = ((ToolStripMenuItem)sender).Text;
            lastButtonClicked.Text = key;
        }

        private void ClearSelection_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lastButtonClicked.Text = null;
        }

        private void buttonLink_Click(object sender, EventArgs e)
        {
        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
        {
            FileName = "https://nondebug.github.io/webhid-explorer/",
            UseShellExecute = true
        });
        }

        private void ClearAll_FN_button_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 64; i++)
            {
                System.Windows.Forms.Button b = this.Controls.Find($"Key{i}", true).FirstOrDefault() as Button;
                b.Text = null;
            }
        }

        private void ClearAll_ALT_button_Click(object sender, EventArgs e)
        {
            for (int i = 65; i <= 127; i++)
            {
                System.Windows.Forms.Button b = this.Controls.Find($"Key{i}", true).FirstOrDefault() as Button;
                b.Text = null;
            }
        }
    }
}
