using Ubicua_Lectura_de_Datos.Db;
using Ubicua_Lectura_de_Datos.Utils;

string com = "COM9";

UtilCom uc = new UtilCom(com);
UtilDb db = new UtilDb();

while (true)
{
    Dato dato = uc.leer();

    if (dato != null)
    {
        db.add(dato);
    }
}