using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Web.Mvc;

namespace Agathas.Storefront.Controllers.JsonDTOs
{
    [DataContract]
    [ModelBinder(typeof(JsonModelBinder))]
    public class JsonBasketQtyUpdateRequest
    {
        [DataMember]
        public JsonBasketItemUpdateRequest[] Items { get; set; }
    }

}
