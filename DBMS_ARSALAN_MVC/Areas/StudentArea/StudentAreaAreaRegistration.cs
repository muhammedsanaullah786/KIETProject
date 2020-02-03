using System.Web.Mvc;

namespace DBMS_ARSALAN_MVC.Areas.StudentArea
{
    public class StudentAreaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "StudentArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "StudentArea_default",
                "StudentArea/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}