using System;

< Project Sdk = "Microsoft.NET.Sdk" >

  < PropertyGroup >
    < TargetFramework > net9.0 </ TargetFramework >
    < ImplicitUsings > enable </ ImplicitUsings >
    < Nullable > enable </ Nullable >
  </ PropertyGroup >

  < ItemGroup >
    < PackageReference Include = "System.Data.SQLite.Core" Version = "1.0.119" />
  </ ItemGroup >

</ Project >
using System;
using System.Collections.Generic;
using EEPrintAPI; // <- Twój="" projekt="" API=""

namespace="" EEPrintAPI_Test=""
{
    class="" Program=""
    {
        static="" void="" Main(string= ""[] args= ""
        {
    string= "" dbPath = @
            EEPrintAPI = "" api = "new" EEPrintAPI = ""(dbPath = ""

            var = "" jobs = "api.GetJobs"(DateTime.Now.AddDays = ""(-7 = ""), DateTime.Now = ""

            foreach= ""(var = "" job = "" in= "" jobs = ""
            {
        Console.WriteLine = ""
            }

    Console.WriteLine = ""
            Console.ReadLine = ""();
}
}
}
