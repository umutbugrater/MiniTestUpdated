using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<IQuestionService, QuestionManager>();
            services.AddScoped<IQuestionOptionService, QuestionOptionManager>();
            services.AddScoped<IAnswerLineService, AnswerLineManager>();
            services.AddScoped<IQuestionTypeService, QuestionTypeManager>();

            services.AddScoped<IQuestionDal, EfQuestionRepository>();
            services.AddScoped<IQuestionOptionsDal, EfQuestionOptionsRepository>();
            services.AddScoped<IAnswerLineDal, EfAnswerLineRepository>();
            services.AddScoped<IQuestionTypeDal, EfQuestionTypeRepository>();
        }

    }
}
