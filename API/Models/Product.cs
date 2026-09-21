using System;

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
        public string Id { get; set; }

        public string Name { get; set; }

        //Data-time do system quando o product criado
        public DateTime CreateOn { get; set; }
    }
}