using System;

namespace TicTacToe
{
	class Game
	{
		private static char[] Positions = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

		//By default player 1 is set
		private static int Player = 1;

		private static int ChoicePosition;

		private static bool? IsWon = null;
		private static void Board()
		{
			Console.WriteLine("     |      |      ");
			ChacngeColorPlate(1);
			ChacngeColorPlate(2);
			ChacngeColorPlate(3);
			Console.WriteLine();
			Console.WriteLine("_____|______|______ ");
			Console.WriteLine("     |      |      ");
			ChacngeColorPlate(4);
			ChacngeColorPlate(5);
			ChacngeColorPlate(6);
			Console.WriteLine();
			Console.WriteLine("_____|______|______ ");
			Console.WriteLine("     |      |      ");
			ChacngeColorPlate(7);
			ChacngeColorPlate(8);
			ChacngeColorPlate(9);
			Console.WriteLine();
			Console.WriteLine("     |      |      ");
		}

		private static void ChacngeColorPlate(int i)
		{
			if (Positions[i] == 'X') Console.ForegroundColor = ConsoleColor.Red;
			else if (Positions[i] == 'O') Console.ForegroundColor = ConsoleColor.Blue;
			Console.Write("  {0} ", Positions[i]);
			Console.ResetColor();
			Console.Write(" | ");
		}
		private static void CheckingChanceofThePlayer()
		{
			if (Player % 2 == 0)
				Console.WriteLine("Player 2 Chance");
			else
				Console.WriteLine("Player 1 Chance");
		}

		private static bool? CheckWin()
		{
			//Winning Condition For First Row
			if (Positions[1] == Positions[2] && Positions[2] == Positions[3])
				return true;
			//Winning Condition For Second Row
			else if (Positions[4] == Positions[5] && Positions[5] == Positions[6])
				return true;
			//Winning Condition For Third Row
			else if (Positions[6] == Positions[7] && Positions[7] == Positions[8])
				return true;
			//Winning Condition For First Column
			else if (Positions[1] == Positions[4] && Positions[4] == Positions[7])
				return true;
			//Winning Condition For Second Column
			else if (Positions[2] == Positions[5] && Positions[5] == Positions[8])
				return true;
			//Winning Condition For Third Column
			else if (Positions[3] == Positions[6] && Positions[6] == Positions[9])
				return true;
			else if (Positions[1] == Positions[5] && Positions[5] == Positions[9])
				return true;
			else if (Positions[3] == Positions[5] && Positions[5] == Positions[7])
				return true;
			// If all the cells or values filled with X or O then any player has won the match
			else if (Positions[1] != '1' && Positions[2] != '2' && Positions[3] != '3' && Positions[4] != '4' &&
							 Positions[5] != '5' && Positions[6] != '6' && Positions[7] != '7' && Positions[8] != '8' && Positions[9] != '9')
				return false;
			else
				return null;
		}

		/// <summary>
		/// Checking position of choice player 
		/// </summary>
		private static void CheckingPositionOfChoice()
		{
			if (ChoicePosition > 0 && ChoicePosition < 10)
			{
				if (Positions[ChoicePosition] != 'X' && Positions[ChoicePosition] != 'O')
				{
					if (Player % 2 == 0) //if chance is of player 2 then mark O else mark X
						Positions[ChoicePosition] = 'O';
					else
						Positions[ChoicePosition] = 'X';

					Player++;
				}
				else
				//If there is any possition where user want to run
				//and that is already marked then show message and load board again
				{
					GetError(string.Format("Sorry the row {0} is already marked with {1}", ChoicePosition, Positions[ChoicePosition]));
				}
				IsWon = CheckWin();
			}
			else
			{
				GetError(string.Format("Sorry the row {0} is not corrected", ChoicePosition));
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

		private static void WriteWhoPlayerHasWon()
		{
			if (IsWon.HasValue && IsWon.Value)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("Player {0} has won", (Player % 2) + 1);
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
				Console.Clear();// whenever loop will be again start then screen will be clear
				Console.WriteLine("Player1: X and Player2: O");
				Console.WriteLine("\n");
				CheckingChanceofThePlayer();
				Console.WriteLine("\n");
				Board();// calling the board Function
				ChoicePosition = int.Parse(Console.ReadLine());//Taking users choice
				CheckingPositionOfChoice();
			} while (!IsWon.HasValue);
			Console.Clear();
			Board();// getting filled board again
			WriteWhoPlayerHasWon();
		}
	}
}