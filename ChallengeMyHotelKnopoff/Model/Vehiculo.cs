namespace ChallengeMyHotel.Model
{
    public enum EstadoVehiculoEnum
    {
         Stock,
         Reservado,
         Vendido
    }
    /// <summary>
    /// Clase interna para manejo de vehiculo
    /// </summary>
    internal class Vehiculo
    {
        #region miembros privados

        private string _Patente;
        private string _Modelo;       
        private int _Anio;
        private EstadoVehiculoEnum _Estado;

        #endregion

        #region constructor
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="patente"></param>
        /// <param name="anio"></param>
        /// <param name="modelo"></param>
        public Vehiculo(string patente, int anio, string modelo)
        {
            _Patente = patente;
            _Anio = anio;
            _Estado = EstadoVehiculoEnum.Stock;
            _Modelo = modelo;
        }

        #endregion

        #region miembros publicos
    
        public string Patente { get { return _Patente; } }
        public string Modelo { get { return _Modelo; } }

        public EstadoVehiculoEnum Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
        public int Anio { get { return _Anio; } }

        #endregion
        public override string ToString()
        {
            return $"Patente: {_Patente} - Modelo: {_Modelo} - Año: {_Anio} - Estado {Estado.ToString()}";
        }
    }


}
