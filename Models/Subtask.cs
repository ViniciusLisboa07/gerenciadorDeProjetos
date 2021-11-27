using System;

namespace Models
{
    
    public class Subtask
    {
        //Construtor
        public Subtask( ) {
            Created = DateTime.Now; 
        } 

        //Atributos ou propriedades
        public int Id { get; set; }
        public string Description { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
        public DateTime Created { get; set; }
        public Boolean End { get; set; }


        //ToString
        public override string ToString() =>
            $"Description: {Description}  | Task: {Task}  | Created em: {Created} | END : {End}";
    }
}