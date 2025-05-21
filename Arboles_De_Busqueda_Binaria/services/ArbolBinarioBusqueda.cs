using Arboles_De_Busqueda_Binaria.models;

namespace Arboles_De_Busqueda_Binaria.services
{
    public class ArbolBinarioBusqueda
    {
        public NodoArbol Raiz { get; private set; }

        
        //METODOS PARA INSERTAR NODO AL ARBOL
        public void Insertar(int valor)
        {
            Raiz = InsertarRecursivo(Raiz, valor);
        }
        private NodoArbol InsertarRecursivo(NodoArbol nodo, int valor)
        {
            //Si llegamos a un nodo null, significa que encontramos un lugar vacío, y allí insertamos el nuevo nodo.
            if (nodo == null)
                return new NodoArbol(valor);

            if (valor < nodo.Valor)
                nodo.Izquierda = InsertarRecursivo(nodo.Izquierda, valor);
            else if (valor > nodo.Valor)
                nodo.Derecha = InsertarRecursivo(nodo.Derecha, valor);
            
            return nodo;
        }


        //METODOS PARA ELIMINAR UN NODO DEL ARBOL
        public void Eliminar(int valor)
        {
            Raiz = EliminarRecursivo(Raiz, valor);
        }
        private NodoArbol EliminarRecursivo(NodoArbol nodo, int valor)
        {
            if (nodo == null) return null;

            if (valor < nodo.Valor)
                nodo.Izquierda = EliminarRecursivo(nodo.Izquierda, valor);
            else if (valor > nodo.Valor)
                nodo.Derecha = EliminarRecursivo(nodo.Derecha, valor);

            else //if(valor == nodo.Valor)
            {
                if (nodo.Izquierda == null) return nodo.Derecha; 
                if (nodo.Derecha == null) return nodo.Izquierda;

                var sucesor = EncontrarMinimo(nodo.Derecha);
                nodo.Valor = sucesor.Valor;
                nodo.Derecha = EliminarRecursivo(nodo.Derecha, sucesor.Valor);
            }

            return nodo;
        }


        //METODOS PARA BUSCAR UN NODO EN EL ARBOL
        private NodoArbol EncontrarMinimo(NodoArbol nodo)
        {
            while (nodo.Izquierda != null) 
                nodo = nodo.Izquierda;
            return nodo;
        }
        public bool Buscar(int valor)
        {
            return BuscarRecursivo(Raiz, valor);
        }
        private bool BuscarRecursivo(NodoArbol nodo, int valor)
        {
            if (nodo == null) return false;
            if (nodo.Valor == valor) return true;
            if (valor < nodo.Valor)
                return BuscarRecursivo(nodo.Izquierda, valor);
            else
                return BuscarRecursivo(nodo.Derecha, valor);
        }


        //METODO PARA RECORRER EL ARBOL - INORDER
        public List<int> RecorridoInorden()
        {
            List<int> resultado = new List<int>();
            RecorridoInordenRecursivo(Raiz, resultado);
            return resultado;
        }
        private void RecorridoInordenRecursivo(NodoArbol nodo, List<int> resultado)
        {
            if (nodo != null)
            {
                // Primero recorrer el subárbol izquierdo
                RecorridoInordenRecursivo(nodo.Izquierda, resultado);

                // Luego agregar el valor del nodo actual
                resultado.Add(nodo.Valor);

                // Finalmente recorrer el subárbol derecho
                RecorridoInordenRecursivo(nodo.Derecha, resultado);
            }
        }


        //METODO PARA RECORRER EL ARBOL - PREORDEN
        public List<int> RecorridoPreorden()
        {
            List<int> resultado = new List<int>();
            RecorridoPreordenRecursivo(Raiz, resultado);
            return resultado;
        }
        private void RecorridoPreordenRecursivo(NodoArbol nodo, List<int> resultado)
        {
            if (nodo != null)
            {
                // Primero agregar el valor del nodo actual
                resultado.Add(nodo.Valor);

                // Luego recorrer el subárbol izquierdo
                RecorridoPreordenRecursivo(nodo.Izquierda, resultado);

                // Finalmente recorrer el subárbol derecho
                RecorridoPreordenRecursivo(nodo.Derecha, resultado);
            }
        }


        //METODO PARA RECORRER EL ARBOL - POSTORDEN
        public List<int> RecorridoPostorden()
        {
            List<int> resultado = new List<int>();
            RecorridoPostordenRecursivo(Raiz, resultado);
            return resultado;
        }
        private void RecorridoPostordenRecursivo(NodoArbol nodo, List<int> resultado)
        {
            if (nodo != null)
            {
                // Primero recorrer el subárbol izquierdo
                RecorridoPostordenRecursivo(nodo.Izquierda, resultado);

                // Luego recorrer el subárbol derecho
                RecorridoPostordenRecursivo(nodo.Derecha, resultado);

                // Finalmente agregar el valor del nodo actual
                resultado.Add(nodo.Valor);
            }
        }
    }
}
