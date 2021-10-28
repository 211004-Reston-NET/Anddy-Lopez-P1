namespace P0Models
{
    public class User : Customers
    {
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}