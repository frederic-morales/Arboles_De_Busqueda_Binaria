using Arboles_De_Busqueda_Binaria.models;

namespace Arboles_De_Busqueda_Binaria.services
{
    public class ArbolBinarioBusqueda
    {
        public NodoArbol Raiz { get; private set; }

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
    }
}
