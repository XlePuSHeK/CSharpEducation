using System;

namespace TicTacToe
{
	class Game
	{
		private static char[] positions = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
		//By default player 1 is set
		private static int player = 1;

		private static int choicePosition;

		private static bool? isWon = null;

		/// <summary>
		/// Отрисовать доску для игры.
		/// </summary>
		private static void DrawBoard()
		{
			Console.WriteLine("     |      |      ");
			DrawPlate(1);
			DrawPlate(2);
			DrawPlate(3);
			Console.WriteLine();
			Console.WriteLine("_____|______|______ ");
			Console.WriteLine("     |      |      ");
			DrawPlate(4);
			DrawPlate(5);
			DrawPlate(6);
			Console.WriteLine();
			Console.WriteLine("_____|______|______ ");
			Console.WriteLine("     |      |      ");
			DrawPlate(7);
			DrawPlate(8);
			DrawPlate(9);
			Console.WriteLine();
			Console.WriteLine("     |      |      ");
		}
		/// <summary>
		/// Отрисовать плитку на доске.
		/// </summary>
		/// <param name="position">Поизиция на поле.</param>
		private static void DrawPlate(int position)
		{
			ColorPlate(position);
			Console.Write("  {0} ", positions[position]);
			Console.ResetColor();
			Console.Write(" | ");
		}

		/// <summary>
		/// Окрасить плитку в красный, если там крестик, если нолик в синий.
		/// </summary>
		/// <param name="position">Позиция на поле.</param>
		private static void ColorPlate(int position)
		{
			if (positions[position] == 'X') Console.ForegroundColor = ConsoleColor.Red;
			else if (positions[position] == 'O') Console.ForegroundColor = ConsoleColor.Blue;
		}

		/// <summary>
		/// Вывести в консоль какой игрок ходит.
		/// </summary>
		private static void WriteWhosePlayerMove()
		{
			if (player % 2 == 0)
				Console.WriteLine("Player 2 Chance");
			else
				Console.WriteLine("Player 1 Chance");
		}
		/// <summary>
		/// Проверить победные комбинации.
		/// </summary>
		/// <returns>Если нашлась победная комбинация - true, если ничья - false, иначе null.</returns>
		private static bool? CheckWin()
		{
			//Winning Condition For First Row
			if (positions[1] == positions[2] && positions[2] == positions[3])
				return true;
			//Winning Condition For Second Row
			else if (positions[4] == positions[5] && positions[5] == positions[6])
				return true;
			//Winning Condition For Third Row
			else if (positions[7] == positions[8] && positions[8] == positions[9])
				return true;
			//Winning Condition For First Column
			else if (positions[1] == positions[4] && positions[4] == positions[7])
				return true;
			//Winning Condition For Second Column
			else if (positions[2] == positions[5] && positions[5] == positions[8])
				return true;
			//Winning Condition For Third Column
			else if (positions[3] == positions[6] && positions[6] == positions[9])
				return true;
			else if (positions[1] == positions[5] && positions[5] == positions[9])
				return true;
			else if (positions[3] == positions[5] && positions[5] == positions[7])
				return true;
			// If all the cells or values filled with X or O then any player has won the match
			else if (positions[1] != '1' && positions[2] != '2' && positions[3] != '3' && positions[4] != '4' &&
							 positions[5] != '5' && positions[6] != '6' && positions[7] != '7' && positions[8] != '8' && positions[9] != '9')
				return false;
			else
				return null;
		}

		/// <summary>
		/// Заполнить выбранную позицию крестиком или ноликом, при условии, что поле еще не заполнено, иначе выдать ошибку.
		/// </summary>
		private static void FillSelectedPosition()
		{
			if (choicePosition > 0 && choicePosition < 10)
			{
				if (positions[choicePosition] != 'X' && positions[choicePosition] != 'O')
				{
					if (player % 2 == 0)
						positions[choicePosition] = 'O';
					else
						positions[choicePosition] = 'X';

					player++;
				}
				else
				{
					GetError(string.Format("Sorry the row {0} is already marked with {1}", choicePosition, positions[choicePosition]));
				}
				isWon = CheckWin();
			}
			else
			{
				GetError(string.Format("Sorry the row {0} is not corrected", choicePosition));
			}

		}

		/// <summary>
		/// Получить ошибку о неверном ходе.
		/// </summary>
		/// <param name="warning">Строка ошибки.</param>
		private static void GetError(string warning)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(warning);
			Console.WriteLine("\n");
			Console.WriteLine("Please wait 1 second board is loading and try again ....");
			Thread.Sleep(1000);
			Console.ResetColor();
		}

		/// <summary>
		/// Вывести в консоль, победившего игрока если нашлась победная комбинация, иначе вывести "Ничья".
		/// </summary>
		private static void WriteWhoPlayerHasWon()
		{
			if (isWon.HasValue && isWon.Value)
			{
			  Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("Player {0} has won", (player % 2) + 1);
				Console.ResetColor();
			}
			else
				Console.WriteLine("Draw");
			Console.ReadLine();
		}

		static void Main(string[] args)
		{
			do
			{
				//Очищаем консоль, чтобы не мусорить.
				Console.Clear();
				Console.WriteLine("Player1: X and Player2: O");
				Console.WriteLine("\n");
				WriteWhosePlayerMove();
				Console.WriteLine("\n");
				DrawBoard();
				choicePosition = int.Parse(Console.ReadLine());
				FillSelectedPosition();
			} while (!isWon.HasValue);
			Console.Clear();
			DrawBoard();
			WriteWhoPlayerHasWon();
		}
	}
}