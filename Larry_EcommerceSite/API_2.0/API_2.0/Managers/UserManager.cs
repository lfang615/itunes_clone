using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Data;

namespace API_2._0.Managers
{
    public class UserManager : GenericManager
    {
        public UserManager()
        {

        }

        public User CreateUser(string fullName, string userName, string password, string email,
            string question1, string answer1, string question2, string answer2, string lastIp, int custId)
        {
            Model1Container1 context = new Model1Container1();

            User test = context.Users.Where(x => x.Username == userName).FirstOrDefault();

            if(test != null)
            {
                return null;
            }

            User user = new User()
            {
                FulName = fullName,
                Username = userName,
                Email = email,
                SecurityQ1 = question1,
                SecurityQA = answer1,
                SecurityQ2 = question2,
                SecurityA2 = answer2,
                CustomerId = custId
            };

            string hash = CreateHash(password);
            user.Salt = hash.Split(':')[1];
            user.Password = hash.Split(':')[2];

            context.Users.Add(user);
            context.SaveChanges();

            return user;
        }

        public bool Authenticate(string username, string password)
        {
            User user = null;
            using(Model1Container1 context = new Model1Container1())
            {
                user = context.Users.Where(x => x.Username == username).FirstOrDefault();

            }
            if(user == null)
            {
                return false;
            }
            else
            {
                return ValidatePassword(password, user.Password, user.Salt);
            }
        }

        public void SavePassword(string username, string password)
        {
            using (Model1Container1 context = new Model1Container1())
            {
                User user = context.Users.Where(x => x.Username == username).First();
                string hash = CreateHash(password);
                user.Salt = hash.Split(':')[1];
                user.Password = hash.Split(':')[2];

                context.SaveChanges();
            }
        }

        public User RetreiveUser(string username)
        {
            User user = null;
            Model1Container1 context = new Model1Container1();

            user = context.Users.Where(x => x.Username == username).FirstOrDefault();

            return user;
        }

        public List<string> GetUserRoles(string username)
        {
            Model1Container1 context = new Model1Container1();

            var roles = (from u in context.Users
                         join r in context.Roles
                         on u.Id equals r.UserId
                         where u.Username == username
                         select r.RoleType.Name
                         ).ToList();

            return roles;
        }

        public List<User> GetUsers()
        {
            return DomainContext.Users.ToList();
        }

        public User GetUserByUsername(string username)
        {
            return DomainContext.Users.Where(x => x.Username == username).FirstOrDefault();
        }

        public User GetUserById(int userId)
        {
            return DomainContext.Users.Where(x => x.Id == userId).FirstOrDefault();
        }

        public void DeleteUser(User user)
        {
            DomainContext.Users.Remove(user);
            DomainContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            User test = DomainContext.Users.Where(x => x.Id == user.Id).FirstOrDefault();

            if (test == null)
            {
                DomainContext.Users.Add(user);
                DomainContext.SaveChanges();
            }
            else
            {
                test.FulName = user.FulName;
                test.Username = user.Username;
                test.Password = user.Password;
                test.Salt = user.Salt;
                test.LastIp = user.LastIp;
                test.SecurityQ1 = user.SecurityQ1;
                test.SecurityQA = user.SecurityQA;
                test.SecurityQ2 = user.SecurityQ2;
                test.SecurityA2 = user.SecurityA2;
                test.CustomerId = user.CustomerId;

                DomainContext.SaveChanges();
            }
        }

        // The following constants may be changed without breaking existing hashes.
        public const int SALT_BYTE_SIZE = 16;
        public const int HASH_BYTE_SIZE = 16;
        public const int PBKDF2_ITERATIONS = 1000;

        public const int ITERATION_INDEX = 0;
        public const int SALT_INDEX = 1;
        public const int PBKDF2_INDEX = 2;

        /// <summary>
        /// Creates a salted PBKDF2 hash of the password.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <returns>The hash of the password.</returns>
        private static string CreateHash(string password)
        {
            // Generate a random salt
            RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SALT_BYTE_SIZE];
            csprng.GetBytes(salt);

            // Hash the password and encode the parameters
            byte[] hash = PBKDF2(password, salt, PBKDF2_ITERATIONS, HASH_BYTE_SIZE);
            return PBKDF2_ITERATIONS + ":" +
                Convert.ToBase64String(salt) + ":" +
                Convert.ToBase64String(hash);
        }

        /// <summary>
        /// Validates a password given a hash of the correct one.
        /// </summary>
        /// <param name="password">The password to check.</param>
        /// <param name="correctHash">A hash of the correct password.</param>
        /// <returns>True if the password is correct. False otherwise.</returns>
        private static bool ValidatePassword(string password, string correctHash, string saltPassword)
        {
            // Extract the parameters from the hash
            byte[] salt = Convert.FromBase64String(saltPassword);
            byte[] hash = Convert.FromBase64String(correctHash);

            byte[] testHash = PBKDF2(password, salt, PBKDF2_ITERATIONS, hash.Length);
            return SlowEquals(hash, testHash);
        }

        /// <summary>
        /// Compares two byte arrays in length-constant time. This comparison
        /// method is used so that password hashes cannot be extracted from
        /// on-line systems using a timing attack and then attacked off-line.
        /// </summary>
        /// <param name="a">The first byte array.</param>
        /// <param name="b">The second byte array.</param>
        /// <returns>True if both byte arrays are equal. False otherwise.</returns>
        private static bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
                diff |= (uint)(a[i] ^ b[i]);
            return diff == 0;
        }

        /// <summary>
        /// Computes the PBKDF2-SHA1 hash of a password.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <param name="salt">The salt.</param>
        /// <param name="iterations">The PBKDF2 iteration count.</param>
        /// <param name="outputBytes">The length of the hash to generate, in bytes.</param>
        /// <returns>A hash of the password.</returns>
        private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }
    }
}

