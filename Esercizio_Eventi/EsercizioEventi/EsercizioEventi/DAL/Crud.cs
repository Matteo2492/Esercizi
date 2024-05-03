using EsercizioEventi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioEventi.DAL
{
    internal static class Crud
    {
        public static bool Create(Object t)
        {
            bool check = false;
            using (var ctx = new AccLez28EventiContext())
            {
                try
                {
                    if(t.GetType() == typeof(Partecipanti)) {
                        Partecipanti tt = (Partecipanti)t;
                        ctx.Partecipantis.Add(tt);
                    }
                    else if (t.GetType() == typeof(Risorse))
                    {
                        Risorse tt = (Risorse)t;
                        ctx.Risorses.Add(tt);
                    }
                    else if (t.GetType() == typeof(Eventi))
                    {
                        Eventi tt = (Eventi)t;
                        ctx.Eventis.Add(tt);
                    }
                    else
                    {
                        Console.WriteLine("Errore");
                    }
                    ctx.SaveChanges();
                    Console.WriteLine("Inserimento avvenuto");
                    check = true;         
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return check;
        }
        public static List<Partecipanti> ReadPartecipanti()
        {
            using (var ctx = new AccLez28EventiContext())
            {
                try
                {
                    return ctx.Partecipantis.ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return new List<Partecipanti>();
        }
        public static List<Risorse> ReadRisorse()
        {
            using (var ctx = new AccLez28EventiContext())
            {
                try
                {
                    return ctx.Risorses.ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return new List<Risorse>();
        }
        public static List<Eventi> ReadEventi()
        {
            using (var ctx = new AccLez28EventiContext())
            {
                try
                {
                    return ctx.Eventis.ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return new List<Eventi>();
        }
        public static bool Update (Object t)
        {
            bool check = false;
            using (var ctx = new AccLez28EventiContext())
            {
                try
                {
                    if (t.GetType() == typeof(Partecipanti))
                    {
                        Partecipanti? tt = (Partecipanti)t;
                        tt = ctx.Partecipantis.Find(tt.PartecipanteId);
                        if (tt == null)
                            return check;
                        ctx.Entry(tt).CurrentValues.SetValues(t);
                        ctx.SaveChanges();
                        check = true;
                    }
                    else if (t.GetType() == typeof(Risorse))
                    {
                        Risorse? tt = (Risorse)t;
                        tt = ctx.Risorses.Find(tt.RisorsaId);
                        if (tt == null)
                            return check;
                        ctx.Entry(tt).CurrentValues.SetValues(t);
                        ctx.SaveChanges();
                        check = true;
                    }
                    else if (t.GetType() == typeof(Eventi))
                    {
                        Eventi? tt = (Eventi)t;
                        tt = ctx.Eventis.Find(tt.EventiId);
                        if (tt == null)
                            return check;
                        ctx.Entry(tt).CurrentValues.SetValues(t);
                        ctx.SaveChanges();
                        check = true;
                    }
                    else
                    {
                        Console.WriteLine("Errore");
                    }
                    ctx.SaveChanges();
                    Console.WriteLine("Update avvenuto");
                    check = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return check;
        }
        public static bool Delete(Object t)
        {
            bool check = false;
            using (var ctx = new AccLez28EventiContext())
            {
                try
                {
                    if (t.GetType() == typeof(Partecipanti))
                    {
                        Partecipanti? tt = (Partecipanti)t;
                        tt = ctx.Partecipantis.Find(tt.PartecipanteId);
                        if (tt == null)
                            return check;
                        ctx.Remove(tt);
                        ctx.SaveChanges();
                        check = true;
                    }
                    else if (t.GetType() == typeof(Risorse))
                    {
                        Risorse? tt = (Risorse)t;
                        tt = ctx.Risorses.Find(tt.RisorsaId);
                        if (tt == null)
                            return check;
                        ctx.Remove(tt);
                        ctx.SaveChanges();
                        check = true;
                    }
                    else if (t.GetType() == typeof(Eventi))
                    {
                        Eventi? tt = (Eventi)t;
                        tt = ctx.Eventis.Find(tt.EventiId);
                        if (tt == null)
                            return check;
                        ctx.Remove(tt);
                        ctx.SaveChanges();
                        check = true;
                    }
                    else
                    {
                        Console.WriteLine("Errore");
                    }
                    ctx.SaveChanges();
                    Console.WriteLine("Delete avvenuto");
                    check = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return check;
        }
    }
}
