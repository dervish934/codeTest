using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Hacker : MonoBehaviour
{

    int level;
    public enum Estado {MainMenu, Password, Win };
    public Estado EstadoActual;
    string password;

    string playerHint = "You can type 'Menu' at any time";

    string[] level1passwords = {"hola", "adios", "hasta luego", "waldo", "wanchez" };
    string[] level2passwords = {"bingo bank", "aquabingo", "mardi jazz", "magic garden" };
    string[] level3passwords = { "pink floyd", "metallica", "led zepellin", "red hot chilli peppers", "queen" };

     // Start is called before the first frame update
    void Start()

    {
        //var gretting = "Hello Dervish";
        // Terminal.WriteLine(gretting);
        ShowMainMenu("Bruno");
        print(level1passwords.Length);
        
    
        
        
    }


    void ShowMainMenu(string name)
    {

        EstadoActual = Estado.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome " + name);
        Terminal.WriteLine("THIS IS DREIDEL INTERACTIVE");
        Terminal.WriteLine("WHAT WOULD YOU LIKE TO DO?");

        Terminal.WriteLine("-Tinos");
        Terminal.WriteLine("-Bingos");
        Terminal.WriteLine("-Slots");

        Terminal.WriteLine("Enter your selection:");

    }



    // Update is called once per frame

    void OnUserInput(string input)
    {

        if (input == "Menu")
        {
            ShowMainMenu("Josue");
          
            

        }
        else if (EstadoActual == Estado.MainMenu)
        {
            RunMainMenu(input);
        }else if (EstadoActual == Estado.Password)
        {
            PasswordCheck(input);

        
        }

    }
    
    void RunMainMenu(string input)
    {


        bool onValidLevel = (input == "1" || input == "2" || input == "3");
            if (onValidLevel)
        {
            level = int.Parse(input);
            GameStart(input);

        }   
        else if (input == "007")
        {


            Terminal.WriteLine("Hello Mr Bond");
        }
        else
        {

            Terminal.WriteLine("Please choose a valid level");
        }

    }







    void GameStart(string input)
    {
        EstadoActual = Estado.Password;
        Terminal.ClearScreen();
       
       


        switch (level)
        {
            case 1:
                password = level1passwords[Random.Range(0, level1passwords.Length)];
                break;

            case 2:
                password = level2passwords[Random.Range(0, level2passwords.Length)];
                break;

            case 3:
                password = level3passwords[Random.Range(0, level3passwords.Length)];
                break;


            default: Terminal.WriteLine("Enter a valid input");
                break;

        }

        Terminal.WriteLine("Enter your password " + password.Anagram());
        Terminal.WriteLine(playerHint);

    }

 
    void PasswordCheck(string input)
    {

        if (input == password)
        {
            AscciCode();
            

        }
        else
        {
            GameStart(input);
            //Terminal.WriteLine("Wrong Password you dreidel noob!");

        }

    }

     void AscciCode()
    {
        ShowLevelReward();
        Terminal.WriteLine(" 'Menu' to play again");
        EstadoActual = Estado.Win;


    }

      void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("CONGRATS YOU WIN!");
                Terminal.WriteLine(@"
                -----------
               /         //
              /         //
             / ------- //
            (_________(/
                ");
                break;

            case 2:
                Terminal.WriteLine("CONGRATS YOU WIN!");
                Terminal.WriteLine(@"
                -----------
               /    gtret     //
              /  erte       //
             / ------- //
            (_________(/

                ");

                break;


            case 3:
                Terminal.WriteLine("CONGRATS YOU WIN!");
             Terminal.WriteLine(@"
  ___________________
   /  __________________()
  /  /|_________________ 
 /  /_/________________()
/______________________
|_____________________() 
       ");
                break;


        }

        
    }

    void Update()
    {

       
        
    }
}
