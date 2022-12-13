
using Microsoft.AspNetCore.Mvc;

namespace CPM.Dimension.Presentation.Controllers.Base
{
    /// <summary>
    /// Base controller for al API controller classes 
    /// </summary>
    [Microsoft.AspNetCore.Components.Route("api/v1/[controller]")]
    [ApiController, Produces("application/json")]
    public abstract class ApiControllerBase : ControllerBase
    {
    }
}
