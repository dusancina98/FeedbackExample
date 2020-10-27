using FeedbackExample.Entities;
using FeedbackExample.Repository.SQL.PersistenceEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeedbackExample.Repository.SQL.DataProvider.Util
{
    //Klasa za mapiranje objekata iz baze na entitete (zbog anotacija)
    public class UserMapper
    {
        public static User MapUserPersistenceToUserEntity(UserPersistence user)
            => user == null ? null : new User(user.Id, user.Username);

        public static IEnumerable<User> MapUserPersistenceCollectionToUserEntityCollection(IEnumerable<UserPersistence> users)
            => users.Select(c => MapUserPersistenceToUserEntity(c));
    }
}
