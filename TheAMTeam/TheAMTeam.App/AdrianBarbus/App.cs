using System;
using TheAMTeam.DataAccessLayer.Repositories;
using TheAMTeam.DataAccessLayer.Entities;

namespace TheAMTeam.App.AdrianBarbus
{
    public class App
    {
        private static readonly ArticlesRepository articlesRepository = new ArticlesRepository();

        public static void PrintArticle(Article a)
        {
            Console.WriteLine($"ID:{a.ArticleId}  Author:{a.Author}");
        }
        

        public static void Execute()
        {

            Article article = new Article
            {
                ArticleId = 4,
                Author = "Marcel",
                PublishedDate = new DateTime(2017,2,8),
                Content = "Here is content",
                ImageURL = "https://www.google.ro/search?q=sport&rlz=1C1GCEA_enRO805RO805&tbm=isch&source=lnms&sa=X&ved=0ahUKEwj1j7jAiKjcAhWOx6YKHTRhBlAQ_AUICygC&biw=1536&bih=715&dpr=1.25#imgrc=dfhE_cI5huF03M:",
                Title = "Sport",
                CategoryId = 1

            };
            Article article1 = new Article
            {
                ArticleId = 10,
                Author = "Pavel",
                PublishedDate = new DateTime(2017, 2, 8),
                Content = "Here is content",
                ImageURL = "https://www.google.ro/search?q=sport&rlz=1C1GCEA_enRO805RO805&tbm=isch&source=lnms&sa=X&ved=0ahUKEwj1j7jAiKjcAhWOx6YKHTRhBlAQ_AUICygC&biw=1536&bih=715&dpr=1.25#imgrc=dfhE_cI5huF03M:",
                Title = "Sport",
                CategoryId = 2
            };

            Console.Write("Select a number from 0 to 5: ");
            int caseSwitch = Int32.Parse(Console.ReadLine());

            while (caseSwitch != 0)
            {
                switch (caseSwitch)
                {
                    case 0:
                        return;
                    case 1:
                        foreach(Article a in articlesRepository.GetAll())
                        {
                            PrintArticle(a);
                        }
                        break;
                    case 2:
                        var entity = articlesRepository.GetById(5);
                        PrintArticle(entity);
                        break;
                    case 3:
                        articlesRepository.Add(article);
                        break;
                    case 4:
                        articlesRepository.Update(article1);
                        break;
                    case 5:
                        articlesRepository.Delete(9);
                        break;
                    default:

                        break;
                }
                Console.WriteLine();
                Console.Write("Select a number from 0 to 5: ");
                caseSwitch = Int32.Parse(Console.ReadLine());
            }
        }

       
    }
}
