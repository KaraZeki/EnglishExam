using EnglishExam.Model.Model;
using System.Threading.Tasks;

namespace EnglishExam.Business.IServices
{
    public interface IUserService
    {
        public UserReturnModel UserAccountControlAsync(UserViewModel userViewModel);
    }
}
