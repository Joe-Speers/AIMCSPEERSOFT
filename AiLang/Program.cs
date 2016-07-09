using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiLang
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting");
            Decode D = new Decode("#^5^^!^0^^50^^##^6^^9^##^7^^-^?^5^^^?^6^^^##^8^\"+\"Result\"^?^7^^\"#~^1000^~$\"?^8^\"$~^500^~$\"+\"XWas\"^?^5^^\"$~^500^~$\"+\"YWas\"^?^6^^\"$");
            while (true)
            {
                System.Threading.Thread.Sleep(100);
            }
        }
    }
    //#^5^^!^0^^50^^##^6^^9^##^7^^*^?^5^^^?^6^^^##^8^\"+\"Result\"^?^7^^\"#$\"?^8^\"$$\"+\"XWas\"^?^5^^\"$$\"+\"YWas\"^?^6^^\"$
}
