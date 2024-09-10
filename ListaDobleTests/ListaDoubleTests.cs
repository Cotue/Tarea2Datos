using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ListaDobleTests
{
    [TestClass]
    [TestClass]
    public class ListaDobleUnitTests
    {
        private ListaDoble listA;
        private ListaDoble listB;

        [TestInitialize]
        public void Setup()
        {
            listA = new ListaDoble();
            listB = new ListaDoble();
        }

        // PRUEBA PARA PROBLEMA #1: MEZCLAR EN ORDEN
        [TestMethod]
        public void MergeSorted_ShouldMergeTwoSortedListsAscending()
        {
            // Arrange
            listA.InsertInOrder(0);
            listA.InsertInOrder(2);
            listA.InsertInOrder(6);
            listA.InsertInOrder(10);
            listA.InsertInOrder(25);

            listB.InsertInOrder(3);
            listB.InsertInOrder(7);
            listB.InsertInOrder(11);
            listB.InsertInOrder(40);
            listB.InsertInOrder(50);

            // Act
            listA.MergeSorted(listA, listB, SortDirection.Asc);

            // Assert
            Assert.AreEqual(0, listA.DeleteFirst());
            Assert.AreEqual(2, listA.DeleteFirst());
            Assert.AreEqual(3, listA.DeleteFirst());
            Assert.AreEqual(6, listA.DeleteFirst());
            Assert.AreEqual(7, listA.DeleteFirst());
            Assert.AreEqual(10, listA.DeleteFirst());
            Assert.AreEqual(11, listA.DeleteFirst());
            Assert.AreEqual(25, listA.DeleteFirst());
            Assert.AreEqual(40, listA.DeleteFirst());
            Assert.AreEqual(50, listA.DeleteFirst());
        }

        // PRUEBA PARA PROBLEMA #1: MEZCLAR EN ORDEN DESCENDENTE
        [TestMethod]
        public void MergeSorted_ShouldMergeTwoSortedListsDescending()
        {
            // Arrange
            listA.InsertInOrder(10);
            listA.InsertInOrder(15);

            listB.InsertInOrder(9);
            listB.InsertInOrder(40);
            listB.InsertInOrder(50);

            // Act
            listA.MergeSorted(listA, listB, SortDirection.Desc);

            // Assert
            Assert.AreEqual(50, listA.DeleteFirst());
            Assert.AreEqual(40, listA.DeleteFirst());
            Assert.AreEqual(15, listA.DeleteFirst());
            Assert.AreEqual(10, listA.DeleteFirst());
            Assert.AreEqual(9, listA.DeleteFirst());
        }

        // PRUEBA PARA PROBLEMA #2: INVERTIR LISTA
        [TestMethod]
        public void Invert_ShouldInvertList()
        {
            // Arrange
            listA.InsertInOrder(1);
            listA.InsertInOrder(3);
            listA.InsertInOrder(5);

            // Act
            listA.Invert();

            // Assert
            Assert.AreEqual(5, listA.DeleteFirst());
            Assert.AreEqual(3, listA.DeleteFirst());
            Assert.AreEqual(1, listA.DeleteFirst());
        }

        // PRUEBA PARA PROBLEMA #3: OBTENER EL ELEMENTO CENTRAL CON NÚMERO IMPAR DE ELEMENTOS
        [TestMethod]
        public void GetMiddle_ShouldReturnMiddleElementForOddCount()
        {
            // Arrange
            listA.InsertInOrder(1);
            listA.InsertInOrder(3);
            listA.InsertInOrder(5);

            // Act
            int middle = listA.GetMiddle();

            // Assert
            Assert.AreEqual(3, middle);
        }

        // PRUEBA PARA PROBLEMA #3: OBTENER EL ELEMENTO CENTRAL CON NÚMERO PAR DE ELEMENTOS
        [TestMethod]
        public void GetMiddle_ShouldReturnMiddleElementForEvenCount()
        {
            // Arrange
            listA.InsertInOrder(1);
            listA.InsertInOrder(2);
            listA.InsertInOrder(3);
            listA.InsertInOrder(4);

            // Act
            int middle = listA.GetMiddle();

            // Assert
            Assert.AreEqual(3, middle);  // Con 4 elementos, el método debe devolver el segundo medio (3)
        }
    }
}

