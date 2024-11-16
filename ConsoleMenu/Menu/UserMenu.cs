using ConsoleMenu.Controller.Customers;
using ConsoleMenu.Controller.Menuitems;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using PizzaLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.Menu
{
    public class UserMenu
    {
        private static string mainMenuChoices = "\t1.Vis Pizzamenu\n\t2.Vis Kunder\n\t3.Add Customer\n\t4.Add Menuitem\n\t5. Add VIP Customer\n\tQ.Afslut\n\n\tIndtast valg:";

        private CustomerRepository _customerRepository = new CustomerRepository();
        private MenuItemRepository _menuItemRepository = new MenuItemRepository();
        private static string ReadChoice(string choices)
        {
            Console.Clear();
            Console.Write(choices);
            string choice = Console.ReadLine();
            Console.Clear();
            return choice.ToLower();
        }
        public void ShowMenu()
        {
            string theChoice = ReadChoice(mainMenuChoices);
            while (theChoice != "q")
            {
                switch (theChoice)
                {
                    case "1":
                        Console.WriteLine("Valg 1");
                        ShowMenuItemController showMenuItemController = new ShowMenuItemController(_menuItemRepository);
                        showMenuItemController.ShowAllMenuItems();
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine("Valg 2");
                        _customerRepository.PrintAllCustomers();
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.WriteLine("Valg 3");
                        Console.WriteLine("Indlæs navn:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Indlæs mobil nr:");
                        string mobile = Console.ReadLine();
                        Console.WriteLine("Indlæs adresse:");
                        string address = Console.ReadLine();
                        Console.WriteLine("Vil du være clubmember y/n");
                        string clubMemberString = Console.ReadLine().ToLower();
                        bool isClubMember = (clubMemberString[0] == 'y') ? true : false;
                        AddCustomerController addMenuItemController = new AddCustomerController(name, mobile, address, isClubMember, _customerRepository);
                        addMenuItemController.AddCustomer();
                        break;
                    case "4":
                        Console.WriteLine("Valg 4");
                        Console.WriteLine("Indlæs navn på Pizza:");
                        string itemname = Console.ReadLine();
                        Console.WriteLine("Indlæs prisen på pizzaen");
                        double price = double.Parse(Console.ReadLine());
                        Console.WriteLine("Indlæs beskrivelse af Pizza:");
                        string description = Console.ReadLine();
                        Console.WriteLine("Indlæs Pizzaens Menutype: \n1. SANDWICHES\n2. BRUCHETTA_CROSTINO\n3. SALATER\n4. PIZZECLASSSICHE\n5. PIZZESPECIALI\n6. PASTAALFORNO\n7. TILBEHØR");
                        string menutypeInput = Console.ReadLine();
                        MenuType menutype;

                        switch (menutypeInput)
                        {
                            case "1":
                                menutype = MenuType.SANDWICHES;
                                break;
                            case "2":
                                menutype = MenuType.BRUCHETTA_CROSTINO;
                                break;
                            case "3":
                                menutype = MenuType.SALATER;
                                break;
                            case "4":
                                menutype = MenuType.PIZZECLASSSICHE;
                                break;
                            case "5":
                                menutype = MenuType.PIZZESPECIALI;
                                break;
                            case "6":
                                menutype = MenuType.PASTAALFORNO;
                                break;
                            case "7":
                                menutype = MenuType.TILBEHØR;
                                break;
                            default:
                                Console.WriteLine("Invalid menu type selected.");
                                return;
                        }

                        MenuItem item = new MenuItem(itemname, price, description, menutype);
                        _menuItemRepository.AddMenuItem(item);
                        break;
                    case "5":
                        Console.WriteLine("Indlæs navn:");
                        string vipName = Console.ReadLine();
                        Console.WriteLine("Indlæs mobil nr:");
                        string vipMobile = Console.ReadLine();
                        Console.WriteLine("Indlæs adresse:");
                        string vipAddress = Console.ReadLine();
                        Console.WriteLine("Indlæs rabatprocent (1-25):");
                        double vipDiscount = double.Parse(Console.ReadLine());

                        try
                        {
                            VIPCustomer vipCustomer = new VIPCustomer(vipName, vipMobile, vipAddress, vipDiscount);
                            _customerRepository.AddCustomer(vipCustomer);   
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    default:
                        Console.WriteLine("Angiv et tal fra 1..5 eller q for afslut");
                        break;
                }
                theChoice = ReadChoice(mainMenuChoices);
            }
        }

    }

}
