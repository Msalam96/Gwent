using GwentSharedLibrary.Models;
using System.Data.Entity;

namespace GwentSharedLibrary.Data
{
    public class DatabaseIntializer : DropCreateDatabaseAlways<Context>
    {
        //protected override void Seed(Context context)
        //{
        //    try
        //    {
        //        Deck deck = new Deck(0);

        //        Card footSolider = new Card(0, false, "Redanian Foot Soldier", "I've bled for Redania! I've killed for Redania... Dammit, I've even raped for Redania!",
        //            1, CardType.CloseCombat, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/redanian_foot_soldier2_card.jpg");
        //        footSolider.Deck = deck;
        //        footSolider.DeckId = deck.Id;

        //        Card infantry = new Card(0, false, "Poor F***ing Infantry", "I's a war veteran! ... spare me a crown?",
        //            1, CardType.CloseCombat, SpecialAbility.Bond, "https://vignette.wikia.nocookie.net/witcher/images/1/16/Tw3_gwent_card_face_Poor_Fucking_Infantry.png/revision/latest?cb=20160320094501");
        //        infantry.Deck = deck;
        //        infantry.DeckId = deck.Id;

        //        Card infantry2 = new Card(0, false, "Poor F***ing Infantry", "I's a war veteran! ... spare me a crown?",
        //            1, CardType.CloseCombat, SpecialAbility.Bond, "https://vignette.wikia.nocookie.net/witcher/images/1/16/Tw3_gwent_card_face_Poor_Fucking_Infantry.png/revision/latest?cb=20160320094501");
        //        infantry2.Deck = deck;
        //        infantry2.DeckId = deck.Id;

        //        Card yarpen = new Card(0, false, "Yarpen Zigrin", "The world belongs to whoever's best at crackin' skulls and impregnatin' lasses",
        //            2, CardType.CloseCombat, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/yarpen_zigrin_card.jpg");
        //        yarpen.Deck = deck;
        //        yarpen.DeckId = deck.Id;

        //        Card commando = new Card(0, false, "Blue Stripes Commando", "I'd do anything for Temeria. Mostly, though, I kill for her.",
        //            4, CardType.CloseCombat, SpecialAbility.Bond, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/blue_stripes_commando_card.jpg");
        //        commando.Deck = deck;
        //        commando.DeckId = deck.Id;

        //        Card commando2 = new Card(0, false, "Blue Stripes Commando", "I'd do anything for Temeria. Mostly, though, I kill for her.",
        //            4, CardType.CloseCombat, SpecialAbility.Bond, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/blue_stripes_commando_card.jpg");
        //        commando2.Deck = deck;
        //        commando2.DeckId = deck.Id;

        //        Card stennis = new Card(0, false, "Prince Stennis", "He ploughin' wears golden armor. Golden. 'Course he's an arsehole",
        //            5, CardType.CloseCombat, SpecialAbility.Spy, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/prince_stennis_card.jpg");
        //        stennis.Deck = deck;
        //        stennis.DeckId = deck.Id;

        //        Card denesle = new Card(0, false, "Siegfried of Denesle", "We're on the same side, witcher. You'll realize this one day",
        //            5, CardType.CloseCombat, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/siegfried_of_denesle_card.jpg");
        //        denesle.Deck = deck;
        //        denesle.DeckId = deck.Id;

        //        Card ves = new Card(0, false, "Ves", "Better to live one day as a king than a whole life as a beggar",
        //            5, CardType.CloseCombat, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/ves_card.jpg");
        //        ves.Deck = deck;
        //        ves.DeckId = deck.Id;

        //        Card thyssen = new Card(0, false, "Esterad Thyssen", "Like all Thyssen men, he was tall, powerfully build and criminally handsome.",
        //            10, CardType.CloseCombat, SpecialAbility.Hero, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/esterad_thyssen_card.jpg");
        //        thyssen.Deck = deck;
        //        thyssen.DeckId = deck.Id;

        //        Card glevissig = new Card(0, false, "Sabrina Glevissig", "The daughter of the Kaedweni Wilderness.",
        //            4, CardType.Ranged, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/sabrina_glevissig_card.jpg");
        //        glevissig.Deck = deck;
        //        glevissig.DeckId = deck.Id;

        //        Card skaggs = new Card(0, false, "Sheldon Skaggs", "I was there, on the front lines! Right where the fightin' was the thickest!",
        //            4, CardType.Ranged, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/sheldon_skaggs_card.jpg");
        //        skaggs.Deck = deck;
        //        skaggs.DeckId = deck.Id;

        //        Card metz = new Card(0, false, "Keira Metz", "If I am to die today, I wish to look smashing for the occasion.",
        //            5, CardType.Ranged, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/keira_metz_card.jpg");
        //        metz.Deck = deck;
        //        metz.DeckId = deck.Id;

        //        Card sile = new Card(0, false, "Sile de Tansarville", "The Lodge lacks humility. Our lust for power may yet be our undoing.",
        //            5, CardType.Ranged, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/sile_de_tansarville_card.jpg");
        //        sile.Deck = deck;
        //        sile.DeckId = deck.Id;

        //        Card dethmold = new Card(0, false, "Dethmold", "I once made a prisoner vomit his own entrails... Ah, good times...",
        //            6, CardType.Ranged, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/dethmold_card.jpg");
        //        dethmold.Deck = deck;
        //        dethmold.DeckId = deck.Id;

        //        Card expert = new Card(0, false, "Kaedweni Siege Expert", "You gotta recalibrate the arm by five degrees. Do what by the what now?",
        //            1, CardType.Seige, SpecialAbility.Morale, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/kaedweni_siege_expert3_card.jpg");
        //        expert.Deck = deck;
        //        expert.DeckId = deck.Id;

        //        Card expert2 = new Card(0, false, "Kaedweni Siege Expert", "You gotta recalibrate the arm by five degrees. Do what by the what now?",
        //            1, CardType.Seige, SpecialAbility.Morale, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/kaedweni_siege_expert3_card.jpg");
        //        expert2.Deck = deck;
        //        expert2.DeckId = deck.Id;

        //        Card expert3 = new Card(0, false, "Kaedweni Siege Expert", "You gotta recalibrate the arm by five degrees. Do what by the what now?",
        //            1, CardType.Seige, SpecialAbility.Morale, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/kaedweni_siege_expert3_card.jpg");
        //        expert3.Deck = deck;
        //        expert3.DeckId = deck.Id;

        //        Card banner = new Card(0, false, "Dun Banner Medic", "Stitch red to red, white to white, and everything will be all right.",
        //            5, CardType.Seige, SpecialAbility.Medic, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/dun_banner_medic_card.jpg");
        //        banner.Deck = deck;
        //        banner.DeckId = deck.Id;

        //        Card ballista = new Card(0, false, "Ballista", "Usually we give 'em female names",
        //            6, CardType.Seige, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/ballista2_card.jpg");
        //        ballista.Deck = deck;
        //        ballista.DeckId = deck.Id;

        //        Card trebuchet = new Card(0, false, "Trebuchet", "Castle won't batter itself down, now will it? Get them trebuchets rollin'!",
        //            6, CardType.Seige, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/trebuchet2_card.jpg");
        //        trebuchet.Deck = deck;
        //        trebuchet.DeckId = deck.Id;

        //        Card trebuchet2 = new Card(0, false, "Trebuchet", "Castle won't batter itself down, now will it? Get them trebuchets rollin'!",
        //            6, CardType.Seige, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/trebuchet2_card.jpg");
        //        trebuchet2.Deck = deck;
        //        trebuchet2.DeckId = deck.Id;


        //        deck.Cards.Add(footSolider);
        //        deck.Cards.Add(infantry);
        //        deck.Cards.Add(infantry2);
        //        deck.Cards.Add(yarpen);
        //        deck.Cards.Add(commando);
        //        deck.Cards.Add(commando2);
        //        deck.Cards.Add(stennis);
        //        deck.Cards.Add(denesle);
        //        deck.Cards.Add(ves);
        //        deck.Cards.Add(thyssen);
        //        deck.Cards.Add(glevissig);
        //        deck.Cards.Add(skaggs);
        //        deck.Cards.Add(metz);
        //        deck.Cards.Add(sile);
        //        deck.Cards.Add(dethmold);
        //        deck.Cards.Add(expert);
        //        deck.Cards.Add(expert2);
        //        deck.Cards.Add(expert3);
        //        deck.Cards.Add(banner);
        //        deck.Cards.Add(ballista);
        //        deck.Cards.Add(trebuchet);
        //        deck.Cards.Add(trebuchet2);

        //        context.Cards.Add(footSolider);
        //        context.Cards.Add(infantry);
        //        context.Cards.Add(infantry2);
        //        context.Cards.Add(yarpen);
        //        context.Cards.Add(commando);
        //        context.Cards.Add(commando2);
        //        context.Cards.Add(stennis);
        //        context.Cards.Add(denesle);
        //        context.Cards.Add(ves);
        //        context.Cards.Add(thyssen);
        //        context.Cards.Add(glevissig);
        //        context.Cards.Add(skaggs);
        //        context.Cards.Add(metz);
        //        context.Cards.Add(sile);
        //        context.Cards.Add(dethmold);
        //        context.Cards.Add(expert);
        //        context.Cards.Add(expert2);
        //        context.Cards.Add(expert3);
        //        context.Cards.Add(banner);
        //        context.Cards.Add(ballista);
        //        context.Cards.Add(trebuchet);
        //        context.Cards.Add(trebuchet2);

        //        context.Decks.Add(deck);

        //        context.SaveChanges();
        //    }
        //    catch (DbEntityValidationException ex)
        //    {
        //        foreach (var errors in ex.EntityValidationErrors)
        //        {
        //            foreach (var validationError in errors.ValidationErrors)
        //            {
        //                // get the error message 
        //                string errorMessage = validationError.ErrorMessage;
        //            }
        //        }
        //    }
        //}

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
            context.SaveChanges();
        }
    }
}