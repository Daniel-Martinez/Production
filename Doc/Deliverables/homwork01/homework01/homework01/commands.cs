﻿using System;

public class command
{
    public void commandReader()     //used to take in user input after file has been read
    {
        Console.WriteLine("enter a command: \n");
        string input = Console.ReadLine();
        input.ToLower();
        string[] commands = input.Split(' ');
        /*commands[0] holds the command and commands[1] holds the argument of the command*/
        switch (commands[0])
        {
            case "print":
                if (commands[1] == null)        //check if there is an argument for print
                {
                    printTarget();
                }
                else
                {
                    printTarget(commands[1]);
                }
                break;
            case "convert":
                pigConvert(commands[1]);
                break;
            case "isfriend":
                isFriend(commands[1]);
                break;
            case "exit":
                return;
                break;
            default:
                Console.WriteLine("What the deusEx: You have not entered a valid command.\n");
                break;
        }
    }

    private void isFriend(string p)
    {
        throw new NotImplementedException();
    }

    private void pigConvert(string p)
    {
        throw new NotImplementedException();
    }

    private void printTarget()
    {
        throw new NotImplementedException();
    }
}
