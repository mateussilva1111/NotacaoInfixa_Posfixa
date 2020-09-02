using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace teste2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string campo;
            campo = textBox1.Text;

			MessageBox.Show(infixToPostfix(campo));
        }


		internal static int Prec(char ch)
		{
			switch (ch)
			{
				case '+':
				case '-':
					return 1;

				case '*':
				case '/':
					return 2;

				case '^':
					return 3;
			}
			return -1;
		}

		public static string infixToPostfix(string exp)
		{
			// inicializando String vazia para resultado
			string result = "";

			// inicializando pilha vazia
			Stack<char> stack = new Stack<char>();

			for (int i = 0; i < exp.Length; ++i)
			{
				char c = exp[i];

				// Se o caractere digitalizado for um operando, adicione-o à saída.
				if (char.IsLetterOrDigit(c))
				{
					result += c;
				}

				// Se o caractere digitalizado for um '(', empurre-o para a pilha.
				else if (c == '(')
				{
					stack.Push(c);
				}


				// Se o caractere digitalizado for um ')', pop e saída da pilha
				// até que um '(' seja encontrado.
				else if (c == ')')
				{
					while (stack.Count > 0 && stack.Peek() != '(')
					{
						result += stack.Pop();
					}

					if (stack.Count > 0 && stack.Peek() != '(')
					{
						return "Invalid Expression"; // expressão inválida 
					}
					else
					{
						stack.Pop();
					}
				}
				else // um operador é encontrado 
				{
					while (stack.Count > 0 && Prec(c) <= Prec(stack.Peek()))
					{
						result += stack.Pop();
					}
					stack.Push(c);
				}

			}

			// pop todos operadores da pilha 
			while (stack.Count > 0)
			{
				result += stack.Pop();
			}

			return result;
		}

	

		

	

		
	}
}
