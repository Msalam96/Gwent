using GwentSharedLibrary.Models;
using System.Data.Entity;

namespace GwentSharedLibrary.Data
{
    public class DatabaseIntializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            User omer = new User(0, "Omer", "Latif", "omerltf@gmail.com", "$2a$10$pQ.jLCkRVWCYoxLZ2K0.9OKDR5cg1IyDIrvXl3ZuwVCuotLJbDMYe");
            User james = new User(0, "James", "Churchill", "jchurchill@gmail.com", "$2a$10$pQ.jLCkRVWCYoxLZ2K0.9OKDR5cg1IyDIrvXl3ZuwVCuotLJbDMYe");
            User mo = new User(0, "Mohammad", "Salam", "msalam@gmail.com", "$2a$10$pQ.jLCkRVWCYoxLZ2K0.9OKDR5cg1IyDIrvXl3ZuwVCuotLJbDMYe");
            User sarthak = new User(0, "Sarthak", "Thakur", "sthakur@gmail.com", "$2a$10$pQ.jLCkRVWCYoxLZ2K0.9OKDR5cg1IyDIrvXl3ZuwVCuotLJbDMYe");
            context.Users.Add(omer);
            context.Users.Add(james);
            context.Users.Add(mo);
            context.Users.Add(sarthak);

            UserRelationship moSarthak = new UserRelationship()
            {
                FirstUser = mo,
                SecondUser = sarthak,
                IsAccepted = true
            };

            context.UserRelationships.Add(moSarthak);

            Card footSolider = new Card("Redanian Foot Soldier", 1, CardType.CloseCombat, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/redanian_foot_soldier2_card.jpg");
            Card infantry = new Card("Poor F***ing Infantry", 1, CardType.CloseCombat, SpecialAbility.Bond, "https://vignette.wikia.nocookie.net/witcher/images/1/16/Tw3_gwent_card_face_Poor_Fucking_Infantry.png/revision/latest?cb=20160320094501");
            Card yarpen = new Card("Yarpen Zigrin", 2, CardType.CloseCombat, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/yarpen_zigrin_card.jpg");
            Card commando = new Card("Blue Stripes Commando", 4, CardType.CloseCombat, SpecialAbility.Bond, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/blue_stripes_commando_card.jpg");
            Card stennis = new Card("Prince Stennis", 5, CardType.CloseCombat, SpecialAbility.Spy, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/prince_stennis_card.jpg");
            Card denesle = new Card("Siegfried of Denesle", 5, CardType.CloseCombat, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/siegfried_of_denesle_card.jpg");
            Card ves = new Card("Ves", 5, CardType.CloseCombat, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/ves_card.jpg");
            Card thyssen = new Card("Esterad Thyssen", 10, CardType.CloseCombat, SpecialAbility.Hero, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/esterad_thyssen_card.jpg");
            Card glevissig = new Card("Sabrina Glevissig", 4, CardType.Ranged, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/sabrina_glevissig_card.jpg");
            Card skaggs = new Card("Sheldon Skaggs", 4, CardType.Ranged, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/sheldon_skaggs_card.jpg");
            Card metz = new Card("Keira Metz", 5, CardType.Ranged, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/keira_metz_card.jpg");
            Card sile = new Card("Sile de Tansarville", 5, CardType.Ranged, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/sile_de_tansarville_card.jpg");
            Card dethmold = new Card("Dethmold", 6, CardType.Ranged, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/dethmold_card.jpg");
            Card expert = new Card("Kaedweni Siege Expert", 1, CardType.Seige, SpecialAbility.Morale, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/kaedweni_siege_expert3_card.jpg");
            Card banner = new Card("Dun Banner Medic", 5, CardType.Seige, SpecialAbility.Medic, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/dun_banner_medic_card.jpg");
            Card ballista = new Card("Ballista", 6, CardType.Seige, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/ballista2_card.jpg");
            Card trebuchet = new Card("Trebuchet", 6, CardType.Seige, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/trebuchet2_card.jpg");

            context.Cards.Add(footSolider);
            context.Cards.Add(infantry);
            context.Cards.Add(yarpen);
            context.Cards.Add(commando);
            context.Cards.Add(stennis);
            context.Cards.Add(denesle);
            context.Cards.Add(ves);
            context.Cards.Add(thyssen);
            context.Cards.Add(glevissig);
            context.Cards.Add(skaggs);
            context.Cards.Add(metz);
            context.Cards.Add(sile);
            context.Cards.Add(dethmold);
            context.Cards.Add(expert);
            context.Cards.Add(banner);
            context.Cards.Add(ballista);
            context.Cards.Add(trebuchet);

            Deck deck = new Deck(0, "Northern Realms");
            deck.AddCard(footSolider);
            deck.AddCard(infantry);
            deck.AddCard(infantry);
            deck.AddCard(yarpen);
            deck.AddCard(commando);
            deck.AddCard(commando);
            deck.AddCard(stennis);
            deck.AddCard(denesle);
            deck.AddCard(ves);
            deck.AddCard(thyssen);
            deck.AddCard(glevissig);
            deck.AddCard(skaggs);
            deck.AddCard(metz);
            deck.AddCard(sile);
            deck.AddCard(dethmold);
            deck.AddCard(expert);
            deck.AddCard(expert);
            deck.AddCard(expert);
            deck.AddCard(banner);
            deck.AddCard(ballista);
            deck.AddCard(trebuchet);
            deck.AddCard(trebuchet);
            context.Decks.Add(deck);

            Deck deck2 = new Deck(0, "Northern Realms");
            deck2.AddCard(footSolider);
            deck2.AddCard(infantry);
            deck2.AddCard(infantry);
            deck2.AddCard(yarpen);
            deck2.AddCard(commando);
            deck2.AddCard(commando);
            deck2.AddCard(stennis);
            deck2.AddCard(denesle);
            deck2.AddCard(ves);
            deck2.AddCard(thyssen);
            deck2.AddCard(glevissig);
            deck2.AddCard(skaggs);
            deck2.AddCard(metz);
            deck2.AddCard(sile);
            deck2.AddCard(dethmold);
            deck2.AddCard(expert);
            deck2.AddCard(expert);
            deck2.AddCard(expert);
            deck2.AddCard(banner);
            deck2.AddCard(ballista);
            deck2.AddCard(trebuchet);
            deck2.AddCard(trebuchet);
            context.Decks.Add(deck2);

            omer.AddDeck(deck);
            james.AddDeck(deck2);
            //mo.AddDeck(deck);
            //sarthak.AddDeck(deck);
            context.SaveChanges();           
           
           
            //context.SaveChanges();
            //}
            //catch (DbEntityValidationException ex)
            //{
            //    foreach (var errors in ex.EntityValidationErrors)
            //    {
            //        foreach (var validationError in errors.ValidationErrors)
            //        {
            //            // get the error message 
            //            string errorMessage = validationError.ErrorMessage;
            //        }
            //    }
            //}
        }
    }
}