using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using kaigang.Models.Entities;
using kaigang.Models.Repositories;
using kaigang.Models.Repositories.Interfaces;

namespace kaigang.Models.Services
{
    public class PostService
    {
       private IRepository<Post> serviceRepository;
       public PostService(IRepository<Post> serviceRepository)
       {
            this.serviceRepository = serviceRepository;     
       } 

       public bool AddPost(Post post)
       {
            return this.serviceRepository.Add(post);
       }
    }
}