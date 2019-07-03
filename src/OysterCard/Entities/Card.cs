namespace OysterCard
{
    public class Card
    {
        private float _balance;

        public Card(float balance)
        {
            _balance = balance;
        }

        public Card()
        {
            _balance = 0;
        }

        public float GetBalance()
        {
            return _balance;
        }

        public void SetBalance(float balance)
        {
            _balance = balance;
        }

        public void AddMoney(float money)
        {
            _balance = _balance + money;
        }

        public void Out(float fare) 
        {
            Validate(fare);
            _balance = _balance - fare;
        }

        public void Validate(float fare)
        {
            if (_balance < fare)
                throw new FareException("You don't have enough balance!");
        }

        public void In(float f)
        {
            _balance = _balance + f;
        }
    }
}
