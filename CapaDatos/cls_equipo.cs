
using System;

namespace Banco.CapaDatos
{
    public class cls_equipo
    {
        private int equipoID;

        public int EquipoID
        {
            get { return equipoID; }
            set { equipoID = value; }
        }

        private string tipoEquipo;

        public string TipoEquipo
        {
            get { return tipoEquipo; }
            set { tipoEquipo = value; }
        }

        private string modelo;

        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }

        private int usuarioID;

        public int UsuarioID
        {
            get { return usuarioID; }
            set { usuarioID = value; }
        }
    }
}
