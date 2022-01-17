namespace Luminous.Code.Extensions.Strings //YD: fix namespace to follow extension method pattern
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class StringExtensions
    {
        public static List<string> SplitIntoWords(this string instance)
        {
            //https://stackoverflow.com/questions/16725848/how-to-split-text-into-words

            //var text = "'Oh, you can't help that,' said the Cat: 'we're all mad here. I'm mad. You're mad.'";

            var punctuation = instance.Where(Char.IsPunctuation).Distinct().ToArray();
            var words = instance.Split().Select(x => x.Trim(punctuation)).ToList();

            return words;
        }

        public static bool MatchesFilter(this string instance, string filter, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase)
        {
            var index = instance.IndexOf(filter, 0, comparison);

            return (index > -1);
        }

        public static bool IsNullOrEmpty(this string instance)
            => string.IsNullOrEmpty(instance);

        public static bool IsNotNullOrEmpty(this string instance)
            => (!instance.IsNullOrEmpty());

        public static string ToPlural(this string instance, int count)
        {
            if (string.IsNullOrEmpty(instance))
                return "";

            return count switch
            {
                0 => $"{instance}s",
                1 => instance,
                _ => $"{instance}s",
            };
        }

        public static string ToQuotedString(this string instance)
            => string.IsNullOrEmpty(instance)
                ? ""
                : instance.Contains(" ")
                    ? (char)34 + instance + (char)34
                    : instance;

        public static bool IsFolder(this string instance)
        {
            var ext = Path.GetExtension(instance);

            return (ext == "");
        }
    }
}