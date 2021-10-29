namespace P0Models
{
    public class User : Customers
    {
        public User(string p_name)
        {
            base.Name = p_name;
        }
        
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}