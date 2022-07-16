namespace Day20_reflection_MoodAnalyser
{
    public class Tests
    {

        MoodAnalyserFactory moodAnalyserfactory;
        [SetUp]
        public void Setup()
        {
            moodAnalyserfactory = new MoodAnalyserFactory();
        }

        /// <summary>
        /// TC-4.1 Given MoodAnalyser Class Name Should Return MoodAnalyser Object 
        /// • Create MoodAnalyser Factory to create a MoodAnalyser Object with default constructor
        /// • Use Equals method in MoodAnalyser to check if the two objects are equal
        /// • Test passes if they are equal
        /// </summary>
        [Test]
        public void MoodAnalyserClassName_ShouldReturn_MoodAnalyserObject()
        {
            string message = null;
            object expected = new MoodAnalyser(message);
            object obj = MoodAnalyserFactory.CreateMoodAnalyse("Day20_reflection_MoodAnalyser.MoodAnalyser", "MoodAnalyser");
            expected.Equals(obj);
        }

        /// <summary>
        /// TC-4.2 Given Class Name When Improper Should Throw MoodAnalysisException To pass this 
        /// test case pass wrong class name catch Exception and throw Exception indicating No Such Class Error
        /// </summary>
        [Test]
        public void MoodAnalyserClassName_Improper_Should_ThrowMoodAnalyserException()
        {
            object obj = null;//here we are passing obj as a null to get the exception and to pass the test cases

            string expected = "Class not found";
            try
            {
                obj = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyserReflections.Mood", "Mood");
            }
            catch (MoodAnalyserCustomException exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }

        /// <summary>
        /// TC-4.3 Given Class When Constructor Not Proper Should Throw MoodAnalysisException 
        /// To pass this Test Case pass wrong Constructor parameter, 
        /// catch the Exception and throw indicating No Such Method Error
        [Test]
        public void MoodAnalyserClassName_ConstructorIsImproper_Should_ThrowMoodAnalyserException()
        {
            object obj = null;

            string expected = "Constructor not found";
            try
            {
                obj = MoodAnalyserFactory.CreateMoodAnalyse("Day20_reflection_MoodAnalyser.MoodAnalyser", "AnalyserMood");
            }
            catch (MoodAnalyserCustomException exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }
        /// <summary>
        /// TC-5.1  Given MoodAnalyser When Proper Return MoodAnalyser Object 
        /// • Use MoodAnalyser Factory to create a MoodAnalyser Object with Parameter constructor 
        /// • Use Equals method in MoodAnalyser to check if the two objects are equal
        /// </summary>
        [Test]
        public void MoodAnalyserClassName_ShouldReturn_MoodAnalyserObject_UsingParametrizedConstructor()
        {
            object expected = new MoodAnalyser("HAPPY");
            object obj = MoodAnalyserFactory.CreateMoodAnalyseUsingParameterizedConstructor("Day20_reflection_MoodAnalyser.MoodAnalyser", "MoodAnalyser");
            expected.Equals(obj);
        }

        /// <summary>
        /// TC-5.2  Given Class Name When Improper Should Throw MoodAnalysisException
        /// To pass this test case pass wrong class name catch Exception and throw Exception
        /// indicating No Such Class Error
        /// </summary>
        [Test]
        public void MoodAnalyserClassName_Improper_UsingParametrizedConstructor_ShouldThrow_Excpetion()
        {
            string expected = "Class not found";
            try
            {
                object obj = MoodAnalyserFactory.CreateMoodAnalyseUsingParameterizedConstructor("Day20_reflection_MoodAnalyser.Mood", "MoodAnalyser");
            }
            catch (MoodAnalyserCustomException exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }

        /// <summary>
        /// TC-5.3  Given Class When Constructor Not Proper Should Throw MoodAnalysisException 
        /// To pass this Test Case pass wrong Constructor parameter, catch the Exception and 
        /// throw indicating No Such Method Error
        /// </summary>
        [Test]
        public void MoodAnalyserClassName_ConstructorIsImproper_UsingParametrizedConstructor_Should_ThrowExcpetion()
        {
            string expected = "Method not found";
            try
            {
                object obj = MoodAnalyserFactory.CreateMoodAnalyseUsingParameterizedConstructor("Day20_reflection_MoodAnalyser.MoodAnalyser", "Mood");
            }
            catch (MoodAnalyserCustomException exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }
        /// <summary>
        /// TC-7.1  Given Hppy Should Return Happy
        /// </summary>
        [Test]
        public void Given_HAPPYMessage_WithReflector_Should_ReturnHAPPY()
        {
            string result = MoodAnalyserFactory.SetField("HAPPY", "message");
            Assert.AreEqual("HAPPY", result);
        }

        /// <summary>
        /// TC-7.2  Set Field When Improper Should Throw Exception 
        /// </summary>
        [Test]
        public void SetField_ImProper_ShouldThrowException()
        {
            try
            {
                string result = MoodAnalyserFactory.SetField("HAPPY", "me");//here we are giving message as me
            }
            catch (MoodAnalyserCustomException exception)
            {
                Assert.AreEqual("Field is not found", exception.Message);
            }
        }

        /// <summary>
        /// TC-7.3  Set Null Messge  Should Throw Exception 
        /// </summary>
        [Test]
        public void Setting_NullMessge_ShouldThrowException()
        {
            try
            {
                string result = MoodAnalyserFactory.SetField(null, "message");//we are passing null for message
            }
            catch (MoodAnalyserCustomException exception)
            {
                Assert.AreEqual("Message should not be null", exception.Message);
            }
        }

    }
}

