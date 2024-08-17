using BlackJackDAL;
using BlackJackEL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCardLib
{

    /*
     * BLL connection to the DAL / DB.
     * Has all the CRUD operations for the diffrent Tables
     */
    public class BlackJackDBManager
    {
        private readonly GameDBContext dbContext;


        /*
         * Setts the connection to the DB
         */
        public BlackJackDBManager()
        {
            dbContext = new GameDBContext();
        }


        /****************************************************************/
        /***************************  Cards  ****************************/
        /****************************************************************/


        /*
         * CREATES a new Card.
         * Adds it to the cards table
         * Saves the data
         */
        public void CreateCard(Suit suit, Value value, string image)
        {
            CardEntity newCard = new CardEntity
            {
                Suit = suit,
                Value = value,
                Image = image
            };

            dbContext.Cards.Add(newCard);
            dbContext.SaveChanges();
        }


        /*
         * "READS" all the cards. Retreves all the cards in the table and return them to the deck.
         */
        public List<Card> GetAllCards()
        {
            return dbContext.Cards
                .Select(card => new Card(card.Suit, card.Value, card.Image))
                .ToList();
        }


        /*
         * "READS" a specifik card using the suit and value. Retreves all the cards in the table and return them.
         */
        public int GetCardId(Suit suit, Value value)
        {
            int cardId = dbContext.Cards
            .Where(c => c.Suit == suit && c.Value == value)
            .Select(c => c.CardID)
            .FirstOrDefault();

            if (cardId != null)
            {
                return cardId;
            }

            return -1; 
        }

       /*
        * Gets all cards fo the DataGridView
        */
        public List<CardEntity> GetAllCard()
        {
            return dbContext.Cards.ToList();
        }


        /*
         * UPDATES a card if needed in the DB. Perhaps if one wanted to change the Images
         */
        public void UpdateCard(int cardId, Suit newSuit, Value newValue, string newImage)
        {
            CardEntity cardToUpdate = dbContext.Cards.FirstOrDefault(c => c.CardID == cardId);

            if (cardToUpdate != null)
            {
                cardToUpdate.Suit = newSuit;
                cardToUpdate.Value = newValue;
                cardToUpdate.Image = newImage;

                dbContext.SaveChanges();
            }
        }


        /*
         * DELETES a Card from the DB using a cardID
         */
        public void DeleteCard(int cardID)
        {
            CardEntity cardToDelete = dbContext.Cards.FirstOrDefault(c => c.CardID == cardID);

            if (cardToDelete != null)
            {
                dbContext.Cards.Remove(cardToDelete);
                dbContext.SaveChanges();
            }
        }

        /****************************************************************/
        /**************************  Player  ****************************/
        /****************************************************************/


        /*
           * CREATES a new Player.
           * Adds it to the Player table
           * Saves the data
           */
        public void CreatePlayer(string playerName, bool winner, bool isDealer)
        {
            PlayerEntity newPlayer = new PlayerEntity
            {
                PlayerName = playerName,
                Winner = winner,
                IsDealer = isDealer
            };

            dbContext.Players.Add(newPlayer);
            dbContext.SaveChanges();
        }


        /*
         * Checks if a PLayername already exist in the DB
         */
        public bool DoesPlayerExist(string playerName)
        {
            return dbContext.Players
                .Any(player => player.PlayerName == playerName);
        }


        /*
         * READS all the players.
         * Return all the Players in the DB.
         */
        public List<PlayerEntity> GetAllPlayers()
        {
            return dbContext.Players.ToList();

        }


        /*
         * Gets the playerID of a spesifik playerName
         */
        public int GetPlayerIdByName(string playerName)
        {
            return dbContext.Players
                .Where(p => p.PlayerName == playerName)
                .Select(p => p.PlayerID)
                .FirstOrDefault();
        }


   


        /*
         * UPDATES a player using the playerID to fin the player to update.    
         */
        public void UpdatePlayer(int playerId, string newName, bool newWinner, bool newIsDealer)
        {
            PlayerEntity playerToUpdate = dbContext.Players.FirstOrDefault(p => p.PlayerID == playerId);

            if (playerToUpdate != null)
            {
                playerToUpdate.PlayerName = newName;
                playerToUpdate.Winner = newWinner;
                playerToUpdate.IsDealer = newIsDealer;

                dbContext.SaveChanges();
            }
        }


        /*
         *  DELETES a player from the DB using playerID
         */
        public void DeletePlayer(int playerId)
        {
            PlayerEntity playerToDelete = dbContext.Players.FirstOrDefault(p => p.PlayerID == playerId);

            if (playerToDelete != null)
            {
                dbContext.Players.Remove(playerToDelete);
                dbContext.SaveChanges();
            }
        }




        /****************************************************************/
        /*************************  GameCards  **************************/
        /****************************************************************/


        /*
         * CREATES the GameCards to the DB
         */
        public void AddGameCard(int gameId, int playerId, int cardId)
        {
            GameCardEntity newGameCard = new GameCardEntity
            {
                GameID = gameId,
                PlayerID = playerId,
                CardID = cardId
            };

            dbContext.GameCards.Add(newGameCard);
            dbContext.SaveChanges();
        }


        /*
         * Getts all the GameCards for the DataViewGrid
         */
        public List<GameCardEntity> GetAllGameCards()
        {
            return dbContext.GameCards.ToList();
        }


        /*
         * Gets a GameCards
         */
        public GameCardEntity GetGameCard(int gameId, int playerId, int cardId)
        {
            return dbContext.GameCards
                .FirstOrDefault(gc => gc.GameID == gameId && gc.PlayerID == playerId && gc.CardID == cardId);
        }


        /*
         * Gets the last ID in the Table
         */
        public int GetLastGameId()
        {
            int lastGameId = dbContext.GameCards
                .OrderByDescending(gc => gc.GameID)
                .Select(gc => gc.GameID)
                .FirstOrDefault();

            return lastGameId;
        }


        /*
         * UPDATES a GameCard
         */
        public void UpdateGameCard(int gameId, int playerId, int cardId, int newGameId, int newPlayerId, int newCardId)
        {
            GameCardEntity gameCardToUpdate = GetGameCard(gameId, playerId, cardId);

            if (gameCardToUpdate != null)
            {
                gameCardToUpdate.GameID = newGameId;
                gameCardToUpdate.PlayerID = newPlayerId;
                gameCardToUpdate.CardID = newCardId;

                dbContext.SaveChanges();
            }
        }


        /*
         * DELETES GameCards from the DB
         */
        public void DeletePlayerFromGameCards(int playerId)
        {
            var gameCardsToDelete = dbContext.GameCards.Where(gc => gc.PlayerID == playerId).ToList();

            foreach (var gameCard in gameCardsToDelete)
            {
                dbContext.GameCards.Remove(gameCard);
            }

            dbContext.SaveChanges();
        }
    }
}
