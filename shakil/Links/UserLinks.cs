using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZenBD_API.Links
{
    public class UserLinks
    {
        static List<Link> links = new List<Link>();
        public static List<Link> getLinks(int id=0,int r = 0)
        {
            if (r == 1)
            {
                links.Add(new Link() { Url = "http://localhost:10022/api/users/" + id, Method = "GET", Relation = "Self" });
                links.Add(new Link() { Url = "http://localhost:10022/api/users/", Method = "GET", Relation = "Get All Users" });
                links.Add(new Link() { Url = "http://localhost:10022/api/users/", Method = "POST", Relation = "Add User" });
                links.Add(new Link() { Url = "http://localhost:10022/api/users/" + id, Method = "PUT", Relation = "Update User" });
                links.Add(new Link() { Url = "http://localhost:10022/api/users/" + id, Method = "DELETE", Relation = "Delete User" });


            }
            
            else if (r == 2)
            {
                links.Add(new Link() { Url = "http://localhost:10022/api/products/" + id, Method = "GET", Relation = "Self" });
                links.Add(new Link() { Url = "http://localhost:10022/api/products/", Method = "GET", Relation = "Get All Products" });
                links.Add(new Link() { Url = "http://localhost:10022/api/products/", Method = "POST", Relation = "Add Product" });
                links.Add(new Link() { Url = "http://localhost:10022/api/products/" + id, Method = "PUT", Relation = "Update Product" });
                links.Add(new Link() { Url = "http://localhost:10022/api/products/" + id, Method = "DELETE", Relation = "Delete Product" });


            }
            else
            {
                //links.Add(new Link() { Url = "http://localhost:10022/api/products/" + id, Method = "GET", Relation = "Get User Dashboard" });
            }




            return links;
        }
    }
}