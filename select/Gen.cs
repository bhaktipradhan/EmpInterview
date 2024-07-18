using EmpInterview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpInterview.select
{
    public class Gen
    {
        private readonly empinterviewEntities1 empEntity;
        public Gen()
        {
            empEntity = new empinterviewEntities1();
        }
        public IEnumerable<SelectListItem> GetGender()
        {
            var objSelectGenderList = new List<SelectListItem>();
            objSelectGenderList = (from obj in empEntity.Genders
                                 select new SelectListItem()
                                 {
                                     Text = obj.Gender1,
                                     Value = obj.Id.ToString(),
                                     Selected = true
                                 }).ToList();
            return objSelectGenderList;
        }
    }
}