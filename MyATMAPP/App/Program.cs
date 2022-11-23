﻿using MyATMAPP.AppUI;

namespace MyATMAPP.App
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DisplayScreen.Welcome();
            ATMApp atmApp = new ATMApp();
            atmApp.InitializeData();
            atmApp.CheckUserCardNumberAndPassword();
            atmApp.Welcome();

            AppUtility.ClickEnterToContinue();
        }
    }
}