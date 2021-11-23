using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalControl : MonoBehaviour
{
    int level;
    readonly string[] Level1Password = { "�����", "�����", "����" };
    readonly string[] Level2Password = { "�������", "������", "���������" };
    readonly string[] Level3Password = { "�����", "������", "��������" };
    string password;
    readonly string menuHint = "������� '����' ��� ������";
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
        Terminal.WriteLine($"������, {playerName}!");
        Terminal.WriteLine("����� �������� ������� �������?");
        Terminal.WriteLine(" ");
        Terminal.WriteLine("����� 1 - ��������� ����������");
        Terminal.WriteLine("����� 2 - ����������� �������");
        Terminal.WriteLine("����� 3 - ����������� �������");
    }
    

    private void OnUserInput(string input)
    {
        if (input == "����")
        {
            ShowMainMenu("��� ������ ���� �����");
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
        Terminal.WriteLine("������� ���������� ��������");
        }
    }
    private void GameStart()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine($"�� ������� {level} �������");
        Terminal.WriteLine(menuHint);
        Terminal.WriteLine("������� ������");
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
        Terminal.WriteLine($"���������: {password.Anagram()}");

    }

    private void CheckPassword(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine("�� ��������!");
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
                Terminal.WriteLine("������ ������.������� ���� �����");
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
                Terminal.WriteLine("������ ������.������� ��� ��");
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
                Terminal.WriteLine("������ ������.��� ����");
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
