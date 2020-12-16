using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EssickFinalProject5.Models;
using EssickFinalProject5.Repository;
using EssickFinalProject5.ViewModels;

namespace EssickFinalProject5.Controllers
{
    public class HomeController : Controller
    {
        private IBlogRepository repo;

        public HomeController(IBlogRepository repos)
        {
            repo = repos;

        }


        public IActionResult Index()
        {
            var posts = repo.GetAllPosts();
            return View(posts);
        }

        public IActionResult Post(int id)
        {
            var post = repo.GetPost(id);

            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> Response(ResponseViewModel rvm)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Post", new { id = rvm.PostId });

            var post = repo.GetPost(rvm.PostId);
            if (rvm.MainId == 0)
            {
                post.MainComments = post.MainComments ?? new List<Main>();

                post.MainComments.Add(new Main
                {
                    Content = rvm.Content,
                    Time = DateTime.Now,
                });

                repo.UpdatePost(post);
            }
            else
            {
                var response = new Response2Reponse
                {
                    MainId = rvm.MainId,
                    Content = rvm.Content,
                    Time = DateTime.Now,
                };
                repo.AddResponse2Response(response);
            }
            await repo.SaveChangesAsync();

            return RedirectToAction("Post", new { id = rvm.PostId });
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return View(new Post());
            else
            {
                var post = repo.GetPost((int)id);
                return View(post);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(Post post)
        {
            if (post.Id > 0)
                repo.UpdatePost(post);
            else
                repo.AddPost(post);


            if(await repo.SaveChangesAsync())
                return RedirectToAction("Index");
            else
                return View(post);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            repo.RemovePost(id);
            await repo.SaveChangesAsync();
            return RedirectToAction("Index");

        }

    }
}
