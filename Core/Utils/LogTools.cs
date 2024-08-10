using System;
using System.Runtime.InteropServices;

namespace AlgoTown.Utils
{
    /// <summary>
    /// Contains several functions for logging to the console
    /// </summary>
    public static class LogTools
    {

        /// <summary>
        /// A quick and easy way to write to the console wihtout having to write a separate line <br/> <br/>
        /// Example: 
        /// <code>    
        ///     "Hello World".Print();
        /// </code> 
        /// Example 2: 
        /// <code>
        ///     "width: {0}  height: {1}".Print(Window.Width, Window.Height);
        /// </code>
        /// </summary>
        public static T Print<T>(this T obj, params object[] args)
        {
            Console.WriteLine(obj.ToString(), args);
            return obj;
        }

        /// <summary>
        /// (Don't question the name) Writes a final message to the console 
        /// and waits for a key input to keep the console open
        /// </summary>
        public static void EdgeProgram()
        {
            PrintWithColor(AlignCenter("helooo"), ConsoleColor.White, ConsoleColor.Blue);

            Console.WriteLine();
            GetStroke().Print();
            // This feels like committing a crime >:)
            "Program has ended... Press any key to close".AlignCenter().Print();
            "AlgoTown by Arda Celebci".AlignCenter().Print();
            GetStroke().Print();
            Console.ReadKey();
        }

        /// <summary>
        /// Returns a string of underscore matching the width of the console
        /// </summary>
        public static string GetStroke(char c = '_')
        {
            string s = "";
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                s += c;
            }
            return s;
        }

        /// <summary>
        /// Write to the console with given colors. Does not overwrite current console colors.
        /// </summary>
        public static void PrintWithColor(
            string s,
            ConsoleColor textColor = ConsoleColor.Gray,
            ConsoleColor backgroundColor = ConsoleColor.Black,
            bool ignoreWhiteSpaces = true)
        {
            ConsoleColor foreground = Console.ForegroundColor;
            ConsoleColor background = Console.BackgroundColor;

            foreach (char c in s)
            {
                if (c == ' ' && ignoreWhiteSpaces)
                {
                    Console.ForegroundColor = foreground;
                    Console.BackgroundColor = background;
                    Console.Write(c);
                }
                else
                {
                    Console.ForegroundColor = textColor;
                    Console.BackgroundColor = backgroundColor;
                    Console.Write(c);
                }
            }

            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
            Console.WriteLine();
        }

        /// <summary>
        /// Returns the type of whitespace as a string
        /// </summary>
        public static string GetTypeOfWhitespace(char c)
        {
            if (char.IsWhiteSpace(c))
            {
                // Check for specific types of whitespace
                if (c == ' ')
                {
                    return "Space";
                }
                else if (c == '\t')
                {
                    return "Tab";
                }
                else if (c == '\n')
                {
                    return "Newline";
                }
                else if (c == '\r')
                {
                    return "Carriage return";
                }
                else if (c == '\v')
                {
                    return "Vertical tab";
                }
                else if (c == '\f')
                {
                    return "Form feed";
                }
                else
                {
                    return "Unknown type of whitespace character";
                }
            }
            else if (c == '\0')
            {
                return "Empty character";
            }
            else
            {
                return "Not a whitespace";
            }

        }

        public static string AlignCenter(this string s)
        {
            return s.PadLeft(Console.WindowWidth / 2 + s.Length / 2);
        }
    }
}
