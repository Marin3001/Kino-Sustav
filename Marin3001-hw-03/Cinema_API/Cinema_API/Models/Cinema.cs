/*
 **********************************
 * Author: Marin Uzinić
 * Project Task: Homework 3 - Cinema
 **********************************
 * Description:
 *  
 *  This file contains domain model which defines Cinema class and it's properties
 *  which include:
 *      -Id for unique identification
 *      -Name for the name of the cinema
 *      -Location which specifies the city of the cinema
 *      -Projected movie 
 *      -Row specifies row number
 *      -Seat indicates seat number
 *
 **********************************
 */
namespace Cinema_API.Models
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Movie { get; set; }
        public int? Rows { get; set; }
        public int? Seats { get; set; }
    }
}
