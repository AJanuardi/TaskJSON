using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections;

namespace JSON3
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = @"[
  {
    ""inventory_id"": 9382,
    ""name"": ""Brown Chair"",
    ""type"": ""furniture"",
    ""tags"": [
      ""chair"",
      ""furniture"",
      ""brown""
    ],
    ""purchased_at"": 1579190471,
    ""placement"": {
      ""room_id"": 3,
      ""name"": ""Sangkuriang""
    }
  },
  {
    ""inventory_id"": 9380,
    ""name"": ""Big Desk"",
    ""type"": ""furniture"",
    ""tags"": [
      ""desk"",
      ""furniture"",
      ""brown""
    ],
    ""purchased_at"": 1579190642,
    ""placement"": {
      ""room_id"": 3,
      ""name"": ""Sangkuriang""
    }
  },
  {
    ""inventory_id"": 2932,
    ""name"": ""LG Monitor 50 inch"",
    ""type"": ""electronic"",
    ""tags"": [
      ""monitor""
    ],
    ""purchased_at"": 1579017842,
    ""placement"": {
      ""room_id"": 3,
      ""name"": ""Sangkuriang""
    }
  },
  {
    ""inventory_id"": 232,
    ""name"": ""Sharp Pendingin Ruangan 2PK"",
    ""type"": ""electronic"",
    ""tags"": [
      ""ac""
    ],
    ""purchased_at"": 1578931442,
    ""placement"": {
      ""room_id"": 5,
      ""name"": ""Dhanapala""
    }
  },
  {
    ""inventory_id"": 9382,
    ""name"": ""Alat Makan"",
    ""type"": ""tableware"",
    ""tags"": [
      ""spoon"",
      ""fork"",
      ""tableware""
    ],
    ""purchased_at"": 1578672242,
    ""placement"": {
      ""room_id"": 10,
      ""name"": ""Rajawali""
    }
  }
]";
        User obj = new User();
        var MyObj = JsonConvert.DeserializeObject<List<User>>(json);

        Console.WriteLine("================================");
        Console.WriteLine("Jumlah barang pada Sangkuriang: ");
            int total = 0;
            foreach (var x in MyObj)
            {
                if (x.Placement.Name == "Sangkuriang")
                {
                    total++;
                    Console.WriteLine("Sangkuriang Room :" + x.Name);
                }
            }
            Console.WriteLine("Total: " + total + " barang");

        Console.WriteLine("================================");
        Console.WriteLine("Jumlah elektronik: ");
            int elektrik = 0;
            foreach (var x in MyObj)
            {
                if (x.Type == "electronic")
                {
                    elektrik++;
                }
            }
            Console.WriteLine("Total: " + elektrik + " barang");
        
        Console.WriteLine("================================");
        Console.WriteLine("Jumlah furniture: ");
            int furnitur = 0;
            foreach (var x in MyObj)
            {
                if (x.Type == "furniture")
                {
                    furnitur++;
                    Console.WriteLine("Furniture :" + x.Name);
                }
            }
            Console.WriteLine("Total: " + furnitur + " barang");
        
        Console.WriteLine("================================");
        Console.WriteLine("Jumlah item yang dibayar pada 16 Jan 2020: ");
            int bayar = 0;
            DateTime hasil = new DateTime(2020, 01, 16);
            string tgl1 = hasil.ToShortDateString();
            string tgl = "";
            foreach (var x in MyObj)
            {
                var date = DateTimeOffset.FromUnixTimeSeconds(x.PurchasedAt).DateTime.ToShortDateString();
                tgl += date;
                //System.Console.WriteLine(tgl);
                //if ((DateTime.Parse(x.PurchasedAt).ToString()).Contains("1601202)"))
                if (tgl1 == tgl)
                {
                    bayar++;
                    tgl ="";
                    Console.WriteLine("Pembelian 16 Januari 2020 :" + x.Name);
                }
            }
            Console.WriteLine("Total: " + bayar + " barang");
        
        Console.WriteLine("================================");
        Console.WriteLine("Jumlah barang cokelat: ");
            int brown = 0;
            foreach (var x in MyObj)
            {
                if (x.Tags.Contains("brown"))
                {
                    brown++;
                    Console.WriteLine("Furniture :" + x.Name);
                }
            }
            Console.WriteLine("Total: " + furnitur + " barang");
            Console.WriteLine("================================");
        
        }
        class User
        {
            [JsonProperty("inventory_id")]
            public int InveroryId {get; set;}
            [JsonProperty("name")]
            public string Name {get;set;}
            [JsonProperty("type")]
            public string Type {get; set;}
            [JsonProperty("purchased_at")]
            public long PurchasedAt {get; set;}
            [JsonProperty("placement")]
            public Placement Placement {get; set;}
            [JsonProperty("tags")]
            public List<string> Tags {get; set;} = new List<string>();
        }
        class Placement
        {
            [JsonProperty("room_id")]
            public int RoomId {get; set;}
            [JsonProperty("name")]
            public string Name {get; set;}
        }
    }
}
