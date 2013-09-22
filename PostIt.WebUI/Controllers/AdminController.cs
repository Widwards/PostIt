using System.Collections.ObjectModel;
using Ninject;
using PostIt.Domain.Abstract;
using PostIt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PostIt.WebUI.Infrastructure.Auth;
using System.Web.UI.WebControls;
using PostIt.WebUI.Abstract;
using PostIt.WebUI.Models.ViewModels;

namespace PostIt.WebUI.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        [Inject]
        public INoteRepository repository { get; set; }
        //TODO:** need dependency resolver. attribute [Inject][DONE]
        [Inject]
        public IUserRepository userRepository { get; set; }

        [Inject]
        public IAutoMapper AutoMapper { get; set; }

        public AdminController()
        {
        }

        public ViewResult Index()
        {
            return View(repository.Notes);
        }


        public ViewResult Edit(int noteId)
        {
            Note note = repository.Notes.FirstOrDefault(x => x.NoteId == noteId);
            //TODO:** implement the view edit model [DONE]
            return View(note);
        }

        [HttpPost]
        [ValidateInput(false)] //TODO: very bad
        public ActionResult Edit(Note note)
        {
            if (!ModelState.IsValid)
            {
                //error
                return View(note);
            }

            repository.SaveNote(note);

            //TODO: implement a warning message [DONE]
            TempData["message"] = string.Format("{0} has been saved", note.Title);
            TempData["message-class"] = "message-info";
            return RedirectToAction("Index");

        }

        public ViewResult Create()
        {
            return View("Edit", new Note());
        }

        [HttpPost]
        public ActionResult Delete(int noteId)
        {
            Note note = repository.Notes.FirstOrDefault(x => x.NoteId == noteId);

            if (note != null)
            {
                repository.RemoveNote(note);
                TempData["message"] = string.Format("{0} has been deleted", note.Title);
                TempData["message-class"] = "message-deleted";
            }

            //TODO: implement the removal of model [DONE]
            return RedirectToAction("Index");
        }

        public ViewResult Users()
        {
            //TODO: *** List of users [DONE]
            return View(userRepository.Users);
        }




        ///////////////////////////////////
        ////////////////USERS//////////////
        ///////////////////////////////////
        [HttpGet]
        public ViewResult AddUser()
        {
            //ViewBag.msl = new MultiSelectList(roles, "Id", "Name");
            UserView newUser = new UserView {Login = "Widwards", Name = "Кислицин Никита", Password = "238652", Email = "theWidwards@gmail.com"};
            newUser.RolesList = userRepository.Roles.ToList();
            return View("EditUser", newUser);
        }
            
        [HttpPost]
        public ActionResult AddUser(UserView newUser, List<int> SelectedRoles)
        {
            var roles = new List<Role>();
            var allRoles = userRepository.Roles;

            foreach (int id in SelectedRoles)
            {
                var role = allRoles.FirstOrDefault(x => x.Id == id);
                roles.Add(role);
            }

            //newUser.Roles = newUser.SelectedRoles.Items as IEnumerable<Role>;
            newUser.Roles = roles;



            //newUser.Roles = new Collection<Role>() { userRepository.Roles.FirstOrDefault(x => x.Name == "User") };
            if (!ModelState.IsValid)
            {
                return View("EditUser", newUser);
            }

            //TODO:* Mapping [DONE] 
            var user = (User) AutoMapper.Map(newUser, typeof (UserView), typeof (User));
            userRepository.SaveUser(user);
            return RedirectToAction("Users");
        }
        
        
        
        

        [HttpGet]
        public ViewResult AddRole()
        {
            ViewBag.AllRoles = userRepository.Roles;
            return View(new Role());
        }
        [HttpPost]
        public ActionResult AddRole(Role newRole)
        {
            if(!ModelState.IsValid)
            {
                return View(newRole);
            }
            
            
            userRepository.AddRole(newRole);

            return RedirectToAction("AddRole");
        }



    }
}
