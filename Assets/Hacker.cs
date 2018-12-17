using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game config data
    const string menuHint = "You may type menu at any time";

    string[] level1Passwords = { "education","teachers","curriculum","syllabus"};
    string[] level2Passwords = { "convict", "prisoner", "manslaughter", "homicide" };
    string[] level3Passwords = { "convict", "prisoner", "manslaughter", "homicide" };

    // Game state
    int level;
    string password;

    enum Screen { MainMenu, Password, Win }
    Screen currentScreen = Screen.MainMenu;


	// Use this for initialization
	void Start ()
    {
        ShowMainMenu();
    }

    // Use every frame
    void Update()
    {

    }

    // takes user to main menu screen
    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;

        // Clears terminal screen
        Terminal.ClearScreen();

        // adds intro messages to terminal
        Terminal.WriteLine("Welcome to cmd_Line H4xor,");
        Terminal.WriteLine("What would you like to hax?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for local School");
        Terminal.WriteLine("Press 2 for Police Station");
        Terminal.WriteLine("Press 3 for City Hall");
        Terminal.WriteLine("Enter your selection:...");


    }
    void OnUserInput(string input)
    {
        if (input == "menu") // we can always go direct to main menu
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);

        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);

        }

    }

    void RunMainMenu(string input)
    {
        bool isvalidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isvalidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Command unknown");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();

        Terminal.WriteLine("Enter your Password, hint:" + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            default:
                Debug.LogError("Invailed Level");
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("Have a Book...");
                Terminal.WriteLine(@"
    ______
   /     //
  /     //
 /_____//
(_____(/
"                                   );
                break;
            case 2:
                Terminal.WriteLine("You found some handcuffs!");
                Terminal.WriteLine(@"
                           
      .::::::::::.                          .::::::::::.
    .::::''''''::::.                      .::::''''''::::.
  .:::'          `::::....          ....::::'          `:::.
 .::'             `:::::::|        |:::::::'             `::.
.::|               |::::::|_ ___ __|::::::|               |::.
`--'               |::::::|_()__()_|::::::|               `--'
 :::               |::-o::|        |::o-::|               :::
 `::.             .|::::::|        |::::::|.             .::'
  `:::.          .::\-----'        `-----/::.          .:::'
    `::::......::::'                      `::::......::::'
      `::::::::::'                          `::::::::::'
");
                break;
            case 3:
                Terminal.WriteLine("You got the Key to the City!!!!");
                Terminal.WriteLine("YOU HAVE WON THE GAME, WELL DONE");
                Terminal.WriteLine(@"
 _
/0 \_______
\__/-=' = '
");
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
    }
}
