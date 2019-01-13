// Interface for objects that have a price.
namespace SpaceTraders
{
    public interface IHasPrice
    {
        // Returns the price of the object.
        int Price { get; set; }
    }
}
