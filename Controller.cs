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

        private int money;

        #region Settings
        private const int STARTING_CITIZENS = 3;

        private const int FARMING_GOODS_PRICE = 5;
        private const int FISHING_GOODS_PRICE = 5;
        private const int HARVESTING_GOODS_PRICE = 5;
        private const int MINING_GOODS_PRICE = 5;

        private const int MONEY_TO_WIN = 1000;

        private const int TRADE_POINTS_GOODS_RATIO = 100;
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
                    Console.WriteLine("\nHas Completado el juego!");
                    gameEnded = true;
                    continue;
                }

                GetGoodsEndOfTurn();
            }
        }

        private void PlayerTurn()
        {
            bool turnEnded = false;

            while (!turnEnded) 
            {
                Console.WriteLine("\nSelecciona una opción:");
                Console.WriteLine("1.- Ver civilizacion");
                Console.WriteLine("2.- Ver ciudadanos");
                Console.WriteLine("3.- Ver bienes");
                Console.WriteLine("4.- Vender Bienes");
                Console.WriteLine("5.- Intercambiar Bienes");
                Console.WriteLine("6.- Agregar un ciudadano");
                Console.WriteLine("7.- Importar un ciudadano");
                Console.WriteLine("8.- Cambiar bienes por puntos de habilidad");
                Console.WriteLine("9.- Pasar Turno");

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
                        turnEnded = true;
                        break;
                }
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
            civilization.AddOriginalCitizens(STARTING_CITIZENS);
            Console.WriteLine($"\nComienzas con {STARTING_CITIZENS} Ciudadanos {civilization.originalCitizen.name}s");
        }

        #region PlayerTurnOptions
        private void SeeCivilization()
        {
            Console.WriteLine($"\nEstas jugando con la {civilization.name}:");

            Console.WriteLine($"\nCuentas con {civilization.money} monedas");

            if (civilization.citizens.Count <= 0)
            {
                Console.WriteLine($"\nNo cuentas con ningun ciudadano.");
                return;
            }

            Console.WriteLine($"Estadisticas de la Civilizacion: {civilization.GetFarmingPoints()} Farmeo || {civilization.GetFishingPoints()} Pesca || {civilization.GetHarvestingPoints()} Cosecha || {civilization.GetMiningPoints()} Mineria");          
        }

        private void SeeCitizens()
        {
            if (civilization.citizens.Count <= 0)
            {
                Console.WriteLine($"\nNo cuentas con ningun ciudadano.");
                return;
            }

            Console.WriteLine($"\nCuentas con los siguientes ciudadanos:");

            int index = 0;

            foreach (Citizen citizen in civilization.citizens)
            {
                index++;
                Console.WriteLine($"{index}.- {citizen.name} - {citizen.GetFarmingPoints()} Farmeo || {citizen.GetFishingPoints()} Pesca || {citizen.GetHarvestingPoints()} Cosecha || {citizen.GetMiningPoints()} Mineria");
            }
        }

        private void SeeGoods()
        {
            Console.WriteLine($"\nCuentas con los siguientes bienes:");

            Console.WriteLine($"Carne: {civilization.GetFarmingGoods()} unidades");
            Console.WriteLine($"Pescado: {civilization.GetFishingGoods()} unidades");
            Console.WriteLine($"Cosechas: {civilization.GetHarvestingGoods()} unidades");
            Console.WriteLine($"Minerales: {civilization.GetMiningGoods()} unidades");
        }

        private void SellGoods()
        {
            Console.WriteLine($"\nSelecciona el bien que quieres vender:");

            Console.WriteLine($"1.- Carne");
            Console.WriteLine($"2.- Pescado");
            Console.WriteLine($"3.- Cosechas");
            Console.WriteLine($"4.- Minerales");
            Console.WriteLine($"5.- Volver");

            int option = ChooseNumberOption(5);

            switch (option)
            {
                case 1:
                    TrySellFarmingGoods();
                    break;
                case 2:
                    TrySellFishingGoods();
                    break;
                case 3:
                    TrySellHarvestingGoods();
                    break;
                case 4:
                    TrySellMiningGoods();
                    break;
                case 5:
                    break;
            }
        }
  
        private void TradeGoods()
        {

        }

        private void AddCitizen()
        {
            Citizen originalCitizen = civilization.originalCitizen;

            if(civilization.GetMoney() < originalCitizen.price)
            {
                Console.WriteLine($"\nNo cuentas con suficiente dinero para agregar un ciudadano {originalCitizen.name}");
                Console.WriteLine($"Necesitas {originalCitizen.price} monedas y cuentas con {civilization.GetMoney()}.");
                return;
            }

            Console.WriteLine($"\nDeseas agregar un ciudadano {originalCitizen.name} por {originalCitizen.price} monedas? (Y/N)");

            bool YNoption = ChooseYNOption();

            if (!YNoption) return;

            civilization.ReduceMoney(originalCitizen.price);

            civilization.AddOriginalCitizens(1);

            Console.WriteLine($"\nHas agregar un ciudadano {originalCitizen.name} a tu civilizacion!");
        }

        private void ImportCitizen()
        {
            List<Civilization> allCivilizations = new List<Civilization>();
            List<Civilization> otherCivilizations = new List<Civilization>();

            allCivilizations.Add(new EgiptianCivilization());
            allCivilizations.Add(new GreekCivilization());
            allCivilizations.Add(new IncanCivilization());
            allCivilizations.Add(new MayanCivilization());

            foreach (Civilization civ in allCivilizations)
            {
                if (civ.name != civilization.name) otherCivilizations.Add(civ);
            }

            Console.WriteLine($"\nSelecciona el ciudadano que quieres importar");

            int index = 0;

            foreach (Civilization otherCivilization in otherCivilizations)
            {
                index++;
                Console.WriteLine($"{index}.- {otherCivilization.originalCitizen.name}");
            }

            int option = ChooseNumberOption(index);
            Civilization chosenCivilization = otherCivilizations[option - 1];

            Citizen importedCitizen = chosenCivilization.originalCitizen;

            if (chosenCivilization.GetMoney() < importedCitizen.importPrice)
            {
                Console.WriteLine($"\nNo cuentas con suficiente dinero para importar un ciudadano {importedCitizen.name}");
                Console.WriteLine($"Necesitas {importedCitizen.importPrice} monedas y cuentas con {chosenCivilization.GetMoney()}.");
                return;
            }

            Console.WriteLine($"\nDeseas importar un ciudadano {importedCitizen.name} por {importedCitizen.importPrice} monedas? (Y/N)");

            bool YNoption = ChooseYNOption();

            if (!YNoption) return;

            chosenCivilization.ReduceMoney(importedCitizen.importPrice);

            Citizen newCitizen = chosenCivilization.GetOriginalCitizen();

            civilization.citizens.Add(newCitizen);

            Console.WriteLine($"\nHas importado un ciudadano {importedCitizen.name} a tu civilizacion!");
        }

        private void ExchangeGoodsForPoints()
        {
            Console.WriteLine($"\nSelecciona el bien que quieres intercambiar por puntos:");

            Console.WriteLine($"1.- Carne");
            Console.WriteLine($"2.- Pescado");
            Console.WriteLine($"3.- Cosechas");
            Console.WriteLine($"4.- Minerales");
            Console.WriteLine($"5.- Volver");

            int option = ChooseNumberOption(5);

            switch (option)
            {
                case 1:
                    TryExchangeFarmingPoints();
                    break;
                case 2:
                    TryExchangeFishingPoints();
                    break;
                case 3:
                    TryExchangeHarvestingPoints();
                    break;
                case 4:
                    TryExchangeMiningPoints();
                    break;
                case 5:
                    break;
            }
        }

        private void SkipTurn()
        {

        }

        #endregion

        private void GetGoodsEndOfTurn()
        {
            int farmingGoods = civilization.GetFarmingGoodsEndOfTurn();
            int fishingGoods = civilization.GetFishingGoodsEndOfTurn();
            int harvestingGoods = civilization.GetHarvestingGoodsEndOfTurn();
            int miningGoods = civilization.GetMiningGoodsEndOfTurn();

            civilization.IncreaseFarmingGoods(farmingGoods);
            civilization.IncreaseFishingGoods(fishingGoods);
            civilization.IncreaseHarvestinGoods(harvestingGoods);
            civilization.IncreaseMiningGoods(miningGoods);

            Console.WriteLine("Obtencion de bienes por fin de turno:");
            Console.WriteLine($"Has obtenido {farmingGoods} unidades de carne");
            Console.WriteLine($"Has obtenido {fishingGoods} unidades de pescado");
            Console.WriteLine($"Has obtenido {harvestingGoods} unidades de cosecha");
            Console.WriteLine($"Has obtenido {miningGoods} unidades de mineral");
        }

        #region TrySell
        private void TrySellFarmingGoods()
        {
            if (civilization.GetFarmingGoods() <= 0)
            {
                Console.WriteLine("\nNo tienes ninguna unidad de carne");
                return;
            }

            int quantityToSell = ChooseNumberToSellGood(civilization.GetFarmingGoods(), "carne");
            civilization.ReduceFarmingGoods(quantityToSell);

            int moneyToObtain = quantityToSell * FARMING_GOODS_PRICE;
            civilization.IncreaseMoney(moneyToObtain);

            Console.WriteLine($"\nHas obtenido {moneyToObtain} por {quantityToSell} unidades de carne");
        }

        private void TrySellFishingGoods()
        {
            if (civilization.GetFishingGoods() <= 0)
            {
                Console.WriteLine("\nNo tienes ninguna unidad de pescado");
                return;
            }

            int quantityToSell = ChooseNumberToSellGood(civilization.GetFishingGoods(), "pescado");
            civilization.ReduceFishingGoods(quantityToSell);

            int moneyToObtain = quantityToSell * FISHING_GOODS_PRICE;
            civilization.IncreaseMoney(moneyToObtain);

            Console.WriteLine($"\nHas obtenido {moneyToObtain} por {quantityToSell} unidades de pescado");
        }

        private void TrySellHarvestingGoods()
        {
            if (civilization.GetHarvestingGoods() <= 0)
            {
                Console.WriteLine("\nNo tienes ninguna unidad de cosecha");
                return;
            }

            int quantityToSell = ChooseNumberToSellGood(civilization.GetHarvestingGoods(), "cosecha");
            civilization.ReduceHarvestingGoods(quantityToSell);

            int moneyToObtain = quantityToSell * HARVESTING_GOODS_PRICE;
            civilization.IncreaseMoney(moneyToObtain);

            Console.WriteLine($"\nHas obtenido {moneyToObtain} por {quantityToSell} unidades de cosecha");
        }

        private void TrySellMiningGoods()
        {
            if (civilization.GetMiningGoods() <= 0)
            {
                Console.WriteLine("\nNo tienes ninguna unidad de mineral");
                return;
            }

            int quantityToSell = ChooseNumberToSellGood(civilization.GetMiningGoods(), "mineral");
            civilization.ReduceMiningGoods(quantityToSell);

            int moneyToObtain = quantityToSell * MINING_GOODS_PRICE;
            civilization.IncreaseMoney(moneyToObtain);

            Console.WriteLine($"\nHas obtenido {moneyToObtain} monedas por {quantityToSell} unidades de mineral");
        }
        #endregion

        #region TryExchangePoints
        private void TryExchangeFarmingPoints()
        {
            if (civilization.GetFarmingGoods() < TRADE_POINTS_GOODS_RATIO)
            {
                Console.WriteLine($"\nNo tienes suficientes unidad de carne (Min. {TRADE_POINTS_GOODS_RATIO})");
                return;
            }

            int pointsNumber = ChooseNumberToExchangePoints(civilization.GetFarmingGoods(), "carne", "Farmeo");
            int goodsToExchange = pointsNumber * TRADE_POINTS_GOODS_RATIO;

            civilization.ReduceFarmingGoods(goodsToExchange);
            civilization.IncreaseFarmingPoints(pointsNumber);

            Console.WriteLine($"Has intercambiado {goodsToExchange} unidades de carne por {pointsNumber} Puntos de Farmeo!");
        }

        private void TryExchangeFishingPoints()
        {
            if (civilization.GetFishingGoods() < TRADE_POINTS_GOODS_RATIO)
            {
                Console.WriteLine($"\nNo tienes suficientes unidad de pescado (Min. {TRADE_POINTS_GOODS_RATIO})");
                return;
            }

            int pointsNumber = ChooseNumberToExchangePoints(civilization.GetFishingGoods(), "pescado", "Pesca");
            int goodsToExchange = pointsNumber * TRADE_POINTS_GOODS_RATIO;

            civilization.ReduceFishingGoods(goodsToExchange);
            civilization.IncreaseFishingPoints(pointsNumber);

            Console.WriteLine($"Has intercambiado {goodsToExchange} unidades de pescado por {pointsNumber} Puntos de Pesca!");
        }

        private void TryExchangeHarvestingPoints()
        {
            if (civilization.GetHarvestingGoods() < TRADE_POINTS_GOODS_RATIO)
            {
                Console.WriteLine($"\nNo tienes suficientes unidad de cosecha (Min. {TRADE_POINTS_GOODS_RATIO})");
                return;
            }

            int pointsNumber = ChooseNumberToExchangePoints(civilization.GetHarvestingGoods(), "cosecha", "Cosecha");
            int goodsToExchange = pointsNumber * TRADE_POINTS_GOODS_RATIO;

            civilization.ReduceHarvestingGoods(goodsToExchange);
            civilization.IncreaseHarvestingPoints(pointsNumber);

            Console.WriteLine($"Has intercambiado {goodsToExchange} unidades de cosecha por {pointsNumber} Puntos de Cosecha!");
        }

        private void TryExchangeMiningPoints()
        {
            if (civilization.GetMiningGoods() < TRADE_POINTS_GOODS_RATIO)
            {
                Console.WriteLine($"\nNo tienes suficientes unidad de mineral (Min. {TRADE_POINTS_GOODS_RATIO})");
                return;
            }

            int pointsNumber = ChooseNumberToExchangePoints(civilization.GetMiningGoods(), "mineral", "Mineria");
            int goodsToExchange = pointsNumber * TRADE_POINTS_GOODS_RATIO;

            civilization.ReduceMiningGoods(goodsToExchange);
            civilization.IncreaseMiningPoints(pointsNumber);

            Console.WriteLine($"Has intercambiado {goodsToExchange} unidades de mineral por {pointsNumber} Puntos de Mineria!");
        }

        #endregion


        #region Checks
        private bool CheckPlayerWin()
        {
            if(civilization.GetMoney() >= MONEY_TO_WIN)
            {
                Console.WriteLine($"\nHas conseguido mas de {MONEY_TO_WIN} monedas!");
                return true;
            }

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

        private int ChooseNumberToSellGood(int maxNumber, string good)
        {
            bool validNumber = false;
            int number = 0;

            Console.WriteLine($"\nInserta la cantidad de unidades de {good} a vender (Max. {maxNumber})");

            while (!validNumber)
            {
                try
                {
                    int desiredNumber = int.Parse(Console.ReadLine());

                    if (desiredNumber > 0 && desiredNumber <= maxNumber)
                    {
                        validNumber = true;
                        number = desiredNumber;
                    }
                    else if(desiredNumber > maxNumber)
                    {
                        Console.WriteLine($"No tienes suficientes unidades de {good}, inserta una cantidad menor.");
                    }
                    else
                    {
                        Console.WriteLine($"Inserta una cantidad positiva");
                    }
                }
                catch
                {
                    Console.WriteLine($"Inserta un número");
                }
            }

            return number;
        }

        private int ChooseNumberToExchangePoints(int goodsNumber, string good, string point)
        {
            int maxNumber = goodsNumber / TRADE_POINTS_GOODS_RATIO;
            bool validNumber = false;
            int number = 0;

            Console.WriteLine($"\nPuedes intercambiar desde {TRADE_POINTS_GOODS_RATIO} de unidades de {good} a por 1 punto de {point}");

            Console.WriteLine($"\nInserta la cantidad de puntos de {point} que deseas obtener (Max. {maxNumber})");

            while (!validNumber)
            {
                try
                {
                    int desiredNumber = int.Parse(Console.ReadLine());

                    if (desiredNumber > 0 && desiredNumber <= maxNumber)
                    {
                        validNumber = true;
                        number = desiredNumber;
                    }
                    else if (desiredNumber > maxNumber)
                    {
                        Console.WriteLine($"No tienes suficientes unidades de {good}, inserta una de puntos menor.");
                    }
                    else
                    {
                        Console.WriteLine($"Inserta una cantidad positiva");
                    }
                }
                catch
                {
                    Console.WriteLine($"Inserta un número");
                }
            }

            return number;
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
