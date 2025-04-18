using System;
using Plants;
using Lab12;

namespace Lab12Test
{

    [TestClass]
    public class MyListTests
    {
        [TestMethod]
        public void Add_ValidPlant_SetsBegData()
        {
            // Arrange
            MyList<Plant> list = new MyList<Plant>(); // Пустой список
            Plant plant = new Plant("TestPlant", "Green", 1); // Тестовое растение

            // Act
            list.Add(plant); // Добавляем растение

            // Assert
            Assert.IsNotNull(list.beg); // Проверяем, что beg не null
            Assert.IsNotNull(list.beg.Data); // Проверяем, что данные не null
        }



        [TestMethod]
        public void Add_ValidPlant_ClonesData()
        {
            // Arrange
            MyList<Plant> list = new MyList<Plant>(); // Пустой список
            Plant plant = new Plant("TestPlant", "Green", 1); // Тестовое растение

            // Act
            list.Add(plant); // Добавляем растение

            // Assert
            Assert.IsNotNull(list.beg); // Проверяем, что beg не null
            Assert.AreNotSame(plant, list.beg.Data); // Проверяем, что данные склонированы
        }
        [TestMethod]
        public void Remove_ExistingPlant_DecreasesCount()
        {
            // Arrange
            MyList<Plant> list = new MyList<Plant>(); // Пустой список
            Plant plant = new Plant("TestPlant", "Green", 1); // Тестовое растение
            list.Add(plant); // Добавляем растение

            // Act
            list.Remove(plant); // Удаляем растение

            // Assert
            Assert.AreEqual(0, list.Count); // Проверяем, что счетчик уменьшился
        }

        [TestMethod]
        public void Remove_NonExistingPlant_ReturnsFalse()
        {
            // Arrange
            MyList<Plant> list = new MyList<Plant>(); // Пустой список
            Plant plant = new Plant("TestPlant", "Green", 1); // Тестовое растение

            // Act
            bool result = list.Remove(plant); // Пытаемся удалить

            // Assert
            Assert.IsFalse(result); // Проверяем, что удаление не удалось
        }

        [TestMethod]
        public void RemoveByName_ExistingName_RemovesElement()
        {
            // Arrange
            MyList<Plant> list = new MyList<Plant>(); // Пустой список
            Plant plant = new Plant("TestPlant", "Green", 1); // Тестовое растение
            list.Add(plant); // Добавляем растение

            // Act
            list.RemoveByName("TestPlant"); // Удаляем по имени

            // Assert
            Assert.AreEqual(0, list.Count); // Проверяем, что элемент удален
        }

        [TestMethod]
        public void RemoveByName_NonExistingName_KeepsCount()
        {
            // Arrange
            MyList<Plant> list = new MyList<Plant>(); // Пустой список
            Plant plant = new Plant("TestPlant", "Green", 1); // Тестовое растение
            list.Add(plant); // Добавляем растение

            // Act
            list.RemoveByName("OtherPlant"); // Удаляем несуществующее имя

            // Assert
            Assert.AreEqual(1, list.Count); // Проверяем, что счетчик не изменился
        }

        [TestMethod]
        public void AddKToStart_ValidK_IncreasesCount()
        {
            // Arrange
            MyList<Plant> list = new MyList<Plant>(); // Пустой список

            // Act
            list.AddKToStart(3); // Добавляем 3 элемента

            // Assert
            Assert.AreEqual(3, list.Count); // Проверяем, что счетчик увеличился
        }

        [TestMethod]
        public void AddKToStart_ZeroK_KeepsCount()
        {
            // Arrange
            MyList<Plant> list = new MyList<Plant>(); // Пустой список

            // Act
            list.AddKToStart(0); // Добавляем 0 элементов

            // Assert
            Assert.AreEqual(0, list.Count); // Проверяем, что счетчик не изменился
        }

        [TestMethod]
        public void DeepCopyList_NonEmptyList_ReturnsEqualCount()
        {
            // Arrange
            MyList<Plant> list = new MyList<Plant>(); // Пустой список
            list.Add(new Plant("TestPlant", "Green", 1)); // Добавляем растение

            // Act
            MyList<Plant> clonedList = list.DeepCopyList(); // Клонируем список

            // Assert
            Assert.AreEqual(list.Count, clonedList.Count); // Проверяем, что размеры равны
        }

        [TestMethod]
        public void DeepCopyList_NonEmptyList_ReturnsDifferentInstance()
        {
            // Arrange
            MyList<Plant> list = new MyList<Plant>(); // Пустой список
            list.Add(new Plant("TestPlant", "Green", 1)); // Добавляем растение

            // Act
            MyList<Plant> clonedList = list.DeepCopyList(); // Клонируем список

            // Assert
            Assert.AreNotSame(list, clonedList); // Проверяем, что это разные объекты
        }

        [TestMethod]
        public void DeleteList_NonEmptyList_SetsCountToZero()
        {
            // Arrange
            MyList<Plant> list = new MyList<Plant>(); // Пустой список
            list.Add(new Plant("TestPlant", "Green", 1)); // Добавляем растение

            // Act
            list.DeleteList(); // Удаляем список

            // Assert
            Assert.AreEqual(0, list.Count); // Проверяем, что счетчик обнулился
        }

        [TestMethod]
        public void DeleteList_NonEmptyList_SetsBegToNull()
        {
            // Arrange
            MyList<Plant> list = new MyList<Plant>(); // Пустой список
            list.Add(new Plant("TestPlant", "Green", 1)); // Добавляем растение

            // Act
            list.DeleteList(); // Удаляем список

            // Assert
            Assert.IsNull(list.beg); // Проверяем, что начало списка null
        }
    }
}