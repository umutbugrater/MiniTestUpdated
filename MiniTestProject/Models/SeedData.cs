using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace MiniTestProject.Models
{
    public class SeedData
    {

        public static void EnsurePopulated(IApplicationBuilder application)
        {
            Context context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<Context>();

            QuestionManager questionManager = new QuestionManager(new EfQuestionRepository());
            QuestionTypeManager questionTypeManager = new QuestionTypeManager(new EfQuestionTypeRepository());
            QuestionOptionManager questionOptionManager = new QuestionOptionManager(new EfQuestionOptionsRepository());

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!questionTypeManager.TGetList().Any())
            {
                questionTypeManager.TAdd(new QuestionType { QuestionTypeName = "Çoktan Seçmeli" });
                questionTypeManager.TAdd(new QuestionType { QuestionTypeName = "Doğru - Yanlış" });
                questionTypeManager.TAdd(new QuestionType { QuestionTypeName = "Boşluk Doldurma" });
            }

            if (!questionManager.TGetList().Any())
            {
                questionManager.TAdd(new Question { QuestionLine = "Aşağıda Verilen İlk Çağ Uygarlıklarından Hangisi Yazıyı İcat Etmiştir?", CreateDate = DateTime.Now, QuestionTypeID = 1 });
                questionManager.TAdd(new Question { QuestionLine = "Aşağıdakilerden Hangisi Dünya Sağlık Örgütünün Kısaltılmış İsmidir?", CreateDate = DateTime.Now, QuestionTypeID = 1 });
                questionManager.TAdd(new Question { QuestionLine = "Romen Rakamında Hangi Sayı Yoktur?", CreateDate = DateTime.Now, QuestionTypeID = 1 });
                questionManager.TAdd(new Question { QuestionLine = "Üç Büyük Dince Kutsal Sayılan Şehir Hangisidir?", CreateDate = DateTime.Now, QuestionTypeID = 1 });
                questionManager.TAdd(new Question { QuestionLine = "Aşağıdaki Ülkelerden Hangisinin Nüfusu Daha Fazladır?", CreateDate = DateTime.Now, QuestionTypeID = 1 });
                questionManager.TAdd(new Question { QuestionLine = "Işık sesten daha hızlı hareket ettiği için şimşek daha duyulmadan görülür.", CreateDate = DateTime.Now, QuestionTypeID = 2 });
                questionManager.TAdd(new Question { QuestionLine = "Uçaktaki kara kutu siyahtır", CreateDate = DateTime.Now, QuestionTypeID = 2 });
                questionManager.TAdd(new Question { QuestionLine = "Kafatası insan vücudundaki en güçlü kemiktir.", CreateDate = DateTime.Now, QuestionTypeID = 2 });
                questionManager.TAdd(new Question { QuestionLine = "Uyurken hapşırabilirsiniz.", CreateDate = DateTime.Now, QuestionTypeID = 2 });
                questionManager.TAdd(new Question { QuestionLine = "Kahve meyvelerden yapılır.", CreateDate = DateTime.Now, QuestionTypeID = 2 });
                questionManager.TAdd(new Question { QuestionLine = "İmsak Ne Demektir?", CreateDate = DateTime.Now, QuestionTypeID = 3 });
                questionManager.TAdd(new Question { QuestionLine = "Bakü Hangi Devletin Başkentidir?", CreateDate = DateTime.Now, QuestionTypeID = 3 });
                questionManager.TAdd(new Question { QuestionLine = "Dünyanın En Uzun Nehrinin Adı Nedir?", CreateDate = DateTime.Now, QuestionTypeID = 3 });
                questionManager.TAdd(new Question { QuestionLine = "Top İle Oynanan Beş Adet Spor Dalı Sayınız?", CreateDate = DateTime.Now, QuestionTypeID = 3 });
                questionManager.TAdd(new Question { QuestionLine = "Kaç Yılda Bir Şubat Ayı 29 Çeker?", CreateDate = DateTime.Now, QuestionTypeID = 3 });
            }

            if (!questionOptionManager.TGetList().Any())
            {
                questionOptionManager.TAdd(new QuestionOption { OptionDescription = "Hititler", Question_ID = 1 });
                questionOptionManager.TAdd(new QuestionOption { OptionDescription = "Elamlar", Question_ID = 1 });
                questionOptionManager.TAdd(new QuestionOption { OptionDescription = "Sümerler", Question_ID = 1 });
                questionOptionManager.TAdd(new QuestionOption { OptionDescription = "Urartular", Question_ID = 1 });

                questionOptionManager.TAdd(new QuestionOption { OptionDescription = "Unıcef ", Question_ID = 2 });
                questionOptionManager.TAdd(new QuestionOption { OptionDescription = "Who", Question_ID = 2 });
                questionOptionManager.TAdd(new QuestionOption { OptionDescription = "Nato", Question_ID = 2 });

                questionOptionManager.TAdd(new QuestionOption { OptionDescription = "0", Question_ID = 3 });
                questionOptionManager.TAdd(new QuestionOption { OptionDescription = "50", Question_ID = 3 });
                questionOptionManager.TAdd(new QuestionOption { OptionDescription = "10", Question_ID = 3 });
                questionOptionManager.TAdd(new QuestionOption { OptionDescription = "100", Question_ID = 3 });
                questionOptionManager.TAdd(new QuestionOption { OptionDescription = "1000", Question_ID = 3 });

                questionOptionManager.TAdd(new QuestionOption { OptionDescription = "Mekke", Question_ID = 4 });
                questionOptionManager.TAdd(new QuestionOption { OptionDescription = "Kudüs", Question_ID = 4 });
                questionOptionManager.TAdd(new QuestionOption { OptionDescription = "Roma", Question_ID = 4 });
                questionOptionManager.TAdd(new QuestionOption { OptionDescription = "İstanbul", Question_ID = 4 });

                questionOptionManager.TAdd(new QuestionOption { OptionDescription = "İspanya", Question_ID = 5 });
                questionOptionManager.TAdd(new QuestionOption { OptionDescription = "Fransa", Question_ID = 5 });
                questionOptionManager.TAdd(new QuestionOption { OptionDescription = "İngiltere", Question_ID = 5 });
                questionOptionManager.TAdd(new QuestionOption { OptionDescription = "Almanya", Question_ID = 5 });
                questionOptionManager.TAdd(new QuestionOption { OptionDescription = "Türkiye", Question_ID = 5 });
            }
        }
    }
}
