using OOP_ATS_att4;

namespace OOPATSTest1
{
    [TestClass]
    public sealed class Test1
    {
        [TestInitialize]
        public void Setup()
        {
            Form1.ATS.Test_ResetStatic();
        }

        [TestMethod]
        public void ATSConstructEmpty()
        {
            Assert.AreEqual(0, Form1.ATS.ObjectCount);
            Form1.ATS ats = new Form1.ATS();

            Assert.AreEqual(0, ats.Id);
            Assert.AreEqual(0, ats.UserCount);
            Assert.AreEqual(0, ats.Price);
            Assert.AreEqual(0, ats.CallCount);
            Assert.AreEqual("Г. Пенза, ул. Беляева, 41", ats.Address);
            Assert.AreEqual(1, Form1.ATS.ObjectCount);
        }
        [TestMethod]
        public void ATSConstructFull()
        {
            int[] users = { 1, 2, 3, 4 };
            Form1.ATS.Call[] calls = {new Form1.ATS.Call(1, 2, 34, true), new Form1.ATS.Call(1, 4, 34, true)};
            Form1.ATS ats = new Form1.ATS(2, "1", users, 100.99, calls);

            Assert.AreEqual(2, ats.Id);
            Assert.AreEqual(4, ats.UserCount);
            Assert.AreEqual(100.99, ats.Price);
            Assert.AreEqual(2, ats.CallCount);
            Assert.AreEqual("1", ats.Address);
            Assert.AreEqual(1, Form1.ATS.ObjectCount);
        }
        [TestMethod]
        public void ATSAddUser()
        {
            Form1.ATS ats = new Form1.ATS(1, 10, 0.2);
            Assert.AreEqual(10, ats.UserCount);
            ats.AddUser(78);
            Assert.AreEqual(11, ats.UserCount);
            Assert.Throws<Form1.UserIdArrayTypeMismatchException>(() => ats.AddUser("hello"));
        }
        [TestMethod]
        public void ATSAddCall()
        {
            int[] users = { 1, 2, 3, 4 };
            Form1.ATS.Call[] calls = { };
            Form1.ATS ats = new Form1.ATS(2, "1", users, 100.99, calls);
            Assert.AreEqual(0, ats.CallCount);
            ats.NewCall(1, 2, 654, false);
            ats.NewCall(3, 4, 54, true);
            Assert.AreEqual(2, ats.CallCount);
            Assert.Throws<Form1.SelfCallException>(() => ats.NewCall(1, 1, 34, true));
            Assert.Throws<ArgumentException>(() => ats.NewCall(99, 1, 34, true));
        }
        [TestMethod]
        public void ATSToString()
        {
            Form1.ATS ats = new Form1.ATS(54, "hi", 3, 99.99);
            Assert.AreEqual("ID АТС: 54. Адрес АТС: hi. Абонентская плата: 99,99. Количество пользователей: 3. Количество совершенных звонков: 0.", ats.ToString());
        }
        [TestMethod]
        public void ATSChange()
        {
            Form1.ATS ats = new Form1.ATS(22, "here", 2, 250);
            Assert.AreEqual(1, Form1.ATS.ObjectCount);
            ats.Change(29, "there", 3, 249.99);
            Assert.AreEqual(29, ats.Id);
            Assert.AreEqual(3, ats.UserCount);
            Assert.AreEqual(249.99, ats.Price);
            Assert.AreEqual(0, ats.CallCount);
            Assert.AreEqual("there", ats.Address);
            Assert.AreEqual(1, Form1.ATS.ObjectCount);
        }
        [TestMethod]
        public void ATSRemove()
        {
            Assert.AreEqual(0, Form1.ATS.ObjectCount);
            Form1.ATS ats = new Form1.ATS(54, "hi", 3, 99.99);
            Assert.AreEqual(1, Form1.ATS.ObjectCount);
            ats.Remove();
            Assert.AreEqual(0, Form1.ATS.ObjectCount);
        }
        [TestMethod]
        public void ATSIdTaken()
        {
            Form1.ATS ats1 = new Form1.ATS();
            Form1.ATS ats2;
            Assert.AreEqual(1, Form1.ATS.ObjectCount);
            Assert.Throws<ArgumentException>(() => ats2 = new Form1.ATS(0,"penza", 9, 400));
            Assert.AreEqual(1, Form1.ATS.ObjectCount);
            ats1.Remove();
            ats1 = new Form1.ATS(54, "bye", 1, 9);
            Assert.Throws<ArgumentException>(() => ats2 = new Form1.ATS(54, "penza", 9, 400));
            Assert.AreEqual(1, Form1.ATS.ObjectCount);
        }
    }
}
