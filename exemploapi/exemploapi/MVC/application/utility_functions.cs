namespace utility_functions
{
    public class utilityFunctions
    {
        public static bool conferir_login_user(HttpContext httpContext)
        {
            if (httpContext.Session.GetString("Eh_Admin") == "False")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool conferir_login_admin(HttpContext httpContext)
        {
            if (httpContext.Session.GetString("Eh_Admin") == "True")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

}