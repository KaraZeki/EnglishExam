using EnglishExam.Business.IServices;
using EnglishExam.Business.Services;
using EnglishExam.DataAccess.Context;
using EnglishExam.DataAccess.Repository;
using EnglishExam.Model.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishExam.Business.ServiceExtensions
{
    public static class AdvancedServiceExtensions
    {

        public static void AddCustomDbContext(this IServiceCollection services, string connectionString)
        {

            services.AddDbContext<EnglishExamDbContext>(c => c.UseSqlite(connectionString));
        }

        public static void AddContainerWithDependencies(this IServiceCollection services)
        {
            #region HttpContextAccessor
            //services.AddHttpContextAccessor();
            //services.AddSingleton<IUriService>(o =>
            //{
            //    var accessor = o.GetRequiredService<IHttpContextAccessor>();
            //    var request = accessor.HttpContext.Request;
            //    var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
            //    return new UriService(uri);
            //});
            #endregion

            #region Core Layer Dependencies

            services.AddScoped<IGenericRepository<Exam>, GenericRepository<Exam>>();
            services.AddScoped<IGenericRepository<ExamList>, GenericRepository<ExamList>>();
            services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();


            #endregion


            #region Service Extensions
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IExamService, ExamService>();
            services.AddScoped<ICommonService, CommonService>();
            #endregion
        }
    }
}
