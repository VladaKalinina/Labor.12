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
            Point<Plant> point = new Point<Plant>(); // Создаем узел без данных

            // Assert
            Assert.IsNull(point.Data); // Проверяем, что Data равно null
        }

        [TestMethod]
        public void Constructor_WithData_SetsCorrectData()
        {
            // Arrange
            Plant plant = new Plant("TestPlant", "Green", 1); // Создаем тестовое растение

            // Act
            Point<Plant> point = new Point<Plant>(plant); // Создаем узел с данными

            // Assert
            Assert.AreEqual(plant, point.Data); // Проверяем, что Data содержит растение
        }

        [TestMethod]
        public void Constructor_WithData_SetsNextToNull()
        {
            // Arrange
            Plant plant = new Plant("TestPlant", "Green", 1); // Создаем тестовое растение

            // Act
            Point<Plant> point = new Point<Plant>(plant); // Создаем узел

            // Assert
            Assert.IsNull(point.Next); // Проверяем, что Next равно null
        }

        [TestMethod]
        public void Constructor_WithData_SetsPredToNull()
        {
            // Arrange
            Plant plant = new Plant("TestPlant", "Green", 1); // Создаем тестовое растение

            // Act
            Point<Plant> point = new Point<Plant>(plant); // Создаем узел

            // Assert
            Assert.IsNull(point.Pred); // Проверяем, что Pred равно null
        }

        [TestMethod]
        public void MakeRandomData_PlantType_ReturnsPointWithPlant()
        {
            // Arrange
            Point<Plant> point = new Point<Plant>(); // Пустой узел

            // Act
            Point<Plant> result = point.MakeRandomData(); // Создаем случайный узел

            // Assert
            Assert.IsNotNull(result.Data); // Проверяем, что Data не null
        }

        [TestMethod]
        public void MakeRandomItem_PlantType_ReturnsPlant()
        {
            // Arrange
            Point<Plant> point = new Point<Plant>(); // Пустой узел

            // Act
            Plant result = point.MakeRandomItem(); // Создаем случайное растение

            // Assert
            Assert.IsNotNull(result); // Проверяем, что возвращается растение
        }

        [TestMethod]
        public void ToString_WithPlantData_ReturnsPlantString()
        {
            // Arrange
            Plant plant = new Plant("TestPlant", "Green", 1); // Тестовое растение
            Point<Plant> point = new Point<Plant>(plant); // Узел с данными

            // Act
            string result = point.ToString(); // Получаем строковое представление

            // Assert
            Assert.AreEqual(plant.ToString(), result); // Проверяем строку растения
        }
    }
}
