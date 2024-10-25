using CoffeeShopAPI.BusinessLogic.Dtos;

namespace CoffeeShopAPI.BusinessLogic.Builder;

public class ProductBuilder : IProductBuilder
{
    private string _id = Guid.NewGuid().ToString();
    private string _name = string.Empty;
    private decimal _price = 0;

    public IProductBuilder SetId(string id)
    {
        _id = id;
        return this;
    }

    public IProductBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public IProductBuilder SetPrice(decimal price)
    {
        _price = price;
        return this;
    }

    public ProductsDto Build()
    {
        return new ProductsDto(_id, _name, _price);
    }
};

