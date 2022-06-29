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
            EMPTY_MOOD,
            NULL_MOOD,
            NO_SUCH_CLASS,
            NO_SUCH_METHOD,
            EMPTY_MESSAGE,
            NULL_MESSAGE,


        }
        public ExceptionType exceptionType;
        public MoodAnalyserCustomException(ExceptionType exceptionType, string message) : base(message)
        {
            this.exceptionType = exceptionType;
        }
    }
}
