﻿using System;
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
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Starting");
            Decode D = new Decode("#^5^^!^0^^50^^##^6^^9^##^7^^*^?^5^^^?^6^^^##^8^\"+\"Result\"^?^7^^\"#$\"?^8^\"$$\"+\"XWas\"^?^5^^\"$$\"+\"YWas\"^?^6^^\"$");
            while (true)
            {
                System.Threading.Thread.Sleep(100);
            }
        }
    }
    //#^5^^!^0^^50^^##^6^^9^##^7^^*^?^5^^^?^6^^^##^8^\"+\"Result\"^?^7^^\"#$\"?^8^\"$$\"+\"XWas\"^?^5^^\"$$\"+\"YWas\"^?^6^^\"$
    //#^5^^11^#{(=<^?^5^^^10000^=)$\"+\"Hi\"^?^5^^\"$#^5^^+^?^5^^^1^^#}
}
