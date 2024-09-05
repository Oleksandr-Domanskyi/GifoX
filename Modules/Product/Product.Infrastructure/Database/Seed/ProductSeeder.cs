using System;
using Product.Core.Domain;
using Product.Infrastructure.Database.DbContext;
using Product.Product.Core.Domain;
using Product.Service.Core.Domain;
using Shared.Infrastructure.Database;
using static Product.Service.Core.Domain.Enums.Category;

namespace Product.Infrastructure.Database.Seed;

public class ProductSeeder : IDatabaseSeederConfiguration
{
  private readonly ProductDbContext _dbContext;

  public ProductSeeder(ProductDbContext dbContext)
  {
    _dbContext = dbContext;
  }
  public async Task Seed()
  {
    if (await _dbContext.Database.CanConnectAsync())
    {
      if (!_dbContext.Products.Any())
      {
        var seed = new List<ProductModel>()
                {
                  new ProductModel
                  {
                    Name = "Fotel wielopozycyjny z zagłówkiem Level Royokamp WYPRZEDAŻ",
                    Description = "Leżak Level od marki Royokamp postawisz w domu, w ogrodzie, zabierzesz na biwaku, na wakacje, nad jezioro i na plażę."+
                    " Produkt został wykonany z solidnych materiałów, które są odpowiedzialne za wytrzymałość konstrukcji, co pozwoli Ci dłużej cieszyć się użytkowaniem."+
                    " Ponadto, fotel ten jest odporny na wszelkie warunki pogodowe. Odpoczywaj na całego w wygodnym fotelu wielopozycyjnym Level."+
                    " Krzesło stworzy wyjątkowe miejsce relaksu. Leżak posiada wygodny zagłówek, który umili Ci odpoczynek, a który w każdej chwili możesz odpiąć."+
                    " Jego dużym atutem jest fakt, iż umożliwia on siedzenie w pozycji Zero Grvity, którą opatentowali profesjonalni naukowcy."+
                    " Polega ona na położeniu się i uniesieniu nóg powyżej klatki piersiowej. Następuje wtedy odciążenie mięśni i kręgosłupa, uwalniając tym samym od bólu."+
                    " Możesz sam regulować pozycje, w których chcesz leżeć. Na leżąco? Na siedząco? A może w pozycji półleżącej?",
                    Characteristics = new List<string>{ "siedzisko: Oxford 600D",
                                                        "stelaż: metal",
                                                        "wymiary",
                                                        "wersja leżąca: 154 x 60 x 38 cm",
                                                        "wersja siedząca: 113 x 60 x 86 cm",
                                                        "zagłówek: 39 x 13 x 7 cm",
                                                        "długość oparcia: 67 cm",
                                                        "długość siedziska: 50 cm",
                                                        "maksymalna waga użytkownika: 100 kg"},
                    Images = new List<Image>(),
                    Category = MainCategory.SportsAndOutdoor,
                    SubCategory = SubMainCategory.CampingAndHiking,
                    PrNetto = 139.99,
                    PrBrutto = 139.99 * 1.2,
                    IsActive = true,
                    CreatedDate = DateTime.UtcNow,
                    EndDate = default,
                    UserId = Guid.NewGuid().ToString()
                  },
                  new ProductModel
                  {
                    Name = "Plecak Terra 35L Hi Mountain",
                    Description = "Turystyczny plecak Terra 35 marki Hi Mountain to propozycja dla miłośników outdooru, którzy poszukują funkcjonalnego plecaka na całodniowe wyprawy.",
                    Characteristics = new List<string>(),
                    Images = new List<Image>(),
                    Category = MainCategory.SportsAndOutdoor,
                    SubCategory = SubMainCategory.CampingAndHiking,
                    PrNetto = 99.99,
                    PrBrutto = 99.99 * 1.2,
                    ClientFeedbacks = new List<ClientFeedback>(),
                    IsActive = true,
                    CreatedDate = DateTime.UtcNow,
                    EndDate = default,
                    UserId =Guid.NewGuid().ToString()
                  },
                  new ProductModel
                  {
                    Name = "Bieżnia elektryczna XT900 Gymtek",
                    Description = "Odkryj bieżnię elektryczną XT900 Gymtek - Twojego nowego partnera na drodze do doskonałej formy,"+
                    " zaprojektowanego z myślą o domowym użytku, lecz z możliwościami profesjonalnego sprzętu.",
                    Characteristics = new List<string>{ "klasa: HC - do użytku domowego",
                                                        "moc silnika: 3,0 HP",
                                                        "napięcie: 220-240 V (50-60 Hz)",
                                                        "zakres prędkości: 1,0-20,0 km/h (regulacja do 0,1 km/h)",
                                                        "przyciski szybkiego wyboru do zmiany prędkości: 4, 8, 12",
                                                        "maksymalna waga użytkownika: 150 kg",
                                                        "waga netto: 81 kg",
                                                        "waga brutto: 96 kg",
                                                        "automatyczna regulacja poziomu nachylenia pasa bieżnego od 0 do 15% (zmiana co 1%)"},
                    Images = new List<Image>(),
                    Category = MainCategory.SportsAndOutdoor,
                    SubCategory = SubMainCategory.SportsEquipment,
                    PrNetto = 3498.00,
                    PrBrutto = 3498.00 * 1.2,
                    ClientFeedbacks = new List<ClientFeedback>(),
                    IsActive = true,
                    CreatedDate = DateTime.UtcNow,
                    EndDate = default,
                    UserId = Guid.NewGuid().ToString()
                  },
                  new ProductModel
                  {
                    Name ="Słuchawki bezprzewodowe nauszne Tune 520BT JBL",
                    Description = "Słuchawki bezprzewodowe nauszne Tune JBL to idealne rozwiązanie dla miłośników muzyki, którzy cenią sobie wolność i wygodę."+
                    "Dzięki technologii Bluetooth możesz cieszyć się ulubionymi utworami bez zamęczania przewodami."+
                    " Wysokiej jakości dźwięk gwarantuje doskonały bas i czyste, klarowne tony."+
                    " Funkcja redukcji szumów pozwala na skupienie się na muzyce i odcięcie od otaczającego hałasu."+
                    " Regulacja głośności i kontrola odtwarzania są intuicyjne i łatwe w obsłudze."+
                    " Słuchawki są wygodne i lekkie, dzięki czemu możesz ich używać przez długi czas bez dyskomfortu."+
                    " Słuchawki bezprzewodowe nauszne Tune JBL to prawdziwa uczta dla zmysłów.",
                    Characteristics = new List<string>
                                    { "zasilanie: 5 V, 1 A",
                                      "maks. SPL: 95 dB",
                                      "czułość mikrofonu: -29 dBV przy 1 kHz/Pa",
                                      "maksymalna temperatura pracy: 45°C",
                                      "składana konstrukcja",
                                      "brzmienie JBL Pure Bass"},
                    Images = new List<Image>(),
                    Category = MainCategory.Electronics,
                    SubCategory = SubMainCategory.Accessories,
                    PrNetto = 189.99,
                    PrBrutto = 189.99 * 1.2,
                    ClientFeedbacks = new List<ClientFeedback>(){
                        new ClientFeedback{
                            Raiting = 4.5,
                            Comment = "The product has justified its price and quality",
                            ProductAdvantages = new List<string>{"Comfortable","Good material","Cheep"},
                            ProductDisadvantages = new List<string>{"",""},
                            CreatedDate = DateTime.UtcNow,
                        },
                        new ClientFeedback{
                            Raiting = 2.0,
                            Comment = "The product went for a long time, as much as 2 months!!!. When I received the product, it looked normal, but broke after a week of use",
                            ProductAdvantages = new List<string>{"",""},
                            ProductDisadvantages = new List<string>{ "long delivery time", "terrible quality"},
                            CreatedDate = DateTime.UtcNow,
                        }
                    },
                    IsActive = true,
                    CreatedDate = DateTime.UtcNow,
                    EndDate = default,
                    UserId =Guid.NewGuid().ToString()
                  },
                   new ProductModel
                  {
                    Name ="Opaska usztywniająca na nadgarstek prawy Mueller Green",
                    Description = "Jedna z najbardziej komfortowych opasek usztywniających na nadgarstek na rynku. Wypróbuj model marki Mueller Green.",
                    Characteristics = new List<string>{"materiał: nylon",
                                                    "zapięcie z dwoma paskami na rzepy",
                                                    "dwa wkłady gąbkowe przy szynach",
                                                    "aplikacja z logo marki"},
                    Images = new List<Image>(),
                    Category = MainCategory.Electronics,
                    SubCategory = SubMainCategory.Accessories,
                    PrNetto = 119.99,
                    PrBrutto = 119.99 * 1.2,
                     ClientFeedbacks = new List<ClientFeedback>()
                     {
                        new ClientFeedback{
                            Raiting = 5.0,
                            Comment = "The product has justified its price and quality",
                            ProductAdvantages = new List<string>{"Comfortable","Good material","Cheep"},
                            ProductDisadvantages = new List<string>{"",""},
                            CreatedDate = DateTime.UtcNow,
                        },
                        new ClientFeedback{
                            Raiting = 2.0,
                            Comment = "The product went for a long time, as much as 2 months!!!. When I received the product, it looked normal, but broke after a week of use",
                            ProductAdvantages = new List<string>{"",""},
                            ProductDisadvantages = new List<string>{ "long delivery time", "terrible quality"},
                            CreatedDate = DateTime.UtcNow,
                        }
                     },
                    IsActive = true,
                    CreatedDate = DateTime.UtcNow,
                    EndDate = default,
                    UserId = Guid.NewGuid().ToString(),
                  }
                };
        await _dbContext.Products.AddRangeAsync(seed);
        await _dbContext.SaveChangesAsync();

      }
    }
  }

}
