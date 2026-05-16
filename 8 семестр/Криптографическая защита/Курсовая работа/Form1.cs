using System.Text;

namespace Курсовая_работа
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;

            _bulbs = new Dictionary<char, YellowBulb>
            {
                { 'A', Bulb_A }, { 'B', Bulb_B }, { 'C', Bulb_C }, { 'D', Bulb_D },
                { 'E', Bulb_E }, { 'F', Bulb_F }, { 'G', Bulb_G }, { 'H', Bulb_H },
                { 'I', Bulb_I }, { 'J', Bulb_J }, { 'K', Bulb_K }, { 'L', Bulb_L },
                { 'M', Bulb_M }, { 'N', Bulb_N }, { 'O', Bulb_O }, { 'P', Bulb_P },
                { 'Q', Bulb_Q }, { 'R', Bulb_R }, { 'S', Bulb_S }, { 'T', Bulb_T },
                { 'U', Bulb_U }, { 'V', Bulb_V }, { 'W', Bulb_W }, { 'X', Bulb_X },
                { 'Y', Bulb_Y }, { 'Z', Bulb_Z }
            };
        }

        #region Константы
        readonly List<string> ALPH = [" ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"];
        readonly string alph = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        readonly string nums = "01234567890123456789012345";
        readonly Dictionary<string, List<string>> Rotors = new()
        {
            { "I"   , new List<string>{"EKMFLGDQVZNTOWYHXUSPAIBRCJ", "Q" } },
            { "II"  , new List<string>{"AJDKSIRUXBLHWTMCQGZNPYFVOE", "E" } },
            { "III" , new List<string>{"BDFHJLCPRTXVZNYEIWGAKMUSQO", "V" } },
            { "IV"  , new List<string>{"ESOVPZJAYQUIRHXLNFTGKDCMWB", "J" } },
            { "V"   , new List<string>{"VZBRGITYUPSDNHLXAWMJQOFECK", "Z" } },
            { "VI"  , new List<string>{"JPGVOUMFYQBENHZRDKASXLICTW", "M", "Z" } },
            { "VII" , new List<string>{"NZJHGRCXMYSWBOUFAIVLPEKQDT", "M", "Z" } },
            { "VIII", new List<string>{"FKQHTLXOCBJSPDZRAMEWNIUYGV", "M", "Z" } }
        };
        readonly Dictionary<string, string> Reflectors = new()
        {
            { "B", "YRUHQSLDPXNGOKMIEBFZCWVJAT" },
            { "C", "FVPJIAOYEDRZXWGCTKUQSBNMHL" }
        };
        Dictionary<string, string> KomBoard = [];
        private readonly Dictionary<char, YellowBulb> _bulbs;

        int countLetters = 0;
        int queue = 0;
        #endregion

        #region Процессы для выбора
        private void CB_KomBoard_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ComboBox> KomBoardComboBoxes = [CB_kom11, CB_kom12, CB_kom21, CB_kom22, CB_kom31, CB_kom32, CB_kom41, CB_kom42, CB_kom51, CB_kom52,
                CB_kom61, CB_kom62, CB_kom71, CB_kom72, CB_kom81, CB_kom82, CB_kom91, CB_kom92, CB_kom101, CB_kom102];
            List<string> selectedValues = [];

            foreach (var comboBox in KomBoardComboBoxes)
            {
                string selectVal = comboBox.Text;

                switch (selectVal)
                {
                    case null or " ":
                        selectedValues.Add("");
                        break;

                    default:
                        selectedValues.Add(selectVal);
                        break;
                }
            }

            foreach (var comboBox in KomBoardComboBoxes)
            {
                string currentSelection = comboBox.Text;
                comboBox.SelectedIndexChanged -= CB_KomBoard_SelectedIndexChanged!;

                comboBox.Items.Clear();

                foreach (var letter in ALPH)
                {
                    if (!selectedValues.Contains(letter) || letter.Equals(currentSelection))
                    {
                        comboBox.Items.Add(letter);
                    }
                }

                comboBox.Text = currentSelection;
                comboBox.SelectedIndexChanged += CB_KomBoard_SelectedIndexChanged!;
            }

            KomBoard.Clear();

            for (int i = 0; i < KomBoardComboBoxes.Count; i += 2)
            {
                var comboBox1 = KomBoardComboBoxes[i];
                var comboBox2 = KomBoardComboBoxes[i + 1];

                if (!comboBox1.Text.Equals("") && !comboBox1.Text.Equals(" "))
                {
                    if (!comboBox2.Text.Equals("") && !comboBox2.Text.Equals(" "))
                    {
                        KomBoard.Add(comboBox1.Text, comboBox2.Text);
                        KomBoard.Add(comboBox2.Text, comboBox1.Text);
                    }
                }
            }
        }
        private void CB_Rotors_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ComboBox> RotorsComboBoxes = [CB_LeftRotor, CB_MidRotor, CB_RightRotor];
            List<TextBox> RotorTextBoxes = [TB_LeftRotor, TB_MidRotor, TB_RightRotor];
            List<string> NumRotors = [" ", "I", "II", "III", "IV", "V", "VI", "VII", "VIII"];

            List<string> selectedValues = new List<string>();
            foreach (var comboBox in RotorsComboBoxes)
            {
                string selectVal = comboBox.Text;

                switch (selectVal)
                {
                    case null or " ":
                        selectedValues.Add("");
                        break;

                    default:
                        selectedValues.Add(selectVal);
                        break;
                }
            }

            for (int i = 0; i < RotorsComboBoxes.Count; i++)
            {
                var comboBox = RotorsComboBoxes[i];
                var textBox = RotorTextBoxes[i];
                string selected = comboBox.Text;
                comboBox.SelectedIndexChanged -= CB_Rotors_SelectedIndexChanged!;

                comboBox.Items.Clear();

                foreach (var letter in NumRotors)
                {
                    comboBox.Items.Add(letter);
                }

                foreach (var letter in selectedValues)
                {
                    comboBox.Items.Remove(letter != selected ? letter : "");
                }

                comboBox.Text = selected;
                textBox.Text = selected == "" || selected == " " ? "" : Rotors[selected][0];
                comboBox.SelectedIndexChanged += CB_Rotors_SelectedIndexChanged!;
            }

            foreach (var comboBox in RotorsComboBoxes)
            {

            }
        }
        private void CB_Refl_SelectedIndexChanged(object sender, EventArgs e)
        {
            TB_Refl.Text = CB_Refl.Text != " " ? Reflectors[CB_Refl.Text] : "";
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == TP_ModeMech)
            {
                KeyDown += Form1_KeyDown!;
                KeyUp += Form1_KeyUp!;
            }
            else
            {
                KeyDown -= Form1_KeyDown!;
                KeyUp -= Form1_KeyUp!;
            }
        }
        private void CB_SP_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label_MechPos.Text = $"{CB_SP_LR.Text}   {CB_SP_MR.Text}   {CB_SP_RR.Text}";
        }
        #endregion

        #region Нажатие клавиш

        private Keys _lastPressedKey = Keys.None;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (tabControl1.SelectedTab == TP_ModeMech)
            {
                if (e.Control)
                {
                    return;
                }

                if (RTB_Notebook.Focused)
                {
                    e.SuppressKeyPress = true;
                    return;
                }

                if (e.KeyCode == _lastPressedKey)
                {
                    e.SuppressKeyPress = true;
                    return;
                }

                if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
                {
                    _lastPressedKey = e.KeyCode;

                    char letter = (char)('A' + (e.KeyCode - Keys.A));
                    letter = EnigmaEngine(letter);

                    if (_bulbs.TryGetValue(letter, out var bulb))
                        bulb.IsOn = true;

                    RTB_Notebook.Text += letter.ToString();
                }

                e.SuppressKeyPress = true;
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (tabControl1.SelectedTab == TP_ModeMech)
            {
                _lastPressedKey = Keys.None;

                foreach (var bulb in _bulbs.Values)
                {
                    if (bulb.IsOn)
                        bulb.IsOn = false;
                }
            }
        }

        #endregion

        #region Кнопки
        private void BTN_ClearKom_Click(object sender, EventArgs e)
        {
            List<ComboBox> KomBoardComboBoxes = [CB_kom11, CB_kom12, CB_kom21, CB_kom22, CB_kom31, CB_kom32, CB_kom41, CB_kom42, CB_kom51, CB_kom52,
                CB_kom61, CB_kom62, CB_kom71, CB_kom72, CB_kom81, CB_kom82, CB_kom91, CB_kom92, CB_kom101, CB_kom102];

            foreach (var comboBox in KomBoardComboBoxes)
            {
                comboBox.Text = " ";
            }
        }
        private void BTN_GoStand_Click(object sender, EventArgs e)
        {
            CB_RightRotor.SelectedIndex = 1;
            CB_MidRotor.SelectedIndex = 1;
            CB_LeftRotor.SelectedIndex = 1;
            CB_Refl.SelectedIndex = 1;
            CB_SP_RR.SelectedIndex = 0;
            CB_SP_MR.SelectedIndex = 0;
            CB_SP_LR.SelectedIndex = 0;

        }
        private void BTN_FullEnDe_Click(object sender, EventArgs e)
        {
            string text = RTB_InputText.Text.ToUpper();
            RTB_StepLog.Text = "";
            RTB_OutputText.Text = "";
            ProgBar.Value = 0;
            ProgBar.Maximum = text.Length * 50;


            var sb = new StringBuilder();
            var outtext = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                sb.Append($"Обработка {i + 1} символа:\n");
                char symbol = text[i];
                if (alph.Contains(symbol))
                {
                    outtext.Append(EnigmaEngine(symbol, ref sb));
                }
                else outtext.Append(symbol);
                sb.Append("\n");
                for (int _ = 0; _ < 50; _++) ProgBar.Value++;
            }
            RTB_StepLog.Text = sb.ToString();
            RTB_OutputText.Text = outtext.ToString();
        }
        private void BTN_StepEnDe_Click(object sender, EventArgs e)
        {
            string text = RTB_InputText.Text.ToUpper();
            BTN_StepEnDe.Text = "Следующий шаг";

            if (countLetters == 0 && queue == 0)
            {
                RTB_StepLog.Text = "";
                RTB_OutputText.Text = "";
                countLetters = text.Length;
                ProgBar.Value = 0;
                ProgBar.Maximum = text.Length * 50;
            }

            var sb = new StringBuilder();
            var outtext = new StringBuilder();


            sb.Append($"Обработка {queue + 1} символа:\n");
            char symbol = text[queue];
            if (alph.Contains(symbol))
            {
                outtext.Append(EnigmaEngine(symbol, ref sb));
            }
            else outtext.Append(symbol);
            sb.Append("\n");

            for (int i = 0; i < 50; i++) ProgBar.Value++;

            queue++;

            RTB_StepLog.Text += sb.ToString();
            RTB_OutputText.Text += outtext.ToString();

            if (countLetters == queue)
            {
                BTN_StepEnDe.Text = "Поэтапно шифр/расшифр";
                countLetters = 0;
                queue = 0;
            }
        }
        private void BTN_ClearNotes_Click(object sender, EventArgs e)
        {
            RTB_Notebook.Text = "";
        }
        private void BTN_ResetPos_Click(object sender, EventArgs e)
        {
            CB_SP_RR.SelectedIndex = 0;
            CB_SP_MR.SelectedIndex = 0;
            CB_SP_LR.SelectedIndex = 0;
        }
        #endregion

        #region Алгоритм Энигмы
        private static int Mod(int a, int m)
        {
            return (a % m + m) % m;
        }
        private char EnigmaEngine(char letter, ref StringBuilder output)
        {
            WorkKomBoard(ref letter, ref output);
            WorkRotorTo("right", ref letter, ref output);
            WorkRotorTo("middle", ref letter, ref output);
            WorkRotorTo("left", ref letter, ref output);
            WorkReflector(ref letter, ref output);
            WorkRotorBack("left", ref letter, ref output);
            WorkRotorBack("middle", ref letter, ref output);
            WorkRotorBack("right", ref letter, ref output);
            WorkKomBoard(ref letter, ref output);

            return letter;
        }
        private char EnigmaEngine(char letter)
        {
            var sb = new StringBuilder();
            letter = EnigmaEngine(letter, ref sb);
            sb.Clear();

            return letter;
        }
        private void WorkRotorTo(string rotor, ref char letter, ref StringBuilder output)
        {
            int shift = 0;
            string seqRot = "";
            string letShift = "";
            string name = "";

            switch (rotor)
            {
                case "right":
                    name = "Правый";
                    shift = Mod(CB_SP_RR.SelectedIndex + 1, 26);
                    CB_SP_RR.SelectedIndex = shift;
                    seqRot = TB_RightRotor.Text;
                    letShift = CB_SP_RR.Text;
                    break;

                case "middle":
                    name = "Средний";
                    NotchGo(rotor);
                    shift = CB_SP_MR.SelectedIndex;
                    seqRot = TB_MidRotor.Text;
                    letShift = CB_SP_MR.Text;
                    break;

                case "left":
                    name = "Левый";
                    NotchGo(rotor);
                    shift = CB_SP_LR.SelectedIndex;
                    seqRot = TB_LeftRotor.Text;
                    letShift = CB_SP_LR.Text;
                    break;
            }

            int indexInputLetter = alph.IndexOf(letter);
            output.Append($"\tРотор: {name}\n\t{nums}\n\t{alph}\n\t{seqRot}\n\t" +
                $"Положение ротора: {letShift} - {shift}\n\tБуква: {letter} - {indexInputLetter}");
            letter = seqRot[Mod(indexInputLetter - shift, 26)];
            output.Append($"\n\tПолученное значение: {letter}\n\n");
        }
        private void WorkRotorBack(string rotor, ref char letter, ref StringBuilder output)
        {
            int shift = 0;
            string seqRot = "";
            string letShift = "";
            string name = "";

            switch (rotor)
            {
                case "right":
                    name = "Правый";
                    shift = CB_SP_RR.SelectedIndex;
                    seqRot = TB_RightRotor.Text;
                    letShift = CB_SP_RR.Text;
                    break;

                case "middle":
                    name = "Средний";
                    shift = CB_SP_MR.SelectedIndex;
                    seqRot = TB_MidRotor.Text;
                    letShift = CB_SP_MR.Text;
                    break;

                case "left":
                    name = "Левый";
                    shift = CB_SP_LR.SelectedIndex;
                    seqRot = TB_LeftRotor.Text;
                    letShift = CB_SP_LR.Text;
                    break;
            }

            int indexInputLetter = seqRot.IndexOf(letter);
            output.Append($"\tРотор: {name}\n\t{nums}\n\t{alph}\n\t{seqRot}\n\t" +
                $"Положение ротора: {letShift} - {shift}\n\tБуква: {letter} - {indexInputLetter}");
            letter = alph[Mod(indexInputLetter + shift, 26)];
            output.Append($"\n\tПолученное значение: {letter}\n\n");
        }
        private void NotchGo(string rotor)
        {
            string numRotor = "";
            int position = 0;
            ComboBox CB_Pos = new();

            switch (rotor)
            {
                case "middle":
                    numRotor = CB_RightRotor.Text;
                    position = CB_SP_RR.SelectedIndex;
                    CB_Pos = CB_SP_MR;
                    break;

                case "left":
                    numRotor = CB_MidRotor.Text;
                    position = CB_SP_MR.SelectedIndex;
                    CB_Pos = CB_SP_LR;
                    break;
            }

            var listOfRot = Rotors[numRotor];

            if (new List<string> { "I", "II", "III", "IV", "V" }.Contains(numRotor))
            {
                if (listOfRot[1].Equals($"{listOfRot[0][position]}"))
                {
                    int tempInd = CB_Pos.SelectedIndex + 1;
                    CB_Pos.SelectedIndex = Mod(tempInd, 26);
                }
            }
            else if (new List<string> { "VI", "VII", "VIII" }.Contains(numRotor))
            {
                if (new List<string> { listOfRot[1], listOfRot[2] }.Contains($"{listOfRot[0][position]}"))
                {
                    int tempInd = CB_Pos.SelectedIndex + 1;
                    CB_Pos.SelectedIndex = Mod(tempInd, 26);
                }
            }
        }
        private void WorkReflector(ref char letter, ref StringBuilder output)
        {
            string type = CB_Refl.Text;
            string seqRefl = Reflectors[type];

            output.Append($"\tРефлектор: {type}\n\t{alph}\n\t{seqRefl}\n\tБуква: {letter}");

            int indInAlph = alph.IndexOf(letter);

            letter = seqRefl[indInAlph];

            output.Append($"\n\tПолученное значение: {letter}\n\n");
        }
        private void WorkKomBoard(ref char letter, ref StringBuilder output)
        {
            if (KomBoard.ContainsKey(letter.ToString()))
            {
                output.Append($"\n\tПеревод по коммут. панели:\n\t{letter} -> ");
                letter = char.Parse(KomBoard[letter.ToString()]);
                output.Append($"{letter}\n\n");
            }

        }

        #endregion


    }
}