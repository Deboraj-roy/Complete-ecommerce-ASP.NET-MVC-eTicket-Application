using eTicket.Data.Enums;
using eTicket.Data.Static;
using eTicket.Models;
using Microsoft.AspNetCore.Identity;

namespace eTicket.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Cinema
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "IMAX",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Description = "IMAX is a proprietary system of high-resolution cameras, film formats, film projectors, and theaters known for having very large screens with a tall aspect ratio and steep stadium seating, with the 1.43:1 ratio format being available only in few selected locations."
                        },
                        new Cinema()
                        {
                            Name = "Movie House",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Description = "Movie House is the UK's leading nationwide independent cinema chain - we are proud to offer low ticket prices alongside exceptional guest experience."
                        },
                        new Cinema()
                        {
                            Name = "Great Lakes Cinema 3",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description = "Movie theatre complex with 3 auditoriums and a candy bar, showing mainstream and arthouse films.\r\n"
                        },
                        new Cinema()
                        {
                            Name = "State Cinemas Nelson",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Description = "Over 75 years since the first film society was founded in Wellington.\r\nThe New Zealand Federation of Film Societies continues its dedication to broadening your film-going options.\r\n\r\nYou local Film Society is a link in New Zealand's only alternative non-profit network of film exhibition. As a predominantly voluntary organization the Film Society plays an important role in bringing a diverse range of international films to this country's screens.\r\n\r\nViewing movies is open to everyone, all you'll need to do is purchase a membership through The Nelson Film Society. Booking and reserving your seat is free, but you'll be required to show your verify your current membership card upon arrival for the film session.\r\n\r\nFor more information on joining the Nelson branch of the New Zealand Film Society, just CLICK HERE\r\n\r\nState Cinemas is proud of our relationship with The Nelson Film Society and will be home for their 2024 season of films. They will be screening on Wednesdays at 6pm - Just CLICK HERE to see what content they have for you this year!"
                        },
                        new Cinema()
                        {
                            Name = "NAZARETH Cinema",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Description = "Cinema is the sixteenth studio album by the Scottish hard rock band Nazareth, released in 1986 by Vertigo Records. Cinema. Studio album by. Nazareth.\r\n"
                        },
                    });
                    context.SaveChanges();
                }
                //Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Matt LeBlanc",
                            Bio = "Matthew Steven LeBlanc is an American actor. He garnered global recognition with his portrayal of Joey Tribbiani in the NBC sitcom Friends and in its spin-off series, Joey. For his work on Friends, LeBlanc received three nominations at the Primetime Emmy Awards.",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Actor()
                        {
                            FullName = "Chris Tucker",
                            Bio = "Christopher Tucker is an American stand-up comedian and actor. Tucker made his debut in 1992 as a stand-up performer on the HBO comedy series Def Comedy Jam, where he frequently appeared on the show during the 1990s.",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Angelina Jolie",
                            Bio = "Angelina Jolie is an American actress, filmmaker, and humanitarian. The recipient of numerous accolades, including an Academy Award and three Golden Globe Awards, she has been named Hollywood's highest-paid actress multiple times.",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Jim Carrey",
                            Bio = "Jim Carrey (born January 17, 1962, Newmarket, Ontario, Canada) is a Canadian American comedian who established himself as a leading comedic actor with a series of over-the-top performances and who won plaudits for his more-serious portrayals as his career progressed. Carrey grew up in and around Toronto.",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Will Smith",
                            Bio = "Willard Carroll Smith II is an American actor, rapper and film producer. He has received multiple accolades, including an Academy Award, a Golden Globe Award, a Screen Actors Guild Award, a BAFTA Award, and four Grammy Awards.",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Frank Marshall",
                            Bio = "Frank Wilton Marshall is an American film producer and director. He often collaborates with his wife, film producer Kathleen Kennedy, with whom he founded the production company Amblin Entertainment, along with Steven Spielberg.",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                        new Producer()
                        {
                            FullName = "Steven Spielberg",
                            Bio = "Steven Allan Spielberg is an American filmmaker. A major figure of the New Hollywood era and pioneer of the modern blockbuster, he is the most commercially successful director in history.",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Quentin Tarantino",
                            Bio = "Quentin Jerome Tarantino is an American film director, screenwriter, and actor. His films are characterized by stylized violence, extended dialogue often with profanity, and references to popular culture.",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Spike Lee",
                            Bio = "Shelton Jackson \"Spike\" Lee is an American film director, producer, screenwriter, actor, and author. His work has continually explored race relations, issues within the black community, the role of media in contemporary life, urban crime and poverty, and other political issues",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Jerry Bruckheimer",
                            Bio = "Jerome Leon Bruckheimer is an American film and television producer. He has been active in the genres of action, drama, comedy, fantasy, horror and science fiction. After working in advertising out of college, Bruckheimer moved into film production in the 1970s.",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "Life",
                            Description = "As astronauts discover the first evidence of extra-terrestrial life on Mars, they begin realising that the life form is extremely intelligent and hostile.",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 3,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name = "The Shawshank Redemption",
                            Description = "Andy Dufresne, a successful banker, is arrested for the murders of his wife and her lover, and is sentenced to life imprisonment at the Shawshank prison. He becomes the most unconventional prisoner.",
                            Price = 29.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            CinemaId = 1,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Ghost",
                            Description = "Sam Wheat (Patrick Swayze) is a banker, Molly Jensen (Demi Moore) is an artist, and the two are madly in love. However, when Sam is murdered by friend and corrupt business partner Carl Bruner (Tony Goldwyn) over a shady business deal, he is left to roam the earth as a powerless spirit.",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            CinemaId = 4,
                            ProducerId = 4,
                            MovieCategory = MovieCategory.Horror
                        },
                        new Movie()
                        {
                            Name = "Race",
                            Description = "African-American athlete Jesse Owens faces many difficulties throughout his journey while participating in the 1936 Berlin Olympics.",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            CinemaId = 1,
                            ProducerId = 2,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name = "Scoob",
                            Description = "With hundreds of cases solved and adventures shared, Scooby and the gang face their biggest, most challenging mystery ever -- a plot to unleash the ghost dog Cerberus upon the world. As they race to stop this global dog-pocalypse, the gang discovers that Scooby has a secret legacy and an epic destiny greater than anyone could have imagined.",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 1,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Cartoon
                        },
                        new Movie()
                        {
                            Name = "Cold Soles",
                            Description = "Paul, an actor, struggles while preparing for the role of a Russian poet in a play. With the help of a company, he exchanges his soul with that of the poet, but soon things spiral out of control.",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CinemaId = 1,
                            ProducerId = 5,
                            MovieCategory = MovieCategory.Drama
                        }
                    });
                    context.SaveChanges();
                }
                //Actors & Movies
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 1
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 1
                        },

                         new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 2
                        },
                         new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 2
                        },

                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 3
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 4
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 5
                        },


                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 6
                        },
                    });
                    context.SaveChanges();
                }
            }

        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                }
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                }

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@etickets.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "ADMIN USER",
                        UserName = "admin_user",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                    };

                    await userManager.CreateAsync(newAdminUser, "eTicket@Admin?123");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (adminUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "APPLICATION USER",
                        UserName = "app_user",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                    };

                    await userManager.CreateAsync(newAppUser, "eTicket@User?123");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }

            }
        }
    }
}
