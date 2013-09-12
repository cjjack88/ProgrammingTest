using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foundation.ObjectHydrator;

namespace DummyData_Users_ObjectHydrator
{
    public class Users
    {
        public UserModel GetSingle()
        {
            Hydrator<UserModel> hydrator = new Hydrator<UserModel>();
            UserModel theUser = hydrator.GetSingle();

            return theUser;
        }

        public IList<UserModel> GetMultiple(int recordsNumber)
        {
            IList<UserModel> users = new List<UserModel>();
            Hydrator<UserModel> hydrator = new Hydrator<UserModel>();

            users = hydrator.GetList(recordsNumber);

            return users;
        }
    }
}
