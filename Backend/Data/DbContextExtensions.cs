using System.Collections.Generic;
using System.Linq;
using Backend.Model;
using Microsoft.AspNetCore.Identity;

namespace Backend.Data
{
    public static class DbContextExtensions
    {
        public static UserManager<User> UserManager { get; set; }
        public static RoleManager<Role> RoleManager { get; set; }

        public static void EnsureSeeded(this Context context)
        {
            AddRoles(context);
            AddUsers(context);
            AddGenres(context);
            AddDirectors(context);
            AddActors(context);
            AddMovie(context);
        }
        private static void AddUsers(Context context)
        {
            if (UserManager.FindByEmailAsync("test@test.io")
            .GetAwaiter().GetResult() == null)
            {
                var user = new User
                {
                    FirstName = "test",
                    LastName = "Testing",
                    UserName = "test@test.io",
                    Email = "test@test.io"
                };
                UserManager.CreateAsync(user, "Password7*").GetAwaiter().GetResult();
            }
            var admin = UserManager.FindByEmailAsync("test@test.io")
            .GetAwaiter().GetResult();

            if (UserManager.IsInRoleAsync(admin, "Admin")
            .GetAwaiter().GetResult() == false)
                UserManager.AddToRoleAsync(admin, "Admin");
        }
        private static void AddRoles(Context context)
        {
            if (RoleManager.RoleExistsAsync("Admin")
            .GetAwaiter().GetResult() == false)
                RoleManager.CreateAsync(new Role("Admin")).GetAwaiter().GetResult();

            if (RoleManager.RoleExistsAsync("User")
            .GetAwaiter().GetResult() == false)
                RoleManager.CreateAsync(new Role("User")).GetAwaiter().GetResult();
        }
        private static void AddGenres(Context context)
        {
            if (context.Genres.Any() == false)
            {
                var g1 = new Genre
                {
                    Name = "Комедия"
                };
                var g2 = new Genre
                {
                    Name = "Sci-Fi"
                };
                var g3 = new Genre
                {
                    Name = "Киберпанк"
                };
                var g4 = new Genre
                {
                    Name = "Криминал"
                };
                var g5 = new Genre
                {
                    Name = "Боевик"
                };
                var g6 = new Genre
                {
                    Name = "Приключение"
                };
                var g7 = new Genre
                {
                    Name = "Семейный"
                };
                var g8 = new Genre
                {
                    Name = "Триллер"
                };
                var g9 = new Genre
                {
                    Name = "Мультфильм"
                };
                var g10 = new Genre
                {
                    Name = "Детектив"
                };
                var g11 = new Genre
                {
                    Name = "Детский"
                };
                var g12 = new Genre
                {
                    Name = "Фантастика"
                };
                var g13 = new Genre
                {
                    Name = "Фэнтези"
                };
                var genres = new List<Genre>()
                {
                    g1,g2,g3,g4,g5,g6,g7,g8,g9,
                    g10,g11,g12,g13
                };
                context.Genres.AddRange(genres);
                context.SaveChanges();
            }
        }
        private static void AddActors(Context context)
        {
            if (context.Actors.Any() == false)
            {
                var a1 = new Actor
                {
                    Name = "Райан Гослинг"
                };
                var a2 = new Actor
                {
                    Name = "Харрисон Форд"
                };
                var a3 = new Actor
                {
                    Name = "Джаред Лето"
                };
                var a4 = new Actor
                {
                    Name = "Ана де Армас"
                };
                var a5 = new Actor
                {
                    Name = "Роберт Дауни мл."
                };
                var a6 = new Actor
                {
                    Name = "Джефф Бриджес"
                };
                var a7 = new Actor
                {
                    Name = "Терренс Ховард"
                };
                var a8 = new Actor
                {
                    Name = "Кларк Грегг"
                };
                var a9 = new Actor
                {
                    Name = "Микки Рурк"
                };
                var a10 = new Actor
                {
                    Name = "Дон Чидл"
                };
                var a11 = new Actor
                {
                    Name = "Скарлетт Йохансон"
                };
                var a12 = new Actor
                {
                    Name = "Крис Хемсворт"
                };
                var a13 = new Actor
                {
                    Name = "Натали Портман"
                };
                var a14 = new Actor
                {
                    Name = "Том Хиддлстон"
                };
                var a15 = new Actor
                {
                    Name = "Энтони Хопкинс"
                };
                var a16 = new Actor
                {
                    Name = "Крис Эванс"
                };
                var a17 = new Actor
                {
                    Name = "Марк Руффало"
                };
                var a18 = new Actor
                {
                    Name = "Джереми Реннер"
                };
                var a19 = new Actor
                {
                    Name = "Джим Керри"
                };
                var a20 = new Actor
                {
                    Name = "Карла Куджино"
                };
                var a21 = new Actor
                {
                    Name = "Анжела Лэнсбери"
                };
                var a22 = new Actor
                {
                    Name = "Офелия Ловинбонд"
                };
                var a23 = new Actor
                {
                    Name = "Кортни Кокс"
                };
                var a24 = new Actor
                {
                    Name = "Шон Янг"
                };
                var a25 = new Actor
                {
                    Name = "Тоун Лок"
                };
                var a26 = new Actor
                {
                    Name = "Удо Кир"
                };
                var a27 = new Actor
                {
                    Name = "Иэн МакНис"
                };
                var a28 = new Actor
                {
                    Name = "Саймон Кэллоу"
                };
                var a29 = new Actor
                {
                    Name = "Боб Гантон"
                };
                var a30 = new Actor
                {
                    Name = "Софи Оконедо"
                };
                var a31 = new Actor
                {
                    Name = "Билли Боб Торнтон"
                };
                var a32 = new Actor
                {
                    Name = "Кэти Бейтс"
                };
                var a33 = new Actor
                {
                    Name = "Тони Кокс"
                };
                var a34 = new Actor
                {
                    Name = "Кристана Хендрикс"
                };
                var a35 = new Actor
                {
                    Name = "Джон Си Райли"
                };
                var a36 = new Actor
                {
                    Name = "Сара Сильверман"
                };
                var a37 = new Actor
                {
                    Name = "Алан Тьюдик"
                };
                var a38 = new Actor
                {
                    Name = "Джек Макбрайер"
                };
                var a39 = new Actor
                {
                    Name = "Роже Карель"
                };
                var a40 = new Actor
                {
                    Name = "Гийом Бриа"
                };
                var a41 = new Actor
                {
                    Name = "Лоран Дойч"
                };
                var a42 = new Actor
                {
                    Name = "Ален Шаба"
                };
                var a43 = new Actor
                {
                    Name = "Колин Фаррелл"
                };
                var a44 = new Actor
                {
                    Name = "Кейт Бекинсейл"
                };
                var a45 = new Actor
                {
                    Name = "Джессика Бил"
                };
                var a46 = new Actor
                {
                    Name = "Брайан Крэнстон"
                };
                var actors = new List<Actor>()
                {
                    a1,a2,a3,a4,a5,a6,a7,a8,a9,a10
                };
                context.Actors.AddRange(actors);
                context.SaveChanges();
                actors = new List<Actor>()
                {
                    a11,a12,a13,a14,a15,a16,a17,a18,a19,a20
                };
                context.Actors.AddRange(actors);
                context.SaveChanges();
                actors = new List<Actor>()
                {
                    a21,a22,a23,a24,a25,a26,a27,a28,a29,a30
                };
                context.Actors.AddRange(actors);
                context.SaveChanges();
                actors = new List<Actor>()
                {
                    a31,a32,a33,a34,a35,a36,a37,a38,a39,a40
                };
                context.Actors.AddRange(actors);
                context.SaveChanges();
                actors = new List<Actor>()
                {
                    a41,a42,a43,a44,a45,a46
                };
                context.Actors.AddRange(actors);
                context.SaveChanges();

            }
        }
        private static void AddDirectors(Context context)
        {
            if (context.Directors.Any() == false)
            {
                var d1 = new Director
                {
                    Name = "Дэни Вильнёв"
                };
                var d2 = new Director
                {
                    Name = "Джон Фавро"
                };
                var d3 = new Director
                {
                    Name = "Джосс Уидон"
                };
                var d4 = new Director
                {
                    Name = "Кеннет Брана"
                };
                var d5 = new Director
                {
                    Name = "Марк Уотерс"
                };
                var d6 = new Director
                {
                    Name = "Том Шэдьяк"
                };
                var d7 = new Director
                {
                    Name = "Стив Одекерк"
                };
                var d8 = new Director
                {
                    Name = "Рич Мур"
                };
                var d9 = new Director
                {
                    Name = "Александр Астье"
                };
                var d10 = new Director
                {
                    Name = "Лен Уайзман"
                };
                var directors = new List<Director>(){
                    d1,d2,d3,d4,d5,d6,d7,d8,d9,d10
                };
                context.Directors.AddRange(directors);
                context.SaveChanges();
            };
        }
        private static void AddMovie(Context context)
        {
            if (context.Movies.Any() == false)
            {
                var m1 = new Movie
                {
                    Name = "Бегущий по лезвию 2049",
                    Poster = "https://avatars.mds.yandex.net/get-kinopoisk-image/1946459/910a3261-ff47-4cc7-866c-6e0388ef3ecc/x1000",
                    Description = @"В недалеком будущем мир населен людьми и репликантами, 
                    созданными выполнять самую тяжелую работу. 
                    Работа офицера полиции Кей — держать репликантов под контролем в условиях нарастающего напряжения… 
                    Пока он случайно не становится обладателем секретной информации, 
                    которая ставит под угрозу существование всего человечества. 
                    Желая найти ключ к разгадке, Кей решает разыскать Рика Декарда, 
                    бывшего офицера специального подразделения полиции Лос-Анджелеса, который бесследно исчез много лет назад.",
                    DirectorId = 1,
                    MovieActors = new List<MovieActors>
                    {
                        new MovieActors
                        {
                            ActorId = 1
                        },
                        new MovieActors
                        {
                            ActorId = 2
                        },
                        new MovieActors
                        {
                            ActorId = 3
                        },
                        new MovieActors
                        {
                            ActorId = 4
                        }
                    },
                    MovieGenres = new List<MovieGenres>
                    {
                        new MovieGenres
                        {
                            GenreId=2
                        },
                        new MovieGenres
                        {
                            GenreId=3
                        },
                        new MovieGenres
                        {
                            GenreId=5
                        },
                        new MovieGenres
                        {
                            GenreId=8
                        },
                        new MovieGenres
                        {
                            GenreId=10
                        }
                    }
                };
                var m2 = new Movie
                {
                    Name = "Железный человек",
                    Poster = "https://avatars.mds.yandex.net/get-kinopoisk-image/1599028/555359d8-7866-4113-b0c5-b5e13e3bf1c8/x1000",
                    Description = @"Миллиардер-изобретатель Тони Старк попадает в плен к Афганским террористам, 
                    которые пытаются заставить его создать оружие массового поражения. 
                    В тайне от своих захватчиков Старк конструирует высокотехнологичную киберброню, 
                    которая помогает ему сбежать. Однако по возвращении в США он узнаёт, 
                    что в совете директоров его фирмы плетётся заговор, чреватый страшными последствиями. 
                    Используя своё последнее изобретение, Старк пытается решить проблемы своей компании радикально…",
                    DirectorId = 2,
                    MovieActors = new List<MovieActors>
                    {
                        new MovieActors
                        {
                            ActorId = 5
                        },
                        new MovieActors
                        {
                            ActorId = 6
                        },
                        new MovieActors
                        {
                            ActorId = 7
                        },
                        new MovieActors
                        {
                            ActorId = 8
                        }
                    },
                    MovieGenres = new List<MovieGenres>
                    {
                        new MovieGenres
                        {
                            GenreId=5
                        },
                        new MovieGenres
                        {
                            GenreId=12
                        }
                    }
                };
                var m3 = new Movie
                {
                    Name = "Железный человек 2",
                    Poster = "https://avatars.mds.yandex.net/get-kinopoisk-image/1629390/ed4b6bbb-f755-4977-bf33-005d2c30f67f/x1000",
                    Description = @"Прошло полгода с тех пор, как мир узнал, что миллиардер-изобретатель Тони Старк является обладателем уникальной кибер-брони Железного человека. 
                    Общественность требует, чтобы Старк передал технологию брони правительству США, но Тони не хочет разглашать её секреты, потому что боится, 
                    что она попадёт не в те руки.
                    
                    Между тем Иван Ванко — сын русского учёного, когда-то работавшего на фирму Старка, но потом уволенного и лишенного всего, 
                    намерен отомстить Тони за беды своей семьи. Для чего сооружает своё высокотехнологичное оружие.",
                    DirectorId = 2,
                    MovieActors = new List<MovieActors>
                    {
                        new MovieActors
                        {
                            ActorId = 5
                        },
                        new MovieActors
                        {
                            ActorId = 8
                        },
                        new MovieActors
                        {
                            ActorId = 10
                        },
                        new MovieActors
                        {
                            ActorId = 11
                        },
                    },
                    MovieGenres = new List<MovieGenres>
                    {
                        new MovieGenres
                        {
                            GenreId=6
                        },
                        new MovieGenres
                        {
                            GenreId=12
                        }
                    }
                };
                var m4 = new Movie
                {
                    Name = "Тор",
                    Poster = "https://avatars.mds.yandex.net/get-kinopoisk-image/1599028/09f0bad6-9ea6-430f-9b7d-47369e51d7f2/x1000",
                    Description = @"Эпическое приключение происходит как на нашей планете Земля, так и в королевстве богов Асгарде. 
                    В центре истории — Могучий Тор, сильный, но высокомерный воин, чьи безрассудные поступки возрождают древнюю войну в Асгарде. 
                    Тора отправляют в ссылку на Землю, лишают сил и заставляют жить среди обычных людей в качестве наказания…",
                    DirectorId = 4,
                    MovieActors = new List<MovieActors>
                    {
                        new MovieActors
                        {
                        ActorId = 12
                        },
                        new MovieActors
                        {
                            ActorId = 13
                        },
                        new MovieActors
                        {
                            ActorId = 14
                        },
                        new MovieActors
                        {
                            ActorId = 15
                        },
                        new MovieActors
                        {
                            ActorId = 8
                        },
                    },
                    MovieGenres = new List<MovieGenres>
                    {
                        new MovieGenres
                        {
                            GenreId=5
                        },
                        new MovieGenres
                        {
                            GenreId=12
                        }
                    }
                };
                var m5 = new Movie
                {
                    Name = "Мстители",
                    Poster = "https://avatars.mds.yandex.net/get-kinopoisk-image/1600647/afab999b-c6bb-4fac-a951-03f72fd2b8cf/x1000",
                    Description = @"Локи, сводный брат Тора, возвращается, и в этот раз он не один. Земля на грани порабощения, 
                    и только лучшие из лучших могут спасти человечество.
                    
                    Ник Фьюри, глава международной организации Щ. И. Т., собирает выдающихся поборников справедливости и добра, 
                    чтобы отразить атаку. Под предводительством Капитана Америки Железный Человек, Тор, Невероятный Халк, Соколиный глаз и Чёрная Вдова вступают в войну с захватчиком.",
                    DirectorId = 3,
                    MovieActors = new List<MovieActors>
                    {
                        new MovieActors 
                        {
                            ActorId = 5
                        },
                        new MovieActors 
                        {
                            ActorId = 8
                        },
                        new MovieActors 
                        {
                            ActorId = 11
                        },
                        new MovieActors 
                        {
                            ActorId = 12
                        },
                        new MovieActors 
                        {
                            ActorId = 14
                        },
                        new MovieActors 
                        {
                            ActorId = 16
                        },
                        new MovieActors 
                        {
                            ActorId = 17
                        },
                        new MovieActors 
                        {
                            ActorId = 18
                        }
                    },
                    MovieGenres = new List<MovieGenres>
                    {
                        new MovieGenres
                        {
                            GenreId=5
                        },
                        new MovieGenres
                        {
                            GenreId=6
                        },
                        new MovieGenres
                        {
                            GenreId=12
                        }
                    }
                };
                var m6 = new Movie
                {
                    Name = "Пингвины мистера Поппера",
                    Poster = "https://avatars.mds.yandex.net/get-kinopoisk-image/1629390/9049ab97-6077-4479-bb03-1d84ec50b80c/x1000",
                    Description = @"Какую только свинью порой ни подложит судьба! Правда, на этот раз она решила обойтись более экзотическими животными. 
                    
                    Преуспевающий бизнесмен получает в наследство шестерых пингвинов и буквально влюбляется в них. 
                    Работа оказывается заброшенной, шикарные апартаменты превращаются в заснеженную обитель, 
                    дело даже почти доходит до тюрьмы. Но стоит ли сожалеть о мишуре, пусть даже и золотой, если взамен тебе открывается такой необычный, и вместе с тем такой настоящий мир?",
                    DirectorId = 5,
                    MovieActors = new List<MovieActors>
                    {
                        new MovieActors
                        {
                            ActorId=8
                        },
                        new MovieActors
                        {
                            ActorId=19
                        },
                        new MovieActors
                        {
                            ActorId=20
                        },
                        new MovieActors
                        {
                            ActorId=21
                        },
                        new MovieActors
                        {
                            ActorId=22
                        }
                    },
                    MovieGenres = new List<MovieGenres>
                    {
                        new MovieGenres
                        {
                            GenreId=1
                        },
                        new MovieGenres
                        {
                            GenreId=7
                        }
                    }
                };
                var m7 = new Movie
                {
                    Name = "Эйс Вентура: Розыск домашних животных",
                    Poster = "https://avatars.mds.yandex.net/get-kinopoisk-image/1898899/8a5dc327-2cbc-4d6b-a7c5-8a74fe6a26e1/x1000",
                    Description = @"Он — лучший в своем деле, единственный и неповторимый! Он — Эйс Вентура, детектив по розыску домашних любимцев. 
                    Когда таинственные злоумышленники похищают дельфина по кличке Снежинка, талисман местной футбольной команды «Дельфины», 
                    Эйс тут же приступает к работе, проявляя чудеса изобретательности. 
                    
                    История принимает странный оборот, когда похищают еще и ведущего игрока «Дельфинов». 
                    Теперь Эйсу приходится разыскивать сразу двух млекопитающих. 
                    Он сталкивается нос к носу с акулой-людоедом, спасает любимую команду и очаровывает женщин. Находится ли он под прикрытием, под огнем или под водой, он обязательно найдет то, что ищет!",
                    DirectorId = 6,
                    MovieActors = new List<MovieActors>
                    {
                        new MovieActors
                        {
                            ActorId=19
                        },
                        new MovieActors
                        {
                            ActorId=23
                        },
                        new MovieActors
                        {
                            ActorId=24
                        },
                        new MovieActors
                        {
                            ActorId=25
                        },
                        new MovieActors
                        {
                            ActorId=26
                        }
                    },
                    MovieGenres = new List<MovieGenres>
                    {
                        new MovieGenres
                        {
                            GenreId=1
                        },
                        new MovieGenres
                        {
                            GenreId=6
                        },
                        new MovieGenres
                        {
                            GenreId=10
                        }
                    }
                };
                var m8 = new Movie
                {
                    Name = "Эйс Вентура 2: Когда зовет природа",
                    Poster = "https://avatars.mds.yandex.net/get-kinopoisk-image/1704946/4e85be04-4fa5-488e-a4c5-2b57d90ad7ac/x1000",
                    Description = @"Место действия — Африка. Знаменитый детектив Эйс Вентура, единственный в мире специалист по розыску пропавших домашних любимцев, снова в деле. 
                    На этот раз Эйс должен найти Шикаку — священное животное племени Вачати. Без Шикаки не может состояться свадьба дочери вождя племени Вачати и сына вождя воинственного племени Вачуту.
                    
                    Если Эйс провалит задание, начнется межплеменная война. Но Эйс Вентура не из тех, кто отступает перед трудностями. 
                    В поисках священной Шикаки он сражается с аллигаторами, приручает слонов, подражает обезьянам, качается на лианах, ходит по раскаленным углям, вылезает, к ужасу семьи американских туристов, из задницы носорога и ставит «на уши» всю Африку.",
                    DirectorId = 7,
                    MovieActors = new List<MovieActors>
                    {
                        new MovieActors
                        {
                            ActorId=19
                        },
                        new MovieActors
                        {
                            ActorId=27
                        },
                        new MovieActors
                        {
                            ActorId=28
                        },
                        new MovieActors
                        {
                            ActorId=29
                        },
                        new MovieActors
                        {
                            ActorId=30
                        }
                    },
                    MovieGenres = new List<MovieGenres>
                    {
                        new MovieGenres
                        {
                            GenreId=1
                        },
                        new MovieGenres
                        {
                            GenreId=6
                        },
                        new MovieGenres
                        {
                            GenreId=10
                        }
                    }
                };
                var m9 = new Movie
                {
                    Name = "Плохой Санта 2",
                    Poster = "https://avatars.mds.yandex.net/get-kinopoisk-image/1599028/c743df4a-6aa5-44e5-a6d8-4c5c5ab2f2db/x1000",
                    Description = @"Продолжение новогодних приключений проходимца Вилли, 
                    который в канун Рождества, как всегда, переодевается в Санта-Клауса. 
                    Ограбить очередной супермаркет в этом наряде не представляет никаких проблем. 
                    Но в Рождество случаются всякие чудеса. Каким оно будет для Вилли на этот раз?",
                    DirectorId = 5,
                    MovieActors = new List<MovieActors>
                    {
                        new MovieActors
                        {
                            ActorId=31
                        },
                        new MovieActors
                        {
                            ActorId=32
                        },
                        new MovieActors
                        {
                            ActorId=33
                        },
                        new MovieActors
                        {
                            ActorId=34
                        }
                    },
                    MovieGenres = new List<MovieGenres>
                    {
                        new MovieGenres
                        {
                            GenreId=1
                        },
                        new MovieGenres
                        {
                            GenreId=4
                        }
                    }
                };
                var m10 = new Movie
                {
                    Name = "Ральф",
                    Poster = "https://avatars.mds.yandex.net/get-kinopoisk-image/1599028/1a217dd3-6970-4ae2-9fa3-eebb4bffaa28/x1000",
                    Description = @"Ральф — второстепенный персонаж восьмибитной компьютерной игры, и ему надоело находиться в тени главного героя, 
                    мастера на все руки Феликса, который всегда появляется, чтобы «исправить» ситуацию! После тридцати лет добросовестной работы в роли злодея, 
                    в течение которых все похвалы выпадали на долю Феликса, Ральф больше не хочет быть плохим. 
                    
                    Он решает отправиться в путешествие по аркадным играм разных жанров, 
                    чтобы доказать всем, что и он тоже может быть героем. На своем пути Ральф встречает героев разных игр — хладнокровную сержанта Калхун из игры Hero’s Duty, 
                    оберегающую планету от нашествия инопланетных захватчиков, и сладкую на вид, но острую на язычок Сластену фон Дю, чье существование в гоночном симуляторе Sugar Rush внезапно оказывается под угрозой. 
                    Наконец-то Ральфу выпадает шанс показать, что он умеет не только разрушать!",
                    DirectorId = 8,
                    MovieActors = new List<MovieActors>
                    {
                        new MovieActors
                        {
                            ActorId=35
                        },
                        new MovieActors
                        {
                            ActorId=36
                        },
                        new MovieActors
                        {
                            ActorId=37
                        },
                        new MovieActors
                        {
                            ActorId=38
                        }
                    },
                    MovieGenres = new List<MovieGenres>
                    {
                        new MovieGenres
                        {
                            GenreId=1
                        },
                        new MovieGenres
                        {
                            GenreId=6
                        },
                        new MovieGenres
                        {
                            GenreId=9
                        },
                        new MovieGenres
                        {
                            GenreId=13
                        }
                    }

                };
                var m11 = new Movie
                {
                    Name = "Астерикс: Земля богов",
                    Poster = "https://avatars.mds.yandex.net/get-kinopoisk-image/1600647/56f9dc08-1a01-48bb-89c7-0bf21200e51e/x1000",
                    Description = @"Астерикс и его лучший друг Обеликс продолжают свою многолетнюю борьбу с Цезарем, 
                    который хочет наконец-то расправиться с неукротимыми галлами. Вокруг деревни Астерикса Цезарь приказывает построить новый Рим — Землю Богов. 
                    В галльской деревне хаос и смятение. Но Астерикс и Обеликс не сдаются!",
                    DirectorId = 9,
                    MovieActors = new List<MovieActors>
                    {
                        new MovieActors
                        {
                            ActorId=39
                        },
                        new MovieActors
                        {
                            ActorId=40
                        },
                        new MovieActors
                        {
                            ActorId=41
                        },
                        new MovieActors
                        {
                            ActorId=42
                        }
                    },
                    MovieGenres = new List<MovieGenres>
                    {
                        new MovieGenres
                        {
                            GenreId=1
                        },
                        new MovieGenres
                        {
                            GenreId=6
                        },
                        new MovieGenres
                        {
                            GenreId=9
                        },
                        new MovieGenres
                        {
                            GenreId=13
                        }
                    }
                };
                var m12 = new Movie
                {
                    Name = "Вспомнить всё",
                    Poster = "https://avatars.mds.yandex.net/get-kinopoisk-image/1599028/b850e0d9-a6cc-4ada-a1e1-8c0a17b27975/x1000",
                    Description = @"Он — обычный рабочий-строитель, живущий в маленькой квартирке в захудалом районе города будущего где-то в Новой Азии. Хотя собственная жизнь его в целом устраивает, он не может избавиться от чувства, 
                    что ему хочется чего-то большего. Потребность в новых будоражащих впечатлениях приводит его в офис компании «Вспомнить всё», имплантирующей в память своих клиентов воспоминания-фантазии, которые они могут получить не рискуя при этом пережить сами события в реальности. 
                    Пока герой выбирает, какие именно воспоминания ему приобрести, отряд спецназа штурмует комнату, где он находится, и уже было берет его под арест. К своему собственному удивлению, он молниеносно уничтожает весь отряд при помощи невероятных бойцовских навыков, 
                    о владении которыми он и не подозревал…",
                    DirectorId = 10,
                    MovieActors = new List<MovieActors>
                    {
                        new MovieActors
                        {
                            ActorId=43
                        },
                        new MovieActors
                        {
                            ActorId=44
                        },
                        new MovieActors
                        {
                            ActorId=45
                        },
                        new MovieActors
                        {
                            ActorId=46
                        }
                    },
                    MovieGenres = new List<MovieGenres>
                    {
                        new MovieGenres
                        {
                            GenreId=3
                        },
                        new MovieGenres
                        {
                            GenreId=5
                        },
                        new MovieGenres
                        {
                            GenreId=8
                        },
                        new MovieGenres
                        {
                            GenreId=12
                        }
                    }
                };
                var movies = new List<Movie>()
                {
                    m1,
                    m2,m3,m4,m5,m6,m7,m8,m9,m10,m11,m12
                };
                context.Movies.AddRange(movies);
                context.SaveChanges();
                // m1.MovieActors.AddRange(new List<MovieActors>
                // {
                //     new MovieActors
                //     {
                //     MovieId = m1.id,
                //     ActorId = 1
                //     },
                //     new MovieActors
                //     {
                //     MovieId = m1.id,
                //     ActorId = 2
                //     },
                //     new MovieActors
                //     {
                //     MovieId = m1.id,
                //     ActorId = 3
                //     },
                //     new MovieActors
                //     {
                //     MovieId = m1.id,
                //     ActorId = 4
                //     }
                // });
                // context.SaveChanges();
            }
        }
    }
}