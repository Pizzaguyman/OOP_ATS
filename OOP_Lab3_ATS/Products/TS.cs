using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab3_ATS
{
    abstract public class TS
    {
        private const string DEFAULT_ADDRESS = "";
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
        public TS(int id, string address, int[] userIdArray, double price)
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
            if (UniqueIds) while (IdList.Contains(++LowestVacantId)) ;
            Address = address;
            UserIdArray = userIdArray;
            UserCount = userIdArray.Length;
            Price = price;
            ObjectCount = IdList.Count;
        }
        public TS(int id, string address, int userCount, double price)
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
            Price = price;
            ObjectCount = IdList.Count;
        }
        public TS() : this(-1, DEFAULT_ADDRESS, 0, 0.00) { }

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

        public override string ToString()
        {
            return $"ID АТС: {Id}. Адрес АТС: {Address}. Абонентская плата: {Price}. " +
                $"Количество пользователей: {UserCount}.";
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

        ~TS()
        {
            RemoveId();
        }

    }
}
