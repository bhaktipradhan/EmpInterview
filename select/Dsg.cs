using EmpInterview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace EmpInterview.select
{
    public class Dsg
    {
        private readonly empinterviewEntities1 empEntity;
        public Dsg()
        {
            empEntity = new empinterviewEntities1();
        }
        public IEnumerable<SelectListItem> GetDsg()
        {
            var objSelectDsgList = new List<SelectListItem>();
            objSelectDsgList = (from obj in empEntity.TblDsgs
                                 select new SelectListItem()
                                 {
                                     Text = obj.Dsg,
                                     Value = obj.Id.ToString(),
                                     Selected = true
                                 }).ToList();
            return objSelectDsgList;
        }
    }
}