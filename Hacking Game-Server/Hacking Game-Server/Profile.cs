using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLua;

namespace Hacking_Game_Server
{
    class Profile
    {
        private Lua scriptPower;
        private string scriptName;
        private string name;
        private Email email;

        public Profile(String name, Lua lua)
        {
            this.name = name;
            scriptName = name + ".lua";
            scriptPower = lua;
            scriptPower.DoFile(scriptName);
        }

        public string Name
        {
            get
            {
                return (string)scriptPower[name + ".name"];
            }
        }
        public string Description
        {
            get
            {
                return (string)scriptPower[name + ".description"];
            }
        }

        public Email Email
        {
            get
            {
                return this.email;
            }
            set
            {
                email = value;
            }
        }
    }
}
