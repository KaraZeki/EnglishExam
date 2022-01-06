using EnglishExam.Business.IServices;
using EnglishExam.DataAccess.Repository;
using EnglishExam.Model.Concrete;
using EnglishExam.Model.Model;
using System;
using System.Linq;

namespace EnglishExam.Business.Services
{
    internal class UserService : IUserService
    {

        private readonly IGenericRepository<User> _userRepository;
        public UserService(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public UserReturnModel UserAccountControlAsync(UserViewModel userViewModel)
        {
            try
            {
                var userReturn = new UserReturnModel();
                var hasEmail = _userRepository.Get(x => x.Email == userViewModel.Email).FirstOrDefault();
                if (hasEmail == null)
                {
                    userReturn.IsOk = false;
                    userReturn.Message = "Email has not correct";
                }
                else
                {
                    var hasPassword = _userRepository.Get(x => x.Password == userViewModel.Password).FirstOrDefault();
                    if (hasPassword == null)
                    {
                        userReturn.IsOk = false;
                        userReturn.Message = "Psssword has not correct";
                    }
                    else
                    {
                        userReturn.Id = hasPassword.Id;
                        userReturn.IsOk = true;
                        userReturn.Message = "Success";
                    }
                }

                return userReturn;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            throw new NotImplementedException();
        }
    }
}
