using System.Data;
using PhoneBook.Domain.Abstractions;
using PhoneBook.Domain.Users.Contracts;
using PhoneBook.Domain.Users.ValueObjects;

namespace PhoneBook.Domain.Users
{
    public class User : BaseEntity<Guid>, IScopeLifeTime
    {
        private User()
        {
        }

        public User(string userName, string password, IUserNameDuplicateChecker userNameDuplicateChecker)
        {
            CheckUserDuplication(userNameDuplicateChecker, userName);
            UserName = new(userName);
            Password = new(password);
        }

        public UserName UserName { get; set; }
        public Password Password { get; set; }

        private void CheckUserDuplication(IUserNameDuplicateChecker userNameDuplicateChecker, string userName)
        {
            if (userNameDuplicateChecker.IsUserNameDuplicate(userName)) throw new DuplicateNameException();
        }


        #region OneToMany

        public List<PhoneBooks.PhoneBook> PhoneBooks { get; set; }

        #endregion
    }
}