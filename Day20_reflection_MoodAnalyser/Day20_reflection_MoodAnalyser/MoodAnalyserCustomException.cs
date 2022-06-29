using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day20_reflection_MoodAnalyser
{
    public class MoodAnalyserCustomException : Exception
    {

        public enum ExceptionType
        {
            NO_SUCH_CLASS,
            NO_SUCH_CONSTRUCTOR,
            EMPTY_MESSAGE,
            NULL_MESSAGE,
            NO_SUCH_FIELD,
            NO_SUCH_METHOD,

        }
        public ExceptionType exceptionType;

        public MoodAnalyserCustomException(ExceptionType exceptionType, string message) : base(message)
        {
            this.exceptionType = exceptionType;
        }
    }
}
