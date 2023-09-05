using System.Text;
using System;
using System.Diagnostics.Metrics;

namespace Wassermelone
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Es ist Sommer und sehr warm. Sie befinden sich im Großraum München und sollen ein Programm
            //für einen Wassermelonenverkäufer schreiben.

            //1
            //Es sollen die Rechnungen automatisiert werden.
            //Sie müssen also den Preis pro Melone und die Anzahl der Bestellmenge eintragen können.
            //Am Ende soll der Betrag, den der Kunde zahlen muss, ausgegeben werden. 
            //Ab einen Bestellwert von mindestens 5 Melonen soll es 5 % Rabatt geben.
            //Ab 10 Melonen 10 %.

            //2
            //Variieren Sie das Programm: an Dienstagen gibt es Sonderrabatte: 7 % und 12 %.
            //Hinweis:
            //Deklarieren Sie dazu ein DateTime - Objekt und weisen Sie ihm den Wert des aktuellen Datums zu:
            //DateTime dt = DateTime.Now;
            //            Das Framework stellt einen besonderen Aufzähltungstyp namens DayOfWeek bereit(sogenannte
            //            Enumerationen werden später noch genauer behandelt).
            //            Z.B.Gibt es DayOfWeek.Tuesday, um den Dienstag zu repräsentieren.
            //            DateTime - Objekte verfügen nun unter anderem über diese Eigenschaft, so dass sie mittels
            //dt.DayOfWeek abfragen können, um welchen Tag es sich handelt.

            //3
            //Simulieren Sie eine Quittung: Also Preis, Bestellmenge, Datum, Mehrwertsteuer usw.
            //Erzeugen Sie ein ansprechendes Ausgabeformat

            // Without this you will never see €€€€€€ xD
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Title Wassermelone Rechnung
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\r\n╦ ╦╔═╗╔═╗╔═╗╔═╗╦═╗╔╦╗╔═╗╦  ╔═╗╔╗╔╔═╗  ╦═╗╔═╗╔═╗╦ ╦╔╗╔╦ ╦╔╗╔╔═╗\r\n║║║╠═╣╚═╗╚═╗║╣ ╠╦╝║║║║╣ ║  ║ ║║║║║╣   ╠╦╝║╣ ║  ╠═╣║║║║ ║║║║║ ╦\r\n╚╩╝╩ ╩╚═╝╚═╝╚═╝╩╚═╩ ╩╚═╝╩═╝╚═╝╝╚╝╚═╝  ╩╚═╚═╝╚═╝╩ ╩╝╚╝╚═╝╝╚╝╚═╝\r\n");

            // Variables
            double wassermelonePreis;
            int wassermeloneAnzahl;
            double berechnungAnzahlPreis;
            double einProzentBerechnungAnzahlPreis;
            double feunfProzentBerechnungAnzahlPreis;
            double zehnProzentBerechnungAnzahlPreis;
            double siebenProzentBerechnungAnzahlPreis;
            double zweolfPrezentBerechnungAnzahlPreis;
            double kundeBetrag;
            DateTime dt = DateTime.Now;
            bool check;

            bool feunfProzentRabatt = false;
            bool zehnProzentRabatt = false;
            bool dienstag = false;

            // Loop input and check for the price and number
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("\nWie viel € kostet eine Wassermelone?\t");
                check = double.TryParse(Console.ReadLine(), out wassermelonePreis);

                if (check == false)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nNur Ziffern!");
                }
            } while (check == false);
            Console.Clear();
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("\nWie viele Wassermelonen möchte der Kunde kaufen?\t");
                check = int.TryParse(Console.ReadLine(), out wassermeloneAnzahl);

                if (check == false)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nNur Ziffern!");
                }
            } while (check == false);
            Console.Clear();

            // Calculations for the % discounts of the sum the client must pay
            berechnungAnzahlPreis = wassermelonePreis * wassermeloneAnzahl;

            einProzentBerechnungAnzahlPreis = berechnungAnzahlPreis / 100;

            feunfProzentBerechnungAnzahlPreis = einProzentBerechnungAnzahlPreis * 5;
            zehnProzentBerechnungAnzahlPreis = einProzentBerechnungAnzahlPreis * 10;
            siebenProzentBerechnungAnzahlPreis = einProzentBerechnungAnzahlPreis * 7;
            zweolfPrezentBerechnungAnzahlPreis = einProzentBerechnungAnzahlPreis * 12;

            // Verifications for the discounts, and calculation of the price for the client
            if (wassermeloneAnzahl >= 5 && wassermeloneAnzahl < 10) 
            {
                feunfProzentRabatt = true;
            }
            else if (wassermeloneAnzahl >= 10)
            {
                zehnProzentRabatt = true;
            }

            if (dt.DayOfWeek == DayOfWeek.Tuesday)
            {
                dienstag = true;
            }

            string mengerabatt;
            string dienstagrabatt;
            string gesamtrabatt;

            // Calculations with the discounts for the price of the client
            if (feunfProzentRabatt == true && dienstag == true)
            {
                kundeBetrag = berechnungAnzahlPreis - siebenProzentBerechnungAnzahlPreis;
                mengerabatt = "ja";
                dienstagrabatt = "ja";
                gesamtrabatt = "7%";
            }
            else if (zehnProzentRabatt == true && dienstag == true)
            {
                kundeBetrag = berechnungAnzahlPreis - zweolfPrezentBerechnungAnzahlPreis;
                mengerabatt = "ja";
                dienstagrabatt = "ja";
                gesamtrabatt = "12%";
            }
            else if (feunfProzentRabatt == true && dienstag == false)
            {
                kundeBetrag = berechnungAnzahlPreis - feunfProzentBerechnungAnzahlPreis;
                mengerabatt = "ja";
                dienstagrabatt = "ja";
                gesamtrabatt = "5%";
            }
            else if (zehnProzentRabatt == true && dienstag == false)
            {
                kundeBetrag = berechnungAnzahlPreis - zehnProzentBerechnungAnzahlPreis;
                mengerabatt = "ja";
                dienstagrabatt = "ja";
                gesamtrabatt = "10%";
            }
            else
            {
                kundeBetrag = berechnungAnzahlPreis;
                mengerabatt = "nein";
                dienstagrabatt = "nein";
                gesamtrabatt = "0%";
            }

                Console.WriteLine($"Der Kunde muss {kundeBetrag}€ für die {wassermeloneAnzahl} Wassermelone(n) bezahlen.");

            // Receipt output
            Console.WriteLine("\nDrücken Sie ENTER, um die Quittung anzuzeigen.");
            Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("\r\n   ___   __ __ __ ______ ______ __ __ __  __   ___ \r\n  // \\\\  || || || | || | | || | || || ||\\ ||  // \\\\\r\n ((   )) || || ||   ||     ||   || || ||\\\\|| (( ___\r\n  \\\\_/X| \\\\_// ||   ||     ||   \\\\_// || \\||  \\\\_||\r\n                                                   \r\n");
            Console.WriteLine($"\n\nProdukt: Wassermelone\t\tBestellmenge: {wassermeloneAnzahl}\t\tDatum: {DateTime.Now} {dt.DayOfWeek}");
            Console.WriteLine($"\nBrutto Stückpreis: {wassermelonePreis}€\t\tNetto Gesamtpreis: {berechnungAnzahlPreis - zehnProzentBerechnungAnzahlPreis}€\t\tMehrwertsteuer Gesamtpreis: {zehnProzentBerechnungAnzahlPreis}€");
            Console.WriteLine($"\nMengerabatt: {mengerabatt}\t\t\tDienstagrabatt:{dienstagrabatt}\t\tGesamtrabatt:{gesamtrabatt}");
            Console.WriteLine($"\n\n\t\t\t\t\t\t\t\t\t\t\tEndepreis:{kundeBetrag}€");
            Console.WriteLine("\n\n\n\t\t\t\t\t\t\t\tPlease visit us again in the future! :)\n\n\n\n\n\n");
        }
    }
}