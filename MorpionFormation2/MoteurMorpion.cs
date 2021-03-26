using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MorpionFormation2
{
	public class MoteurMorpion
	{
		private int _playerTurn;
		public int PlayerTurn{get =>  _playerTurn ; set { _playerTurn = value; } }

		private int[,] _winners = new int[,]
		{
			{0,1,2 },
			{3,4,5 },
			{6,7,8 },
			{0,3,6 },
			{1,4,7 },
			{2,5,8 },
			{0,4,8 },
			{2,4,6 }
		};

		public bool CheckWinner(Button[] buttons)
		{
			bool gameOver = false;
			for (int i = 0; i < 8; i++)
			{
				int a = _winners[i, 0];
				int b = _winners[i, 1];
				int c = _winners[i, 2];

				Button b1 = buttons[a];
				Button b2 = buttons[b];
				Button b3 = buttons[c];

				if (b1.Text == "" || b2.Text == "" || b3.Text == "")
					continue;

				if (b1.Text == b2.Text && b2.Text == b3.Text)
				{
					b1.BackgroundColor = Color.Red;
					b2.BackgroundColor = Color.Red;
					b3.BackgroundColor = Color.Red;
					gameOver = true;
					break;
				}
			}

			bool isTie = true;
			if (!gameOver)
			{
				foreach (Button b in buttons)
				{
					if (b.Text == "")
					{
						isTie = false;
						break;
					}
				}
				if (isTie)
					gameOver = true;
			}
				return gameOver;		
		}

		public void SetButton(Button b)
		{
			if (b.Text == "")
			{
				b.Text = PlayerTurn == 1 ? "X" : "O";
				/*if (PlayerTurn == 1)
					b.Text = "X";
				else
					b.Text = "O";*/

				PlayerTurn = PlayerTurn == 1 ? 2 : 1;
				/*if (PlayerTurn == 1)
					PlayerTurn = 2;
				else
					PlayerTurn = 1;*/
			}
		}

		public void ResetGame(Button[] buttons)
		{
			PlayerTurn = 1;
			foreach (Button b in buttons)
			{
				b.Text = "";
				b.BackgroundColor = Color.Blue;
			}
		}
	}
}
