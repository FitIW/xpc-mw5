using System;
using System.Collections.Generic;
using Bogus;
using CookBook.DAL.Entities;
using CookBook.Models;

namespace CookBook.DAL
{
    public class Storage
    {
        public Storage()
        {
            // usedf for deterministic seeds in Bogus/Faker- see https://github.com/bchavez/Bogus#determinism
            Randomizer.Seed = new Random(1533415312);
            Ingredients = SeedIngredients();
            Recipes = SeedRecipes();
            IngredientAmounts = SeedIngredientAmounts();
        }

        public IList<IngredientEntity> Ingredients { get; }
        public IList<IngredientAmountEntity> IngredientAmounts { get; }
        public IList<RecipeEntity> Recipes { get; }

        private IList<IngredientEntity> SeedIngredients(int itemsToGenerate = 80)
        {
            var ingredients = new[]
            {
                "adzuki",
                "agar",
                "amarant",
                "amasaké",
                "amazake",
                "arame",
                "arašídové máslo",
                "arónie",
                "azuki",
                "badyán",
                "batát",
                "batáty",
                "bazalka",
                "bezpluchý oves",
                "bílá ředkev",
                "bílé fazole",
                "bílé miso",
                "bílé zelí",
                "bobkový list",
                "borůvky",
                "brokolice",
                "broskev",
                "broskve",
                "bršlice",
                "bulgur",
                "burizony",
                "burské ořechy",
                "celer",
                "celerová nať",
                "celozrnná mouka",
                "celozrnná rýže",
                "černá čočka",
                "černá fazole",
                "černá jeřabina",
                "černá rýže",
                "černé fazole",
                "černý bez",
                "černý sezam",
                "červená cibule",
                "červená čočka",
                "červená paprika",
                "červená řepa",
                "červené kvašené zelí",
                "česnáček",
                "česnek",
                "čevená cibule",
                "chia",
                "chia semínka",
                "chilli",
                "chřest",
                "cibule",
                "čínské zelí",
                "čirok",
                "citron",
                "citrónová kůra",
                "citronová šťáva",
                "citronová tráva",
                "cizrna",
                "čočka",
                "cuketa",
                "daikon",
                "datle",
                "dýně",
                "dýňová semínka",
                "falafel",
                "fazole",
                "fazolky",
                "fazolky mungo",
                "fenykl",
                "fíky",
                "hatomugi",
                "hlávkový salát",
                "hlíva",
                "hlíva ústřičná",
                "Hokaido",
                "Hokkaido",
                "hořčice",
                "hořčičné semínko",
                "houby",
                "hrách",
                "hrášek",
                "hraška",
                "hřiby",
                "hrozinky",
                "hruška",
                "hrušky",
                "hummus",
                "jabka",
                "jablečný koncentrát",
                "jablka",
                "jablko",
                "jáhly",
                "jahody",
                "jarní cibulka",
                "javorový sirup",
                "ječmen",
                "kadeřávek",
                "kakao",
                "kakaové boby",
                "kapusta",
                "kapustičky",
                "kardamom",
                "karob",
                "kaštany",
                "kedluben",
                "kedlubna",
                "kedlubnové zelí",
                "kinpira",
                "klíčky",
                "kmín",
                "knedlík",
                "knedlíky",
                "kokos",
                "kokosové mléko",
                "kokosový krém",
                "kokosový tuk",
                "kopr",
                "kopřiva",
                "koriandr",
                "křen",
                "kroupy",
                "kukuřice",
                "kukuřičná krupice",
                "kurkuma",
                "kuskus",
                "kuzu",
                "kvásek",
                "kvašená zelenina",
                "kvašené zelí",
                "květák",
                "kysané zelí",
                "limetka",
                "lněné semínko",
                "lopuch",
                "luštěniny",
                "maizena",
                "majoránka",
                "mák",
                "mandle",
                "mandlové máslo",
                "mangold",
                "marmeláda",
                "medvědí česnek",
                "meruňky",
                "mirin",
                "miso",
                "miso pasta",
                "misopasta",
                "mrkev",
                "mungo",
                "mungo fazolky",
                "natto",
                "natto miso",
                "obilné mléko",
                "obiloviny",
                "okurka",
                "ořechy",
                "oříškové máslo",
                "oves",
                "ovesné vločky",
                "ovoce",
                "ovocenka",
                "paprika",
                "petržel",
                "pohanka",
                "pohanková mouka",
                "polenta",
                "pórek",
                "pšenice",
                "quinoa",
                "řapíkatý celer",
                "ředkev",
                "ředkvička",
                "ředkvičky",
                "řepa",
                "římský kmín",
                "rozinky",
                "rozmarýn",
                "rýže",
                "rýžové nudle",
                "rýžový ocet",
                "salát",
                "seitan",
                "semínka",
                "sezam",
                "shoyu",
                "skořice",
                "slad",
                "slunečnice",
                "slunečnicová semínka",
                "soba nudle",
                "sojanéza",
                "sójová omáčka",
                "sójová smetana",
                "špagety",
                "špaldová mouka",
                "sušené houby",
                "sušené mléko",
                "sušené ovoce",
                "švestky",
                "tahini",
                "tekka",
                "tempeh",
                "těstoviny",
                "tofu",
                "tofunéza",
                "topinambury",
                "tuřín",
                "tymián",
                "umeboška",
                "uzené tofu",
                "vlašské ořechy",
                "vločky",
                "vodnice",
                "wakame",
                "žampiony",
                "zázvor",
                "zelené fazolky",
                "zelenina",
                "zelí"
            };

            var faker = new Faker<IngredientEntity>()
                .RuleFor(i => i.Id, f => f.Random.Guid())
                .RuleFor(i => i.Name, f => f.Random.ArrayElement(ingredients))
                .RuleFor(i => i.Description, (f, i) => $"Popis ${i.Name}");
            return faker.Generate(itemsToGenerate);
        }

        private IList<RecipeEntity> SeedRecipes(int itemsToGenerate = 30)
        {
            var recipes = new[]
            {
                "Slovinský orechový závin (Potica)",
                "Vínové venčeky (Taralli dolci)",
                "Ruský veľkonočný chlebík (Kulich)",
                "Kokosové sušienky (Cocadas)",
                "Pečený jahňací chrbát na stredomorský spôsob",
                "Jahňací guláš",
                "Grécke veľkonočné pletence (Tsoureki)",
                "Zemiakový šalát so špenátom a slaninou",
                "Cesnaková hrianka so špenátom a strateným vajíčkom",
                "Krémový špenátový prívarok zapekaný s vajíčkom",
                "Bryndzové pirohy",
                "Avokádovo-banánové smoothie",
                "Torta Esterházy",
                "Pečené kuracie rolky s brokolicou a syrom",
                "Krúpové rizoto so šampiňónmi",
                "Ananásovo-špenátové smoothie",
                "Krehké vanilkové sušienky s džemom",
                "Jablkovo-zázvorový koktail",
                "Nepečený ovsený čokoládový koláč (len z 3 surovín)",
                "Svieži uhorkový šalát s reďkovkami a kôprom",
                "Odpaľované buchtičky so šľahačkou a ovocím",
                "Lahodné pečené reďkovky",
                "Mangovo-kokosové guličky",
                "Nepečený malinový cheesecake",
                "Čučoriedkovo-tvarohový dezert v pohári",
                "Turecký borek so špenátom a fetou",
                "Špenátové pesto",
                "Zeleninová frittata",
                "Ananásové rolky",
                "Krehké slivkové koláčiky (Hamantash)",
                "Vínové venčeky (Taralli dolci)",
                "Marhuľovo-nektárinkový džem so sektom",
                "Jahodový džem s vanilkou so zníženým obsahom kalórií",
                "Pomarančový dresing s oreganom a makom",
                "Jahodové smoothie so zmrzlinou a kvapkou brandy",
                "Cuketovo-jablkový kompót"
            };

            var faker = new Faker<RecipeEntity>()
                .RuleFor(i => i.Id, f => f.Random.Guid())
                .RuleFor(i => i.Name, f => f.Random.ArrayElement(recipes))
                .RuleFor(i => i.Duration, f => f.Date.Timespan(TimeSpan.FromMinutes(80)))
                .RuleFor(i => i.FoodType, f => f.Random.Enum<FoodType>())
                .RuleFor(i => i.ImageUrl, f => f.Image.PicsumUrl())
                .RuleFor(i => i.Description, (f, i) => $"Popis ${i.Name}");
            return faker.Generate(itemsToGenerate);
        }

        private IList<IngredientAmountEntity> SeedIngredientAmounts(int itemsToGenerate = 150)
        {
            var faker = new Faker<IngredientAmountEntity>()
                    .RuleFor(i => i.Id, f => f.Random.Guid())
                    .RuleFor(i => i.Amount, f => f.Random.Number(1, 500))
                    .RuleFor(i=> i.Unit, (f, i) =>
                    {
                        return i.Amount switch
                        {
                            double n when n > 250 => Unit.G,
                            double n when n > 100 => Unit.Ml,
                            double n when n > 50 => Unit.Kg,
                            double n when n > 25 => Unit.L,
                            double n when n > 10 => Unit.Pieces,
                            double n when n > 5 => Unit.Spoon,
                            _ => Unit.Unknown,
                        };
                    })
                    .RuleFor(i => i.IngredientId, f => f.PickRandom(Ingredients).Id)
                    .RuleFor(i => i.RecipeId, f => f.PickRandom(Recipes).Id)
                ;
            return faker.Generate(itemsToGenerate);
        }
    }
}