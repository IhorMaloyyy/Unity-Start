using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalControl : MonoBehaviour
{
    int level;
    readonly string[] Level1Password = { "книга", "ручка", "шкаф" };
    readonly string[] Level2Password = { "дубинка", "значек", "наручники" };
    readonly string[] Level3Password = { "пульт", "ракета", "скафандр" };
    string password;
    readonly string menuHint = "Введите 'меню' для выхода";
    enum Screen {MainMenu,Password,Win};

    Screen currentScreen = Screen.MainMenu;


    void Start()
    {
        ShowMainMenu("User");
    }

    private void ShowMainMenu(string playerName)
    {
        currentScreen = Screen.MainMenu;
        level = 0;
        Terminal.ClearScreen();
        Terminal.WriteLine($"Здоров, {playerName}!");
        Terminal.WriteLine("Какой терминал хакнешь сегодня?");
        Terminal.WriteLine(" ");
        Terminal.WriteLine("Введи 1 - городская библиотека");
        Terminal.WriteLine("Введи 2 - полицейский участок");
        Terminal.WriteLine("Введи 3 - космический корабль");
    }
    

    private void OnUserInput(string input)
    {
        if (input == "меню")
        {
            ShowMainMenu("рад видеть тебя снова");
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
    
    private void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            GameStart();
        }
        else
        {
        Terminal.WriteLine("Введите правельное значение");
        }
    }
    private void GameStart()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine($"Вы выбрали {level} уровень");
        Terminal.WriteLine(menuHint);
        Terminal.WriteLine("Введите пароль");
        switch (level)
        {
            case 1:
                password = Level1Password[Random.Range(0,Level1Password.Length)];
                break;
            case 2:
                password = Level2Password[Random.Range(0, Level2Password.Length)];
                break;
            case 3:
                password = Level3Password[Random.Range(0, Level3Password.Length)];
                break;
        }
        Terminal.WriteLine($"Подсказка: {password.Anagram()}");

    }

    private void CheckPassword(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine("Вы победили!");
            ShowWinScreen();
        }
        else
        {
            GameStart();
        }
    }

    private void ShowWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        Reward();
    }
    private void Reward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Пароль верный.Держите вашу книгу");
                Terminal.WriteLine(
                    @"
    _______
   /      /,
  /      //
 /______//
(______(/
                    
                    ");
                Terminal.WriteLine(menuHint);
                break;
            case 2:
                Terminal.WriteLine("Пароль верный.Держите ваш ПК");
                Terminal.WriteLine(
                    @"
   _______
        |.-----.|
        ||x . x||
        ||_.-._||
        `--)-(--`
       __[=== o]___
      |:::::::::::|\
      `-=========-`()
                    ");
                Terminal.WriteLine(menuHint);
                break;

            case 3:
                Terminal.WriteLine("Пароль верный.Ваш Йода");
                Terminal.WriteLine(
                    @"
    __.-._
    '-._*7*
     / *.-c
     |  / T
snd _)_ / LI
                    ");
                Terminal.WriteLine(menuHint);
                break;



        }
    }


}
