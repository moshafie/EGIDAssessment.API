﻿using EGIDAssessment.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGIDAssessment.Infrastructure.InitialDataInitializer
{
    public class DataInitializer : IDataInitializer
    {
        public List<Broker> getInitialBroker() { return new List<Broker>() {new Broker {ID=1,Name="Ahmed" }}; }

        public List<Person> getInitialPerson() { return new List<Person>() { new Person { Id = 1, Name = "Ahmed" ,BrokerId=1} }; }


        public List<Stock> GetInitialStoks()
        {
            return new List<Stock>
            {
                new Stock { ID=1,Name = "Vianet"},
                new Stock {ID=2, Name = "Akamai"},
                new Stock {ID=3, Name = "Baidu"},
                new Stock {ID=4, Name = "Blinkx"},
                new Stock {ID=5, Name = "Blucora"},
                new Stock {ID=6, Name = "Boingo"},
                new Stock {ID=7, Name = "Brainybrawn"},
                new Stock {ID=8, Name = "Carbonite"},
                new Stock {ID=9, Name = "China Finance"},
                new Stock {ID=10, Name = "ChinaCache"},
                new Stock {ID=11, Name = "ADR"},
                new Stock {ID=12, Name = "ChitrChatr"},
                new Stock {ID=13, Name = "Cnova"},
                new Stock {ID=14, Name = "Cogent"},
                new Stock {ID=15, Name = "Crexendo"},
                new Stock {ID=16, Name = "CrowdGather"},
                new Stock {ID=17, Name = "EarthLink"},
                new Stock {ID=18, Name = "Eastern"},
                new Stock {ID=19, Name = "ENDEXX"},
                new Stock {ID=20, Name = "Envestnet"},
                new Stock {ID=21, Name = "Epazz"},
                new Stock {ID=23, Name = "FlashZero"},
                new Stock {ID=24, Name = "Genesis"},
                new Stock {ID=25, Name = "InterNAP"},
                new Stock {ID=26, Name = "MeetMe"},
                new Stock {ID=27, Name = "Netease"},
                new Stock {ID=28, Name = "Qihoo"},
                };
        }
    }
}
