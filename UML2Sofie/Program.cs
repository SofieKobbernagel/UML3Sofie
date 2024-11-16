// See https://aka.ms/new-console-template for more information
using PizzaLibrary.Models;
using PizzaLibrary.Services;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Data;

CustomerRepository cr = new CustomerRepository();
MenuItemRepository mr = new MenuItemRepository();

Console.WriteLine(cr.GetAll().Count);
Console.WriteLine(mr.GetAll().Count);