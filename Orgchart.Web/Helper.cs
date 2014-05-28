using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Orgchart.Web.Infrastructure;

namespace Orgchart.Web
{
    public class Helper
    {
        //public static List<SelectListItem> GetDropDownList<T>(string text, string value, string selected)
        //    where T : class
        //{
        //    var db = new DatabaseContext();
        //    var list = new List<SelectListItem>();
        //    list.Add(new SelectListItem { Text = "-Please select-", Value = string.Empty });
        //    //IQueryable<T> result = db.Repository<T>();
        //    //var lisData = (from items in db
        //    //               select items).AsEnumerable().Select(m => new SelectListItem
        //    //               {
        //    //                   Text = (string)m.GetType().GetProperty(text).GetValue(m),
        //    //                   Value = (string)m.GetType().GetProperty(value).GetValue(m),
        //    //                   Selected = (selected != "") && ((string)
        //    //                       m.GetType().GetProperty(value).GetValue(m) ==
        //    //                                                   selected ? true : false),
        //    //               }).ToList();

        //    //var lisData = (from depts in db.Departments select depts.Name).AsEnumerable().Select(m => new SelectListItem
        //    //               {
        //    //                   Text = value.ToString(),

        //    //                   Value = value.ToString(),

        //    //                   Selected = value == depts,
        //    //               }).ToList();
        //    list.AddRange(lisData);
        //    return list;
        //}
    }
}