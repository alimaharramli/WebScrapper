namespace SearchRes;
public static class ProductUtils{
     public static void DisplayProducts(List<Product> productList)
    {
        Console.WriteLine("----------------------------------");
        foreach (Product prod in productList)
        {
            Console.WriteLine(prod.Title);
            Console.WriteLine(prod.Rating);
            Console.WriteLine(prod.Price);
            Console.WriteLine(prod.Seller);
            Console.WriteLine("----------------------------------");
        }
    }
 }