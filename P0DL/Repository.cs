using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using P0Models;

namespace P0DL
{
    public class Repository : IRepository //Will Inherit from IRepo
    {
        //Reduced the file path to make it adjust to different databases
        private const string _filePath = "./../P0DL/Database/";
        private string _jsonString;

        /// <summary>
        /// To start you need to dotnet sln add .\P0DL\
        /// Will cause errors to appear
        /// To set up you need to cd back into P0DL folder then, dotnet add reference ..\P0Models\P0Models.csproj
        /// This will get rid of red line
        /// EDIT OUT TO CREAT BL?
        /// </summary>
        /// <param name="p_cust"></param>
        /// <returns></returns>
        public Customers AddCustomer(Customers p_cust)
        {
            List<Customers> listOfCustomers = GetAllCustomers();
            listOfCustomers.Add(p_cust);

            _jsonString = JsonSerializer.Serialize(listOfCustomers, new JsonSerializerOptions{WriteIndented=true});

            File.WriteAllText(_filePath+"Customers.json",_jsonString);
            return p_cust;
        }

        public List<Customers> GetAllCustomers()
        {   
            _jsonString = File.ReadAllText(_filePath+"Customers.json");

            return JsonSerializer.Deserialize<List<Customers>>(_jsonString);
        }

        public List<StoreFronts> GetAllStoreFronts()
        {
            _jsonString = File.ReadAllText(_filePath+"StoreFronts.json");
            return JsonSerializer.Deserialize<List<StoreFronts>>(_jsonString);
        }
    }
}
