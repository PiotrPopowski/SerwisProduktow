﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerwisProduktow.Domain.Exceptions
{
    public static class ErrorCodes
    {
        public static string ShortComment => "Komentarz zbyt krótki! (min 20 znaków)";
        public static string LongComment => "Komentarz zbyt długi! (max 190 znaków)";
        public static string ShortDescryption => "Opis zbyt krótki! (min 50 znaków)";
        public static string LongDescryption => "Opis zbyt dług! (max 250 znaków)";
        public static string NullLogin => "Pusty login!";
        public static string WrongCharacterLogin => "Niedozwolone znaki w Loginie!";
        public static string NullPassword => "Białe znaki lub brak hasła!";
        public static string WrongSalt => "Wrong salt!";
        public static string ShortPassword => "Hasło zbyt krótkie! (min 8 znaków)";
        public static string LongPassword => "Hasło zbyt długie! (max 32 znaki)";
        public static string WrongStatus => "Zły status!";
    }
}