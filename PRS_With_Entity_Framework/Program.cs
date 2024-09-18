using PRS_With_Entity_Framework.Db;
using PRS_With_Entity_Framework.Models;

namespace PRS_With_Entity_Framework
{
    internal class Program
    {
        private static UserDb userDb = new();
        private static VendorDb vendorDb = new();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the PRS DB Manager!");
            string mainMenuCommand = "";
            while (mainMenuCommand != "exit")//start of primary/MainMenu while loop
            {
                DisplayMainMenu();
                mainMenuCommand = PromptInput("Please enter a command: ");

                switch (mainMenuCommand)//start of primary/MainMenu switch statement
                {
                    case "user":
                    case "users":
                        string userMenuCommand = "";
                        while (userMenuCommand != "back")//Start of UserMenu while loop
                        {
                            DisplayUserMenu();
                            userMenuCommand = PromptInput("Please enter a command: ");

                            switch (userMenuCommand) //start of UserMenu switch statement
                            {
                                case "list":
                                    ListUsers();
                                    break;
                                case "get":
                                    GetUser();
                                    break;
                                case "add":
                                    AddUser();
                                    break;
                                case "del":
                                    RemoveUser();
                                    break;
                                case "back":
                                    userMenuCommand = "back";
                                    break;
                                default:
                                    Console.WriteLine("Invalid command. Please enter a valid Menu command.");
                                    break;
                            }//end of UserMenu switch statement
                        }//end of UserMenu while loop
                        break;
                    case "product":
                    case "products":
                        break;
                    case "vendor":
                    case "vendors":
                        string vendorMenuCommand = "";
                        while (vendorMenuCommand != "back")//Start of VendorMenu while loop
                        {
                            DisplayVendorMenu();
                            vendorMenuCommand = PromptInput("Please enter a command: ");

                            switch (vendorMenuCommand) //start of VendorMenu switch statement
                            {
                                case "list":
                                    ListVendors();
                                    break;
                                case "get":
                                    GetVendor();
                                    break;
                                case "add":
                                    AddVendor();
                                    break;
                                case "del":
                                    RemoveVendor();
                                    break;
                                case "back":
                                    userMenuCommand = "back";
                                    break;
                                default:
                                    Console.WriteLine("Invalid command. Please enter a valid Menu command.");
                                    break;
                            }//end of VendorMenu switch statement
                        }//end of VendorMenu while loop
                        break;
                    case "lineitem":
                    case "line item":
                        break;
                    case "request":
                        break;
                    case "exit":
                        mainMenuCommand = "exit";
                        break;
                    default:
                        Console.WriteLine("Invalid Command. Please enter a valid Menu command.");
                        break;
                }// end of the primary/MainMenu switch statement
            }//end of primary/MainMenu while loop
            Console.WriteLine("BYE");
        }

        //All Menu Methods start here
        static void DisplayMainMenu()
        {
            Console.WriteLine("\n  Main Menu");
            Console.WriteLine("=============");
            Console.WriteLine("\n       Command options:");
            Console.WriteLine("User - enter the User Sub-Menu");
            Console.WriteLine("Product - enter the Product Sub-Menu");
            Console.WriteLine("Vendor - enter the Vendor Sub-Menu");
            Console.WriteLine("LineItem - enter the Line Item Sub-Menu");
            Console.WriteLine("Request - enter the Request Sub-Menu");
            Console.WriteLine("Exit - exit the application\n");
        }

        static void DisplayUserMenu()
        {
            Console.WriteLine("\n  User Menu");
            Console.WriteLine("=============");
            Console.WriteLine("\n       Command options:");
            Console.WriteLine("List - list all users");
            Console.WriteLine("Get - Get a user by ID number");
            Console.WriteLine("Add - Add a new user");
            Console.WriteLine("Del - Remove a user by ID number");
            Console.WriteLine("Back - Return to the main menu\n");
        }

        static void DisplayVendorMenu()
        {
            Console.WriteLine("\n  Vendor Menu");
            Console.WriteLine("=============");
            Console.WriteLine("\n       Command options:");
            Console.WriteLine("List - list all vendors");
            Console.WriteLine("Get - Get a vendor by ID number");
            Console.WriteLine("Add - Add a new vendor");
            Console.WriteLine("Del - Remove a vendor by ID number");
            Console.WriteLine("Back - Return to the main menu\n");
        }

        //USER menu option Methods below here
        static void ListUsers()
        {
            Console.WriteLine("\n    Users List");
            Console.WriteLine("==================\n");
            List<User> users = userDb.GetUsers();
            foreach (User user in users)
            {
                Console.WriteLine(user);
            }

        }
        static void GetUser()
        {
            Console.WriteLine("Get User by ID number");
            Console.WriteLine("=====================");
            int id = int.Parse(PromptInput("User ID: "));
            User u = userDb.FindUser(id);
            if (u != null)
            {
                Console.WriteLine($"User Found: {u}");
            }
            else
            {
                Console.WriteLine($"No User found for ID: {id}");
            }
        }
        static void AddUser()
        {//begin AddUser Method
            string userName = PromptInput("Enter Username: ");
            string password = PromptInput("Enter Password: ");
            string firstName = PromptInput("Enter First Name: ");
            string lastName = PromptInput("Enter Last Name: ");
            string phoneNumber = PromptInput("Enter Phone Number: ");
            string email = PromptInput("Enter Email Address: ");
            bool reviewer = false;
            bool admin = false;

            string keepGoing = "y";
            while (keepGoing == "y")
            {
                string tempReviewer = PromptInput("Is the user a Reviewer (y/n): ");
                if (tempReviewer == "y")
                {
                    reviewer = true;
                    keepGoing = "n";
                }
                else if (tempReviewer == "n")
                {
                    reviewer = false;
                    keepGoing = "n";
                }
                else
                {
                    Console.WriteLine("Please enter a valid answer: Y/N\n");
                }
            }
            string keepGoing2 = "y";
            while (keepGoing2 == "y")
            {
                string tempAdmin = PromptInput("Is the user an Admin (y/n): ");
                if (tempAdmin == "y")
                {
                    admin = true;
                    keepGoing2 = "n";
                }
                else if (tempAdmin == "n")
                {
                    admin = false;
                    keepGoing2 = "n";
                }
                else
                {
                    Console.WriteLine("Please enter a valid answer: Y/N\n");
                }
            }
            User u = new User(userName, password, firstName, lastName, phoneNumber, email, reviewer, admin);
            userDb.AddUser(u);
            Console.WriteLine($"User Added: {u}");

        }//End AddUser Method
        static void RemoveUser()
        {
            Console.WriteLine("\nRemove User");
            Console.WriteLine("=============");
            int id = int.Parse(PromptInput("User ID: "));
            User u = userDb.FindUser(id);
            if (u != null)
            {
                userDb.RemoveUser(u);
            }
            else
            {
                Console.WriteLine($"No User found for ID: {id}");
            }
            Console.WriteLine("User Successfully Removed from Database");

        }

        //VENDER METHODS below here
        static void ListVendors()
        {
            Console.WriteLine("\n    Vendors List");
            Console.WriteLine("==================\n");

            List<Vendor> vendors = vendorDb.GetVendors();
            Console.WriteLine("List of vendors:");
            foreach (Vendor v in vendors)
            {
                Console.WriteLine($"id: {v.Id}, name: {v.Name}, code: {v.Code}");
            }
        }
        static void GetVendor()
        {
            Console.WriteLine("Get Vendor by ID number");
            Console.WriteLine("=====================");
            int id = int.Parse(PromptInput("Vendor ID: "));
            Vendor v = vendorDb.FindVendor(id);
            if (v != null)
            {
                Console.WriteLine($"Vendor Found: {v}");
            }
            else
            {
                Console.WriteLine($"No Vendor found for ID: {v}");
            }
        }
        static void AddVendor()
        {//begin AddVendor Method
            string code = PromptInput("Enter Code: ");
            string name = PromptInput("Enter Name: ");
            string address = PromptInput("Enter Address: ");
            string city = PromptInput("Enter City: ");
            string state = PromptInput("Enter State:");
            string zip = PromptInput("Enter Zip Code:");
            string phoneNumber = PromptInput("Enter Phone Number: ");
            string email = PromptInput("Enter Email Address: ");
            Console.WriteLine("Please enter a valid answer: Y/N\n");
            Vendor v = new Vendor(code, name, address, city, state, zip, phoneNumber, email);
            vendorDb.AddVendor(v);
            Console.WriteLine($"Vendor Added: {v}");
        }//End AddVendor Method
        static void RemoveVendor()
        {
            Console.WriteLine("\nRemove Vendor");
            Console.WriteLine("=============");
            int id = int.Parse(PromptInput("Vendor ID: "));
            Vendor v = vendorDb.FindVendor(id);
            if (v != null)
            {
                vendorDb.RemoveVendor(v);
            }
            else
            {
                Console.WriteLine($"No Vendor found for ID: {id}");
            }
            Console.WriteLine("Vendor Successfully Removed from Database");

        }


        // GENERAL METHODS below here
        static string PromptInput(string prompt)
        {
            Console.Write(prompt);
            string choice = Console.ReadLine().ToLower();
            return choice;
        }


    }
}
