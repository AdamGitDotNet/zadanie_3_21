using System;

namespace zadania
{
    class Program
    {
        static void Main(string[] args)
        {

            string imie = string.Empty;
            string miejscowosc = string.Empty;
            Int16 rok = 0;
            Int16 miesiac = 0;
            byte dzien = 0;
            int iloscLat = 0;
            DateTime dataUrodzenia;


            imie = DaneDoPobraniaString("Podaj imie", 3);
            miejscowosc = DaneDoPobraniaString("Podaj miejscowość urodzenia", 3);
            rok = PobierzRokUrodzeniaOdUzytkownika("Podaj rok urodzenia (4 cyfry)");
            miesiac = PobierzMiesiacUrodzeniaOdUzytkownika("Podaj miesiąc urodzenia");
            dzien = PobierzDzienUrodzeniaOdUzytkownika("Podaj dzień urodzenia", rok, miesiac);


            dataUrodzenia = DateTime.Parse($"{rok}-{miesiac}-{dzien}");

            //  dataUrodzenia = new DateTime(rok,miesiac,dzien);

            iloscLat = DateTime.Now.Year - dataUrodzenia.Year;
            if (DateTime.Now.DayOfYear < dataUrodzenia.DayOfYear)
                iloscLat--;

            Console.WriteLine($"Witaj {imie} urodziłeś(aś) się w  {miejscowosc} i masz {iloscLat} lat.");

            Console.ReadLine();

        }


        private static string DaneDoPobraniaString(string komunikat, byte dlugoscCiagu)
        {
            string zmienna = string.Empty;
            try
            {
                do
                {
                    Console.WriteLine(komunikat);
                    zmienna = Console.ReadLine();
                }

                while (string.IsNullOrWhiteSpace(zmienna) || zmienna.Length < dlugoscCiagu);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return zmienna;
        }


        private static Int16 PobierzRokUrodzeniaOdUzytkownika(string komunikat)
        {
            bool zmienna = false;
            Int16 rokUrodzenia = 0;
            try
            {
                Console.WriteLine(komunikat);
                do
                {
                    zmienna = Int16.TryParse(Console.ReadLine(), out Int16 wynik);
                    if (wynik > 1900 && wynik <= DateTime.Now.Year)
                    {
                        rokUrodzenia = wynik;
                    }
                    else
                    {
                        Console.WriteLine($"Podałeś niepoprawne dane. {komunikat}");
                    }
                }

                while (rokUrodzenia == 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return rokUrodzenia;
        }

        private static Int16 PobierzMiesiacUrodzeniaOdUzytkownika(string komunikat)
        {
            bool zmienna = false;
            Int16 miesiacUrodzenia = 0;
            try
            {
                Console.WriteLine(komunikat);
                do
                {
                    zmienna = Int16.TryParse(Console.ReadLine(), out Int16 wynik);
                    if (wynik >= 1 && wynik <= 12)
                    {
                        miesiacUrodzenia = wynik;
                    }
                    else
                    {
                        Console.WriteLine($"Podałeś niepoprawne dane. {komunikat}");
                    }
                }

                while (miesiacUrodzenia == 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return miesiacUrodzenia;
        }


        private static byte PobierzDzienUrodzeniaOdUzytkownika(string komunikat, Int16 rokUrodzenia, Int16 miesiacUrodzenia)
        {
            bool zmienna = false;
            byte dzienUrodzenia = 0;
            try
            {
                Console.WriteLine(komunikat);
                do
                {
                    zmienna = byte.TryParse(Console.ReadLine(), out byte wynik);
                    if (wynik >= 1 && wynik <= DateTime.DaysInMonth(rokUrodzenia, miesiacUrodzenia))
                    {
                        dzienUrodzenia = wynik;
                    }
                    else
                    {
                        Console.WriteLine($"Podałeś niepoprawne dane. {komunikat}");
                    }
                }

                while (dzienUrodzenia == 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dzienUrodzenia;
        }


    }
}
