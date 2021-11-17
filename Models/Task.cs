using System;

namespace Models
{
    
    public class Task
    {
        //Construtor
        public Task(DateTime startDate,DateTime endDate ) {
            Created = DateTime.Now; 
            StartDate = startDate;
            EndDate = endDate;
        } 

        //Atributos ou propriedades
        public int Id { get; set; }
        public string Name { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime Created { get; set; }
        public Boolean End { get; set; }


        //ToString
        public override string ToString() =>
            $"Name: {Name}  | Project: {Project} | StartDate em: {StartDate} | EndDate em: {EndDate} | Created em: {Created} | END : {End}";
    }
}