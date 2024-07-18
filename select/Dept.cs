using EmpInterview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpInterview.select
{
    public class Dept
    {
        private readonly empinterviewEntities1 empEntity;
        public Dept()
        {
            empEntity = new empinterviewEntities1();
        }
        public IEnumerable<SelectListItem> GetDept()
        {
            var objSelectDeptList = new List<SelectListItem>();
            objSelectDeptList = (from obj in empEntity.TblDepts
                                 select new SelectListItem()
                                 {
                                     Text = obj.Dept,
                                     Value = obj.Id.ToString(),
                                     Selected = true
                                 }).ToList();
            return objSelectDeptList;
        }
    }
}