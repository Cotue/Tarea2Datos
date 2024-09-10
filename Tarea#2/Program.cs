namespace tarea
{
    public class Program
    {
        static void Main(string[] args)
        {
            // **PROBLEMA #1: MEZCLAR EN ORDEN**

            // Crear dos listas doblemente enlazadas en orden ascendente
            ListaDoble listA = new ListaDoble();
            listA.InsertInOrder(0);
            listA.InsertInOrder(2);
            listA.InsertInOrder(6);
            listA.InsertInOrder(10);
            listA.InsertInOrder(25);

            ListaDoble listB = new ListaDoble();
            listB.InsertInOrder(3);
            listB.InsertInOrder(7);
            listB.InsertInOrder(11);
            listB.InsertInOrder(40);
            listB.InsertInOrder(50);

            Console.WriteLine("Lista A antes de mezclar:");
            listA.MostrarLista();

            Console.WriteLine("Lista B antes de mezclar:");
            listB.MostrarLista();

            // Mezclar listB en listA en orden ascendente
            listA.MergeSorted(listA, listB, SortDirection.Asc);
            Console.WriteLine("Lista A después de mezclar en orden ascendente:");
            listA.MostrarLista();

            // **PROBLEMA #2: INVERTIR LISTA**
            ListaDoble listo = new ListaDoble();
            listo.InsertInOrder(0);
            listo.InsertInOrder(2);
            listo.InsertInOrder(6);
            listo.InsertInOrder(10);
            listo.InsertInOrder(25);
            Console.WriteLine("Lista o antes de invertir:");
            listo.MostrarLista();
            Console.WriteLine("Invirtiendo Lista 0:");
            listo.Invert();
            Console.WriteLine("Lista o después de invertir:");
            listo.MostrarLista();

            // **PROBLEMA #3: OBTENER EL ELEMENTO CENTRAL**

            try
            {
                int middleElement = listA.GetMiddle();
                Console.WriteLine($"Elemento central de la lista A: {middleElement}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Otro ejemplo con una lista más pequeña
            ListaDoble listC = new ListaDoble();
            listC.InsertInOrder(1);
            listC.InsertInOrder(2);
            listC.InsertInOrder(3);

            Console.WriteLine("Lista C:");
            listC.MostrarLista();

            int middleElementC = listC.GetMiddle();
            Console.WriteLine($"Elemento central de la lista C: {middleElementC}");
        }
    }
}
