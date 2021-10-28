using P0BL;

namespace P0UI
{
    public class CurrentProduct : IMenu
    {
        private IProductsBL _prodBL;
        public CurrentProduct(IProductsBL p_prodBL)
        {
            this._prodBL = p_prodBL;
        }
        
        public void Menu()
        {
            throw new System.NotImplementedException();
        }

        public MenuType YourChoice()
        {
            throw new System.NotImplementedException();
        }
    }
}