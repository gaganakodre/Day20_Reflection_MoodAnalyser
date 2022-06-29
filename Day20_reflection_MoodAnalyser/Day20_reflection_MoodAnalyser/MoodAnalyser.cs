using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day20_reflection_MoodAnalyser
{
    public class MoodAnalyser
    {
        string message;

        /// <summary>
        /// empty constructor
        /// </summary>
        public MoodAnalyser()
        {
            this.message = null;
        }
        /// <summary>
        /// parameterised constructor with null or empty message 
        /// </summary>
        /// <param name="message"></param>
        public MoodAnalyser(string message)
        {
            this.message = message;
        }

        /// <summary>
        /// Method to analyse mood with custom exception
        /// </summary>
        /// <returns></returns>
        public string AnalyserMood()
        {
            try
            {
                if (this.message.Equals(string.Empty))
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.EMPTY_MESSAGE, "Mood should not be empty");
                }
                if (this.message.Contains("SAD"))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NULL_MESSAGE, "Mood should not be null message");
            }

        }
    }
}
