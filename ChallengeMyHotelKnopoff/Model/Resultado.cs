namespace ChallengeMyHotel.Model
{
    public  class Resultado
    {
        public bool Exito { get; set; } = true;

        public string Mensaje { get; set; }

        public void AsignarResultado (bool exito, string mensaje)
        {
            Exito = exito;
            Mensaje = mensaje;
        }
    }
}
