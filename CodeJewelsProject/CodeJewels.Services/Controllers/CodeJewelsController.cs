using CodeJewels.Data;
using CodeJewels.Models;
using CodeJewels.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CodeJewels.Services.Controllers
{
    public class CodeJewelsController : BaseController
    {
        [HttpPost]
        [ActionName("addjewel")]
        public HttpResponseMessage AddCodeJewel([FromBody] Code code)
        {
            var responses = ExceptionHandler(() =>
            {
                var context = new CodeJewelsContext();
                using (context)
                {
                    context.Codes.Add(code);
                    context.SaveChanges();

                    var response = this.Request.CreateResponse(HttpStatusCode.Created, code);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = code.Id }));

                    return response;
                }
            });

            return responses;
        }

        [HttpGet]
        [ActionName("getall")]
        public HttpResponseMessage GetAllCodeJewels()
        {
            var responses = ExceptionHandler(() =>
            {
                var context = new CodeJewelsContext();
                using (context)
                {
                    var jewels = context.Codes;

                    var models =
                        (from c in jewels
                         select new CodeModel
                         {
                             Id = c.Id,
                             SourseCode = c.SourceCode,
                             Category = c.Category.Name
                         });

                    var response = this.Request.CreateResponse(HttpStatusCode.Created, models);

                    return response;
                }
            });

            return responses;
        }

        [HttpGet]
        [ActionName("bysource")]
        public HttpResponseMessage SearchByCriteriaSource(string source)
        {
            var responses = ExceptionHandler(() =>
            {
                var context = new CodeJewelsContext();
                using (context)
                {
                    var jewels = context.Codes.Include("Category").Include("Votes").Where(code => code.SourceCode.Contains(source));

                    var models =
                       (from c in jewels
                        select new CodeModel
                        {
                            Id = c.Id,
                            SourseCode = c.SourceCode,
                            Category = c.Category.Name
                        });

                    var response = this.Request.CreateResponse(HttpStatusCode.Created, models);

                    return response;
                }
            });

            return responses;
        }

        [HttpGet]
        [ActionName("bycategory")]
        public HttpResponseMessage SearchByCriteriaCategory(string category)
        {
            var responses = ExceptionHandler(() =>
            {
                var context = new CodeJewelsContext();
                using (context)
                {
                    var jewels = context.Codes.Include("Category").Include("Votes").Where(code => code.Category.Name == category);
                    var models =
                       (from c in jewels
                        select new CodeModel
                        {
                            Id = c.Id,
                            SourseCode = c.SourceCode,
                            Category = c.Category.Name
                        });

                    var response = this.Request.CreateResponse(HttpStatusCode.Created, models);

                    return response;
                }
            });

            return responses;
        }
    }
}