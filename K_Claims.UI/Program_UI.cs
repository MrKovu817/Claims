
public class Program_UI
{
    private readonly ClaimRepository _clRepo = new ClaimRepository();
    public void Run()
    {
        RunApplication();
    }

    private void RunApplication()
    {
        while (true)
        {
            Clear();
            WriteLine("=================\n" +
                "1. Add Claim\n" +
                "2. View Next Claim\n" +
                "3. View All Claims\n" +
                "4. Process Claim\n" +
                "0. CloseApp\n");

            var userInput = ReadLine();
            switch (userInput)
            {
                case "1":
                    AddClaim();
                    break;
                case "2":
                    ViewNextClaim();
                    break;
                case "3":
                    ViewAllClaims();
                    break;
                case "4":
                    ProcessClaim();
                    break;
                case "0":
                    WriteLine("Thanks, Press any key");
                    ReadKey();
                    break;
                default:
                    WriteLine("Invalid Selection, Press any key.");
                    ReadKey();
                    break;
            }
        }
    }

    private void ProcessClaim()
    {
        Console.Clear();
        Console.WriteLine("Do you want to process this gremlin? y/n");
        ShowClaimData();

        var userInput = Console.ReadLine();
        if (userInput == "Y".ToLower())
        {
            _clRepo.ProcessClaim();
        }
        else
        {
            System.Console.WriteLine("Returning to Main Menu.");
        }

        Console.ReadKey();
    }

    private void ViewAllClaims()
    {
        Console.Clear();
        foreach (ClaimRepository claim in _clRepo.GetClaims())
        {
            System.Console.WriteLine(claim);
        }

        Console.ReadKey();
    }

    private void ViewNextClaim()
    {
        Console.Clear();
        ShowClaimData();
        Console.ReadKey();
    }
    private void ShowClaimData()
    {
        System.Console.WriteLine(_clRepo.GetClaim());
    }


    private void AddClaim()
    {
        Console.Clear();

        ClaimRepository claim = new ClaimRepository();

        Console.WriteLine("Claim Name:");
        claim.Name = Console.ReadLine();

        if (_clRepo.AddClaimToDatabase(claim))
        {
            Console.Write("Success!");
        }
        else
        {
            Console.Write("Fail!");
        }

        Console.ReadKey();
    }
}
