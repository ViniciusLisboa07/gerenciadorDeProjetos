using System;

namespace Models
{
    
    public class Project
    {
        //Construtor
        public Project() => Created = DateTime.Now;

        //Atributos ou propriedades
        public int Id { get; set; }
        public string Name { get; set; }
        public string User { get; set; }
        public string Company { get; set; }
        public DateTime Created { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //ToString
        public override string ToString() =>
            $"Name: {Name} | User: {User} | Company: {Company} |Created em: {Created}";
    }
}