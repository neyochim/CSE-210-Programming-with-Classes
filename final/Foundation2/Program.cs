using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] ney_args)
    {
        Product ney_product1 = new Product("Widget", "P1001", 3.50, 4);
        Product ney_product2 = new Product("Gadget", "P1002", 8.25, 2);
        Product ney_product3 = new Product("Cable", "P1003", 5.00, 3);
        Product ney_product4 = new Product("Adapter", "P1004", 12.99, 1);

        Address ney_address1 = new Address("123 Main Street", "Phoenix", "AZ", "USA");
        Address ney_address2 = new Address("77 King Street", "Toronto", "ON", "Canada");

        Customer ney_customer1 = new Customer("Alex Morgan", ney_address1);
        Customer ney_customer2 = new Customer("Jordan Lee", ney_address2);

        List<Product> ney_products1 = new List<Product> { ney_product1, ney_product2 };
        List<Product> ney_products2 = new List<Product> { ney_product3, ney_product4 };

        Order ney_order1 = new Order(ney_customer1, ney_products1);
        Order ney_order2 = new Order(ney_customer2, ney_products2);

        DisplayOrder(ney_order1);
        DisplayOrder(ney_order2);
    }

    static void DisplayOrder(Order ney_order)
    {
        Console.WriteLine(ney_order.ney_GetPackingLabel());
        Console.WriteLine(ney_order.ney_GetShippingLabel());
        Console.WriteLine($"Total Price: ${ney_order.ney_GetTotalPrice():0.00}");
        Console.WriteLine();
    }
}

class Product
{
    private string _ney_name;
    private string _ney_productId;
    private double _ney_pricePerUnit;
    private int _ney_quantity;

    public Product(string ney_name, string ney_productId, double ney_pricePerUnit, int ney_quantity)
    {
        _ney_name = ney_name;
        _ney_productId = ney_productId;
        _ney_pricePerUnit = ney_pricePerUnit;
        _ney_quantity = ney_quantity;
    }

    public string ney_GetName()
    {
        return _ney_name;
    }

    public void ney_SetName(string ney_name)
    {
        _ney_name = ney_name;
    }

    public string ney_GetProductId()
    {
        return _ney_productId;
    }

    public void ney_SetProductId(string ney_productId)
    {
        _ney_productId = ney_productId;
    }

    public double ney_GetPricePerUnit()
    {
        return _ney_pricePerUnit;
    }

    public void ney_SetPricePerUnit(double ney_pricePerUnit)
    {
        _ney_pricePerUnit = ney_pricePerUnit;
    }

    public int ney_GetQuantity()
    {
        return _ney_quantity;
    }

    public void ney_SetQuantity(int ney_quantity)
    {
        _ney_quantity = ney_quantity;
    }

    public double ney_GetTotalCost()
    {
        return _ney_pricePerUnit * _ney_quantity;
    }
}

class Address
{
    private string _ney_streetAddress;
    private string _ney_city;
    private string _ney_stateOrProvince;
    private string _ney_country;

    public Address(string ney_streetAddress, string ney_city, string ney_stateOrProvince, string ney_country)
    {
        _ney_streetAddress = ney_streetAddress;
        _ney_city = ney_city;
        _ney_stateOrProvince = ney_stateOrProvince;
        _ney_country = ney_country;
    }

    public string ney_GetStreetAddress()
    {
        return _ney_streetAddress;
    }

    public void ney_SetStreetAddress(string ney_streetAddress)
    {
        _ney_streetAddress = ney_streetAddress;
    }

    public string ney_GetCity()
    {
        return _ney_city;
    }

    public void ney_SetCity(string ney_city)
    {
        _ney_city = ney_city;
    }

    public string ney_GetStateOrProvince()
    {
        return _ney_stateOrProvince;
    }

    public void ney_SetStateOrProvince(string ney_stateOrProvince)
    {
        _ney_stateOrProvince = ney_stateOrProvince;
    }

    public string ney_GetCountry()
    {
        return _ney_country;
    }

    public void ney_SetCountry(string ney_country)
    {
        _ney_country = ney_country;
    }

    public bool ney_IsInUSA()
    {
        return string.Equals(_ney_country, "USA", StringComparison.OrdinalIgnoreCase) ||
               string.Equals(_ney_country, "United States", StringComparison.OrdinalIgnoreCase) ||
               string.Equals(_ney_country, "United States of America", StringComparison.OrdinalIgnoreCase);
    }

    public string ney_GetFullAddress()
    {
        return $"{_ney_streetAddress}\n{_ney_city}, {_ney_stateOrProvince}\n{_ney_country}";
    }
}

class Customer
{
    private string _ney_name;
    private Address _ney_address;

    public Customer(string ney_name, Address ney_address)
    {
        _ney_name = ney_name;
        _ney_address = ney_address;
    }

    public string ney_GetName()
    {
        return _ney_name;
    }

    public void ney_SetName(string ney_name)
    {
        _ney_name = ney_name;
    }

    public Address ney_GetAddress()
    {
        return _ney_address;
    }

    public void ney_SetAddress(Address ney_address)
    {
        _ney_address = ney_address;
    }

    public bool ney_IsInUSA()
    {
        return _ney_address.ney_IsInUSA();
    }
}

class Order
{
    private Customer _ney_customer;
    private List<Product> _ney_products;

    public Order(Customer ney_customer, List<Product> ney_products)
    {
        _ney_customer = ney_customer;
        _ney_products = ney_products;
    }

    public Customer ney_GetCustomer()
    {
        return _ney_customer;
    }

    public void ney_SetCustomer(Customer ney_customer)
    {
        _ney_customer = ney_customer;
    }

    public List<Product> ney_GetProducts()
    {
        return _ney_products;
    }

    public void ney_SetProducts(List<Product> ney_products)
    {
        _ney_products = ney_products;
    }

    public double ney_GetTotalPrice()
    {
        double ney_total = 0;

        foreach (Product ney_product in _ney_products)
        {
            ney_total += ney_product.ney_GetTotalCost();
        }

        ney_total += _ney_customer.ney_IsInUSA() ? 5 : 35;
        return ney_total;
    }

    public string ney_GetPackingLabel()
    {
        StringBuilder ney_label = new StringBuilder();
        ney_label.AppendLine("Packing Label");

        foreach (Product ney_product in _ney_products)
        {
            ney_label.AppendLine($"{ney_product.ney_GetName()} (ID: {ney_product.ney_GetProductId()})");
        }

        return ney_label.ToString().TrimEnd();
    }

    public string ney_GetShippingLabel()
    {
        return $"Shipping Label\n{_ney_customer.ney_GetName()}\n{_ney_customer.ney_GetAddress().ney_GetFullAddress()}";
    }
}