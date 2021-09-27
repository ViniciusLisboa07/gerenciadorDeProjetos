using System;

namespace Models
{
    
    public class Project
    {
        //Construtor
        public Project() => CriadoEm = DateTime.Now;

        //Atributos ou propriedades
        public int Id { get; set; }
        public string Name { get; set; }
        public string User { get; set; }
        public string Company { get; set; }
        public DateTime Created { get; set; }

        //ToString
        public override string ToString() =>
            $"Name: {Name} | User: {User} | Company: {Company} |Criado em: {CriadoEm}";
    }
}