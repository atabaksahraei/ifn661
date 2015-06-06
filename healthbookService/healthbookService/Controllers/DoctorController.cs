using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using healthbookService.DataObjects;
using healthbookService.Models;

namespace healthbookService.Controllers
{
    public class DoctorController : TableController<Doctor>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            healthbookContext context = new healthbookContext();
            DomainManager = new EntityDomainManager<Doctor>(context, Request, Services);
        }

        // GET tables/Doctor
        public IQueryable<Doctor> GetAllDoctor()
        {
            return Query(); 
        }

        // GET tables/Doctor/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Doctor> GetDoctor(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Doctor/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Doctor> PatchDoctor(string id, Delta<Doctor> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Doctor
        public async Task<IHttpActionResult> PostDoctor(Doctor item)
        {
            Doctor current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Doctor/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteDoctor(string id)
        {
             return DeleteAsync(id);
        }

    }
}