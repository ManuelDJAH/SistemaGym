using System.Data;

public class MembresiaBL
{
    MembresiaDAO dao = new MembresiaDAO();

    public DataTable ListarMembresias()
    {
        return dao.ListarMembresias();
    }
}
