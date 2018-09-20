using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace NepuBot.Modules
{
    public class Misc : ModuleBase<SocketCommandContext>
    {
        [Command("help")]
        public async Task Help()
        {
            
            var embed = new EmbedBuilder();
            embed.WithTitle("COMMAND LISTS");
            //embed.WithDescription(message);
            embed.WithColor(new Color(180, 0, 255));

            embed.AddInlineField("Command", "say"
                                          + "\nchoose"
                                          + "\nanswer"
                                          + "\narch"
                                          + "\nfish king"
                                          + "\ntips"
                                          + "\ngtips"
                                          + "\ngather"
                                          + "\nmy tip"
                                          + "\nmy gtip"
                                          + "\npara"
                                          + "\npromo AP"
                                          + "\npromo BP"
                                          + "\npromo LP"
                                          + "\nhelp");
            embed.AddInlineField("Description", "Make Nep repeat something you say."
                                              + "\nMake Nep choose from a list."
                                              + "\nNep will answer your yes/no question."
                                              + "\nShow the maps that are available for Archaelogy today."
                                              + "\nShow info about the next fish kings."
                                              + "\nNep will give you a random tip about AK."
                                              + "\nNep will give you a random tip of NepuNepu."
                                              + "\nGathering image guide."
                                              + "\nShare your AK tips and tricks."
                                              + "\nShare your guild tips."
                                              + "\nNep will show you the current paragon."
                                              + "\nNep will show you the current AP promotion."
                                              + "\nNep will show you the current BP promotion."
                                              + "\nNep will show you the current LP promotion."
                                              + "\nShow the list of commands you can use.");


            await Context.Channel.SendMessageAsync("", false, embed);

        }

        [Command("para")]
        public async Task ShowCurrentParagon()
        {
            await Context.Channel.SendMessageAsync("**This is the current paragon neppu!**");
            string[] paraList = Utilities.GetDatabse("PARA");
            for (int i = 0; i < paraList.Length; i++)
            {
                string imgSrc = paraList[i];
                await Context.Channel.SendFileAsync(imgSrc);
            }
        }
        /*
        [Command("promo AP")]
        public async Task ShowCurrentAPPromo()
        {
            await Context.Channel.SendMessageAsync("**This is the current AP promotion neppu!**");
            string[] paraList = Utilities.GetDatabse("PROMO_AP");
            for (int i = 0; i < paraList.Length; i++)
            {
                string imgSrc = paraList[i];
                await Context.Channel.SendFileAsync(imgSrc);
            }
        }

        [Command("promo BP")]
        public async Task ShowCurrentBPPromo()
        {
            await Context.Channel.SendMessageAsync("**This is the current BP promotion neppu!**");
            string[] paraList = Utilities.GetDatabse("PROMO_BP");
            for (int i = 0; i < paraList.Length; i++)
            {
                string imgSrc = paraList[i];
                await Context.Channel.SendFileAsync(imgSrc);
            }
        }

        [Command("promo LP")]
        public async Task ShowCurrentLPPromo()
        {
            await Context.Channel.SendMessageAsync("**This is the current LP promotion neppu!**");
            string[] paraList = Utilities.GetDatabse("PROMO_LP");
            for (int i = 0; i < paraList.Length; i++)
            {
                string imgSrc = paraList[i];
                await Context.Channel.SendFileAsync(imgSrc);
            }
        }
        */
        [Command("promo")]
        public async Task PromoDirect()
        {
            var embed = new EmbedBuilder();
            //embed.WithTitle("Type `Nep promo <AP/LP/BP>` for image info of the corresponding promo");
            embed.WithTitle("Locked");
            //embed.WithDescription(message);
            embed.WithColor(new Color(180, 0, 255));

            await Context.Channel.SendMessageAsync("", false, embed);
        }

        [Command("say")]
        public async Task Echo([Remainder]string message)
        {
            /*
            var embed = new EmbedBuilder();
            embed.WithTitle("Echo message");
            embed.WithDescription(message);
            embed.WithColor(new Color(0, 255, 0));
            */

            await Context.Channel.SendMessageAsync(message);

        }

        [Command("my tip")]
        public async Task ReceiveTip([Remainder]string message)
        {
            ulong id = 323473566253318145;
            var client = Context.Client;
            var usr = client.GetUser(id);
            var giver = Context.User.Username;
            await usr.SendMessageAsync("\"" + message + " (" + giver + ")" + "\",");

            if (message != null)
            {
                await Context.Channel.SendMessageAsync("Thank you sooo much for sharing your tip!");
            }
        }

        [Command("my gtip")]
        public async Task ReceiveGuildTip([Remainder]string message)
        {
            ulong id = 431673679450079232;
            var client = Context.Client;
            var usr = client.GetUser(id);
            var giver = Context.User.Username;
            await usr.SendMessageAsync("\"" + message + " (" + giver + ")" + "\",");

            if (message != null)
            {
                await Context.Channel.SendMessageAsync("Thank you sooo much for sharing your tip!");
            }
        }


        /*
        [Command("secret")]
        public async Task Secret()
        {

            await Context.Channel.SendMessageAsync(Utilities.GetAlert("SECRET"));
        }
        */

        [Command("gather")]
        public async Task GatheringList()
        {

            var embed = new EmbedBuilder();
            embed.WithTitle("GATHERING MAPS LIST");
            embed.WithDescription("Type `Nep gather + Map Code` for image guide.");
            embed.WithColor(new Color(180, 0, 255));

            embed.AddInlineField("Map name", "Navea"
                                          + "\nHelonia Coas"
                                          + "\nCrescent Hill"
                                          + "\nCactakara Forest"
                                          + "\nDemarech Mines"
                                          + "\nTriatio Highlands"
                                          + "\nCandeo Marsh"
                                          + "\nVentos Prairie"
                                          + "\nOblitus Woods"
                                          + "\nStar Sand Desert"
                                          + "\nRainmist Reach"
                                          + "\nEmerald Marsh"
                                          + "\nStarstruck Plateau"
                                          + "\nSilent Ice Field"
                                          + "\nPort Morton"
                                          + "\nCandetonn Hill"
                                          + "\nViridan Steppe"
                                          + "\nDesolate Valley"
                                          + "\nChronology Forest"
                                          + "\nTempest Desert");

            embed.AddInlineField("Map code", "navea"
                                          + "\nhelonia"
                                          + "\ncrescent"
                                          + "\ncacta"
                                          + "\ndemarech"
                                          + "\ntriatio"
                                          + "\ncandeo"
                                          + "\nventos"
                                          + "\noblitus"
                                          + "\nstarsand"
                                          + "\nrainmist"
                                          + "\nem"
                                          + "\nstarstruck"
                                          + "\nsif"
                                          + "\nportmorton"
                                          + "\ncandetonn"
                                          + "\nviridan"
                                          + "\ndesolate"
                                          + "\nchronology"
                                          + "\ntempest");


            await Context.Channel.SendMessageAsync("", false, embed);

        }

        [Command("gather navea")]
        public async Task GatheringNavea()
        {

            await Context.Channel.SendMessageAsync("These are the gathering spots in Navea neppu!");
            await Context.Channel.SendFileAsync("res/gathering/navea.png");

            Console.WriteLine("nep gather");
        }

        [Command("gather helonia")]
        public async Task GatheringHelonia()
        {

            await Context.Channel.SendMessageAsync("These are the gathering spots in Helonia Coast neppu!");
            await Context.Channel.SendFileAsync("res/gathering/helonia.png");
        }

        [Command("gather crescent")]
        public async Task GatheringCrescent()
        {

            await Context.Channel.SendMessageAsync("These are the gathering spots in Crescent Hill neppu!");
            await Context.Channel.SendFileAsync("res/gathering/crescent.png");
        }

        [Command("gather cacta")]
        public async Task GatheringCacta()
        {

            await Context.Channel.SendMessageAsync("These are the gathering spots in Cactakara Forest neppu!");
            await Context.Channel.SendFileAsync("res/gathering/cacta.png");
        }

        [Command("gather demarech")]
        public async Task GatheringDemarech()
        {

            await Context.Channel.SendMessageAsync("These are the gathering spots in Demarech Mines neppu!");
            await Context.Channel.SendFileAsync("res/gathering/demarech.png");
        }

        [Command("gather triatio")]
        public async Task GatheringTriatio()
        {

            await Context.Channel.SendMessageAsync("These are the gathering spots in Triatio Highlands neppu!");
            await Context.Channel.SendFileAsync("res/gathering/triatio.png");
        }

        [Command("gather candeo")]
        public async Task GatheringCandeo()
        {

            await Context.Channel.SendMessageAsync("These are the gathering spots in Candeo Marsh neppu!");
            await Context.Channel.SendFileAsync("res/gathering/candeo.png");
        }

        [Command("gather ventos")]
        public async Task GatheringVentos()
        {

            await Context.Channel.SendMessageAsync("These are the gathering spots in Ventos Prairie neppu!");
            await Context.Channel.SendFileAsync("res/gathering/ventos.png");
        }

        [Command("gather oblitus")]
        public async Task GatheringOblitus()
        {

            await Context.Channel.SendMessageAsync("These are the gathering spots in Oblitus Woods neppu!");
            await Context.Channel.SendFileAsync("res/gathering/oblitus.png");
        }

        [Command("gather starsand")]
        public async Task GatheringStarSand()
        {

            await Context.Channel.SendMessageAsync("These are the gathering spots in Star Sand Desert neppu!");
            await Context.Channel.SendFileAsync("res/gathering/starsand.png");
        }

        [Command("gather rainmist")]
        public async Task GatheringRainmist()
        {

            await Context.Channel.SendMessageAsync("These are the gathering spots in Rainmist Reach neppu!");
            await Context.Channel.SendFileAsync("res/gathering/rainmist.png");
        }

        [Command("gather em")]
        public async Task GatheringEM()
        {

            await Context.Channel.SendMessageAsync("These are the gathering spots in Emerald Marsh neppu!");
            await Context.Channel.SendFileAsync("res/gathering/em.png");
        }

        [Command("gather starstruck")]
        public async Task GatheringStarstruck()
        {

            await Context.Channel.SendMessageAsync("These are the gathering spots in Starstruck Plateau neppu!");
            await Context.Channel.SendFileAsync("res/gathering/starstruck.png");
        }

        [Command("gather sif")]
        public async Task GatheringSIF()
        {

            await Context.Channel.SendMessageAsync("These are the gathering spots in Silent Ice Field neppu!");
            await Context.Channel.SendFileAsync("res/gathering/sif.png");
        }

        [Command("gather portmorton")]
        public async Task GatheringPortMorton()
        {

            await Context.Channel.SendMessageAsync("These are the gathering spots in Port Morton neppu!");
            await Context.Channel.SendFileAsync("res/gathering/portmorton.png");
        }

        [Command("gather candetonn")]
        public async Task GatheringCandetonn()
        {

            await Context.Channel.SendMessageAsync("These are the gathering spots in Candetonn Hill neppu!");
            await Context.Channel.SendFileAsync("res/gathering/candetonn.png");
        }

        [Command("gather viridan")]
        public async Task GatheringViridan()
        {

            await Context.Channel.SendMessageAsync("These are the gathering spots in Viridan Steppe neppu!");
            await Context.Channel.SendFileAsync("res/gathering/viridan.png");
        }

        [Command("gather desolate")]
        public async Task GatheringDesolate()
        {

            await Context.Channel.SendMessageAsync("These are the gathering spots in Desolate Valley neppu!");
            await Context.Channel.SendFileAsync("res/gathering/desolate.png");
        }

        [Command("gather chronology")]
        public async Task GatheringChronology()
        {

            await Context.Channel.SendMessageAsync("These are the gathering spots in Chronology Forest neppu!");
            await Context.Channel.SendFileAsync("res/gathering/chronology.png");
        }

        [Command("gather tempest")]
        public async Task GatheringTempest()
        {

            await Context.Channel.SendMessageAsync("These are the gathering spots in Tempest Desert neppu!");
            await Context.Channel.SendFileAsync("res/gathering/tempest.png");
        }

        [Command("fish king")]
        public async Task NextFishKing()
        {
            DateTime utcNow = DateTime.UtcNow;
            DateTime igTime = utcNow.AddHours(1);
            DateTime h1 = DateTime.Today.AddHours(1D);
            DateTime h5 = DateTime.Today.AddHours(5D);
            DateTime h9 = DateTime.Today.AddHours(9D);
            DateTime h13 = DateTime.Today.AddHours(13D);
            DateTime h17 = DateTime.Today.AddHours(17D);
            DateTime h21 = DateTime.Today.AddHours(21D);

            //debug
            //DateTime dt = new DateTime(2018, 9, 22, 21, 5, 0, 000);
            //igTime = igTime.AddHours(3);
            //igTime = dt;

            var embed = new EmbedBuilder();
            embed.WithTitle("NEXT FISH KING");
            embed.WithColor(new Color(180, 0, 255));
            /*embed.WithDescription("Time: 12AM");
            embed.WithColor(new Color(255, 0, 255));
            embed.AddInlineField("Map", "Vulture Vale\nABC");
            embed.AddInlineField("Name", "Vulture Vale\nABC");
            embed.AddInlineField("Bait", "Vulture Vale\nABC");*/

            //await Context.Channel.SendMessageAsync("", false, embed);

            if (igTime.DayOfWeek == DayOfWeek.Sunday)
            {
                if (igTime.Hour < h13.Hour)
                {
                    embed.WithDescription("Time: 1PM");
                    embed.AddInlineField("Map", "ALL MAPS");
                }
                else if (igTime.Hour < h17.Hour)
                {
                    embed.WithDescription("Time: 5PM");
                    embed.AddInlineField("Map", "ALL MAPS");
                }
                else
                {
                    embed.WithDescription("Time: 1AM");
                    embed.AddInlineField("Map", "Vulture's Vale\nDesolate Valley");
                    embed.AddInlineField("Name", "Eternal Wise Crab\nMidnight Silverside");
                    embed.AddInlineField("Bait", "Shining Crystal Shell\nTop Fish Head");
                }
            }
            else {
                int tSlot = 0;
                if (igTime.Hour < h1.Hour)
                {
                    embed.WithDescription("Time: 1AM");
                    Console.WriteLine("h1");
                }
                else if (igTime.Hour < h5.Hour)
                {
                    embed.WithDescription("Time: 5AM");
                    tSlot = 1;
                    Console.WriteLine("h5");
                }
                else if (igTime.Hour < h9.Hour)
                {
                    embed.WithDescription("Time: 9AM");
                    Console.WriteLine("h9");
                }
                else if (igTime.Hour < h13.Hour)
                {
                    embed.WithDescription("Time: 1PM");
                    tSlot = 1;
                    Console.WriteLine("h13");
                }
                else if (igTime.Hour < h17.Hour)
                {
                    embed.WithDescription("Time: 5PM");
                    Console.WriteLine("h17");
                }
                else if (igTime.Hour < h21.Hour)
                {
                    embed.WithDescription("Time: 9PM");
                    tSlot = 1;
                    Console.WriteLine("h21");
                }
                else
                {
                    Console.WriteLine("else");
                    igTime = igTime.AddDays(1);
                    if (igTime.DayOfWeek == DayOfWeek.Sunday)
                    {
                        embed.WithDescription("Time: 1PM");
                    }
                    else
                    {
                        embed.WithDescription("Time: 1AM");
                    }
                }

                if (igTime.DayOfWeek == DayOfWeek.Monday)
                {
                    if (tSlot == 0)
                    {
                        embed.AddInlineField("Map", "Vulture's Vale\nDesolate Valley");
                        embed.AddInlineField("Name", "Eternal Wise Crab\nMidnight Silverside");
                        embed.AddInlineField("Bait", "Shining Crystal Shell\nTop Fish Head");
                    }
                    else
                    {
                        embed.AddInlineField("Map", "Rainmist Reach\nEmerald Marsh");
                        embed.AddInlineField("Name", "Hypnosis Frog\nBloodthirsty Thornfang");
                        embed.AddInlineField("Bait", "Rainbow Cricket\nFreshly Grilled Sirloin");
                    }
                }
                else if (igTime.DayOfWeek == DayOfWeek.Tuesday)
                {
                    if (tSlot == 0)
                    {
                        embed.AddInlineField("Map", "Port Skandia\nCandetonn Hill\nCrescent Valley");
                        embed.AddInlineField("Name", "Copper Shark King\nStellar Blowfish\nDistorted Phantom");
                        embed.AddInlineField("Bait", "Prince Saury\nOversized Squid\nUltra Heat - Resistant Squid");
                    }
                    else
                    {
                        embed.AddInlineField("Map", "Triatio Highlands\nNorway Snowland");
                        embed.AddInlineField("Name", "King Sand Crab\nWarm Gold Crab");
                        embed.AddInlineField("Bait", "Wriggling River Snail\nFloral Koi");
                    }
                }
                else if (igTime.DayOfWeek == DayOfWeek.Wednesday)
                {
                    if (tSlot == 0)
                    {
                        embed.AddInlineField("Map", "Helonia Coast\nEnchanted Valley\nSecret Lake");
                        embed.AddInlineField("Name", "Deep Sea Tuna\nShadow Butterfly Fish\nGolden Temptation");
                        embed.AddInlineField("Bait", "Small Fluorescent Squid\nNeon Coral\nThick-scented Flourescent Fish");
                    }
                    else
                    {
                        embed.AddInlineField("Map", "Candeo Marsh\nStarstruck Plateau");
                        embed.AddInlineField("Name", "Giant Marsh Trout\nCrimson Wisp Jellyfish");
                        embed.AddInlineField("Bait", "Fresh Marsh Shrimp\nCoral Red Fish");
                    }
                }
                else if (igTime.DayOfWeek == DayOfWeek.Thursday)
                {
                    if (tSlot == 0)
                    {
                        embed.AddInlineField("Map", "Crescent Hill\nPort Morton\nSunset Ridge");
                        embed.AddInlineField("Name", "Golden Petal Fish\nIronclad Swordfish\nGoldstream Guardian");
                        embed.AddInlineField("Bait", "Golden Petal\nLive Emperor Fish\nPink Fragrant Shrimp");
                    }
                    else
                    {
                        embed.AddInlineField("Map", "Ventos Prairie\nCrystal Lake Waterfall");
                        embed.AddInlineField("Name", "Rainbow Salmon\nGlimmershade");
                        embed.AddInlineField("Bait", "Giant Black Mayfly\nAqualord Redshade");
                    }
                }
                else if (igTime.DayOfWeek == DayOfWeek.Friday)
                {
                    if (tSlot == 0)
                    {
                        embed.AddInlineField("Map", "Cactakara Forest\nWhistling Canyon\nBlack Rock Desert");
                        embed.AddInlineField("Name", "Ancient Mandarin Fish\nFlare Tuna\nBlessed Turtle");
                        embed.AddInlineField("Bait", "Magic Fig\nTyrant Nautilus\nPeach-colored Shell");
                    }
                    else
                    {
                        embed.AddInlineField("Map", "Oblitus Wood\nSilent Ice Field\nSacred Valley");
                        embed.AddInlineField("Name", "Waterfall Catfish\nIce Field Continent Turtle\nFlashing Dawn");
                        embed.AddInlineField("Bait", "Green Leech\nPrincess Hardscale Fish\nDazzling Rainbow Fish");
                    }
                }
                else if (igTime.DayOfWeek == DayOfWeek.Saturday)
                {
                    if (tSlot == 0)
                    {
                        embed.AddInlineField("Map", "Demarech Mines\nViridian Steppe");
                        embed.AddInlineField("Name", "Mutant Crystal Lobster\nPhantom Devilfish");
                        embed.AddInlineField("Bait", "Forked-Tail Loach\nSilvercrown Empress Fish");
                    }
                    else
                    {
                        embed.AddInlineField("Map", "Star Sand Desert\nAncient Desert");
                        embed.AddInlineField("Name", "Giant Sand Perch\nDesert Snakehead");
                        embed.AddInlineField("Bait", "Lively Grass Carp\nPatterned Pink Shell");
                    }
                }
                else
                {
                    embed.AddInlineField("Map", "ALL MAPS");
                }
            }

            await Context.Channel.SendMessageAsync("Neppu!", false, embed);
        }

        [Command("arch")]
        public async Task ArchToday()
        {
            DateTime utcNow = DateTime.UtcNow;
            DateTime igTime = utcNow.AddHours(1);
            string imgSrc = "";
            if (igTime.DayOfWeek == DayOfWeek.Sunday) {
                imgSrc = "res/arch/ArchSun.PNG";
            }
            else if (igTime.DayOfWeek == DayOfWeek.Monday)
            {
                imgSrc = "res/arch/ArchMon.PNG";
            }
            else if (igTime.DayOfWeek == DayOfWeek.Tuesday)
            {
                imgSrc = "res/arch/ArchTue.PNG";
            }
            else if (igTime.DayOfWeek == DayOfWeek.Wednesday)
            {
                imgSrc = "res/arch/ArchWed.PNG";
            }
            else if (igTime.DayOfWeek == DayOfWeek.Thursday)
            {
                imgSrc = "res/arch/ArchThu.PNG";
            }
            else if (igTime.DayOfWeek == DayOfWeek.Friday)
            {
                imgSrc = "res/arch/ArchFri.PNG";
            }
            else if (igTime.DayOfWeek == DayOfWeek.Saturday)
            {
                imgSrc = "res/arch/ArchSat.PNG";
            }
            await Context.Channel.SendFileAsync(imgSrc, "These are the Archaeology locations today neppu!");
        }

        /*
        [Command("arch sched")]
        public async Task ArchSched()
        {
            await Context.Channel.SendMessageAsync("This is the Archaeology schedule neppu!");
            await Context.Channel.SendFileAsync("res/arch/ArchSun.PNG");
            await Context.Channel.SendFileAsync("res/arch/ArchMon.PNG");
            await Context.Channel.SendFileAsync("res/arch/ArchTue.PNG");
            await Context.Channel.SendFileAsync("res/arch/ArchWed.PNG");
            await Context.Channel.SendFileAsync("res/arch/ArchThu.PNG");
            await Context.Channel.SendFileAsync("res/arch/ArchFri.PNG");
            await Context.Channel.SendFileAsync("res/arch/ArchSat.PNG");
        }
        */

        [Command("tips")]
        public async Task GivingTips()
        {
            string[] tips = Utilities.GetDatabse("TIPS");
            Random r = new Random();
            int rand = r.Next(0, tips.Length);

            var embed = new EmbedBuilder();
            embed.WithTitle("RANDOM AK TIP");
            embed.WithDescription(tips[rand]);
            embed.WithColor(new Color(180, 0, 255));

            await Context.Channel.SendMessageAsync("", false, embed);
        }

        [Command("gtips")]
        public async Task GivingGuildTips()
        {
            string[] tips = Utilities.GetDatabse("GTIPS");
            Random r = new Random();
            int rand = r.Next(0, tips.Length);

            var embed = new EmbedBuilder();
            embed.WithTitle("RANDOM NEPUNEPU TIP");
            embed.WithDescription(tips[rand]);
            embed.WithColor(new Color(180, 0, 255));

            await Context.Channel.SendMessageAsync("", false, embed);
        }

        [Command("debug")]
        public async Task Debug()
        {
            /*
            DateTime utcNow = DateTime.UtcNow;
            DateTime igTime = utcNow.AddHours(1);
            DateTime h11 = DateTime.Today.AddHours(11D);


            DiscordSocketClient _client = new DiscordSocketClient(); // 2
            _client = Context.Client;
            ulong id = 491959323698921473; // 3
            var chnl = _client.GetChannel(id) as IMessageChannel; // 4
            await chnl.SendMessageAsync(h11.ToString()); // 5
            Console.WriteLine(h11.ToString());
            //await chnl.SendFileAsync("res/arch/ArchMon.PNG");
            */
            /*
            var embed = new EmbedBuilder();
            embed.WithTitle("NEXT FISH KING");
            embed.WithDescription("Time: 12AM");
            embed.WithColor(new Color(255, 0, 255));
            embed.AddInlineField("Map", "Vulture Vale\nABC");
            embed.AddInlineField("Name", "Vulture Vale\nABC");
            embed.AddInlineField("Bait", "Vulture Vale\nABC");

            await Context.Channel.SendMessageAsync("", false, embed);
            */
            string[] tips = Utilities.GetDatabse("TIPS");
            for (int i = 0; i < tips.Length; i++)
            {
                await Context.Channel.SendMessageAsync(tips[i]);
            }
        }

        [Command("choose")]
        public async Task Choose([Remainder]string message)
        {
            string[] options = message.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Random r = new Random();
            string selection = options[r.Next(0, options.Length)];

            /*
            var embed = new EmbedBuilder();
            embed.WithTitle("Echo message");
            embed.WithDescription(message);
            embed.WithColor(new Color(0, 255, 0));
            */

            if (options.Length == 1)
            {
                await Context.Channel.SendMessageAsync("There's only one option >.<");
            }
            else
            {
                await Context.Channel.SendMessageAsync("I choose " + selection + " neppu!");
            }
        }

        [Command("answer")]
        public async Task Answer([Remainder]string message)
        {
            if (message.Length <= 6)
            {
                await Context.Channel.SendMessageAsync("What do you mean? >.<");
            }
            else if (message.Substring(0, 2).ToLower() == "do"
                    || message.Substring(0, 2).ToLower() == "am"
                    || message.Substring(0, 4).ToLower() == "does"
                    || message.Substring(0, 2).ToLower() == "is"
                    || message.Substring(0, 3).ToLower() == "are"
                    || message.Substring(0, 4).ToLower() == "will"
                    || message.Substring(0, 5).ToLower() == "would"
                    || message.Substring(0, 6).ToLower() == "should"
                    || message.Substring(0, 5).ToLower() == "shall"
                    || message.Substring(0, 3).ToLower() == "can"
                    || message.Substring(0, 5).ToLower() == "could"
                    || message.Substring(0, 4).ToLower() == "have")
            {
                Random r = new Random();
                string ans = "";
                int rand = r.Next(0, 3);
                if (rand == 0)
                {
                    ans = "Yes neppu!";
                }
                else if (rand == 1)
                {
                    ans = "No.";
                }
                else
                {
                    ans = "I don't know >.<";
                }
                await Context.Channel.SendMessageAsync(ans);
            }
            else
            {
                await Context.Channel.SendMessageAsync("I don't know >.<");
            }

        }

    }
}
