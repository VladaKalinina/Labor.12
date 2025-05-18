using Plants;
using Lab12;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Reflection;

namespace Lab12Test
{
    [TestClass]
    public class MyTreeTests
    {
        [TestMethod]
        public void Constructor_EmptyTree_HasZeroCount()
        {
            var tree = new MyTree<Plant>();
            Assert.AreEqual(0, tree.Count, "Пустое дерево должно иметь Count = 0.");
        }

        [TestMethod]
        public void Constructor_WithItems_CreatesBalancedTree()
        {
            var items = new Plant[] { new Plant("Plant1", "Green", 1), new Plant("Plant2", "Red", 2), new Plant("Plant3", "Blue", 3) };
            var tree = new MyTree<Plant>(items);
            Assert.AreEqual(3, tree.Count, "Дерево должно содержать 3 элемента.");
        }

        [TestMethod]
        public void TransformToSearchTree_ValidTree_CreatesAVLTree()
        {
            var items = new Plant[] { new Plant("Plant2", "Red", 2), new Plant("Plant1", "Green", 1), new Plant("Plant3", "Blue", 3) };
            var tree = new MyTree<Plant>(items);
            var searchTree = tree.TransformToSearchTree();
            Assert.AreEqual(3, searchTree.Count, "АВЛ-дерево должно содержать 3 элемента.");
        }

        [TestMethod]
        public void AddPoint_ValidData_IncreasesCount()
        {
            var tree = new MyTree<Plant>();
            var plant = new Plant("TestPlant", "Green", 1);
            tree.AddPoint(plant);
            Assert.AreEqual(1, tree.Count, "После добавления одного узла Count должен быть 1.");
        }

        [TestMethod]
        public void AddPoint_ValidData_MaintainsBalance()
        {
            var tree = new MyTree<Plant>();
            tree.AddPoint(new Plant("Plant2", "Red", 2));
            tree.AddPoint(new Plant("Plant1", "Green", 1));
            tree.AddPoint(new Plant("Plant3", "Blue", 3));
            Assert.IsTrue(IsBalanced(tree), "Дерево должно быть сбалансированным после добавления.");
        }

        [TestMethod]
        public void RemoveByKey_ExistingKey_RemovesItem()
        {
            var items = new Plant[] { new Plant("Plant2", "Red", 2), new Plant("Plant1", "Green", 1), new Plant("Plant3", "Blue", 3) };
            var tree = new MyTree<Plant>(items);
            var keyToRemove = new Plant("Plant2", "Red", 2);
            tree.RemoveByKey(keyToRemove);
            Assert.AreEqual(2, tree.Count, "После удаления должно остаться 2 узла.");
        }

        [TestMethod]
        public void RemoveByKey_ExistingKey_MaintainsBalance()
        {
            var items = new Plant[] { new Plant("Plant2", "Red", 2), new Plant("Plant1", "Green", 1), new Plant("Plant3", "Blue", 3) };
            var tree = new MyTree<Plant>(items);
            var keyToRemove = new Plant("Plant2", "Red", 2);
            tree.RemoveByKey(keyToRemove);
            Assert.IsTrue(IsBalanced(tree), "Дерево должно быть сбалансированным после удаления.");
        }

        [TestMethod]
        public void RemoveByKey_NonExistingKey_ReturnsFalse()
        {
            var items = new Plant[] { new Plant("Plant1", "Green", 1), new Plant("Plant2", "Red", 2) };
            var tree = new MyTree<Plant>(items);
            var keyToRemove = new Plant("Plant999", "Blue", 999);
            bool removed = tree.RemoveByKey(keyToRemove);
            Assert.IsFalse(removed, "Удаление несуществующего узла должно вернуть false.");
        }

        [TestMethod]
        public void FindAverageAge_OnlyTrees_ReturnsCorrectAverage()
        {
            var items = new Tree[] { new Tree("Tree1", "Green", 10, 1), new Tree("Tree2", "Red", 20, 2) };
            var tree = new MyTree<Tree>(items);
            double average = tree.FindAverageAge();
            Assert.AreEqual(15.0, average, 0.01, "Среднее арифметическое высоты деревьев должно быть 15.");
        }

        [TestMethod]
        public void FindAverageAge_MixedItems_IgnoresNonTrees()
        {
            var items = new Plant[] { new Tree("Tree1", "Green", 10, 1), new Plant("Plant1", "Blue", 3), new Tree("Tree2", "Red", 20, 2) };
            var tree = new MyTree<Plant>(items);
            double average = tree.FindAverageAge();
            Assert.AreEqual(15.0, average, 0.01, "Среднее арифметическое должно учитывать только деревья.");
        }

        [TestMethod]
        public void FindAverageAge_EmptyTree_ReturnsZero()
        {
            var tree = new MyTree<Plant>();
            double average = tree.FindAverageAge();
            Assert.AreEqual(0.0, average, 0.01, "Пустое дерево должно возвращать среднее 0.");
        }

        [TestMethod]
        public void Clone_DeepCopy_DoesNotModifyOriginal()
        {
            var plant = new Plant("TestPlant", "Green", 1);
            var tree = new MyTree<Plant>();
            tree.AddPoint(plant);
            var searchTree = tree.TransformToSearchTree();
            var modifiedPlant = searchTree.TransformToSearchTree().root.Data;
            modifiedPlant.Name = "ModifiedPlant";
            Assert.AreEqual("TestPlant", plant.Name, "Оригинальный объект не должен быть изменён после клонирования.");
        }

        [TestMethod]
        public void DeleteTree_ValidTree_ClearsTree()
        {
            var items = new Plant[] { new Plant("Plant1", "Green", 1), new Plant("Plant2", "Red", 2) };
            var tree = new MyTree<Plant>(items);
            tree.DeleteTree();
            Assert.AreEqual(0, tree.Count, "После удаления дерева Count должен быть 0.");
        }

        [TestMethod]
        public void ShowTree_ValidTree_OutputsCorrectFormat()
        {
            var items = new Plant[] { new Plant("Plant2", "Red", 2), new Plant("Plant1", "Green", 1), new Plant("Plant3", "Blue", 3) };
            var tree = new MyTree<Plant>(items);
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                tree.ShowTree();
                string output = sw.ToString();
                Assert.IsTrue(output.Contains("Plant2"), "Вывод должен содержать корень дерева.");
            }
        }

        [TestMethod]
        public void AddMultiplePoints_MaintainsBalance()
        {
            var tree = new MyTree<Plant>();
            tree.AddPoint(new Plant("Plant1", "Green", 5));
            tree.AddPoint(new Plant("Plant2", "Red", 2));
            tree.AddPoint(new Plant("Plant3", "Blue", 10));
            tree.AddPoint(new Plant("Plant4", "Yellow", 1));
            Assert.IsTrue(IsBalanced(tree), "Дерево должно оставаться сбалансированным после нескольких добавлений.");
        }

        [TestMethod]
        public void RemoveMultiplePoints_MaintainsBalance()
        {
            var items = new Plant[] { new Plant("Plant1", "Green", 5), new Plant("Plant2", "Red", 2), new Plant("Plant3", "Blue", 10), new Plant("Plant4", "Yellow", 1) };
            var tree = new MyTree<Plant>(items);
            tree.RemoveByKey(new Plant("Plant1", "Green", 5));
            tree.RemoveByKey(new Plant("Plant2", "Red", 2));
            Assert.IsTrue(IsBalanced(tree), "Дерево должно оставаться сбалансированным после нескольких удалений.");
        }

        [TestMethod]
        public void Clone_AfterMultipleOperations_DoesNotModifyOriginal()
        {
            var plant1 = new Plant("Plant1", "Green", 5);
            var plant2 = new Plant("Plant2", "Red", 2);
            var tree = new MyTree<Plant>();
            tree.AddPoint(plant1);
            tree.AddPoint(plant2);
            tree.RemoveByKey(plant2);
            var searchTree = tree.TransformToSearchTree();
            var modifiedPlant = searchTree.root.Data;
            modifiedPlant.Name = "ModifiedPlant";
            Assert.AreEqual("Plant1", plant1.Name, "Оригинальный объект не должен быть изменён после клонирования.");
        }

        [TestMethod]
        public void Height_AfterAddAndRemove_IsCorrect()
        {
            var tree = new MyTree<Plant>();
            tree.AddPoint(new Plant("Plant1", "Green", 5));
            tree.AddPoint(new Plant("Plant2", "Red", 2));
            tree.AddPoint(new Plant("Plant3", "Blue", 10));
            tree.RemoveByKey(new Plant("Plant2", "Red", 2));
            var height = GetTreeHeight(tree);
            Assert.AreEqual(2, height, "Высота дерева должна быть 2 после добавления и удаления.");
        }

        [TestMethod]
        public void RemoveByKey_EmptyTree_ReturnsFalse()
        {
            var tree = new MyTree<Plant>();
            var keyToRemove = new Plant("Plant1", "Green", 5);
            bool removed = tree.RemoveByKey(keyToRemove);
            Assert.IsFalse(removed, "Удаление из пустого дерева должно вернуть false.");
        }

        [TestMethod]
        public void RightRotate_AfterUnbalancedAdd_CorrectsHeight()
        {
            var tree = new MyTree<Plant>();
            tree.AddPoint(new Plant("Plant2", "Red", 2));
            tree.AddPoint(new Plant("Plant1", "Green", 1));
            var root = GetRoot(tree);
            Assert.AreEqual(1, root.Height, "Высота после правого поворота должна быть 1.");
        }

        [TestMethod]
        public void LeftRotate_AfterUnbalancedAdd_CorrectsHeight()
        {
            var tree = new MyTree<Plant>();
            tree.AddPoint(new Plant("Plant1", "Green", 1));
            tree.AddPoint(new Plant("Plant2", "Red", 2));
            tree.AddPoint(new Plant("Plant3", "Blue", 3));
            var root = GetRoot(tree);
            Assert.AreEqual(2, root.Height, "Высота после левого поворота должна быть 2.");
        }

        [TestMethod]
        public void AddDuplicatePoint_DoesNotIncreaseCount()
        {
            var tree = new MyTree<Plant>();
            var plant = new Plant("TestPlant", "Green", 1);
            tree.AddPoint(plant);
            tree.AddPoint(plant);
            Assert.AreEqual(1, tree.Count, "Добавление дубликата не должно увеличивать Count.");
        }

        [TestMethod]
        public void DeleteTree_WithMultipleNodes_FreesMemory()
        {
            var items = new Plant[] { new Plant("Plant1", "Green", 1), new Plant("Plant2", "Red", 2), new Plant("Plant3", "Blue", 3) };
            var tree = new MyTree<Plant>(items);
            tree.DeleteTree();
            var root = GetRoot(tree);
            Assert.IsNull(root, "Корень должен быть null после удаления дерева.");
        }

        [TestMethod]
        public void ShowTree_WithSingleNode_OutputsCorrectly()
        {
            var tree = new MyTree<Plant>();
            tree.AddPoint(new Plant("Plant1", "Green", 1));
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                tree.ShowTree();
                string output = sw.ToString();
                Assert.IsTrue(output.Contains("Plant1"), "Вывод должен содержать единственный узел.");
            }
        }

        [TestMethod]
        public void ShowTree_WithManyNodes_OutputsAllNodes()
        {
            var items = new Plant[] { new Plant("Plant1", "Green", 1), new Plant("Plant2", "Red", 2), new Plant("Plant3", "Blue", 3), new Plant("Plant4", "Yellow", 4) };
            var tree = new MyTree<Plant>(items);
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                tree.ShowTree();
                string output = sw.ToString();
                Assert.IsTrue(output.Contains("Plant2") && output.Contains("Plant4"), "Вывод должен содержать все узлы.");
            }
        }

        [TestMethod]
        public void Insert_WithLeftLeftCase_TriggersRightRotate()
        {
            var tree = new MyTree<Plant>();
            tree.AddPoint(new Plant("Plant3", "Blue", 3));
            tree.AddPoint(new Plant("Plant2", "Red", 2));
            tree.AddPoint(new Plant("Plant1", "Green", 1));
            var root = GetRoot(tree);
            Assert.AreEqual("Plant2", root.Data.Name, "После правого поворота корень должен быть Plant2.");
        }

        [TestMethod]
        public void Insert_WithRightRightCase_TriggersLeftRotate()
        {
            var tree = new MyTree<Plant>();
            tree.AddPoint(new Plant("Plant1", "Green", 1));
            tree.AddPoint(new Plant("Plant2", "Red", 2));
            tree.AddPoint(new Plant("Plant3", "Blue", 3));
            var root = GetRoot(tree);
            Assert.AreEqual("Plant2", root.Data.Name, "После левого поворота корень должен быть Plant2.");
        }

        [TestMethod]
        public void DeleteNode_WithTwoChildren_MaintainsBalance()
        {
            var items = new Plant[] { new Plant("Plant2", "Red", 2), new Plant("Plant1", "Green", 1), new Plant("Plant4", "Yellow", 4), new Plant("Plant3", "Blue", 3) };
            var tree = new MyTree<Plant>(items);
            tree.RemoveByKey(new Plant("Plant2", "Red", 2));
            Assert.IsTrue(IsBalanced(tree), "Дерево должно быть сбалансированным после удаления узла с двумя потомками.");
        }

        [TestMethod]
        public void MakeBalancedTree_WithOddCount_CreatesCorrectRoot()
        {
            var items = new Plant[] { new Plant("Plant1", "Green", 1), new Plant("Plant2", "Red", 2), new Plant("Plant3", "Blue", 3) };
            var tree = new MyTree<Plant>(items);
            var root = GetRoot(tree);
            Assert.AreEqual("Plant2", root.Data.Name, "Корень должен быть Plant2 для нечетного числа элементов.");
        }

        [TestMethod]
        public void MakeBalancedTree_WithEvenCount_CreatesCorrectRoot()
        {
            var items = new Plant[] { new Plant("Plant1", "Green", 1), new Plant("Plant2", "Red", 2), new Plant("Plant3", "Blue", 3), new Plant("Plant4", "Yellow", 4) };
            var tree = new MyTree<Plant>(items);
            var root = GetRoot(tree);
            Assert.AreEqual("Plant2", root.Data.Name, "Корень должен быть Plant2 для четного числа элементов.");
        }

        // Новые тесты для прямого вызова приватных методов

        [TestMethod]
        public void RightRotate_DirectCall_UpdatesLinks()
        {
            var tree = new MyTree<Plant>();
            var node = new PointTree<Plant>(new Plant("Parent", "Red", 2));
            node.Left = new PointTree<Plant>(new Plant("Left", "Green", 1));
            var rotateMethod = typeof(MyTree<Plant>).GetMethod("RightRotate", BindingFlags.NonPublic | BindingFlags.Instance);
            var rotated = rotateMethod.Invoke(tree, new object[] { node }) as PointTree<Plant>;
            Assert.AreEqual("Left", rotated.Data.Name, "После правого поворота корень должен быть Left.");
        }

        [TestMethod]
        public void LeftRotate_DirectCall_UpdatesLinks()
        {
            var tree = new MyTree<Plant>();
            var node = new PointTree<Plant>(new Plant("Parent", "Green", 1));
            node.Right = new PointTree<Plant>(new Plant("Right", "Red", 2));
            var rotateMethod = typeof(MyTree<Plant>).GetMethod("LeftRotate", BindingFlags.NonPublic | BindingFlags.Instance);
            var rotated = rotateMethod.Invoke(tree, new object[] { node }) as PointTree<Plant>;
            Assert.AreEqual("Right", rotated.Data.Name, "После левого поворота корень должен быть Right.");
        }

        [TestMethod]
        public void Insert_DirectCall_WithNullNode_ReturnsNewNode()
        {
            var tree = new MyTree<Plant>();
            var insertMethod = typeof(MyTree<Plant>).GetMethod("Insert", BindingFlags.NonPublic | BindingFlags.Instance);
            var newNode = insertMethod.Invoke(tree, new object[] { null, new Plant("Test", "Green", 1) }) as PointTree<Plant>;
            Assert.IsNotNull(newNode, "Вставка в null должна создать новый узел.");
        }

        [TestMethod]
        public void Insert_DirectCall_WithDuplicate_IgnoresDuplicate()
        {
            var tree = new MyTree<Plant>();
            var node = new PointTree<Plant>(new Plant("Test", "Green", 1));
            var insertMethod = typeof(MyTree<Plant>).GetMethod("Insert", BindingFlags.NonPublic | BindingFlags.Instance);
            var result = insertMethod.Invoke(tree, new object[] { node, new Plant("Test", "Green", 1) }) as PointTree<Plant>;
            Assert.AreEqual(node, result, "Вставка дубликата не должна менять узел.");
        }

        

        [TestMethod]
        public void MakeBalancedTree_DirectCall_WithEmptyArray_ReturnsNull()
        {
            var tree = new MyTree<Plant>();
            var makeBalancedMethod = typeof(MyTree<Plant>).GetMethod("MakeBalancedTree", BindingFlags.NonPublic | BindingFlags.Instance);
            var result = makeBalancedMethod.Invoke(tree, new object[] { new Plant[0], 0, -1 }) as PointTree<Plant>;
            Assert.IsNull(result, "Создание дерева из пустого массива должно вернуть null.");
        }

        // Вспомогательные методы

        private bool IsBalanced(MyTree<Plant> tree)
        {
            return CheckBalance(tree, GetRoot(tree));
        }

        private bool CheckBalance(MyTree<Plant> tree, PointTree<Plant> node)
        {
            if (node == null) return true;

            var getBalanceMethod = tree.GetType().GetMethod("GetBalance", BindingFlags.NonPublic | BindingFlags.Instance);
            int balance = (int)getBalanceMethod.Invoke(tree, new object[] { node });
            if (Math.Abs(balance) > 1) return false;

            return CheckBalance(tree, node.Left) && CheckBalance(tree, node.Right);
        }

        private Plant FindMinAge(MyTree<Plant> tree)
        {
            var root = GetRoot(tree);
            if (root == null) return null;

            var current = root;
            while (current.Left != null)
            {
                current = current.Left;
            }
            return current.Data;
        }

        private int GetTreeHeight(MyTree<Plant> tree)
        {
            var root = GetRoot(tree);
            if (root == null) return 0;
            return root.Height;
        }

        private PointTree<Plant> GetRoot(MyTree<Plant> tree)
        {
            return tree.GetType().GetField("root", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(tree) as PointTree<Plant>;
        }
    }

    [TestClass]
    public class PointTreeTests
    {
        [TestMethod]
        public void Constructor_EmptyNode_SetsDefaultValues()
        {
            var node = new PointTree<Plant>();
            Assert.IsNull(node.Data, "Data должно быть null.");
        }

        [TestMethod]
        public void Constructor_WithData_SetsDataCorrectly()
        {
            var plant = new Plant("TestPlant", "Green", 1);
            var node = new PointTree<Plant>(plant);
            Assert.AreEqual(plant, node.Data, "Data должно быть равно переданному объекту.");
        }

        [TestMethod]
        public void ToString_ValidData_ReturnsCorrectString()
        {
            var plant = new Plant("TestPlant", "Green", 1);
            var node = new PointTree<Plant>(plant);
            Assert.AreEqual("Растение: Имя=TestPlant, Цвет=Green", node.ToString(), "ToString должен возвращать корректную строку.");
        }

        [TestMethod]
        public void ToString_NullData_ReturnsEmptyString()
        {
            var node = new PointTree<Plant>();
            Assert.AreEqual("", node.ToString(), "ToString должен возвращать пустую строку для null Data.");
        }
    }
}