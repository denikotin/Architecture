using Unity.VisualScripting;
using UnityEngine;

namespace Architecture
{
    public class BankRepository : Repository
    {
        private const string KEY = "BANK_KEY";
        public int Coins { get; set; }

        public override void OnCreate()
        {
           
        }

        public override void Initialize()
        {
            Coins = PlayerPrefs.GetInt(KEY, 0);
        }

        public override void OnStart()
        {

        }

        public override void Save()
        {
            PlayerPrefs.SetInt(KEY,Coins);
        }
    }

}

