namespace tarea
{
    using System;

    public enum SortDirection
    {
        Asc,
        Desc
    }

    public class ListaDoble
    {
        public Nodo Cabeza;
        private Nodo Medio; 
        private int Count;  

        public ListaDoble()
        {
            Cabeza = null;
            Medio = null;
            Count = 0;
        }


        // Método para insertar valores en orden ascendente

        public void InsertInOrder(int value)
        {
            Nodo nuevoNodo = new Nodo(value);

            if (Cabeza == null)
            {
                Cabeza = nuevoNodo;
                Medio = nuevoNodo;
            }
            else
            {
                Nodo actual = Cabeza;
                Nodo anterior = null;

                while (actual != null && actual.Valor < value)
                {
                    anterior = actual;
                    actual = actual.Siguiente;
                }

                if (anterior == null)
                {
                    nuevoNodo.Siguiente = Cabeza;
                    Cabeza.Anterior = nuevoNodo;
                    Cabeza = nuevoNodo;
                }
                else
                {
                    nuevoNodo.Siguiente = actual;
                    nuevoNodo.Anterior = anterior;
                    anterior.Siguiente = nuevoNodo;

                    if (actual != null)
                    {
                        actual.Anterior = nuevoNodo;
                    }
                }
            }

            Count++;
            UpdateMiddle();
        }
        // Método para invertir la lista doblemente enlazada sin crear una nueva lista
        public void Invert()
        {
            if (Cabeza == null)
            {
                throw new Exception("La lista está vacía");
            }

            Nodo actual = Cabeza;
            Nodo temp = null;

            // Intercambiar los punteros Anterior y Siguiente para cada nodo
            while (actual != null)
            {
                temp = actual.Anterior;
                actual.Anterior = actual.Siguiente;
                actual.Siguiente = temp;
                actual = actual.Anterior; // Moverse al siguiente nodo (que ahora está en Anterior)
            }

            // Ajustar la nueva cabeza de la lista
            if (temp != null)
            {
                Cabeza = temp.Anterior; // El último nodo será la nueva cabeza
            }
        }


        // Método para eliminar el primer nodo
        public int DeleteFirst()
        {
            if (Cabeza == null)
            {
                throw new Exception("La lista está vacía");
            }

            int valor = Cabeza.Valor;
            Cabeza = Cabeza.Siguiente;

            if (Cabeza != null)
            {
                Cabeza.Anterior = null;
            }

            Count--;
            UpdateMiddle();

            return valor;
        }

        // Método para eliminar el último nodo
        public int DeleteLast()
        {
            if (Cabeza == null)
            {
                throw new Exception("La lista está vacía");
            }

            Nodo actual = Cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }

            int valor = actual.Valor;
            if (actual.Anterior != null)
            {
                actual.Anterior.Siguiente = null;
            }
            else
            {
                Cabeza = null;
            }

            Count--;
            UpdateMiddle();

            return valor;
        }

        // Método para eliminar un valor específico
        public bool DeleteValue(int value)
        {
            if (Cabeza == null)
            {
                throw new Exception("La lista está vacía");
            }

            Nodo actual = Cabeza;
            while (actual != null && actual.Valor != value)
            {
                actual = actual.Siguiente;
            }

            if (actual == null) // Valor no encontrado
            {
                return false;
            }

            if (actual.Anterior != null)
            {
                actual.Anterior.Siguiente = actual.Siguiente;
            }
            else
            {
                Cabeza = actual.Siguiente;
            }

            if (actual.Siguiente != null)
            {
                actual.Siguiente.Anterior = actual.Anterior;
            }

            Count--;
            UpdateMiddle();

            return true;
        }

        // Método para obtener el nodo medio
        public int GetMiddle()
        {
            if (Medio == null)
            {
                throw new Exception("La lista está vacía");
            }

            return Medio.Valor;
        }

        // Método para mezclar dos listas en orden ascendente o descendente
        public void MergeSorted(ListaDoble listA, ListaDoble listB, SortDirection direction)
        {
            if (listA == null || listB == null)
            {
                throw new Exception("Una o ambas listas son nulas");
            }

            Nodo nodoA = listA.Cabeza;
            Nodo nodoB = listB.Cabeza;

            ListaDoble resultado = new ListaDoble();

            while (nodoA != null && nodoB != null)
            {
                if (direction == SortDirection.Asc)
                {
                    if (nodoA.Valor <= nodoB.Valor)
                    {
                        resultado.InsertInOrder(nodoA.Valor);
                        nodoA = nodoA.Siguiente;
                    }
                    else
                    {
                        resultado.InsertInOrder(nodoB.Valor);
                        nodoB = nodoB.Siguiente;
                    }
                }
                else // Descendente
                {
                    if (nodoA.Valor >= nodoB.Valor)
                    {
                        resultado.InsertInOrder(nodoA.Valor);
                        nodoA = nodoA.Siguiente;
                    }
                    else
                    {
                        resultado.InsertInOrder(nodoB.Valor);
                        nodoB = nodoB.Siguiente;
                    }
                }
            }

            while (nodoA != null)
            {
                resultado.InsertInOrder(nodoA.Valor);
                nodoA = nodoA.Siguiente;
            }

            while (nodoB != null)
            {
                resultado.InsertInOrder(nodoB.Valor);
                nodoB = nodoB.Siguiente;
            }

            listA.Cabeza = resultado.Cabeza;
        }

        // Método auxiliar para actualizar el nodo medio después de inserciones/eliminaciones
        private void UpdateMiddle()
        {
            if (Count == 0)
            {
                Medio = null;
                return;
            }

            Nodo actual = Cabeza;
            int steps = Count / 2;

            for (int i = 0; i < steps; i++)
            {
                actual = actual.Siguiente;
            }

            Medio = actual;
        }

        // Método para mostrar la lista (para pruebas)
        public void MostrarLista()
        {
            Nodo actual = Cabeza;
            while (actual != null)
            {
                Console.Write(actual.Valor + " ");
                actual = actual.Siguiente;
            }
            Console.WriteLine();
        }
    }
}