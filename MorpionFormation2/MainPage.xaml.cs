using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MorpionFormation2
{
	public partial class MainPage : ContentPage
	{
		private Button[] boutons = new Button[9];
		private MoteurMorpion _jeu = new MoteurMorpion();

		public MainPage()
		{
			InitializeComponent();
			boutons[0] = btn1;
			boutons[1] = btn2;
			boutons[2] = btn3;
			boutons[3] = btn4;
			boutons[4] = btn5;
			boutons[5] = btn6;
			boutons[6] = btn7;
			boutons[7] = btn8;
			boutons[8] = btn9;
		}

		private void btn1_Clicked(object sender, EventArgs e)
		{
			_jeu.SetButton((Button)sender);
			if (_jeu.CheckWinner(boutons))
			{
				lblEtatPartie.Text = string.Format("{0} a gagné la partie",
					_jeu.PlayerTurn == 1 ? "Joueur 1" : "Joueur 2");
			}
		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			_jeu.ResetGame(boutons);
			lblEtatPartie.Text = "";
		}
	}
}
