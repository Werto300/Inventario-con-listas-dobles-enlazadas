using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario
{
    class Inventario
    {
        // TOTOS LOS MÉTODOS POSIBLES MENOS INSERTAR USAN RECURSIVIDAD

        public Producto primero { private set; get; }

        public void agregar(Producto nuevo)
        {
            if (primero == null)
                primero = nuevo;
            else
                agregar(nuevo, primero);
        }

        private void agregar(Producto nuevo, Producto último)
        {
            if (último.siguiente == null)
            {
                último.siguiente = nuevo;
                nuevo.anterior = último;
            }
            else
                agregar(nuevo, último.siguiente);
        }


        public void agregarAlInicio(Producto nuevo)
        {
            if (primero == null)
                primero = nuevo;
            else
            {
                primero.anterior = nuevo;
                nuevo.siguiente = primero;
                primero = nuevo;
            }
        }

        public Producto buscarProducto(int código)
        {
            if (primero == null)
                return null;
            else
                return buscarProducto(código, primero);
        }

        private Producto buscarProducto(int código, Producto último)
        {
            if (último != null)
            {
                if (último.código == código)
                    return último;
                else
                    return buscarProducto(código, último.siguiente);
            }
            else
                return null;
        }

        public bool insertar(Producto nuevo, int pos)
        {
            if (pos == 0)
            {
                agregarAlInicio(nuevo);
                return true;
            }
            else
            {
                Producto aux = primero;
                while (pos >= 2)
                {
                    if (aux == null)
                        return false;
                    pos--;
                    aux = aux.siguiente;
                }
                if (aux.siguiente != null)
                    aux.siguiente.anterior = nuevo;
                nuevo.siguiente = aux.siguiente;
                aux.siguiente = nuevo;
                nuevo.anterior = aux;
                return true;
            }
        }

        public bool eliminar(int código)
        {
            if (primero == null)
                return false;
            else if (primero.código == código)
            {
                primero = primero.siguiente;
                return true;
            }
            else
                return eliminar(código, primero);
        }

        private bool eliminar(int código, Producto último)
        {
            if (último != null)
            {
                if (último.código == código)
                {
                    último.anterior.siguiente = último.siguiente;
                    if (último.siguiente != null)
                        último.siguiente.anterior = último.anterior;
                    return true;
                }
                else
                    return eliminar(código, último.siguiente);
            }
            else
                return false;
        }

        public bool eliminarPrimero()
        {
            if (primero == null)
                return false;
            else
            {
                if (primero.siguiente != null)
                    primero.siguiente.anterior = null;
                primero = primero.siguiente;
                return true;
            }
        }

        public bool eliminarÚltimo()
        {
            if (primero == null)
                return false;
            else if (primero.siguiente == null)
                primero = null;
            else
                eliminarÚltimo(primero);
            return true;
        }

        private void eliminarÚltimo(Producto último)
        {
            if (último.siguiente == null)
                último.anterior.siguiente = null;
            else
                eliminarÚltimo(último.siguiente);
        }

        public string reporte(bool inverso)
        {
            if (primero == null)
                return "";
            else
                return reporte(primero, inverso);
        }

        private string reporte(Producto último, bool inverso)
        {
            if (último.siguiente == null)
                return último.ToString();
            else
            {
                if (inverso)
                    return reporte(último.siguiente, inverso) + último.ToString();
                else
                    return último.ToString() + reporte(último.siguiente, inverso);
            }
        }
    }
}
