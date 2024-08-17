using BlackJackDAL;
using BlackJackEL;
using GameCardLib;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Assignment4_Blackjack
{
    public partial class BlackJackForm : Form
    {
        private Deck deck;
        private Hand playerHand;
        private Hand DealerHand;
        private Player player;
        private Player Dealer;
        private int cardIndex;
        int PlayerScore;
        int DealerScore;
        private BlackJackDBManager BJBLL;
        string playerName;
        int gameID;


        public BlackJackForm()
        {
            //Initialise
            InitializeComponent();
            BJBLL = new BlackJackDBManager();
            setPlayerName();
            //AddStandardDeckToDatabase();
            deck = new Deck(BJBLL.GetAllCards());
            gameID = BJBLL.GetLastGameId();
            gameID= gameID + 1;


            //Fix dataGridView
            dataGridView1.DataSource = BJBLL.GetAllCard();
            dataGridView1.ReadOnly = true;
            gameCardGridView.ReadOnly = true;
            dataGridView3.ReadOnly = true;
            updateTabelView();

            //Fix player hand and subscribe
            playerHand = new Hand(deck);
            playerHand.CardDrawn += PlayerHand_CardDrawn;
            playerHand.Standing += PlayerHand_Standing;
            playerHand.Bust += PlayerHand_Bust;
            player = new Player(playerHand, false, false, false);

            //Fix Dealer hand and subscribe
            DealerHand = new Hand(deck);
            Dealer = new Player(DealerHand, false, false, true);
            int oldDealerID = BJBLL.GetPlayerIdByName("Dealer");
            BJBLL.DeletePlayer(oldDealerID);
            BJBLL.CreatePlayer("Dealer", false, true);
            DealerHand.Bust += DealerHand_Bust;

            //Fix backsideImages
            cardIndex = 0;
            DealerPicture1.Image = Image.FromFile("BackSide.png");
            DealerPicture2.Image = Image.FromFile("BackSide.png");
            PlayerpictureBox1.Image = Image.FromFile("BackSide.png");
            PlayerpictureBox2.Image = Image.FromFile("BackSide.png");

            StandButton.Enabled = false;
            HitButton.Enabled = false;
        }

        /*
         * Starts the game
         * Gives player 2 cards And dealer 1
         * Updates GUI
         * sets Labels and disables buttons
         */
        private void StartButton_Click(object sender, EventArgs e)
        {
            deck.Shuffle();
            Card card1 = deck.DrawCard();
            Card card2 = deck.DrawCard();
            Card card3 = deck.DrawCard();
            playerHand.AddCard(card1);
            playerHand.AddCard(card2);
            DealerHand.AddCard(card3);

            addGameCard(card1);
            addGameCard(card2);

            DealerLabel.Text = $"Dealer amount: {DealerHand.CalculateScore()}";
            PlayerLabel.Text = $"Player amount: {playerHand.CalculateScore()}";

            DisplayPlayerHand();

            StartButton.Enabled = false;
            StandButton.Enabled = true;
            HitButton.Enabled = true;
        }

        /*
         * Shuffels deck
         */
        private void ShuffleButton_Click(object sender, EventArgs e)
        {
            deck.Shuffle();
        }

        /****************************************************************/
        /***************************  Hit  ******************************/
        /****************************************************************/

        /*
         * Button for "Hitting"
         * Player gets a new card "from Dealer"
         */
        private void HitButton_Click(object sender, EventArgs e)
        {
            Card card = deck.DrawCard();
            playerHand.AddCard(card);
            addGameCard(card);
        }

        /*
         * Event for when cardd is drawn
         * Updates GUI
         * Sets lables
         * Checks if player gets automatic blackjack on start (Would be greater payour return)
         */
        private void PlayerHand_CardDrawn(Card card)
        {
            DisplayPlayerHand();

            PlayerScore = playerHand.CalculateScore();
            DealerScore = DealerHand.CalculateScore();
            DealerLabel.Text = $"Dealer amount: {DealerScore}";
            PlayerLabel.Text = $"Player amount: {PlayerScore}";


            if (PlayerScore == 21 && playerHand.Cards.Count == 2)
            {
                player.isFinished = true;
                playerHand.Stand();
                MessageBox.Show("Blackjack! You win!", "Congratulations!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PlayerWinDBUpdate();
            }
        }

        /*
         * Button for player Busts
         * Displays message of bust
         * Player is finished playing
         */
        private void PlayerHand_Bust(object sender, EventArgs e)
        {
            // Handle the event when the player goes bust
            // For example, end the current game or perform other actions
            MessageBox.Show("You have gon Bust  Dealer wins", "You Loose", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            player.isFinished = true;
            DealerWinDBUpdate();
        }

        /****************************************************************/
        /*************************  Stand  ******************************/
        /****************************************************************/

        /*
         * Button for player stand
         * Calls upon playerhands Stand
         */
        private void StandButton_Click(object sender, EventArgs e)
        {
            playerHand.Stand();
        }

        /*
         * Event for player standing
         * Stands and its dealers turn
         */
        private void PlayerHand_Standing(object sender, EventArgs e)
        {
            DealerTurn();
            player.isFinished = true;
            HitButton.Enabled = false;
            StandButton.Enabled = false;
        }


        /****************************************************************/
        /*************************  Dealer  *****************************/
        /****************************************************************/

        /*
         * Dealers turn to play
         * Plays untill Dealer stands on 17 / Busts / gets more points then player
         */
        private void DealerTurn()
        {
            if (PlayerScore == 21 && playerHand.Cards.Count == 2) //If player automaticly gets BlackJack on start he wins
            {
                Dealer.isFinished = true;
            }
            else if (PlayerScore > 21) //If player bust game is done
            {
                Dealer.isFinished = true;
                DealerWinDBUpdate();
            }
            else //Else dealer plays
            {
                while (DealerScore < 17) //Dealer must stand on 17 and must draw to 16
                {
                    DealerHand.AddCard(deck.DrawCard());
                    DealerScore = DealerHand.CalculateScore();
                }

                DisplayPlayerHand();
                DealerLabel.Text = $"Dealer amount: {DealerScore}";

                if (DealerScore == PlayerScore) //PLayer and Dealer has same score
                {
                    MessageBox.Show("It's a draw!", "Draw", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (DealerScore > PlayerScore && DealerScore <= 21) //Dealer has more than Player (Player lose)
                {
                    MessageBox.Show("Dealer wins!", "You Lose", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    DealerWinDBUpdate();
                }
                else if (DealerScore < PlayerScore) //If dealer has less points then player
                {
                    MessageBox.Show("You win!", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PlayerWinDBUpdate();
                }
            }

            Dealer.isFinished = true;
        }


        //Event when Dealer Busts
        private void DealerHand_Bust(object sender, EventArgs e)
        {
            DealerLabel.Text = $"Dealer amount: {DealerScore}";
            DisplayPlayerHand();
            MessageBox.Show("Dealer has gone Bust! You win!", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Dealer.isFinished = true;
            PlayerWinDBUpdate();
        }

        /****************************************************************/
        /**********************  General Stuff  *************************/
        /****************************************************************/

        /*
         *  Updates the Dealer to display winner in the DB
         */
        public void DealerWinDBUpdate()
        {
            int DealerID = BJBLL.GetPlayerIdByName("Dealer");
            BJBLL.UpdatePlayer(DealerID, "Dealer", true, true);
            updateTabelView();
        }

        /*
         * Updates the current player to display winner in the DB
         */
        public void PlayerWinDBUpdate()
        {
            int playerID = BJBLL.GetPlayerIdByName(playerName);
            BJBLL.UpdatePlayer(playerID, playerName, true, false);
            updateTabelView();
        }

        /*
         * Updates the dataGridView for Player and GameCard tables
         */
        public void updateTabelView()
        {
            dataGridView3.DataSource = BJBLL.GetAllPlayers();
            gameCardGridView.DataSource = BJBLL.GetAllGameCards();
        }

        /*
         * Method to set a players name in the GUI and the DB.
         * Checks if name exist in DB if yes re-type name.
         * else it adds the new player to db.
         * CREATES a new player
         */
        public void setPlayerName()
        {
            while (true)
            {
                playerName = InputDialog("Enter Username");
                bool playerExists = BJBLL.DoesPlayerExist(playerName);

                if (playerExists)
                {
                    MessageBox.Show("Sorry, this username already exists. Please choose a different name.");
                }
                else
                {
                    break;
                }
            }
            playerNameLabel.Text = $"PlayerName: {playerName} ";
            BJBLL.CreatePlayer(playerName, false, false);
            updateTabelView();

        }

        /*
         * Method for GUI component for user tp type in username or Player to delete
         */
        private static string InputDialog(string prompt)
        {
            return Microsoft.VisualBasic.Interaction.InputBox(prompt, "Enter Username for Player: ");
        }


        /*
         * Same as setPlayerName() for when a alrready loggin in Player wants to create a new profile
         * CREATES a new player
         */
        private void newPlayerBTN_Click(object sender, EventArgs e)
        {

            while (true)
            {
                playerName = InputDialog("Enter Username");
                bool playerExists = BJBLL.DoesPlayerExist(playerName);

                if (playerExists)
                {
                    MessageBox.Show("Sorry, this username already exists. Please choose a different name.");
                }
                else
                {
                    break;
                }
            }
            playerNameLabel.Text = $"PlayerName: {playerName} ";
            BJBLL.CreatePlayer(playerName, false, false);
            updateTabelView();
        }


        /*
         * Button for when player only want to UPDATE (change) its name.
         */
        private void changeNameBTN_Click(object sender, EventArgs e)
        {
            int playerID = BJBLL.GetPlayerIdByName(playerName);
            while (true)
            {
                playerName = InputDialog("Enter New Username");
                bool playerExists = BJBLL.DoesPlayerExist(playerName);

                if (playerExists)
                {
                    MessageBox.Show("Sorry, this username already exists. Please choose a different name.");
                }
                else
                {
                    break;
                }
            }
            playerNameLabel.Text = $"PlayerName: {playerName} ";
            BJBLL.UpdatePlayer(playerID, playerName, true, false);
            updateTabelView();
        }


        /*
         * Method to Delete a user from the DB.
         * Askes user if its sure.
         * Then checks if userinpuit is the current player. IF yes displays it cant delte current Player
         * Else it deltes the Player from the Player table and then from GameCards
         * Then updates the DataGridView
         */
        private void DeletePlayerBTN_Click(object sender, EventArgs e)
        {
            DialogResult anwser = MessageBox.Show("You are about to delte a Player! \n Are you sure?", "Warning", MessageBoxButtons.YesNo);

            if (anwser == DialogResult.Yes)
            {
                string playerToDelete = InputDialog("Enter User for delete");
                if (playerToDelete == playerName)
                {
                    MessageBox.Show("Sorry you cant delete current Player");
                }
                else
                {
                    int playerID = BJBLL.GetPlayerIdByName(playerToDelete);
                    BJBLL.DeletePlayer(playerID);
                    BJBLL.DeletePlayerFromGameCards(playerID);
                    updateTabelView();
                }

            }
        }


        /*
         * When a player draws a card it adds it to GameCard Table.
         * Gets the player id and the card id.
         */
        public void addGameCard(Card card)
        {
            int playerID = BJBLL.GetPlayerIdByName(playerName);
            int cardID = BJBLL.GetCardId(card.Suit, card.Value);

            BJBLL.AddGameCard(gameID, playerID, cardID);
            updateTabelView();
        }

        /*
         * Method for adding a new card to the UI.
         * Displays for dealer and Player
         * Converts card values to ex Jack to J, Five to 5 and then converts Clubs to C
         */
        private void DisplayPlayerHand()
        {
            ClearPictureBoxes();

            for (int i = 0; i < playerHand.Cards.Count; i++)
            {
                // Finds the PictureBox called PlayerpictureBoxI where I is dynamic (PlayerpictureBox1,PlayerpictureBox2..PlayerpictureBox5..etc)
                PictureBox PlayerpictureBox = Controls.Find($"PlayerpictureBox{i + 1}", true).FirstOrDefault() as PictureBox;
                if (PlayerpictureBox != null)
                {
                    string cardName;

                    //Converts the Jack,Queen,King,Ace into J,Q,K,A for the Images            
                    if (playerHand.Cards[i].Value >= Value.Two && playerHand.Cards[i].Value <= Value.Ten)
                    {
                        cardName = $"{(int)playerHand.Cards[i].Value}{playerHand.Cards[i].Suit.ToString().Substring(0, 1)}.png";
                    }
                    else //Converts for example Two = 2 , Five = 5      
                    {
                        cardName = $"{playerHand.Cards[i].Value.ToString().Substring(0, 1)}{playerHand.Cards[i].Suit.ToString().Substring(0, 1)}.png";
                    }
                    //Sets the Image box to the images of the cards drawn
                    PlayerpictureBox.Image = Image.FromFile($"C:/Users/krist/source/repos/Assignment5_Blackjack/Assignment5_Blackjack/Assets/{cardName}");
                }
            }

            //Same as above but for the Dealer
            for (int i = 0; i < DealerHand.Cards.Count; i++)
            {
                PictureBox Dealerpicture = Controls.Find($"Dealerpicture{i + 1}", true).FirstOrDefault() as PictureBox;
                if (Dealerpicture != null)
                {
                    string cardName;

                    if (DealerHand.Cards[i].Value >= Value.Two && DealerHand.Cards[i].Value <= Value.Ten)
                    {
                        cardName = $"{(int)DealerHand.Cards[i].Value}{DealerHand.Cards[i].Suit.ToString().Substring(0, 1)}.png";
                    }
                    else
                    {
                        cardName = $"{DealerHand.Cards[i].Value.ToString().Substring(0, 1)}{DealerHand.Cards[i].Suit.ToString().Substring(0, 1)}.png";
                    }

                    Dealerpicture.Image = Image.FromFile($"C:/Users/krist/source/repos/Assignment5_Blackjack/Assignment5_Blackjack/Assets/{cardName}");
                }
            }
        }

        // Clears screen and player/Dealers hand
        private void ResetButton_Click(object sender, EventArgs e)
        {
            playerHand.Clear();
            DealerHand.Clear();
            cardIndex = 0;
            PlayerScore = 0;
            DealerScore = 0;
            player.isFinished = false;

            DealerLabel.Text = "Dealer amount:";
            PlayerLabel.Text = "Player amount:";

            resetImages();
            gameID++;
            StartButton.Enabled = true;
        }

        //Creates the Deck Of cards to the DB with its values and Suit and Picture
        private void AddStandardDeckToDatabase()
        {
            BJBLL.CreateCard(Suit.Clubs, Value.Two, "2C.png");
            BJBLL.CreateCard(Suit.Clubs, Value.Three, "3C.png");
            BJBLL.CreateCard(Suit.Clubs, Value.Four, "4C.png");
            BJBLL.CreateCard(Suit.Clubs, Value.Five, "5C.png");
            BJBLL.CreateCard(Suit.Clubs, Value.Six, "6C.png");
            BJBLL.CreateCard(Suit.Clubs, Value.Seven, "7C.png");
            BJBLL.CreateCard(Suit.Clubs, Value.Eight, "8C.png");
            BJBLL.CreateCard(Suit.Clubs, Value.Nine, "9C.png");
            BJBLL.CreateCard(Suit.Clubs, Value.Ten, "10C.png");
            BJBLL.CreateCard(Suit.Clubs, Value.Jack, "JC.png");
            BJBLL.CreateCard(Suit.Clubs, Value.Queen, "QC.png");
            BJBLL.CreateCard(Suit.Clubs, Value.King, "KC.png");
            BJBLL.CreateCard(Suit.Clubs, Value.Ace, "AC.png");

            BJBLL.CreateCard(Suit.Diamonds, Value.Two, "2D.png");
            BJBLL.CreateCard(Suit.Diamonds, Value.Three, "3D.png");
            BJBLL.CreateCard(Suit.Diamonds, Value.Four, "4D.png");
            BJBLL.CreateCard(Suit.Diamonds, Value.Five, "5D.png");
            BJBLL.CreateCard(Suit.Diamonds, Value.Six, "6D.png");
            BJBLL.CreateCard(Suit.Diamonds, Value.Seven, "7D.png");
            BJBLL.CreateCard(Suit.Diamonds, Value.Eight, "8D.png");
            BJBLL.CreateCard(Suit.Diamonds, Value.Nine, "9D.png");
            BJBLL.CreateCard(Suit.Diamonds, Value.Ten, "10D.png");
            BJBLL.CreateCard(Suit.Diamonds, Value.Jack, "JD.png");
            BJBLL.CreateCard(Suit.Diamonds, Value.Queen, "QD.png");
            BJBLL.CreateCard(Suit.Diamonds, Value.King, "KD.png");
            BJBLL.CreateCard(Suit.Diamonds, Value.Ace, "AD.png");

            BJBLL.CreateCard(Suit.Hearts, Value.Two, "2H.png");
            BJBLL.CreateCard(Suit.Hearts, Value.Three, "3H.png");
            BJBLL.CreateCard(Suit.Hearts, Value.Four, "4H.png");
            BJBLL.CreateCard(Suit.Hearts, Value.Five, "5H.png");
            BJBLL.CreateCard(Suit.Hearts, Value.Six, "6H.png");
            BJBLL.CreateCard(Suit.Hearts, Value.Seven, "7H.png");
            BJBLL.CreateCard(Suit.Hearts, Value.Eight, "8H.png");
            BJBLL.CreateCard(Suit.Hearts, Value.Nine, "9H.png");
            BJBLL.CreateCard(Suit.Hearts, Value.Ten, "10H.png");
            BJBLL.CreateCard(Suit.Hearts, Value.Jack, "JH.png");
            BJBLL.CreateCard(Suit.Hearts, Value.Queen, "QH.png");
            BJBLL.CreateCard(Suit.Hearts, Value.King, "KH.png");
            BJBLL.CreateCard(Suit.Hearts, Value.Ace, "AH.png");

            BJBLL.CreateCard(Suit.Spades, Value.Two, "2S.png");
            BJBLL.CreateCard(Suit.Spades, Value.Three, "3S.png");
            BJBLL.CreateCard(Suit.Spades, Value.Four, "4S.png");
            BJBLL.CreateCard(Suit.Spades, Value.Five, "5S.png");
            BJBLL.CreateCard(Suit.Spades, Value.Six, "6S.png");
            BJBLL.CreateCard(Suit.Spades, Value.Seven, "7S.png");
            BJBLL.CreateCard(Suit.Spades, Value.Eight, "8S.png");
            BJBLL.CreateCard(Suit.Spades, Value.Nine, "9S.png");
            BJBLL.CreateCard(Suit.Spades, Value.Ten, "10S.png");
            BJBLL.CreateCard(Suit.Spades, Value.Jack, "JS.png");
            BJBLL.CreateCard(Suit.Spades, Value.Queen, "QS.png");
            BJBLL.CreateCard(Suit.Spades, Value.King, "KS.png");
            BJBLL.CreateCard(Suit.Spades, Value.Ace, "AS.png");

        }



        //When restarting 2 images should be images of a cards backside
        public void resetImages()
        {
            DealerPicture1.Image = Image.FromFile("BackSide.png");
            DealerPicture2.Image = Image.FromFile("BackSide.png");
            DealerPicture3.Image = null;
            DealerPicture4.Image = null;
            DealerPicture5.Image = null;
            DealerPicture6.Image = null;
            DealerPicture7.Image = null;
            PlayerpictureBox1.Image = Image.FromFile("BackSide.png");
            PlayerpictureBox2.Image = Image.FromFile("BackSide.png");
            PlayerpictureBox3.Image = null;
            PlayerpictureBox4.Image = null;
            PlayerpictureBox5.Image = null;
            PlayerpictureBox6.Image = null;
            PlayerpictureBox7.Image = null;
        }

        //Setts all pictures to Null
        private void ClearPictureBoxes()
        {
            Controls.OfType<PictureBox>().ToList().ForEach(pictureBox => pictureBox.Image = null);
        }

        private void BlackJackForm_Load(object sender, EventArgs e)
        {

        }

        private void DealerLabel_Click(object sender, EventArgs e)
        {

        }

        private void playerNameLabel_Click(object sender, EventArgs e)
        {
        }


    }
}
