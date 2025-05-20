namespace Arboles_De_Busqueda_Binaria.models
{
    public class NodoArbol
    {
        public int Valor { get; set; }
        public NodoArbol Izquierda { get; set; }
        public NodoArbol Derecha { get; set; }

        public NodoArbol(int valor)
        {
            Valor = valor;
        }
    }
}
