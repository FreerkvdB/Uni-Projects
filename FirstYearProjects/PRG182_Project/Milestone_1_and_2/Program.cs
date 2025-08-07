using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

// Ryno Goetz 602306
// Freerk van den Bos 602074
// Steven Piek 602240
// Wildre Fourie 601625

/* Link to presentation video:
 * https://youtu.be/LStNenHHysE
 */

namespace Milestone_1_and_2
{
    internal class Program
    {
        // Initialize and declare lists/variables globally

        // Lists

        static List<string> ApplicantName = new List<string>();
        static List<int> ApplicantAge = new List<int>();
        static List<int> ApplicantHighScore = new List<int>();
        static List<DateTime> StartingDate = new List<DateTime>();
        static List<int> PizzasConsumed = new List<int>();
        static List<int> BowlingHighScore = new List<int>();
        static List<string> EmploymentStatus = new List<string>();
        static List<string> SlushyPreference = new List<string>();
        static List<int> SlushysConsumed = new List<int>();
        static List<string> ParentsEmploymentStatus = new List<string>();
        static List<int> DaysAsMember = new List<int>(); // New list to store days as a member
        static List<int> AverageHighScore = new List<int>();
        static List<string> TokensRewarded = new List<string>();

        //Variables
        static int NumApplicant = 1;
        static int TokenGranted;
        static int TokenDenied;
        static bool Datachecked = false;
        static bool DataCaptured = false;

        // We use the Enum functions to create the menu that the user will choose what they want to do.
        enum Menu
        {
            CaptureDetail = 1,
            CheckCreditQualification,
            DisplayStats,
            AveragePizza,
            Sort,
            Loyal,
            Additional,
            HighScore,
            Exit
        }

        static void Main(string[] args)
        {
            Thread tread = new Thread(new ThreadStart(Load));

            bool Active = true;

            while (Active)
            {
                Console.Clear(); // Clear the console before displaying the menu
                Console.WriteLine("Welcome to RetroSlice.\n");
                Console.WriteLine("Please select an option from the menu:\n");
                /* This code will display all the option available on the menu.
                 * The {item.ToString()} displays the option name as listed in the enum function
                 * and the {(int)item} displays the number the user has to press to select the item.*/
                Console.WriteLine("1. Add an applicant.");
                Console.WriteLine("2. Check the token credit qualification rules.");
                Console.WriteLine("3. Display token credit qualification stats.");
                Console.WriteLine("4. Display the average pizzas consumed from first visit.");
                Console.WriteLine("5. Display sorted ages.");
                Console.WriteLine("6. Display long term loyalty customers");
                Console.WriteLine("7. Subscribe to newsletter ");
                Console.WriteLine("8. Update highscore");
                Console.WriteLine("9. Exit");
                Console.WriteLine("==================================="); // This separates the menu from the typing field.

                //This int is used for the switch case.
                // The tread.Start is the start of the loading time
                Console.WriteLine("Enter your choice:");
                string input = Console.ReadLine();
                int pick;

                if (int.TryParse(input, out pick))
                {
                    switch ((Menu)pick)
                    {
                        case Menu.CaptureDetail:
                            CaptureApplicantDetails();
                            break;
                        case Menu.CheckCreditQualification:
                            Check();
                            // Assuming tread.Start(); should not be here
                            break;
                        case Menu.DisplayStats:
                            Display();
                            tread.Start();
                            break;
                        case Menu.AveragePizza:
                            AveragePizzas();
                            tread.Start();
                            break;
                        case Menu.Sort:
                            DisplayAgeRange();
                            tread.Start();
                            break;
                        case Menu.Loyal:
                            LongTermLoyalty();
                            tread.Start();
                            break;
                        case Menu.Additional:
                            Email();
                            tread.Start();
                            break;
                        case Menu.HighScore:
                            HighscoreUpdate();
                            // Assuming tread.Start(); should not be here
                            break;
                        case Menu.Exit:
                            System.Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }// end of switch
        }






        // At the beginning of each method we call the Load method to start the loading animation and wait time

        static void CaptureApplicantDetails()
        {
            Load();
            Console.WriteLine("\n");

            // Other variables
            bool Active = true;
            string Capture;
            int Age;

            // Get Input
            while (Active)
            {
                Console.Clear();
                Console.WriteLine("Enter your Name: ");
                ApplicantName.Add(Console.ReadLine()); // Captures Name

                while (true) // While loop for validation of age
                {
                    Console.WriteLine("Enter your age (0-120): ");
                    if (int.TryParse(Console.ReadLine(), out Age) && Age >= 0 && Age <= 120)
                    {
                        ApplicantAge.Add(Age); // Captures Age
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid age between 0 and 120.");
                    }
                } // end of age while loop

                if (Age < 18) // check Age
                {
                    while (true) // While loop for validation of parent's employment status
                    {
                        Console.WriteLine("Are your parents employed? (Y/N): ");
                        string ParentEmploymentStatus = Console.ReadLine().ToUpper();
                        if (ParentEmploymentStatus == "Y" || ParentEmploymentStatus == "N")
                        {
                            ParentsEmploymentStatus.Add(ParentEmploymentStatus); // Captures Parents' Employment Status
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter 'Y' for Yes or 'N' for No.");
                        }
                    }
                    EmploymentStatus.Add("N/A"); // Not applicable for under 18
                }
                else
                {
                    while (true) // While loop for validation of employment status
                    {
                        Console.WriteLine("Are you employed? (Y/N): ");
                        string Employment = Console.ReadLine().ToUpper();
                        if (Employment == "Y" || Employment == "N")
                        {
                            EmploymentStatus.Add(Employment); // Captures Employment Status
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter 'Y' for Yes or 'N' for No.");
                        }
                    }
                    ParentsEmploymentStatus.Add("N/A"); // Parents' Employment Status not applicable
                }

                Console.WriteLine("Enter your high score rank: ");
                ApplicantHighScore.Add(int.Parse(Console.ReadLine()));
                bool validDate = false;
                while (!validDate) // check if Date is in correct format
                {
                    Console.WriteLine("Enter your joining date (yyyy-mm-dd): ");
                    string dateInput = Console.ReadLine();
                    if (DateTime.TryParse(dateInput, out DateTime date))
                    {
                        StartingDate.Add(date.Date); // Captures Joining Date, only date part
                        validDate = true;

                        // Calculate the number of days as a member and add it to the list
                        TimeSpan membershipDuration = DateTime.Today - date.Date;
                        DaysAsMember.Add((int)membershipDuration.TotalDays);
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format. Please enter the date in yyyy-mm-dd format.");
                    }
                } // end of error check for date

                Console.WriteLine("Enter number of pizzas consumed: ");
                PizzasConsumed.Add(int.Parse(Console.ReadLine())); // Captures Pizzas Consumed

                Console.WriteLine("Enter bowling high score: ");
                BowlingHighScore.Add(int.Parse(Console.ReadLine())); // Captures Bowling High Score

                Console.WriteLine("Enter slush-puppy flavor preference: ");
                SlushyPreference.Add(Console.ReadLine()); // Captures Slushy Preference

                Console.WriteLine("Enter number of slush-puppies consumed: ");
                SlushysConsumed.Add(int.Parse(Console.ReadLine())); // Captures Slushies Consumed

                // Display of Data 
                Console.Clear();
                Console.WriteLine("Applicant " + NumApplicant);
                Console.WriteLine("Applicant name: " + ApplicantName[NumApplicant - 1]);
                Console.WriteLine("Applicant age: " + ApplicantAge[NumApplicant - 1]);
                Console.WriteLine("Applicant best rank: " + ApplicantHighScore[NumApplicant - 1]);
                Console.WriteLine("Applicant joining date: " + StartingDate[NumApplicant - 1].ToString("yyyy-MM-dd"));
                Console.WriteLine("Applicant pizzas consumed: " + PizzasConsumed[NumApplicant - 1]);
                Console.WriteLine("Applicant bowling best score: " + BowlingHighScore[NumApplicant - 1]);
                Console.WriteLine("Applicant employment status: " + EmploymentStatus[NumApplicant - 1]);
                Console.WriteLine("Applicant parents employment status: " + ParentsEmploymentStatus[NumApplicant - 1]);
                Console.WriteLine("Applicant slush-puppy flavor preference: " + SlushyPreference[NumApplicant - 1]);
                Console.WriteLine("Applicant number of slush-puppies consumed: " + SlushysConsumed[NumApplicant - 1]);

                DataCaptured = true;

                // If the Applicant wants to capture another profile
                while (true) // While loop for validation of capture input
                {
                    Console.Write("Do you want to capture another applicant? (Y/N): ");
                    Capture = Console.ReadLine().ToUpper();
                    if (Capture == "N")
                    {
                        Main(null);
                    }
                    else if (Capture == "Y")
                    {
                        NumApplicant++; // Increment numApplicant if the user chooses to capture another applicant
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 'Y' for Yes or 'N' for No.");
                    }
                } // end of While Loop
            }// end of main while loop

        }// end of method

        static void Check()
        {
            Load();
            Console.WriteLine("\n");

            Console.Clear();
            //Game token qualification criteria
            Console.WriteLine("Criteria to qualify for a game token: \n ");
            Console.WriteLine("1. If you are above 18 you must be employed or if you are underage your parents must be employed.");
            Console.WriteLine("2. You have to be a loyal customer for at least 2 years.");
            Console.WriteLine("3. You have to meet the following requirements, arcade score of 2000, bowling score of 1500, or a combined average of 1200.");
            Console.WriteLine("4. You need to consume at least 3 pizzas a month.");
            Console.WriteLine("5. You need to consume at least 4 slush puppies a month and Your flavour preference can not be a 'Gooey Gulp Galore'.");

            //Variables
            int choice;
            bool Qualifies = false;
            TokensRewarded.Clear();
            TokenDenied = 0;
            TokenGranted = 0;

            for (int i = 0; i < NumApplicant; i++)
            { // loop to check if applicant qualifies for a token



                if (EmploymentStatus[i] == "Y" || (ApplicantAge[i] < 18 && ParentsEmploymentStatus[i] == "Y")) //test age/employment/parentsemployment
                {
                    if (DaysAsMember[i] > 730)
                    {
                        if (ApplicantHighScore[i] > 2000 || BowlingHighScore[i] > 1500 || ((ApplicantHighScore[i] + BowlingHighScore[i]) / 2) > 1200) //test arcade and bowling high score
                        {
                            if (PizzasConsumed[i] / (DaysAsMember[i] / 30) >= 3) // test pizzas consumed

                            {
                                if ((SlushysConsumed[i] / (DaysAsMember[i] / 30) < 4) || SlushyPreference[i] == "Gooey Gulp Galore") // test slushies consumed and slushy prefrence

                                {
                                    Qualifies = false;
                                }
                                else
                                {
                                    Qualifies = true;
                                }

                            }
                            else
                            {

                                Qualifies = false;
                            }



                        }
                        else
                        {
                            Qualifies |= false;
                        }


                    }
                    else
                    {
                        Qualifies = false;

                    }

                }
                else
                {
                    Qualifies = false;

                }

                if (Qualifies == true)
                {
                    TokensRewarded.Add("Yes");
                    TokenGranted++;  // increase tokens granted

                }
                else
                {
                    TokensRewarded.Add("No");
                    TokenDenied++; // increase tokens denied
                }



            }

            Datachecked = true;

            Console.WriteLine("Press 0 to return to menu. ");
            choice = int.Parse(Console.ReadLine());
            if (choice == 0)
            {
                Main(null);
            }
        }

        static void Display()
        {
            Load();
            Console.WriteLine("\n");

            if ((Datachecked == false && DataCaptured == false) || (Datachecked == false && DataCaptured == true) || (Datachecked == true && DataCaptured == false))
            {
                Console.Clear();
                Console.WriteLine("Check data first or submit an applicant");


            }

            else
            {
                Console.Clear();
                Console.WriteLine("Total tokens rewarded: " + TokenGranted);
                Console.WriteLine("Total tokens denied: " + TokenDenied);
                Console.WriteLine("");
                Console.WriteLine("Stats detail");



                for (int i = 0; i < NumApplicant; i++)
                {
                    // display stats


                    Console.Write("Name: " + ApplicantName[i]);
                    Console.Write(" Arcade high score: " + ApplicantHighScore[i]);
                    Console.Write(" Bowling high score: " + BowlingHighScore[i]);
                    Console.Write(" Average: " + ((ApplicantHighScore[i] + BowlingHighScore[i]) / 2));
                    Console.WriteLine(" Token granted: " + TokensRewarded[i]);





                }
            }



            Console.WriteLine("Press 0 to go back to the menu");
            int pick = int.Parse(Console.ReadLine());

            if (pick == 0)
            {
                Main(null);
            }
            Console.ReadLine();
        }

        static void AveragePizzas()
        {
            Load();
            Console.WriteLine("\n");

            Console.Clear();

            if (DataCaptured == true)
            {
                int TotalPizzas = 0;
                double AveragePizzas = 0;

                for (int i = 0; i < NumApplicant; i++)
                {
                    TotalPizzas += PizzasConsumed[i];
                }

                AveragePizzas = TotalPizzas / NumApplicant;
                Console.WriteLine($"Average Pizzas since first visit: {AveragePizzas}");

                Console.WriteLine("Press 0 to go back to the menu");
                int pick = int.Parse(Console.ReadLine());

                if (pick == 0)
                {
                    Main(null);
                }
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Please submit an application first");
                Console.WriteLine("Press any key");
                Console.ReadLine();

                if (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                    Main(null);
                }
            }
        }

        static void DisplayAgeRange()
        {
            Load();
            Console.WriteLine("\n");

            if (ApplicantAge.Count == 0)
            {
                Console.WriteLine("No applicants available.");
                Console.WriteLine("Press 0 to go back to the menu");
                int pick = int.Parse(Console.ReadLine());
                if (pick == 0)
                {
                    Main(null);
                }
                return;
            }
            int youngest = ApplicantAge[0];
            int oldest = ApplicantAge[0];

            foreach (int age in ApplicantAge)
            {
                if (age < youngest)
                {
                    youngest = age;
                }
                if (age > oldest)
                {
                    oldest = age;
                }
            }
            Console.Clear();
            Console.WriteLine($"Youngest Applicant: {youngest}");
            Console.WriteLine($"Oldest Applicant: {oldest}");

            Console.WriteLine("Press 0 to go back to the menu");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 0)
            {
                Main(null);
            }
            Console.ReadLine();
        }

        static void Load()
        {
            //This method runs in the background and handles the load time and display a load animation 
            string[] Loading = new string[100];
            Console.WriteLine("Loading.....");
            foreach (string s in Loading)
            {
                Console.Write("*");
            }

            Thread.Sleep(5000);// This number is the amount of wait time in milliseconds 
        }

        static void LongTermLoyalty()//qualifies for a long-term loyalty award.
        {
            Load();
            Console.WriteLine("\n");

            if (DaysAsMember.Count == 0)
            {
                Console.WriteLine("No applicants available.");
                Console.WriteLine("Press 0 to go back to the menu");
                int pick = int.Parse(Console.ReadLine());
                if (pick == 0)
                {
                    Main(null);
                }
                return;
            }

            Console.Clear();
            for (int i = 0; i < NumApplicant; i++)
            {
                if (DaysAsMember[i] >= 3650) // 10 years * 365 days
                {
                    Console.WriteLine($"Applicant {ApplicantName[i]} qualifies for a long-term loyalty award with unlimited credits.");
                }
            }

            Console.WriteLine("Press 0 to go back to the menu");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 0)
            {
                Main(null);
            }

        }

        static void Email()
        {
            Load();
            Console.WriteLine("\n");

            string email;
            Console.WriteLine("Please enter your email address: ");
            email = Console.ReadLine();


            try
            {
                // Specify the email sender
                var fromAddress = new MailAddress("retroslice444@gmail.com", "RetroSlice");
                // Specify the email recipient
                var toAddress = new MailAddress(email);
                const string fromPassword = "Retroslice@123";
                const string subject = "Subscribed";
                const string body = "Hello, you have subscribed for the RetroSlice newsletter.";

                // Set up the SMTP client
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                // Create the email
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    // Send the email
                    smtp.Send(message);
                }
                Console.WriteLine(email + "you have successfully subscribe for the newsletter.");

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while sending the email: " + ex.Message);
            }
        }
        static void HighscoreUpdate()
        {
            Load();
            Console.WriteLine("\n");
            Console.Clear();

            Console.WriteLine("Enter member name: ");
            string searchName = Console.ReadLine();

            // Find the index of the applicant with the matching name
            int index = ApplicantName.FindIndex(name => name.Equals(searchName, StringComparison.OrdinalIgnoreCase));

            if (index != -1)
            {
                Console.WriteLine($"Current high score for {ApplicantName[index]}: {ApplicantHighScore[index]}");
                Console.WriteLine("Enter the new high score: ");
                if (int.TryParse(Console.ReadLine(), out int newHighScore))
                {
                    ApplicantHighScore[index] = newHighScore;
                    Console.WriteLine($"High score updated for {ApplicantName[index]} to {newHighScore}");
                }
                else
                {
                    Console.WriteLine("Invailid input.");
                }
            }
            else
            {
                Console.WriteLine("Member not found.");
            }

            Console.WriteLine("Press 0 to go back to the menu");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 0)
            {
                Main(null);
            }
        }
    }
}