using Epam.Auction.BLL.Interfaces;
using Epam.Auction.Common.Dependencies;
using Epam.Auction.Common.Entites;

namespace Epam.Auction.PL.ConsolePL
{
    public class FirstPage
    {
        private static IAuctionLogic Bll = DependencyResolver.Instance.auctionLogic;
        private static int Id = 0;
        public static void OpenConsole()
            => StartFirstPage();

        private static void StartFirstPage()
        {
            if (Id > 0)
            {
                Console.WriteLine("\nSelect an action:" +
                "\n\t1 - Detailed account information" +
                "\n\t2 - View list of lots" +
                "\n\t3 - View list of users" +
                "\n\t0 - Exit");

                try
                {
                    var action = int.Parse(Console.ReadLine());

                    switch (action)
                    {
                        case 1:
                            GetUser(Id);
                            break;
                        case 2:
                            StartListLotsPage();
                            break;
                        case 3:
                            StartListUsersPage();
                            break;
                        case 0:
                            return;
                        default:
                            Console.WriteLine("Invalid value entered");
                            StartFirstPage();
                            break;
                    }

                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid value entered");
                    StartFirstPage();
                }
            }
            else
            {
                Console.WriteLine("\nSelect an action:" +
                    "\n\t1 - Sign in" +
                    "\n\t2 - Sign up" +
                    "\n\t3 - View list of lots" +
                    "\n\t4 - View list of users" +
                    "\n\t0 - Exit");

                try
                {
                    var action = int.Parse(Console.ReadLine());

                    switch (action)
                    {
                        case 1:
                            StartSignInPage();
                            StartFirstPage();
                            break;
                        case 2:
                            StartSignUpPage();
                            StartFirstPage();
                            break;
                        case 3:
                            StartListLotsPage();
                            break;
                        case 4:
                            StartListUsersPage();
                            break;
                        case 0:
                            return;
                        default:
                            Console.WriteLine("Invalid value entered");
                            StartFirstPage();
                            break;
                    }

                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid value entered");
                    StartFirstPage();
                }
            }
        }

        private static void StartSignInPage()
        {
            Console.WriteLine("\nUsername:");
            string login = Console.ReadLine();

            Console.WriteLine("\nPassword:");
            string password = Console.ReadLine();

            if (Bll.CheckAccount(login, password) > 0)
            {
                Console.WriteLine("\nWelcome to the system!");
                StartFirstPage();
            } else
            {
                Console.WriteLine("\nLogin error." +
                    "\n\t1 - Try again" +
                    "\n\t2 - Sign Up" +
                    "\n\t0 - Cancel");
                try
                {
                    var action = int.Parse(Console.ReadLine());

                    switch (action)
                    {
                        case 1:
                            StartSignInPage();
                            break;
                        case 2:
                            StartSignUpPage();
                            break;
                        case 0:
                            StartFirstPage();
                            break;
                        default:
                            Console.WriteLine("Invalid value entered");
                            StartFirstPage();
                            break;
                    }
                } catch (FormatException e)
                {
                    Console.WriteLine("Invalid value entered");
                    StartFirstPage();
                }
            }
        }

        private static void StartSignUpPage()
        {
            Console.WriteLine("\n\t\tRegistration");

            Console.WriteLine("\nYour birthdate (dd.mm.yyyy):");
            try
            {
                var birthdate = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("\nYour name:");
                var name = Console.ReadLine();

                Console.WriteLine("\nYour email:");
                var email = Console.ReadLine();

                Console.WriteLine("\nYour login");
                var login = Console.ReadLine();

                Console.WriteLine("\nYour password");
                var password = Console.ReadLine();

                Id = Bll.GetLastIdForUser() + 1;
                Console.WriteLine(Id);

                Bll.AddUser(new Account(Id, birthdate, name, email, login, password));

            } catch (FormatException e)
            {
                Console.WriteLine("\nLogin error." +
                    "\n\t1 - Try again" +
                    "\n\t2 - Sign In" +
                    "\n\t0 - Cancel");
                try
                {
                    var action = int.Parse(Console.ReadLine());

                    switch (action)
                    {
                        case 1:
                            StartSignUpPage();
                            break;
                        case 2:
                            StartSignInPage();
                            break;
                        case 0:
                            StartFirstPage();
                            break;
                        default:
                            Console.WriteLine("Invalid value entered");
                            StartFirstPage();
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Invalid value entered");
                    StartFirstPage();
                }
            }
        }

        private static void StartListLotsPage()
        {
            Console.WriteLine("\n---------------------------------------------" +
                "\n\t\tLots");
            foreach (var item in Bll.GetLots(""))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nSelect an action:" +
                "\n\t1 - Filter" +
                "\n\t2 - Select a lot" +
                "\n\t3 - Add new lot" +
                "\n\t4 - Delete lot" +
                "\n\t0 - Back to previous page");
            try
            {
                var action = int.Parse(Console.ReadLine());

                switch (action)
                {
                    case 1:
                        var lots = FilterLots();
                        if (lots == null)
                        {
                            Console.WriteLine("Back to previous page");
                            StartListLotsPage();
                        }
                        foreach (var item in lots) Console.WriteLine(item);
                        break;
                    case 2:
                        try
                        {
                            SelectLot();
                        } catch (InvalidOperationException e)
                        {
                            Console.WriteLine("{0}. Back to previous page", e.Message);
                            StartListLotsPage();
                        }
                        break;
                    case 3:
                        if (Id > 0)
                        {
                            AddLot();
                        } else
                        {
                            Console.WriteLine("\nYou are not logged in.");
                            StartListLotsPage();
                        }
                        break;
                    case 4:
                        if (Id > 0)
                        {
                            DeleteLot();
                        }
                        else
                        {
                            Console.WriteLine("\nYou are not logged in.");
                            StartListLotsPage();
                        }
                        break;
                    case 0:
                        StartFirstPage();
                        break;
                    default:
                        Console.WriteLine("Invalid value entered. Back to previous page");
                        StartListLotsPage();
                        break;
                }

            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid value entered");
                StartFirstPage();
            }
        }

        private static IEnumerable<Lot> FilterLots()
        {
            Console.WriteLine("\nSelect filter options" +
                "\n\t1 - Name" +
                "\n\t2 - Price" +
                "\n\t3 - Date added");

            try
            {
                var action = int.Parse(Console.ReadLine());

                switch (action)
                {
                    case 1:
                        Console.WriteLine("\nEnter name: ");
                        var name = Console.ReadLine();
                        return Bll.GetLots(name);
                    case 2:
                        Console.WriteLine("\nEnter price range\nPrice from:");
                        var priceFrom = Double.Parse(Console.ReadLine());
                        Console.WriteLine("Price to:");
                        var priceTo = Double.Parse(Console.ReadLine());
                        return Bll.GetLots(priceFrom, priceTo);
                    case 3:
                        Console.WriteLine("\nEnter date range\nDate from:");
                        var dateFrom = Console.ReadLine();
                        Console.WriteLine("Date to:");
                        var dateTo = Console.ReadLine();
                        return Bll.GetLots(dateFrom, dateTo);
                    default:
                        Console.WriteLine("Invalid value entered");
                        return null;
                }

            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid value entered");
                return null;
            }
        }

        private static void SelectLot()
        {
            Console.WriteLine("\nEnter ID need lot:");
            int id = int.Parse(Console.ReadLine());

            try
            {
                var lot = Bll.GetLot(id);

                Console.WriteLine("\nSelected lot:");

                ShowLot(id);

                Console.WriteLine("\nSelect an action:" +
                    "\n\t1 - Edit" +
                    "\n\t2 - To favorites" +
                    "\n\t0 - Back to previous page");

                try
                {
                    var action = int.Parse(Console.ReadLine());

                    switch (action)
                    {
                        case 1:
                            if (Id > 0)
                                EditLot(id);
                            else
                            {
                                Console.WriteLine("\nYou are not logged in.");
                                SelectLot();
                            }
                            break;
                        case 2:
                            if (Id > 0)
                            {
                                Bll.AddLotForUser(Id, lot.Id);
                            } else
                            {
                                Console.WriteLine("\nYou are not logged in.");
                                SelectLot();
                            }
                            break;
                        case 0:
                            StartListLotsPage();
                            break;
                        default:
                            Console.WriteLine("Invalid value entered");
                            SelectLot();
                            break;
                    }

                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid value entered. Back to previous page");
                    StartListLotsPage();
                }
            } 
            catch (InvalidOperationException e)
            {
                Console.WriteLine("{0}. Try again", e.Message);
                SelectLot();
            }
        }

        private static void StartListUsersPage() 
        {
            Console.WriteLine("\n---------------------------------------------" +
                "\n\t\tUsers");
            foreach (var item in Bll.GetUsers(""))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nSelect an action:" +
                "\n\t1 - Filter" +
                "\n\t2 - Select an user" +
                "\n\t0 - Back to previous page");
            try
            {
                var action = int.Parse(Console.ReadLine());

                switch (action)
                {
                    case 1:
                        var users = FilterUsers();
                        if (users == null)
                        {
                            Console.WriteLine("Back to previous page");
                            StartListUsersPage();
                        }
                        foreach (var item in users) Console.WriteLine(item);
                        break;
                    case 2:
                        try
                        {
                            SelectUser();
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine("{0}. Back to previous page", e.Message);
                            StartListLotsPage();
                        }
                        break;
                    case 0:
                        StartFirstPage();
                        break;
                    default:
                        Console.WriteLine("Invalid value entered. Back to previous page");
                        StartListLotsPage();
                        break;
                }

            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid value entered");
                StartFirstPage();
            }
        }

        private static IEnumerable<User> FilterUsers()
        {
            Console.WriteLine("\nSelect filter options" +
                "\n\t1 - Name" +
                "\n\t2 - Birthdate");

            try
            {
                var action = int.Parse(Console.ReadLine());

                switch (action)
                {
                    case 1:
                        Console.WriteLine("\nEnter name: ");
                        var name = Console.ReadLine();
                        return Bll.GetUsers(name);
                    case 2:
                        Console.WriteLine("\nEnter date range\nDate from:");
                        var dateFrom = Console.ReadLine();
                        Console.WriteLine("Date to:");
                        var dateTo = Console.ReadLine();
                        return Bll.GetUsers(dateFrom, dateTo);
                    default:
                        Console.WriteLine("Invalid value entered");
                        return null;
                        break;
                }

            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid value entered");
                return null;
            }
        }

        private static void SelectUser()
        {
            Console.WriteLine("\nEnter ID need user:");
            int id = int.Parse(Console.ReadLine());

            var account = Bll.GetAccount(id);

            Console.WriteLine("\nSelected user:");
            ShowUser(account);

            Console.WriteLine("\nSelect an action:" +
                "\n\t1 - Edit account" +
                "\n\t2 - Edit lots in account" +
                "\n\t3 - Sign out" +
                "\n\t0 - Back to previous page");

            try
            {
                var action = int.Parse(Console.ReadLine());

                switch (action)
                {
                    case 1:
                        if (account.Id == Id)
                        {
                            EditAccount(account.Id);

                        } else
                        {
                            Console.WriteLine("Not enough rights to edit this account");
                            SelectUser();
                        }
                        break;
                    case 2:
                        if (account.Id == Id)
                        {
                            EditLots(account);

                        }
                        else
                        {
                            Console.WriteLine("Not enough rights to edit this account");
                            SelectUser();
                        }
                        break;
                    case 3:
                        if (account.Id == Id)
                        {
                            Id = 0;
                            Console.WriteLine("You have successfully sign out of your account");
                            StartFirstPage();

                        }
                        else
                        {
                            Console.WriteLine("This is not your account. You can't sign out of it");
                            SelectUser();
                        }
                        break;
                    case 0:
                        StartListUsersPage();
                        break;
                    default:
                        Console.WriteLine("Invalid value entered");
                        SelectUser();
                        break;
                }

            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid value entered. Back to previous page");
                StartListUsersPage();
            }
        }

        private static void ShowLot(int id)
        {
            Console.WriteLine("\n{0}", Bll.GetLot(id));
        }

        private static void ShowUser(Account account)
        {
            Console.WriteLine("\n{0}", account);
        }

        private static void GetUser(int id)
        {
            Console.WriteLine("\n\t\tYour profile");
            ShowAccount(id);

            Console.WriteLine("\nSelect an action:" +
                "\n\t1 - Edit profile" +
                "\n\t2 - Sign out" +
                "\n\t0 - Cancel");

            try
            {
                var action = int.Parse(Console.ReadLine());

                switch (action)
                {
                    case 1:
                        EditAccount(id);
                        break;
                    case 2:
                        Id = 0;
                        Console.WriteLine("You have successfully sign out of your account");
                        StartFirstPage();
                        break;
                    case 0:
                        StartFirstPage();
                        break;
                    default:
                        Console.WriteLine("Invalid value entered");
                        GetUser(id);
                        break;
                }

            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid value entered. Back to previous page");
                GetUser(id);
            }
        }

        private static void AddLot()
        {
            if (Bll.CheckRole(Id) > 0)
            {
                Console.WriteLine("\nEnter name:");
                var name = Console.ReadLine();

                Console.WriteLine("\n Enter description:");
                var description = Console.ReadLine();

                Console.WriteLine("\n Enter price:");
                try
                {
                    var price = int.Parse(Console.ReadLine());

                    var id = Bll.GetLastIdForLot();


                    Bll.AddLot(new Lot(id, name, price, description));

                    Console.WriteLine("\n Added lot:");
                    ShowLot(id);

                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid value entered. Back to previous page");
                    StartListLotsPage();
                }
            }
            else
            {
                Console.WriteLine("\nNot enough rights.");
                StartListLotsPage();
            }
        }

        private static void DeleteLot()
        {
            if (Bll.CheckRole(Id) > 0)
            {
                Console.WriteLine("\nEnter ID need lot:");
                int idLot = int.Parse(Console.ReadLine());

                try
                {
                    var lot = Bll.GetLot(idLot);

                    Console.WriteLine("\nSelected lot:");

                    ShowLot(lot);

                    Bll.DeleteLot(idLot);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    SelectLot();
                }
            }
            else
            {
                Console.WriteLine("\nNot enough rights.");
                StartListLotsPage();
            }
        }

        private static void EditLot(int id)
        {
            if (Bll.CheckRole(Id) > 0)
            {
                Console.WriteLine("\nSelect an option to edit:" +
                "\n\t1 - All option" +
                "\n\t2 - Name" +
                "\n\t3 - Description" +
                "\n\t4 - Price" +
                "\n\t0 - Cancel");

                try
                {
                    var action = int.Parse(Console.ReadLine());

                    switch (action)
                    {
                        case 1:
                            EditLotWithAllParameters(id);
                            break;
                        case 2:
                            Console.WriteLine("\nEnter new name for lot:");
                            var name = Console.ReadLine();
                            Bll.EditLot(id, name, true);
                            break;
                        case 3:
                            Console.WriteLine("\nEnter new description for lot:");
                            var description = Console.ReadLine();
                            Bll.EditLot(id, description, false);
                            break;
                        case 4:
                            Console.WriteLine("\nEnter new price for lot:");
                            var price = Console.ReadLine();
                            Bll.EditLot(id, price, true);
                            break;
                        case 0:
                            SelectLot();
                            break;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid value entered. Back to previous page");
                    SelectLot();
                }
            }
            else
            {
                Console.WriteLine("\nNot enough rights.");
                SelectLot();
            }
        }

        private static void EditLotWithAllParameters(int id)
        {
            Console.WriteLine("Enter new name for lot");
            var name = Console.ReadLine();

            Console.WriteLine("Enter new price for lot");
            try
            {
                var price = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter new description for lot");
                var description = Console.ReadLine();

                Bll.EditLotWithAllParameters(new Lot(id, name, price, description));

            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid value entered. Back to previous page");
                EditLot(id);
            }
        }

        private static void EditAccount(int id)
        {
            Console.WriteLine("\nSelect an option to edit:" +
                "\n\t1 - All option" +
                "\n\t2 - Name" +
                "\n\t3 - Email" +
                "\n\t4 - Birthdate" +
                "\n\t5 - Login" +
                "\n\t6 - Password" +
                "\n\t7 - Role" +
                "\n\t0 - Cancel");

            try
            {
                var action = int.Parse(Console.ReadLine());

                switch (action)
                {
                    case 1:
                        EditAccountWithAllParameters(id);
                        break;
                    case 2:
                        Console.WriteLine("\nEdit your name:");
                        var name = Console.ReadLine();
                        Bll.EditUser(id, name, true);
                        break;
                    case 3:
                        Console.WriteLine("\nEdit your email:");
                        var email = Console.ReadLine();
                        Bll.EditUser(id, email, false);
                        break;
                    case 4:
                        Console.WriteLine("\nEdit your birthdate (dd.mm.yyyy):");
                        try
                        {
                            var birthdate = Console.ReadLine();
                            Bll.EditUser(id, birthdate, true);
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Invalid value entered");
                            EditAccount(id);
                        }
                        break;
                    case 5:
                        Console.WriteLine("\nEdit your login:");
                        var login = Console.ReadLine();
                        Bll.EditAccount(id, login, true);
                        break;
                    case 6:
                        Console.WriteLine("\nEdit your password:");
                        var password = Console.ReadLine();
                        Bll.EditAccount(id, password, false);
                        break;
                    case 7:
                        if (Bll.CheckRole(Id) > 0)
                        {
                            EditRole();
                        } else
                        {
                            Console.WriteLine("\nNot enough rights.");
                            EditAccount(Id);
                        }
                        break;
                    case 0:
                        SelectUser();
                        break;
                    default:
                        Console.WriteLine("Invalid value entered");
                        SelectUser();
                        break;
                }

            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid value entered. Back to previous page");
                StartListLotsPage();
            }
        }

        private static void EditRole()
        {
            Console.WriteLine("\nSelect a role:" +
                                "\n\t1 - admin" +
                                "\n\t2 - user" +
                                "\n\t0 - Cancel");

            try
            {
                var action = int.Parse(Console.ReadLine());

                switch (action)
                {
                    case 1:
                        Bll.EditRoleInAcoount(Id, "admin");
                        break;
                    case 2:
                        Bll.EditRoleInAcoount(Id, "user");
                        break;
                    case 0:
                        EditAccount(Id);
                        break;
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid value entered. Back to previous page");
                EditAccount(Id);
            }
        }

        private static void EditAccountWithAllParameters(int id)
        {
            Console.WriteLine("\nEdit your birthdate (dd.mm.yyyy):");
            try
            {
                var birthdate = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("\nEdit your name:");
                var name = Console.ReadLine();

                Console.WriteLine("\nEdit your email:");
                var email = Console.ReadLine();

                Console.WriteLine("\nEdit your login");
                var login = Console.ReadLine();

                Console.WriteLine("\nEdit your password");
                var password = Console.ReadLine();

                Bll.EditUserWithAllParameters(new Account(id, birthdate, name, email, login, password));

            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid value entered. Try again");
                EditAccountWithAllParameters(id);
            }
        }

        private static void EditLots(Account account)
        {
            Console.WriteLine("\nSelect an action:" +
                "\n\t1 - Add lot to your list of lots" +
                "\n\t2 - Delete lot from your list of lots" +
                "\n\t0 - Cancel");

            try
            {
                var action = int.Parse(Console.ReadLine());

                switch (action)
                {
                    case 1:
                        AddLotForUser();
                        break;
                    case 2:
                        DeleteLotForUser();
                        break;
                    case 0:
                        SelectUser();
                        break;
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid value entered. Back to previous page");
                SelectUser();
            }
        }

        private static void DeleteLotForUser()
        {
            Console.WriteLine("\nEnter ID need lot:");
            int idLot = int.Parse(Console.ReadLine());

            try
            {
                var lot = Bll.GetLot(idLot);

                Console.WriteLine("\nSelected lot:");

                ShowLot(lot);

                Bll.DeleteLotForUser(Id, idLot);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                SelectLot();
            }
        }
        private static void AddLotForUser()
        {
            Console.WriteLine("\nEnter ID need lot:");
            int idLot = int.Parse(Console.ReadLine());

            try
            {
                var lot = Bll.GetLot(idLot);

                Console.WriteLine("\nSelected lot:");

                ShowLot(lot);

                Bll.AddLotForUser(Id, idLot);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                SelectLot();
            }
        }

        private static void ShowLot(Lot lot)
        {
            Console.WriteLine("\n{0}", lot);
        }

        private static void ShowAccount(int id)
        {
            Console.WriteLine("\n{0}", Bll.GetAccount(id));
        }
    }
}
