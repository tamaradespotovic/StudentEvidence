using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA
{
    public class DALUser
    {
        StudentEvidenceEntities _db = new StudentEvidenceEntities();
        public bool CheckUser(string username, string password) {
            var user = _db.Users.FirstOrDefault(x => x.Username == username && x.Password == password);
            if (user == null)
            {
                return false;
            }
            else {
                return true;
            }
        }
    }
}
