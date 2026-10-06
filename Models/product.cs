namespace API.Models
{
    public class Product
    {
        //ID do product criado
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; } = string.Empty;

        //Data-time do system quando o product criado
        public DateTime CreateOn { get; set; } = DateTime.Now;
    }
}