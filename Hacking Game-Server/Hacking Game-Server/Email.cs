using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLua;

namespace Hacking_Game_Server
{
    class Email
    {
        private Lua scriptPower;
        private string fileName;
        private string name;
        private string scriptName;
        private string password;

        public Email(string fileName, string name, string password, Lua lua)
        {
            this.fileName = fileName;
            this.name = name;
            this.password = password;
            scriptPower = lua;
            scriptName = fileName + ".lua";
            scriptPower.DoFile(scriptName);
        }

        public string Name
        {
            get { return (string)scriptPower[fileName + ".name"]; }
        }

        public string Password
        {
            get { return (string)scriptPower[fileName + ".password"]; }
        }
    }
}
