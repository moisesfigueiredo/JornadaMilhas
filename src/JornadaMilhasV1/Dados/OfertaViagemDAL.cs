using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Dados;
public class OfertaViagemDAL
{
    private readonly JornadaMilhasContext _context;

    public OfertaViagemDAL(JornadaMilhasContext context)
    {
        _context = context;
    }

    public void Adicionar(OfertaViagem oferta)
    {
        _context.OfertasViagem.Add(oferta);
        _context.SaveChanges();
    }

    public OfertaViagem? RecuperarPorId(int id)
    {
        return _context.OfertasViagem.FirstOrDefault(o => o.Id == id);
    }

    public IEnumerable<OfertaViagem>? RecuperarPor(Func<OfertaViagem, bool> predicate) =>
        _context.OfertasViagem.Where(predicate);

    public IEnumerable<OfertaViagem> RecuperarTodas()
    {
        return _context.OfertasViagem.ToList();
    }

    public void Atualizar(OfertaViagem oferta)
    {
        _context.OfertasViagem.Update(oferta);
        _context.SaveChanges();
    }

    public void Remover(OfertaViagem oferta)
    {
        _context.OfertasViagem.Remove(oferta);
        _context.SaveChanges();
    }

    public OfertaViagem? RecuperaMaiorDesconto(Func<OfertaViagem, bool> filtro)
    {
        return _context.OfertasViagem
            .Where(filtro)
            .Where(o => o.Ativa)
            .OrderBy(o => o.Preco)
            .FirstOrDefault();
    }
}
