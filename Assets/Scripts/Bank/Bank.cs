using System;
using System.Data;
using UnityEditor;

namespace Architecture
{
    public static class Bank 
    {
        //public static event Action OnBankInitializedEvent;

        private static BankInteractor _bankInteractor;
        public static int Coins { get { CheckInitialize(); return _bankInteractor.Coins; } }
        public static bool isInitialize { get; private set; }

        public static void Initialize(BankInteractor bankInteractor)
        {
            _bankInteractor = bankInteractor;
            isInitialize = true;

            //OnBankInitializedEvent?.Invoke();
        }

        public static bool isEnoughCoins(int value)
        {
            CheckInitialize();
            return _bankInteractor.isEnoughCoins(value);
        }

        public static void AddCoins(object sender, int value)
        {
            CheckInitialize();
            _bankInteractor.AddCoins(sender, value);
        }

        public  static void SpendCoins(object sender, int value)
        {
            CheckInitialize();
            _bankInteractor.SpendCoins(sender, value);
        }

        public static void CheckInitialize()
        {
           if(!isInitialize)
            {
                throw new Exception("Bank is not initialized.");
            }
        }
    }

}
