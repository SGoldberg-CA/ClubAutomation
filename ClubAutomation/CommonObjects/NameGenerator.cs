using System;
using System.Linq;

namespace ClubAutomation.CommonObjects
{
    public class NameGenerator
    {
        public static string GetRandomName(int len)
        {
            var r = new Random();
            const string alphabet = "abcdefghijklmnopqrstuvwyxzeeeiouea";

            Func<char> randomLetter = () => alphabet[r.Next(alphabet.Length)];
            Func<int, string> makeName =
              length => new string(Enumerable.Range(0, length)
                 .Select(x => x == 0 ? char.ToUpper(randomLetter()) : randomLetter())
                 .ToArray());

            return makeName(r.Next(len) + len);
        }

        public static string GetFirstLetter(string name)
        {
            var length = name.Length - (name.Length - 1);
            return name.Substring(0, length);
        }
    }
}
