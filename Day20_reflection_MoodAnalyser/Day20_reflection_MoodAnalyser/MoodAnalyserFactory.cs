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

        public static object CreateMoodAnalyse(string className, string constructorName)//here we are creating the class as object it self
        {
            //Create pattern to check class name and constructor name are same or not
            string pattern = @"." + constructorName + "$";//jere we are passing like class name .construvtor as a pattren
            Match result = Regex.Match(className, pattern);
            //Computation
            if (result.Success)//sucess returns bool value true 
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();//assembly class is a abstract class,
                                                                        //it contatins the .exe or dll files  
                                                                        //get executing method will reutns the  assembly
        //type class represents the class type,interface type..etc 
                                                                          //that contains the code that currently executing
                    Type moodAnalyseType = assembly.GetType(className);//it returns the specified class or else
                                                                       //retrun null if class not found
                    return Activator.CreateInstance(moodAnalyseType);
                }//activarot createts the type localy or remotly by using some methods inside it
                //here createinstance method create the instacne of the moodanalysetype and return the newly created object
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
                {//here we are getting the informaton for the constructor
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
                //getmethod serach for the public method with the specified name and returns the object of that method
                MethodInfo analyseMoodInfo = type.GetMethod(methodName);
                //for the methods we will use methodinfo which discovres the attributes of
                //the method and provide access to the metadata 
                object mood = analyseMoodInfo.Invoke(moodAnalyseObject, null);
                //invoke  method it invokes the method or constructor using specified parameters and returns the object containg that invoked method
                return mood.ToString();

            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CONSTRUCTOR, "Constructor not found");

            }
        }
        /// <summary>
        /// UC-7 Chnge Mood Dynamically
        /// </summary>
        /// <param name="message"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static string SetField(string message, string fieldName)
        {

            try
            {
                MoodAnalyser moodAnalyser = new MoodAnalyser();
                Type type = typeof(MoodAnalyser);
                //fieldsinfo this class it discribes the field info and provides the metadata

                //flages are like enum values we can store many values init

                //here bindingflages it specifies the flag that control the binding nside that we are
                //specifing the public so that it will only specifies the or bindies for the publuc or instance fields(varialble)
                FieldInfo field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if (message == null)
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_FIELD, "Message should not be null");
                }
                field.SetValue(moodAnalyser, message);
                return moodAnalyser.message;
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_FIELD, "Field is not found");
            }
        }


    }

}
