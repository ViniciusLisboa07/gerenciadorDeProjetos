using System;

namespace Models
{
    
    public class User
    {
        //Construtor
        public User() => Created = DateTime.Now;

        //Atributos ou propriedades
        public int Id { get; set; }
        public string Name { get; set; }
        public string Office { get; set; }
        public string Company { get; set; }
        public DateTime Created { get; set; }

        //ToString
        public override string ToString() =>
            $"Name: {Name} | Office: {Office} | Company: {Company} | Created em: {Created}";
    }
}