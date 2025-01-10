using System;
using System.Collections.Generic;
using System.Linq;

public class MontyHall
{
    // Enum für die Tore
    public enum Door
    {
        Door1 = 1,
        Door2 = 2,
        Door3 = 3
    }

    private static readonly Random _random = new Random();

    // Hilfsmethode zum Simulieren eines einzelnen Spiels
    private static (bool, bool) SimulateGame()
    {
        // Zuweisung des Autors und der Ziegen
        var doorsWithPrize = new Dictionary<Door, bool>
        {
            { Door.Door1, false },
            { Door.Door2, false },
            { Door.Door3, false }
        };
        var winningDoor = (Door)_random.Next(1, 4); // Zufällige Zahl zwischen 1 und 3
        doorsWithPrize[winningDoor] = true;

        // Spieler wählt ein Tor
        var playerGuess = (Door)_random.Next(1, 4);

        // Monty öffnet ein Tor mit einer Ziege
        var remainingDoors = doorsWithPrize.Keys.ToList();
        remainingDoors.Remove(playerGuess); // Entfernt die Wahl des Spielers
        var losingDoor = remainingDoors.First(door => !doorsWithPrize[door]);

        // Der Spieler hat die Möglichkeit zu wechseln
        remainingDoors.Remove(losingDoor);
        var switchedGuess = remainingDoors.First();

        // Prüfen, ob der Spieler gewinnt, wenn er bei seiner Wahl bleibt
        var winSticking = doorsWithPrize[playerGuess];
        // Prüfen, ob der Spieler gewinnt, wenn er wechselt
        var winChanging = doorsWithPrize[switchedGuess];

        return (winSticking, winChanging);
    }

    // Hauptmethode zum Spielen einer Anzahl von Spielen
    public static void Play(int times)
    {
        if (times < 1)
        {
            throw new ArgumentException("Die Anzahl der Spiele muss größer als 0 sein.");
        }

        var wonSticking = 0;
        var wonChanging = 0;

        // Simulation der Spiele
        for (var i = 0; i < times; i++)
        {
            var (winSticking, winChanging) = SimulateGame();
            if (winSticking) wonSticking++;
            if (winChanging) wonChanging++;
        }

        // Statistik ausgeben
        Console.WriteLine($"Spiele gespielt: {times}");
        Console.WriteLine($"Gewonnen durch Beibehalten der Wahl: {wonSticking} ({(wonSticking / (float)times * 100):0.00}%)");
        Console.WriteLine($"Gewonnen durch Wechseln der Wahl: {wonChanging} ({(wonChanging / (float)times * 100):0.00}%)");
    }

    public static void Main(string[] args)
    {
        // Beispiel-Aufruf der Simulation
        Play(10000);
    }
}
