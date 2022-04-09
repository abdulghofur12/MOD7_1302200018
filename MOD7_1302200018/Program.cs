using System;
using System.IO;
using System.Text.Json;

namespace MOD7_1302200018
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello word");
        }
    }

    class Config
    {
        public BankTransferConfig conf;
        public string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public string fileconfigName = "bank_transfer_config.json";


        public Config()
        {
            try
            {
                ReadConfigFile();
            }
            catch (Exception)
            {
                SetDefault();
                WriteNewConfigFile();
            }
        }

        private Config ReadConfigFile()
        {
            string jsonstringFromFile = File.ReadAllText(path + "/" + fileconfigName);
            conf = JsonSerializer.Deserialize<BankTransferConfig>(jsonstringFromFile);
            return conf;

        }
        private void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            String jsonString = JsonSerializer.Serialize(conf, options);
            string fullfilepath = path + "/" + fileconfigName;
            File.WriteAllText(fullfilepath, jsonString);

        }


        private void setDefault()
        {
            en = "Please insert the amount of money to transfer:";
            id = "“Masukkan jumlah uang yang akan di-transfe";
        }

        class BankTransferConfig
        {
            public string en { get; set; }
            public string id { get; set; }

            public BankTransferConfig(string en, string id)
            {
                this.en = en;
                this.id = id;
            }
        }
    }
}
