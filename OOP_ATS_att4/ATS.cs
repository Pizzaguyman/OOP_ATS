using System;
using System.Collections.Generic;
using System.Text;
using static OOP_ATS_att4.Form1;

namespace OOP_ATS_att4
{
    public class ATS
    {
        private const string DEFAULT_ADDRESS = "";
        public struct Call
        {
            public int user1;
            public int user2;
            public int time;
            public bool isPaid;
            public Call(int user1, int user2, int time, bool isPaid)
            {
                this.user1 = user1;
                this.user2 = user2;
                this.time = time;
                this.isPaid = isPaid;
            }
        }
        static public int ObjectCount { get; private set; }
        static public List<int> IdList { get; private set; } = new List<int>();
        static public int LatestId { get; private set; }
        static public int LowestVacantId { get; private set; } = 0;
        static public bool UniqueIds { get; set; } = true;
        public int Id { get; set; }
        public string Address { get; set; }
        public int UserCount { get; set; }
        public int[] UserIdArray { get; set; }
        public double Price { get; set; }
        public int CallCount { get; set; }
        public Call[] Calls { get; set; }
        public ATS(int id, string address, int[] userIdArray, double price, Call[] calls)
        {
            if (UniqueIds)
            {
                if (id == -1) 
                { 
                    id = LowestVacantId;
                    IdList.Add(id);
                }
                else
                {
                    if (IdList.Contains(id)) throw new ArgumentException("Этот ID занят");
                    else IdList.Add(id);
                }
            }
            else if (id == -1) id = 0;
            Id = id;
            LatestId = id;
            if (UniqueIds) while (IdList.Contains(++LowestVacantId));
            Address = address;
            UserIdArray = userIdArray;
            UserCount = userIdArray.Length;
            Price = price;
            Calls = calls;
            CallCount = calls.Length;
            ObjectCount = IdList.Count;
        }
        public ATS(int id, string address, int userCount, double price)
        {
            if (UniqueIds)
            {
                if (id == -1)
                {
                    id = LowestVacantId;
                    IdList.Add(id);
                }
                else
                {
                    if (IdList.Contains(id)) throw new ArgumentException("Этот ID занят");
                    else IdList.Add(id);
                }
            }
            else if(id == -1) id = 0;
            Id = id;
            LatestId = id;
            if (UniqueIds) while (IdList.Contains(++LowestVacantId)) ;
            Address = address;
            UserCount = userCount;
            UserIdArray = new int[userCount];
            Random rand = new Random();
            for (int i = 0; i < userCount; i++)
            {
                int random = rand.Next(0x000000, 0xFFFFFF);
                while (UserIdArray.IndexOf(random) != -1) random = rand.Next(0x000000, 0xFFFFFF);
                UserIdArray[i] = random;
            }
            Calls = new Call[CallCount];
            Price = price;
            ObjectCount = IdList.Count;
        }
        public ATS(int id, int userCount, double price) : this(id, DEFAULT_ADDRESS, userCount, price) { }
        public ATS(int id, double price) : this(id, DEFAULT_ADDRESS, 0, price) { }
        public ATS(double price) : this(-1, DEFAULT_ADDRESS, 0, price) { }
        public ATS() : this(0) { }

        public void AddUser(dynamic userId)
        {
            if (!(userId is int)) throw new UserIdArrayTypeMismatchException("Попытка добавить строку в массив чисел", userId);
            for (int i = 0; i < UserIdArray.Length; i++)
            {
                if (UserIdArray[i] == userId) return;
            }
            UserCount++;
            int[] newArray = new int[UserCount];
            UserIdArray.CopyTo(newArray, 0);
            UserIdArray = newArray;
            UserIdArray[UserCount - 1] = userId;
        }

        public void NewCall(int user1, int user2, int time, bool isPaid)
        {
            if (user1 == user2)
            {
                throw new SelfCallException("Пользователь не может звонить самому себе");
            }
            if (!Array.Exists(UserIdArray, id => id == user1) || !Array.Exists(UserIdArray, id => id == user2))
            {
                throw new ArgumentException("Пользователя с таким ID не существует");
            }
            CallCount++;
            Call[] newArray = new Call[CallCount];
            Calls.CopyTo(newArray, 0);
            Calls = newArray;
            Calls[CallCount - 1] = new Call(user1, user2, time, isPaid);
        }

        public override string ToString()
        {
            return $"ID АТС: {Id}. Адрес АТС: {Address}. Абонентская плата: {Price}. " +
                $"Количество пользователей: {UserCount}. Количество совершенных звонков: {CallCount}.";
        }

        public void Change(int id, string address, int userCount, double price)
        {
            IdList.Remove(Id);
            IdList.Add(id);
            Id = id;
            Address = address;
            int[] new_users = new int[userCount];
            new_users = UserIdArray[(UserCount - Math.Min(UserCount, userCount))..];
            Random rand = new Random();
            for (int i = UserCount; i < userCount; i++)
            {
                int random = rand.Next(0x000000, 0xFFFFFF);
                while (UserIdArray.IndexOf(random) != -1) random = rand.Next(0x000000, 0xFFFFFF);
                new_users[i] = random;
            }
            UserIdArray = new_users;
            UserCount = userCount;
            Price = price;
        }

        public void RemoveId()
        {
            IdList.Remove(Id);
            if (Id < LowestVacantId) LowestVacantId = Id;
            ObjectCount--;
        }

        ~ATS()
        {
            RemoveId();
        }

        public static void Test_ResetStatic()
        {
            ObjectCount = 0;
            IdList = new List<int>();
        }

    }
}
