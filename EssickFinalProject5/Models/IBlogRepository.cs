using EssickFinalProject5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EssickFinalProject5.Repository
{
    public interface IBlogRepository
    {
        Post GetPost(int id);
        List<Post> GetAllPosts();
        void AddPost(Post post);
        void RemovePost(int id);
        void UpdatePost(Post post);

        void AddResponse2Response(Response2Reponse response);

        Task<bool> SaveChangesAsync();
    }
}
