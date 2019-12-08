
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using PlayersAndMonsters.Models.Players;
using System.Collections.Generic;
using PlayersAndMonsters.Models.Cards.Contracts;
using System.Linq;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            if (attackPlayer is Beginner)
            {
                attackPlayer.Health += 40;
                IList<ICard> attackPlayerCards = attackPlayer.CardRepository.Cards.ToList();
                attackPlayerCards.Select(x => x.DamagePoints += 30);
            }

            if (enemyPlayer is Beginner)
            {
                enemyPlayer.Health += 40;
                IList<ICard> enemyPlayerCards = enemyPlayer.CardRepository.Cards.ToList();
                enemyPlayerCards.Select(x => x.DamagePoints += 30);
            }

            attackPlayer.Health += attackPlayer.CardRepository.Cards.Sum(x => x.HealthPoints);
            enemyPlayer.Health += enemyPlayer.CardRepository.Cards.Sum(x => x.HealthPoints);

            while (!attackPlayer.IsDead || !enemyPlayer.IsDead)
            {
                enemyPlayer.TakeDamage(attackPlayer.CardRepository.Cards.Sum(x => x.DamagePoints));

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                attackPlayer.TakeDamage(enemyPlayer.CardRepository.Cards.Sum(x => x.DamagePoints));

                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }
    }
}
