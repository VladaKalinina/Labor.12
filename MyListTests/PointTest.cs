using Lab12;
using Plants;

namespace Lab12Test
{
    [TestClass]
    public class PointTests
    {
        [TestMethod]
        public void Constructor_NoData_SetsDataToDefault()
        {
            // Arrange & Act
            Point<Plant> point = new Point<Plant>(); // ������� ���� ��� ������

            // Assert
            Assert.IsNull(point.Data); // ���������, ��� Data ����� null
        }

        [TestMethod]
        public void Constructor_WithData_SetsCorrectData()
        {
            // Arrange
            Plant plant = new Plant("TestPlant", "Green", 1); // ������� �������� ��������

            // Act
            Point<Plant> point = new Point<Plant>(plant); // ������� ���� � �������

            // Assert
            Assert.AreEqual(plant, point.Data); // ���������, ��� Data �������� ��������
        }

        [TestMethod]
        public void Constructor_WithData_SetsNextToNull()
        {
            // Arrange
            Plant plant = new Plant("TestPlant", "Green", 1); // ������� �������� ��������

            // Act
            Point<Plant> point = new Point<Plant>(plant); // ������� ����

            // Assert
            Assert.IsNull(point.Next); // ���������, ��� Next ����� null
        }

        [TestMethod]
        public void Constructor_WithData_SetsPredToNull()
        {
            // Arrange
            Plant plant = new Plant("TestPlant", "Green", 1); // ������� �������� ��������

            // Act
            Point<Plant> point = new Point<Plant>(plant); // ������� ����

            // Assert
            Assert.IsNull(point.Pred); // ���������, ��� Pred ����� null
        }

        [TestMethod]
        public void MakeRandomData_PlantType_ReturnsPointWithPlant()
        {
            // Arrange
            Point<Plant> point = new Point<Plant>(); // ������ ����

            // Act
            Point<Plant> result = point.MakeRandomData(); // ������� ��������� ����

            // Assert
            Assert.IsNotNull(result.Data); // ���������, ��� Data �� null
        }

        [TestMethod]
        public void MakeRandomItem_PlantType_ReturnsPlant()
        {
            // Arrange
            Point<Plant> point = new Point<Plant>(); // ������ ����

            // Act
            Plant result = point.MakeRandomItem(); // ������� ��������� ��������

            // Assert
            Assert.IsNotNull(result); // ���������, ��� ������������ ��������
        }

        [TestMethod]
        public void ToString_WithPlantData_ReturnsPlantString()
        {
            // Arrange
            Plant plant = new Plant("TestPlant", "Green", 1); // �������� ��������
            Point<Plant> point = new Point<Plant>(plant); // ���� � �������

            // Act
            string result = point.ToString(); // �������� ��������� �������������

            // Assert
            Assert.AreEqual(plant.ToString(), result); // ��������� ������ ��������
        }
    }
}
