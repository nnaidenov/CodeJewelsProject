using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CodeJewels.Data;
using CodeJewels.Models;

namespace CodeJewels.Services.Controllers
{
    public class VoteController : BaseController
    {
        [HttpPost]
        [ActionName("addvote")]
        public HttpResponseMessage AddVote(int id, [FromBody] Vote vote)
        {
            var responses = ExceptionHandler(() =>
            {
                var context = new CodeJewelsContext();
                using (context)
                {
                    var jewel = context.Codes.FirstOrDefault(j => j.Id == id);
                    if (jewel == null)
                    {
                        throw new InvalidOperationException("The jewel does not exists!");
                    }

                    jewel.Votes.Add(vote);
                    context.Votes.Add(vote);
                    context.SaveChanges();

                    var response = this.Request.CreateResponse(HttpStatusCode.Created, vote);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = vote.Id }));
                    return response;
                }
            });

            return responses;
        }
    }
}
