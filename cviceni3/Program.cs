using System.Globalization;

namespace cviceni3;

class Program
{
    static void Main(string[] args)
    {
        CultureInfo ci = CultureInfo.GetCultureInfo("cs-CZ");
        CultureInfo ciUs = CultureInfo.GetCultureInfo("en-US");
        CultureInfo ciGb = CultureInfo.GetCultureInfo("en-GB");


        Console.WriteLine("Zadejte cislo:");
        string? input = Console.ReadLine();

        int? x = ParseIntOrNull(input!);
        // int num;
        if(TryParseInt(input!, out int num, ParseIntOptionEnum.ALLOW_WHITESPACES | ParseIntOptionEnum.ALLOW_NEGATIVE_NUMBERS)) {
            Console.WriteLine("Neplatny vstup");
        } else {
            Console.WriteLine($"Vstup je platne cislo: {num}");
        }
    }

    public static int ParseInt(string input) {
        int result = 0;
        if(input == null) {
            return -1;
        }
        for(int i = 0;i < input.Length;i++) {
            if(input[i] < '0' || input[i] > '9') {
                return -1;
            }

            result = input[i] - '0' + result * 10;
        }
        return result;
    }

    static int? ParseIntOrNull(string input) {
        int result = 0;
        if(input == null) {
            return null;
        }
        for(int i = 0;i < input.Length;i++) {
            if(input[i] < '0' || input[i] > '9') {
                return null;
            }

            result = input[i] - '0' + result * 10;
        }
        return result;
    }

    static bool TryParseInt(string input, out int result) {
        result = 0;
        if(input == null) {
            return false;
        }
        for(int i = 0;i < input.Length;i++) {
            if(input[i] < '0' || input[i] > '9') {
                return false;
            }

            result = input[i] - '0' + result * 10;
        }
        return true;
    }

    static bool TryParseInt(string input, out int result, ParseIntOptionEnum options) {
        result = 0;
        bool isNegative = false;
        if(input == null) {
            return false;
        }
        for(int i = 0;i < input.Length;i++) {
            if(input[i] < '0' || input[i] > '9') {
                if(i == 0 && input[i] == '-') {
                    isNegative = true;
                    continue;
                }
                if(options.HasFlag(ParseIntOptionEnum.IGNORE_INVALID_CHARACTERS)) continue;
                if(options.HasFlag(ParseIntOptionEnum.ALLOW_WHITESPACES) && char.IsWhiteSpace(input[i])) continue;
                return false;
            }else {
                result = input[i] - '0' + result * 10;
            }
            
        }
        if(isNegative) result = -result;
        return true;
    }

    enum ParseIntOptionEnum {
        NONE = 1,
        ALLOW_WHITESPACES = 2,
        ALLOW_NEGATIVE_NUMBERS = 4,
        IGNORE_INVALID_CHARACTERS = 8
    }
}
