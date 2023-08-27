using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace VideoGameLibrary_PartOne.Models
{
    public class Game
    {
        [Required]
        public int Id { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Title { get; set; } = null;
        [Column(TypeName = "varchar(500)")]
        public string Platform { get; set; } = null;
        [Column(TypeName = "varchar(500)")]
        public string Genre { get; set; } = null;
        [Column(TypeName = "varchar(500)")]
        public string ESRB { get; set; } = null;
        [Column(TypeName = "int")]
        public int Year { get; set; } = 0;

        public string ImageLink { get; set; } = null;

        public string LoanStatus { get; set; } = null;

        public DateTime? LoanDate { get; set; }

        public Game()
        {

        }

        public Game(int id, string title, string platform, string genre, string esrb, int year, string imageLink)
        {
            this.Id = id;
            this.Title = title;
            this.Platform = platform;
            this.Year = year;
            this.Genre = genre;
            this.ESRB = esrb;
            this.ImageLink = imageLink;
        }

        public Game(int id, string title, string platform, string genre, string esrb, int year, string imageLink,
            string loanStatus, DateTime? loanDate)
        {
            this.Id = id;
            this.Title = title;
            this.Platform = platform;
            this.Genre = genre;
            this.ESRB = esrb;
            this.Year = year;
            this.ImageLink = imageLink;
            this.LoanStatus = loanStatus;
            this.LoanDate = loanDate;
        }
    }
}
