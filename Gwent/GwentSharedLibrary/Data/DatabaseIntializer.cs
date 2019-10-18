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
            User mo = new User(0, "Mohammed", "Salam", "msalam@gmail.com", "$2a$10$pQ.jLCkRVWCYoxLZ2K0.9OKDR5cg1IyDIrvXl3ZuwVCuotLJbDMYe");
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

            Card frost = new Card("Frost", null, CardType.Weather, SpecialAbility.Frost, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/biting_frost_card.jpg");
            Card fog = new Card("Fog", null, CardType.Weather, SpecialAbility.Fog, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/impenetrable_fog_card.jpg");
            Card rain = new Card("Rain", null, CardType.Weather, SpecialAbility.Rain, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/torrential_rain_card.jpg");

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

            context.Cards.Add(frost);
            context.Cards.Add(rain);
            context.Cards.Add(fog);
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
            deck.AddCard(frost);
            deck.AddCard(sile);
            deck.AddCard(trebuchet);
            deck.AddCard(infantry);
            deck.AddCard(infantry);
            deck.AddCard(expert);
            deck.AddCard(commando);
            deck.AddCard(commando);
            deck.AddCard(stennis);
            deck.AddCard(denesle);
            deck.AddCard(thyssen);
            deck.AddCard(glevissig);
            deck.AddCard(skaggs);
            deck.AddCard(metz);
            deck.AddCard(dethmold);
            deck.AddCard(ves);
            deck.AddCard(expert);
            deck.AddCard(expert);
            deck.AddCard(yarpen);
            deck.AddCard(banner);
            deck.AddCard(ballista);
            deck.AddCard(trebuchet);
            context.Decks.Add(deck);

            Card vreemde = new Card("Vreemde", 2, CardType.CloseCombat, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/vreemde_card.jpg");
            Card nausicaa = new Card("Nausicaa", 2, CardType.CloseCombat, SpecialAbility.Bond, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/nausicaa_cavalry_rider_card.jpg");
            Card morteisen = new Card("Morteisen", 3, CardType.CloseCombat, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/morteisen_card.jpg");
            Card rainfarn = new Card("Rainfarn", 4, CardType.CloseCombat, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/rainfarn_card.jpg");
            Card vattier = new Card("Vattier", 4, CardType.CloseCombat, SpecialAbility.Spy, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/vattier_de_rideaux_card.jpg");
            Card cahir = new Card("Cahir", 6, CardType.CloseCombat, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/cahir_mawr_dyffryn_aep_ceallach.jpg");
            Card letho = new Card("Letho", 10, CardType.CloseCombat, SpecialAbility.Hero, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/letho_of_gulet_card.jpg");
            Card etolian = new Card("Etolian", 1, CardType.Ranged, SpecialAbility.Medic, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/etolian_auxiliary_archers2_card.jpg");
            Card young = new Card("Young Emissary", 5, CardType.CloseCombat, SpecialAbility.Bond, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/young_emissary2_card.jpg");
            Card renauld = new Card("Renauld", 5, CardType.Ranged, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/renuald_aep_matsen_card.jpg");
            Card black = new Card("Black Infantry Archer", 10, CardType.Ranged, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/black_infatry_archer2_card.jpg");
            Card technician = new Card("Siege Technician", 0, CardType.Seige, SpecialAbility.Medic, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/siege_technician_card.jpg");
            Card rotten = new Card("Rotten Mangonel", 3, CardType.Seige, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/rotten_mangonel_card.jpg");
            Card zerrikanian = new Card("Zerrikanian", 5, CardType.Seige, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/zerrikanian_fire_scorpion_card.jpg");
            Card engineer = new Card("Siege Engineer", 6, CardType.Seige, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/siege_engineer_card.jpg");
            Card heavy = new Card("Heavy Zerrikanian", 10, CardType.Seige, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/heavy_zerrikanian_fire_scorpion_card.jpg");
            Card albrich = new Card("Albrich", 2, CardType.Ranged, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/albrich_card.jpg");
            Card cynthia = new Card("Cynthia", 4, CardType.Ranged, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/cynthia_card.jpg");

            context.Cards.Add(vreemde);
            context.Cards.Add(nausicaa);
            context.Cards.Add(morteisen);
            context.Cards.Add(rainfarn);
            context.Cards.Add(vattier);
            context.Cards.Add(cahir);
            context.Cards.Add(letho);
            context.Cards.Add(etolian);
            context.Cards.Add(young);
            context.Cards.Add(renauld);
            context.Cards.Add(black);
            context.Cards.Add(technician);
            context.Cards.Add(rotten);
            context.Cards.Add(zerrikanian);
            context.Cards.Add(engineer);
            context.Cards.Add(heavy);
            context.Cards.Add(albrich);
            context.Cards.Add(cynthia);

            Deck deck2 = new Deck(0, "Nilfgaardian Empire");
            deck2.AddCard(fog);
            deck2.AddCard(technician);
            deck2.AddCard(vreemde);
            deck2.AddCard(heavy);
            deck2.AddCard(nausicaa);
            deck2.AddCard(young);
            deck2.AddCard(nausicaa);
            deck2.AddCard(morteisen);
            deck2.AddCard(rainfarn);
            deck2.AddCard(vattier);
            deck2.AddCard(cahir);
            deck2.AddCard(letho);
            deck2.AddCard(etolian);
            deck2.AddCard(etolian);
            deck2.AddCard(young);
            deck2.AddCard(renauld);
            deck2.AddCard(black);
            deck2.AddCard(black);
            deck2.AddCard(frost);
            deck2.AddCard(nausicaa);
            deck2.AddCard(rotten);
            deck2.AddCard(zerrikanian);
            deck2.AddCard(engineer);
            deck2.AddCard(rain);
            deck2.AddCard(cynthia);
            deck2.AddCard(albrich);
            context.Decks.Add(deck2);

            omer.AddDeck(deck);
            james.AddDeck(deck2);
            mo.AddDeck(deck);
            sarthak.AddDeck(deck2);
            context.SaveChanges();           
        }
    }
}