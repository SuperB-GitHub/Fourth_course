using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Web.Security;
using System.Windows.Forms;
using static MyLibrary.MathUtils;
using static MyLibrary.StringUtils;



namespace Лабораторные_работы
{
    public partial class Form1 : Form
    {
        private List<long> SeqLCG = new List<long>();
        private List<long> SeqPCG = new List<long>();
        private Dictionary<long, List<long>> SeqFIB = new Dictionary<long, List<long>>();
        private List<long> SeqGEF = new List<long>();

        private (int start, int period) PeriodLCG = (0, 0);
        private (int start, int period) PeriodPCG = (0, 0);
        private int PeriodFIB = 0;
        private int PeriodGEF = 0;

        public Form1()
        {
            InitializeComponent();
        }

        // Генераторы псевдослучайной последовательности
        private List<long> GenLCGSeq(long a, long b, long m, long x0, int count)
        {
            List<long> sequence = new List<long>();
            long current = x0;

            for (int i = 0; i < count; i++)
            {
                sequence.Add(current);
                current = (a * current + b) % m;
            }

            return sequence;
        }
        private List<long> GenPCGSeq(long a1, long a2, long b, long m, long x0, int count)
        {
            List<long> sequence = new List<long>();
            long current = x0;

            for (int i = 0; i < count; i++)
            {
                sequence.Add(current);
                current = (Mod(a2 * FastPowMod(current, 2, m), m) + Mod(a1 * current, m) + b) % m;
            }

            return sequence;
        }
        private List<List<long>> GenFIBSeq(long k, List<long> fk, bool print = false)
        {
            long size = fk.Count() - 1;
            long[,] T = new long[size, size];
            for (int i = 1; i <= T.GetLength(1); i++)
            {
                T[0, i-1] = fk[i];
            }

            for (int i = 1; i < T.GetLength(0); i++)
            {
                for (int j = 0; j < T.GetLength(1); j++)
                {
                    T[i, j] = i-1 == j ? 1 : 0;
                }
            }
            if (print) RTB_FIB_Output.Text += "";

            if (print) RTB_FIB_Output.Text += "\n\nT = \n";
            if (print) PrintMatrix(T);

            if (print) RTB_FIB_Output.Text += $"\n\nV = T^k = T^{k} = \n";
            long[,] V = T;
            for(long k_i = 1; k_i < k; k_i++)
            {
                V = MultiplyMatrices(V, T);
            }
            if (print) PrintMatrix(V);

            if (print) RTB_FIB_Output.Text += $"\n\nQ(t+1) = V * Q(t) = \n\n";

            
            List<List<long>> regs = new List<List<long>>();
            for (int i = 0; i < V.GetLength(0); i++)
            {
                List<long> list = new List<long>();
                for (int j = 0; j < V.GetLength(1); j++)
                {
                    if (V[i, j] == 1) list.Add(j+1);
                }
                regs.Add(list);
                if (print) RTB_FIB_Output.Text += $"q{i+1}(t+1) = q{string.Join($"(t) + q",list)}(t)\n";
            }

            return regs;
        }
        private Dictionary<long, List<long>> GenFIBDiag(List<List<long>> regs, long size, List<long> SP)
        {
            Dictionary<long, List<long>> rslos = new Dictionary<long, List<long>>();

            for (long key = 1; key <= size; key++)
            {
                rslos[key] = new List<long> { SP[(int)key - 1] };
            }

            List<long> EP = new List<long>();
            int s = 0;

            while (!EP.SequenceEqual(SP))
            {
                
                EP = new List<long>();
                for (long key = 1; key <= size; key++)
                {
                    List<long> reg = regs[(int)(key - 1)];
                    long sums = 0;
                    foreach (long item in reg)
                    {
                        sums += rslos[item][s];
                    }
                    rslos[key] = new List<long>(rslos[key]) { Mod(sums, 2) };
                    EP.Add(Mod(sums, 2));
                }
                s++;
            }

            return rslos;

        }

        // Проверки на максимальный период
        private bool CheckMaxPeriodLCG(long a, long b, long m)
        {
            // Условия для максимального периода (m):
            // 1. b и m взаимно просты
            // 2. a-1 делится на все простые делители m
            // 3. Если m делится на 4, то a-1 должно делиться на 4

            // 1. Проверка взаимной простоты b и m
            if (NOD(b, m) != 1)
            {
                CLB_MaxPeriod.SetItemChecked(0, false);
                return false;
            }
            CLB_MaxPeriod.SetItemChecked(0, true);

            // 2. Проверка делимости a-1 на все простые делители m
            long aMinus1 = a - 1;

            // Получаем простые делители m
            var primeFactors = PrimeFactors(m);
            foreach (var factor in primeFactors)
            {
                if (aMinus1 % factor != 0)
                {
                    CLB_MaxPeriod.SetItemChecked(1, false);
                    return false;
                }
            }
            CLB_MaxPeriod.SetItemChecked(1, true);

            // 3. Проверка для случая, когда m делится на 4
            if (m % 4 == 0 && aMinus1 % 4 != 0)
            {
                CLB_MaxPeriod.SetItemChecked(2, false);
                return false;
            }
            CLB_MaxPeriod.SetItemChecked(2, true);

            return true;
        }
        private bool CheckMaxPeriodPCG(long a1, long a2, long b, long m)
        {
            // Условия для максимального периода (m):
            // 1. Числа b и m – взаимно просты
            // 2. a₁-1 и a₂ делится на все простые делители m
            // 3. Если a₂ - чётное и если
            // 3.1 a₂ ≡ (a₁-1)(mod 4), если m кратно 4
            // 3.1 a₂ ≡ (a₁-1)(mod 2), если m кратно 2
            // 4. Если m кратно 9, то a₂ ≢ 3b(mod 9)

            // 1. Проверка взаимной простоты b и m
            if (NOD(b, m) != 1)
            {
                CLB_PCG_MaxPeriod.SetItemChecked(0, false);
                return false;
            }
            CLB_PCG_MaxPeriod.SetItemChecked(0, true);

            // 2. Проверка делимости a-1 и а2 на все простые делители m
            long aMinus1 = a1 - 1;
            var primeFactors = PrimeFactors(m);
            foreach (var factor in primeFactors)
            {
                if (aMinus1 % factor != 0 || a2 % factor != 0)
                {
                    CLB_PCG_MaxPeriod.SetItemChecked(1, false);
                    return false;
                }
            }
            CLB_PCG_MaxPeriod.SetItemChecked(1, true);

            // 3. Проверка четности а2
            if (a2 % 2 == 0)
            {
                CLB_PCG_MaxPeriod.SetItemChecked(2, true);

                // 3. Проверка кратности m к 4 и сравнение
                if (m % 4 == 0 && Mod(a2, 4) == Mod(aMinus1, 4))
                {
                    CLB_PCG_MaxPeriod.SetItemChecked(3, true);
                    CLB_PCG_MaxPeriod.SetItemChecked(4, false);
                }
                // 3. Проверка кратности m к 2 и сравнение
                else if (m % 2 == 0 && Mod(a2,2) == Mod(aMinus1, 2))
                {
                    CLB_PCG_MaxPeriod.SetItemChecked(3, false);
                    CLB_PCG_MaxPeriod.SetItemChecked(4, true);
                }
                else
                {
                    CLB_PCG_MaxPeriod.SetItemChecked(2, false);
                    CLB_PCG_MaxPeriod.SetItemChecked(3, false);
                    CLB_PCG_MaxPeriod.SetItemChecked(4, false);
                    return false;
                }
            }
            else
            {
                CLB_PCG_MaxPeriod.SetItemChecked(2, false);
                CLB_PCG_MaxPeriod.SetItemChecked(3, false);
                CLB_PCG_MaxPeriod.SetItemChecked(4, false);
                return false;
            }

            // 4. Проверка кратности m к 9 и сравнение
            if (m % 9 != 0 || Mod(a2, 9) == Mod(3 * b, 9))
            {
                CLB_PCG_MaxPeriod.SetItemChecked(5, false);
                return false;
            }
            CLB_PCG_MaxPeriod.SetItemChecked(5, true);

            return true;
        }

        // Обработчики кнопки "Сгенерировать"
        private void BTN_GenLCGSeq_Click(object sender, EventArgs e)
        {
            try
            {
                if (!long.TryParse(textBoxA.Text, out long a))
                {
                    MessageBox.Show("Неверное значение параметра a", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!long.TryParse(textBoxB.Text, out long b))
                {
                    MessageBox.Show("Неверное значение параметра b", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!long.TryParse(textBoxM.Text, out long m) || m <= 0)
                {
                    MessageBox.Show("Неверное значение параметра m (должно быть положительным)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!long.TryParse(textBoxX0.Text, out long x0))
                {
                    MessageBox.Show("Неверное начальное значение x₀", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int count = (int)numericUpDownCount.Value;

                SeqLCG = GenLCGSeq(a, b, m, x0, count);

                PeriodLCG = FindPeriod(GenLCGSeq(a, b, m, x0, (int)m + 2));

                textBoxSequence.Text = SeqToString(SeqLCG);

                textBoxPeriod.Text = PeriodLCG.period.ToString();

                bool hasMaxPeriod = CheckMaxPeriodLCG(a, b, m);
                checkBoxMaxPeriod.Checked = hasMaxPeriod;

                if (PeriodLCG.period == m)
                {
                    checkBoxMaxPeriod.Checked = true;
                    textBoxPeriod.Text += " (максимальный)";
                }
                else
                {
                    textBoxPeriod.Text += $" (обнаружен на {PeriodLCG.start}-м шаге)";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при генерации последовательности: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BTN_GenPCGSeq_Click(object sender, EventArgs e)
        {
            try
            {
                if (!long.TryParse(TB_PCG_a1.Text, out long a1))
                {
                    MessageBox.Show("Неверное значение параметра a₁", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!long.TryParse(TB_PCG_a2.Text, out long a2))
                {
                    MessageBox.Show("Неверное значение параметра a₂", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!long.TryParse(TB_PCG_b.Text, out long b))
                {
                    MessageBox.Show("Неверное значение параметра b", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!long.TryParse(TB_PCG_m.Text, out long m) || m <= 0)
                {
                    MessageBox.Show("Неверное значение параметра m (должно быть положительным)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!long.TryParse(TB_PCG_x0.Text, out long x0))
                {
                    MessageBox.Show("Неверное начальное значение x₀", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int count = (int)PCG_Count.Value;

                SeqPCG = GenPCGSeq(a1, a2, b, m, x0, count);

                PeriodPCG = FindPeriod(GenPCGSeq(a1, a2, b, m, x0, (int)m + 2));

                TB_PCG_Seq.Text = SeqToString(SeqPCG);

                TB_PCG_Period.Text = PeriodPCG.period.ToString();

                bool hasMaxPeriod = CheckMaxPeriodPCG(a1, a2, b, m);
                CB_PCG_MaxPeriod.Checked = hasMaxPeriod;

                if (PeriodPCG.period == m)
                {
                    CB_PCG_MaxPeriod.Checked = true;
                    TB_PCG_Period.Text += " (максимальный)";
                }
                else
                {
                    TB_PCG_Period.Text += $" (обнаружен на {PeriodPCG.start}-м шаге)";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при генерации последовательности: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BTN_FIB_GenSeq_Click(object sender, EventArgs e)
        {
            try
            {
                if (!long.TryParse(TB_FIB_k.Text, out long k))
                {
                    MessageBox.Show("Неверное значение параметра k", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<long> Fk = TB_FIB_Fx.Text.Split(' ')
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Select(long.Parse)
                    .ToList();

                long N = Fk.Max();

                if (TB_FIB_StartPos.Text.Length != N)
                {
                    MessageBox.Show("Неверное значение начальной позиции", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<long> SP = TB_FIB_StartPos.Text.Where(c => char.IsDigit(c))
                    .Select(c => long.Parse(c.ToString()))
                    .ToList();

                List<long> bitsFk = new List<long>();
                for (long i = 0; i <= N; i++)
                {
                    long bit = Fk.Contains(i) ? 1 : 0;
                    bitsFk.Add(bit);
                    RTB_FIB_Output.Text += $"a{i} = {bit}; ";
                }


                var rslos = GenFIBDiag(GenFIBSeq(k, bitsFk, true), N, SP);

                SeqFIB = rslos;
                FillDataGridViewSimple(rslos);
                Fill_Qs(CB_FIB_Qs, rslos);

                long S = (long)Math.Pow(2, N) - 1;
                PeriodFIB = (int)S;
                Lab_FIB_S.Text = $"S = 2^N-1 = 2^{N} - 1 = {S}";
                Lab_FIB_NOD.Text = $"НОД(S, k) = НОД({S}, {k}) = {NOD(S,k)}";


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при генерации последовательности: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BTN_GEF_GenSeq_Click(object sender, EventArgs e)
        {
            void Input_k(string TextBox, out long k)
            {
                if (!long.TryParse(TextBox, out k))
                {
                    MessageBox.Show("Неверное значение параметра k", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            void Input_Fk(string TextBox, out List<long> Fk, out long N)
            {
                Fk = TextBox.Split(' ')
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Select(long.Parse)
                    .ToList();

                N = Fk.Max();
            }
            void Input_SP(string TextBox, long N, List<long> Fk, out List<long> SP, out List<long> bitsFk)
            {
                SP = TextBox.Where(c => char.IsDigit(c))
                    .Select(c => long.Parse(c.ToString()))
                    .ToList();

                bitsFk = new List<long> { };

                if (TextBox.Length != N)
                {
                    MessageBox.Show("Неверное значение начальной позиции", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                for (long i = 0; i <= N; i++)
                {
                    bitsFk.Add(Fk.Contains(i) ? 1 : 0);
                }
            }
            string Print_Qs(Dictionary<long, List<long>> rslos, long q)
            {
                List<long> selectedList = rslos[q];

                string binaryString = string.Join("", selectedList);
                binaryString = binaryString.Substring(0, binaryString.Length - 1);

                return binaryString;

                //RTB_FIB_Output.Text += $"\nq{selectedKey} = {Convert.ToInt64(binaryString, 2)}";
            }
            long Multiplex(long x1, long x2, long x3)
            {
                return ((x1 * x2) == (x2 * x3) ? 1 : 0) == x3 ? 1 : 0;
            }

            try
            {
                Input_Fk(TB_GEF_Fx1.Text, out List<long> Fk1, out long N1);
                Input_Fk(TB_GEF_Fx2.Text, out List<long> Fk2, out long N2);
                Input_Fk(TB_GEF_Fx3.Text, out List<long> Fk3, out long N3);

                Input_k(TB_GEF_k1.Text, out long k1);
                Input_k(TB_GEF_k2.Text, out long k2);
                Input_k(TB_GEF_k3.Text, out long k3);

                Input_SP(TB_GEF_SP1.Text, N1, Fk1, out List<long> SP1, out List<long> bitsFk1);
                Input_SP(TB_GEF_SP2.Text, N2, Fk2, out List<long> SP2, out List<long> bitsFk2);
                Input_SP(TB_GEF_SP3.Text, N3, Fk3, out List<long> SP3, out List<long> bitsFk3);

                var rslos1 = GenFIBDiag(GenFIBSeq(k1, bitsFk1), N1, SP1);
                var rslos2 = GenFIBDiag(GenFIBSeq(k2, bitsFk2), N2, SP2);
                var rslos3 = GenFIBDiag(GenFIBSeq(k3, bitsFk3), N3, SP3);

                long S1 = (long)Math.Pow(2, N1) - 1;
                Lab_GEF_S1.Text = $" {S1}";

                long S2 = (long)Math.Pow(2, N2) - 1;
                Lab_GEF_S2.Text = $" {S2}";

                long S3 = (long)Math.Pow(2, N3) - 1;
                Lab_GEF_S3.Text = $" {S3}";

                bool coprime = CrossSimple(S1, S2, S3);
                long S = 0;

                if (CB_GEF_q1.Items.Count == 0 || CB_GEF_q2.Items.Count == 0 || CB_GEF_q3.Items.Count == 0)
                {
                    Fill_Qs(CB_GEF_q1, rslos1);
                    Fill_Qs(CB_GEF_q2, rslos2);
                    Fill_Qs(CB_GEF_q3, rslos3);
                }
                else
                {
                    if (coprime)
                    {
                        RTB_GEF_Output.Text += $"Т.к. НОД({S1}, {S2}, {S3}) = {(coprime ? 1 : 0)}, то S = {S1} * {S2} * {S3} = {S = S1 * S2 * S3}\n\n";
                    }
                    else
                    {
                        RTB_GEF_Output.Text += $"Т.к. НОД({S1}, {S2}, {S3}) = {(coprime ? 1 : 0)}, то S = НОK({S1}, {S2}, {S3}) = {S = HOK(S1, S2, S3)} Максисальный - {S1 * S2 * S3}\n\n";
                    }
                    Lab_GEF_S.Text = $" {S}";
                    PeriodGEF = (int)S;

                    long q1 = (long)CB_GEF_q1.SelectedItem;
                    long q2 = (long)CB_GEF_q2.SelectedItem;
                    long q3 = (long)CB_GEF_q3.SelectedItem;
                    RTB_GEF_Output.Text += $"РСЛОС1 = {Print_Qs(rslos1, q1)} \n" +
                        $"РСЛОС2 = {Print_Qs(rslos2, q2)} \nРСЛОС3 = {Print_Qs(rslos3, q3)}\n";

                    RTB_GEF_Output.Text += $"\n f(x1, x2, x3) = ";
                    for (long i = 0; i < S; i++)
                    {
                        long elem = Multiplex(rslos1[q1][(int)Mod(i, S1)], rslos2[q2][(int)Mod(i, S2)], rslos3[q3][(int)Mod(i, S3)]);
                        SeqGEF.Add(elem);
                        RTB_GEF_Output.Text += $"{elem}";
                    }

                    string binaryString = string.Join("", SeqGEF);
                    binaryString = binaryString.Substring(0, binaryString.Length - 1);

                    //RTB_FIB_OutQs.Text = binaryString;
                    BigInteger result = 0;
                    foreach (char c in binaryString)
                    {
                        result = result * 2 + (c == '1' ? 1 : 0);
                    }
                    RTB_GEF_Output.Text += $"\n\nВ 10сс = {result*2}";

                }
        }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при генерации последовательности: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        // Обработчики кнопки "Сохранить"
        private void BTN_LCG_Save_Click(object sender, EventArgs e)
        {
            if (SeqLCG == null || SeqLCG.Count == 0)
            {
                MessageBox.Show("Нет данных для сохранения. Сначала сгенерируйте последовательность.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SaveFunc(1);
        }
        private void BTN_PCG_Save_Click(object sender, EventArgs e)
        {
            if (SeqPCG == null || SeqPCG.Count == 0)
            {
                MessageBox.Show("Нет данных для сохранения. Сначала сгенерируйте последовательность.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SaveFunc(2);
        }
        private void BTN_FIB_Save_Click(object sender, EventArgs e)
        {
            if (SeqFIB == null || SeqFIB.Count == 0)
            {
                MessageBox.Show("Нет данных для сохранения. Сначала сгенерируйте последовательность.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SaveFunc(3);
        }
        private void BTN_GEF_Save_Click(object sender, EventArgs e)
        {
            if (SeqGEF == null || SeqGEF.Count == 0)
            {
                MessageBox.Show("Нет данных для сохранения. Сначала сгенерируйте последовательность.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SaveFunc(4);
        }
        private void SaveFunc(int typeGen)
        {
            string fileName = "NaN";
            string name = "NaN";
            string param = "NaN";
            int count = 0;
            int period = 0;
            bool maxPer = false;
            List<long> seq = new List<long>();

            switch (typeGen)
            {
                case 1:
                    fileName = "ЛКГ";
                    name = "Линейный конгруэнтный генератор псевдослучайных чисел";
                    param = $"Параметры: a = {textBoxA.Text}, b = {textBoxB.Text}, m = {textBoxM.Text}, x₀ = {textBoxX0.Text}";
                    count = SeqLCG.Count;
                    period = PeriodLCG.period;
                    maxPer = checkBoxMaxPeriod.Checked;
                    seq = SeqLCG;
                    break;
                case 2:
                    fileName = "ПКГ";
                    name = "Полиномиальный конгруэнтный генератор псевдослучайных чисел";
                    param = $"Параметры: a₁ = {TB_PCG_a1.Text}, a₂ = {TB_PCG_a2.Text}, b = {TB_PCG_b.Text}, m = {TB_PCG_m.Text}, x₀ = {TB_PCG_x0.Text}";
                    count = SeqPCG.Count;
                    period = PeriodPCG.period;
                    maxPer = CB_PCG_MaxPeriod.Checked;
                    seq = SeqPCG;
                    break;
                case 3:
                    fileName = "Фибоначчи";
                    name = "Генератор Фибоначчи псевдослучайных чисел на РСЛОС";
                    param = $"Параметры: Ф(k) = {TB_FIB_Fx.Text}, k = {TB_FIB_k.Text}, Нач.поз. = {TB_FIB_StartPos.Text}, qs = {CB_FIB_Qs.Text}";
                    count = PeriodFIB;
                    period = PeriodFIB;
                    maxPer = NOD(PeriodFIB, int.Parse(TB_FIB_k.Text)) == 1;
                    seq = SeqFIB[long.Parse(CB_FIB_Qs.Text)];
                    break;
                case 4:
                    fileName = "Гефе";
                    name = "Генератор Гефе псевдослучайных чисел на РСЛОСах";
                    param = $"Параметры:\n" +
                        $"Ф1(k) = {TB_GEF_Fx1.Text}, k1 = {TB_GEF_k1.Text}, Нач.поз.1 = {TB_GEF_SP1.Text}, q1s = {CB_GEF_q1.Text}\n" +
                        $"Ф2(k) = {TB_GEF_Fx2.Text}, k2 = {TB_GEF_k2.Text}, Нач.поз.2 = {TB_GEF_SP2.Text}, q2s = {CB_GEF_q2.Text}\n" +
                        $"Ф3(k) = {TB_GEF_Fx3.Text}, k3 = {TB_GEF_k3.Text}, Нач.поз.3 = {TB_GEF_SP3.Text}, q3s = {CB_GEF_q3.Text}";
                    count = PeriodGEF;
                    period = PeriodGEF;
                    maxPer = CrossSimple(long.Parse(Lab_GEF_S1.Text), long.Parse(Lab_GEF_S2.Text), long.Parse(Lab_GEF_S3.Text));
                    seq = SeqGEF;
                    break;
            }
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                saveDialog.Title = "Сохранить последовательность";
                saveDialog.DefaultExt = "txt";
                saveDialog.FileName = $"{fileName}.txt";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Сохраняем не только числа, но и информацию о параметрах
                        StringBuilder fileContent = new StringBuilder();
                        fileContent.AppendLine(name);
                        fileContent.AppendLine("======================================================");
                        fileContent.AppendLine($"Дата генерации: {DateTime.Now:dd.MM.yyyy HH:mm:ss}");
                        fileContent.AppendLine(param);
                        fileContent.AppendLine($"Количество чисел: {count}");
                        fileContent.AppendLine($"Период последовательности: {period}");
                        fileContent.AppendLine($"Максимальный период: {(maxPer ? "Да" : "Нет")}");
                        fileContent.AppendLine();
                        fileContent.AppendLine("Последовательность чисел:");
                        fileContent.AppendLine();

                        for (int i = 0; i < count; i++)
                        {
                            fileContent.Append($"{seq[i]}");
                            if (i < count - 1)
                                fileContent.Append(", ");
                        }

                        File.WriteAllText(saveDialog.FileName, fileContent.ToString());
                        MessageBox.Show($"Последовательность успешно сохранена в файл:\n{saveDialog.FileName}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Обработчики кнопки "Очистить"
        private void BTN_LCG_Clear_Click(object sender, EventArgs e)
        {
            SeqLCG.Clear();
            textBoxSequence.Clear();
            textBoxPeriod.Clear();
            checkBoxMaxPeriod.Checked = false;
            PeriodLCG = (0, 0);
        }
        private void BTN_PCG_Clear_Click(object sender, EventArgs e)
        {
            SeqPCG.Clear();
            TB_PCG_Seq.Clear();
            TB_PCG_Period.Clear();
            CB_PCG_MaxPeriod.Checked = false;
            PeriodPCG = (0, 0);
        }
        private void BTN_FIB_Clear_Click(object sender, EventArgs e)
        {
            RTB_FIB_Output.Text = "";
            RTB_FIB_OutQs.Text = "";
            CB_FIB_Qs.Items.Clear();
            DGW_FIB_Diagram.Rows.Clear();
            RTB_FIB_OutQs.Clear();
        }
        private void BTN_GEF_Clear_Click(object sender, EventArgs e)
        {
            RTB_GEF_Output.Text = "";
            TB_GEF_Fx1.Clear();
            TB_GEF_Fx2.Clear();
            TB_GEF_Fx3.Clear();
            TB_GEF_k1.Clear();
            TB_GEF_k2.Clear();
            TB_GEF_k3.Clear();
            TB_GEF_SP1.Clear();
            TB_GEF_SP2.Clear();
            TB_GEF_SP3.Clear();
            CB_GEF_q1.Items.Clear();
            CB_GEF_q2.Items.Clear();
            CB_GEF_q3.Items.Clear();
            Lab_GEF_S1.Text = "Тут будет S";
            Lab_GEF_S2.Text = "Тут будет S";
            Lab_GEF_S3.Text = "Тут будет S";
            Lab_GEF_S.Text = "Тут будет S";
            SeqGEF = new List<long> ();

        }

        // Обработчики выбора пресета
        private void CB_LCG_PreSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPresets.SelectedIndex > 0)
            {
                string selectedPreset = comboBoxPresets.SelectedItem.ToString();

                // Разбираем строку пресета
                string[] parts = selectedPreset.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length >= 3)
                {
                    textBoxA.Text = parts[0];
                    textBoxB.Text = parts[1];
                    textBoxM.Text = parts[2];
                    textBoxX0.Text = "1"; // Устанавливаем начальное значение по умолчанию

                    // Автоматически устанавливаем количество чисел
                    numericUpDownCount.Value = 200;
                }
            }
        }
        private void CB_PCG_PreSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_PCG_PreSets.SelectedIndex > 0)
            {
                string selectedPreset = CB_PCG_PreSets.SelectedItem.ToString();

                string[] parts = selectedPreset.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length >= 4)
                {
                    TB_PCG_a1.Text = parts[0];
                    TB_PCG_a2.Text = parts[1];
                    TB_PCG_b.Text = parts[2];
                    TB_PCG_m.Text = parts[3];
                    TB_PCG_x0.Text = "1";

                    PCG_Count.Value = 200;
                }
            }
        }
        private void CB_FIB_Qs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_FIB_Qs.SelectedItem != null)
            {
                long selectedKey = (long)CB_FIB_Qs.SelectedItem;

                if (SeqFIB.ContainsKey(selectedKey))
                {
                    List<long> selectedList = SeqFIB[selectedKey];

                    RTB_FIB_OutQs.Clear();
                    string binaryString = string.Join("", selectedList);
                    binaryString = binaryString.Substring(0, binaryString.Length - 1);

                    RTB_FIB_OutQs.Text = binaryString;

                    RTB_FIB_Output.Text += $"\nq{selectedKey} = {Convert.ToInt64(binaryString, 2)}";

                }
                else
                {
                    RTB_FIB_OutQs.Text = "Ключ не найден в словаре";
                }
            }
        }

        // Вспомогательные функции
        private string SeqToString(List<long> sequence, int numbersPerLine = 10)
        {
            if (sequence == null || sequence.Count == 0)
                return "";

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < sequence.Count; i++)
            {
                sb.Append($"{sequence[i],6}");

                if ((i + 1) % numbersPerLine == 0 || i == sequence.Count - 1)
                {

                    // Добавляем номер строки
                    if ((i + 1) % numbersPerLine == 0)
                    {
                        int startLine = i - numbersPerLine + 2;
                        int endLine = i + 1;
                        sb.AppendLine($"  // {startLine}-{endLine}");
                    }
                }
                else
                {
                    sb.Append(", ");
                }
            }

            return sb.ToString();
        }
        private (int start, int period) FindPeriod(List<long> sequence)
        {
            if (sequence == null || sequence.Count < 2)
                return (0, 0);

            var seen = new Dictionary<(long, long), int>();

            for (int i = 0; i < sequence.Count; i++)
            {
                long first = sequence[i];
                long second = (i + 1 < sequence.Count) ? sequence[i + 1] : sequence[0];
                var pair = (first, second);

                if (seen.ContainsKey(pair))
                {
                    int possiblePeriod = i - seen[pair];
                    return (seen[pair], possiblePeriod);
                }

                seen[pair] = i;
            }
            return (0, sequence.Count);
        }
        private long[,] MultiplyMatrices(long[,] a, long[,] b)
        {
            int rowsA = a.GetLength(0);
            int colsA = a.GetLength(1);
            int rowsB = b.GetLength(0);
            int colsB = b.GetLength(1);

            if (colsA != rowsB)
                throw new ArgumentException("Матрицы нельзя перемножить");

            long[,] result = new long[rowsA, colsB];

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    for (long k = 0; k < colsA; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                        result[i, j] = Mod(result[i, j], 2);

                    }
                }
            }
            return result;
        }
        private void PrintMatrix(long[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    RTB_FIB_Output.Text += $"{a[i, j]} ";
                }
                RTB_FIB_Output.Text += $"\n";
            }
        }
        private void FillDataGridViewSimple(Dictionary<long, List<long>> rslos)
        {
            // Очищаем существующие столбцы и строки
            DGW_FIB_Diagram.Columns.Clear();
            DGW_FIB_Diagram.Rows.Clear();

            // Добавляем столбцы из ключей словаря
            foreach (var key in rslos.Keys)
            {
                DGW_FIB_Diagram.Columns.Add(key.ToString(), "q"+key.ToString());
            }

            // Находим максимальное количество элементов в списках
            int maxRowCount = rslos.Values.Max(list => list.Count);

            // Заполняем строки
            for (int i = 0; i < maxRowCount; i++)
            {
                // Создаем массив значений для строки
                string[] rowValues = new string[rslos.Count];
                int columnIndex = 0;

                foreach (var kvp in rslos)
                {
                    if (i < kvp.Value.Count)
                    {
                        rowValues[columnIndex] = kvp.Value[i].ToString();
                    }
                    else
                    {
                        rowValues[columnIndex] = string.Empty;
                    }
                    columnIndex++;
                }

                // Добавляем строку
                int rowIndex = DGW_FIB_Diagram.Rows.Add(rowValues);

                // Устанавливаем заголовок строки
                DGW_FIB_Diagram.Rows[rowIndex].HeaderCell.Value = (i + 1).ToString();
            }

            foreach (DataGridViewColumn column in DGW_FIB_Diagram.Columns)
            {
                column.Width = 389/DGW_FIB_Diagram.ColumnCount; // Ширина столбца в пикселях
            }
            // Настройка внешнего вида
            DGW_FIB_Diagram.RowHeadersWidth = 55;
            DGW_FIB_Diagram.ReadOnly = true;
            DGW_FIB_Diagram.AllowUserToAddRows = false;
        }
        private void Fill_Qs(ComboBox CB, Dictionary<long, List<long>> rslos)
        {
            CB.Items.Clear();

            foreach (var key in rslos.Keys)
            {
                CB.Items.Add(key);
            }

            CB.Sorted = true;
        }


    }
}