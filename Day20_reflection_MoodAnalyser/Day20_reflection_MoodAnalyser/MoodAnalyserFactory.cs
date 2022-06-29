using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Day20_reflection_MoodAnalyser
{
    public class MoodAnalyserFactory
    {
        /// <summary>
        /// UC-4 CreateMoodAnalyse method create object of MoodAnalyse class 
        /// </summary>

        public static object CreateMoodAnalyse(string className, string constructorName)
        {
            //Create pattern to check class name and constructor name are same or not
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);
            //Computation
            if (result.Success)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = assembly.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch (ArgumentNullException)
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "Class not found");

                }
            }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CONSTRUCTOR, "Constructor not found");
            }
        }
        /// <summary>
        /// UC-5 For parameterised constructor by pssing messge parameter to the class method
        /// </summary>

        public static object CreateMoodAnalyseUsingParameterizedConstructor(string className, string constructorName)
        {
            Type type = typeof(MoodAnalyser);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo construct = type.GetConstructor(new[] { typeof(string) });
                    object instance = construct.Invoke(new object[] { "HAPPY" });
                    return instance;
                }

                else
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "Method not found");
                }
            }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "Class not found");
            }
        }
        /// <summary>
        /// UC6: Use Reflection to invoke Method
        /// </summary>

        public static string InvokeAnalyseMood(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyserReflections.MoodAnalyser");
                object moodAnalyseObject = MoodAnalyserFactory.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyserReflections.MoodAnalyser", "MoodAnalyser");
                MethodInfo analyseMoodInfo = type.GetMethod(methodName);
                object mood = analyseMoodInfo.Invoke(moodAnalyseObject, null);
                return mood.ToString();

            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "Method not found");

            }
        }
    }

}
