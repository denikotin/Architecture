namespace Architecture
{
    public class BankInteractor : Interactor
    {
        private BankRepository _bankRepository;

        public int Coins => _bankRepository.Coins;

        public override void OnCreate()
        {
            base.OnCreate();
            _bankRepository = Game.GetRepository<BankRepository>();
        }

        public override void Initialize()
        {
            Bank.Initialize(this);
        }

        public bool isEnoughCoins(int value)
        {
            return Coins >= value;
        }

        public void AddCoins(object sender, int value)
        {
             _bankRepository.Coins += value;
             _bankRepository.Save();
        }

        public void SpendCoins(object sender, int value)
        {
            _bankRepository.Coins -= value;
            _bankRepository.Save();
        }

    }

}
