using System;
using System.Collections.Generic;
using System.Linq;
using TheAMTeam.Data;
using TheAMTeam.Data.Repositories;

namespace TheAMTeam.App.AdrianBarbus
{
    public class App
    {
        private static readonly ArticlesRepository articlesRepository = new ArticlesRepository();

        public static void PrintArticle(Article a)
        {
            Console.WriteLine("ID:"+a.ArticleId+";  Author:"+a.Author + ";  Category:" + a.Category);
        }

        public static void Execute()
        {

            Article article = new Article
            {
                ArticleId = 4,
                Author = "Marcel",
                Category = 2,
                PublishedDate = new DateTime(2017,2,8),
                Content = "Here is content",
                ImageURL = "https://www.google.ro/search?q=sport&rlz=1C1GCEA_enRO805RO805&tbm=isch&source=lnms&sa=X&ved=0ahUKEwj1j7jAiKjcAhWOx6YKHTRhBlAQ_AUICygC&biw=1536&bih=715&dpr=1.25#imgrc=dfhE_cI5huF03M:",
                Title = "Sport"
            };
            Article article1 = new Article
            {
                ArticleId = 4,
                Author = "Pavel",
                Category = 2,
                PublishedDate = new DateTime(2017, 2, 8),
                Content = "Here is content",
                ImageURL = "https://www.google.ro/search?q=sport&rlz=1C1GCEA_enRO805RO805&tbm=isch&source=lnms&sa=X&ved=0ahUKEwj1j7jAiKjcAhWOx6YKHTRhBlAQ_AUICygC&biw=1536&bih=715&dpr=1.25#imgrc=dfhE_cI5huF03M:",
                Title = "Sport"
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
                        PrintArticle(articlesRepository.GetById(2));
                        break;
                    case 3:
                        articlesRepository.Add(article1);
                        break;
                    case 4:
                        articlesRepository.Update(article1);
                        break;
                    case 5:
                        articlesRepository.Delete(8);
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
