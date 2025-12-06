using AdvancedProgramming.Core;
using AdvancedProgramming.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AdvancedProgramming.Web.Controllers
{

    [Authorize]
    public class UserController : ControllerBase
    {
        public ActionResult Index()
        {
            var users = UserBusiness.GetUsers(id: 0);
            return View(users.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = UserBusiness.GetUsers((int)id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        public ActionResult Create()
        {
            SetFilters();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Name, Email, Password")] UserDetail user)
        {
            if (ModelState.IsValid)
            {
                UserBusiness.SaveOrUpdate(user);
                return RedirectToAction("Index");
            }
            SetFilters();
            return View(user);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = UserBusiness.GetUsers((int)id);
            if (user == null)
            {
                return HttpNotFound();
            }
            SetFilters();
            return View(user);
        }

        /// <summary>
        /// Processes the update of an existing user.
        /// </summary>
        /// <param name="user">The user object containing the updated data</param>
        /// <returns>Redirects to Index on success, or returns the edit view with validation errors</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Name, Email, Password")] UserDetail user)
        {
            if (ModelState.IsValid)
            {
                UserBusiness.SaveOrUpdate(user);
                return RedirectToAction("Index");
            }
            SetFilters();
            return View(user);
        }

        /// <summary>
        /// Displays the confirmation page for deleting a user.
        /// </summary>
        /// <param name="id">The unique identifier of the user to delete</param>
        /// <returns>View containing the delete confirmation, or BadRequest/NotFound if invalid</returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = UserBusiness.GetUsers((int)id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        /// <summary>
        /// Confirms and processes the deletion of a user.
        /// </summary>
        /// <param name="id">The unique identifier of the user to delete</param>
        /// <returns>Redirects to Index after successful deletion</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserBusiness.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
