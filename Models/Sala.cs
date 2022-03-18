using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Repository;

namespace Models
{
    public class Sala
    {
        public int Id { set; get; }
        public string Numero { set; get; }
        public string Equipamentos { set; get; }

        public Sala()
        {}

        public Sala(
            string Numero,
            string Equipamentos
        )
        {
            this.Numero = Numero;
            this.Equipamentos = Equipamentos;
            Context db = new Context();
            db.Salas.Add(this);
            db.SaveChanges();
        }

        public override string ToString()
        {
            return $"ID: {this.Id}"
                + $"\nNúmero: {this.Numero}"
                + $"\nEquipamentos: {this.Equipamentos}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!Sala.ReferenceEquals(obj, this))
            {
                return false;
            }
            Sala it = (Sala) obj;
            return it.Id == this.Id;
        }


        public static List<Sala> GetSalas()
        {
            Context db = new Context();
            return (from Sala in db.Salas select Sala).ToList();
        }

        public static void AlterarSala(
            int Id,
            string Numero,
            string Equipamentos
        ) 
        {
            Context db = new Context();
            Sala sala = db.Salas.First(it => it.Id == Id);
            sala.Numero = Numero;
            sala.Equipamentos = Equipamentos;
            db.SaveChanges();
        }

        public static void RemoverSala(Sala sala)
        {
            Context db = new Context();
            db.Salas.Remove(sala);
            db.SaveChanges();
        }
    }
}