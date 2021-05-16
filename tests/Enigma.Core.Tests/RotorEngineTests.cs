using System;
using Xunit;
using Enigma.Core.Interfaces;
using Enigma.Core;
using System.Reflection;
using System.Linq;

namespace Enigma.Core.Tests
{
    public class RotorEngineTests
    {
        private const char DEFAULT_RINGSETTINGS = 'A';
        private const string DEFAULT_SEQUENCE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string DEFAULT_WIREDSEQUENCE = "EKMFLGDQVZNTOWYHXUSPAIBRCJ";
        private const string DEFAULT_TURNOVER_NOTCH = "Q";

        [Theory]
        [InlineData('A',"EKMFLGDQVZNTOWYHXUSPAIBRCJ")]
        [InlineData('B',"KFLNGMHERWAOUPXZIYVTQBJCSD")]
        [InlineData('C',"ELGMOHNIFSXBPVQYAJZWURCKDT")]
        [InlineData('D',"UFMHNPIOJGTYCQWRZBKAXVSDLE")]
        [InlineData('E',"FVGNIOQJPKHUZDRXSACLBYWTEM")]
        [InlineData('F',"NGWHOJPRKQLIVAESYTBDMCZXUF")]
        [InlineData('G',"GOHXIPKQSLRMJWBFTZUCENDAYV")]
        [InlineData('H',"WHPIYJQLRTMSNKXCGUAVDFOEBZ")]
        [InlineData('I',"AXIQJZKRMSUNTOLYDHVBWEGPFC")]
        [InlineData('J',"DBYJRKALSNTVOUPMZEIWCXFHQG")]
        [InlineData('K',"HECZKSLBMTOUWPVQNAFJXDYGIR")]
        [InlineData('L',"SIFDALTMCNUPVXQWROBGKYEZHJ")]
        [InlineData('M',"KTJGEBMUNDOVQWYRXSPCHLZFAI")]
        [InlineData('N',"JLUKHFCNVOEPWRXZSYTQDIMAGB")]
        [InlineData('O',"CKMVLIGDOWPFQXSYATZUREJNBH")]
        [InlineData('P',"IDLNWMJHEPXQGRYTZBUAVSFKOC")]
        [InlineData('Q',"DJEMOXNKIFQYRHSZUACVBWTGLP")]
        [InlineData('R',"QEKFNPYOLJGRZSITAVBDWCXUHM")]
        [InlineData('S',"NRFLGOQZPMKHSATJUBWCEXDYVI")]
        [InlineData('T',"JOSGMHPRAQNLITBUKVCXDFYEZW")]
        [InlineData('U',"XKPTHNIQSBROMJUCVLWDYEGZFA")]
        [InlineData('V',"BYLQUIOJRTCSPNKVDWMXEZFHAG")]
        [InlineData('W',"HCZMRVJPKSUDTQOLWEXNYFAGIB")]
        [InlineData('X',"CIDANSWKQLTVEURPMXFYOZGBHJ")]
        [InlineData('Y',"KDJEBOTXLRMUWFVSQNYGZPAHCI")]
        [InlineData('Z',"JLEKFCPUYMSNVXGWTROZHAQBID")]
        public void ConfigureRingSettings_ValidCalculations(char innerRingSettingCharacter, string expectedSequence)
        {
            //Arrange
            IRotorEngine rotorEngine = new RotorEngine(DEFAULT_RINGSETTINGS, DEFAULT_SEQUENCE, DEFAULT_WIREDSEQUENCE, DEFAULT_TURNOVER_NOTCH);

            //Act
            rotorEngine.ConfigureInnerRingSetting(innerRingSettingCharacter);
            var calculatedSequence = rotorEngine.WiredSequence;

            //Assert
            Assert.Equal(calculatedSequence, expectedSequence);
        }

        [Theory]
        [InlineData('a',"EKMFLGDQVZNTOWYHXUSPAIBRCJ")]      
        public void ConfigureRingSettings_LowerCaseCharMustbeValid(char innerRingSettingCharacter, string expectedSequence)
        {
            //Arrange
            IRotorEngine rotorEngine = new RotorEngine(DEFAULT_RINGSETTINGS, DEFAULT_SEQUENCE, DEFAULT_WIREDSEQUENCE, DEFAULT_TURNOVER_NOTCH);

            //Act
            rotorEngine.ConfigureInnerRingSetting(innerRingSettingCharacter);
            var calculatedSequence = rotorEngine.WiredSequence;

            //Assert
            Assert.Equal(calculatedSequence, expectedSequence);
        }

        [Fact] 
        public void ConfigureRingSettings_MustResetBeforeReconfigureInChainedConfigurations()
        {
            //Arrange
            char firstInnerRingSetting = 'B';
            string firstExpectedSequence = "KFLNGMHERWAOUPXZIYVTQBJCSD";
            char secondInnerRingSetting = 'C';
            string secondExpectedSequence = "ELGMOHNIFSXBPVQYAJZWURCKDT";
            IRotorEngine rotorEngine = new RotorEngine(DEFAULT_RINGSETTINGS, DEFAULT_SEQUENCE, DEFAULT_WIREDSEQUENCE, DEFAULT_TURNOVER_NOTCH);

            //Act
            rotorEngine.ConfigureInnerRingSetting(firstInnerRingSetting);
            var firstCalculatedSequence = rotorEngine.WiredSequence;
            rotorEngine.ConfigureInnerRingSetting(secondInnerRingSetting);
            var secondCalculatedSequence = rotorEngine.WiredSequence;

            //Assert
            Assert.Equal(firstCalculatedSequence, firstExpectedSequence);
            Assert.Equal(secondCalculatedSequence, secondExpectedSequence);
        }
    }
}
