﻿namespace OnlineShopWebApp.Models
{
    public class Product
    {
        private static int instanceCounter = 0;
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public decimal Cost { get;}
        public string FilePath { get; }

        public Product( string name, decimal cost, string filePath, string description) 
        {
            Id = instanceCounter;
            Name = name; 
            Cost = cost;
            Description = description;
            FilePath = filePath;

            instanceCounter +=1;
        }

        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Cost}";
        }
    }
}