using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLua;

namespace Hacking_Game_Server
{
    class Program
    {
        public static bool quit = false;
        private static Profile currentProfile;
        private static Lua lua;

        private void RegisterFunctions()
        {
            lua.RegisterFunction("CreateProfile", this, this.GetType().GetMethod("CreateProfile"));
            lua.RegisterFunction("CreateEmail", this, this.GetType().GetMethod("CreateEmail"));
            lua.RegisterFunction("SetEmail", this, this.GetType().GetMethod("SetEmail"));
            lua.RegisterFunction("SetStartProfile", this, this.GetType().GetMethod("SetStartProfile"));
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Starting LUA Engine");
            Console.WriteLine("Type q to quit.");

            lua = new Lua();
            lua.LoadCLRPackage();

            Program p = new Program();
            p.RegisterFunctions();
            lua.DoFile("setup.lua");

            while (quit == false)
            {
                Console.WriteLine(">");
                string ans = Console.ReadLine();
                ClearScreen();

                if (ans == "q" || ans == "Q")
                {
                    quit = true;
                }

                ExploreProfile(currentProfile);
            }

            Console.WriteLine("Quitting...");
        }

        private static void ExploreProfile(Profile p)
        {
            Console.WriteLine("You are in " + p.Name + "'s Profile.");
            Console.WriteLine(p.Description);
        }

        private static void ClearScreen()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine();
            }
        }

        public static Profile CreateProfile(string name)
        {
            return new Profile(name, lua);
        }

        public static Email CreateEmail(string fileName, string name, string password)
        {
            return new Email(fileName, name, password, lua);
        }

        public static void SetStartProfile(Profile p)
        {
            currentProfile = p;
        }

        public static void SetEmail(Profile p, Email e)
        {
            p.Email = e;
        }
    }
}
