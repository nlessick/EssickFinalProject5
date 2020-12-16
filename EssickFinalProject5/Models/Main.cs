using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EssickFinalProject5.Models
{
    public class Main : Response
    {
        //Main has many to many relationships with the Response and child class response2response
        //Since one post can have many main comments and main comments can have many responses
        public List<Response2Reponse> Response2Reponses { get; set; }
    }
}
