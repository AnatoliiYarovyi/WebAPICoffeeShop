using CoffeeShopAPI.BusinessLogic.Dtos;

namespace CoffeeShopAPI.BusinessLogic.Builder;

//Паттерн Builder дозволяє створювати складні об'єкти поетапно.
public interface IProductBuilder
{
    IProductBuilder SetId(string id);
    IProductBuilder SetName(string name);
    IProductBuilder SetPrice(decimal price);
    ProductsDto Build();
}