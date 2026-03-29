using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab3_ATS
{
    public class UserIdArrayTypeMismatchException : ArrayTypeMismatchException
    {
        private dynamic _id;
        public UserIdArrayTypeMismatchException(string message, dynamic id) : base(message) { _id = id; }
    }
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message) { }
    }
    public class SelfCallException : Exception
    {
        public SelfCallException(string message) : base(message) { }
    }
}
