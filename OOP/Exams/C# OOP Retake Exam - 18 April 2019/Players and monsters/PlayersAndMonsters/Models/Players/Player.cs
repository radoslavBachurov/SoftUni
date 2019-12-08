using System;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;


namespace PlayersAndMonsters.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private ICardRepository cardRepository;
        private bool isDead;

        public Player(string username, int health, ICardRepository cardRepo)
        {
            this.Username = username;
            this.Health = health;
            this.cardRepository = cardRepo;
        }

        public ICardRepository CardRepository => this.cardRepository;

        public string Username
        {
            get => this.username;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Player's username cannot be null or an empty string.");
                }
                this.username = value;
            }
        }

        public int Health
        {
            get => this.health;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player's health bonus cannot be less than zero.");
                }
                this.health = value;
            }
        }

        public bool IsDead => this.isDead;

        public void TakeDamage(int damagePoints)
        {
            if (damagePoints < 0)
            {
                throw new ArgumentException("Damage points cannot be less than zero.");
            }

            if (this.Health - damagePoints <= 0)
            {
                this.Health = 0;
                isDead = true;
            }
            else
            {
                this.Health -= damagePoints;
            }
        }
    }
}
