using System;
using System.Data;

namespace API.Models
{
    public class Product
    {
        public Product()
        {
            Id = Guid.NewGuid().ToString(); //Gera um ID para o product criado
            CreateOn = DateTime.Now;
        }

        //ID do product criado
        public string Id { get; set; } = Guid.NewGuid().ToString;

        public string Name { get; set; } = String.Empty;

        //Data-time do system quando o product criado
        public DateTime CreateOn { get; set; } = DataSetDateTime.Now;
    }
}