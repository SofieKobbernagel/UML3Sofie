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

Beverage øl = new Beverage(true);

UserMenu menu = new UserMenu();
//menu.ShowMenu();
