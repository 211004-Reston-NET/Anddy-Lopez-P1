//This interface is for MenuFactory
namespace P0UI
{
    public interface IFactory
    {
        IMenu GetMenu(MenuType p_menu);
    }
}