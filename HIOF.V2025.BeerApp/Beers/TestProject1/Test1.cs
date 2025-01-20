using System.Security.Cryptography.X509Certificates;

namespace TestProject1;

[TestClass]
public class Test1
{
    [TestMethod]
    public void Consructor_ValidAlcoholByVolume_AlcocolByVolumeIsSet() 
        {
            // Arrange
            double alcoholByVolume = 5.0;

            // Act
            var beer = new Beer(alcoholByVolume);

            // Assert
            Assert.AreEqual(5.0, beer.AlcoholByVolume, "AlcoholByVolume is not set");
        }
}
