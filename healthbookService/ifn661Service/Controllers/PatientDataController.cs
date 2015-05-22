using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using Healthbook.DataObjects;
using Healthbook.Models;

namespace healthbook.Controllers
{
    public class PatientDataController : TableController<PatientData>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            HealthbookContext context = new HealthbookContext();
            DomainManager = new EntityDomainManager<PatientData>(context, Request, Services);
        }

        // GET tables/PatientData
        public IQueryable<PatientData> GetAllPatientData()
        {
            return Query(); 
        }

        // GET tables/PatientData/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<PatientData> GetPatientData(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/PatientData/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<PatientData> PatchPatientData(string id, Delta<PatientData> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/PatientData
        public async Task<IHttpActionResult> PostPatientData(PatientData item)
        {
            PatientData current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/PatientData/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeletePatientData(string id)
        {
             return DeleteAsync(id);
        }

    }
}