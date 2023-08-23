namespace F04
{
    internal class Program
    {
        static void PrintVersion()
        {
            Console.WriteLine("MyDOS [Version V1.01]");
            Console.WriteLine();
        }

        static void PrintDirectoryInfo()
        {
            var directories =
                Directory
                .GetDirectories(Directory.GetCurrentDirectory())
                .OrderBy(dir => dir);

            foreach (var dir in directories)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"<DIR>\t{Path.GetFileName(dir)}");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            var dirInfo = new DirectoryInfo(Directory.GetCurrentDirectory());

            var files =
                dirInfo
                .GetFiles()
                .OrderBy(f => f.Name)
                .Select(file =>
                    new
                    {
                        Name = file.Name,
                        Size = file.Length
                    });

            foreach (var file in files)
            {
                Console.WriteLine($"<FILE>\t{file.Size}\t\t\t{file.Name}");
            }
        }

        static void PrintCurrentDirectory()
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
        }

        static void ChangeToParentDirectory()
        {
            var parentDirectory = Directory.GetParent(Directory.GetCurrentDirectory());

            if (parentDirectory != null)
            {
                Directory.SetCurrentDirectory(parentDirectory.FullName);
            }
        }

        static void ChangeDirectory(string command)
        {
            var commandParts = command.Split(' ');

            Directory.SetCurrentDirectory(commandParts[1]);
        }

        static void PrintErrorMessage(string message)
        {
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void ProcessCommands()
        {
            bool exit = false;

            do
            {
                Console.Write($"{Directory.GetCurrentDirectory()}> ");
                string? command = Console.ReadLine();

                try
                {
                    if (command == "dir" || command == "ls")
                    {
                        PrintDirectoryInfo();
                    }
                    else if (command == "cd")
                    {
                        PrintCurrentDirectory();
                    }
                    else if (command == "cd.." || command == "cd ..")
                    {
                        ChangeToParentDirectory();
                    }
                    else if (command.StartsWith("cd"))
                    {
                        ChangeDirectory(command);
                    }
                    else if (command == "cls")
                    {
                        Console.Clear();
                    }
                    else if (command == "exit")
                    {
                        exit = true;
                    }
                    else if (!string.IsNullOrEmpty(command))
                    {
                        PrintErrorMessage("Bad command or file name");
                    }
                }
                catch (Exception ex)
                {
                    PrintErrorMessage($"Error: {ex.Message}");
                }
            } while (!exit);
        }

        static void Main(string[] args)
        {
            PrintVersion();

            ProcessCommands();
        }
    }
}