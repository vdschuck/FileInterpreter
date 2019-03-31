namespace Data.Models
{
    public class Seller
    {
        public string Name { get; set; }

        public double SalesAmout { get; set; }

        public string Cpf { get; set; }

        public double Salary { get; set; }

        public override string ToString()
        {           
            return $"001ç{Cpf}ç{Name}ç{Salary}";
        }
    }    
}
