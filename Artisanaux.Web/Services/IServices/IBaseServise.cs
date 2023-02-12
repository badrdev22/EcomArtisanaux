using Artisanaux.Web.Models;

namespace Artisanaux.Web.Services.IServices;

public interface IBaseServise:IDisposable
{
    ResponseDto ResponseModel { get; set; }
    Task<T> SendAsync<T>(ApiRequest apiRequest);

}
