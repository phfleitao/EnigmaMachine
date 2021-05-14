using Enigma.Core.Interfaces;
using Enigma.MachineEnigmaI.Reflectors;
using Enigma.MachineEnigmaI.Rotors;
using Xunit;

namespace Enigma.MachineEnigmaI.Tests
{
    public class EnigmaITests
    {
        [Theory]
        [InlineData("A","T")]   
        [InlineData("J","D")]    
        public void AnotherRotorOrder_Rotors_I_III_II_MustConvertCorrectly(string inputText, string expectedOutputText)
        {
            //Arrange
            IEnigma enigma = new EnigmaI(new RotorI(), new RotorIII(), new RotorII(), new ReflectorB());

            //Act
            string calculatedOutputText = string.Empty;
            for (var i = 0; i < inputText.Length; i++)
            {
                calculatedOutputText += enigma.Write(inputText[i]);
            }

            //Assert
            Assert.Equal(expectedOutputText, calculatedOutputText);
        }

        [Theory]
        [InlineData("A","L")]   
        public void AnotherRotorOrder_Rotors_VI_VII_VIII_MustConvertCorrectly(string inputText, string expectedOutputText)
        {
            //Arrange
            IEnigma enigma = new EnigmaI(new RotorVI(), new RotorVII(), new RotorVIII(), new ReflectorB());
            enigma.ConfigureOutterRingSetting('A','L','M');

            //Act
            string calculatedOutputText = string.Empty;
            for (var i = 0; i < inputText.Length; i++)
            {
                calculatedOutputText += enigma.Write(inputText[i]);
            }

            //Assert
            Assert.Equal(expectedOutputText, calculatedOutputText);
        }

        [Theory]
        [InlineData("AAAAAAAAAAAAAAAAAAA","FTZMGISXIPJWGDNJJCO")]      
        [InlineData("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA","FTZMGISXIPJWGDNJJCOQTYRIGDMXFIESRWZGTOIUIEKKDCSHTPYOEPVXNHVRWWESFRUXDGWOZDMNKIZWNCZDUCOBLTUYHDZGOVBU")]
        public void TurnOver_RotorsMustRotateCorrectlyBasedOnTurnOverNotch(string inputText, string expectedOutputText)
        {
            //Arrange
            IEnigma enigma = new EnigmaI();

            //Act
            string calculatedOutputText = string.Empty;
            for (var i = 0; i < inputText.Length; i++)
            {
                calculatedOutputText += enigma.Write(inputText[i]);
            }

            //Assert
            Assert.Equal(expectedOutputText, calculatedOutputText);
        }

        [Theory]
        [InlineData('A','E','R',"A","G")] 
        [InlineData('V','E','Q',"A","Z")]        
        [InlineData('A','E','S',"A","O")]
        [InlineData('V','E','A',"A","G")]
        public void TurnOver_RotorsMustRotateCorrectlyBasedOnTurnOverNotchWithStartedOutterConfiguration(char slowRotorSetting, char middleRotorSetting, char fastRotorSetting, string inputText, string expectedOutputText)
        {
            //Arrange
            IEnigma enigma = new EnigmaI();
            enigma.ConfigureOutterRingSetting(slowRotorSetting, middleRotorSetting, fastRotorSetting);

            //Act
            string calculatedOutputText = string.Empty;
            for (var i = 0; i < inputText.Length; i++)
            {
                calculatedOutputText += enigma.Write(inputText[i]);
            }

            //Assert
            Assert.Equal(expectedOutputText, calculatedOutputText);
        }

        [Theory]
        [InlineData("PEDROLEITAO", "CFSQZJHZMPD")]
        [InlineData("CARINA", "PTFXBI")]
        [InlineData("JULIA", "RBNXG")]
        [InlineData("BEATRIZ", "WFZUUAX")]
        public void WriteTextMustReturnValidConversion(string inputText, string expectedOutputText)
        {
            //Arrange
            IEnigma enigma = new EnigmaI();

            //Act
            string calculatedOutputText = enigma.WriteText(inputText);

            //Assert
            Assert.Equal(expectedOutputText, calculatedOutputText);
        }

        [Theory]
        [InlineData("PEDROLEITAO","TFNKVKCDGKV")]  
        [InlineData("JULIALEITAO","QTJPTKCDGKV")] 
        public void CryptSentence_II_I_III_MustBeAValidCrypt(string inputText, string expectedOutputText)
        {
            //Arrange
            IEnigma enigma = new EnigmaI(new RotorII(), new RotorI(), new RotorIII(), new ReflectorB());

            //Act
            string calculatedOutputText = string.Empty;
            for (var i = 0; i < inputText.Length; i++)
            {
                calculatedOutputText += enigma.Write(inputText[i]);
            }

            //Assert
            Assert.Equal(expectedOutputText, calculatedOutputText);
        }

        [Theory]
        [InlineData("TFNKVKCDGKV", "PEDROLEITAO")] 
        [InlineData("QTJPTKCDGKV", "JULIALEITAO")]
        public void DecryptSentence_II_I_III_MustBeAValidDecrypt(string inputText, string expectedOutputText)
        {
            //Arrange
            IEnigma enigma = new EnigmaI(new RotorII(), new RotorI(), new RotorIII(), new ReflectorB());

            //Act
            string calculatedOutputText = string.Empty;
            for (var i = 0; i < inputText.Length; i++)
            {
                calculatedOutputText += enigma.Write(inputText[i]);
            }

            //Assert
            Assert.Equal(expectedOutputText, calculatedOutputText);
        }

        [Theory]
        [InlineData("AY", "AAAAYYYY", "GCKHGISX")]
        [InlineData("AY GX MP", "AAAAYYYY", "XCKHXISG")]
        public void PlugBoardConfigurationMustHaveValidConversion(string plugBoardJumpers, string inputText, string expectedOutputText)
        {
            //Arrange
            IEnigma enigma = new EnigmaI();
            enigma.ConfigurePlugBoard(plugBoardJumpers);

            //Act
            string calculatedOutputText = string.Empty;
            for (var i = 0; i < inputText.Length; i++)
            {
                calculatedOutputText += enigma.Write(inputText[i]);
            }

            //Assert
            Assert.Equal(expectedOutputText, calculatedOutputText);
        }
    }
}