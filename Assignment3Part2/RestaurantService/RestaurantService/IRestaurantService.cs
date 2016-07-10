using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestaurantService
{
    [ServiceContract]
    public interface IRestaurantService
    {
        [WebGet(UriTemplate = "restaurants/{postalCode}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        RestaurantData GetRestaurants(string postalCode);

    }
}
