using System;
using System.Collections.Generic;

namespace Курсовая_работа
{
    public class EnigmaMachine
    {
        private Rotor[] rotors;
        private Reflector reflector;

        // Схемы роторов (стандартные настройки Энигмы)
        private static readonly Dictionary<int, string> rotorWiring = new Dictionary<int, string>
        {
            { 1, "EKMFLGDQVZNTOWYHXUSPAIBRCJ" },  // Ротор I
            { 2, "AJDKSIRUXBLHWTMCQGZNPYFVOE" },  // Ротор II
            { 3, "BDFHJLCPRTXVZNYEIWGAKMUSQO" }   // Ротор III
        };

        // Схемы рефлекторов
        private static readonly Dictionary<string, string> reflectorWiring = new Dictionary<string, string>
        {
            { "B", "YRUHQSLDPXNGOKMIEBFZCWVJAT" },
            { "C", "FVPJIAOYEDRZXWGCTKUQSBNMHL" }
        };

        public EnigmaMachine(int[] rotorTypes, char[] initialPositions, string reflectorType)
        {
            if (rotorTypes.Length != 3 || initialPositions.Length != 3)
                throw new ArgumentException("Должно быть 3 ротора");

            rotors = new Rotor[3];
            for (int i = 0; i < 3; i++)
            {
                rotors[i] = new Rotor(rotorWiring[rotorTypes[i]], initialPositions[i]);
            }

            reflector = new Reflector(reflectorWiring[reflectorType]);
        }

        public char Encrypt(char input)
        {
            // Шаг 1: Поворот роторов
            bool rotateNext = true;
            for (int i = 2; i >= 0; i--)
            {
                if (rotateNext)
                {
                    rotateNext = rotors[i].Rotate();
                }
            }

            // Шаг 2: Прямой проход через роторы
            int currentSignal = input - 'A';

            for (int i = 0; i < 3; i++)
            {
                currentSignal = rotors[i].Forward(currentSignal);
            }

            // Шаг 3: Проход через рефлектор
            currentSignal = reflector.Reflect(currentSignal);

            // Шаг 4: Обратный проход через роторы
            for (int i = 2; i >= 0; i--)
            {
                currentSignal = rotors[i].Backward(currentSignal);
            }

            return (char)(currentSignal + 'A');
        }

        public void Reset()
        {
            foreach (var rotor in rotors)
            {
                rotor.Reset();
            }
        }
    }

    public class Rotor
    {
        private string wiring;
        private string inverseWiring;
        private int position;
        private int initialPosition;
        private int turnoverPosition;

        public Rotor(string wiring, char initialPosition)
        {
            this.wiring = wiring;
            this.initialPosition = initialPosition - 'A';
            this.position = this.initialPosition;

            // Создание обратной маппинга
            char[] inverse = new char[26];
            for (int i = 0; i < 26; i++)
            {
                int output = wiring[i] - 'A';
                inverse[output] = (char)(i + 'A');
            }
            this.inverseWiring = new string(inverse);

            // Установка точки переворота (обычно на букве Q для большинства роторов)
            this.turnoverPosition = 'Q' - 'A';
        }

        public bool Rotate()
        {
            position = (position + 1) % 26;
            return position == turnoverPosition;
        }

        public int Forward(int input)
        {
            int shiftedInput = (input + position) % 26;
            int output = wiring[shiftedInput] - 'A';
            return (output - position + 26) % 26;
        }

        public int Backward(int input)
        {
            int shiftedInput = (input + position) % 26;
            int output = inverseWiring[shiftedInput] - 'A';
            return (output - position + 26) % 26;
        }

        public void Reset()
        {
            position = initialPosition;
        }

        public void SetPosition(char newPosition)
        {
            position = newPosition - 'A';
        }
    }

    public class Reflector
    {
        private string wiring;

        public Reflector(string wiring)
        {
            this.wiring = wiring;
        }

        public int Reflect(int input)
        {
            return wiring[input] - 'A';
        }
    }
}