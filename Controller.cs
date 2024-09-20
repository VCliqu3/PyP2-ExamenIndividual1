using PyP2_ExamenIndividual1.Civilizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PyP2_ExamenIndividual1
{
    public class Controller
    {
        private Civilization civilization;
        private List<Citizen> citizens = new List<Citizen>();

        private int money;

        #region Settings
        private const int STARTING_CITIZENS = 3;
        #endregion

        public void Execute() 
        {
            Console.WriteLine("CIVILIZATION GAME");

            ChooseCivilization();
            AddStartingCitizens();

            bool gameEnded = false;

            while (!gameEnded)
            {
                PlayerTurn();

                if (CheckPlayerWin())
                {
                    gameEnded = true;
                }
            }
        }

        private void PlayerTurn()
        {
            Console.WriteLine("\nSelecciona una opción:");
            Console.WriteLine("1.- Ver civilizacion");
            Console.WriteLine("2.- Ver ciudadanos");
            Console.WriteLine("3.- Ver bienes");
            Console.WriteLine("4.- Vender Bienes");
            Console.WriteLine("5.- Intercambiar Bienes");
            Console.WriteLine("6.- Agregar un ciudadano");
            Console.WriteLine("7.- Cambiar bienes por puntos de habilidad");
            Console.WriteLine("8.- Pasar Turno");

            int option = ChooseNumberOption(9);

            switch (option)
            {
                case 1:
                    SeeCivilization();
                    break;
                case 2:
                    SeeCitizens();
                    break;
                case 3:
                    SeeGoods();
                    break;
                case 4:
                    SellGoods();
                    break;
                case 5:
                    TradeGoods();
                    break;
                case 6:
                    AddCitizen();
                    break;
                case 7:
                    ImportCitizen();
                    break;
                case 8:
                    ExchangeGoodsForPoints();
                    break;
                case 9:
                default:
                    SkipTurn();
                    break;
            }
        }

        private void ChooseCivilization()
        {
            Console.WriteLine("\nEscoge tu civilizacion:");
            Console.WriteLine("1.- Egipcios");
            Console.WriteLine("2.- Griegos");
            Console.WriteLine("3.- Incas");
            Console.WriteLine("4.- Mayas");

            int option = ChooseNumberOption(4);

            switch (option)
            {
                case 1:
                    civilization = new EgiptianCivilization();
                    break;
                case 2:
                    civilization = new GreekCivilization();
                    break;
                case 3:
                default:
                    civilization = new IncanCivilization();
                    break;
                case 4:
                    civilization = new MayanCivilization();
                    break;
            }

            Console.WriteLine($"\nHas escogido la {civilization.name}!");
        }

        private void AddStartingCitizens()
        {
            for(int i = 0; i < STARTING_CITIZENS; i++)
            {
                Citizen citizen = civilization.GetOriginalCitizen();
                civilization.citizens.Add(citizen);
            }

            Console.WriteLine($"\nComienzas con {STARTING_CITIZENS} Ciudadanos {civilization.originalCitizen.name}s");
        }

        private void SeeCivilization()
        {

        }

        private void SeeCitizens()
        {

        }

        private void SeeGoods()
        {

        }

        private void SellGoods()
        {

        }

        private void TradeGoods()
        {

        }

        private void AddCitizen()
        {

        }

        private void ImportCitizen()
        {

        }

        private void ExchangeGoodsForPoints()
        {

        }

        private void SkipTurn()
        {

        }

        #region Checks
        private bool CheckPlayerWin()
        {
            return false;
        }
        #endregion

        #region OptionHandlers
        private int ChooseNumberOption(int maxOptionNumber)
        {
            bool validOption = false;
            int option = 0;

            while (!validOption)
            {
                try
                {
                    int desiredOption = int.Parse(Console.ReadLine());

                    if (desiredOption > 0 && desiredOption <= maxOptionNumber)
                    {
                        validOption = true;
                        option = desiredOption;
                    }
                    else
                    {
                        Console.WriteLine($"Selecciona una opcion válida:");
                    }
                }
                catch
                {
                    Console.WriteLine($"Selecciona una opcion válida:");
                }
            }

            return option;
        }
        private bool ChooseYNOption()
        {
            Console.WriteLine("(Y/N):");

            bool desiredOption = false;
            bool validYN = false;

            while (!validYN)
            {
                string answer = Console.ReadLine();

                switch (answer)
                {
                    case "Y":
                    case "y":
                        validYN = true;
                        desiredOption = true;
                        break;
                    case "N":
                    case "n":
                        validYN = true;
                        desiredOption = false;
                        break;
                    default:
                        Console.WriteLine("\nEscoge una opción válida:");
                        break;
                }
            }

            return desiredOption;
        }
        #endregion
    }
}
