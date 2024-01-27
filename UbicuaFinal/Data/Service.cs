namespace UbicuaFinal.Data
{
    public class Service
    {
        private UbicuaDbContext _contex;
        public Service (UbicuaDbContext context)
        {
            _contex = context;
        }

        public List<Dato> datos()
        {
            List<Dato> data = new List<Dato> ();
            try
            {
                data = _contex.Datos.ToList().OrderByDescending( x => x.date).ToList();
            } catch (Exception ex)
            {
                Console.WriteLine (ex);
            }

            return data;
        }
    }
}
