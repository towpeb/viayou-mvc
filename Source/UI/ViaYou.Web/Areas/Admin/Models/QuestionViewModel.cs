using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ViaYou.Domain;
using ViaYou.Infraestructure.Mapping;

namespace ViaYou.Web.Areas.Admin.Models
{
    public class QuestionViewModel : IHaveCustomMappings
    {
        public QuestionViewModel()
        {
            SelectedAnswersIds = new List<int>();
        }
        public int Id { get; set; }
        [Required]
        public string Identifier { get; set; }
        [Required]
        public string Text { get; set; }
        public IEnumerable<SelectListItem> AvailableAnswers { get; set; }
        public List<int> SelectedAnswersIds { get; set; }
        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Question, QuestionViewModel>();
        }
    }
}