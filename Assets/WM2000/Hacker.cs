using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game state
    int level;

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
        Terminal.WriteLine("Press 1 for town Library");
        Terminal.WriteLine("Press 2 for local School");
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

    }

    void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
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
}
