using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Copyrightclaimed_Street_Fighter
{
    class Program
    {
        static void Main(string[] args)
        {
            Random generator = new Random();

            //Alla variabler som kommer användas under spelets gång. Skriver int:en här både för att minnas de samt för att kunna använda de flera gånger.
            int money = 5;
            int strenght = 0;

            int hit1;
            int hit2;
            int crit1;
            int crit2;
            int games = 0;
            int round = 0;
            int hp1 = 100;
            int hp2 = 100;
            int champ1;
            int champ2;

            string[] criticalInformation =
            {
                " missed their attack!",
                " got critical!"
            };

            Ascii();

            //En kort introduktion
            Console.WriteLine("Hello and welcome to the battle of the centuries!");
            Console.WriteLine("Today we have two champions that will fight to the death!");

            //Rensar konsolen innan användaren får se kämpen hen ska möta
            Console.WriteLine("\n\n\nPress ENTER to continue");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine();
            ChampionFighter1();
            string champion1Name = "123";
            Console.WriteLine("The first champion is the almighty " + champion1Name + "!");

            //Låter användaren sätta namn på slagkämpe 2
            Console.WriteLine("\nWhats the name of the second champion?");
            string champion2Name = Console.ReadLine().Trim();

            //Gör så att användaren måste sätta ett namn på slagkämpe 2
            while (champion2Name.Length < 2 || champion2Name.Length > 20)
            {
                Console.WriteLine("\nPlease enter a name of the champion");
                champion2Name = Console.ReadLine();
            }

            //Välkomnar kämparna
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("\n\n\nPlease welcome " + champion1Name + " and " + champion2Name);
            Thread.Sleep(3000);

            //Meddelar användaren att det finns en butik som hen kan handla i
            Console.Clear();
            Console.WriteLine("\nYou can enter the shop");
            Console.WriteLine("\nDo you want to?\n");
            YesNo();
            string shop = Console.ReadLine().ToLower();

            //Tvingar användaren att välja ett av alternativen. Mycket viktig för att inte få programmet att krasha eller inte fungera som den skall då min kod förlitar sig på att användaren skriver in ett svarsalternativ. Hade detta inte funnits och användaren hade svarat med något som inte var ett alternativ så skulle programmet inte köras
            while (shop != "y" && shop != "n")
            {
                Console.Clear();
                Console.WriteLine("\nYou can enter the shop");
                Console.WriteLine("\nDo you want to?\n");
                YesNo();
                shop = Console.ReadLine();
            }

            //Gör att användaren stannar kvar i butiken så länge angumentet stämmer
            //I butiken kan användaren köpa styrka till kämparna, som kommer göra båda kämparna starkare med den mängd styrka de köper.
            while (shop == "y")
            {
                Console.Clear();
                Console.WriteLine("\nWelcome to the shop!");
                Console.WriteLine("\nYou can so far only buy one sort of thing, strength");
                Console.WriteLine("Strenght makes it easier to win the match as it only affects your champion");
                Console.WriteLine("\n1 strenght = 1 extra damage");
                Console.WriteLine("\nDo you want to purchase strenght?");
                YesNo();
                shop = Console.ReadLine();
                shop = shop.ToLower();

                //Tvingar användaren att välja ett av alternativen. Mycket viktig för att inte få programmet att krasha eller inte fungera som den skall då min kod förlitar sig på att användaren skriver in ett svarsalternativ. Hade detta inte funnits och användaren hade svarat med något som inte var ett alternativ så skulle programmet inte köras
                while (shop != "y" && shop != "n")
                {
                    Console.WriteLine("\nDo you want to purchase strenght?\n");
                    YesNo();
                    shop = Console.ReadLine();
                }


                //Användaren ska kunna ha en chans att kunna ångra sig 1 gång efter ha fått veta om vad som säljs
                while (shop == "y")
                {
                    Console.Clear();
                    //Sålänge det finns pengar kommer användaren ha chansen att kunna köpa
                    while (money > 0)
                    {
                        //Frågar användaren hur mycket hen vill köpa sam säger hur mycket hen vill köpa
                        Console.WriteLine("\nHow much strenght do you want to buy?");
                        Console.WriteLine("Strenght makes it easier to beat your opponent and thereby winning the fight");
                        Console.WriteLine("\nYou can buy a maximum of " + money + " strenght");

                        int ammount = 0;

                        //Kontrollerar att så länge mängden styrka man har inte är över mängden pengar eller är mindre eller lika med 0.
                        while (ammount > money || ammount <= 0)
                        {
                            int.TryParse(Console.ReadLine(), out ammount);

                            if (ammount > money)
                            {
                                Console.WriteLine("You can't buy more strenght than the ammount of money you have");
                                Console.WriteLine();
                            }

                            if (ammount == 0)
                            {
                                Console.WriteLine("Please enter a valid ammount");
                                Console.WriteLine();
                            }
                        }

                        //Omvandlar int'en ammount till den universiella int'en strenth som används i fighten
                        //Reducerar pengarna så att man inte kan köpa i all oändlighet
                        //Lägger ihop mängden man köper

                        strenght = ammount;

                        money = 0;

                        //Om användaren avarar nej så kommer pengarna ta slut för att stoppa loopen
                        if (shop != "y")
                        {
                            Console.WriteLine();
                            money = 0;
                            shop = "n";
                        }
                    }

                    //Indikerar användaren att pengarna är slut, dvs. hen lämnar butiken
                    if (money == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Thank you and good bye!");
                        shop = "n";
                        Console.WriteLine("Press ENTER to continue");
                        Console.ReadLine();
                    }
                }
            }

            //Frågar användaren om hen faktist vill sätta igång spelet
            AskPlayerStart();
            string start = Console.ReadLine().ToLower();

            //Tvingar användaren att välja ett av alternativen. Mycket viktig för att inte få programmet att krasha eller inte fungera som den skall då min kod förlitar sig på att användaren skriver in ett svarsalternativ. Hade detta inte funnits och användaren hade svarat med något som inte var ett alternativ så skulle programmet inte köras
            while (start != "y" && start != "n")
            {
                AskPlayerStart();
                start = Console.ReadLine();
            }

            //Om användaren säger Y eller y (betyder yes) kommer spelet att börja, om hen svarar N eller n kommer spelet att hoppas över och hen skickas ner till adjösidan. Detta är viktigt för att om en person av misstag starta upp spelet eller av någon anledning ångrar sig så ska hen inte behöva leva med sina val
            while (start == "y")
            {
                //En timer tills striden börjar (låter användaren bli redo)
                //Har lagt till många cw's för att inte få konsollen att sitta i taket när timern är igång. Detta var för att jag tyckte det var trevligare att kolla på.
                GameStart();

                //Gör att slagkämparna slåss tills en av de inte ha liv kvar. Denna del av koden är den viktigaste då det är den som ser till att kämparna slår varandra. Utan denna delen av koden skulle det inte finns någon mening med detta program.
                //Slagkämparna slår varandra och med varje slag tappar de den mänd liv som är den andra kämpens styrka (1 styrka = 1 skada).
                //Så långe som minst en av kämparna har 1 eller mer liv kvar kommer de slå varandra med en slumpmässig mängd skada.
                //Jag har även lagt till att kämparna kan få så kallade "critical" vilket är en mycket starkare attack där de gör som minst 25 skada och som högst 50. Trots att kämparna kan få "critical" så betyder det inte att de kommer träffa motståndaren då de kan missa sin attack helt, spelar ingen roll om den är "critical" eller normal, risken att missa är lika stor.
                while (hp1 > 0 && hp2 > 0)
                {
                    round++;

                    Console.WriteLine("Round: " + round + "\n");


                    hit1 = generator.Next(1, 6);
                    hit2 = generator.Next(1, 6);

                    crit1 = generator.Next(1, 51);
                    crit2 = generator.Next(1, 51);

                    champ1 = generator.Next(1,11);
                    champ2 = generator.Next(1,11) + strenght;

                    //Gör att om en kämpe för critical så skrivs den gamla styrkan över med den nya, mycket starkare styrkan.
                    if (crit1 == 22)
                    {
                        champ1 = generator.Next(25, 51);
                        Console.WriteLine(champion1Name + criticalInformation[1]);
                        Thread.Sleep(500);
                    }

                    //Gör att om en kämpe för critical så skrivs den gamla styrkan över med den nya, mycket starkare styrkan.
                    if (crit2 == 22)
                    {
                        champ2 = generator.Next(25, 51) + strenght;
                        Console.WriteLine(champion2Name + criticalInformation[1]);
                        Thread.Sleep(500);
                    }

                    //Gör att kämpen kan missa, det vill säga göra ingen skada alls
                    if (hit1 == 5)
                    {
                        champ1 = 0;
                        Console.WriteLine(champion1Name + criticalInformation[0]);
                        Thread.Sleep(500);
                    }

                    //Gör att kämpen kan missa, det vill säga göra ingen skada alls
                    if (hit2 == 5)
                    {
                        champ2 = 0;
                        Console.WriteLine(champion2Name + criticalInformation[0]);
                        Thread.Sleep(500);
                    }

                    //Hanterar skadan skedd.
                    hp1 = hp1 - champ2;
                    hp2 = hp2 - champ1;

                    //Säger ut vem som gjorde hur mycker skada till vem

                    Console.WriteLine("\n\n" + champion1Name + " dealt " + champ1 + " damage to " + champion2Name +"! " + champion2Name + " has " + hp2 + "hp left!");
                    Thread.Sleep(100);
                    Console.WriteLine("\n\n" + champion2Name + " dealt " + champ2 + " damage to " + champion1Name + "! " + champion1Name + " has "+hp1+"hp left!");
                    Thread.Sleep(3000);
                    Console.Clear();
                }

                //Om kämparna knockar ut varandra kommer det bli lika
                if (hp1 <= 0 && hp2 <= 0)
                {
                    Console.WriteLine("Draw!");
                    Thread.Sleep(100);
                    Console.WriteLine("Both champions were defeated!");
                    Console.WriteLine("It took " + round + " rounds until they knocked out eachother");
                    games++;
                }

                //Om kämpe 1 fortfarande har liv kvar kommer hen att vinna
                else if (hp1 > 0)
                {
                    Console.WriteLine(champion1Name + " won in round " + round + "! The champion had " + hp1 + "hp left!");
                    games++;
                }

                //Om kämpe 2 fortfarande har liv kvar kommer hen att vinna
                else if (hp2 > 0)
                {
                    Console.WriteLine(champion2Name + " won in round " + round + "! The champion had " + hp2 + "hp left!");
                    games++;
                }

                //Återställer kämparnas liv samt rundan de fightas på så att striden kan startas om, om så önskas
                round = 0;
                hp1 = 100;
                hp2 = 100;

                //Frågar användaren om hen vill att kämparna ska slåss igen
                Console.ReadLine();
                PlayAgain();
                Console.WriteLine();
                start = Console.ReadLine();
                start = start.ToLower();

                //Tvingar användaren att välja ett av alternativen. Mycket viktig för att inte få programmet att krasha eller inte fungera som den skall då min kod förlitar sig på att användaren skriver in ett svarsalternativ. Hade detta inte funnits och användaren hade svarat med något som inte var ett alternativ så skulle programmet inte köras
                while (start != "y" && start != "n")
                {
                    Console.ReadLine();
                    PlayAgain();
                    start = Console.ReadLine();
                }
            }

            //Säger adjö till användaren samt säger antalet gånger fighten hölls till.
            Console.Clear();
            Console.WriteLine("\nThank you for playing!");
            Console.WriteLine("\nYou played " + games + " times");
            Console.WriteLine("\nPress ENTER to quit");

            Console.ReadLine();
        }

        static void AskPlayerStart()
        {
            Console.Clear();
            Console.WriteLine("Do you want to start the match?");
            Console.WriteLine("Press Y or y for yes");
            Console.WriteLine("Press N or n for no");
        }

        static void GameStart()
        {
            Console.Clear();
            Console.WriteLine("\n\nThe battle begins in 5 seconds, best of luck to you both");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("\n\n4 seconds!");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("\n\n3 seconds!");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("\n\n2 seconds!");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("\n\n1 second!");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("\n\nThe battle begins!");
            Console.Clear();
        }

        static void PlayAgain()
        {
            Console.Clear();
            Console.WriteLine("Want to play again?");
            Console.WriteLine("Press Y or y for yes");
            Console.WriteLine("Press N or n for no");
        }

        static void YesNo()
        {
            Console.WriteLine("Press Y or y for yes");
            Console.WriteLine("Press N or n for no");
        }

        static void Ascii()
        {
            Console.WriteLine(@"
                    888                          888    .d888d8b        888     888    
                    888                          888   d88P' Y8P        888     888    
                    888                          888   888              888     888    
            .d8888b 888888888d888 .d88b.  .d88b. 888888888888888 .d88b. 88888b. 888888.d88b. 888d888  
            88K     888   888P'  d8P  Y8bd8P  Y8b888   888   888d88P'88b888 '88b888   d8P  Y8b888P'   
            'Y8888b.888   888    8888888888888888888   888   888888  888888  888888   88888888888     
                 X88Y88b. 888    Y8b.    Y8b.    Y88b. 888   888Y88b 888888  888Y88b. Y8b.    888     
             88888P' 'Y888888     'Y8888  'Y8888  'Y888888   888 'Y88888888  888 'Y888 'Y8888 888     
                                                                     888               
                                                                Y8b d88P               
                                                                 'Y88P'                
            ");
        }

        static void ChampionFighter1()
        {
            //Slumpar ett namn på slgakämpe 1
            Random generator = new Random();
            int champion1 = generator.Next(1, 4);

            //Slumpar ett namn bland 3 stycken olika för den som användarens kämpe kommer strida mot samt skriver ut det och samt hur kämpen ser ut
            string champion1Name = "";

            if (champion1 == 1)
            {
                champion1Name = "Gunnar";
                Console.WriteLine("\n\n"+@"
                            /:""|  
                           |: 66|_ 
                           C     _)
                            \ ._|  
                             ) /   
                            /`\\   
                           || |Y|  
                           || |#|  
                           || |#|  
                           || |#|  
                           :| |=:  
                           ||_|,|  
                           \)))||  
                        |~~~`-`~~~|
                        |         |
                        |_________|
                        |_________|
                            | ||   
                            |_||__ 
                            (____))
                                 ");
            }

            else if (champion1 == 2)
            {
                champion1Name = "Lennart";
                Console.WriteLine("\n\n"+@"
                             ,,,,
                            /   '
                           /.. /
                          ( c  D
                           \- '\_
                            `-'\)\
                               |_ \
                               |U \\
                              (__,//
                              |. \/
                              LL__I
                               |||
                               |||
                            ,,-``'\ ");
            }

            else if (champion1 == 3)
            {
                champion1Name = "Rudolf";
                Console.WriteLine("\n\n"+@"
                          ,.,.
                        ((((^))
                        d e_# b
                         \._./
                     ,---i`-'i---.
                    /  |  `-'  |  \
                    |__|       |__|
                     \ |        | |
                      \ \______ | |
                       \/ )   \|| \
                       |-  |   |'//\
                       |___|___|
                        |  |  |
                        (  |  )
                        {_ |__|
                        (__|__}
                       _>= | =<_
                      (__._|_.__)");
            }
        }
    }
}
