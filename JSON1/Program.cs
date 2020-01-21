using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace JSONtest
{
    class Program
    {
        static void Main(string[] args)
        {
            
             string json = @"[{
                                ""id"": 323,
                                ""username"": ""rinood30"",
                                ""profile"": {
                                ""full_name"": ""Shabrina Fauzan"",
                                ""birthday"": ""1988-10-30"",
                                ""phones"": [
                                    ""08133473821"",
                                    ""082539163912"",
                                ],
                                },
                                ""articles"": [
                                {
                                    ""id"": 3,
                                    ""title"": ""Tips Berbagi Makanan"",
                                    ""published_at"": ""2019-01-03T16:00:00""
                                },
                                {
                                    ""id"": 7,
                                    ""title"": ""Cara Membakar Ikan"",
                                    ""published_at"": ""2019-01-07T14:00:00""
                                }
                                ]
                            },
                            {
                                ""id"": 201,
                                ""username"": ""norisa"",
                                ""profile"": {
                                ""full_name"": ""Noor Annisa"",
                                ""birthday"": ""1986-08-14"",
                                ""phones"": [],
                                },
                                ""articles"": [
                                {
                                    ""id"": 82,
                                    ""title"": ""Cara Membuat Kue Kering"",
                                    ""published_at"": ""2019-10-08T11:00:00""
                                },
                                {
                                    ""id"": 91,
                                    ""title"": ""Cara Membuat Brownies"",
                                    ""published_at"": ""2019-11-11T13:00:00""
                                },
                                {
                                    ""id"": 31,
                                    ""title"": ""Cara Membuat Brownies"",
                                    ""published_at"": ""2019-11-11T13:00:00""
                                }
                                ]
                            },
                            {
                                ""id"": 42,
                                ""username"": ""karina"",
                                ""profile"": {
                                ""full_name"": ""Karina Triandini"",
                                ""birthday"": ""1986-04-14"",
                                ""phones"": [
                                    ""06133929341""
                                ],
                                },
                                ""articles"": []
                            },
                            {
                                ""id"": 201,
                                ""username"": ""icha"",
                                ""profile"": {
                                ""full_name"": ""Annisa Rachmawaty"",
                                ""birthday"": ""1987-12-30"",
                                ""phones"": [],
                                },
                                ""articles"": [
                                {
                                    ""id"": 39,
                                    ""title"": ""Tips Berbelanja Bulan Tua"",
                                    ""published_at"": ""2019-04-06T07:00:00""
                                },
                                {
                                    ""id"": 43,
                                    ""title"": ""Cara Memilih Permainan di Steam"",
                                    ""published_at"": ""2019-06-11T05:00:00""
                                },
                                {
                                    ""id"": 58,
                                    ""title"": ""Cara Membuat Brownies"",
                                    ""published_at"": ""2019-09-12T04:00:00""
                                }
                                ]
                            }]";
    
           
           var list = JsonConvert.DeserializeObject<List<User>>(json);

           Console.WriteLine("======================================");
           Console.WriteLine("User yang tidak memiliki nomor telepon");
           foreach(var item in list)
           {   
               if((item.Profile.Phones).Length == 0)
               {
                 Console.WriteLine(item.Username);
               }      
           }

           
           Console.WriteLine("======================================");
           Console.WriteLine("User yang memiliki Artikel");
           foreach(var item in list)
           {   
                if((item.articles).Count > 0)
                {
                    Console.WriteLine(item.Username);
                }
           }

           
           Console.WriteLine("======================================");
           Console.WriteLine("User yang memiliki kata Annis pada nama");
           foreach(var item in list)
           {
               if((item.Profile.Fullname).Contains("Annis"))
               {
                   Console.WriteLine(item.Username);
               }
           }

           
           Console.WriteLine("======================================");
           Console.WriteLine("User yang lahir pada tahun 1986");
           foreach(var item in list)
           {
               if((item.Profile.Birthday).Year == 1986)
               {
                   Console.WriteLine(item.Username);
               }
           }

           
           Console.WriteLine("======================================");
           Console.WriteLine("User yang memiliki artikel pada tahun 2020");
           foreach(var item in list)
           {
               foreach(var x in item.articles)
               {
                if((x.published_at).Year == 2020)
                {
                    Console.WriteLine(item.Username);
                }
               }
           }

           
           Console.WriteLine("======================================");
           Console.WriteLine("User yang memiliki judul tips");
           foreach(var item in list)
           {
               foreach(var x in item.articles)
               {
                if((x.title).Contains("Tips"))
                {
                    Console.WriteLine(item.Username + " " + x.title);
                }
               }
           }

            
           Console.WriteLine("======================================");
           Console.WriteLine("User yang publish artikel sebelum Agustus 2019");
           var filterDate = new DateTime(2019,08,01);
           foreach(var item in list)
           {
               foreach(var x in item.articles)
               {
                if((x.published_at) < filterDate) 
                {
                    Console.WriteLine(item.Username + " " + x.title);
                }
               }
           }
           Console.WriteLine("======================================");    
        }
    }
    public class User
    {
        [JsonProperty("id")]
        public int Id {get;set;}
        [JsonProperty("username")]
        public string Username {get;set;}
        public Profile Profile {get;set;}
        public List<Articles> articles {get;set;} = null;

    }

    public class Profile
    {
        [JsonProperty("id")]
        public int Id {get;set;}
        [JsonProperty("full_name")]
        public string Fullname {get;set;}
        [JsonProperty("birthday")]
        public DateTime Birthday {get;set;}
        [JsonProperty("phones")]
        public string[] Phones {get;set;} = {};

    }

    public class Articles
    {
        [JsonProperty("id")]
        public int id {get;set;}
        [JsonProperty("title")]
        public string title {get;set;}
        [JsonProperty("published_at")]
        public DateTime published_at {get;set;}
    }
    
}