// See https://aka.ms/new-console-template for more information
using ConsoleMenu.Menu;
using PizzaLibrary.Models;
using PizzaLibrary.Services;

MenuItemRepository mr = new MenuItemRepository();
MenuItem expensivePizza = mr.MostExpensivePizza();
if (expensivePizza != null )
    Console.WriteLine($"Den dyreste Pizza er {expensivePizza.Name}");
else
    Console.WriteLine("Der findes ikke en dyreste Pizza");
VIPCustomer vip = new VIPCustomer("Susanne", "40908090", "vejvej 69", 15);
Console.WriteLine(vip.ToString());

Beverage øl = new Beverage("Øl",30,"Carlsberg",MenuType.TILBEHØR,true);
Console.WriteLine(øl.ToString());
Beverage cola = new Beverage("Cola",25,"Coca-Cola",MenuType.TILBEHØR,false);
Console.WriteLine(cola.ToString());
  

UserMenu menu = new UserMenu();
//menu.ShowMenu();
