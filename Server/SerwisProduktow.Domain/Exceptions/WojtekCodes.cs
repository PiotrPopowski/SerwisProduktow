﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerwisProduktow.Domain.Exceptions
{
    public static class WojtekCodes
    {
        public static string ShortComment => "Komentarz zbyt krótki! (min 20 znaków)";
        public static string LongComment => "Komentarz zbyt długi! (max 190 znaków)";
        public static string ShortDescryption => "Opis zbyt krótki! (min 50 znaków)";
        public static string LongDescryption => "Opis zbyt długi! (max 2500 znaków)";
        public static string NullLogin => "Pusty login!";
        public static string WrongCharacterLogin => "Niedozwolone znaki w Loginie!";
        public static string NullPassword => "Białe znaki lub brak hasła!";
        public static string WrongSalt => "Wrong salt!";
        public static string ShortPassword => "Hasło zbyt krótkie! (min 8 znaków)";
        public static string LongPassword => "Hasło zbyt długie! (max 32 znaki)";
        public static string WrongStatus => "Zły status!";
        public static string WrongCredentials => "Złe dane logowania!";
        public static string UserNotFound => "Nie znaleziono użytkownika!";
        public static string CategoryNotFound => "Nie znaleziono kategori!";
        public static string WrongUserName => "Zła nazwa użytkownika";
        public static string LongLogin => "Login za długi! (max 15 znaków)";
        public static string ShortLogin => "Login zbyt krótki! (min 4 znaki)";
        public static string LoginTaken => "Użytkownik o takim loginie już istnieje";
        public static string LongUserName => "Nazwa użytkownika zbyt długa! (max 15 znaków)";
        public static string ShortUserName => "Nazwa użytkownika zbyt krótka! (min 4 zanki)";
        public static string UserNameTaken => "Nazwa użytkownika zajęta!";
        public static string ShorServiceName => "Zbyt krótka nazwa usługi! (min 4 znaki)";
        public static string LongServiceName => "Zbyt dluga nazwa usługi! (max 20 znaków)";
        public static string PermissionDenied => "Nie masz uprawnień do tego zasobu.";
        public static string ActiveName => "Masz już produkt o takiej nazwie!";
        public static string UserVoted => "Użytkownik już wystawił ocenę dla tego produktu.";
        public static string WrongRating => "Podana wartość oceny jest nieprawidłowa.";
    }
}
