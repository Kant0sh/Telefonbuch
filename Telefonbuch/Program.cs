using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Telefonbuch
{
    class Program
    {
        static void Main(string[] args)
        {
            Telefonbuch();
        }

        public static void Telefonbuch() {

            // Legt fest in welcher datei alles gespeichert wird
            string Filename = @"C:\telefonbuch.txt";

            // Fragt ab ob der nutzer etwas auslesen oder eingeben will
            Console.WriteLine("(L)esen oder (S)chreiben?");
            string c = Console.ReadLine();

            if (c == "S" || c == "s")
            {

                // S --> Eingabe
                Console.WriteLine("Hi! Wie ist dein Name?");
                // speichert den Namen in Name
                string Name = Console.ReadLine();
                Console.WriteLine("Und wie ist deine Telefonnummer?");
                // speichert die Nummer in Nummer
                string Nummer = Console.ReadLine();

                // ruft die Speichermethode auf und übergibt den Dateipfad und Namen und Nummer durch Zeilenumbrüche getrennt
                WriteToFile(Filename, Name + "\r\n" + Nummer + "\r\n");

            }
            else if (c == "L" || c == "l")
            {

                // L --> Auslesen
                Console.WriteLine("Wessen Telefonnummer brauchst du?");
                // speichert Namen in Name
                String Name = Console.ReadLine();
                // Gibt direkt die Nummer aus, die mit ReadFromFile() ermittelt wurde
                Console.WriteLine("Nummer: " + ReadFromFile(Filename, Name));
                Console.ReadKey();
            }
            else
            {

                // kein L oder S --> NIX Passiert
                Console.WriteLine("NOPE!");
                Console.ReadKey();
            }

        }

        static void WriteToFile(string Filename, string Text)
        {
            // packt einfach den Text den es kriegt an die datei hinten dran
            File.AppendAllText(Filename, Text);
        }

        static string ReadFromFile(string Filename, string Name)
        {

            // holt den string[] der Zeilen und speichert ihn in Zeilen
            string[] Zeilen = File.ReadAllLines(Filename);
            // geht die Zeilen durch und sucht in ihnen den gesuchten namen
            for (int i = 0; i < Zeilen.Length; i++)
            {
                if (Zeilen[i].ToLower().Equals(Name.ToLower()))
                {
                    // wenn name gefunden, nummer aus der zeile danacu zurückgeben
                    return Zeilen[i + 1];
                }
            }

            // wenn nichts gefunden, nichts zurückgeben
            return "Gibt es nicht!";
            Telefonbuch();

        }

    }
}
