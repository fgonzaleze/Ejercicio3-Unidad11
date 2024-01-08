
namespace Ejercicio3_Unidad11.Entities
{
    public class clsPersona
    {
        #region atributos

        private int id;
        private string nombre;
        private string apellido;
        private int idDepartamento;
        private DateTime fechaNac;
        private String foto;
        private String telefono;
        private String direccion;

        #endregion

        #region constructores

        public clsPersona() { }

        public clsPersona(string nombre, string apellido, int idDepartamento, int id, DateTime fechaNac, String foto, String telefono, String direccion)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.idDepartamento = idDepartamento;
            this.fechaNac = fechaNac;
            this.foto = foto;
            this.telefono = telefono;
            this.direccion = direccion;
        }

        #endregion

        #region propiedades

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public String Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public String Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public int IdDepartamento
        {
            get { return idDepartamento; }
            set { idDepartamento = value; }

        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime FechaNac
        {
            get { return fechaNac; }
            set { fechaNac = value; }
        }

        public String Foto
        {
            get { return foto; }
            set { foto = value; }
        }

        #endregion

    }
}
