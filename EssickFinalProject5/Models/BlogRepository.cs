using EssickFinalProject5.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EssickFinalProject5.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private BlogContext context;  

        public BlogRepository(BlogContext ctx)
        {
            context = ctx;
        }

        public void AddPost(Post post) 
        {
            context.Posts.Add(post);
        }

        public List<Post> GetAllPosts()
        {
            return context.Posts.ToList();
        }

        public Post GetPost(int id)
        {

            return context.Posts
                .Include(p => p.MainComments)
                    .ThenInclude(mc => mc.Response2Reponses)
                .FirstOrDefault(c => c.Id == id);
        }

        public void RemovePost(int id)
        {
            context.Posts.Remove(GetPost(id));
        }

        public void UpdatePost(Post post)
        {
            context.Posts.Update(post);
        }

        public async Task<bool> SaveChangesAsync()
        {
            if(await context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
            
        }

        public void AddResponse2Response(Response2Reponse response)
        {
            context.Response2Reponses.Add(response);
        }
    }
}
