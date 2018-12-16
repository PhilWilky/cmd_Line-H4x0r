using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game config data
    string[] level1Passwords = { "Education","Teachers","curriculum","syllabus"};
    string[] level2Passwords = { "Convict", "Prisoner", "Manslaughter", "Homicide" };

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
        Terminal.WriteLine("Enter your selection:");


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
        if (input == "1")
        {
            level = 1;
            password = level1Passwords[2]; //todo make random later
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            password = level2Passwords[2]; //todo make random later
            StartGame();

        }
        else
        {
            Terminal.WriteLine("Command unknown");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;

        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please enter your Password");
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine("Well done!");
        }
        else
        {
            Terminal.WriteLine("Sorry, wrong password!");
        }
    }
}
